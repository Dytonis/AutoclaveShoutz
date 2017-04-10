using Autoclave.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Windows.Forms;

namespace Autoclave
{
    public class Autoclave
    {
        public double seconds = 1;
        public bool Debug = false;
        public Main main;

        public bool Cycling = false;

        private bool _running;
        public bool Running
        {
            get
            {
                return _running;
            }
            set
            {
                _running = value;
                RunningUpdated();
            }
        }

        System.Diagnostics.Stopwatch watch;
        System.Timers.Timer update;
        public Autoclave()
        {
            update = new System.Timers.Timer(15000);
            update.Elapsed += Update_Elapsed;
            update.Start();
            watch = new System.Diagnostics.Stopwatch();
        }

        private void Update_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(Running && !Cycling)
                main.AddToConsole((watch.ElapsedMilliseconds / 1000).ToString() + " seconds elapsed of " + seconds + ". (" + (((watch.ElapsedMilliseconds / 1000) / seconds) * 100).ToString(".##") + "%)");
        }

        public System.Timers.Timer ticker;
        public void RunningUpdated()
        {
            if(ticker == null)
            {
                main.AddToConsole("Autoclave init...");
                ticker = new System.Timers.Timer(seconds * 1000);
                ticker.Elapsed += new ElapsedEventHandler(Tick);
                main.AddToConsole("Finished.");
            }
            if (Running)
            {
                watch.Reset();
                watch.Start();
                main.AddToConsole("Autoclave starting...");
                ticker = new System.Timers.Timer(seconds * 1000);
                ticker.Elapsed += new ElapsedEventHandler(Tick);
                ticker.Start();
            }
            else
            {
                watch.Reset();
                watch.Stop();
                main.AddToConsole("Autoclave stopping...");
                ticker.Stop();
            }
            main.AddToConsole("Autoclave ready.");
        }

        public void Cycle(bool force = false)
        {
            main.AddToConsole("Cycles Render starting...");

            main.NumbersList.Clear();
            States.CachedURLS.Clear();
            watch.Stop();
            watch.Reset();

            Thread t = new Thread(new ThreadStart(() =>
            {
                int run = 0;
                int iS = 0;
                foreach (State state in States.AllStates)
                {
                    state.main = main;
                    int iL = 0;
                    foreach (Lottery lottery in state.lotteries)
                    {
                        try
                        {
                            if (!Running && !force)
                                return;

                            main.UpdateProgressBar1(run, States.AllStates.Sum(x => x.lotteries.Count));
                            main.UpdateStatusText("Cycles Render (" + run + " / " + States.AllStates.Sum(x => x.lotteries.Count) + ")");
                            main.AddToConsole("Rendering " + lottery.url + "...");


                            if (lottery.Action == LotteryDecodeAction.Decode)
                            {
                                HandleUpdateIfNeeded(DecodeNumbers(lottery));
                            }
                            else if (lottery.Action == LotteryDecodeAction.DateTrigger)
                            {
                                lottery.LoadHtml(lottery.url);
                                HandleDateTrigger(DecodeDate(lottery, true), lottery);
                            }
                            iL++;
                            run++;

                            main.UpdateProgressBar1(run, States.AllStates.Sum(x => x.lotteries.Count));
                            main.UpdateStatusText("Cycles Render (" + run + " / " + States.AllStates.Sum(x => x.lotteries.Count) + ")");
                            //main.AddToConsole(num.lottery.lotteryNameUI + " finished.");
                        }
                        catch (NumbersUnavailableExcpetion)
                        {
                            main.AddToConsole("    ...Currently unavailabele/pending.");
                            continue;
                        }
                        catch (MissingFieldException)
                        {
                            main.AddToConsole("    ...Server returned an invalid response.");
                        }
                        catch (IOException)
                        {
                            main.AddToConsole("IO exception while running " + lottery.lotteryName);
                        }
                        catch (System.Net.WebException ex)
                        {
                            if (ex.InnerException != null)
                                if (ex.InnerException.Message.Contains("closed."))
                                {
                                    main.AddToConsole("    ...The host closed the connection.");
                                    continue;
                                }
                            main.AddToConsole("Web exception while running " + lottery.lotteryName);
                            continue;
                        }
                        catch (Exception ex)
                        {
                            main.AddToConsole("Unknown exception while running " + lottery.lotteryName);
                            if (Debug)
                            {
                                main.AddToConsole("    ..." + ex.Message);
                                if (ex.InnerException != null)
                                    main.AddToConsole("    ..." + ex.InnerException.Message);
                                main.AddToConsole("Stack trace: \n" + ex.StackTrace);
                            }
                            continue;
                        }

                    }
                    iS++;
                }

                ticker.Start();
                Cycling = false;

                if (main.InvokeRequired)
                {
                    main.BeginInvoke((MethodInvoker)delegate () { main.CyclesRenderFinished(); });
                    watch.Reset();
                    watch.Start();
                }
                else
                {
                    main.CyclesRenderFinished();
                    watch.Reset();
                    watch.Start();
                }
            }));

            try
            {
                ticker.Stop();
                t.Start();
                Cycling = true;
            }
            catch
            {
                main.AddToConsole("There was an error running cycles render.");
            }
        }

