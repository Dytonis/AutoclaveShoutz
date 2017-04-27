using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoclave.Pages
{
    public static class States
    {
        public static Dictionary<string, string> CachedURLS = new Dictionary<string, string>();
        public static List<State> AllStates = new List<State>()
        {
            new Maine
            {
               lotteries = new List<Lottery>()
               {
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_megabucks",
                       lotteryNameUI = "Megabucks",
                       state = new Pages.Maine(),
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_luckyforlife",
                       Action = LotteryDecodeAction.Skip,
                       lotteryNameUI = "Lucky For Life",
                       state = new Pages.Maine(),
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_hotlottosizzler",
                       lotteryNameUI = "Hot Lotto Sizzler",
                       state = new Pages.Maine(),
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_pick3day",
                       lotteryNameUI = "Pick 3",
                       state = new Pages.Maine(),
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_pick3eve",
                       lotteryNameUI = "Pick 3",
                       state = new Pages.Maine(),
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_pick4day",
                       lotteryNameUI = "Pick 4",
                       state = new Pages.Maine(),
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_pick4eve",
                       lotteryNameUI = "Pick 4",
                       state = new Pages.Maine(),
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_gimme5",
                       lotteryNameUI = "Gimme 5",
                       state = new Pages.Maine(),
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_wptallin",
                       lotteryNameUI = "WPT All In",
                       state = new Pages.Maine(),
                       Action = LotteryDecodeAction.DateTrigger
                   },
               },
            },
            new Arizona
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_thepick",
                        lotteryNameUI = "The Pick",
                        state = new Pages.Arizona(),
                    },
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_fantasy5",
                        lotteryNameUI = "Fantasy 5",
                        state = new Pages.Arizona(),
                    },
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_pick3",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Arizona(),
                    },
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_5cardcash",
                        lotteryNameUI = "5 Card Cash",
                        state = new Pages.Arizona(),
                        Action = LotteryDecodeAction.DateTrigger
                    },
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_allornothingday",
                        lotteryNameUI = "All or Nothing",
                        state = new Pages.Arizona(),
                    },
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_allornothingeve",
                        lotteryNameUI = "All or Nothing",
                        state = new Pages.Arizona(),
                    },
                }
            },
            new Arkansas
            {
                lotteries = new List<Lottery>()
                {
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_nsj",
                       lotteryNameUI = "Natural State Jackpot",
                       state = new Pages.Arkansas(),
                   },
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_luckyforlife",
                       Action = LotteryDecodeAction.Skip,
                       lotteryNameUI = "Lucky For Life",
                       state = new Pages.Arkansas(),
                   },
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_cash3day",
                       lotteryNameUI = "Cash 3",
                       state = new Pages.Arkansas(),
                   },
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_cash3eve",
                       lotteryNameUI = "Cash 3",
                       state = new Pages.Arkansas(),
                   },
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_cash4day",
                       lotteryNameUI = "Cash 4",
                       state = new Pages.Arkansas(),
                   },
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_cash4eve",
                       lotteryNameUI = "Cash 4",
                       state = new Pages.Arkansas(),
                   },
                }
            },
            new California
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                       url = "http://www.calottery.com/play/draw-games/superlotto-plus/",
                       lotteryName = "california_superlotto",
                       lotteryNameUI = "Super Lotto",
                       state = new Pages.California(),
                    },
                    new Lottery
                    {
                       url = "http://www.calottery.com/play/draw-games/fantasy-5/",
                       lotteryName = "california_fantasy5",
                       lotteryNameUI = "Fantasy 5",
                       state = new Pages.California(),
                    },
                    new Lottery
                    {
                       url = "http://www.calottery.com/play/draw-games/daily-3/",
                       lotteryName = "california_daily3day",
                       lotteryNameUI = "Daily 3",
                       state = new Pages.California(),
                    },
                    new Lottery
                    {
                       url = "http://www.calottery.com/play/draw-games/daily-3/",
                       lotteryName = "california_daily3eve",
                       lotteryNameUI = "Daily 3",
                       state = new Pages.California(),
                    },
                    new Lottery
                    {
                       url = "http://www.calottery.com/play/draw-games/daily-4/",
                       lotteryName = "california_daily4",
                       lotteryNameUI = "Daily 4",
                       state = new Pages.California(),
                    },
                }
            },
            new Colorado
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                       url = "https://www.coloradolottery.com/en/",
                       lotteryName = "colorado_luckyforlife",
                       Action = LotteryDecodeAction.Skip,
                       lotteryNameUI = "Lucky for Life",
                       state = new Pages.Colorado(),
                   },
                    new Lottery
                    {
                       url = "https://www.coloradolottery.com/en/",
                       lotteryName = "colorado_lotto",
                       lotteryNameUI = "Lotto",
                       state = new Pages.Colorado(),
                   },
                    new Lottery
                    {
                       url = "https://www.coloradolottery.com/en/",
                       lotteryName = "colorado_cash5",
                       lotteryNameUI = "Cash 5",
                       state = new Pages.Colorado(),
                   },
                    new Lottery
                    {
                       url = "https://www.coloradolottery.com/en/",
                       lotteryName = "colorado_pick3day",
                       lotteryNameUI = "Pick 3",
                       state = new Pages.Colorado(),
                   },
                    new Lottery
                    {
                       url = "https://www.coloradolottery.com/en/",
                       lotteryName = "colorado_pick3eve",
                       lotteryNameUI = "Pick 3",
                       state = new Pages.Colorado(),
                   },
                }
            },
            new Connecticut
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_luckylinksday",
                        lotteryNameUI = "Lucky Links",
                        state = new Pages.Connecticut(),
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_luckylinkseve",
                        lotteryNameUI = "Lucky Links",
                        state = new Pages.Connecticut(),
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_lotto",
                        lotteryNameUI = "Lotto",
                        state = new Pages.Connecticut(),
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_cash5",
                        lotteryNameUI = "Lotto",
                        state = new Pages.Connecticut(),
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_play3day",
                        lotteryNameUI = "Play 3",
                        state = new Pages.Connecticut(),
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_play3eve",
                        lotteryNameUI = "Play 3",
                        state = new Pages.Connecticut(),
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_play4day",
                        lotteryNameUI = "Play 4",
                        state = new Pages.Connecticut(),
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_play4eve",
                        lotteryNameUI = "Play 4",
                        state = new Pages.Connecticut(),
                    },
                }
            },
            new Delaware
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "http://www.delottery.com/games/play3play4/",
                        lotteryName = "deleware_play3day",
                        lotteryNameUI = "Play 3",
                        state = new Pages.Delaware(),
                    },
                    new Lottery
                    {
                        url = "http://www.delottery.com/games/play3play4/",
                        lotteryName = "deleware_play3eve",
                        lotteryNameUI = "Play 3",
                        state = new Pages.Delaware(),
                    },
                    new Lottery
                    {
                        url = "http://www.delottery.com/games/play3play4/",
                        lotteryName = "deleware_play4day",
                        lotteryNameUI = "Play 4",
                        state = new Pages.Delaware(),
                    },
                    new Lottery
                    {
                        url = "http://www.delottery.com/games/play3play4/",
                        lotteryName = "deleware_play4eve",
                        lotteryNameUI = "Play 4",
                        state = new Pages.Delaware(),
                    },
                    new Lottery
                    {
                        url = "http://www.delottery.com/games/multiwin/",
                        lotteryName = "deleware_multiwin",
                        lotteryNameUI = "Multiwin",
                        state = new Pages.Delaware(),
                    },
                }
            },
            new DC
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_3day",
                        lotteryNameUI = "DC 3",
                        state = new Pages.DC(),
                    },
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_3eve",
                        lotteryNameUI = "DC 3",
                        state = new Pages.DC(),
                    },
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_4day",
                        lotteryNameUI = "DC 4",
                        state = new Pages.DC(),
                    },
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_4eve",
                        lotteryNameUI = "DC 4",
                        state = new Pages.DC(),
                    },
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_5day",
                        lotteryNameUI = "DC 5",
                        state = new Pages.DC(),
                    },
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_5eve",
                        lotteryNameUI = "DC 5",
                        state = new Pages.DC(),
                    },
                }
            },
            new Florida
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_lotto",
                        lotteryNameUI = "Lotto",
                        state = new Pages.Florida(),
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_luckymoney",
                        lotteryNameUI = "Lucky Money",
                        state = new Pages.Florida(),
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_fantasy5",
                        lotteryNameUI = "Fantasy 5",
                        state = new Pages.Florida(),
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_pick2day",
                        lotteryNameUI = "Pick 2",
                        state = new Pages.Florida(),
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_pick2eve",
                        lotteryNameUI = "Pick 2",
                        state = new Pages.Florida(),
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_pick3day",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Florida(),
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_pick3eve",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Florida(),
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_pick4day",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Florida(),
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_pick4eve",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Florida(),
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_pick5day",
                        lotteryNameUI = "Pick 5",
                        state = new Pages.Florida(),
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/",
                        lotteryName = "florida_pick5eve",
                        lotteryNameUI = "Pick 5",
                        state = new Pages.Florida(),
                    },
                }
            },
            new Idaho
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "https://www.idaholottery.com/games/draw/idahoCash/",
                        lotteryName = "idaho_cash",
                        lotteryNameUI = "Cash",
                        state = new Pages.Idaho(),
                    },
                    new Lottery
                    {
                        url = "https://www.idaholottery.com/games/draw/pick3/",
                        lotteryName = "idaho_pick3day",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Idaho(),
                    },
                    new Lottery
                    {
                        url = "https://www.idaholottery.com/games/draw/pick3/",
                        lotteryName = "idaho_pick3eve",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Idaho(),
                    },
                    new Lottery
                    {
                        url = "https://www.idaholottery.com/games/draw/weeklyGrand/",
                        lotteryName = "idaho_weeklygrand",
                        lotteryNameUI = "Weekly Grand",
                        state = new Pages.Idaho(),
                    },
                }
            },
            new Illinois
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_lotto",
                        lotteryNameUI = "Lotto",
                        state = new Pages.Illinois(),
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_luckydaylottoday",
                        lotteryNameUI = "Lucky Day Lotto",
                        state = new Pages.Illinois(),
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_luckydaylottoeve",
                        lotteryNameUI = "Lucky Day Lotto",
                        state = new Pages.Illinois(),
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_pick3day",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Illinois(),
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_pick3eve",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Illinois(),
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_pick4day",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Illinois(),
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_pick4eve",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Illinois(),
                    },
                }
            },
            new Iowa
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/AON.aspx",
                        lotteryName = "iowa_allornothingday",
                        lotteryNameUI = "All or Nothing",
                        state = new Pages.Iowa(),
                    },
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/AON.aspx",
                        lotteryName = "iowa_allornothingeve",
                        lotteryNameUI = "All or Nothing",
                        state = new Pages.Iowa(),
                    },
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/Pick3.aspx",
                        lotteryName = "iowa_pick3day",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Iowa(),
                    },
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/Pick3.aspx",
                        lotteryName = "iowa_pick3eve",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Iowa(),
                    },
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/Pick3.aspx",
                        lotteryName = "iowa_pick4day",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Iowa(),
                    },
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/Pick3.aspx",
                        lotteryName = "iowa_pick4eve",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Iowa(),
                    },
                }
            }
        };
    }
}
