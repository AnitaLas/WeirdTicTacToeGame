using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.CommonMethods;

namespace Assets.Scripts.GameConfigurationPlayerSymbol
{
    internal class GameConfigurationPlayerSymbolTableWithSymbols
    {
        public static GameObject[,,] CreateTableWithSymbols(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
            tableWithNumber = CreateTableMainMethodsForButtons.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);

            return tableWithNumber;
        }

        public static string[,,] CreateTableForDefaultTextWithCharacters(string[] tableWithCharacters, int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];
            string stringAlphabet;

            int tableLenght = tableWithCharacters.Length;
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

                        if (currentIndex >= tableLenght)
                        {
                            stringAlphabet = "-";
                        } 
                        else
                        {
                            stringAlphabet = tableWithCharacters[currentIndex];
                        }
                         newTable[indexDepth, indexRow, indexColumn] = stringAlphabet;

                        index[0] = index[0] + 1;
                    }
                }
            }

            return newTable;
        }

        public static string[,,] CreateTableWithTextForPrefabCubePlay(int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];

            string[] alphabet = CreateGameBoardMethods.CreateTableWithCharactersByGivenString();

            string[,,] alphabet3D = CreateTableForDefaultTextWithCharacters(alphabet, numberOfDepths, numberOfRows, numberOfColumns);

            for (int indexDepth = 0; indexDepth < numberOfDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < numberOfRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                    {
                        string stringNumber = alphabet3D[indexDepth, indexRow, indexColumn];
                        newTable[indexDepth, indexRow, indexColumn] = stringNumber;
                    }
                }
            }

            return newTable;
        }

        public static string[] CreateTableWithPlayersChosenSymbols(List<GameObject[,,]> tableWithPlayersAndSymbols)
        {
            int elements = tableWithPlayersAndSymbols.Count;
            int maxIndexDepth = 1;
            int maxIndexColumn;
            int maxIndexRow;
            int index;

            GameObject[,,] table;

            string[] tableWitPlayersChosenSymbols = new string[elements];

            for (int i = 0; i < elements; i++)
            {
                table = tableWithPlayersAndSymbols[i];
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);
                index = i;

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject chosenPlayerSymbol = table[indexDepth, indexRow, indexColumn];
                            string chosenPlayerSymbolText = CommonMethodsMain.GetCubePlayText(chosenPlayerSymbol);

                            tableWitPlayersChosenSymbols[index] = chosenPlayerSymbolText;                          
                        }
                    }
                }
            }

            return tableWitPlayersChosenSymbols;
        }

        public static GameObject[,,] ChangeDataForTableWithSymbols(GameObject[,,] tableWithSymbolsBase, string[] tableWitPlayersChosenSymbols, Material[] prefabSymbolPlayerMaterialInactiveField, string tagConfigurationPlayerSymbolChooseSymbol, string tagConfigurationBoardGameInactiveFieldt)
        {
            Material cubeColourInactiveField = prefabSymbolPlayerMaterialInactiveField[0];
;           
            int maxIndexDepth = 1;
            int maxIndexColumn = tableWithSymbolsBase.GetLength(2);
            int maxIndexRow = tableWithSymbolsBase.GetLength(1);
            int numberForName = 0;

            float newCoordinateZ = 0;
            float fontSize = 0.45f;
            string frontTextToAdd = "ChooseSymbol_No_";
            string inactiveField = "-";
            string chosenPlayerSymbol;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWithSymbolsBase[indexDepth, indexRow, indexColumn];
                        string cubePlayText = CommonMethodsMain.GetCubePlayText(cubePlay);
                        CommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);

                        if (!cubePlayText.Equals(inactiveField))
                        {
                            CommonMethodsMain.ChangeTagForGameObject(cubePlay, tagConfigurationPlayerSymbolChooseSymbol);                                              
                        }
                        else
                        {
                            CommonMethodsMain.ChangeTagForGameObject(cubePlay, tagConfigurationBoardGameInactiveFieldt);
                            CommonMethodsMain.ChangeColourForGameObject(cubePlay, cubeColourInactiveField);
                            CommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        }

                        for (int i = 0; i < tableWitPlayersChosenSymbols.Length; i++)
                        {
                            chosenPlayerSymbol = tableWitPlayersChosenSymbols[i];

                            if (cubePlayText.Equals(chosenPlayerSymbol))
                            {
                                CommonMethodsMain.ChangeTagForGameObject(cubePlay, tagConfigurationBoardGameInactiveFieldt);
                                CommonMethodsMain.ChangeColourForGameObject(cubePlay, cubeColourInactiveField);
                                CommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                            }
                        }

                        numberForName = numberForName + 1;
                        string newName = frontTextToAdd + numberForName;
                        CommonMethodsMain.ChangeGameObjectName(cubePlay, newName);
                    }
                }
            }

            return tableWithSymbolsBase;
        }
    }
}
