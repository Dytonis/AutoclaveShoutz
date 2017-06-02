using Autoclave.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autoclave
{
    public struct LotteryNumber
    {
        public string[] numbers;
        public string[] specials;
        public string multiplier;
        public DateTime date;
        public string subdate;
        public Lottery lottery;
        public DebugDecodeInformation info;

        public string ToString(LotteryNumberStringTypes index)
        {
            if(index == LotteryNumberStringTypes.Numbers)
            {
                string a = "";

                if(numbers == null)
                {
                    return "null";
                }

                foreach(string s in numbers)
                {
                    a += s + " ";
                }

                a.Trim();

                return a;
            }
            if (index == LotteryNumberStringTypes.NumbersName)
            {
                string a = lottery.lotteryNameUI + ": ";

                foreach (string s in numbers)
                {
                    a += s + " ";
                }

                a.Trim();

                return a;
            }
            if (index == LotteryNumberStringTypes.NumbersNameDate)
            {
                string a = lottery.lotteryNameUI + ", " + date.ToShortDateString() + ": ";

                foreach (string s in numbers)
                {
                    a += s + " ";
                }

                a.Trim();

                return a;
            }

            return "";
        }
    }

    public struct DebugDecodeInformation
    {
        public string rawNumbersText;
    }

    public enum LotteryNumberStringTypes
    {
        Numbers,
        NumbersDate,
        NumbersNameDate,
        NumbersName,
    }

    public enum LotteryDecodeAction
    {
        Decode = 0,
        DateTrigger,
        PopAlways,
        Skip
    }

    public struct Lottery
    {
        public string html;
        public string url;
        public string lotteryName;
        public string lotteryNameUI;
        public UInt32 lottery_id;
        public List<DateTime> UpdateTimes;
        public IStateDecodable state;
        public LotteryDecodeAction Action;

        public void LoadHtml(string url)
        {
            string cache;
            if(States.CachedURLS.TryGetValue(url, out cache))
            {
                if(!String.IsNullOrWhiteSpace(cache))
                {
                    html = cache;
                    return;
                }
            }
            
            using (WebClient client = new WebClient())
            {
                if(state.GetType() == typeof(Georgia))
                {
                    client.Headers.Add("Upgrade-Insecure-Requests", "1");
                    client.Headers.Add("Accept", "*/*");
                    client.Headers.Add("Accept-Encoding", "gzip, deflate, sdch, br");
                    client.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                }

                client.Headers.Add("User-Agent", "Autoclave by Shoutz, Inc. LotteryHUB.com Lottery Data Miner");
                string htmlCode = client.DownloadString(url);
                this.html = htmlCode;

                if(!String.IsNullOrWhiteSpace(html))
                    States.CachedURLS.Add(url, html);
            }
        }
    }
}
