using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsWithNumbersForChangeRandomly
    {

        public static GameObject[,,] CreateTableForTimeBySeconds(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField)
        {
            GameObject[,,] table;
            int[] tableWithSeconds = CreateTableWithSeconds();
            int start = 0;
            int end = 4;
            //float newCoordinateY = 100f;
            float newCoordinateY = 0f;
            string inactiveText = "-";

            table = GameConfigurationButtonsWithNumbersCommonMethods.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
            return table;

        }


        public static GameObject[,,] CreateTableForChangeRandomly(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            string tagConfigurationBoardGameTableNumberRows = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberRandomly();
            string tagConfigurationBoardGameInactiveField = "";

            int numberOfDepths = 1;
            int numberOfRows = 4;
            int numberOfColumns = 4;

            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            //tableWithNumberFinal = GameConfigurationButtonsWithNumbersForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumbers, tagConfigurationBoardGameTableNumberRows, tagConfigurationBoardGameInactiveField, isCellphoneMode);
            tableWithNumberFinal = CreateTableForTimeBySeconds(tableWithNumbers, tagConfigurationBoardGameTableNumberRows, tagConfigurationBoardGameInactiveField);

            //return tableWithNumbers;
            return tableWithNumberFinal;
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

            for (int i = 0; i < table.Length; i++)
            {
                Debug.Log(table[i]);
            }

            return table;
        }

        public static GameObject[,,] ChangeDataForTableWithSeconds(GameObject[,,] tableWtithNumber, int[] tableWithSeconds, string tagConfigurationBoardGameTableNumberForAll, float newCoordinateY)
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
                        string cubePlayText = GameCommonMethodsMain.GetCubePlayText(cubePlay);
                        int cubePlayTextInt = GameCommonMethodsMain.ConvertStringToInt(cubePlayText);

                        GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagConfigurationBoardGameTableNumberForAll);
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);

                    }
                }
            }

            return tableWtithNumber;
        }

    }
}
