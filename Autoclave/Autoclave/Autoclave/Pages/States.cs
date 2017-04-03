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
            }
        };
    }
}
