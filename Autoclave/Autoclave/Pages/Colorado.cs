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
    public class Colorado : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "colorado";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Colorado";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("Colorado.cs", lottery.html);
                }

                HtmlDocument Colorado = new HtmlDocument();
                Colorado.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("colorado_luckyforlife"))
                {
                    HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumbers')]")[2];
                    HtmlNode node2 = node.SelectNodes(".//a")[0];
                    string dateTextRaw = node2.InnerText;
                    dateTextRaw = Regex.Replace(dateTextRaw, @"\r\n?|\n", "").Trim();

                    string dateText = dateTextRaw.Split(new char[] { ' ' })[0].Trim();

                    DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("colorado_lotto"))
                {
                    HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumbers')]")[3];
                    HtmlNode node2 = node.SelectNodes(".//a")[0];
                    string dateTextRaw = node2.InnerText;
                    dateTextRaw = Regex.Replace(dateTextRaw, @"\r\n?|\n", "").Trim();

                    string dateText = dateTextRaw.Split(new char[] { ' ' })[0].Trim();

                    DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("colorado_cash5"))
                {
                    HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumbers')]")[4];
                    HtmlNode node2 = node.SelectNodes(".//a")[0];
                    string dateTextRaw = node2.InnerText;
                    dateTextRaw = Regex.Replace(dateTextRaw, @"\r\n?|\n", "").Trim();

                    string dateText = dateTextRaw.Split(new char[] { ' ' })[0].Trim();

                    DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("colorado_pick3day"))
                {
                    try
                    {
                        //try for a
                        HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumbers')]")[5];
                        HtmlNode node2 = node.SelectNodes(".//a")[0];
                        string dateTextRaw = node2.InnerText;
                        dateTextRaw = Regex.Replace(dateTextRaw, @"\r\n?|\n", "").Trim();

                        string dateText = dateTextRaw.Split(new char[] { ' ' })[0].Trim();

                        DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                        return dt;
                    }
                    catch
                    {
                        //try div
                        HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumbers')]")[5];
                        HtmlNode node2 = node.SelectNodes(".//div[contains(@class,'drawDate')]")[0];
                        string dateTextRaw = node2.InnerText;
                        dateTextRaw = Regex.Replace(dateTextRaw, @"\r\n?|\n", "").Trim();

                        string dateText = dateTextRaw.Split(new char[] { ' ' })[0].Trim();

                        DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                        return dt;
                    }
                }
                else if (lottery.lotteryName.Equals("colorado_pick3eve"))
                {
                    try
                    {
                        //try for a
                        HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumbers')]")[5];
                        HtmlNode node2 = node.SelectNodes(".//a")[2];
                        string dateTextRaw = node2.InnerText;
                        dateTextRaw = Regex.Replace(dateTextRaw, @"\r\n?|\n", "").Trim();

                        string dateText = dateTextRaw.Split(new char[] { ' ' })[0].Trim();

                        DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                        return dt;
                    }
                    catch
                    {
                        //try div
                        HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumbers')]")[5];
                        HtmlNode node2 = node.SelectNodes(".//div[contains(@class,'drawDate')]")[1];
                        string dateTextRaw = node2.InnerText;
                        dateTextRaw = Regex.Replace(dateTextRaw, @"\r\n?|\n", "").Trim();

                        string dateText = dateTextRaw.Split(new char[] { ' ' })[0].Trim();

                        DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                        return dt;
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
                    throw new MissingFieldException("Colorado.cs", lottery.html);
                }

                HtmlDocument Colorado = new HtmlDocument();
                Colorado.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("colorado_luckyforlife"))
                {
                    HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumber')]")[2];

                    HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'drawNumber')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes2[0].InnerText,
                            nodes2[1].InnerText,
                            nodes2[2].InnerText,
                            nodes2[3].InnerText,
                            nodes2[4].InnerText,
                            nodes2[5].InnerText.Replace("Lucky Ball", "")
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("colorado_lotto"))
                {
                    HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumber')]")[3];

                    HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'drawNumber')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes2[0].InnerText,
                            nodes2[1].InnerText,
                            nodes2[2].InnerText,
                            nodes2[3].InnerText,
                            nodes2[4].InnerText,
                            nodes2[5].InnerText
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("colorado_cash5"))
                {
                    HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumber')]")[4];

                    HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'drawNumber')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes2[0].InnerText,
                            nodes2[1].InnerText,
                            nodes2[2].InnerText,
                            nodes2[3].InnerText,
                            nodes2[4].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("colorado_pick3day"))
                {
                    HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumber')]")[5];

                    HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'drawNumber')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        numbers = new string[]
                        {
                            Regex.Replace(nodes2[0].InnerText.Replace("&ndash;", "-").Trim(), @"\r\n?|\n", "").Trim(),
                            Regex.Replace(nodes2[1].InnerText.Replace("&ndash;", "-").Trim(), @"\r\n?|\n", "").Trim(),
                            Regex.Replace(nodes2[2].InnerText.Replace("&ndash;", "-").Trim(), @"\r\n?|\n", "").Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("colorado_pick3eve"))
                {
                    HtmlNode node = Colorado.DocumentNode.SelectNodes("//div[contains(@class,'winningNumber')]")[5];

                    HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'drawNumber')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        numbers = new string[]
                        {
                            Regex.Replace(nodes2[3].InnerText.Replace("&ndash;", "-").Trim(), @"\r\n?|\n", "").Trim(),
                            Regex.Replace(nodes2[4].InnerText.Replace("&ndash;", "-").Trim(), @"\r\n?|\n", "").Trim(),
                            Regex.Replace(nodes2[5].InnerText.Replace("&ndash;", "-").Trim(), @"\r\n?|\n", "").Trim(),
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
