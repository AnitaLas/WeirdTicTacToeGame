using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class CommonMethods
    {

        public static float ConvertDoubleToFloat(double number)
        {
            string doubleToString = number.ToString();
            float doubleToFloat = float.Parse(doubleToString);
            return doubleToFloat;
        }

        public static float ConvertIntToFloat(float number)
        {
            string intToString = number.ToString();
            float intToFloat = int.Parse(intToString);
            return intToFloat;
        }

        public static float RoundAndConvertDoubleToFloat(double number, int round)
        {
            double roundedNumber = Math.Round(number, round);
            float doubleToFloat = ConvertDoubleToFloat(roundedNumber);
            return doubleToFloat;
        }

        public static double RoundDownWithDecimal(double number, int numberAfterDecimal)
        {
            double newNumber = number * 10;
            double newNumberRounded = Math.Floor(newNumber);
            double resul = newNumberRounded / Math.Pow(10, numberAfterDecimal);
            return resul;
        }

    }
}
