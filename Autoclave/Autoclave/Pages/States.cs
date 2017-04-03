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
        };
    }
}
