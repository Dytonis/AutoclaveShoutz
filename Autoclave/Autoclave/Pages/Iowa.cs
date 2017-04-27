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
    public class Iowa : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "iowa";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Iowa";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {

            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Iowa.cs", "html");
            }

            HtmlDocument Iowa = new HtmlDocument();
            Iowa.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("iowa_allornothingday"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'date')]").ToArray();
                string dateText = nodes[10].InnerText.Replace("Drawing Date: ", "").Replace(":", "");

                DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("iowa_allornothingeve"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'date')]").ToArray();
                string dateText = nodes[11].InnerText.Replace("Drawing Date: ", "").Replace(":", "");

                DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if(lottery.lotteryName.Equals("iowa_pick3day"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'date')]").ToArray();
                string dateText = nodes[6].InnerText.Replace(" MID-DAY", "");

                DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if(lottery.lotteryName.Equals("iowa_pick3eve"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'date')]").ToArray();
                string dateText = nodes[7].InnerText.Replace(" EVENING", "");

                DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("iowa_pick4day"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'date')]").ToArray();
                string dateText = nodes[8].InnerText.Replace(" MID-DAY", "");

                DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("iowa_pick4eve"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'date')]").ToArray();
                string dateText = nodes[9].InnerText.Replace(" EVENING", "");

                DateTime dt = DateTime.ParseExact(dateText, "M/d", CultureInfo.InvariantCulture);
                return dt;
            }

            return new DateTime();
        }

        public LotteryNumber GetLatestNumbers(Lottery lottery)
        {
            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Iowa.cs", "html");
            }

            HtmlDocument Iowa = new HtmlDocument();
            Iowa.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("iowa_allornothingday"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'number')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    subdate = "Day",
                    numbers = new string[]
                    {
                        nodes[24].InnerText,
                        nodes[25].InnerText,
                        nodes[26].InnerText,
                        nodes[27].InnerText,
                        nodes[28].InnerText,
                        nodes[29].InnerText,
                        nodes[30].InnerText,
                        nodes[31].InnerText,
                        nodes[32].InnerText,
                        nodes[33].InnerText,
                        nodes[34].InnerText,
                        nodes[35].InnerText,
                    }
                };
            }
            else if (lottery.lotteryName.Equals("iowa_allornothingeve"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'number')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    subdate = "Eve",
                    numbers = new string[]
                    {
                        nodes[36].InnerText,
                        nodes[37].InnerText,
                        nodes[38].InnerText,
                        nodes[39].InnerText,
                        nodes[40].InnerText,
                        nodes[41].InnerText,
                        nodes[42].InnerText,
                        nodes[43].InnerText,
                        nodes[44].InnerText,
                        nodes[45].InnerText,
                        nodes[46].InnerText,
                        nodes[47].InnerText,
                    }
                };
            }
            else if (lottery.lotteryName.Equals("iowa_pick3day"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'number')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    subdate = "Day",
                    numbers = new string[]
                    {
                        nodes[48].InnerText,
                        nodes[49].InnerText,
                        nodes[50].InnerText,
                    }
                };
            }
            else if (lottery.lotteryName.Equals("iowa_pick3eve"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'number')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    subdate = "Eve",
                    numbers = new string[]
                    {
                        nodes[51].InnerText,
                        nodes[52].InnerText,
                        nodes[53].InnerText,
                    }
                };
            }
            else if (lottery.lotteryName.Equals("iowa_pick4day"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'number')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    subdate = "Day",
                    numbers = new string[]
                    {
                        nodes[54].InnerText,
                        nodes[55].InnerText,
                        nodes[56].InnerText,
                        nodes[57].InnerText,
                    }
                };
            }
            else if (lottery.lotteryName.Equals("iowa_pick4eve"))
            {
                HtmlNode[] nodes = Iowa.DocumentNode.SelectNodes("//span[contains(@class,'number')]").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    subdate = "Eve",
                    numbers = new string[]
                    {
                        nodes[58].InnerText,
                        nodes[59].InnerText,
                        nodes[60].InnerText,
                        nodes[61].InnerText,
                    }
                };
            }
            else
            {
                throw new MissingFieldException("Iowa.cs", "lottery");
            }
        }
    }
}
