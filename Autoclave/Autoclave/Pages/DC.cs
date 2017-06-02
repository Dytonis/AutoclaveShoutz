using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Autoclave.Pages
{
    public class DC : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "dc";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "District of Columbia";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("DC.cs", lottery.html);
                }

                HtmlDocument DC = new HtmlDocument();
                DC.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("dc_3day"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC3DateD')]")[0];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "M/d/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("dc_3eve"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC3DateE')]")[0];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "M/d/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                if (lottery.lotteryName.Equals("dc_4day"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC4DateD')]")[0];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "M/d/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("dc_4eve"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC3DateE')]")[0];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "M/d/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                if (lottery.lotteryName.Equals("dc_5day"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC5DateD')]")[0];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "M/d/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("dc_5eve"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC5DateE')]")[0];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "M/d/yyyy", CultureInfo.InvariantCulture);
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
                    throw new MissingFieldException("DC.cs", lottery.html);
                }

                HtmlDocument DC = new HtmlDocument();
                DC.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("dc_3day"))
                {
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC3NumbersD')]")[0];

                    string[] numText = node.InnerText.Split('-');

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        info = new DebugDecodeInformation()
                        {
                            rawNumbersText = node.InnerHtml
                        },
                        numbers = new string[]
                        {
                            numText[0].Trim(),
                            numText[1].Trim(),
                            numText[2].Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("dc_3eve"))
                {
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC3NumbersE')]")[0];

                    string[] numText = node.InnerText.Split('-');

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        info = new DebugDecodeInformation()
                        {
                            rawNumbersText = node.InnerHtml
                        },
                        numbers = new string[]
                        {
                            numText[0].Trim(),
                            numText[1].Trim(),
                            numText[2].Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("dc_4day"))
                {
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC4NumbersD')]")[0];

                    string[] numText = node.InnerText.Split('-');

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        info = new DebugDecodeInformation()
                        {
                            rawNumbersText = node.InnerHtml
                        },
                        numbers = new string[]
                        {
                            numText[0].Trim(),
                            numText[1].Trim(),
                            numText[2].Trim(),
                            numText[3].Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("dc_4eve"))
                {
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC4NumbersE')]")[0];

                    string[] numText = node.InnerText.Split('-');

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        info = new DebugDecodeInformation()
                        {
                            rawNumbersText = node.InnerHtml
                        },
                        numbers = new string[]
                        {
                            numText[0].Trim(),
                            numText[1].Trim(),
                            numText[2].Trim(),
                            numText[3].Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("dc_5day"))
                {
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC5NumbersD')]")[0];

                    string[] numText = node.InnerText.Split('-');

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        info = new DebugDecodeInformation()
                        {
                            rawNumbersText = node.InnerHtml
                        },
                        numbers = new string[]
                        {
                            numText[0].Trim(),
                            numText[1].Trim(),
                            numText[2].Trim(),
                            numText[3].Trim(),
                            numText[4].Trim(),
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("dc_5eve"))
                {
                    HtmlNode node = DC.DocumentNode.SelectNodes("//span[contains(@id,'BaseBoard1_lblDC5NumbersE')]")[0];

                    string[] numText = node.InnerText.Split('-');

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        info = new DebugDecodeInformation()
                        {
                            rawNumbersText = node.InnerHtml
                        },
                        numbers = new string[]
                        {
                            numText[0].Trim(),
                            numText[1].Trim(),
                            numText[2].Trim(),
                            numText[3].Trim(),
                            numText[4].Trim(),
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
