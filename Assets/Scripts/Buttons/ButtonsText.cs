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

        public static string[] CreateTableWithButtonNameForGameConfiguration(int numberOfRows, int numberOfColumns, string buttonText)
        {
            string[] table = new string[numberOfColumns];
            string emptyString = "";

            int textLenght = buttonText.Length;

            for (int i = 0; i < numberOfColumns; i++)
            {
                if (numberOfColumns > 1)
                {
                    if (i == 0)
                    {
                        table[i] = emptyString;
                        //table[i] = "x";
                    }
                    else if (i <= textLenght)
                    {
                        string symbol = buttonText.Substring(i - 1, 1);
                        table[i] = symbol;

                    }
                    else
                    {
                        table[i] = emptyString;
                        //table[i] = "o";
                    }
                } 
                else
                {
                    string symbol = buttonText.Substring(0, 1);
                    table[i] = symbol;
                }
            }

            return table;
        }

        public static string[] CreateTableWithButtonNameForGame(int numberOfRows, int numberOfColumns, string buttonText)
        {
            string[] table = new string[numberOfColumns];
            string emptyString = "";

            int stringHalfLength = numberOfColumns / 2;
            int textLenght = buttonText.Length;
            int textHalfLength = textLenght / 2;
            int differenceBetweenHalves;

            bool isButtonTextEven = CommonMethods.IsNumberEven(textLenght);

            if (isButtonTextEven == true)
            {
                differenceBetweenHalves = stringHalfLength - textHalfLength;
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
                    //differenceBetweenHalves = stringHalfLength - textHalfLength - 1 ;
                }

            }

            for (int i = 0; i < numberOfColumns; i++)
            {
                int indexText = i - differenceBetweenHalves;

                if (i < differenceBetweenHalves)
                {
                    table[i] = emptyString;
                }

                else if (i >= differenceBetweenHalves && indexText < textLenght)
                {
                    string symbol = buttonText.Substring(indexText, 1);
                    table[i] = symbol;
                }

                else
                {
                    table[i] = emptyString;
                }




            }

            return table;

        }

    }
}
