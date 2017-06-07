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
        public AfterDecodeInformation ADI;
        public DateTime date;
        public string subdate;
        public Lottery lottery;
        public DebugDecodeInformation info;

        public string ToString(LotteryNumberStringTypes index)
        {
            if(index == LotteryNumberStringTypes.NumbersSpecialsMultipliers)
            {
                string a = "";

                if(ADI == AfterDecodeInformation.NotDrawnOrUnavailable)
                {
                    return "ADI is Not Drawn / Unavailable";
                }

                if (numbers == null)
                {
                    return "null";
                }

                foreach (string s in numbers)
                {
                    a += s + " ";
                }

                if (specials?.Length >= 0)
                {
                    a += " [";

                    foreach (string s2 in specials)
                    {
                        a += s2 + " ";
                    }

                    a = a.Trim();

                    if (String.IsNullOrWhiteSpace(multiplier))
                        a += "]";
                    else
                        a += "], ";
                }
                if (!String.IsNullOrWhiteSpace(multiplier))
                {
                    a += "<" + multiplier + ">";
                }


                a.Trim();

                if(ADI == AfterDecodeInformation.NeedsValidation)
                {
                    a += " (NV)";
                }
                else if (ADI == AfterDecodeInformation.Invalid)
                {
                    a += " (INVALID)";
                }
                else if (ADI == AfterDecodeInformation.Valid)
                {
                    a += " (OK)";
                }

                return a;
            }
            else if(index == LotteryNumberStringTypes.Numbers)
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

    public enum AfterDecodeInformation
    {
        NeedsValidation,
        Valid,
        Invalid,
        NotDrawnOrUnavailable
    }

    public enum LotteryNumberStringTypes
    {
        Numbers,
        NumbersDate,
        NumbersNameDate,
        NumbersName,
        Specials,
        Multipliers,
        NumbersSpecials,
        NumbersSpecialsMultipliers
    }

    public enum LotteryDecodeAction
    {
        Decode = 0,
        DateTrigger,
        PopAlways,
        Skip
    }

    public enum FullAutoAction
    {
        DoNothing,
        SubmitFull
    }

    public struct Lottery
    {
        public string html;
        public string url;
        public string lotteryName;
        public string lotteryNameUI;
        public UInt32 lottery_id;
        public byte UnitLength;
        public byte NumbersCount;
        public bool hasMultiplier;
        public byte SpecialUnitLength;
        public byte SpecialsCount;
        public List<DateTime> UpdateTimes;
        public IStateDecodable state;
        public LotteryDecodeAction Action;
        public FullAutoAction Submit;

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
