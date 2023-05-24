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
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
            tableWithNumber = CreateTableMainMethodsForButtons.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);
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
                decimal playersNumberDecimal = CommonMethods.ConvertDecimalToInt(playersNumberDevidedByTwo);
                decimal playersNumberRoundUp = CommonMethods.RoundUp(playersNumberDecimal);
                float playersNumberFloat = CommonMethods.ConvertDecimalToFloat(playersNumberRoundUp);

                yForFirstPrefabPlayerSymbol = -playersNumberFloat;
                return yForFirstPrefabPlayerSymbol;

            } 
            else
            {
                decimal playersNumberDecimal = CommonMethods.ConvertDecimalToInt(playersNumberDevidedByTwo);
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
            int previousResultIndex;

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
            float halfScale = scale * 3.2f;
            //float halfScale = scale * 3.5f;
            float firstY = GetFirstPositionForPrefabPlayerSymbol(scale, playersNumber) - 0.2f;
            table[0] = firstY;
            float result;
            float previousResult;
            int previousResultIndex;

            for (int newY = 1; newY < playersNumber; newY++)
            {
                previousResultIndex = newY - 1;
                previousResult = table[previousResultIndex];
                result = previousResult + scale + halfScale;
                table[newY] = result;
            }



            return table;
        }

        public static int SetUpPlayersNumberForColumns(int palayersNumber)
        {
            decimal number = CommonMethods.ConvertIntToDecimal(palayersNumber) / 2;
            //int number = palayersNumber / 2;
            //Debug.Log("number = " + number);

            decimal numberFinal = CommonMethods.RoundUp(number);
            int numberInt = CommonMethods.ConvertDecimalToInt(numberFinal);
           
            bool isEvenNumber = CommonMethods.IsNumberEven(number);

            if(isEvenNumber == true)
            {
                //return number;
                //Debug.Log("number = " + number );
                //number = number + 1;
                //return number;
                return numberInt;
            }
            else
            {
                //return ++number;
                //Debug.Log("number + 1 = " + (number + 1));
                number = number + 1;
                //return number;
                return numberInt;
            }
        }

        public static float[] SetUpTableWithNewYForPrefabPlayerSymbolBiggerThanSix(GameObject prefabPlayerSymbol, int playersNumber)
        {
            //Debug.Log(" 1  ");
            

            int playersNumberForFirstColumn = SetUpPlayersNumberForColumns(playersNumber); //  playersNumber / 2 = round down
            float[] table = new float[playersNumberForFirstColumn];
            //bool isEvenplayersNumber = CommonMethods.IsNumberEven(playersNumber);

            //Debug.Log(" playersNumberForFirstColumn  = " + playersNumberForFirstColumn);

            //int playersNumberForSecondColumn = playersNumber - playersNumberForFirstColumn;
            //bool isEvenPlayersNumberForSecondColumn = CommonMethods.IsNumberEven(playersNumberForSecondColumn);
            //bool isEvenPlayersNumberForSecondColumn = CommonMethods.IsNumberEven(playersNumber);
            //Debug.Log(" playersNumberForSecondColumn  = " + playersNumberForSecondColumn);

            //Debug.Log(" 2  ");
            float[] tableWithCoordinatesYForFirstColumn = SetUpTableWithNewYForPrefabPlayerSymbol(prefabPlayerSymbol, playersNumberForFirstColumn);
            //float[] tableWithCoordinatesYForSecondColumn = SetUpTableWithNewYForPrefabPlayerSymbol(prefabPlayerSymbol, playersNumberForSecondColumn);

            //Debug.Log(" 3  ");
            //for (int i = 0; i < tableWithCoordinatesYForFirstColumn.Length; i++)
            //{
            //    Debug.Log($" tableWithCoordinatesYForFirstColumn[{i}]  = " + tableWithCoordinatesYForFirstColumn[i]);
            //}

            //for (int i = 0; i < tableWithCoordinatesYForSecondColumn.Length; i++)
            //{
            //    Debug.Log($" tableWithCoordinatesYForSecondColumn[{i}]  = " + tableWithCoordinatesYForSecondColumn[i]);
            //}

            //Debug.Log(" ----------------------------  ");

            float upValue = 0.5f;

            for (int i = playersNumberForFirstColumn - 1; i >= 0; i--)
            {
                //Debug.Log(" 4 ");
                table[i] = tableWithCoordinatesYForFirstColumn[i] + upValue;
                //Debug.Log($" table[{i}]  = " + table[i]);
            }

            //Debug.Log(" ----------------------------  ");

            //for (int i = 0; i < table.Length; i++)
            //{
            //    Debug.Log($" table[{i}]  = " + table[i]);
            //}







            //Debug.Log(" playersNumber = " + playersNumber);

            //int j;

            //for (int i = playersNumber - 1; i >= playersNumberForFirstColumn ; i--)
            //{
               
            //    //Debug.Log(" 2 ");
            //    //if (isEvenplayersNumber == true)
            //    //if (isEvenPlayersNumberForSecondColumn == true)
            //    if (isEvenPlayersNumberForSecondColumn == true)
            //    {
            //        j = i - playersNumberForSecondColumn - 1;
            //        Debug.Log($"EEEEEE   j  = " + j);
            //    }
            //    else
            //    {
            //        j = i - playersNumberForSecondColumn - 1;
            //        Debug.Log($"ODD   j  = " + j);
            //    }
            //    //j = i - playersNumberForSecondColumn;
            //    //Debug.Log($" j  = " + j);
            //    table[i] = tableWithCoordinatesYForSecondColumn[j] + upValue;
            //     //Debug.Log($" table[{i}]  = " + table[i]);
            //}


            //for (int i = 0; i < playersNumberForFirstColumn; i++)
            //{

            //    table[i] = tableWithCoordinatesYForFirstColumn[i];
            //    //Debug.Log($" table[{i}]  = " + table[i]);
            //}

            ////Debug.Log(" ----------------------------  ");

            //for (int i = playersNumberForFirstColumn; i < playersNumber; i++)
            //{
            //    int j = i - playersNumberForFirstColumn;
            //    table[i] = tableWithCoordinatesYForSecondColumn[j];
            //    //Debug.Log($" table[{i}]  = " + table[i]);
            //}




            //for (int i = 0; i < table.Length; i++)
            //{
            //    Debug.Log($" table[{i}]  = " + table[i]);
            //}

            //Debug.Log(" 3 ");
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

            GameObject[,,] table;         
            GameObject[,,] buttonFirst = buttons[0];

            GameObject prefabPlayerSymbol = buttonFirst[0, 0, 0];

            float[] tableWithNewCordinateForY = SetUpTableWithNewYForPrefabPlayerSymbol(prefabPlayerSymbol, buttonsNumber);

            float yForFirstPrefabPlayerSymbol;
            float newCoordinateX = -0.85f;
            int start = buttonsNumber - 1;
            int playerNumber;

            for (int i = 0; i < buttonsNumber; i++)
            {
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

                            CommonMethods.SetUpNewYForGameObject(player, yForFirstPrefabPlayerSymbol);
                            CommonMethods.SetUpNewXForGameObject(player, newCoordinateX);

                            ChangeNameForPrefabPlayerNumber(player, playerNumber);
                        }
                    }
                }
            }
        }

        public static void ChangeDataForTableWithPlayerNumberBiggerThanSix(List<GameObject[,,]> buttons)
        {
            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumber = buttons.Count;
            int buttonsNumberForOneColumn = buttonsNumber / 2;

            GameObject[,,] table;
            GameObject[,,] buttonFirst = buttons[0];

            GameObject prefabPlayerSymbol = buttonFirst[0, 0, 0];

            float[] tableWithNewCordinateForY = SetUpTableWithNewYForPrefabPlayerSymbolBiggerThanSix(prefabPlayerSymbol, buttonsNumber);

            //float[] newCoordinateX = { -0.5f, 2.05f, 0.75f };
            float[] newCoordinateX = { -0.8f, 2.05f, 0.75f }; // {leftColumn, rightColumn, middleSingleButton}
            float coordinateX;
            float yForFirstPrefabPlayerSymbol;


            int buttonsNumberForColumns = SetUpPlayersNumberForColumns(buttonsNumber);

            int start = buttonsNumberForColumns - 1;
            int playerNumber;

            int[] buttonsColumnsNumbers = { 1, 2 }; // two columns
            int buttonsColumnsIndex = 0;

            //int countedButtonsNumberForColumns = 0;
            int currentCountedButtonsNumberForOneColumn = 0;


            for (int i = 0; i < buttonsNumber; i++)
            {
                table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = 1;
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn];
                coordinateX = newCoordinateX[buttonsColumnsIndex];

                if (currentCountedButtonsNumberForOneColumn < buttonsNumberForOneColumn - 1)
                {
                    //Debug.Log(" 3 ");
                    ++currentCountedButtonsNumberForOneColumn;
                }
                else if (currentCountedButtonsNumberForOneColumn == buttonsNumberForOneColumn - 1 && buttonsColumnsIndex < 1)
                {
                    //Debug.Log(" 2 ");
                    currentCountedButtonsNumberForOneColumn = 0;
                    ++buttonsColumnsIndex;
                }
                else
                {

                    if (i == buttonsNumber - 1)
                    {
                        //Debug.Log(" 1 ");
                        currentCountedButtonsNumberForOneColumn = start;
                        //Debug.Log(" currentCountedButtonsNumberForOneColumn =  " + currentCountedButtonsNumberForOneColumn);


                    }



                }


                    for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                    {
                        for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                        {
                            for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                            {
                                GameObject player = table[indexDepth, indexRow, indexColumn];


                                if (currentCountedButtonsNumberForOneColumn < buttonsNumberForOneColumn)
                                {
                                    CommonMethods.SetUpNewXForGameObject(player, coordinateX);

                                    CommonMethods.SetUpNewYForGameObject(player, yForFirstPrefabPlayerSymbol);

                                }
                                else
                                {
                                    coordinateX = newCoordinateX[2];

                                    CommonMethods.SetUpNewXForGameObject(player, coordinateX);

                                    yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn];
                                    CommonMethods.SetUpNewYForGameObject(player, yForFirstPrefabPlayerSymbol);
                                }


                                ChangeNameForPrefabPlayerNumber(player, playerNumber);
                            }
                        }
                    }
                }

            
        }

        public static void ChangeDataForTableWithPlayerSymbolBiggerThanSix(List<GameObject[,,]> buttons)
        {
            Debug.Log("tablet ");
            //float newCoordinateX = 1.65f;
            float newCoordinateZ = 0.45f;
            float newScale = 0.9f;
            float fontSize = 0.5f;

            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumber = buttons.Count;
            int buttonsNumberForOneColumn = buttonsNumber / 2;

            GameObject[,,] table;
            GameObject[,,] buttonFirst = buttons[0];

            GameObject prefabPlayerSymbol = buttonFirst[0, 0, 0];

            float[] tableWithNewCordinateForY = SetUpTableWithNewYForPrefabPlayerSymbolBiggerThanSix(prefabPlayerSymbol, buttonsNumber);

            //float[] newCoordinateX = { -0.7f, 1.85f, 0.6f };
            float[] newCoordinateX = { -0.95f, 1.95f, 0.6f }; // {leftColumn, rightColumn, middleSingleButton}
            float coordinateX;
            float yForFirstPrefabPlayerSymbol;
            float coordinateYCorrection = -0.65f; // move down

            int buttonsNumberForColumns = SetUpPlayersNumberForColumns(buttonsNumber);

            int start = buttonsNumberForColumns - 1;
            int playerNumber;

            int[] buttonsColumnsNumbers = { 1, 2 }; // two columns
            int buttonsColumnsIndex = 0;

            //int countedButtonsNumberForColumns = 0;
            int currentCountedButtonsNumberForOneColumn = 0;


            for (int i = 0; i < buttonsNumber; i++)
            {
                table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = 1;
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn] + coordinateYCorrection;
                coordinateX = newCoordinateX[buttonsColumnsIndex];

                if (currentCountedButtonsNumberForOneColumn < buttonsNumberForOneColumn - 1)
                {
                    //Debug.Log(" 3 ");
                    ++currentCountedButtonsNumberForOneColumn;
                }
                else if (currentCountedButtonsNumberForOneColumn == buttonsNumberForOneColumn - 1 && buttonsColumnsIndex < 1)
                {
                    //Debug.Log(" 2 ");
                    currentCountedButtonsNumberForOneColumn = 0;
                    ++buttonsColumnsIndex;
                }
                else
                {

                    if (i == buttonsNumber - 1)
                    {
                        //Debug.Log(" 1 ");
                        currentCountedButtonsNumberForOneColumn = start;
                        //Debug.Log(" currentCountedButtonsNumberForOneColumn =  " + currentCountedButtonsNumberForOneColumn);


                    }



                }


                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject playerSymbol = table[indexDepth, indexRow, indexColumn];


                            if (currentCountedButtonsNumberForOneColumn < buttonsNumberForOneColumn)
                            {
                                CommonMethods.SetUpNewXForGameObject(playerSymbol, coordinateX);

                                CommonMethods.SetUpNewYForGameObject(playerSymbol, yForFirstPrefabPlayerSymbol);

                            }
                            else
                            {
                                coordinateX = newCoordinateX[2];

                                CommonMethods.SetUpNewXForGameObject(playerSymbol, coordinateX);

                                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn] + coordinateYCorrection;
                                CommonMethods.SetUpNewYForGameObject(playerSymbol, yForFirstPrefabPlayerSymbol);
                            }
                            CommonMethods.ChangeZForGameObject(playerSymbol, newCoordinateZ);
                            CommonMethods.ChangeTextFontSize(playerSymbol, fontSize);

                            CommonMethods.TransformGameObjectToNewScale(playerSymbol, newScale, newScale, newScale);
                            ChangeNameForPrefabPlayerSymbol(playerSymbol, playerNumber);
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

            GameObject[,,] table;
            GameObject[,,] buttonFirst = buttons[0];

            GameObject prefabPlayerSymbol = buttonFirst[0, 0, 0];


            float[] tableWithNewCordinateForY = SetUpTableWithNewYForPrefabPlayerSymbol(prefabPlayerSymbol, buttonsNumber);
            float yForFirstPrefabPlayerSymbol;
            //float newCoordinateX = 1.6f;
            float newCoordinateX = 1.65f;
            float newCoordinateZ = 0.45f;
            float newScale = 0.9f;
            float fontSize = 0.5f;

            int start = buttonsNumber - 1;
            int playerNumber;

            for (int i = 0; i < buttonsNumber; i++)
            {
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
                            CommonMethods.ChangeTextFontSize(cubePlay, fontSize);

                            ChangeNameForPrefabPlayerSymbol(cubePlay, playerNumber);
                        }
                    }
                }
            }
        }

        public static void ChangeDataForTableWithPlayersSymbolBiggerThanSix(List<GameObject[,,]> buttons)
        {
            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumberForColumns = buttons.Count;

            GameObject[,,] table;
            GameObject[,,] buttonFirst = buttons[0];

            GameObject prefabPlayerSymbol = buttonFirst[0, 0, 0];


            float[] tableWithNewCordinateForY = SetUpTableWithNewYForPrefabPlayerSymbolBiggerThanSix(prefabPlayerSymbol, buttonsNumberForColumns);
            float yForFirstPrefabPlayerSymbol;
            //float newCoordinateX = 1.6f;
            float newCoordinateX = 1.65f;
            float newCoordinateZ = 0.45f;
            float newScale = 0.9f;
            float fontSize = 0.5f;

            int start = buttonsNumberForColumns - 1; // -1 for index, -1 for start position
            int playerNumber;

            int[] buttonsColumnsNumbers = { 1, 2 }; // two columns
            int buttonsColumnsIndex = 0;

            int countedButtonsNumberForColumns = 0;
            int currentCountedButtonsNumberForOneColumn = 0;




            for (int i = 0; i < buttonsNumberForColumns; i++)
            {
                table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = 1;
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                // yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - i];

                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn];
                //Debug.Log($"currentCountedButtonsNumberForOneColumn = " + currentCountedButtonsNumberForOneColumn);
                //coordinateX = newCoordinateX[buttonsColumnsIndex];

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
                            CommonMethods.ChangeTextFontSize(cubePlay, fontSize);

                            ChangeNameForPrefabPlayerSymbol(cubePlay, playerNumber);
                        }
                    }
                }
            }
        }

    }
}