        public LotteryNumber DecodeNumbers(Lottery l)
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
                            main.AddToConsole("    ...The host closed the connection.");
                            main.AddToConsole("    ...Retrying (" + (tries + 1) + " of 3)");
                            Thread.Sleep(1000);
                            continue;
                        }
                    main.AddToConsole("Unknown exception while running " + l.lotteryName);
                    if (Debug)
                    {
                        main.AddToConsole("    ..." + ex.Message);
                        if (ex.InnerException != null)
                            main.AddToConsole("    ..." + ex.InnerException.Message);
                        main.AddToConsole("Stack trace: \n" + ex.StackTrace);
                    }
                    break;
                }
            }

            throw new NumbersUnavailableExcpetion();
        }

        public DateTime DecodeDate(Lottery l)
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
                            main.AddToConsole("    ...The host closed the connection.");
                            main.AddToConsole("    ...Retrying (" + (tries + 1) + " of 3)");
                            Thread.Sleep(1000);
                            continue;
                        }
                    main.AddToConsole("Unknown exception while running " + l.lotteryName);
                    if (Debug)
                    {
                        main.AddToConsole("    ..." + ex.Message);
                        if (ex.InnerException != null)
                            main.AddToConsole("    ..." + ex.InnerException.Message);
                        main.AddToConsole("Stack trace: \n" + ex.StackTrace);
                    }
                    break;
                }
            }

            throw new NumbersUnavailableExcpetion();
        }
        public DateTime DecodeDate(Lottery l, bool skipLaod)
        {
            for (int tries = 0; tries < 3; tries++)
            {
                try
                {
                    if(!skipLaod)
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
                            main.AddToConsole("    ...The host closed the connection.");
                            main.AddToConsole("    ...Retrying (" + (tries + 1) + " of 3)");
                            Thread.Sleep(1000);
                            continue;
                        }
                    main.AddToConsole("Unknown exception while running " + l.lotteryName);
                    if (Debug)
                    {
                        main.AddToConsole("    ..." + ex.Message);
                        if (ex.InnerException != null)
                            main.AddToConsole("    ..." + ex.InnerException.Message);
                        main.AddToConsole("Stack trace: \n" + ex.StackTrace);
                    }
                    break;
                }
            }

            throw new NumbersUnavailableExcpetion();
        }

        public void Tick(object source, ElapsedEventArgs e)
        {
            if (!Running)
            {
                ticker.Stop();
                return;
            }

            Cycle();
        }

        public void HandleUpdateIfNeeded(LotteryNumber num, int recursivecalls = 0)
        {
            try
            {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (File.Exists(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html"))
                {
                    //save the new html
                    string writeHTML = num.lottery.html;
                    num.lottery.html = File.ReadAllText(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html");
                    if(String.IsNullOrWhiteSpace(num.lottery.html))
                    {
                        main.AddToConsole("    ...Record blank. Deleting...");
                        File.Delete(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html");
                        Directory.CreateDirectory(path + "\\Autoclave\\Save\\");
                        main.NumbersList.Add(num);
                        File.WriteAllText(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html", writeHTML);
                        main.AddToConsole("    ...Record re-made. This will cause a slave update.");

                    }
                    IStateDecodable decode = num.lottery.state as IStateDecodable;
                    LotteryNumber numold = decode.GetLatestNumbers(num.lottery);

                    bool numsMatch = false;
                    for(int i = 0; i < num.numbers.Length; i++)
                    {
                        if (numold.numbers.Length != num.numbers.Length)
                        {
                            numsMatch = false;
                            break;
                        }
                        if(numold.numbers[i].Equals(num.numbers[i]))
                        {
                            numsMatch = true;
                            break;
                        }
                    }

                    if(!numsMatch || num.date != numold.date) //sense update
                    {
                        main.NumbersList.Add(num);
                        File.WriteAllText(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html", writeHTML);
                        main.AddToConsole("    ...Update found.");
                    }
                }
                else
                {
                    Directory.CreateDirectory(path + "\\Autoclave\\Save\\");
                    main.NumbersList.Add(num);
                    File.WriteAllText(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html", num.lottery.html);
                    main.AddToConsole("    ...No record.");
                }
            }
            catch (NumbersUnavailableExcpetion)
            {
                main.AddToConsole("    ...Currently unavailabele/pending.");
            }
            catch (Exception ex)
            {
                main.AddToConsole("Exception while running " + num.lottery.lotteryName);
                if (Debug)
                {
                    main.AddToConsole("    ..." + ex.Message);
                    if (ex.InnerException != null)
                        main.AddToConsole("    ..." + ex.InnerException.Message);
                    main.AddToConsole("Stack trace: \n" + ex.StackTrace);
                }
            }
        }
        public void HandleDateTrigger(DateTime date, Lottery lot)
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
                        main.AddToConsole("    ...Record blank. Deleting...");
                        File.Delete(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html");
                        Directory.CreateDirectory(path + "\\Autoclave\\Save\\");
                        main.NumbersList.Add(new LotteryNumber
                        {
                            date = date,
                            lottery = lot,
                            numbers = new string[] { "Date Trigger Only" },
                        });
                        File.WriteAllText(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html", writeHTML);
                        main.AddToConsole("    ...Record re-made. This will cause a slave update.");

                    }
                    IStateDecodable decode = lot.state as IStateDecodable;
                    DateTime dateold = decode.GetLatestDate(lot);

                    if (date != dateold) //sense update
                    {
                        main.NumbersList.Add(new LotteryNumber
                        {
                            date = date,
                            lottery = lot,
                            numbers = new string[] { "Date Trigger Only" },
                        });
                        File.WriteAllText(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html", writeHTML);
                        main.AddToConsole("    ...Update found.");
                    }
                }
                else
                {
                    Directory.CreateDirectory(path + "\\Autoclave\\Save\\");
                    main.NumbersList.Add(new LotteryNumber
                    {
                        date = date,
                        lottery = lot,
                        numbers = new string[] { "Date Trigger Only" },
                    });
                    File.WriteAllText(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html", lot.html);
                    main.AddToConsole("    ...No record.");
                }
            }
            catch (NumbersUnavailableExcpetion)
            {
                main.AddToConsole("    ...Currently unavailabele/pending.");
            }
            catch (Exception ex)
            {
                main.AddToConsole("Exception while running " + lot.lotteryName);
                if (Debug)
                {
                    main.AddToConsole("    ..." + ex.Message);
                    if (ex.InnerException != null)
                        main.AddToConsole("    ..." + ex.InnerException.Message);
                    main.AddToConsole("Stack trace: \n" + ex.StackTrace);
                }
            }
        }
    }

    public class NumbersUnavailableExcpetion : Exception
    {

    }
}
