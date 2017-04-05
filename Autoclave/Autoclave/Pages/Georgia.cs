using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoclave.Pages
{
    public class Georgia : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "georgia";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "Georgia";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {
            try
            {
                if (String.IsNullOrWhiteSpace((lottery.html)))
                {
                    throw new MissingFieldException("Georgia.cs", lottery.html);
                }

                HtmlDocument Georgia = new HtmlDocument();
                Georgia.LoadHtml(lottery.html);

                if (lottery.lotteryName.Equals("georgia_jumbobucks"))
                {
                    //File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Autoclave\\Save\\" + lottery.lotteryName + ".html", lottery.html);
                    HtmlNode node = Georgia.DocumentNode.SelectNodes("//div[contains(@class,'winning-numbers')]")[0];
                    HtmlNode node2 = node.SelectSingleNode(".//time");
                    string dateText = node2.InnerHtml;

                    DateTime dt = DateTime.ParseExact(dateText, "MM/dd/yyyy", CultureInfo.InvariantCulture);
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
            throw new NotImplementedException();
        }
    }
}
