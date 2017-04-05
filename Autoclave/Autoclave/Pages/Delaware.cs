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
    class Delaware : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "deleware";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Deleware";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("Deleware.cs", lottery.html);
                }

                HtmlDocument Connecticut = new HtmlDocument();
                Connecticut.LoadHtml(lottery.html);


                if (lottery.lotteryName.Equals("deleware_play3day"))
                {
                    HtmlNode node = Connecticut.DocumentNode.SelectNodes("//td[contains(@class,'gelcelbkgrdleft')]")[0];
                    string dateTextRaw = node.InnerText;

                    string[] dateTexts = dateTextRaw.Replace("&nbsp;", "").Split(':');
                    string dateText = dateTexts[0];

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("deleware_play3eve"))
                {
                    HtmlNode node = Connecticut.DocumentNode.SelectNodes("//td[contains(@class,'gelcelbkgrdleft')]")[0];
                    string dateTextRaw = node.InnerText;

                    string[] dateTexts = dateTextRaw.Replace("&nbsp;", "").Split(':');
                    string dateText = dateTexts[1];
                    dateText = Regex.Replace(dateText, @"\r|\n|\t", "");
                    dateText = dateText.Substring(dateText.Length - 8, 8);

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("deleware_play4day"))
                {
                    HtmlNode node = Connecticut.DocumentNode.SelectNodes("//td[contains(@class,'gelcelbkgrdright')]")[0];
                    string dateTextRaw = node.InnerText;

                    string[] dateTexts = dateTextRaw.Replace("&nbsp;", "").Split(':');
                    string dateText = dateTexts[0];

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("deleware_play4eve"))
                {
                    HtmlNode node = Connecticut.DocumentNode.SelectNodes("//td[contains(@class,'gelcelbkgrdright')]")[0];
                    string dateTextRaw = node.InnerText;

                    string[] dateTexts = dateTextRaw.Replace("&nbsp;", "").Split(':');
                    string dateText = dateTexts[1];
                    dateText = Regex.Replace(dateText, @"\r|\n|\t", "");
                    dateText = dateText.Substring(dateText.Length - 8, 8);

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("deleware_multiwin"))
                {
                    HtmlNode[] nodes = Connecticut.DocumentNode.SelectNodes("//tr").ToArray();
                    HtmlNode[] nodes2 = nodes[4].SelectNodes(".//strong").ToArray();
                    string dateTextRaw = nodes2[1].InnerText;

                    string[] innerTexts = dateTextRaw.Replace("&nbsp;", "").Split(':');
                    string innerText = innerTexts[0];
                    innerText = Regex.Replace(innerText, @"\r|\n|\t", "");
                    innerText = innerText.Trim();

                    DateTime dt = DateTime.ParseExact(innerText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
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
                    throw new MissingFieldException("Deleware.cs", lottery.html);
                }

                HtmlDocument Connecticut = new HtmlDocument();
                Connecticut.LoadHtml(lottery.html);


                if (lottery.lotteryName.Equals("deleware_play3day"))
                {
                    HtmlNode node = Connecticut.DocumentNode.SelectNodes("//td[contains(@class,'gelcelbkgrdleft')]")[0];
                    string dateTextRaw = node.InnerText;

                    string[] innerTexts = dateTextRaw.Replace("&nbsp;", "").Split(':');
                    string innerText = innerTexts[1];
                    innerText = Regex.Replace(innerText, @"\r|\n|\t", "");
                    innerText = innerText.Remove(innerText.Length - 8, 8);
                    innerText = innerText.Replace("Day ", "").Trim();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        numbers = new string[]
                        {
                            innerText[0].ToString(),
                            innerText[1].ToString(),
                            innerText[2].ToString(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("deleware_play3eve"))
                {
                    HtmlNode node = Connecticut.DocumentNode.SelectNodes("//td[contains(@class,'gelcelbkgrdleft')]")[0];
                    string dateTextRaw = node.InnerText;

                    string[] innerTexts = dateTextRaw.Replace("&nbsp;", "").Split(':');
                    string innerText = innerTexts[2];
                    innerText = Regex.Replace(innerText, @"\r|\n|\t", "");
                    innerText = innerText.Replace("Night", "").Trim();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        numbers = new string[]
                        {
                            innerText[0].ToString(),
                            innerText[1].ToString(),
                            innerText[2].ToString(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("deleware_play4day"))
                {
                    HtmlNode node = Connecticut.DocumentNode.SelectNodes("//td[contains(@class,'gelcelbkgrdright')]")[0];
                    string dateTextRaw = node.InnerText;

                    string[] innerTexts = dateTextRaw.Replace("&nbsp;", "").Split(':');
                    string innerText = innerTexts[1];
                    innerText = Regex.Replace(innerText, @"\r|\n|\t", "");
                    innerText = innerText.Remove(innerText.Length - 8, 8);
                    innerText = innerText.Replace("Day ", "").Trim();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        numbers = new string[]
                        {
                            innerText[0].ToString(),
                            innerText[1].ToString(),
                            innerText[2].ToString(),
                            innerText[3].ToString(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("deleware_play4eve"))
                {
                    HtmlNode node = Connecticut.DocumentNode.SelectNodes("//td[contains(@class,'gelcelbkgrdright')]")[0];
                    string dateTextRaw = node.InnerText;

                    string[] dateTexts = dateTextRaw.Replace("&nbsp;", "").Split(':');
                    string inner = dateTexts[2];
                    inner = Regex.Replace(inner, @"\r|\n|\t", "");
                    inner = inner.Replace("Night", "").Trim();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        numbers = new string[]
                        {
                            inner[0].ToString(),
                            inner[1].ToString(),
                            inner[2].ToString(),
                            inner[3].ToString(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("deleware_multiwin"))
                {
                    HtmlNode[] nodes = Connecticut.DocumentNode.SelectNodes("//tr").ToArray();
                    HtmlNode[] nodes2 = nodes[4].SelectNodes(".//strong").ToArray();
                    string dateTextRaw = nodes2[1].InnerText;

                    string[] innerTexts = dateTextRaw.Replace("&nbsp;", "").Split(':');
                    string innerText = innerTexts[1];
                    innerText = Regex.Replace(innerText, @"\r|\n|\t", "");
                    innerText = innerText.Trim();
                    innerText = innerText.Split(' ')[0];

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            innerText[0].ToString() + innerText[1].ToString(),
                            innerText[2].ToString() + innerText[3].ToString(),
                            innerText[4].ToString() + innerText[5].ToString(),
                            innerText[6].ToString() + innerText[7].ToString(),
                            innerText[8].ToString() + innerText[9].ToString(),
                            innerText[10].ToString() + innerText[11].ToString(),
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
