using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Scripts
{
    internal class GameConfigurationPlayerSymbolTableWithPlayerNumber
    {

        //public static string[] CreateTableWithTextForPrefabPlayerNumber(int numberOfRows)
        //{
        //    string[] numbers = new string[numberOfRows];
        //    string numberString;

        //    for (int number = 1; number <= numberOfRows; number++)
        //    {
        //        numberString = CommonMethodsMain.ConverIntToString(number);
        //        int indexNumber = number - 1;
        //        numbers[indexNumber] = numberString;
        //    }

        //    return numbers;
        //}

        //public static string[,,] CreateTableForDefaultTextForPlayersSymbol(string[] table, int numberOfRows)
        //{
        //    int numberOfDepths = 1;
        //    int numberOfColumns = 1;
           
        //    string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];
        //    int[] index = new int[1];
        //    index[0] = 0;
        //    int currentIndex;

        //    for (int indexDepth = 0; indexDepth < numberOfDepths; indexDepth++)
        //    {
        //        for (int indexRow = numberOfRows - 1; indexRow >= 0; indexRow--)
        //        {
        //            for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
        //            {
        //                currentIndex = index[0];
        //                string stringNumber = table[currentIndex];

        //                newTable[indexDepth, indexRow, indexColumn] = stringNumber;
        //                index[0] = index[0] + 1;
        //            }
        //        }

        //        index[0] = 0;
        //    }

        //    return newTable;
        //}

        public static float GetFirstPositionForPrefabPlayerSymbol(float scale, int playersNumber)
        {       
            float scaleDevidedByTwo = scale / 2;
            float scaleDevidedByFour = scale / 4;
            float yForFirstPrefabPlayerSymbol;
            int playersNumberDevidedByTwo = playersNumber / 2;
            
            bool isPlayersNumberEven = GameCommonMethodsMain.IsNumberEven(playersNumber);

            if (isPlayersNumberEven == false)
            {
                decimal playersNumberDecimal = GameCommonMethodsMain.ConvertDecimalToInt(playersNumberDevidedByTwo);
                decimal playersNumberRoundUp = GameCommonMethodsMain.RoundUp(playersNumberDecimal);
                float playersNumberFloat = GameCommonMethodsMain.ConvertDecimalToFloat(playersNumberRoundUp);

                yForFirstPrefabPlayerSymbol = -playersNumberFloat;
                return yForFirstPrefabPlayerSymbol;
            } 
            else
            {
                decimal playersNumberDecimal = GameCommonMethodsMain.ConvertDecimalToInt(playersNumberDevidedByTwo);
                decimal playersNumberRoundUp = GameCommonMethodsMain.RoundUp(playersNumberDecimal);
                float playersNumberFloat = GameCommonMethodsMain.ConvertDecimalToFloat(playersNumberRoundUp);

                yForFirstPrefabPlayerSymbol = -playersNumberFloat;
                return yForFirstPrefabPlayerSymbol;
            }
        }

        public static float[] SetUpTableWithNewYForPrefabPlayerSymbol(GameObject prefabPlayerSymbol, int playersNumber)
        {
            float[] table = new float[playersNumber];
            float scale = GameCommonMethodsMain.GetObjectScaleX(prefabPlayerSymbol);
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
            decimal number = GameCommonMethodsMain.ConvertIntToDecimal(palayersNumber) / 2;

            decimal numberFinal = GameCommonMethodsMain.RoundUp(number);
            int numberInt = GameCommonMethodsMain.ConvertDecimalToInt(numberFinal);
           
            bool isEvenNumber = GameCommonMethodsMain.IsNumberEven(number);

            if(isEvenNumber == true)
            {
                return numberInt;
            }
            else
            {
                number = number + 1;
                return numberInt;
            }
        }

        public static float[] SetUpTableWithNewYForPrefabPlayerSymbolBiggerThanSix(GameObject prefabPlayerSymbol, int playersNumber)
        {
            int playersNumberForFirstColumn = SetUpPlayersNumberForColumns(playersNumber); //  playersNumber / 2 = round down
            float[] table = new float[playersNumberForFirstColumn];

            float[] tableWithCoordinatesYForFirstColumn = SetUpTableWithNewYForPrefabPlayerSymbol(prefabPlayerSymbol, playersNumberForFirstColumn);         
            float upValue = 0.5f;

            for (int i = playersNumberForFirstColumn - 1; i >= 0; i--)
            {
                table[i] = tableWithCoordinatesYForFirstColumn[i] + upValue;
            }
           
            return table;
        }

        public static void ChangeNameForPlayersOrSymbols(GameObject gameObject, int currentNumber, string constantPartOfName)
        {
            string gameObjectName;
           
            if (currentNumber < 10)
            {
                gameObjectName = $"{constantPartOfName}_No_0{currentNumber}";
                GameCommonMethodsMain.ChangeGameObjectName(gameObject, gameObjectName);
            }
            else
            {
                gameObjectName = $"{constantPartOfName}_No_{currentNumber}";
                GameCommonMethodsMain.ChangeGameObjectName(gameObject, gameObjectName);
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
                maxIndexDepth = table.GetLength(0);
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

                            GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(player, yForFirstPrefabPlayerSymbol);
                            GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(player, newCoordinateX);

                            ChangeNameForPrefabPlayerNumber(player, playerNumber);
                        }
                    }
                }
            }
        }

        public static void ChangeDataForConfigurationButtonsPlayersNumbers(List<GameObject[,,]> buttons)
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
            float changeMoreY = -0.3f;
            int start = buttonsNumber - 1;
            int playerNumber;

            for (int i = 0; i < buttonsNumber; i++)
            {
                table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = table.GetLength(0);
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - i] + changeMoreY;

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject player = table[indexDepth, indexRow, indexColumn];

                            GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(player, yForFirstPrefabPlayerSymbol);
                            GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(player, newCoordinateX);

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
            float changeMoreY = -0.2f;
            int buttonsNumberForColumns = SetUpPlayersNumberForColumns(buttonsNumber);
            int start = buttonsNumberForColumns - 1;
            int playerNumber;

            int[] buttonsColumnsNumbers = { 1, 2 }; // two columns
            int buttonsColumnsIndex = 0;
            int currentCountedButtonsNumberForOneColumn = 0;

            for (int i = 0; i < buttonsNumber; i++)
            {
                table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = table.GetLength(0);
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn] + changeMoreY;
                coordinateX = newCoordinateX[buttonsColumnsIndex];

                if (currentCountedButtonsNumberForOneColumn < buttonsNumberForOneColumn - 1)
                {
                    ++currentCountedButtonsNumberForOneColumn;
                }
                else if (currentCountedButtonsNumberForOneColumn == buttonsNumberForOneColumn - 1 && buttonsColumnsIndex < 1)
                {
                    currentCountedButtonsNumberForOneColumn = 0;
                    ++buttonsColumnsIndex;
                }
                else
                {
                    if (i == buttonsNumber - 1)
                    {
                        currentCountedButtonsNumberForOneColumn = start;
                    }
                }

                for(int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject player = table[indexDepth, indexRow, indexColumn];

                            if (currentCountedButtonsNumberForOneColumn < buttonsNumberForOneColumn)
                            {
                                GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(player, coordinateX);
                                GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(player, yForFirstPrefabPlayerSymbol);
                            }
                            else
                            {
                                coordinateX = newCoordinateX[2];
                                GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(player, coordinateX);

                                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn];
                                GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(player, yForFirstPrefabPlayerSymbol);
                            }

                            ChangeNameForPrefabPlayerNumber(player, playerNumber);
                        }
                    }
                }
            }       
        }

        public static void ChangeDataForConfigurationButtonsPlayersSymbolsBiggerThanSix(List<GameObject[,,]> buttons)
        {
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

            float[] newCoordinateX = { -0.95f, 1.95f, 0.6f }; // {leftColumn, rightColumn, middleSingleButton}
            float coordinateX;
            float yForFirstPrefabPlayerSymbol;
            float coordinateYCorrection = -0.75f; // move down

            int buttonsNumberForColumns = SetUpPlayersNumberForColumns(buttonsNumber);

            int start = buttonsNumberForColumns - 1;
            int playerNumber;

            int[] buttonsColumnsNumbers = { 1, 2 }; // two columns
            int buttonsColumnsIndex = 0;
            int currentCountedButtonsNumberForOneColumn = 0;

            for (int i = 0; i < buttonsNumber; i++)
            {
                table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = table.GetLength(0);
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn] + coordinateYCorrection;
                coordinateX = newCoordinateX[buttonsColumnsIndex];

                if (currentCountedButtonsNumberForOneColumn < buttonsNumberForOneColumn - 1)
                {
                    ++currentCountedButtonsNumberForOneColumn;
                }
                else if (currentCountedButtonsNumberForOneColumn == buttonsNumberForOneColumn - 1 && buttonsColumnsIndex < 1)
                {
                    currentCountedButtonsNumberForOneColumn = 0;
                    ++buttonsColumnsIndex;
                }
                else
                {
                    if (i == buttonsNumber - 1)
                    {
                        currentCountedButtonsNumberForOneColumn = start;
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
                                GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(playerSymbol, coordinateX);
                                GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(playerSymbol, yForFirstPrefabPlayerSymbol);
                            }
                            else
                            {
                                coordinateX = newCoordinateX[2];
                                GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(playerSymbol, coordinateX);

                                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn] + coordinateYCorrection;
                                GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(playerSymbol, yForFirstPrefabPlayerSymbol);
                            }

                            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(playerSymbol, newCoordinateZ);
                            GameCommonMethodsMain.ChangeTextFontSize(playerSymbol, fontSize);

                            GameCommonMethodsMain.TransformGameObjectToNewScale(playerSymbol, newScale, newScale, newScale);
                            ChangeNameForPrefabPlayerSymbol(playerSymbol, playerNumber);
                        }
                    }
                }
            }
        }

        public static void ChangeDataForTableWithPlayerSymbolBiggerThanSix(List<GameObject[,,]> buttons)
        {
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

            float[] newCoordinateX = { -0.95f, 1.95f, 0.6f }; // {leftColumn, rightColumn, middleSingleButton}
            float coordinateX;
            float yForFirstPrefabPlayerSymbol;
            float coordinateYCorrection = -0.65f; // move down

            int buttonsNumberForColumns = SetUpPlayersNumberForColumns(buttonsNumber);

            int start = buttonsNumberForColumns - 1;
            int playerNumber;

            int[] buttonsColumnsNumbers = { 1, 2 }; // two columns
            int buttonsColumnsIndex = 0;
            int currentCountedButtonsNumberForOneColumn = 0;

            for (int i = 0; i < buttonsNumber; i++)
            {
                table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = table.GetLength(0);
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn] + coordinateYCorrection;
                coordinateX = newCoordinateX[buttonsColumnsIndex];

                if (currentCountedButtonsNumberForOneColumn < buttonsNumberForOneColumn - 1)
                {
                    ++currentCountedButtonsNumberForOneColumn;
                }
                else if (currentCountedButtonsNumberForOneColumn == buttonsNumberForOneColumn - 1 && buttonsColumnsIndex < 1)
                {
                    currentCountedButtonsNumberForOneColumn = 0;
                    ++buttonsColumnsIndex;
                }
                else
                {
                    if (i == buttonsNumber - 1)
                    {
                        currentCountedButtonsNumberForOneColumn = start;
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
                                GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(playerSymbol, coordinateX);
                                GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(playerSymbol, yForFirstPrefabPlayerSymbol);
                            }
                            else
                            {
                                coordinateX = newCoordinateX[2];
                                GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(playerSymbol, coordinateX);

                                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn] + coordinateYCorrection;
                                GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(playerSymbol, yForFirstPrefabPlayerSymbol);
                            }

                            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(playerSymbol, newCoordinateZ);
                            GameCommonMethodsMain.ChangeTextFontSize(playerSymbol, fontSize);

                            GameCommonMethodsMain.TransformGameObjectToNewScale(playerSymbol, newScale, newScale, newScale);
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
                maxIndexDepth = table.GetLength(0);
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

                            GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);

                            GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, yForFirstPrefabPlayerSymbol);
                            GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);

                            GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                            ChangeNameForPrefabPlayerSymbol(cubePlay, playerNumber);
                        }
                    }
                }
            }
        }

        public static void ChangeDataForConfigurationButtonsPlayersSymbols(List<GameObject[,,]> buttons)
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
            float changeMoreY = -0.4f;
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
                maxIndexDepth = table.GetLength(0);
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - i] + changeMoreY;

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = table[indexDepth, indexRow, indexColumn];

                            GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);

                            GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, yForFirstPrefabPlayerSymbol);
                            GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);

                            GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                            ChangeNameForPrefabPlayerSymbol(cubePlay, playerNumber);
                        }
                    }
                }
            }
        }

        public static void ChangeDataForButtonsPlayGameChangePlayersSymbols(List<GameObject[,,]> buttons, float newCoordinateX)
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
            //float newCoordinateX = 1.65f;
            float newCoordinateZ = 0.45f;
            float newScale = 0.9f;
            float fontSize = 0.5f;

            int start = buttonsNumber - 1;
            int playerNumber;

            for (int i = 0; i < buttonsNumber; i++)
            {
                table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = table.GetLength(0);
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

                            GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);

                            GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, yForFirstPrefabPlayerSymbol);
                            GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);

                            GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                            ChangeNameForPrefabPlayerSymbol(cubePlay, playerNumber);
                        }
                    }
                }
            }
        }


        //public static void ChangeDataForTableWithPlayersSymbolBiggerThanSix(List<GameObject[,,]> buttons)
        //{
        //    int maxIndexDepth;
        //    int maxIndexColumn;
        //    int maxIndexRow;
        //    int buttonsNumberForColumns = buttons.Count;

        //    GameObject[,,] table;
        //    GameObject[,,] buttonFirst = buttons[0];

        //    GameObject prefabPlayerSymbol = buttonFirst[0, 0, 0];

        //    float[] tableWithNewCordinateForY = SetUpTableWithNewYForPrefabPlayerSymbolBiggerThanSix(prefabPlayerSymbol, buttonsNumberForColumns);
        //    float yForFirstPrefabPlayerSymbol;
        //    float newCoordinateX = 1.65f;
        //    float newCoordinateZ = 0.45f;
        //    float newScale = 0.9f;
        //    float fontSize = 0.5f;

        //    int start = buttonsNumberForColumns - 1; // -1 for index, -1 for start position
        //    int playerNumber;

        //    int[] buttonsColumnsNumbers = { 1, 2 }; // two columns
        //   // int buttonsColumnsIndex = 0;
        //   //int countedButtonsNumberForColumns = 0;
        //    int currentCountedButtonsNumberForOneColumn = 0;

        //    for (int i = 0; i < buttonsNumberForColumns; i++)
        //    {
        //        table = buttons[i];
        //        playerNumber = i + 1;
        //        maxIndexDepth = table.GetLength(0);
        //        maxIndexColumn = table.GetLength(2);
        //        maxIndexRow = table.GetLength(1);

        //        yForFirstPrefabPlayerSymbol = tableWithNewCordinateForY[start - currentCountedButtonsNumberForOneColumn];

        //        for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
        //        {
        //            for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
        //            {
        //                for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
        //                {
        //                    GameObject cubePlay = table[indexDepth, indexRow, indexColumn];
        //                    CommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);

        //                    CommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, yForFirstPrefabPlayerSymbol);
        //                    CommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
        //                    CommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);

        //                    CommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
        //                    ChangeNameForPrefabPlayerSymbol(cubePlay, playerNumber);
        //                }
        //            }
        //        }
        //    }
        //}

    
    }
}
