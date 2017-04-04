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

namespace Autoclave
{
    public partial class SequentialSlave : Form
    {
        public Main main;
        public int indexThrough;
        public List<LotteryNumber> Sequence = new List<LotteryNumber>();
        public float timeSpent;

        public SequentialSlave()
        {
            InitializeComponent();
        }

        public void LoadLottery(int index)
        {
            main.SlaveRunning = true;
            richTextBox1.Text = Sequence[index].ToString(LotteryNumberStringTypes.Numbers);
            GameText.Text = Sequence[index].lottery.lotteryNameUI;
            TimeText.Text = Sequence[index].subdate;
            StateText.Text = Sequence[index].lottery.state.stateNameUI;
            DateText.Text = Sequence[index].date.ToShortDateString();
            SeqText.Text = (indexThrough + 1) + " / " + Sequence.Count;

            if(checkBox1.Checked)
            {
                Process.Start("chrome.exe", Sequence[index].lottery.url);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(indexThrough + 1 < Sequence.Count)
            {
                indexThrough++;
                LoadLottery(indexThrough);
                SeqText.Text = (indexThrough + 1) + " / " + Sequence.Count;
            }
            else
            {
                main.SlaveFinished();
                main.SlaveRunning = false;
                this.Close();
            }
        }
    }
}
