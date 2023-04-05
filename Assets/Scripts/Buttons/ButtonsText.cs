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
        /// <returns></returns>
        public static string[] CreateTableWithGivenString(int numberOfRows, int numberOfColumns, string buttonText)
        {
            //Debug.Log(" 1 ");

            string[] table = new string[numberOfColumns];

            string emptyString = "";

            int stringHalfLength = numberOfColumns / 2;

            //int textLenght = buttonText.Length;

            int textLenght = buttonText.Length;

            //float textLenghtFloat = CommonMethods.ConvertIntToFloat(textLenght);
            Debug.Log(" textLenght = " + textLenght);

            int textHalfLength = textLenght / 2;
            //float textHalfLength = textLenghtFloat / 2;



            Debug.Log(" textHalfLength = " + textHalfLength);

            int differenceBetweenHalves;
            //float differenceBetweenHalves;


            bool isButtonTextEven = CommonMethods.IsNumberEven(textLenght);

            

            if (isButtonTextEven == true)
            {
                differenceBetweenHalves = stringHalfLength - textHalfLength ; 
            }
            else
            {
                if (numberOfRows > 3)
                {
                    differenceBetweenHalves = stringHalfLength - textHalfLength - 1;
                }
                else
                {
                    differenceBetweenHalves = stringHalfLength - textHalfLength;
                }
                
            }

            //Debug.Log($"differenceBetweenHalves = " + differenceBetweenHalves);

            for (int i = 0; i < numberOfColumns; i++)
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
