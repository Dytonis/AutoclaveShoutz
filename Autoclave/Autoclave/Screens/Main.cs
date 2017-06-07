using Autoclave.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoclave
{
    public partial class Main : Form
    {
        public string version = "build8 - 5/30/2017 2:16pm";
        public bool SlaveRunning;
        public Autoclave autoclave;
        public List<LotteryNumber> NumbersList = new List<LotteryNumber>();

        public Main()
        {
            InitializeComponent();

            this.BackColor = Color.IndianRed;
            autoclave = new Autoclave();
            button1.Enabled = false;
            autoclave.main = this;

            ClearConsole();

            CommandLine.KeyDown += tb_KeyDown;
        }

        public void CyclesRenderFinished()
        {
            AddToConsole("Cycles Render finished.");

            progressBar1.MarqueeAnimationSpeed = 1;
            UpdateProgressBar1(0, 1);

            this.textBox1.Enabled = !autoclave.Running;

            if (autoclave.Running)
            {
                this.BackColor = Color.ForestGreen;
                button1.Text = "STOP AUTOCLAVE";
            }
            else
            {
                this.BackColor = Color.IndianRed;
                button1.Text = "START AUTOCLAVE";
            }

            if (ActionMode.Text == "Slave" && NumbersList.Count > 0)
            {
                BringToFront();

                SequentialSlave slave = new SequentialSlave();
                slave.Sequence = NumbersList;
                slave.main = this;
                slave.Show();
                slave.LoadLottery(0);
                slave.BringToFront();

                this.BackColor = Color.Gray;
                button1.Text = "RESUME FROM SLAVE";
                autoclave.Running = false;

                SystemSounds.Asterisk.Play();
            }
        }

        public void SlaveFinished()
        {
            if(!autoclave.Running)
                button1_Click(null, null);
        }

        public void ClearConsole()
        {
            richTextBox1.Clear();
        }

        public void AddToConsole(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke((MethodInvoker)delegate ()
                {
                    richTextBox1.Text += text + Environment.NewLine;
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                });
            }
            else
            {
                richTextBox1.Text += text + Environment.NewLine;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
        }

        public void UpdateStatusText(string text)
        {
            if (label1.InvokeRequired)
            {
                label1.BeginInvoke((MethodInvoker)delegate ()
                {
                    label1.Text = text;
                });
            }
            else
            {
                label1.Text = text;
            }
        }

        public void UpdateProgressBar1(int count, int total)
        {
            if (count > total)
                count = total;

            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke((MethodInvoker)delegate ()
                {
                    progressBar1.Value = (int)(((double)count / (double)total) * 1000);
                });
            }
            else
            {
                progressBar1.Value = (int)(((double)count / (double)total) * 1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            autoclave.Running = !autoclave.Running;
            this.textBox1.Enabled = !autoclave.Running;

            if (autoclave.Running)
            {
                this.BackColor = Color.ForestGreen;
                button1.Text = "STOP AUTOCLAVE";
            }
            else
            {
                progressBar1.MarqueeAnimationSpeed = 1;
                UpdateProgressBar1(0, 1);
                this.BackColor = Color.IndianRed;
                button1.Text = "START AUTOCLAVE";
            }
        }

        private void S_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(RenderMode.Text) && !String.IsNullOrWhiteSpace(ActionMode.Text) && !String.IsNullOrWhiteSpace(textBox1.Text))
            {
                button1.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(RenderMode.Text) && !String.IsNullOrWhiteSpace(ActionMode.Text) && !String.IsNullOrWhiteSpace(textBox1.Text))
            {
                button1.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                autoclave.seconds = Convert.ToDouble(textBox1.Text) * 60;
                AddToConsole("Autoclave cycles render updated.");
                if (!String.IsNullOrWhiteSpace(RenderMode.Text) && !String.IsNullOrWhiteSpace(ActionMode.Text) && !String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    button1.Enabled = true;
                }
            }
            catch
            {
                AddToConsole("Cannot convert " + textBox1.Text + " to a number.");
            }
        }

        public void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string command = CommandLine.Text;
                CommandLine.Text = "";
                AddToConsole("> " + command);

                string[] args = command.Split(new char[] { ' ' });

                Thread t = new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        switch (args[0])
                        {
                            case "date":

                                if (args.Length <= 1)
                                {
                                    AddToConsole("Unable to find lottery \' \'");
                                    return;
                                }

                                foreach (Lottery l in States.AllStates.SelectMany(x => x.lotteries))
                                {
                                    if (l.lotteryName == args[1])
                                    {
                                        DateTime date = autoclave.DecodeDate(l);

                                        AddToConsole(date.ToLongDateString());

                                        return;
                                    }
                                }

                                foreach (IStateDecodable s in States.AllStates)
                                {
                                    if(args[1] == s.stateName)
                                    {
                                        foreach(Lottery l in (s as State).lotteries)
                                        {
                                            try
                                            {
                                                DateTime date = autoclave.DecodeDate(l);

                                                AddToConsole(l.lotteryName + ": " + date.ToLongDateString());

                                                continue;
                                            }
                                            catch(Exception ex)
                                            {
                                                if(ex.InnerException != null)
                                                    if(ex.InnerException.Message.Contains("closed."))
                                                    {
                                                        AddToConsole("    ...The host closed the connection.");
                                                        continue;
                                                    }
                                                AddToConsole("An error occurred when running " + l.lotteryName);
                                            }
                                        }

                                        return;
                                    }
                                }

                                AddToConsole("Unable to find lottery \'" + args[1] + "\'");

                                break;

                            case "numbers":

                                if (args.Length <= 1)
                                {
                                    AddToConsole("Unable to find lottery \' \'");
                                    return;
                                }

                                foreach (Lottery l in States.AllStates.SelectMany(x => x.lotteries))
                                {
                                    if (args.Length <= 1)
                                    {
                                        AddToConsole("Unable to find lottery \' \'");
                                        return;
                                    }

                                    if (l.lotteryName == args[1])
                                    {
                                        if (l.Action == LotteryDecodeAction.Decode)
                                        {
                                            LotteryNumber num = autoclave.DecodeNumbers(l);

                                            AddToConsole(num.ToString(LotteryNumberStringTypes.NumbersSpecialsMultipliers));
                                        }
                                        else if (l.Action == LotteryDecodeAction.DateTrigger)
                                        {
                                            AddToConsole("Date Trigger Only");
                                        }
                                        return;
                                    }
                                }

                                foreach (IStateDecodable s in States.AllStates)
                                {
                                    if (args[1] == s.stateName)
                                    {
                                        foreach (Lottery l in (s as State).lotteries)
                                        {
                                            try
                                            {
                                                if (l.Action == LotteryDecodeAction.Decode)
                                                {
                                                    LotteryNumber num = autoclave.DecodeNumbers(l);

                                                    AddToConsole(l.lotteryName + ": " + num.ToString(LotteryNumberStringTypes.NumbersSpecialsMultipliers));
                                                }
                                                else if (l.Action == LotteryDecodeAction.DateTrigger)
                                                {
                                                    AddToConsole("Date Trigger Only");
                                                }

                                                continue;
                                            }
                                            catch (Exception ex)
                                            {
                                                if (ex.InnerException != null)
                                                    if (ex.InnerException.Message.Contains("closed."))
                                                    {
                                                        AddToConsole("    ...The host closed the connection.");
                                                        continue;
                                                    }
                                                AddToConsole("Exception while running " + l.lotteryName);
                                                continue;
                                            }
                                        }

                                        return;
                                    }
                                }

                                AddToConsole("Unable to find lottery \'" + args[1] + "\'");

                                break;

                            case "autoclave":

                                if (args.Length <= 1)
                                {
                                    AddToConsole(">>autoclave usage:");
                                    AddToConsole(">>autoclave cycle");
                                    AddToConsole(">>autoclave init");
                                    AddToConsole(">>autoclave debug");
                                    return;
                                }

                                if (args[1] == "cycle")
                                {
                                    if (autoclave != null)
                                    {
                                        if (autoclave.ticker != null)
                                        {
                                            autoclave.Cycle(true);
                                            return;
                                        }
                                        else
                                        {
                                            AddToConsole("Autoclave is not initialized. Please run autoclave init.");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        AddToConsole("Autoclave is not initialized. Please run autoclave init.");
                                        return;
                                    }
                                }
                                else if (args[1] == "init")
                                {
                                    autoclave.RunningUpdated();
                                    return;
                                }

                                if (args[1] == "debug")
                                {
                                    if(args.Length == 3)
                                    {
                                        if(args[2].ToLower() == "true")
                                        {
                                            autoclave.Debug = true;
                                            AddToConsole("Debug messages enabled.");
                                        }
                                        else if (args[2].ToLower() == "false")
                                        {
                                            autoclave.Debug = false;
                                            AddToConsole("Debug messages disabled.");
                                        }
                                        else
                                        {
                                            AddToConsole(">>debug usage:");
                                            AddToConsole(">>autoclave debug true/false"); AddToConsole(">>debug usage:");
                                            AddToConsole(">>autoclave debug true/false");
                                        }
                                    }
                                    else
                                    {
                                        AddToConsole(">>debug usage:");
                                        AddToConsole(">>autoclave debug true/false");
                                    }
                                }

                                break;

                            case "write":

                                if(args.Length >= 2)
                                {
                                    Thread writeThread = new Thread(new ThreadStart(() =>
                                    {
                                        using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
                                        {
                                            try
                                            {
                                                if(args.Length >= 3)
                                                {
                                                    if(command.Contains("-emulate"))
                                                    {                 
                                                        client.Headers.Add("Upgrade-Insecure-Requests", "1");
                                                        client.Headers.Add("Accept", "*/*");
                                                        client.Headers.Add("Accept-Encoding", "gzip, deflate, sdch, br");
                                                        client.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                                                    }
                                                }
                                                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36");
                                                AddToConsole("Downloading " + args[1]);
                                                string text = client.DownloadString(args[1]);
                                                File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\write.html", text);
                                                AddToConsole("Finished download.");
                                            }
                                            catch(WebException ex)
                                            {
                                                if (ex.Message.Contains("find"))
                                                { 
                                                    AddToConsole("Invalid URI.");
                                                    return;
                                                }

                                                AddToConsole("WebException " + ex.Status.ToString());
                                                return;
                                            }
                                        }
                                    }));

                                    writeThread.Start();
                                }

                                break;

                            case "version":

                                AddToConsole(version);

                                break;

                            default:

                                AddToConsole("Invalid command \'" + args[0] + "\'");

                                break;
                        }
                    }
                    catch
                    {
                        AddToConsole("A fatal error occurred when running " + command);
                    }
                }));

                t.Start();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearConsole();
        }
    }
}
