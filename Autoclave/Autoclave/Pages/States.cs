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
                       NumbersCount = 6,
                       UnitLength = 2,
                       lottery_id = 188,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_luckyforlife",
                       Action = LotteryDecodeAction.Skip,
                       lotteryNameUI = "Lucky For Life",
                       state = new Pages.Maine(),
                       lottery_id = 0,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_hotlottosizzler",
                       lotteryNameUI = "Hot Lotto Sizzler",
                       state = new Pages.Maine(),
                       lottery_id = 0,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_pick3day",
                       lotteryNameUI = "Pick 3",
                       state = new Pages.Maine(),
                       NumbersCount = 3,
                       UnitLength = 1,
                       lottery_id = 191,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_pick3eve",
                       lotteryNameUI = "Pick 3",
                       state = new Pages.Maine(),
                       NumbersCount = 3,
                       UnitLength = 1,
                       lottery_id = 192,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_pick4day",
                       lotteryNameUI = "Pick 4",
                       state = new Pages.Maine(),
                       NumbersCount = 4,
                       UnitLength = 1,
                       lottery_id = 193,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_pick4eve",
                       lotteryNameUI = "Pick 4",
                       state = new Pages.Maine(),
                       NumbersCount = 4,
                       UnitLength = 1,
                       lottery_id = 194,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_gimme5",
                       lotteryNameUI = "Gimme 5",
                       state = new Pages.Maine(),
                       NumbersCount = 5,
                       UnitLength = 2,
                       lottery_id = 190,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.mainelottery.com/",
                       lotteryName = "maine_wptallin",
                       lotteryNameUI = "WPT All In",
                       state = new Pages.Maine(),
                       Action = LotteryDecodeAction.DateTrigger,
                       lottery_id = 0,
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
                        NumbersCount = 6,
                        UnitLength = 2,
                        lottery_id = 43,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_fantasy5",
                        lotteryNameUI = "Fantasy 5",
                        state = new Pages.Arizona(),
                        NumbersCount = 5,
                        UnitLength = 2,
                        lottery_id = 44,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_pick3",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Arizona(),
                        NumbersCount = 3,
                        UnitLength = 1,
                        lottery_id = 47,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_5cardcash",
                        lotteryNameUI = "5 Card Cash",
                        state = new Pages.Arizona(),
                        Action = LotteryDecodeAction.DateTrigger,
                        lottery_id = 311
                    },
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_allornothingday",
                        lotteryNameUI = "All or Nothing",
                        state = new Pages.Arizona(),
                        NumbersCount = 10,
                        UnitLength = 2,
                        lottery_id = 264,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.arizonalottery.com/",
                        lotteryName = "arizona_allornothingeve",
                        lotteryNameUI = "All or Nothing",
                        state = new Pages.Arizona(),
                        NumbersCount = 10,
                        UnitLength = 2,
                        lottery_id = 265,
                        Submit = FullAutoAction.SubmitFull
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
                       NumbersCount = 5,
                       UnitLength = 2,
                       lottery_id = 52,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_luckyforlife",
                       Action = LotteryDecodeAction.Skip,
                       lotteryNameUI = "Lucky For Life",
                       state = new Pages.Arkansas(),
                       lottery_id = 0,
                   },
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_cash3day",
                       lotteryNameUI = "Cash 3",
                       state = new Pages.Arkansas(),
                       NumbersCount = 3,
                       UnitLength = 2,
                       lottery_id = 48,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_cash3eve",
                       lotteryNameUI = "Cash 3",
                       state = new Pages.Arkansas(),
                       NumbersCount = 3,
                       UnitLength = 2,
                       lottery_id = 49,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_cash4day",
                       lotteryNameUI = "Cash 4",
                       state = new Pages.Arkansas(),
                       NumbersCount = 4,
                       UnitLength = 2,
                       lottery_id = 50,
                       Submit = FullAutoAction.SubmitFull
                   },
                   new Lottery
                   {
                       url = "http://www.myarkansaslottery.com/",
                       lotteryName = "arkansas_cash4eve",
                       lotteryNameUI = "Cash 4",
                       state = new Pages.Arkansas(),
                       NumbersCount = 4,
                       UnitLength = 2,
                       lottery_id = 51,
                       Submit = FullAutoAction.SubmitFull
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
                       NumbersCount = 6,
                       UnitLength = 2,
                       SpecialsCount = 1,
                       SpecialUnitLength = 2,
                       lottery_id = 54,
                       Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                       url = "http://www.calottery.com/play/draw-games/fantasy-5/",
                       lotteryName = "california_fantasy5",
                       lotteryNameUI = "Fantasy 5",
                       state = new Pages.California(),
                       NumbersCount = 5,
                       UnitLength = 2,
                       lottery_id = 55,
                       Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                       url = "http://www.calottery.com/play/draw-games/daily-3/",
                       lotteryName = "california_daily3day",
                       lotteryNameUI = "Daily 3",
                       state = new Pages.California(),
                       NumbersCount = 3,
                       UnitLength = 1,
                       lottery_id = 57,
                       Action = LotteryDecodeAction.Skip
                    },
                    new Lottery
                    {
                       url = "http://www.calottery.com/play/draw-games/daily-3/",
                       lotteryName = "california_daily3eve",
                       lotteryNameUI = "Daily 3",
                       state = new Pages.California(),
                       NumbersCount = 3,
                       UnitLength = 1,
                       lottery_id = 58,
                       Action = LotteryDecodeAction.Skip
                    },
                    new Lottery
                    {
                       url = "http://www.calottery.com/play/draw-games/daily-4/",
                       lotteryName = "california_daily4",
                       lotteryNameUI = "Daily 4",
                       state = new Pages.California(),
                       NumbersCount = 4,
                       UnitLength = 1,
                       lottery_id = 56,
                       Submit = FullAutoAction.SubmitFull
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
                       lottery_id = 0,
                   },
                    new Lottery
                    {
                       url = "https://www.coloradolottery.com/en/",
                       lotteryName = "colorado_lotto",
                       lotteryNameUI = "Lotto",
                       state = new Pages.Colorado(),
                       NumbersCount = 6,
                       UnitLength = 2,
                       lottery_id = 2,
                       Submit = FullAutoAction.SubmitFull
                   },
                    new Lottery
                    {
                       url = "https://www.coloradolottery.com/en/",
                       lotteryName = "colorado_cash5",
                       lotteryNameUI = "Cash 5",
                       state = new Pages.Colorado(),
                       NumbersCount = 5,
                       UnitLength = 2,
                       lottery_id = 3,
                       Submit = FullAutoAction.SubmitFull
                   },
                    new Lottery
                    {
                       url = "https://www.coloradolottery.com/en/",
                       lotteryName = "colorado_pick3day",
                       lotteryNameUI = "Pick 3",
                       state = new Pages.Colorado(),
                       Action = LotteryDecodeAction.Skip,
                       NumbersCount = 3,
                       UnitLength = 1,
                       lottery_id = 0
                   },
                    new Lottery
                    {
                       url = "https://www.coloradolottery.com/en/",
                       lotteryName = "colorado_pick3eve",
                       lotteryNameUI = "Pick 3",
                       state = new Pages.Colorado(),
                       Action = LotteryDecodeAction.Skip,
                       NumbersCount = 3,
                       UnitLength = 1,
                       lottery_id = 0
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
                        NumbersCount = 8,
                       UnitLength = 2,
                        lottery_id = 306,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_luckylinkseve",
                        lotteryNameUI = "Lucky Links",
                        state = new Pages.Connecticut(),
                        NumbersCount = 8,
                       UnitLength = 2,
                        lottery_id = 307,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_lotto",
                        lotteryNameUI = "Lotto",
                        state = new Pages.Connecticut(),
                        lottery_id = 121
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_cash5",
                        lotteryNameUI = "Cash 5",
                        state = new Pages.Connecticut(),
                        NumbersCount = 5,
                       UnitLength = 2,
                        lottery_id = 122
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_play3day",
                        lotteryNameUI = "Play 3",
                        state = new Pages.Connecticut(),
                        NumbersCount = 3,
                       UnitLength = 1,
                        lottery_id = 124,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_play3eve",
                        lotteryNameUI = "Play 3",
                        state = new Pages.Connecticut(),
                        NumbersCount = 3,
                       UnitLength = 1,
                        lottery_id = 125,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_play4day",
                        lotteryNameUI = "Play 4",
                        state = new Pages.Connecticut(),
                        NumbersCount = 4,
                       UnitLength = 1,
                        lottery_id = 126,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.ctlottery.org/",
                        lotteryName = "connecticut_play4eve",
                        lotteryNameUI = "Play 4",
                        state = new Pages.Connecticut(),
                        NumbersCount = 4,
                       UnitLength = 1,
                        lottery_id = 127,
                        Submit = FullAutoAction.SubmitFull
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
                        NumbersCount = 3,
                       UnitLength = 1,
                        lottery_id = 130,
                        Submit = FullAutoAction.SubmitFull,
                     
                    },
                    new Lottery
                    {
                        url = "http://www.delottery.com/games/play3play4/",
                        lotteryName = "deleware_play3eve",
                        lotteryNameUI = "Play 3",
                        state = new Pages.Delaware(),
                        NumbersCount = 3,
                       UnitLength = 1,
                        lottery_id = 131,
                        Submit = FullAutoAction.SubmitFull,
                    },
                    new Lottery
                    {
                        url = "http://www.delottery.com/games/play3play4/",
                        lotteryName = "deleware_play4day",
                        lotteryNameUI = "Play 4",
                        state = new Pages.Delaware(),
                        NumbersCount = 4,
                       UnitLength = 1,
                        lottery_id = 132,
                        Submit = FullAutoAction.SubmitFull,
                    },
                    new Lottery
                    {
                        url = "http://www.delottery.com/games/play3play4/",
                        lotteryName = "deleware_play4eve",
                        lotteryNameUI = "Play 4",
                        state = new Pages.Delaware(),
                        NumbersCount = 4,
                       UnitLength = 1,
                        lottery_id = 133,
                        Submit = FullAutoAction.SubmitFull,
                    },
                    new Lottery
                    {
                        url = "http://www.delottery.com/games/multiwin/",
                        lotteryName = "deleware_multiwin",
                        lotteryNameUI = "Multiwin",
                        state = new Pages.Delaware(),
                        NumbersCount = 6,
                       UnitLength = 2,
                        lottery_id = 128,
                        Submit = FullAutoAction.SubmitFull,
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
                        NumbersCount = 3,
                       UnitLength = 1,
                        lottery_id = 70,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_3eve",
                        lotteryNameUI = "DC 3",
                        state = new Pages.DC(),
                        NumbersCount = 3,
                       UnitLength = 1,
                        lottery_id = 71,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_4day",
                        lotteryNameUI = "DC 4",
                        state = new Pages.DC(),
                        NumbersCount = 4,
                       UnitLength = 1,
                        lottery_id = 72,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_4eve",
                        lotteryNameUI = "DC 4",
                        state = new Pages.DC(),
                        NumbersCount = 4,
                       UnitLength = 1,
                        lottery_id = 73,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_5day",
                        lotteryNameUI = "DC 5",
                        state = new Pages.DC(),
                        NumbersCount = 5,
                       UnitLength = 1,
                        lottery_id = 74,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://dclottery.com/games/dc3/default.aspx/",
                        lotteryName = "dc_5eve",
                        lotteryNameUI = "DC 5",
                        state = new Pages.DC(),
                        NumbersCount = 5,
                       UnitLength = 1,
                        lottery_id = 75,
                        Submit = FullAutoAction.SubmitFull
                    },
                }
            },
            new Florida
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_lotto",
                        lotteryNameUI = "Lotto",
                        state = new Pages.Florida(),
                        NumbersCount = 6,
                       UnitLength = 2,
                       hasMultiplier = true,
                        lottery_id = 5,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_luckymoney",
                        lotteryNameUI = "Lucky Money",
                        state = new Pages.Florida(),
                        NumbersCount = 4,
                        UnitLength = 2, 
                       SpecialsCount = 1,
                       SpecialUnitLength = 2,
                        lottery_id = 271,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_fantasy5",
                        lotteryNameUI = "Fantasy 5",
                        state = new Pages.Florida(),
                        NumbersCount = 5,
                        UnitLength = 2,
                        lottery_id = 7,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_pick2day",
                        lotteryNameUI = "Pick 2",
                        state = new Pages.Florida(),
                        NumbersCount = 2,
                        UnitLength = 1,
                        lottery_id = 317,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_pick2eve",
                        lotteryNameUI = "Pick 2",
                        state = new Pages.Florida(),
                        NumbersCount = 2,
                        UnitLength = 1,
                        lottery_id = 319,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_pick3day",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Florida(),
                        NumbersCount = 3,
                        UnitLength = 1,
                        lottery_id = 10,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_pick3eve",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Florida(),
                        NumbersCount = 3,
                        UnitLength = 1,
                        lottery_id = 11,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_pick4day",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Florida(),
                        NumbersCount = 4,
                        UnitLength = 1,
                        lottery_id = 8,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_pick4eve",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Florida(),
                        NumbersCount = 4,
                        UnitLength = 1,
                        lottery_id = 9,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_pick5day",
                        lotteryNameUI = "Pick 5",
                        state = new Pages.Florida(),
                        NumbersCount = 5,
                        UnitLength = 1,
                        lottery_id = 318,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.flalottery.com/winningNumbers",
                        lotteryName = "florida_pick5eve",
                        lotteryNameUI = "Pick 5",
                        state = new Pages.Florida(),
                        NumbersCount = 5,
                        UnitLength = 1,
                        lottery_id = 320,
                        Submit = FullAutoAction.SubmitFull
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
                        Action = LotteryDecodeAction.Skip,
                        NumbersCount = 5,
                        UnitLength = 2,
                        lottery_id = 0
                    },
                    new Lottery
                    {
                        url = "https://www.idaholottery.com/games/draw/pick3/",
                        lotteryName = "idaho_pick3day",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Idaho(),
                        NumbersCount = 3,
                        UnitLength = 1,
                        SpecialsCount = 1,
                        SpecialUnitLength = 2,
                        lottery_id = 144
                    },
                    new Lottery
                    {
                        url = "https://www.idaholottery.com/games/draw/pick3/",
                        lotteryName = "idaho_pick3eve",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Idaho(),
                        NumbersCount = 5,
                        UnitLength = 2,
                        SpecialUnitLength = 2,
                        SpecialsCount = 1,
                        lottery_id = 145
                    },
                    new Lottery
                    {
                        url = "https://www.idaholottery.com/games/draw/weeklyGrand/",
                        lotteryName = "idaho_weeklygrand",
                        lotteryNameUI = "Weekly Grand",
                        state = new Pages.Idaho(),
                        NumbersCount = 5,
                        UnitLength = 2,
                        lottery_id = 143,
                        Submit = FullAutoAction.SubmitFull
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
                        NumbersCount = 6,
                        UnitLength = 2,
                        SpecialsCount = 1,
                        SpecialUnitLength = 2,
                        lottery_id = 146,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_luckydaylottoday",
                        lotteryNameUI = "Lucky Day Lotto",
                        state = new Pages.Illinois(),
                        NumbersCount = 5,
                        UnitLength = 2,
                        lottery_id = 147,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_luckydaylottoeve",
                        lotteryNameUI = "Lucky Day Lotto",
                        state = new Pages.Illinois(),
                        NumbersCount = 5,
                        UnitLength = 2,
                        lottery_id = 154,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_pick3day",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Illinois(),
                        NumbersCount = 3,
                        UnitLength = 1,
                        lottery_id = 150,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_pick3eve",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Illinois(),
                        NumbersCount = 3,
                        UnitLength = 1,
                        lottery_id = 151,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_pick4day",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Illinois(),
                        NumbersCount = 4,
                        UnitLength = 1,
                        lottery_id = 152,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.illinoislottery.com/en-us/home.html",
                        lotteryName = "illinois_pick4eve",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Illinois(),
                        NumbersCount = 4,
                        UnitLength = 1,
                        lottery_id = 153,
                        Submit = FullAutoAction.SubmitFull
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
                        NumbersCount = 12,
                        UnitLength = 2,
                        lottery_id = 257,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/AON.aspx",
                        lotteryName = "iowa_allornothingeve",
                        lotteryNameUI = "All or Nothing",
                        state = new Pages.Iowa(),
                        NumbersCount = 12,
                        UnitLength = 2,
                        lottery_id = 258,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/Pick3.aspx",
                        lotteryName = "iowa_pick3day",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Iowa(),
                        NumbersCount = 3,
                        UnitLength = 1,
                        lottery_id = 16,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/Pick3.aspx",
                        lotteryName = "iowa_pick3eve",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Iowa(),
                        NumbersCount = 3,
                        UnitLength = 1,
                        lottery_id = 17,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/Pick3.aspx",
                        lotteryName = "iowa_pick4day",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Iowa(),
                        NumbersCount = 4,
                        UnitLength = 1,
                        lottery_id = 14,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.ialottery.com/Pages/Games-Online/Pick3.aspx",
                        lotteryName = "iowa_pick4eve",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Iowa(),
                        NumbersCount = 4,
                        UnitLength = 1,
                        lottery_id = 15,
                        Submit = FullAutoAction.SubmitFull
                    },
                }
            },
            new Kansas
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "https://www.kslottery.com/",
                        lotteryName = "kansas_cash",
                        lotteryNameUI = "Super Cash",
                        state = new Pages.Kansas(),
                        NumbersCount = 5,
                        UnitLength = 2,
                        SpecialUnitLength = 2,
                        SpecialsCount = 1,
                        lottery_id = 29,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.kslottery.com/",
                        lotteryName = "kansas_2by2",
                        lotteryNameUI = "2 by 2",
                        state = new Pages.Kansas(),
                        NumbersCount = 4,
                        UnitLength = 2,
                        lottery_id = 30,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://www.kslottery.com/",
                        lotteryName = "kansas_pick3day",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Kansas(),
                        NumbersCount = 3,
                        UnitLength = 1,
                        lottery_id = 312
                    },
                    new Lottery
                    {
                        url = "https://www.kslottery.com/",
                        lotteryName = "kansas_pick3eve",
                        lotteryNameUI = "Pick 3",
                        NumbersCount = 3,
                        UnitLength = 1,
                        state = new Pages.Kansas(),
                        lottery_id = 31
                    },
                }
            },
            new Louisiana
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "http://louisianalottery.com/lotto",
                        lotteryName = "louisiana_lotto",
                        lotteryNameUI = "Lotto",
                        state = new Pages.Louisiana(),
                        UnitLength = 2,
                        NumbersCount = 6,
                        lottery_id = 87,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://louisianalottery.com/easy-5",
                        lotteryName = "louisiana_easy5",
                        lotteryNameUI = "Easy 5",
                        state = new Pages.Louisiana(),
                        UnitLength = 2,
                        NumbersCount = 5,
                        lottery_id = 86,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://louisianalottery.com/pick-4",
                        lotteryName = "louisiana_pick4",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.Louisiana(),
                        UnitLength = 1,
                        NumbersCount = 4,
                        lottery_id = 85,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://louisianalottery.com/pick-3",
                        lotteryName = "louisiana_pick3",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Louisiana(),
                        UnitLength = 1,
                        NumbersCount = 3,
                        lottery_id = 84,
                        Submit = FullAutoAction.SubmitFull
                    },
                }
            },
            new NorthCarolina
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "http://www.nc-educationlottery.org/games.aspx",
                        lotteryName = "northcarolina_pick3day",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.NorthCarolina(),
                        UnitLength = 1,
                        NumbersCount = 3,
                        lottery_id = 97,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.nc-educationlottery.org/games.aspx",
                        lotteryName = "northcarolina_pick3eve",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.NorthCarolina(),
                        UnitLength = 1,
                        NumbersCount = 3,
                        lottery_id = 98,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.nc-educationlottery.org/games.aspx",
                        lotteryName = "northcarolina_pick4day",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.NorthCarolina(),
                        UnitLength = 1,
                        NumbersCount = 4,
                        lottery_id = 99,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.nc-educationlottery.org/games.aspx",
                        lotteryName = "northcarolina_pick4eve",
                        lotteryNameUI = "Pick 4",
                        state = new Pages.NorthCarolina(),
                        UnitLength = 1,
                        NumbersCount = 4,
                        lottery_id = 100,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.nc-educationlottery.org/games.aspx",
                        lotteryName = "northcarolina_cash5",
                        lotteryNameUI = "Cash 5",
                        state = new Pages.NorthCarolina(),
                        UnitLength = 2,
                        NumbersCount = 5,
                        lottery_id = 101,
                        Submit = FullAutoAction.SubmitFull
                    },
                }
            },
            new Nebraska
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "https://nelottery.com/homeapp/landing",
                        lotteryName = "nebraska_pick5",
                        lotteryNameUI = "Pick 5",
                        state = new Pages.Nebraska(),
                        UnitLength = 2,
                        NumbersCount = 5,
                        lottery_id = 24,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://nelottery.com/homeapp/landing",
                        lotteryName = "nebraska_pick3",
                        lotteryNameUI = "Pick 3",
                        state = new Pages.Nebraska(),
                        UnitLength = 2,
                        NumbersCount = 3,
                        lottery_id = 25,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://nelottery.com/homeapp/landing",
                        lotteryName = "nebraska_myday",
                        lotteryNameUI = "My Day",
                        state = new Pages.Nebraska(),
                        UnitLength = 2,
                        NumbersCount = 3,
                        lottery_id = 26,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "https://nelottery.com/homeapp/landing",
                        lotteryName = "nebraska_2by2",
                        lotteryNameUI = "2 by 2",
                        state = new Pages.Nebraska(),
                        UnitLength = 2,
                        NumbersCount = 4,
                        lottery_id = 27,
                        Submit = FullAutoAction.SubmitFull
                    },
                }
            },
            new Washington
            {
                lotteries = new List<Lottery>()
                {
                    new Lottery
                    {
                        url = "http://www.walottery.com/WinningNumbers/Default.aspx",
                        lotteryName = "washington_lotto",
                        lotteryNameUI = "Lotto",
                        state = new Pages.Washington(),
                        UnitLength = 2,
                        NumbersCount = 6,
                        lottery_id = 176,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.walottery.com/WinningNumbers/Default.aspx",
                        lotteryName = "washington_hit5",
                        lotteryNameUI = "Hit 5",
                        state = new Pages.Washington(),
                        UnitLength = 2,
                        NumbersCount = 5,
                        lottery_id = 177,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.walottery.com/WinningNumbers/Default.aspx",
                        lotteryName = "washington_match4",
                        lotteryNameUI = "Match 4",
                        state = new Pages.Washington(),
                        UnitLength = 2,
                        NumbersCount = 4,
                        lottery_id = 178,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.walottery.com/WinningNumbers/Default.aspx",
                        lotteryName = "washington_dailygame",
                        lotteryNameUI = "Daily Game",
                        state = new Pages.Washington(),
                        UnitLength = 1,
                        NumbersCount = 3,
                        lottery_id = 179,
                        Submit = FullAutoAction.SubmitFull
                    },
                    new Lottery
                    {
                        url = "http://www.walottery.com/WinningNumbers/Default.aspx",
                        lotteryName = "washington_keno",
                        lotteryNameUI = "Keno",
                        state = new Pages.Washington(),
                        UnitLength = 2,
                        NumbersCount = 20,
                        lottery_id = 180,
                        Submit = FullAutoAction.SubmitFull
                    },
                }
            }
        };
    }
}
