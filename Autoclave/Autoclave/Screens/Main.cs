using Autoclave.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoclave
{
    public partial class Main : Form
    {
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
            }
        }

        public void SlaveFinished()
        {
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

                                foreach (Lottery l in States.AllStates.SelectMany(x => x.lotteries))
                                {
                                    if (args.Length <= 1)
                                    {
                                        AddToConsole("Unable to find lottery \' \'");
                                        return;
                                    }

                                    if (l.lotteryName == args[1])
                                    {
                                        l.LoadHtml(l.url);
                                        IStateDecodable decode = l.state as IStateDecodable;
                                        DateTime date = decode.GetLatestDate(l);

                                        AddToConsole(date.ToLongDateString());

                                        return;
                                    }
                                }

                                AddToConsole("Unable to find lottery \'" + args[1] + "\'");

                                break;

                            case "numbers":

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
                                            l.LoadHtml(l.url);
                                            IStateDecodable decode = l.state as IStateDecodable;
                                            LotteryNumber num = decode.GetLatestNumbers(l);

                                            AddToConsole(num.ToString(LotteryNumberStringTypes.Numbers));
                                        }
                                        else if (l.Action == LotteryDecodeAction.DateTrigger)
                                        {
                                            AddToConsole("Date Trigger Only");
                                        }
                                        return;
                                    }
                                }

                                AddToConsole("Unable to find lottery \'" + args[1] + "\'");

                                break;

                            default:

                                AddToConsole("Invalid command \'" + args[0] + "\'");

                                break;
                        }
                    }
                    catch
                    {
                        AddToConsole("An error occurred when running " + command);
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
