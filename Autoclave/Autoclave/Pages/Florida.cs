using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoclave.Pages
{
    public class Florida : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "florida";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Florida";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("Florida.cs", lottery.html);
                }

                HtmlDocument Florida = new HtmlDocument();
                Florida.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("florida_lotto"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate wnDateSlideOut')]")[2];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("florida_luckymoney"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate wnDateSlideOut')]")[4];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("florida_fantasy5"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate wnDateSlideOut')]")[5];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("florida_pick5day"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate')]")[6];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("florida_pick5eve"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate')]")[7];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("florida_pick4day"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate')]")[8];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("florida_pick4eve"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate')]")[9];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("florida_pick3day"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate')]")[10];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("florida_pick3eve"))
                {
                    ///File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate')]")[11];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("florida_pick2day"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate')]")[12];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("florida_pick2eve"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnDate')]")[13];
                    string dateText = node.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture);
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
                    throw new MissingFieldException("Florida.cs", lottery.html);
                }

                HtmlDocument Florida = new HtmlDocument();
                Florida.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("florida_lotto"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[2];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes[0].InnerText,
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                            nodes[4].InnerText,
                            nodes[5].InnerText,
                            nodes[6].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("florida_luckymoney"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[4];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes[0].InnerText,
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                            nodes[4].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("florida_fantasy5"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[5];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes[0].InnerText,
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                            nodes[4].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("florida_pick5day"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[6];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        numbers = new string[]
                        {
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                            nodes[4].InnerText,
                            nodes[5].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("florida_pick5eve"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[7];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        numbers = new string[]
                        {
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                            nodes[4].InnerText,
                            nodes[5].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("florida_pick4day"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[8];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        numbers = new string[]
                        {
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                            nodes[4].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("florida_pick4eve"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[9];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        numbers = new string[]
                        {
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                            nodes[4].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("florida_pick3day"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[10];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        numbers = new string[]
                        {
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("florida_pick3eve"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[11];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        numbers = new string[]
                        {
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                            nodes[3].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("florida_pick2day"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[12];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        numbers = new string[]
                        {
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("florida_pick2eve"))
                {
                    HtmlNode node = Florida.DocumentNode.SelectNodes("//p[contains(@class,'wnBalls')]")[13];
                    HtmlNode[] nodes = node.SelectNodes(".//span[contains(@class,'balls')]").ToArray();

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        numbers = new string[]
                        {
                            nodes[1].InnerText,
                            nodes[2].InnerText,
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
