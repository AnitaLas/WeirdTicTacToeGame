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


        public static GameObject[,,] CreateTableWithOptionToChooseForTeamMembersNumbers(GameObject[,,] tableWtithNumber, string tagName)
        {
            string frontTextToAdd = "TeamMembers_NewNo_";

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
                        GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagName);
                        string text = CommonMethods.GetCubePlayText(cubePlay);
                        string oldName = GameCommonMethodsMain.GetObjectName(cubePlay);
                        string newName = frontTextToAdd + text + "_" + oldName;
                        GameCommonMethodsMain.ChangeGameObjectName(cubePlay, newName);
                    }
                }
            }

            return tableWtithNumber;
        }

        public static GameObject[,,] CreateTableWithNumberForTeamMembers(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            string tagNumbers = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersTableWithNumbers();

            //string tagInactiveField = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();

            var numbers = ScreenVerificationMethods.GetSizeForTableWithPlayersNumbersForTeamMembers(isCellphoneMode);
            int numberOfDepths = 1;
            int numberOfRows = numbers.Item1;
            int numberOfColumns = numbers.Item2;

            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = CreateTableWithOptionToChooseForTeamMembersNumbers(tableWithNumbers, tagNumbers);

            return tableWithNumberFinal;
        }


        // new class 
        public static GameObject[,,] CreateTableWithTeamMembersSymbols(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTimeForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
            tableWithNumber = CreateTableMainMethodsForButtons.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);

            return tableWithNumber;
        }     

        public static string[] CreateTableWithSymbolsForCubePlay()
        {
            int maxCubePlayNumber = 12;
            string[] tableString = new string[maxCubePlayNumber];         

            for (int i = 0; i < maxCubePlayNumber; i++)
            {
                string numberString = CommonMethods.ConverIntToString(i);
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

            string[] numbers = CreateTableWithSymbolsForCubePlay();

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

        public static GameObject[,,] ChangeDataForTableWithTeamMembers(GameObject[,,] tableWtithNumber)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);

            //string tagInactiveField = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersInactiveField();
            //string tagTableWithNumbers = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersTableWithNumbers();
            //string textToCompare = "0";
            //string newText = "-";

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
                        //GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagTableWithNumbers);
                        string oldText = CommonMethods.GetCubePlayText(cubePlay);

                        //if (oldText.Equals(textToCompare))
                        //{
                        //    CommonMethods.ChangeTextForFirstChild(cubePlay, newText);
                        //    CommonMethods.ChangeTagForGameObject(cubePlay, tagInactiveField);
                        //}
                    }
                }
            }

            return tableWtithNumber;
        }

    }
}
