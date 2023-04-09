using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.GameConfigurationPlayerSymbol
{
    internal class GameConfigurationPlayerSymbolTableWithPlayerNumber
    {

        public static GameObject[,,] CreateTableWithPlayers(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //Debug.Log(" 3 ");
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }

        public static string[] CreateTableWithTextForPrefabPlayerNumber(int numberOfRows)
        {
            string[] numbers = new string[numberOfRows];
            string numberString;

            for (int number = 1; number <= numberOfRows; number++)
            {
                numberString = CommonMethods.ConverIntToString(number);
                int indexNumber = number - 1;
                numbers[indexNumber] = numberString;
            }

            return numbers;

        }

        public static string[,,] CreateTableForDefaultTextForPlayersSymbol(string[] table, int numberOfRows)
        {
            int numberOfDepths = 1;
            int numberOfColumns = 1;
           
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



        public static string[,,] CreateTableWithTextForPrefabCubePlay(int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];

            string[] numbers = CreateTableWithTextForPrefabPlayerNumber(numberOfRows);

            string[,,] numbers3D = CreateTableForDefaultTextForPlayersSymbol(numbers, numberOfRows);

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

        // ---
        public static void ChangePlayerSymbolForChildText(GameObject gameObject, int childNumber, string newText)
        {
            TextMeshProUGUI text = CommonMethods.GetTextMeshProUGUIForPlayerSymbolChild(gameObject, childNumber);
            text.text = newText;
        }


        public static float GetFirstPositionForPrefabPlayerSymbol(float scale, int playersNumber)
        {
           
            float scaleDevidedByTwo = scale / 2;
            float scaleDevidedByFour = scale / 4;
            float yForFirstPrefabPlayerSymbol;
            int playersNumberDevidedByTwo = playersNumber / 2;
            
            bool isPlayersNumberEven = CommonMethods.IsNumberEven(playersNumber);

            if (isPlayersNumberEven == false)
            {
                decimal playersNumberDecimal = CommonMethods.ConvertIntToDecimal(playersNumberDevidedByTwo);
                decimal playersNumberRoundUp = CommonMethods.RoundUp(playersNumberDecimal);
                float playersNumberFloat = CommonMethods.ConvertDecimalToFloat(playersNumberRoundUp);

                yForFirstPrefabPlayerSymbol = -playersNumberFloat;
                return yForFirstPrefabPlayerSymbol;

            } 
            else
            {
                //2468
                decimal playersNumberDecimal = CommonMethods.ConvertIntToDecimal(playersNumberDevidedByTwo);
                decimal playersNumberRoundUp = CommonMethods.RoundUp(playersNumberDecimal);
                float playersNumberFloat = CommonMethods.ConvertDecimalToFloat(playersNumberRoundUp);

                yForFirstPrefabPlayerSymbol = -playersNumberFloat;
                return yForFirstPrefabPlayerSymbol;

            }
        }


        public static float[] GetTableWithNewYForPrefabPlayerSymbol(GameObject prefabPlayerSymbol, int playersNumber)
        {
            float[] table = new float[playersNumber];
            float scale = CommonMethods.GetObjectScaleX(prefabPlayerSymbol);
            float halfScale = scale / 2;
            float firstY = GetFirstPositionForPrefabPlayerSymbol(scale, playersNumber);
            table[0] = firstY;
            float result;
            float previousResult;
            int previousResultIndex; // = 0;

            for (int newY = 1; newY < playersNumber; newY++)
            {
                previousResultIndex = newY - 1;
                previousResult = table[previousResultIndex];
                result = previousResult + scale + halfScale;
                table[newY] = result; 
            }



            return table;
        }

        public static void ChangeNameForPrefabPlayerSymbol(GameObject prefabPlayerSymbol, int currentPrefabPlayerSymbol)
        {
            string prefabPlayerSymbolName = $"PlayerSymbol_No_{currentPrefabPlayerSymbol}";
            //string cubePlayName = $"CubePlayUI_No_{currentNumberCubePlayName}";
            prefabPlayerSymbol.name = prefabPlayerSymbolName;
            //return cubePlayName;
        }


        public static GameObject[,,] ChangeDataForTableWithPlayersAndSymbols(GameObject[,,] tableWtithNumber)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);
            //bool isRowNumberEven = CommonMethods.IsNumberEven(maxIndexRow);

            GameObject prefabPlayerSymbol = tableWtithNumber[0, 0, 0];
            string[] defaultPlayersSymbols = CreateGameBoardMethods.CreateTableWithCharactersByGivenString();
            float[] tableWithNewCordinateForY = GetTableWithNewYForPrefabPlayerSymbol(prefabPlayerSymbol, maxIndexRow);

            float yForFirstPrefabPlayerSymbol;

            int firstChildText = 0;
            int secondChildSymbol = 1;
            int playerNumber;
            int defaultSymbolNumber;

            string firstChildDefaultText;
            string secondChildDefaultText;


            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject playerSymbol = tableWtithNumber[indexDepth, indexRow, indexColumn];

                        playerNumber = maxIndexRow - indexRow;
                        firstChildDefaultText = $"PLAYER {playerNumber}";
                        ChangePlayerSymbolForChildText(playerSymbol, firstChildText, firstChildDefaultText);

                        defaultSymbolNumber = maxIndexRow - indexRow - 1;
                        secondChildDefaultText = defaultPlayersSymbols[defaultSymbolNumber];
                        ChangePlayerSymbolForChildText(playerSymbol, secondChildSymbol, secondChildDefaultText);

                        yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[indexRow];
                        CommonMethods.ChangeYForGameObject(playerSymbol , yForFirstPrefabPlayerSymbol);

                        CommonMethods.ChangeTextForSecondChild(playerSymbol, firstChildDefaultText);

                        ChangeNameForPrefabPlayerSymbol(playerSymbol, playerNumber);
                    }
                }
            }

            return tableWtithNumber;

        }
    }
}
