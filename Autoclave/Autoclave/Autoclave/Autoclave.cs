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
        public Main main;

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

        System.Timers.Timer ticker;
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
                main.AddToConsole("Autoclave starting...");
                ticker.Start();
            }
            else
            {
                main.AddToConsole("Autoclave stopping...");
                ticker.Stop();
            }
            main.AddToConsole("Autoclave ready.");
        }

        public void Tick(object source, ElapsedEventArgs e)
        {
            if (!Running)
            {
                ticker.Stop();
                return;
            }

            main.AddToConsole("Cycles Render starting...");

            main.NumbersList.Clear();

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
                        if (!Running)
                            return;

                        main.UpdateProgressBar2(iL, state.lotteries.Count);
                        main.UpdateProgressBar1(iS, States.AllStates.Count);
                        main.UpdateStatusText("Cycles Render (" + run + " / " + States.AllStates.Sum(x => x.lotteries.Count) + ")");
                        main.AddToConsole("Rendering " + lottery.url + "...");


                        if (lottery.Action == LotteryDecodeAction.Decode)
                        {
                            lottery.LoadHtml(lottery.url);
                            IStateDecodable decode = state as IStateDecodable;
                            LotteryNumber num = decode.GetLatestNumbers(lottery);
                            HandleUpdateIfNeeded(num);
                        }
                        else if (lottery.Action == LotteryDecodeAction.DateTrigger)
                        {
                            lottery.LoadHtml(lottery.url);
                            IStateDecodable decode = state as IStateDecodable;
                            DateTime date = decode.GetLatestDate(lottery);
                            HandleDateTrigger(date, lottery);
                        }
                            iL++;
                            run++;

                            main.UpdateProgressBar2(iL, state.lotteries.Count);
                            main.UpdateProgressBar1(iS, States.AllStates.Count);
                            main.UpdateStatusText("Cycles Render (" + run + " / " + States.AllStates.Sum(x => x.lotteries.Count) + ")");
                            //main.AddToConsole(num.lottery.lotteryNameUI + " finished.");
                        
                    }
                    iS++;
                }

                ticker.Start();

                if (main.InvokeRequired)
                {
                    main.BeginInvoke((MethodInvoker)delegate () { main.CyclesRenderFinished(); });
                }
                else
                {
                    main.CyclesRenderFinished();
                }
            }));

            try
            {
                ticker.Stop();
                t.Start();
            }
            catch
            {
                main.AddToConsole("There was an error running cycles render.");
            }
        }

        public void HandleUpdateIfNeeded(LotteryNumber num)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html"))
            {
                num.lottery.html = File.ReadAllText(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html");
                IStateDecodable decode = num.lottery.state as IStateDecodable;
                LotteryNumber numold = decode.GetLatestNumbers(num.lottery);

                if(!numold.numbers.Equals(num.numbers))
                {
                    //no update
                }
                else
                {
                    main.NumbersList.Add(num);
                    File.WriteAllText(path + "\\Autoclave\\Save\\" + num.lottery.lotteryName + ".html", num.lottery.html);
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
        public void HandleDateTrigger(DateTime date, Lottery lot)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html"))
            {
                lot.html = File.ReadAllText(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html");
                IStateDecodable decode = lot.state as IStateDecodable;
                DateTime dateold = decode.GetLatestDate(lot);

                if (date.Equals(dateold))
                {
                    //no update
                }
                else
                {
                    main.NumbersList.Add(new LotteryNumber
                    {
                        date = date,
                        lottery = lot,
                        numbers = new string[] { "Date Trigger Only" },
                    });
                    File.WriteAllText(path + "\\Autoclave\\Save\\" + lot.lotteryName + ".html", lot.html);
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
    }
}
