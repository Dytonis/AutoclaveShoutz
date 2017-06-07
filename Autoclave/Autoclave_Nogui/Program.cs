using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoclave;
using Autoclave.Pages;
using System.Threading;
using System.IO;
using System.Media;

namespace Autoclave_Nogui
{
    class Program
    {
        static System.Timers.Timer MainTimer = new System.Timers.Timer();
        static ProgramStatus Status;
        static ProgramAction Action;
        public static SequentialSlave Slave;

        static float RenderTimer;
        static float CurrentRenderTimerCount;
        static float DeltaTime;
        static DateTime LastTick;

        public static List<LotteryNumber> NumbersList = new List<LotteryNumber>();

        [STAThread]
        static void Main(string[] args)
        {
            MainTimer.Interval = 300;
            MainTimer.Elapsed += MainTimer_Elapsed;
            MainTimer.Start();
            Status = ProgramStatus.Program_Idle;
            Action = ProgramAction.Action_PopSlaveThenApply;
            InputLoop();
        }

        public static void InputLoop()
        {
            while (true)
            {
                string command = Console.ReadLine().ToLower();
                string[] splits = command.Split(' ');

                if(splits[0] == "action")
                {
                    if(splits.Length >= 2)
                    {
                        if(splits[1] == "slave")
                        {
                            Action = ProgramAction.Action_PopSlave;
                        }
                        else if (splits[1] == "mix")
                        {
                            Action = ProgramAction.Action_PopSlaveThenApply;
                        }
                        else if (splits[1] == "auto")
                        {
                            Action = ProgramAction.Action_Full;
                        }
                    }

                    AddToConsole("ProgramAction is " + Action.ToString());
                }
                else if(splits[0] == "start")
                {
                    RenderTimer = 10000;
                    if (splits.Length >= 2)
                    {
                        try
                        {
                            RenderTimer = Convert.ToInt16(splits[1]) * 1000;
                        }
                        catch
                        {
                            AddToConsole("Incorrect format.");
                            continue;
                        }
                    }
                    Status = ProgramStatus.Program_Waiting;
                    AddToConsole("AUTOCLAVE Started");
                }
                else if (command == "slave")
                {
                    if (Slave != null)
                        Slave.Close();

                    Status = ProgramStatus.Program_Idle;

                    Slave = new SequentialSlave();
                    Slave.Sequence = NumbersList;
                    SystemSounds.Exclamation.Play();

                    Slave.ShowDialog();

                    NumbersList.Clear();
                }
                else
                {
                    AddToConsole("\'" + command + "\' not recognized.");
                }
            }
        }

        private static int lateUpdate = 0;
        private static void MainTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Status != ProgramStatus.Program_Waiting)
            {
                return;
            }

            DeltaTime = LastTick.Subtract(DateTime.Now).Duration().Milliseconds;

            if (CurrentRenderTimerCount >= RenderTimer)
            {
                CurrentRenderTimerCount = 0;
                Status = ProgramStatus.Program_Rendering;

                Cycle();
            }
            else
            {
                CurrentRenderTimerCount += DeltaTime;

                if (lateUpdate >= 6)
                {
                    AddToConsole(CurrentRenderTimerCount + "ms of " + RenderTimer + "ms elapsed.");
                    lateUpdate = 0;
                }
                else
                    lateUpdate++;
            }

