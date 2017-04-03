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
    class California : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "california";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "California";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("California.cs", lottery.html);
                }

                HtmlDocument California = new HtmlDocument();
                California.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("california_superlotto") || lottery.lotteryName.Equals("california_fantasy5") || lottery.lotteryName.Equals("california_daily4"))
                {
                    HtmlNode node1 = California.DocumentNode.SelectNodes("//section[contains(@id,'main-content')]")[0];
                    HtmlNode node2 = node1.SelectNodes(".//h3[contains(@class,'date')]")[0];
                    string dateTextRaw = node2.InnerHtml;

                    string dateText = dateTextRaw.Split('|')[0];
                    dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                    dateText = dateText.Trim();

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("california_daily3day") || lottery.lotteryName.Equals("california_daily3eve"))
                {
                    HtmlNode node11 = California.DocumentNode.SelectNodes("//section[contains(@id,'main-content')]")[0];
                    HtmlNode node21 = node11.SelectNodes(".//h3[contains(@class,'date')]")[0];
                    string dateTextRaw1 = node21.InnerHtml;

                    if(dateTextRaw1.ToUpper().Contains("MIDDAY"))
                    {
                        //midday
                        if(lottery.lotteryName.Equals("california_daily3day"))
                        {
                            //correct
                            string dateText = dateTextRaw1.Split('|')[0];
                            dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                            dateText = dateText.Replace("&nbsp;", " ");
                            dateText = dateText.Trim();

                            DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                            return dt;
                        }
                    }
                    if (dateTextRaw1.ToUpper().Contains("EVENING"))
                    {
                        //evening
                        if (lottery.lotteryName.Equals("california_daily3eve"))
                        {
                            //correct
                            string dateText = dateTextRaw1.Split('|')[0];
                            dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                            dateText = dateText.Replace("&nbsp;", " ");
                            dateText = dateText.Trim();

                            DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                            return dt;
                        }
                    }

                    HtmlNode node12 = California.DocumentNode.SelectNodes("//section[contains(@id,'main-content')]")[0];
                    HtmlNode node22 = node12.SelectNodes(".//h3[contains(@class,'date')]")[1];
                    string dateTextRaw2 = node22.InnerHtml;

                    if (dateTextRaw2.ToUpper().Contains("MIDDAY"))
                    {
                        //midday
                        if (lottery.lotteryName.Equals("california_daily3day"))
                        {
                            //correct
                            string dateText = dateTextRaw2.Split('|')[0];
                            dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                            dateText = dateText.Replace("&nbsp;", " ");
                            dateText = dateText.Trim();

                            DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d", CultureInfo.InvariantCulture);
                            return dt;
                        }
                    }
                    if (dateTextRaw2.ToUpper().Contains("EVENING"))
                    {
                        //evening
                        if (lottery.lotteryName.Equals("california_daily3eve"))
                        {
                            //correct
                            string dateText = dateTextRaw2.Split('|')[0];
                            dateText = Regex.Replace(dateText, @"\r\n?|\n", "");
                            dateText = dateText.Replace("&nbsp;", " ");
                            dateText = dateText.Trim();

                            DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d", CultureInfo.InvariantCulture);
                            return dt;
                        }
                    }
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
                    throw new MissingFieldException("California.cs", lottery.html);
                }

                HtmlDocument California = new HtmlDocument();
                California.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("california_superlotto"))
                {
                    HtmlNode[] nodes = California.DocumentNode.SelectNodes("//ul[contains(@class,'winning_number_sm')]//span").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes[0].InnerText.Trim(),
                            nodes[1].InnerText.Trim(),
                            nodes[2].InnerText.Trim(),
                            nodes[3].InnerText.Trim(),
                            nodes[4].InnerText.Trim(),
                            nodes[5].InnerText.Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("california_fantasy5"))
                {
                    HtmlNode[] nodes = California.DocumentNode.SelectNodes("//ul[contains(@class,'winning_number_sm')]//span").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes[0].InnerText.Trim(),
                            nodes[1].InnerText.Trim(),
                            nodes[2].InnerText.Trim(),
                            nodes[3].InnerText.Trim(),
                            nodes[4].InnerText.Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("california_daily4"))
                {
                    HtmlNode[] nodes = California.DocumentNode.SelectNodes("//ul[contains(@class,'winning_number_sm')]//span").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes[0].InnerText.Trim(),
                            nodes[1].InnerText.Trim(),
                            nodes[2].InnerText.Trim(),
                            nodes[3].InnerText.Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("california_daily3day") || lottery.lotteryName.Equals("california_daily3eve"))
                {
                    HtmlNode node11 = California.DocumentNode.SelectNodes("//section[contains(@id,'main-content')]")[0];
                    HtmlNode node21 = node11.SelectNodes(".//h3[contains(@class,'date')]")[0];
                    string dateTextRaw1 = node21.InnerHtml;

                    if (dateTextRaw1.ToUpper().Contains("MIDDAY"))
                    {
                        //midday
                        if (lottery.lotteryName.Equals("california_daily3day"))
                        {
                            HtmlNode[] nodes = California.DocumentNode.SelectNodes("//ul[contains(@class,'winning_number_sm')]//span").ToArray();

                            return new LotteryNumber()
                            {
                                date = GetLatestDate(lottery),
                                lottery = lottery,
                                subdate = "Day",
                                numbers = new string[]
                                {
                                    nodes[0].InnerText.Trim(),
                                    nodes[1].InnerText.Trim(),
                                    nodes[2].InnerText.Trim(),
                                }
                            };
                        }
                    }
                    if (dateTextRaw1.ToUpper().Contains("EVENING"))
                    {
                        //evening
                        if (lottery.lotteryName.Equals("california_daily3eve"))
                        {
                            HtmlNode[] nodes = California.DocumentNode.SelectNodes("//ul[contains(@class,'winning_number_sm')]//span").ToArray();

                            return new LotteryNumber()
                            {
                                date = GetLatestDate(lottery),
                                lottery = lottery,
                                subdate = "Eve",
                                numbers = new string[]
                                {
                                    nodes[0].InnerText.Trim(),
                                    nodes[1].InnerText.Trim(),
                                    nodes[2].InnerText.Trim(),
                                }
                            };
                        }
                    }

                    HtmlNode node12 = California.DocumentNode.SelectNodes("//section[contains(@id,'main-content')]")[0];
                    HtmlNode node22 = node12.SelectNodes(".//h3[contains(@class,'date')]")[1];
                    string dateTextRaw2 = node22.InnerHtml;

                    if (dateTextRaw2.ToUpper().Contains("MIDDAY"))
                    {
                        //midday
                        if (lottery.lotteryName.Equals("california_daily3day"))
                        {
                            HtmlNode node1 = California.DocumentNode.SelectNodes("//ul[contains(@class,'winning_number_sm')]")[1];
                            HtmlNode[] nodes = node1.SelectNodes(".//span").ToArray();

                            return new LotteryNumber()
                            {
                                date = GetLatestDate(lottery),
                                lottery = lottery,
                                subdate = "Day",
                                numbers = new string[]
                                {
                                    nodes[0].InnerText.Trim(),
                                    nodes[1].InnerText.Trim(),
                                    nodes[2].InnerText.Trim(),
                                }
                            };
                        }
                    }
                    if (dateTextRaw2.ToUpper().Contains("EVENING"))
                    {
                        //evening
                        if (lottery.lotteryName.Equals("california_daily3eve"))
                        {
                            HtmlNode node1 = California.DocumentNode.SelectNodes("//ul[contains(@class,'winning_number_sm')]")[1];
                            HtmlNode[] nodes = node1.SelectNodes(".//span").ToArray();

                            return new LotteryNumber()
                            {
                                date = GetLatestDate(lottery),
                                lottery = lottery,
                                subdate = "Eve",
                                numbers = new string[]
                                {
                                    nodes[0].InnerText.Trim(),
                                    nodes[1].InnerText.Trim(),
                                    nodes[2].InnerText.Trim(),
                                }
                            };
                        }
                    }
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
