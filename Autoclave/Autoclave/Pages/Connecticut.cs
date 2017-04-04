using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Autoclave.Pages
{
    class Connecticut : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "connecticut";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Connecticut";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("Connecticut.cs", lottery.html);
                }

                HtmlDocument Connecticut = new HtmlDocument();
                Connecticut.LoadHtml(lottery.html);

                int index = -1;



                if (lottery.lotteryName.Equals("connecticut_luckylinksday"))
                {
                    index = 0;
                }
                else if (lottery.lotteryName.Equals("connecticut_luckylinkseve"))
                {
                    index = 1;
                }
                else if (lottery.lotteryName.Equals("connecticut_lotto"))
                {
                    index = 4;
                }
                else if (lottery.lotteryName.Equals("connecticut_cash5"))
                {
                    index = 6;
                }
                else if (lottery.lotteryName.Equals("connecticut_play3day"))
                {
                    index = 7;
                }
                else if (lottery.lotteryName.Equals("connecticut_play3eve"))
                {
                    index = 8;
                }
                else if (lottery.lotteryName.Equals("connecticut_play4day"))
                {
                    index = 9;
                }
                else if (lottery.lotteryName.Equals("connecticut_play4eve"))
                {
                    index = 10;
                }

                HtmlNode node = Connecticut.DocumentNode.SelectNodes("//div[contains(@class,'date')]")[index];
                string dateText = node.InnerText;

                DateTime dt = DateTime.ParseExact(dateText, "MMMM d, yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            catch
            {
                throw;
            }

            throw new Exception();
        }

        public LotteryNumber GetLatestNumbers(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("Connecticut.cs", lottery.html);
                }

                HtmlDocument Connecticut = new HtmlDocument();
                Connecticut.LoadHtml(lottery.html);

                int index = -1;

                if (lottery.lotteryName.Equals("connecticut_luckylinksday"))
                {
                    index = 1;
                }
                else if (lottery.lotteryName.Equals("connecticut_luckylinkseve"))
                {
                    index = 2;
                }
                else if (lottery.lotteryName.Equals("connecticut_lotto"))
                {
                    index = 5;
                }
                else if (lottery.lotteryName.Equals("connecticut_cash5"))
                {
                    index = 7;
                }
                else if (lottery.lotteryName.Equals("connecticut_play3day"))
                {
                    index = 9;
                }
                else if (lottery.lotteryName.Equals("connecticut_play3eve"))
                {
                    index = 10;
                }
                else if (lottery.lotteryName.Equals("connecticut_play4day"))
                {
                    index = 12;
                }
                else if (lottery.lotteryName.Equals("connecticut_play4eve"))
                {
                    index = 13;
                }

                HtmlNode node = Connecticut.DocumentNode.SelectNodes("//div[contains(@class,'nbrs')]")[index];
                HtmlNode plain = node.SelectSingleNode("text()[normalize-space()]");

                string[] nums = plain.InnerText.Split('-');
                nums.Select(x => x.Trim());

                if (lottery.lotteryName.Equals("connecticut_play3day")
                    || lottery.lotteryName.Equals("connecticut_play4day")
                    || lottery.lotteryName.Equals("connecticut_luckylinksday"))
                    {
                        return new LotteryNumber()
                        {
                            date = GetLatestDate(lottery),
                            lottery = lottery,
                            subdate = "Day",
                            numbers = nums
                        };
                }
                else if (lottery.lotteryName.Equals("connecticut_play3eve")
                    || lottery.lotteryName.Equals("connecticut_play4eve")
                    || lottery.lotteryName.Equals("connecticut_luckylinkseve"))
                    {
                        return new LotteryNumber()
                        {
                            date = GetLatestDate(lottery),
                            lottery = lottery,
                            subdate = "Eve",
                            numbers = nums
                        };
                }
                else
                {
                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = nums
                    };
                }
            }
            catch
            {
                throw;
            }

            throw new Exception();
        }
    }
}
