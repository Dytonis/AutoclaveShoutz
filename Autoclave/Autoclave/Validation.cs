using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoclave
{
    public static class Validation
    {
        public static LotteryNumber CheckValidation(LotteryNumber number)
        {
            bool valid = true;

            if (number.lottery.Action == LotteryDecodeAction.Skip)
            {
                number.ADI = AfterDecodeInformation.NotDrawnOrUnavailable;
                return number;
            }

            if (number.numbers.Length != number.lottery.NumbersCount)
            {
                number.ADI = AfterDecodeInformation.Invalid;
                valid = false;
            }
            if (number.numbers[0].Length > number.lottery.UnitLength)
            {
                number.ADI = AfterDecodeInformation.Invalid;
                valid = false;
            }
            if (number.specials != null)
            {
                if (number.specials.Length != number.lottery.SpecialsCount)
                {
                    number.ADI = AfterDecodeInformation.Invalid;
                    valid = false;
                }
                if (number.specials[0].Length > number.lottery.SpecialUnitLength)
                {
                    number.ADI = AfterDecodeInformation.Invalid;
                    valid = false;
                }
            }
            if ((String.IsNullOrWhiteSpace(number.multiplier) && number.lottery.hasMultiplier))
            {
                number.ADI = AfterDecodeInformation.Invalid;
                valid = false;
            }

            if (valid)
                number.ADI = AfterDecodeInformation.Valid;

            return number;
        }
    }
}

