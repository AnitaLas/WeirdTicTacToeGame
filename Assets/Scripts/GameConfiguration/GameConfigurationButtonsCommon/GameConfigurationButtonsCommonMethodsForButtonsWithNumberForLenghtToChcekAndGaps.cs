using Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsCommonMethodsForButtonsWithNumberForLenghtToChcekAndGaps
    {
        /// <summary>
        /// rows number = numbers[0]
        /// columns number = numbers[1]
        /// </summary>
        /// <returns></returns>
        public static int[] GetCurrentRowsAndColumnsNumber()
        {
            string tagConfigurationBoardGameChangeNumberRows = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberRows();
            string tagConfigurationBoardGameChangeNumberColumns = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberColumns();
            int[] numbers = CreateTableWithNumberFromConfiguration(tagConfigurationBoardGameChangeNumberRows, tagConfigurationBoardGameChangeNumberColumns);
            return numbers;
        }

        public static int GetNumberFromConfiguration(string tagName)
        {
            GameObject objectNumber = GameCommonMethodsMain.GetObjectByTagName(tagName);
            string numberString = GameCommonMethodsMain.GetCubePlayText(objectNumber);
            int numberInt = GameCommonMethodsMain.ConvertStringToInt(numberString);
            return numberInt;
        }

        public static int GetLowerNumberBetweenRowsNumberAndColumnsNumber()
        {
            int[] numbers = GetCurrentRowsAndColumnsNumber();
            int numberRows = numbers[0];
            int numberColumns = numbers[1];
            int lowerNumber = GameCommonMethodsMain.GetLowerNumber(numberRows, numberColumns);
            return lowerNumber;
        }

        public static int[] CreateTableWithNumberFromConfiguration(string tagNameRows, string tagNameColumns)
        {
            string[] tagsName = { tagNameRows, tagNameColumns };
            int tagsNameLenght = tagsName.Length;

            string tagName;
            int[] numbers = new int[tagsNameLenght];

            for (int i = 0; i < tagsNameLenght; i++)
            {
                tagName = tagsName[i];
                int number = GetNumberFromConfiguration(tagName);
                numbers[i] = number;
            }

            return numbers;
        }
    }
}
