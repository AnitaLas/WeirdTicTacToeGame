using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsWithNumbersForTeamMembers
    {


        public static GameObject[,,] CreateTableWithTeamMembersSymbols(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTimeForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
            tableWithNumber = CreateTableMainMethodsForButtons.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);

            return tableWithNumber;
        }

        // to fix it!!!
        public static int[] CreateTableWithNumbers()
        {
            int maxTeamNumber = 6;
            int minTeamNumber = 2;
            int[] table = new int[maxTeamNumber];

            int index = 0;

            for (int i = minTeamNumber; i <= maxTeamNumber; i++)
            {
                table[index] = i;
                index++;
            }

            for (int i = (maxTeamNumber + 1); i < table.Length; i++)
            {
                table[i] = 0;
            }

            return table;
        }

        public static string[] CreateTableWithNumbersForCubePlay()
        {
            int[] tableInt = CreateTableWithNumbers();
            int tableStringLenght = tableInt.Length;
            string[] tableString = new string[tableStringLenght];

            for (int i = 0; i < tableStringLenght; i++)
            {
                int number = tableInt[i];
                string numberString = CommonMethods.ConverIntToString(number);
                tableString[i] = numberString;
            }

            //Debug.Log(" -------- 2222 ------------- ");
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

            string[] numbers = CreateTableWithNumbersForCubePlay();

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

        public static GameObject[,,] ChangeDataForTableWithTeamNumbers(GameObject[,,] tableWtithNumber)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);

            string tagInactiveField = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersInactiveField();
            string tagTableWithNumbers = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersTableWithNumbers();
            string textToCompare = "0";
            string newText = "-";

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagTableWithNumbers);
                        string oldText = CommonMethods.GetCubePlayText(cubePlay);

                        if (oldText.Equals(textToCompare))
                        {
                            CommonMethods.ChangeTextForFirstChild(cubePlay, newText);
                            CommonMethods.ChangeTagForGameObject(cubePlay, tagInactiveField);
                        }
                    }
                }
            }

            return tableWtithNumber;
        }

    }
}
