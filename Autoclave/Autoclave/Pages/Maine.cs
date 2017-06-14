using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.Globalization;

namespace Autoclave.Pages
{
    public class Maine : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "maine";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Maine";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {

            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Maine.cs", "html");
            }

            HtmlDocument Maine = new HtmlDocument();
            Maine.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("maine_megabucks"))
            {
                HtmlNode[] nodes = Maine.DocumentNode.SelectNodes("//div[contains(@class,'homewinners')]//h2").ToArray();
                string dateText = nodes[1].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "dddd MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("maine_luckyforlife"))
            {
                HtmlNode[] nodes = Maine.DocumentNode.SelectNodes("//div[contains(@class,'homewinners')]//h2").ToArray();
                string dateText = nodes[4].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "dddd MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("maine_hotlottosizzler"))
            {
                HtmlNode[] nodes = Maine.DocumentNode.SelectNodes("//div[contains(@class,'homewinners')]//h2").ToArray();
                string dateText = nodes[3].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "dddd MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("maine_gimme5"))
            {
                HtmlNode[] nodes = Maine.DocumentNode.SelectNodes("//div[contains(@class,'homewinners')]//h2").ToArray();
                string dateText = nodes[5].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "dddd MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("maine_pick3day") || lottery.lotteryName.Equals("maine_pick3eve"))
            {
                HtmlNode[] nodes = Maine.DocumentNode.SelectNodes("//div[contains(@class,'pickhomewinners')]//h2").ToArray();
                string dateText = nodes[0].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "dddd MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("maine_pick4day") || lottery.lotteryName.Equals("maine_pick4eve"))
            {
                HtmlNode[] nodes = Maine.DocumentNode.SelectNodes("//div[contains(@class,'pickhomewinners')]//h2").ToArray();
                string dateText = nodes[1].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "dddd MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("maine_wptallin") || lottery.lotteryName.Equals("maine_pick4eve"))
            {
                HtmlNode[] nodes = Maine.DocumentNode.SelectNodes("//div[contains(@class,'homewinners')]//h2").ToArray();
                string dateText = nodes[8].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "dddd MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else
            {
                throw new MissingFieldException("Maine.cs", "lottery");
            }
        }

        public LotteryNumber GetLatestNumbers(Lottery lottery)
        {
            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Maine.cs", "html");
            }

            HtmlDocument Maine = new HtmlDocument();
            Maine.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("maine_megabucks"))
            {
                HtmlNode node = Maine.DocumentNode.SelectNodes("//div[contains(@class,'homewinners')]")[1];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'ball')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        nodes2[0].InnerText.Trim(),
                        nodes2[1].InnerText.Trim(),
                        nodes2[2].InnerText.Trim(),
                        nodes2[3].InnerText.Trim(),
                        nodes2[4].InnerText.Trim(),
                        nodes2[5].InnerText.Trim()
                    }
                };
            }
            else if (lottery.lotteryName.Equals("maine_luckyforlife"))
            {
                HtmlNode node = Maine.DocumentNode.SelectNodes("//div[contains(@class,'homewinners')]")[4];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'ball')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        nodes2[0].InnerText.Trim(),
                        nodes2[1].InnerText.Trim(),
                        nodes2[2].InnerText.Trim(),
                        nodes2[3].InnerText.Trim(),
                        nodes2[4].InnerText.Trim(),
                        nodes2[5].InnerText.Trim()
                    }
                };
            }
            else if (lottery.lotteryName.Equals("maine_gimme5"))
            {
                HtmlNode node = Maine.DocumentNode.SelectNodes("//div[contains(@class,'homewinners')]")[5];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'ball')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        nodes2[0].InnerText.Trim(),
                        nodes2[1].InnerText.Trim(),
                        nodes2[2].InnerText.Trim(),
                        nodes2[3].InnerText.Trim(),
                        nodes2[4].InnerText.Trim(),
                    }
                };
            }
            else if (lottery.lotteryName.Equals("maine_hotlottosizzler"))
            {
                HtmlNode node = Maine.DocumentNode.SelectNodes("//div[contains(@class,'homewinners')]")[3];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'ball')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        nodes2[0].InnerText.Trim(),
                        nodes2[1].InnerText.Trim(),
                        nodes2[2].InnerText.Trim(),
                        nodes2[3].InnerText.Trim(),
                        nodes2[4].InnerText.Trim(),
                        nodes2[5].InnerText.Trim(),
                    }
                };
            }
            else if (lottery.lotteryName.Equals("maine_pick3day"))
            {
                HtmlNode node = Maine.DocumentNode.SelectNodes("//div[contains(@class,'pickhomewinners')]")[0];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'ball')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    subdate = "Day",
                    lottery = lottery,
                    numbers = new string[]
                    {
                        nodes2[0].InnerText.Trim(),
                        nodes2[1].InnerText.Trim(),
                        nodes2[2].InnerText.Trim(),
                    }
                };
            }
            else if (lottery.lotteryName.Equals("maine_pick3eve"))
            {
                HtmlNode node = Maine.DocumentNode.SelectNodes("//div[contains(@class,'pickhomewinners')]")[0];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'ball')]").ToArray();

                if (nodes2.Length >= 4)
                {
                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        subdate = "Eve",
                        lottery = lottery,
                        numbers = new string[]
                        {
                        nodes2[3].InnerText.Trim(),
                        nodes2[4].InnerText.Trim(),
                        nodes2[5].InnerText.Trim()
                        }
                    };
                }
                else
                {
                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        subdate = "Eve",
                        lottery = lottery,
                        numbers = new string[]
                        {
                            
                        },
                        ADI = AfterDecodeInformation.NotDrawnOrUnavailable
                    };
                }
            }
            else if (lottery.lotteryName.Equals("maine_pick4day"))
            {
                HtmlNode node = Maine.DocumentNode.SelectNodes("//div[contains(@class,'pickhomewinners')]")[1];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'ball')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    subdate = "Day",
                    numbers = new string[]
                    {
                        nodes2[0].InnerText.Trim(),
                        nodes2[1].InnerText.Trim(),
                        nodes2[2].InnerText.Trim(),
                        nodes2[3].InnerText.Trim(),
                    }
                };
            }
            else if (lottery.lotteryName.Equals("maine_pick4eve"))
            {
                HtmlNode node = Maine.DocumentNode.SelectNodes("//div[contains(@class,'pickhomewinners')]")[1];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'ball')]").ToArray();

                if (nodes2.Length >= 5)
                {

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        subdate = "Eve",
                        lottery = lottery,
                        numbers = new string[]
                        {
                        nodes2[4].InnerText.Trim(),
                        nodes2[5].InnerText.Trim(),
                        nodes2[6].InnerText.Trim(),
                        nodes2[7].InnerText.Trim(),
                        }
                    };
                }
                else
                {
                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        subdate = "Eve",
                        lottery = lottery,
                        numbers = new string[]
                        {
                           
                        },
                        ADI = AfterDecodeInformation.NotDrawnOrUnavailable
                    };
                }
            }
            else
            {
                throw new MissingFieldException("Maine.cs", "lottery");
            }
        }
    }
}
