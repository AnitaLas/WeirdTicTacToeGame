using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsWithNumbersForTime
    {

        public static GameObject[,,] CreateTableWithTime(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTimeForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
            tableWithNumber = CreateTableMainMethodsForButtons.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);

            return tableWithNumber;
        }

        public static int[] CreateTableWithSeconds()
        {
            int numberOfCubePlay = 4 * 4; // number: rows & columns
            //int maxSecondsNumber = 60;
            int[] table = new int[numberOfCubePlay];
            table[0] = 0;
            int increaseNumber = 5;

            for (int i = 1; i < numberOfCubePlay; i++)
            {
                int previousValue = i - 1;
                table[i] = table[previousValue] + increaseNumber;
            }

            return table;
        }

        public static string[] CreateTableWithSecondsForCubePlay()
        {
            int[] tableInt = CreateTableWithSeconds();
            int tableStringLenght = tableInt.Length;
            string[] tableString = new string[tableStringLenght];

            for (int i = 0; i < tableStringLenght; i++)
            {
                int number = tableInt[i];
                string numberString = CommonMethods.ConverIntToString(number);
                tableString[i] = numberString;
            }

            return tableString;
        }

        public static string[,,] CreateTableForDefaultTextWithNumbers(string[] table, int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];
            int[] index = new int[1];
            index[0] = 0;
            int currentIndex;

            for (int indexDepth = 0; indexDepth < numberOfDepths; indexDepth++)
            {
                for (int indexRow = numberOfRows - 1; indexRow >= 0; indexRow--)
                {
                    for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                    {
                        currentIndex = index[0];
                        string stringNumber = table[currentIndex];

                        newTable[indexDepth, indexRow, indexColumn] = stringNumber;
                        index[0] = index[0] + 1;
                    }
                }

                index[0] = 0;
            }

            return newTable;
        }

        public static string[,,] CreateTableWithTimeForPrefabCubePlay(int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];

            string[] numbers = CreateTableWithSecondsForCubePlay();

            string[,,] numbers3D = CreateTableForDefaultTextWithNumbers(numbers, numberOfDepths, numberOfRows, numberOfColumns);

            for (int indexDepth = 0; indexDepth < numberOfDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < numberOfRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                    {
                        string stringNumber = numbers3D[indexDepth, indexRow, indexColumn];                      
                        newTable[indexDepth, indexRow, indexColumn] = stringNumber;
                    }
                }
            }

            return newTable;
        }

        public static GameObject[,,] ChangeDataForTableWithTime(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagConfigurationBoardGameTableNumberForAll);
                    }
                }
            }

            return tableWtithNumber;
        }
    }
}
