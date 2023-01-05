using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.XR;


namespace Assets.Scripts
{
    internal class CommonMethods
    {

        // double 14/15 digits after coma
        // float 6/7 digits after coma

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

        public static string ConverIntToString(int number)
        {
            string intToString = number.ToString();
            return intToString;
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

        // even number - 2 4 6 
        // odd number - 3 5 7 444

        public static bool IsNumberEven(int number)
        {
            bool isNumberEven;

            if (number %2 == 0) 
            {
                isNumberEven = true;
                return isNumberEven;
            }
            else
            {
                isNumberEven = false;
                return isNumberEven;
            }
        }

    }
}
