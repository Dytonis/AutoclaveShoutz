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
    public class Arkansas : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "Arkansas";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Arkansas";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("Arkansas.cs", lottery.html);
                }

                HtmlDocument Arkansas = new HtmlDocument();
                Arkansas.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("arkansas_nsj"))
                {
                    HtmlNode node1 = Arkansas.DocumentNode.SelectNodes("//div[contains(@class,'init')]")[2];
                    HtmlNode node2 = node1.SelectNodes(".//span[contains(@class,'drawdate')]")[0];
                    string dateText = node2.InnerHtml;

                    dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                    dateText = dateText.Trim();

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("arkansas_luckyforlife"))
                {
                    HtmlNode node1 = Arkansas.DocumentNode.SelectNodes("//div[contains(@class,'init')]")[3];
                    HtmlNode node2 = node1.SelectNodes(".//span[contains(@class,'drawdate')]")[0];
                    string dateText = node2.InnerHtml;

                    dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                    dateText = dateText.Trim();

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("arkansas_cash3day"))
                {
                    HtmlNode node1 = Arkansas.DocumentNode.SelectNodes("//div[contains(@class,'init')]")[5];
                    HtmlNode node2 = node1.SelectNodes(".//span[contains(@class,'cash_drawdate_top')]")[0];
                    string dateText = node2.InnerHtml;

                    dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                    dateText = dateText.Replace(" - Midday", " ");
                    dateText = dateText.Trim();

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("arkansas_cash3eve"))
                {
                    HtmlNode node1 = Arkansas.DocumentNode.SelectNodes("//div[contains(@class,'init')]")[5];
                    HtmlNode node2 = node1.SelectNodes(".//span[contains(@class,'cash_drawdate_bottom')]")[0];
                    string dateText = node2.InnerHtml;

                    dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                    dateText = dateText.Replace(" - Evening", " ");
                    dateText = dateText.Trim();

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("arkansas_cash4day"))
                {
                    HtmlNode node1 = Arkansas.DocumentNode.SelectNodes("//div[contains(@class,'init')]")[6];
                    HtmlNode node2 = node1.SelectNodes(".//span[contains(@class,'cash_drawdate_top')]")[0];
                    string dateText = node2.InnerHtml;

                    dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                    dateText = dateText.Replace(" - Midday", " ");
                    dateText = dateText.Trim();

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("arkansas_cash4eve"))
                {
                    HtmlNode node1 = Arkansas.DocumentNode.SelectNodes("//div[contains(@class,'init')]")[6];
                    HtmlNode node2 = node1.SelectNodes(".//span[contains(@class,'cash_drawdate_bottom')]")[0];
                    string dateText = node2.InnerHtml;

                    dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                    dateText = dateText.Replace(" - Evening", " ");
                    dateText = dateText.Trim();

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
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
                    throw new MissingFieldException("Arizona.cs", lottery.html);
                }

                HtmlDocument Arizona = new HtmlDocument();
                Arizona.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("arkansas_nsj"))
                {
                    HtmlNode[] nodes = Arizona.DocumentNode.SelectNodes("//span[contains(@id,'nsj_balls')]//span").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                        nodes[1].InnerText.Trim(),
                        nodes[3].InnerText.Trim(),
                        nodes[5].InnerText.Trim(),
                        nodes[7].InnerText.Trim(),
                        nodes[9].InnerText.Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("arkansas_luckyforlife"))
                {
                    HtmlNode node1 = Arizona.DocumentNode.SelectNodes("//span[contains(@class,'mm_balls sidenum homepage')]")[1];
                    HtmlNode[] nodes = node1.SelectNodes(".//span").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes[1].InnerText.Trim(),
                            nodes[3].InnerText.Trim(),
                            nodes[5].InnerText.Trim(),
                            nodes[7].InnerText.Trim(),
                            nodes[9].InnerText.Trim(),
                            nodes[11].InnerText.Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("arkansas_cash3day"))
                {
                    HtmlNode node1 = Arizona.DocumentNode.SelectNodes("//span[contains(@id,'pb_balls')]")[0];
                    HtmlNode[] nodes = node1.SelectNodes(".//span").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        numbers = new string[]
                        {
                            nodes[2].InnerText.Trim(),
                            nodes[4].InnerText.Trim(),
                            nodes[6].InnerText.Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("arkansas_cash3eve"))
                {
                    HtmlNode node1 = Arizona.DocumentNode.SelectNodes("//span[contains(@id,'pb_balls')]")[1];
                    HtmlNode[] nodes = node1.SelectNodes(".//span").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        numbers = new string[]
                        {
                            nodes[2].InnerText.Trim(),
                            nodes[4].InnerText.Trim(),
                            nodes[6].InnerText.Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("arkansas_cash4day"))
                {
                    HtmlNode node1 = Arizona.DocumentNode.SelectNodes("//span[contains(@id,'pb_balls')]")[2];
                    HtmlNode[] nodes = node1.SelectNodes(".//span").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        numbers = new string[]
                        {
                            nodes[2].InnerText.Trim(),
                            nodes[4].InnerText.Trim(),
                            nodes[6].InnerText.Trim(),
                            nodes[8].InnerText.Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("arkansas_cash4eve"))
                {
                    HtmlNode node1 = Arizona.DocumentNode.SelectNodes("//span[contains(@id,'pb_balls')]")[3];
                    HtmlNode[] nodes = node1.SelectNodes(".//span").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        numbers = new string[]
                        {
                            nodes[2].InnerText.Trim(),
                            nodes[4].InnerText.Trim(),
                            nodes[6].InnerText.Trim(),
                            nodes[8].InnerText.Trim(),
                        }
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
