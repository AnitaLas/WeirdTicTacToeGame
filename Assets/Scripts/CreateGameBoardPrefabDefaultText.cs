using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{

    internal class CreateGameBoardPrefabDefaultText : MonoBehaviour
    {

        public static void SetUpDefaultTextForPrefaCubePlay(GameObject prefab, string prefabDefaultText)
        {
            var newPrefabCubePlayCanvas = prefab.transform.GetChild(0);
            var newPrefabCubePlayCanvasText = newPrefabCubePlayCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            newPrefabCubePlayCanvasText.text = prefabDefaultText;

        }

        /// <summary>
        /// <para> e.g. string = "ABCDEFGHI" </para>
        /// <para> table = { A, B, C, D, E, F, G, H, I} </para>
        /// <para>  |   A   |   B   |   C   |    D   |   E   |   F   |   G   |   H   |   I   | </para>
        /// </summary>
        /// <returns></returns>
        public static string[] CreateTableWithCharactersByGivenString()
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //string characters = "ABCD";
            int alphabetLenght = characters.Length;
            string[] allSeparatedCharacters = new string[alphabetLenght];

            for (int i = 0; i < alphabetLenght; i++)
            {
                string character = characters.Substring(i, 1);
                allSeparatedCharacters[i] = character;
            }

            return allSeparatedCharacters;
        }

        /// <summary>
        /// <para> e.g. for table 3x3 </para>
        /// <para> table = { 1, 2, 3, 4, 5, 6, 7, 8, 9} </para>
        /// <para>  |   1   |   2   |   3   |    4   |   5   |   6   |   7   |   8   |   9   | </para>
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static string[] CreateTableWithNumbersForPrefabCubePlay(int numberOfRows, int numberOfColumns)
        {
            int allNumbers = numberOfRows * numberOfColumns;
            string[] numbers = new string[allNumbers];
            string numberString;

            for (int number = 1; number <= allNumbers; number++)
            {
                numberString = CommonMethods.ConverIntToString(number);
                int indexNumber = number - 1;
                numbers[indexNumber] = numberString;
            }

            return numbers;
        }

        /// <summary>
        /// <para>It returns the difference (e.g. 4) between the numbers for rows given by the player (e.g. 30) 
        /// and the length for the string set in the method CreateTableWithCharactersByGivenString() (e.g. 26 lengths of the alphabet) </para>
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="tableWithCharacters"></param>
        /// <returns></returns>
        public static int ChecksDifferenceBetweenLengthOfTableWithCharactersAndNumberOfRows(int numberOfRows, string[] tableWithCharacters)
        {
            int tableCharacters = tableWithCharacters.Length;
            int result = numberOfRows - tableCharacters;
            return result;
        }

        /// <summary>
        /// <para> e.g. for table 3x3, string = "ABC" </para>
        /// <para>  table = { A, B, C, AA, BB, CC, DD, AAA, BBB } </para>
        /// <para>  |   A   |   B   |   C   |  AA  |  BB  |  CC  |  DD  |  AAA  |  BBB  | </para>
        /// </summary>
        /// <param name="baseTableWithCharacters"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static string[] CreateNewTableWithCharactersBasedOntheExistingTableWithCharacters(string[] baseTableWithCharacters, int numberOfRows, int numberOfColumns)
        {
            int newTableWithCharactersLenght = numberOfRows * numberOfColumns;
            int oldTableLenght = baseTableWithCharacters.Length;

            string[] oldTable = new string[oldTableLenght];
            string[] newTableWithCharacters = new string[newTableWithCharactersLenght];
            string[] newString = new string[oldTableLenght];

            int[] newStringIndex = new int[1];
            newStringIndex[0] = 0;
            int indexForNewString;

            int[] oldTableIndex = new int[1];
            oldTableIndex[0] = 0;
            int indexForOldTable;

            int[] indexForNewTableWithCharacters = new int[1];
            indexForNewTableWithCharacters[0] = 0;

            int indexBase;
            int indexNew;
            string baseText;
            string currentText;
            string newText;

            for (int i = 0; i < newTableWithCharactersLenght; i++)
            {
                indexForOldTable = oldTableIndex[0];
                indexForNewString = newStringIndex[0];

                if (i < (oldTableLenght - 1))
                {
                    newTableWithCharacters[i] = baseTableWithCharacters[i];
                    newString[i] = baseTableWithCharacters[i];
                    oldTable[i] = baseTableWithCharacters[i];

                    oldTableIndex[0] = oldTableIndex[0] + 1;
                    newStringIndex[0] = newStringIndex[0] + 1;
                }
                else if (i == oldTableLenght - 1)
                {
                    newTableWithCharacters[i] = baseTableWithCharacters[i];
                    newString[i] = baseTableWithCharacters[i];
                    oldTable[i] = baseTableWithCharacters[i];

                    oldTableIndex[0] = 0;
                    newStringIndex[0] = 0;
                }
                else
                {
                    if (indexForNewString < oldTableLenght - 1)
                    {
                        indexBase = oldTableIndex[0];
                        indexNew = newStringIndex[0];

                        baseText = oldTable[indexBase]; ;
                        currentText = newString[indexNew];
                        newText = baseText + currentText;

                        newString[indexNew] = newText;
                        newTableWithCharacters[i] = newText;

                        oldTableIndex[0] = oldTableIndex[0] + 1;
                        newStringIndex[0] = newStringIndex[0] + 1;
                    }
                    else
                    {
                        indexBase = oldTableIndex[0];
                        indexNew = newStringIndex[0];

                        baseText = oldTable[indexBase]; ;
                        currentText = newString[indexNew];
                        newText = baseText + currentText;

                        newString[indexNew] = newText;
                        newTableWithCharacters[i] = newText;

                        oldTableIndex[0] = 0;
                        newStringIndex[0] = 0;
                    }
                }
            }

            return newTableWithCharacters;
        }

        /// <summary>
        /// <para> e.g. for table 3x3, string = "ABCDEFGHI" </para>
        /// <para> table = { A, B, C, D, E, F, G, H, I} </para>
        /// <para>  |   A   |   B   |   C   |    D   |   E   |   F   |   G   |   H   |   I   | </para>
        /// <para> --------------------------------------------------------------------------- </para>
        /// <para> e.g. for table 3x3, string = "ABC" </para>
        /// <para>  table = { A, B, C, AA, BB, CC, DD, AAA, BBB } </para>
        /// <para>  |   A   |   B   |   C   |  AA  |  BB  |  CC  |  DD  |  AAA  |  BBB  | </para>
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static string[] CreateTableWithCharactersForPrefabCubePlay(int numberOfRows, int numberOfColumns)
        {
            string[] newTableWithCharacters = new string[numberOfRows];
            string[] tableWithCharacters = CreateTableWithCharactersByGivenString();
            int difference = ChecksDifferenceBetweenLengthOfTableWithCharactersAndNumberOfRows(numberOfRows, tableWithCharacters);

            if (difference <= 0)
            {
                return tableWithCharacters;
            }
            else
            {
                newTableWithCharacters = CreateNewTableWithCharactersBasedOntheExistingTableWithCharacters(tableWithCharacters, numberOfRows, numberOfColumns);
                return newTableWithCharacters;
            }
        }

        /// <summary>
        /// <para> e.g. for table 3x3 </para>
        /// <para>  |   A   |   A   |   A   | </para>
        /// <para>  |   B   |   B   |   B   | </para>
        /// <para>  |   C   |   C   |   C   | </para>
        /// <para> --------------------------- </para>
        /// <para>  string [,] text = { { A, A, A },    </para>
        /// <para>                      { B, B, B },    </para>
        /// <para>                      { C, C, C } };  </para>
        /// </summary>
        /// <param name="table"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static string[,] Create2DTableForDefaultTextWithCharacters(string[] table, int numberOfRows, int numberOfColumns)
        {
            string[,] newTable = new string[numberOfRows, numberOfColumns];
            int[] index = new int[1];
            index[0] = 0;
            int currentIndex;

            for (int indexRow = 0; indexRow < numberOfRows; indexRow++)
            {

                for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                {
                    currentIndex = index[0];
                    string stringAlphabet = table[indexRow];
                    string textForPrebaCubePlay = stringAlphabet;

                    newTable[indexRow, indexColumn] = textForPrebaCubePlay;
                    index[0] = index[0] + 1;

                }
            }

            return newTable;
        }


        /// <summary>
        /// <para> e.g. for table 3x3 </para> 
        /// <para>  |   1   |   2   |   3   | </para>
        /// <para>  |   1   |   2   |   3   | </para>
        /// <para>  |   1   |   2   |   3   | </para>
        /// <para> --------------------------- </para>
        /// <para>  string [,] text = { { 1, 2, 3 },    </para>
        /// <para>                      { 1, 2, 3 },    </para>
        /// <para>                      { 1, 2, 3 } };  </para>
        /// </summary>
        /// <param name="table"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static string[,] Create2DTableForDefaultTextWithNumbers(string[] table, int numberOfRows, int numberOfColumns)
        {
            string[,] newTable = new string[numberOfRows, numberOfColumns];
            int[] index = new int[1];
            index[0] = 0;
            int currentIndex;

            for (int indexRow = 0; indexRow < numberOfRows; indexRow++)
            {

                for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                {
                    currentIndex = index[0];
                    string stringAlphabet = table[indexColumn];
                    string textForPrebaCubePlay = stringAlphabet;

                    newTable[indexRow, indexColumn] = textForPrebaCubePlay;
                    index[0] = index[0] + 1;

                }
            }

            return newTable;
        }

        /// <summary>
        /// <para> e.g. for table 3x3 </para> 
        /// <para>  |   A1   |   A2   |   A3   | </para>
        /// <para>  |   B1   |   B2   |   B3   | </para>
        /// <para>  |   C1   |   C2   |   C3   | </para>
        /// <para> --------------------------- </para>
        /// <para>  string [,] text = { { A1, A2, A3 },    </para>
        /// <para>                      { B1, B2, B3 },    </para>
        /// <para>                      { C1, C2, C3 } };  </para>
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static string[,] CreateTableWithTextForPrefabCubePlay(int numberOfRows, int numberOfColumns)
        {
            string[,] newTable = new string[numberOfRows, numberOfColumns];
            string[] alphabet = CreateTableWithCharactersForPrefabCubePlay(numberOfRows, numberOfColumns);
            string[] numbers = CreateTableWithNumbersForPrefabCubePlay(numberOfRows, numberOfColumns);

            string[,] alphabet2D = Create2DTableForDefaultTextWithCharacters(alphabet, numberOfRows, numberOfColumns);
            string[,] numbers2D = Create2DTableForDefaultTextWithNumbers(numbers, numberOfRows, numberOfColumns);

            for (int indexRow = 0; indexRow < numberOfRows; indexRow++)
            {

                for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                {
                    string stringNumber = numbers2D[indexRow, indexColumn];
                    string stringAlphabet = alphabet2D[indexRow, indexColumn];
                    string textForPrebaCubePlay = stringAlphabet + stringNumber;

                    newTable[indexRow, indexColumn] = textForPrebaCubePlay;
                }
            }

            return newTable;
        }

        public static string SetUpNewDefaultTextForPrefaCubePlay(int[,] prefabCubePlayNumbers, string[,] defaultTextForPrefabCubePlay, int currentNumberForPrefabCubePlay)
        {
            var cublePlayindexRowY = CreateGameBoardMethods.GetIndexXYForPrefaCubePlay(prefabCubePlayNumbers, currentNumberForPrefabCubePlay);
            int cubePlayindexRow = cublePlayindexRowY.Item1;
            int cubePlayindexColumn = cublePlayindexRowY.Item2;

            string defaultText = defaultTextForPrefabCubePlay[cubePlayindexRow, cubePlayindexColumn];
            return defaultText;

        }

    }

}
