using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autoclave.Pages
{
    public class State
    {
        public Main main;
        public List<Lottery> lotteries;
    }

    public interface IStateDecodable
    {
        string stateName { get; }
        string stateNameUI { get; }
        LotteryNumber GetLatestNumbers(Lottery lottery);
        DateTime GetLatestDate(Lottery lottery);
    }
}
