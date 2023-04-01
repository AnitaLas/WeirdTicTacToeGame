using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Buttons
{
    internal class ButtonsText 
    {

        /// <summary>
        /// currently, it works only for even column numbers e.g. 14
        /// </summary>
        /// <param name="stringLength1"></param>
        /// <param name="text1"></param>
        /// <returns></returns>
        public static string[] CreateTableWithGivenString(int stringLength, string buttonText)
        {
            Debug.Log(" 1 ");

            string[] table = new string[stringLength];

            string emptyString = "";

            int stringHalfLength = stringLength / 2;

            int textLenght = buttonText.Length;
            int textHalfLength = textLenght / 2;

            bool isButtonTextEven = CommonMethods.IsNumberEven(textLenght);

            int differenceBetweenHalves; // = stringHalfLength - textHalfLength; ;

            if (isButtonTextEven == true)
            {
                differenceBetweenHalves = stringHalfLength - textHalfLength ; 
            }
            else
            {
                differenceBetweenHalves = stringHalfLength - textHalfLength - 1; 
            }

            //Debug.Log($"differenceBetweenHalves = " + differenceBetweenHalves);

            for (int i = 0; i < stringLength; i++)
            {
                int indexText = i - differenceBetweenHalves;

                if (i < differenceBetweenHalves)
                {
                    table[i] = emptyString;
                    //Debug.Log($"table[{i}] = " + table[i]);
                }

                else if (i >= differenceBetweenHalves && indexText < textLenght)
                {
                    string symbol = buttonText.Substring(indexText, 1);
                    //Debug.Log($"symbol = " + symbol);
                    table[i] = symbol;
                }

                else 
                {
                    table[i] = emptyString;
                }


            }


            //for (int i = 0; i < stringLength; i++)
            //{
            //    Debug.Log($"table[{i}]" + table[i]);
            //}




            return table;
        }


    }
}
