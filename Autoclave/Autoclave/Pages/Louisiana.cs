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

            if (lottery.lotteryName.Equals("louisiana_lotto") || lottery.lotteryName.Equals("louisiana_easy5") || lottery.lotteryName.Equals("louisiana_pick4") || lottery.lotteryName.Equals("louisiana_pick3"))
            {
                HtmlNode[] nodes = Louisiana.DocumentNode.SelectNodes("//span[contains(@class,'text-error')]").ToArray();

                DateTime dt = DateTime.ParseExact(nodes[0].InnerText, "dddd, MMM d, yyyy", CultureInfo.InvariantCulture);
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

            if (lottery.lotteryName.Equals("louisiana_lotto") || lottery.lotteryName.Equals("louisiana_easy5") || lottery.lotteryName.Equals("louisiana_pick4") || lottery.lotteryName.Equals("louisiana_pick3"))
            {
                HtmlNode[] nodes = Louisiana.DocumentNode.SelectNodes("//span[contains(@class,'ball inline-block reflect')]").ToArray();

                List<string> picks = new List<string>();

                foreach(HtmlNode n in nodes)
                {
                    picks.Add(n.InnerText);
                }

                return new LotteryNumber()
                {
                    date = GetLatestDate(lottery),
                    lottery = lottery,

                    numbers = picks.ToArray()
                };
            }
            else
            {
                throw new MissingFieldException("Louisiana.cs", "lottery");
            }
        }
    }
}
