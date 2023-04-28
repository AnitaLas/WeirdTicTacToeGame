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

        public static float[] SetUpTableWithNewYForPrefabPlayerSymbol(GameObject prefabPlayerSymbol, int playersNumber)
        {
            float[] table = new float[playersNumber];
            float scale = CommonMethods.GetObjectScaleX(prefabPlayerSymbol);
            //float halfScale = scale / 2;
            //float halfScale = scale * 1.5f;
            float halfScale = scale * 3.2f;
            float firstY = GetFirstPositionForPrefabPlayerSymbol(scale, playersNumber) - 0.2f;
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


        public static void ChangeNameForPlayersOrSymbols(GameObject gameObject, int currentNumber, string constantPartOfName)
        {
            string gameObjectName;
           
            if (currentNumber < 10)
            {
                gameObjectName = $"{constantPartOfName}_No_0{currentNumber}";
                CommonMethods.ChangeGameObjectName(gameObject, gameObjectName);
            }
            else
            {
                gameObjectName = $"{constantPartOfName}_No_{currentNumber}";
                CommonMethods.ChangeGameObjectName(gameObject, gameObjectName);
            }

        }

        public static void ChangeNameForPrefabPlayerSymbol(GameObject gameObject, int currentNumber)
        {
            string constantPartOfName = "PlayerSymbol";
            ChangeNameForPlayersOrSymbols(gameObject, currentNumber, constantPartOfName);

        }

        public static void ChangeNameForPrefabPlayerNumber(GameObject gameObject, int currentNumber)
        {
            string constantPartOfName = "PlayerNumber";
            ChangeNameForPlayersOrSymbols(gameObject, currentNumber, constantPartOfName);
        }


        public static void ChangeDataForTableWithPlayerNumber(List<GameObject[,,]> buttons)
        {
            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumber = buttons.Count;
            //Debug.Log($"buttonsNumber =  {buttonsNumber} ");

            GameObject[,,] table;         
            GameObject[,,] buttonFirst = buttons[0];

            GameObject prefabPlayerSymbol = buttonFirst[0, 0, 0];


            float[] tableWithNewCordinateForY = SetUpTableWithNewYForPrefabPlayerSymbol(prefabPlayerSymbol, buttonsNumber);
            float yForFirstPrefabPlayerSymbol;
            float newCoordinateX = -0.95f;
            int start = buttonsNumber - 1;
            int playerNumber;

            for (int i = 0; i < buttonsNumber; i++)
            {
                //Debug.Log($"i =  {i} ");
                 table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = 1;
                 maxIndexColumn = table.GetLength(2);
                 maxIndexRow = table.GetLength(1);

                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - i];

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject player = table[indexDepth, indexRow, indexColumn];

                            //playerNumber = maxIndexRow - indexRow;

                            CommonMethods.SetUpNewYForGameObject(player, yForFirstPrefabPlayerSymbol);
                            CommonMethods.SetUpNewXForGameObject(player, newCoordinateX);

                            ChangeNameForPrefabPlayerNumber(player, playerNumber);
                        }
                    }
                }
            }
        }


        public static void ChangeDataForTableWithPlayerSymbols(List<GameObject[,,]> buttons)
        {
            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumber = buttons.Count;
            //Debug.Log($"buttonsNumber =  {buttonsNumber} ");

            GameObject[,,] table;
            GameObject[,,] buttonFirst = buttons[0];

            GameObject prefabPlayerSymbol = buttonFirst[0, 0, 0];


            float[] tableWithNewCordinateForY = SetUpTableWithNewYForPrefabPlayerSymbol(prefabPlayerSymbol, buttonsNumber);
            float yForFirstPrefabPlayerSymbol;
            float newCoordinateX = 1.6f;
            float newCoordinateZ = 0.45f;
            float newScale = 0.9f;

            int start = buttonsNumber - 1;
            int playerNumber;

            for (int i = 0; i < buttonsNumber; i++)
            {
                //Debug.Log($"i =  {i} ");
                table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = 1;
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - i];

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = table[indexDepth, indexRow, indexColumn];

                            CommonMethods.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);

                            CommonMethods.SetUpNewYForGameObject(cubePlay, yForFirstPrefabPlayerSymbol);
                            CommonMethods.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            CommonMethods.ChangeZForGameObject(cubePlay, newCoordinateZ);

                            ChangeNameForPrefabPlayerSymbol(cubePlay, playerNumber);
                        }
                    }
                }
            }



        }

    }
}