            LastTick = DateTime.Now;
        }

        internal static void SlaveFinished()
        {
            if(Action == ProgramAction.Action_PopSlaveThenApply)
            {

            }

            Status = ProgramStatus.Program_Waiting;
        }

        private static void Cycle()
        {
            Status = ProgramStatus.Program_Rendering;
            NumbersList.Clear();
            States.CachedURLS.Clear();

            Thread t = new Thread(new ThreadStart(() =>
            {
                int run = 0;
                int iS = 0;
                foreach (State state in States.AllStates)
                {
                    int iL = 0;
                    foreach (Lottery lottery in state.lotteries)
                    {
                        try
                        {
                            UpdateStatusText("Cycles Render (" + run + " / " + States.AllStates.Sum(x => x.lotteries.Count) + ")");
                            AddToConsole("Rendering " + lottery.url + "...");


                            if (lottery.Action == LotteryDecodeAction.Decode)
                            {
                                HandleUpdateIfNeeded(DecodeNumbers(lottery));
                            }
                            else if (lottery.Action == LotteryDecodeAction.DateTrigger)
                            {
                                lottery.LoadHtml(lottery.url);
                                HandleDateTrigger(DecodeDate(lottery, true), lottery);
                            }
                            else if (lottery.Action == LotteryDecodeAction.Skip)
                            {
                                AddToConsole("    ...Action is SKIP.");
                            }
                            iL++;
                            run++;

                            UpdateStatusText("Cycles Render (" + run + " / " + States.AllStates.Sum(x => x.lotteries.Count) + ")");
                            //AddToConsole(num.lottery.lotteryNameUI + " finished.");
                        }
                        catch (NumbersUnavailableExcpetion)
                        {
                            AddToConsole("    ...Currently unavailabele/pending.");
                            continue;
                        }
                        catch (MissingFieldException)
                        {
                            AddToConsole("    ...Server returned an invalid response.");
                        }
                        catch (IOException)
                        {
                            AddToConsole("IO exception while running " + lottery.lotteryName);
                        }
                        catch (System.Net.WebException ex)
                        {
                            if (ex.InnerException != null)
                                if (ex.InnerException.Message.Contains("closed."))
                                {
                                    AddToConsole("    ...The host closed the connection.");
                                    continue;
                                }
                            AddToConsole("Web exception while running " + lottery.lotteryName);
                            continue;
                        }
                        catch (Exception ex)
                        {
                            AddToConsole("Unknown exception while running " + lottery.lotteryName);
                            AddToConsole("    ..." + ex.Message);
                            if (ex.InnerException != null)
                                AddToConsole("    ..." + ex.InnerException.Message);
                            AddToConsole("Stack trace: \n" + ex.StackTrace);
                            continue;
                        }

                    }
                    iS++;
                }

                CycleEndedAsync();
            }));

            t.Start();
        }

        private static async void CycleEndedAsync()
        {
            Status = ProgramStatus.Program_Idle;

            if ((Action == ProgramAction.Action_PopSlave) && NumbersList.Count > 0)
            {
                Status = ProgramStatus.Program_Applying;

                AddToConsole("");
                AddToConsole("Autoclave detected " + NumbersList.Count + " updates.");
                foreach (LotteryNumber n in NumbersList)
                {
                    AddToConsole("    [" + n.lottery.lotteryName + "]");
                }
                AddToConsole("");

                Slave = new SequentialSlave();
                Slave.Sequence = NumbersList;
                SystemSounds.Exclamation.Play();

                Slave.ShowDialog();

                NumbersList.Clear();

                Status = ProgramStatus.Program_Waiting;
            }
            else if (Action == ProgramAction.Action_Full || Action == ProgramAction.Action_PopSlaveThenApply)
            {
                AddToConsole("");
                AddToConsole("Autoclave detected " + NumbersList.Count + " updates.");
                foreach (LotteryNumber n in NumbersList)
                {
                    AddToConsole("    [" + n.lottery.lotteryName + "]");
                }
                AddToConsole("");

                if(NumbersList.Count <= 0)
                {
                    Status = ProgramStatus.Program_Waiting;
                    return;
                }

                if (Action == ProgramAction.Action_PopSlaveThenApply)
                {
                    Slave = new SequentialSlave();
                    Slave.Sequence = NumbersList;
                    SystemSounds.Exclamation.Play();

                    Slave.ShowDialog();
                }

                TextUtils.DashBox("Deploying updates to LH.com...");
                Console.WriteLine();
                Console.WriteLine();
                AddToConsole("Creating JSON object...");

                DataEntryAPI.EntryImporterWebRequest request = NumbersListToConcreteJson.ToJson(NumbersList);

                AddToConsole("Complete.");
                if (request.draw_data.Length <= 0)
                {
                    AddToConsole(" --- All updates are FullAutoAction.DoNothing. No updates will be deployed.");
                    AddToConsole("");
                    Status = ProgramStatus.Program_Waiting;
                    return;
                }
                else
                {
                    AddToConsole("Submitting data to LHAPI...");
                    DataEntryAPI.EntryImporterWebResponse response = await DataEntryAPI.Entry.EntryImporter(request);
                    AddToConsole("Complete.");
                    Status = ProgramStatus.Program_Waiting;
                }
            }
            else
            {
                Status = ProgramStatus.Program_Waiting;
            }
            NumbersList.Clear();
        }

        private static void UpdateStatusText(string v)
        {
            Console.Title = v;
        }

        public static LotteryNumber DecodeNumbers(Lottery l)
        {
            for (int tries = 0; tries < 3; tries++)
            {
                try
                {
                    l.LoadHtml(l.url);
                    IStateDecodable decode = l.state as IStateDecodable;
                    LotteryNumber num = decode.GetLatestNumbers(l);
                    return num;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        if (ex.InnerException.Message.Contains("closed."))
                        {
                            AddToConsole("    ...The host closed the connection.");
                            AddToConsole("    ...Retrying (" + (tries + 1) + " of 3)");
                            Thread.Sleep(1000);
                            continue;
                        }
                    AddToConsole("Unknown exception while running " + l.lotteryName);
                    AddToConsole("    ..." + ex.Message);
                    if (ex.InnerException != null)
                        AddToConsole("    ..." + ex.InnerException.Message);
                    AddToConsole("Stack trace: \n" + ex.StackTrace);
                }
            }

            throw new NumbersUnavailableExcpetion();
        }

        public static DateTime DecodeDate(Lottery l)
        {
            for (int tries = 0; tries < 3; tries++)
            {
                try
                {
                    l.LoadHtml(l.url);
                    IStateDecodable decode = l.state as IStateDecodable;
                    DateTime date = decode.GetLatestDate(l);
                    return date;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        if (ex.InnerException.Message.Contains("closed."))
                        {
                            AddToConsole("    ...The host closed the connection.");
                            AddToConsole("    ...Retrying (" + (tries + 1) + " of 3)");
                            Thread.Sleep(1000);
                            continue;
                        }

                    AddToConsole("Unknown exception while running " + l.lotteryName);
                    AddToConsole("    ..." + ex.Message);
                    if (ex.InnerException != null)
                        AddToConsole("    ..." + ex.InnerException.Message);
                    AddToConsole("Stack trace: \n" + ex.StackTrace);
                }
            }

            throw new NumbersUnavailableExcpetion();
        }
        public static DateTime DecodeDate(Lottery l, bool skipLoad)
        {
            for (int tries = 0; tries < 3; tries++)
            {
                try
                {
                    if (!skipLoad)
                        l.LoadHtml(l.url);

                    IStateDecodable decode = l.state as IStateDecodable;
                    DateTime date = decode.GetLatestDate(l);
                    return date;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        if (ex.InnerException.Message.Contains("closed."))
                        {
                            AddToConsole("    ...The host closed the connection.");
                            AddToConsole("    ...Retrying (" + (tries + 1) + " of 3)");
                            Thread.Sleep(1000);
                            continue;
                        }
                    AddToConsole("Unknown exception while running " + l.lotteryName);
                    AddToConsole("    ..." + ex.Message);
                    if (ex.InnerException != null)
                        AddToConsole("    ..." + ex.InnerException.Message);
                    AddToConsole("Stack trace: \n" + ex.StackTrace);
                    break;
                }
            }

            throw new NumbersUnavailableExcpetion();
        }

        public static void HandleUpdateIfNeeded(LotteryNumber num, int recursivecalls = 0)
        {
            try
            {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (File.Exists(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html"))
                {
                    //save the new html
                    string writeHTML = num.lottery.html;
                    num.lottery.html = File.ReadAllText(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html");
                    if (String.IsNullOrWhiteSpace(num.lottery.html))
                    {
                        AddToConsole("    ...Record blank. Deleting...");
                        File.Delete(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html");
                        Directory.CreateDirectory(path + "\\Autoclave\\Save\\");
                        NumbersList.Add(num);
                        File.WriteAllText(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html", writeHTML);
                        AddToConsole("    ...Record re-made. This will cause a slave update.");

                    }
                    IStateDecodable decode = num.lottery.state as IStateDecodable;
                    LotteryNumber numold = decode.GetLatestNumbers(num.lottery);

                    bool numsMatch = false;
                    for (int i = 0; i < num.numbers.Length; i++)
                    {
                        if (numold.numbers.Length != num.numbers.Length)
                        {
                            numsMatch = false;
                            break;
                        }
                        if (numold.numbers[i].Equals(num.numbers[i]))
                        {
                            numsMatch = true;
                            break;
                        }
                    }

                    if (!numsMatch || num.date != numold.date) //sense update
                    {
                        NumbersList.Add(num);
                        File.WriteAllText(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html", writeHTML);
                        AddToConsole("    ...Update found.");
                    }
                }
                else
                {
                    Directory.CreateDirectory(path + "\\Autoclave\\Save\\");
                    NumbersList.Add(num);
                    File.WriteAllText(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html", num.lottery.html);
                    AddToConsole("    ...No record.");
                }
            }
            catch (NumbersUnavailableExcpetion)
            {
                AddToConsole("    ...Currently unavailabele/pending.");
            }
            catch (Exception ex)
            {
                AddToConsole("Exception while running " + num.lottery.lotteryName);

                AddToConsole("    ..." + ex.Message);
                if (ex.InnerException != null)
                    AddToConsole("    ..." + ex.InnerException.Message);
                AddToConsole("Stack trace: \n" + ex.StackTrace);
            }
        }
        public static void HandleDateTrigger(DateTime date, Lottery lot)
        {
            try
            {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (File.Exists(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html"))
                {
                    string writeHTML = lot.html;
                    lot.html = File.ReadAllText(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html");
                    if (String.IsNullOrWhiteSpace(lot.html))
                    {
                        AddToConsole("    ...Record blank. Deleting...");
                        File.Delete(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html");
                        Directory.CreateDirectory(path + "\\Autoclave\\Save\\");
                        NumbersList.Add(new LotteryNumber
                        {
                            date = date,
                            lottery = lot,
                            numbers = new string[] { "Date Trigger Only" },
                        });
                        File.WriteAllText(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html", writeHTML);
                        AddToConsole("    ...Record re-made. This will cause a slave update.");

                    }
                    IStateDecodable decode = lot.state as IStateDecodable;
                    DateTime dateold = decode.GetLatestDate(lot);

                    if (date != dateold) //sense update
                    {
                        NumbersList.Add(new LotteryNumber
                        {
                            date = date,
                            lottery = lot,
                            numbers = new string[] { "Date Trigger Only" },
                        });
                        File.WriteAllText(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html", writeHTML);
                        AddToConsole("    ...Update found.");
                    }
                }
                else
                {
                    Directory.CreateDirectory(path + "\\Autoclave\\Save\\");
                    NumbersList.Add(new LotteryNumber
                    {
                        date = date,
                        lottery = lot,
                        numbers = new string[] { "Date Trigger Only" },
                    });
                    File.WriteAllText(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html", lot.html);
                    AddToConsole("    ...No record.");
                }
            }
            catch (NumbersUnavailableExcpetion)
            {
                AddToConsole("    ...Currently unavailabele/pending.");
            }
            catch (Exception ex)
            {
                AddToConsole("Exception while running " + lot.lotteryName);
                AddToConsole("    ..." + ex.Message);
                if (ex.InnerException != null)
                    AddToConsole("    ..." + ex.InnerException.Message);
                AddToConsole("Stack trace: \n" + ex.StackTrace);
            }
        }

        private static void AddToConsole(string v)
        {
            Console.WriteLine(v);
        }
    }

    public enum ProgramStatus
    {
        Program_Idle,
        Program_Waiting,
        Program_Rendering,
        Program_Applying,
        Program_Fatal,
    }
    public enum ProgramAction
    {
        Action_None,
        Action_PopSlave,
        Action_PopSlaveThenApply,
        Action_Full,
    }

    public class TextUtils
    {
        public static void DashBox(string text)
        {
            Console.WriteLine();
            Console.Write("////");
            for (int i = 0; i < text.Length + 2; i++)
            {
                Console.Write("/");
            }
            Console.WriteLine("////");
            Console.WriteLine("//// " + text + " ////");
            Console.Write("////");
            for (int i = 0; i < text.Length + 2; i++)
            {
                Console.Write("/");
            }
            Console.Write("////");
        }
    }

    public class NumbersListToConcreteJson
    {
        public static DataEntryAPI.EntryImporterWebRequest ToJson(List<LotteryNumber> list)
        {
            DataEntryAPI.EntryImporterWebRequest request = new DataEntryAPI.EntryImporterWebRequest();

            List<DataEntryAPI.EntryImporterWebRequest.EntryImporterDrawData> dataList = new List<DataEntryAPI.EntryImporterWebRequest.EntryImporterDrawData>();

            if (DataEntryAPI.Auth.isProduction)
                request.data_key = DataEntryAPI.Auth.AuthToken_Prod;
            else
                request.data_key = DataEntryAPI.Auth.AutoToken_Test;

            foreach(LotteryNumber n in list)
            {
                DataEntryAPI.EntryImporterWebRequest.EntryImporterDrawData data = new DataEntryAPI.EntryImporterWebRequest.EntryImporterDrawData();

                if (n.lottery.Submit == FullAutoAction.SubmitFull)

                {
                    data.draw_date = n.date.ToShortDateString();
                    data.picks = n.numbers;
                    data.multiplier = n.multiplier;
                    data.lottery_id = n.lottery.lottery_id;
                    data.specials = n.specials;

                    foreach (string p in data.picks)
                    {
                        p.Trim();
                    }

                    dataList.Add(data);
                }
            }

            request.draw_data = dataList.ToArray();

            return request;
        }
    }
}
