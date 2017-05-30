using Autoclave;
using Autoclave_Nogui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoclave_Nogui
{
    public partial class SequentialSlave : Form
    {
        public int indexThrough;
        public List<LotteryNumber> Sequence = new List<LotteryNumber>();
        public float timeSpent;

        public SequentialSlave()
        {
            InitializeComponent();
        }

        public void init()
        {
            LoadLottery(0);
            BringToFront();
        }

        public void LoadLottery(int index)
        {
            if (Sequence.Count > 0)
            {
                richTextBox1.Text = Sequence[index].ToString(LotteryNumberStringTypes.Numbers);
                GameText.Text = Sequence[index].lottery.lotteryNameUI;
                TimeText.Text = Sequence[index].subdate;
                StateText.Text = Sequence[index].lottery.state.stateNameUI;
                DateText.Text = Sequence[index].date.ToShortDateString();
                SeqText.Text = (indexThrough + 1) + " / " + Sequence.Count;
            }

            if(checkBox1.Checked)
            {
                Process.Start("chrome.exe", Sequence[index].lottery.url);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (indexThrough + 1 < Sequence.Count)
            {
                indexThrough++;
                LoadLottery(indexThrough);
                SeqText.Text = (indexThrough + 1) + " / " + Sequence.Count;
            }
            else
            {
                Program.SlaveFinished();
                this.Close();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(Sequence[indexThrough].info.rawNumbersText))
                richTextBox1.Text = Sequence[indexThrough].info.rawNumbersText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (indexThrough - 1 >= 0)
            {
                indexThrough--;
                LoadLottery(indexThrough);
                SeqText.Text = (indexThrough) + " / " + Sequence.Count;
            }
        }

        private void SequentialSlave_Load(object sender, EventArgs e)
        {
            init();
        }
    }
}
