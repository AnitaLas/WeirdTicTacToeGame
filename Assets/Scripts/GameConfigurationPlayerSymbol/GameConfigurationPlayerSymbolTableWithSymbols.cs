using Assets.Scripts.GameConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfigurationPlayerSymbol
{
    internal class GameConfigurationPlayerSymbolTableWithSymbols
    {

        public static GameObject[,,] CreateTableWithSymbols(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //Debug.Log(" 3 ");
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }

        public static string[,,] CreateTableForDefaultTextWithCharacters(string[] tableWithCharacters, int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];
            //string[] baseTable = table;
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

        public static GameObject[,,] ChangeDataForTableWithSymbols(GameObject[,,] tableWtithNumber, string tagConfigurationPlayerSymbolChooseSymbol, string tagConfigurationBoardGameInactiveFieldt)
        {
            Debug.Log(" test 1 ");
            int maxIndexDepth = 1;
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);

            string inactiveField = "-";

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
                        string cubePlayText = CommonMethods.GetCubePlayText(cubePlay);
                        Debug.Log("cubePlayText = " + cubePlayText);

                        if (!cubePlayText.Equals(inactiveField))
                        {
                            Debug.Log(" test 2 ");
                            CommonMethods.ChangeTagForGameObject(cubePlay, tagConfigurationPlayerSymbolChooseSymbol);
                        } 
                        else
                        {
                            Debug.Log(" test 3 ");
                            CommonMethods.ChangeTagForGameObject(cubePlay, tagConfigurationBoardGameInactiveFieldt);
                        }

                       
                       


                    }
                }
            }

            return tableWtithNumber;

        }





    }
}
