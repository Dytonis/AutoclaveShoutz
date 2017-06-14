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
    public class Nebraska : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "nebraska";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Nebraska";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {

            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Nebraska.cs", "html");
            }

            HtmlDocument Nebraska = new HtmlDocument();
            Nebraska.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("nebraska_pick3"))
            {
                HtmlNode[] nodes = Nebraska.DocumentNode.SelectNodes("//div[contains(@class,'transBox')][4]//div").ToArray();
                string dateText = nodes[2].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("nebraska_myday"))
            {
                HtmlNode[] nodes = Nebraska.DocumentNode.SelectNodes("//div[contains(@class,'transBox')][5]//div").ToArray();
                string dateText = nodes[3].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("nebraska_2by2"))
            {
                HtmlNode[] nodes = Nebraska.DocumentNode.SelectNodes("//div[contains(@class,'transBox')][6]//div").ToArray();
                string dateText = nodes[2].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("nebraska_pick5"))
            {
                HtmlNode[] nodes = Nebraska.DocumentNode.SelectNodes("//div[contains(@class,'transBox')][3]//div").ToArray();
                string dateText = nodes[4].InnerText.Trim();

                DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else
            {
                throw new MissingFieldException("Nebraska.cs", "lottery");
            }
        }

        public LotteryNumber GetLatestNumbers(Lottery lottery)
        {
            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Nebraska.cs", "html");
            }

            HtmlDocument Nebraska = new HtmlDocument();
            Nebraska.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("nebraska_pick3"))
            {
                HtmlNode[] nodes = Nebraska.DocumentNode.SelectNodes("//div[contains(@class,'transBox')][4]//span").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        nodes[0].InnerText.Trim(),
                        nodes[1].InnerText.Trim(),
                        nodes[2].InnerText.Trim(),
                    }
                };
            }
            else if (lottery.lotteryName.Equals("nebraska_myday"))
            {
                HtmlNode[] nodes = Nebraska.DocumentNode.SelectNodes("//div[contains(@class,'transBox')][5]//span").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        nodes[3].InnerText.Trim(),
                        nodes[4].InnerText.Trim(),
                        nodes[5].InnerText.Trim().Replace(" ", ""),
                    }
                };
            }
            else if (lottery.lotteryName.Equals("nebraska_pick5"))
            {
                HtmlNode[] nodes = Nebraska.DocumentNode.SelectNodes("//div[contains(@class,'transBox')][3]//span").ToArray();

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
            else if (lottery.lotteryName.Equals("nebraska_2by2"))
            {
                HtmlNode[] nodes = Nebraska.DocumentNode.SelectNodes("//div[contains(@class,'transBox')][6]//span").ToArray();

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        nodes[0].InnerText.Trim(),
                        nodes[1].InnerText.Trim(),
                        nodes[2].InnerText.Trim(),
                        nodes[3].InnerText.Trim()
                    }
                };
            }
            else
            {
                throw new MissingFieldException("Nebraska.cs", "lottery");
            }
        }
    }
}
