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
    public class Louisiana : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "louisiana";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Louisiana";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {

            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Louisiana.cs", "html");
            }

            HtmlDocument Louisiana = new HtmlDocument();
            Louisiana.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("louisiana_lotto"))
            {
                HtmlNode[] nodes = Louisiana.DocumentNode.SelectNodes("//span[contains(@class,'ball inline-block reflect')]").ToArray();
                string dateText = nodes[4].InnerText.Replace(" Drawing", "").Replace("*", "");

                DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if (lottery.lotteryName.Equals("louisiana_2by2"))
            {
                HtmlNode[] nodes = Louisiana.DocumentNode.SelectNodes("//span[contains(@class,'Left90')]").ToArray();
                string dateText = nodes[5].InnerText.Replace(" Drawing", "").Replace("*", "");

                DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if(lottery.lotteryName.Equals("louisiana_pick3day"))
            {
                HtmlNode[] nodes = Louisiana.DocumentNode.SelectNodes("//span[contains(@class,'Left90')]").ToArray();
                string dateText = nodes[6].InnerText.Replace(" Midday", "").Replace("*", "");

                DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else if(lottery.lotteryName.Equals("louisiana_pick3eve"))
            {
                HtmlNode[] nodes = Louisiana.DocumentNode.SelectNodes("//span[contains(@class,'Left90')]").ToArray();
                string dateText = nodes[7].InnerText.Replace(" Evening", "").Replace("*", "");

                DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }

            return new DateTime();
        }

        public LotteryNumber GetLatestNumbers(Lottery lottery)
        {
            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("Louisiana.cs", "html");
            }

            HtmlDocument Louisiana = new HtmlDocument();
            Louisiana.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("louisiana_cash"))
            {
                HtmlNode[] nodes = Louisiana.DocumentNode.SelectNodes("//span[contains(@class,'ball inline-block reflect')]").ToArray();

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
                        nodes[5].InnerText
                    }
                };
            }
            else if (lottery.lotteryName.Equals("louisiana_2by2"))
            {
                HtmlNode[] nodes = Louisiana.DocumentNode.SelectNodes("//span[contains(@class,'Left100')]").ToArray();

                string removed1 = nodes[12].InnerText.Replace("Red - ", "");
                string removed2 = nodes[13].InnerText.Replace("White - ", "");

                string[] splits1 = removed1.Split(' ');
                string[] splits2 = removed2.Split(' ');

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        splits1[0],
                        splits1[1],
                        splits2[0],
                        splits2[1]
                    }
                };
            }
            else if (lottery.lotteryName.Equals("louisiana_pick3day"))
            {
                HtmlNode[] nodes = Louisiana.DocumentNode.SelectNodes("//span[contains(@class,'Left100')]").ToArray();

                string[] splits = nodes[14].InnerText.Split(' ');

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        splits[0],
                        splits[1],
                        splits[2],
                    }
                };
            }
            else if (lottery.lotteryName.Equals("louisiana_pick3eve"))
            {
                HtmlNode[] nodes = Louisiana.DocumentNode.SelectNodes("//span[contains(@class,'Left100')]").ToArray();

                string[] splits = nodes[15].InnerText.Split(' ');

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,
                    numbers = new string[]
                    {
                        splits[0],
                        splits[1],
                        splits[2],
                    }
                };
            }
            else
            {
                throw new MissingFieldException("Louisiana.cs", "lottery");
            }
        }
    }
}
