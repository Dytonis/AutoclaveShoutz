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
    public class Washington : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "washington";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Washington";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {

            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Washington.cs", "html");
            }

            HtmlDocument Washington = new HtmlDocument();
            Washington.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("washington_lotto"))
            {
                HtmlNode[] nodes = Washington.DocumentNode.SelectNodes("//div[contains(@class,'game-bucket')]//strong").ToArray();
                string dateText = nodes[6].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "ddd/MMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("washington_hit5"))
            {
                HtmlNode[] nodes = Washington.DocumentNode.SelectNodes("//div[contains(@class,'game-bucket')]//strong").ToArray();
                string dateText = nodes[12].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "ddd/MMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("washington_match4"))
            {
                HtmlNode[] nodes = Washington.DocumentNode.SelectNodes("//div[contains(@class,'game-bucket')]//strong").ToArray();
                string dateText = nodes[14].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "ddd/MMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("washington_dailygame"))
            {
                HtmlNode[] nodes = Washington.DocumentNode.SelectNodes("//div[contains(@class,'game-bucket')]//strong").ToArray();
                string dateText = nodes[15].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "ddd/MMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("washington_keno"))
            {
                HtmlNode[] nodes = Washington.DocumentNode.SelectNodes("//div[contains(@class,'game-bucket')]//strong").ToArray();
                string dateText = nodes[18].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "ddd/MMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else
            {
                throw new MissingFieldException("Washington.cs", "lottery");
            }
        }

        public LotteryNumber GetLatestNumbers(Lottery lottery)
        {
            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Washington.cs", "html");
            }

            HtmlDocument Washington = new HtmlDocument();
            Washington.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("washington_lotto"))
            {
                HtmlNode[] nodes = Washington.DocumentNode.SelectNodes("//div[contains(@class,'game-balls')]").ToArray();
                HtmlNode[] nodes2 = nodes[2].SelectNodes(".//li").ToArray();

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
            else if (lottery.lotteryName.Equals("washington_hit5"))
            {
                HtmlNode[] nodes = Washington.DocumentNode.SelectNodes("//div[contains(@class,'game-balls')]").ToArray();
                HtmlNode[] nodes2 = nodes[4].SelectNodes(".//li").ToArray();

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
            else if (lottery.lotteryName.Equals("washington_match4"))
            {
                HtmlNode[] nodes = Washington.DocumentNode.SelectNodes("//div[contains(@class,'game-balls')]").ToArray();
                HtmlNode[] nodes2 = nodes[5].SelectNodes(".//li").ToArray();

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
                    }
                };
            }
            else if (lottery.lotteryName.Equals("washington_dailygame"))
            {
                HtmlNode[] nodes = Washington.DocumentNode.SelectNodes("//div[contains(@class,'game-balls')]").ToArray();
                HtmlNode[] nodes2 = nodes[6].SelectNodes(".//li").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        nodes2[0].InnerText.Trim(),
                        nodes2[1].InnerText.Trim(),
                        nodes2[2].InnerText.Trim(),
                    }
                };
            }
            else if (lottery.lotteryName.Equals("washington_keno"))
            {
                HtmlNode[] nodes = Washington.DocumentNode.SelectNodes("//div[contains(@class,'game-balls')]").ToArray();
                HtmlNode[] nodes2 = nodes[9].SelectNodes(".//li").ToArray();

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
                        nodes2[6].InnerText.Trim(),
                        nodes2[7].InnerText.Trim(),
                        nodes2[8].InnerText.Trim(),
                        nodes2[9].InnerText.Trim(),
                        nodes2[10].InnerText.Trim(),
                        nodes2[11].InnerText.Trim(),
                        nodes2[12].InnerText.Trim(),
                        nodes2[13].InnerText.Trim(),
                        nodes2[14].InnerText.Trim(),
                        nodes2[15].InnerText.Trim(),
                        nodes2[16].InnerText.Trim(),
                        nodes2[17].InnerText.Trim(),
                        nodes2[18].InnerText.Trim(),
                        nodes2[19].InnerText.Trim(),
                    }
                };
            }
            else
            {
                throw new MissingFieldException("Washington.cs", "lottery");
            }
        }
    }
}
