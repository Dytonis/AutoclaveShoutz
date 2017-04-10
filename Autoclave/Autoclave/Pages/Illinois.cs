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
    public class Illinois : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "illinois";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Illinois";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("Illinois.cs", lottery.html);
                }

                HtmlDocument Illinois = new HtmlDocument();
                Illinois.LoadHtml(lottery.html);

                int index = -1;

                if (lottery.lotteryName.Equals("illinois_lotto"))
                {
                    index = 2;
                }
                else if (lottery.lotteryName.Equals("illinois_luckydaylottoday"))
                {
                    index = 3;
                }
                else if (lottery.lotteryName.Equals("illinois_luckydaylottoeve"))
                {
                    index = 5;
                }
                else if (lottery.lotteryName.Equals("illinois_pick3day"))
                {
                    index = 7;
                }
                else if (lottery.lotteryName.Equals("illinois_pick3eve"))
                {
                    index = 9;
                }
                else if (lottery.lotteryName.Equals("illinois_pick4day"))
                {
                    index = 11;
                }
                else if (lottery.lotteryName.Equals("illinois_pick4eve"))
                {
                    index = 13;
                }

                //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                HtmlNode node = Illinois.DocumentNode.SelectNodes("//p[contains(@class,'draw-time')]")[index];
                string dateText = node.InnerText;
                dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                dateText = dateText.Replace("Midday:", "").Replace("Evening:", "").Trim();

                DateTime dt = DateTime.ParseExact(dateText, "ddd, MMM dd", CultureInfo.InvariantCulture);
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
                    throw new MissingFieldException("Illinois.cs", lottery.html);
                }

                HtmlDocument Illinois = new HtmlDocument();
                Illinois.LoadHtml(lottery.html);

                int index = -1;
                string sub = "";
                int nums = 5;

                if (lottery.lotteryName.Equals("illinois_lotto"))
                {
                    index = 2;
                }
                else if (lottery.lotteryName.Equals("illinois_luckydaylottoday"))
                {
                    index = 3;
                    sub = "Day";
                }
                else if (lottery.lotteryName.Equals("illinois_luckydaylottoeve"))
                {
                    index = 4;
                    sub = "Eve";
                }
                else if (lottery.lotteryName.Equals("illinois_pick3day"))
                {
                    index = 5;
                    nums = 3;
                    sub = "Day";
                }
                else if (lottery.lotteryName.Equals("illinois_pick3eve"))
                {
                    index = 8;
                    nums = 3;
                    sub = "Eve";
                }
                else if (lottery.lotteryName.Equals("illinois_pick4day"))
                {
                    index = 11;
                    nums = 4;
                    sub = "Day";
                }
                else if (lottery.lotteryName.Equals("illinois_pick4eve"))
                {
                    index = 14;
                    nums = 4;
                    sub = "Eve";
                }


                HtmlNode node = Illinois.DocumentNode.SelectNodes("//ul[contains(@class,'numbers')]")[index];
                HtmlNode[] nodes = node.SelectNodes(".//li").ToArray();

                LotteryNumber num = new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    subdate = sub
                };

                if(nums == 5)
                {
                    num.numbers = new string[]
                    {
                            nodes[0].InnerText,
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                            nodes[4].InnerText,
                    };
                }
                else if(nums == 4)
                {
                    num.numbers = new string[]
                    {
                            nodes[0].InnerText,
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                    };
                }
                else if (nums == 3)
                {
                    num.numbers = new string[]
                    {
                            nodes[0].InnerText,
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                    };
                }

                return num;
            }
            catch
            {
                throw;
            }

            throw new Exception();
        }
    }
}
