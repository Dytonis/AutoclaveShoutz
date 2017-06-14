using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Autoclave.Pages
{
    public class NorthCarolina : State, IStateDecodable
    {
        public string stateName
        {
            get
            {
                return "northcarolina";
            }
        }

        public string stateNameUI
        {
            get
            {
                return "NorthCarolina";
            }
        }

        public DateTime GetLatestDate(Lottery lottery)
        {

            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("NorthCarolina.cs", "html");
            }

            HtmlDocument NorthCarolina = new HtmlDocument();
            NorthCarolina.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("northcarolina_pick3day"))
            {
                HtmlNode[] nodes = NorthCarolina.DocumentNode.SelectNodes("//table[contains(@class,'drawtable')]").ToArray();

                //check if the first block is day or eve
                if(nodes[0].SelectSingleNode(".//div[contains(@class,'Day')]") != null)
                {
                    //1
                    HtmlNode[] nodes2 = nodes[0].SelectNodes(".//div[contains(@class,'calendar')]").ToArray();
                    string text = nodes2[0].InnerText.Trim();
                    string replacement = Regex.Replace(text, @"\t|\n", "");
                    replacement = Regex.Replace(replacement, @"\r", " ");

                    DateTime dt = DateTime.ParseExact(replacement, "ddd d MMM yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if(nodes[1].SelectSingleNode(".//div[contains(@class,'Day')]") != null)
                {
                    //2, try the second block
                    HtmlNode[] nodes2 = nodes[1].SelectNodes(".//div[contains(@class,'calendar')]").ToArray();
                    string text = nodes2[0].InnerText.Trim();
                    string replacement = Regex.Replace(text, @"\t|\n", "");
                    replacement = Regex.Replace(replacement, @"\r", " ");

                    DateTime dt = DateTime.ParseExact(replacement, "ddd d MMM yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else
                {
                    Logging.AddToLog(new string[]
                    {
                        "Autoclave could not parse a dynamic lottery pair. The target 'Day' was not found in either scenarios.",
                        "    [" + lottery.lotteryName + "]"
                    });

                    throw new MissingMemberException("Error parsing dynamic pair.");
                }
            }
            else if (lottery.lotteryName.Equals("northcarolina_pick3eve"))
            {
                HtmlNode[] nodes = NorthCarolina.DocumentNode.SelectNodes("//table[contains(@class,'drawtable')]").ToArray();

                //check if the first block is day or eve
                if (nodes[0].SelectSingleNode(".//div[contains(@class,'Eve')]") != null)
                {
                    //1
                    HtmlNode[] nodes2 = nodes[0].SelectNodes(".//div[contains(@class,'calendar')]").ToArray();
                    string text = nodes2[0].InnerText.Trim();
                    string replacement = Regex.Replace(text, @"\t|\n", "");
                    replacement = Regex.Replace(replacement, @"\r", " ");

                    DateTime dt = DateTime.ParseExact(replacement, "ddd d MMM yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (nodes[1].SelectSingleNode(".//div[contains(@class,'Eve')]") != null)
                {
                    //2, try the second block
                    HtmlNode[] nodes2 = nodes[1].SelectNodes(".//div[contains(@class,'calendar')]").ToArray();
                    string text = nodes2[0].InnerText.Trim();
                    string replacement = Regex.Replace(text, @"\t|\n", "");
                    replacement = Regex.Replace(replacement, @"\r", " ");

                    DateTime dt = DateTime.ParseExact(replacement, "ddd d MMM yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else
                {
                    Logging.AddToLog(new string[]
                    {
                        "Autoclave could not parse a dynamic lottery pair. The target 'Eve' was not found in either scenarios.",
                        "    [" + lottery.lotteryName + "]"
                    });

                    throw new MissingMemberException("Error parsing dynamic pair.");
                }
            }
            else if (lottery.lotteryName.Equals("northcarolina_pick4day"))
            {
                HtmlNode[] nodes = NorthCarolina.DocumentNode.SelectNodes("//table[contains(@class,'drawtable')]").ToArray();

                //check if the first block is day or eve
                if (nodes[2].SelectSingleNode(".//div[contains(@class,'Day')]") != null)
                {
                    //1
                    HtmlNode[] nodes2 = nodes[2].SelectNodes(".//div[contains(@class,'calendar')]").ToArray();
                    string text = nodes2[0].InnerText.Trim();
                    string replacement = Regex.Replace(text, @"\t|\n", "");
                    replacement = Regex.Replace(replacement, @"\r", " ");

                    DateTime dt = DateTime.ParseExact(replacement, "ddd d MMM yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (nodes[3].SelectSingleNode(".//div[contains(@class,'Day')]") != null)
                {
                    //2, try the second block
                    HtmlNode[] nodes2 = nodes[3].SelectNodes(".//div[contains(@class,'calendar')]").ToArray();
                    string text = nodes2[0].InnerText.Trim();
                    string replacement = Regex.Replace(text, @"\t|\n", "");
                    replacement = Regex.Replace(replacement, @"\r", " ");

                    DateTime dt = DateTime.ParseExact(replacement, "ddd d MMM yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else
                {
                    Logging.AddToLog(new string[]
                    {
                        "Autoclave could not parse a dynamic lottery pair. The target 'Day' was not found in either scenarios.",
                        "    [" + lottery.lotteryName + "]"
                    });

                    throw new MissingMemberException("Error parsing dynamic pair.");
                }
            }
            else if (lottery.lotteryName.Equals("northcarolina_pick4eve"))
            {
                HtmlNode[] nodes = NorthCarolina.DocumentNode.SelectNodes("//table[contains(@class,'drawtable')]").ToArray();

                //check if the first block is day or eve
                if (nodes[2].SelectSingleNode(".//div[contains(@class,'Eve')]") != null)
                {
                    //1
                    HtmlNode[] nodes2 = nodes[2].SelectNodes(".//div[contains(@class,'calendar')]").ToArray();
                    string text = nodes2[0].InnerText.Trim();
                    string replacement = Regex.Replace(text, @"\t|\n", "");
                    replacement = Regex.Replace(replacement, @"\r", " ");

                    DateTime dt = DateTime.ParseExact(replacement, "ddd d MMM yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else if (nodes[3].SelectSingleNode(".//div[contains(@class,'Eve')]") != null)
                {
                    //2, try the second block
                    HtmlNode[] nodes2 = nodes[3].SelectNodes(".//div[contains(@class,'calendar')]").ToArray();
                    string text = nodes2[0].InnerText.Trim();
                    string replacement = Regex.Replace(text, @"\t|\n", "");
                    replacement = Regex.Replace(replacement, @"\r", " ");

                    DateTime dt = DateTime.ParseExact(replacement, "ddd d MMM yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                else
                {
                    Logging.AddToLog(new string[]
                    {
                        "Autoclave could not parse a dynamic lottery pair. The target 'Eve' was not found in either scenarios.",
                        "    [" + lottery.lotteryName + "]"
                    });

                    throw new MissingMemberException("Error parsing dynamic pair.");
                }
            }
            else if (lottery.lotteryName.Equals("northcarolina_cash5"))
            {
                HtmlNode[] nodes = NorthCarolina.DocumentNode.SelectNodes("//table[contains(@class,'drawtable')]").ToArray();
                HtmlNode[] nodes2 = nodes[4].SelectNodes(".//div[contains(@class,'calendar')]").ToArray();
                string text = nodes2[0].InnerText.Trim();
                string replacement = Regex.Replace(text, @"\t|\n", "");
                replacement = Regex.Replace(replacement, @"\r", " ");

                DateTime dt = DateTime.ParseExact(replacement, "ddd d MMM yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            else
            {
                Logging.AddToLog(new string[]
                {
                    "Autoclave could not find the specified lottery.",
                    "    [" + lottery.lotteryName + "]"
                });
                throw new MissingFieldException("NorthCarolina.cs", "lottery");
            }
        }

        public LotteryNumber GetLatestNumbers(Lottery lottery)
        {
            if (String.IsNullOrWhiteSpace((lottery.html)))
            {
                throw new MissingFieldException("NorthCarolina.cs", "html");
            }

            HtmlDocument NorthCarolina = new HtmlDocument();
            NorthCarolina.LoadHtml(lottery.html);

            if (lottery.lotteryName.Equals("northcarolina_pick3day"))
            {
                HtmlNode[] nodes = NorthCarolina.DocumentNode.SelectNodes("//table[contains(@class,'drawtable')]").ToArray();

                //check if the first block is day or eve
                if (nodes[0].SelectSingleNode(".//div[contains(@class,'Day')]") != null)
                {
                    //1
                    HtmlNode[] nodes2 = nodes[0].SelectNodes(".//div[contains(@class,'ball')]").ToArray();
                    HtmlNode sumNode = nodes[0].SelectSingleNode(".//span[contains(@class,'sumitup')]//span[2]");

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
                else if (nodes[1].SelectSingleNode(".//div[contains(@class,'Day')]") != null)
                {
                    //2, try the second block
                    HtmlNode[] nodes2 = nodes[1].SelectNodes(".//div[contains(@class,'ball')]").ToArray();
                    HtmlNode sumNode = nodes[1].SelectSingleNode(".//span[contains(@class,'sumitup')]//span[2]");

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes2[0].InnerText.Trim(),
                            nodes2[1].InnerText.Trim(),
                            nodes2[2].InnerText.Trim(),
                        },
                    };
                }
                else
                {
                    Logging.AddToLog(new string[]
                    {
                        "Autoclave could not parse a dynamic lottery pair. The target 'Day' was not found in either scenarios.",
                        "    [" + lottery.lotteryName + "]"
                    });

                    throw new MissingMemberException("Error parsing dynamic pair.");
                }
            }
            else if (lottery.lotteryName.Equals("northcarolina_pick3eve"))
            {
                HtmlNode[] nodes = NorthCarolina.DocumentNode.SelectNodes("//table[contains(@class,'drawtable')]").ToArray();

                //check if the first block is day or eve
                if (nodes[0].SelectSingleNode(".//div[contains(@class,'Eve')]") != null)
                {
                    //1
                    HtmlNode[] nodes2 = nodes[0].SelectNodes(".//div[contains(@class,'ball')]").ToArray();
                    HtmlNode sumNode = nodes[0].SelectSingleNode(".//span[contains(@class,'sumitup')]//span[2]");

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes2[0].InnerText.Trim(),
                            nodes2[1].InnerText.Trim(),
                            nodes2[2].InnerText.Trim(),
                        },
                    };
                }
                else if (nodes[1].SelectSingleNode(".//div[contains(@class,'Eve')]") != null)
                {
                    //2, try the second block
                    HtmlNode[] nodes2 = nodes[1].SelectNodes(".//div[contains(@class,'ball')]").ToArray();
                    HtmlNode sumNode = nodes[1].SelectSingleNode(".//span[contains(@class,'sumitup')]//span[2]");

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes2[0].InnerText.Trim(),
                            nodes2[1].InnerText.Trim(),
                            nodes2[2].InnerText.Trim(),
                        },
                    };
                }
                else
                {
                    Logging.AddToLog(new string[]
                    {
                        "Autoclave could not parse a dynamic lottery pair. The target 'Eve' was not found in either scenarios.",
                        "    [" + lottery.lotteryName + "]"
                    });

                    throw new MissingMemberException("Error parsing dynamic pair.");
                }
            }
            else if (lottery.lotteryName.Equals("northcarolina_pick4day"))
            {
                HtmlNode[] nodes = NorthCarolina.DocumentNode.SelectNodes("//table[contains(@class,'drawtable')]").ToArray();

                //check if the first block is day or eve
                if (nodes[2].SelectSingleNode(".//div[contains(@class,'Day')]") != null)
                {
                    //1
                    HtmlNode[] nodes2 = nodes[2].SelectNodes(".//div[contains(@class,'ball')]").ToArray();
                    HtmlNode sumNode = nodes[2].SelectSingleNode(".//span[contains(@class,'sumitup')]//span[2]");

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes2[0].InnerText.Trim(),
                            nodes2[1].InnerText.Trim(),
                            nodes2[2].InnerText.Trim(),
                            nodes2[3].InnerText.Trim()
                        },
                    };
                }
                else if (nodes[3].SelectSingleNode(".//div[contains(@class,'Day')]") != null)
                {
                    //2, try the second block
                    HtmlNode[] nodes2 = nodes[3].SelectNodes(".//div[contains(@class,'ball')]").ToArray();
                    HtmlNode sumNode = nodes[3].SelectSingleNode(".//span[contains(@class,'sumitup')]//span[2]");

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
                        },
                    };
                }
                else
                {
                    Logging.AddToLog(new string[]
                    {
                        "Autoclave could not parse a dynamic lottery pair. The target 'Day' was not found in either scenarios.",
                        "    [" + lottery.lotteryName + "]"
                    });

                    throw new MissingMemberException("Error parsing dynamic pair.");
                }
            }
            else if (lottery.lotteryName.Equals("northcarolina_pick4eve"))
            {
                HtmlNode[] nodes = NorthCarolina.DocumentNode.SelectNodes("//table[contains(@class,'drawtable')]").ToArray();

                //check if the first block is day or eve
                if (nodes[2].SelectSingleNode(".//div[contains(@class,'Eve')]") != null)
                {
                    //1
                    HtmlNode[] nodes2 = nodes[2].SelectNodes(".//div[contains(@class,'ball')]").ToArray();
                    HtmlNode sumNode = nodes[2].SelectSingleNode(".//span[contains(@class,'sumitup')]//span[2]");

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes2[0].InnerText.Trim(),
                            nodes2[1].InnerText.Trim(),
                            nodes2[2].InnerText.Trim(),
                            nodes2[3].InnerText.Trim()
                        },
                    };
                }
                else if (nodes[3].SelectSingleNode(".//div[contains(@class,'Eve')]") != null)
                {
                    //2, try the second block
                    HtmlNode[] nodes2 = nodes[3].SelectNodes(".//div[contains(@class,'ball')]").ToArray();
                    HtmlNode sumNode = nodes[3].SelectSingleNode(".//span[contains(@class,'sumitup')]//span[2]");

                    return new LotteryNumber()
                    {
                        date = GetLatestDate(lottery),
                        lottery = lottery,
                        numbers = new string[]
                        {
                            nodes2[0].InnerText.Trim(),
                            nodes2[1].InnerText.Trim(),
                            nodes2[2].InnerText.Trim(),
                            nodes2[3].InnerText.Trim()
                        },
                    };
                }
                else
                {
                    Logging.AddToLog(new string[]
                    {
                        "Autoclave could not parse a dynamic lottery pair. The target 'Eve' was not found in either scenarios.",
                        "    [" + lottery.lotteryName + "]"
                    });

                    throw new MissingMemberException("Error parsing dynamic pair.");
                }
            }
            else if (lottery.lotteryName.Equals("northcarolina_cash5"))
            {
                HtmlNode[] nodes = NorthCarolina.DocumentNode.SelectNodes("//table[contains(@class,'drawtable')]").ToArray();
                HtmlNode[] nodes2 = nodes[4].SelectNodes(".//div[contains(@class,'ball')]").ToArray();

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
                            nodes2[4].InnerText.Trim()
                    }
                };
            }
            else
            {
                throw new MissingFieldException("NorthCarolina.cs", "lottery");
            }
        }
    }
}
