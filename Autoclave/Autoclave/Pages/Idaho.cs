using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoclave.Pages
{
    public class Idaho : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "idaho";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Idaho";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("Idaho.cs", lottery.html);
                }

                HtmlDocument Idaho = new HtmlDocument();
                Idaho.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("idaho_cash") || lottery.lotteryName.Equals("idaho_weeklygrand"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Idaho.DocumentNode.SelectNodes("//table")[0];
                    HtmlNode node2 = node.SelectSingleNode(".//td");
                    string dateText = node2.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "M/d/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("idaho_pick3day"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Idaho.DocumentNode.SelectNodes("//table")[0];
                    HtmlNode node2 = node.SelectSingleNode(".//p[contains(@class,'day')]");

                    HtmlNode node3 = node2.ParentNode.ParentNode.SelectSingleNode(".//td"); //back up 2

                    string dateText = node3.InnerText;

                    DateTime dt = DateTime.ParseExact(dateText, "M/d/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (lottery.lotteryName.Equals("idaho_pick3eve"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Idaho.DocumentNode.SelectNodes("//table")[0];
                    HtmlNode node2 = node.SelectSingleNode(".//p[contains(@class,'night')]");

                    HtmlNode node3 = node2.ParentNode.ParentNode.SelectSingleNode(".//td"); //back up 2

                    string dateText = node3.InnerText;

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
                    throw new MissingFieldException("Idaho.cs", lottery.html);
                }

                HtmlDocument Idaho = new HtmlDocument();
                Idaho.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("idaho_cash") || lottery.lotteryName.Equals("idaho_weeklygrand"))
                {
                    HtmlNode[] nodes = Idaho.DocumentNode.SelectNodes("//span[contains(@class,'wBall')]").ToArray();

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
                else if (lottery.lotteryName.Equals("idaho_pick3day"))
                {
                    HtmlNode node = Idaho.DocumentNode.SelectNodes("//table")[0];
                    HtmlNode node2 = node.SelectSingleNode(".//p[contains(@class,'day')]");

                    HtmlNode[] nodes = node2.ParentNode.ParentNode.SelectNodes(".//span[contains(@class,'wBall')]").ToArray(); //back up 2

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Day",
                        numbers = new string[]
                        {
                            nodes[0].InnerText,
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                        },
                        specials = new string[]
                        {
                            (Convert.ToInt16(nodes[0].InnerText) + Convert.ToInt16(nodes[1].InnerText) + Convert.ToInt16(nodes[2].InnerText)).ToString()
                        }
                    };
                }
                else if (lottery.lotteryName.Equals("idaho_pick3eve"))
                {
                    HtmlNode node = Idaho.DocumentNode.SelectNodes("//table")[0];
                    HtmlNode node2 = node.SelectSingleNode(".//p[contains(@class,'night')]");

                    HtmlNode[] nodes = node2.ParentNode.ParentNode.SelectNodes(".//span[contains(@class,'wBall')]").ToArray(); //back up 2

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        subdate = "Eve",
                        numbers = new string[]
                        {
                            nodes[0].InnerText,
                            nodes[1].InnerText,
                            nodes[2].InnerText,
                        },
                        specials = new string[]
                        {
                            (Convert.ToInt16(nodes[0].InnerText) + Convert.ToInt16(nodes[1].InnerText) + Convert.ToInt16(nodes[2].InnerText)).ToString()
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
