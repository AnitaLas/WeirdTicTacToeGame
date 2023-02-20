//using Fare;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts   
{

    internal class CreateGameBoardMethods : MonoBehaviour
    {

        /// <summary>
        /// <para> e.g. string = "ABCDEFGHI" </para>
        /// <para> table = { A, B, C, D, E, F, G, H, I} </para>
        /// <para>  |   A   |   B   |   C   |    D   |   E   |   F   |   G   |   H   |   I   | </para>
        /// </summary>
        /// <returns></returns>
        public static string[] CreateTableWithCharactersByGivenString()
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //string characters = "ABC";
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
            //int indexForOldTable;

            int[] indexForNewTableWithCharacters = new int[1];
            indexForNewTableWithCharacters[0] = 0;

            int indexBase;
            int indexNew;
            string baseText;
            string currentText;
            string newText;

            for (int i = 0; i < newTableWithCharactersLenght; i++)
            {
                //indexForOldTable = oldTableIndex[0];
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
        /// <para>  |   A   |   B   |   C   | </para>
        /// <para>  |   A   |   B   |   C   | </para>
        /// <para>  |   A   |   B   |   C   | </para>
        /// <para> --------------------------- </para>
        /// <para>  string [,] text = { { A, B, C },    </para>
        /// <para>                      { A, B, C },    </para>
        /// <para>                      { A, B, C } };  </para>
        /// </summary>
        /// <param name="table"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static string[,,] CreateTableForDefaultTextWithCharacters(string[] table, int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];
            string[] baseTable = table;

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

                        string stringAlphabet = baseTable[currentIndex];
                        string textForPrebaCubePlay = stringAlphabet;
                        newTable[indexDepth, indexRow, indexColumn] = textForPrebaCubePlay;

                        index[0] = index[0] + 1;
                    }

                    index[0] = 0;
                }
            }

            return newTable;
        }


        /// <summary>
        /// <para> e.g. for table 3x3 </para> 
        /// <para>  |   1   |   1   |   1   | </para>
        /// <para>  |   2   |   2   |   2   | </para>
        /// <para>  |   3   |   3   |   3   | </para>
        /// <para> --------------------------- </para>
        /// <para>  string [,] text = { { 1, 1, 1 },    </para>
        /// <para>                      { 2, 3, 3 },    </para>
        /// <para>                      { 3, 3, 3 } };  </para>
        /// </summary>
        /// <param name="table"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
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
                    currentIndex = index[0];

                    for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                    {
                        string stringAlphabet = table[currentIndex];
                        string textForPrebaCubePlay = stringAlphabet;
                        newTable[indexDepth, indexRow, indexColumn] = textForPrebaCubePlay;
                    }

                    index[0] = index[0] + 1;
                }

                index[0] = 0;
            }

            return newTable;
        }

        /// <summary>
        /// <para> e.g. for table 3x3 </para> 
        /// <para>  |   A1   |   B1   |   C1   | </para>
        /// <para>  |   A1   |   B2   |   C2   | </para>
        /// <para>  |   A1   |   B2   |   C3   | </para>
        /// <para> --------------------------- </para>
        /// <para>  string [,] text = { { A1, A2, A3 },    </para>
        /// <para>                      { B1, B2, B3 },    </para>
        /// <para>                      { C1, C2, C3 } };  </para>
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static string[,,] CreateTableWithTextForPrefabCubePlay(int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];

            string[] alphabet = CreateTableWithCharactersForPrefabCubePlay(numberOfRows, numberOfColumns);
            string[] numbers = CreateTableWithNumbersForPrefabCubePlay(numberOfRows, numberOfColumns);

            string[,,] alphabet3D = CreateTableForDefaultTextWithCharacters(alphabet, numberOfDepths, numberOfRows, numberOfColumns);
            string[,,] numbers3D = CreateTableForDefaultTextWithNumbers(numbers, numberOfDepths, numberOfRows, numberOfColumns);

            for (int indexDepth = 0; indexDepth < numberOfDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < numberOfRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                    {
                        string stringNumber = numbers3D[indexDepth, indexRow, indexColumn];
                        string stringAlphabet = alphabet3D[indexDepth, indexRow, indexColumn];
                        string textForPrebaCubePlay = stringAlphabet + stringNumber;

                        newTable[indexDepth, indexRow, indexColumn] = textForPrebaCubePlay;
                    }
                }
            }

            return newTable;
        }
























        // it can be remove in future - rong interpretation
        /// <summary>
        /// <para> create table for board game - for logic </para>
        /// <para> create the table which is identictal as is create in logic </para>
        /// GameBoardCreate line 54 int[,] tableForBoardGame
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static Tuple<int, int, int> GetXYZForTable3DForBoardGame(int numberOfDepths, int numberOfRows, int numberOfColumns, int currentNumberOfDepth, int currentNumberOfRow, int currentNumberOfColumn)
        {

            int[,,] gameBoard = new int[numberOfDepths, numberOfRows, numberOfColumns];

            int newNumberOfRow;
            int newNumberOfColumn;
            int newNumberOfDepth = numberOfDepths;

            if (currentNumberOfRow + numberOfRows - 1 > numberOfRows - currentNumberOfRow)
            {
                newNumberOfRow = Math.Abs(currentNumberOfRow - 1);
                newNumberOfColumn = currentNumberOfColumn;
                newNumberOfDepth = currentNumberOfDepth;

                var newXYZ = Tuple.Create(newNumberOfDepth, newNumberOfRow, newNumberOfColumn);
                return newXYZ;
            }

            else // if(currentNumberOfColumn == numberOfColumns - 1)
            {
                if (currentNumberOfColumn < numberOfColumns - 1)
                {
                    newNumberOfRow = numberOfRows - 1;
                    newNumberOfColumn = currentNumberOfColumn + 1;
                    newNumberOfDepth = currentNumberOfDepth;

                    var newXYZ = Tuple.Create(newNumberOfDepth, newNumberOfRow, newNumberOfColumn);
                    return newXYZ;
                }
                //else if(currentNumberOfColumn == numberOfColumns)
                else
                {
                    newNumberOfRow = numberOfRows - 1;
                    newNumberOfColumn = currentNumberOfColumn + 1;
                    newNumberOfDepth = currentNumberOfDepth;

                    var newXYZ = Tuple.Create(newNumberOfDepth, newNumberOfRow, newNumberOfColumn);
                    return newXYZ;


                    /*  for 3D need to be added
                    if (currentNumberOfDepth < numberOfDepths - 1)
                    {
                        newNumberOfRow = 0;
                        newNumberOfColumn = 0;
                        newNumberOfDepth = currentNumberOfDepth + 1;

                        var newXYZ = Tuple.Create(newNumberOfRow, newNumberOfColumn, newNumberOfDepth);
                        return newXYZ;
                    }
                   // else if (currentNumberOfDepth == numberOfDepths)
                   else
                    {
                        newNumberOfRow = 0;
                        newNumberOfColumn = 0;
                        newNumberOfDepth = 0;
                        var newXYZ = Tuple.Create(newNumberOfRow, newNumberOfColumn, newNumberOfDepth);
                        return newXYZ;
                    }
                    */

                }
            }
        }

       
    }
}
