using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoclave.Pages
{
    public class Arizona : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "arizona";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Arizona";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Arizona.cs", lottery.html);
            }

            HtmlDocument Arizona = new HtmlDocument();
            Arizona.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("arizona_thepick"))
            {
                HtmlNode[] nodes = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix the-pick single')]//p").ToArray();
                string dateText = nodes[0].InnerText;

                DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("arizona_fantasy5"))
            {
                HtmlNode[] nodes = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix fantasy-5 single')]//p").ToArray();
                string dateText = nodes[0].InnerText;

                DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("arizona_pick3"))
            {
                HtmlNode[] nodes = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix pick-3 single')]//p").ToArray();
                string dateText = nodes[0].InnerText;

                DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("arizona_5cardcash"))
            {
                HtmlNode[] nodes = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix 5-card-cash single')]//p").ToArray();
                string dateText = nodes[0].InnerText;

                DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("arizona_allornothingday"))
            {
                HtmlNode[] nodes = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'all-or-nothing')]//p[contains(@class,'am')]").ToArray();
                string dateText = nodes[0].InnerText;

                DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("arizona_allornothingeve"))
            {
                HtmlNode[] nodes = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'all-or-nothing')]//p[contains(@class,'pm')]").ToArray();
                string dateText = nodes[0].InnerText;
                

                DateTime dt = DateTime.ParseExact(dateText, "dddd, MMMM d", CultureInfo.InvariantCulture);
                return dt;
            }
            else
            {
                return new DateTime();
            }
        }

        public LotteryNumber GetLatestNumbers(Lottery lottery)
        {
            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Arizona.cs", lottery.html);
            }

            HtmlDocument Arizona = new HtmlDocument();
            Arizona.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("arizona_thepick"))
            {
                HtmlNode node = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix the-pick single')]")[0];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'winning_ball')]//h2").ToArray();

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
            else if (lottery.lotteryName.Equals("arizona_fantasy5"))
            {
                HtmlNode node = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix fantasy-5 single')]")[0];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'winning_ball')]//h2").ToArray();

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
            else if (lottery.lotteryName.Equals("arizona_pick3"))
            {
                HtmlNode node = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix pick-3 single')]")[0];

                HtmlNode[] nodes2 = node.SelectNodes(".//div[contains(@class,'winning_ball')]//h2").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        nodes2[0].InnerText,
                        nodes2[1].InnerText,
                        nodes2[2].InnerText,
                    }
                };
            }
            else if (lottery.lotteryName.Equals("arizona_allornothingday"))
            {
                HtmlNode node1 = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix all-or-nothing')]//div[contains(@class,'winning_numbers am')]")[0];

                HtmlNode[] nodes1ball = node1.SelectNodes(".//div[contains(@class,'winning_ball')]//h2").ToArray();

                HtmlNode node2 = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix all-or-nothing')]//div[contains(@class,'winning_numbers am')]")[1];

                HtmlNode[] nodes2ball = node2.SelectNodes(".//div[contains(@class,'winning_ball')]//h2").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    subdate = "AM",
                    numbers = new string[]
                    {
                        nodes1ball[0].InnerText,
                        nodes1ball[1].InnerText,
                        nodes1ball[2].InnerText,
                        nodes1ball[3].InnerText,
                        nodes1ball[4].InnerText,
                        nodes2ball[0].InnerText,
                        nodes2ball[1].InnerText,
                        nodes2ball[2].InnerText,
                        nodes2ball[3].InnerText,
                        nodes2ball[4].InnerText,
                    }
                };
            }
            else if (lottery.lotteryName.Equals("arizona_allornothingeve"))
            {
                HtmlNode node1 = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix all-or-nothing')]//div[contains(@class,'winning_numbers pm')]")[0];

                HtmlNode[] nodes1ball = node1.SelectNodes(".//div[contains(@class,'winning_ball')]//h2").ToArray();

                HtmlNode node2 = Arizona.DocumentNode.SelectNodes("//div[contains(@class,'clearfix all-or-nothing')]//div[contains(@class,'winning_numbers pm')]")[1];

                HtmlNode[] nodes2ball = node2.SelectNodes(".//div[contains(@class,'winning_ball')]//h2").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    subdate = "PM",
                    numbers = new string[]
                    {
                        nodes1ball[0].InnerText,
                        nodes1ball[1].InnerText,
                        nodes1ball[2].InnerText,
                        nodes1ball[3].InnerText,
                        nodes1ball[4].InnerText,
                        nodes2ball[0].InnerText,
                        nodes2ball[1].InnerText,
                        nodes2ball[2].InnerText,
                        nodes2ball[3].InnerText,
                        nodes2ball[4].InnerText,
                    }
                };
            }

            return new LotteryNumber();
        }
    }
}
