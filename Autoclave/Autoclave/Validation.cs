using System;
using System.Collections.Generic;
using System.IO;
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

            if (number.numbers != null)
            {

                if (number.numbers.Length != number.lottery.NumbersCount)
                {
                    number.ADI = AfterDecodeInformation.Invalid;
                    valid = false;
                }
                if (number.numbers.Length > 0 && number.lottery.UnitLength > 0)
                {
                    if (number.numbers[0].Length > number.lottery.UnitLength)
                    {
                        number.ADI = AfterDecodeInformation.Invalid;
                        valid = false;
                    }
                }
                else if (number.numbers.Length == 0 && number.lottery.UnitLength > 0)
                {
                    number.ADI = AfterDecodeInformation.Invalid;
                    valid = false;
                }
            }
            if (number.specials != null)
            {
                if (number.specials.Length != number.lottery.SpecialsCount)
                {
                    number.ADI = AfterDecodeInformation.Invalid;
                    valid = false;
                }
                if (number.specials.Length > 0 && number.lottery.SpecialUnitLength > 0)
                {
                    if (number.specials[0].Length > number.lottery.SpecialUnitLength)
                    {
                        number.ADI = AfterDecodeInformation.Invalid;
                        valid = false;
                    }
                }
                else if (number.specials.Length == 0 && number.lottery.SpecialUnitLength > 0)
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
            {
                number.ADI = AfterDecodeInformation.Valid;

                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string specificpath = path + "\\Autoclave\\Log\\NumberSave.log";

                int totalNumbers = 0;
                int readNumbers = 0;

                if (number.lottery.SpecialsCount > 0 || number.lottery.NumbersCount > 0)
                {

                    if (Directory.Exists(path + "\\Autoclave\\Log\\"))
                    {
                        if (File.Exists(specificpath))
                        {
                            try
                            {
                                readNumbers = Convert.ToInt32(File.ReadAllText(specificpath));
                            }
                            catch
                            {
                                readNumbers = 0;
                            }
                        }
                    }

                    totalNumbers = readNumbers + number.lottery.NumbersCount + number.lottery.SpecialsCount;

                    File.WriteAllText(specificpath, totalNumbers.ToString());
                }
            }
            return number;
        }
    }
}

