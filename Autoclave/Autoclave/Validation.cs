using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoclave
{
    class Validation
    {
        public void CheckValidation(List<LotteryNumber> numbers)
        {
            bool valid = true;
            for(int i = 0; i < numbers.Count; i++)
            {
                LotteryNumber n = numbers[i];

                if(n.lottery.Action == LotteryDecodeAction.Skip)
                {
                    n.ADI = AfterDecodeInformation.NotDrawnOrUnavailable;
                    continue;
                }

                if (n.numbers.Length != n.lottery.NumbersCount)
                {
                    n.ADI = AfterDecodeInformation.Invalid;
                    valid = false;
                }
                if (n.numbers[0].Length != n.lottery.UnitLength)
                {
                    n.ADI = AfterDecodeInformation.Invalid;
                    valid = false;
                }
                if (n.specials.Length != n.lottery.SpecialsCount)
                {
                    n.ADI = AfterDecodeInformation.Invalid;
                    valid = false;
                }
                if (n.specials[0].Length != n.lottery.SpecialUnitLength)
                {
                    n.ADI = AfterDecodeInformation.Invalid;
                    valid = false;
                }
                if ((String.IsNullOrWhiteSpace(n.multiplier) && n.lottery.hasMultiplier))
                {
                    n.ADI = AfterDecodeInformation.Invalid;
                    valid = false;
                }

                if (valid)
                    n.ADI = AfterDecodeInformation.Valid;
            }
        }
    }
}
