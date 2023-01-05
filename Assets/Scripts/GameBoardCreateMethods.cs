//using Fare;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    internal class GameBoardCreateMethods
    {
        // --------------------------------------------------------------------
        // GameBoardCreate - start

        /// <summary>
        /// <para> Calculate the min X or Y or Z for first prefab "cubePlay" </para>
        /// <para> Calculate the max X or Y or Z for last prefab "cubePlay" </para>
        /// <para> e.g  number = 14, device = 34, round = 2, result = 0,411</para>
        /// </summary>
        /// <param name="number"></param>
        /// <param name="devide"></param>
        /// <param name="round"></param>
        /// <returns></returns>

        public static double PositionMinOrMaxXYZForCubePlayCalculate(double number, int devide, int round)
        {
            double result = number / devide;
            double roundedNumber = Math.Round(result, round);
            return roundedNumber;
        }

        public static float PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(double number)
        {
            int round = 2;
            int devide = 2;
            double doubleNumber = PositionMinOrMaxXYZForCubePlayCalculate(number, devide, round);
            float floatNumber = CommonMethods.ConvertDoubleToFloat(doubleNumber);
            return floatNumber;         
        }

        /// <summary>
        /// <para> prefab = CubePlay </para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float PositionForFirstPrefab(double number, float startPositionXYZ)
        {
            float floatNumber = PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(number);
            float positionForFirstCubePlay = startPositionXYZ - floatNumber;
            return positionForFirstCubePlay;
        }

        /// <summary>
        /// <para> prefab = CubePlay </para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float PositionForLastPrefab(double number)
        {
            float positionForLastPrefab = PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(number);
            return positionForLastPrefab;
        }


        public static float CalculateLengthForAllPrefabInOneLineXYZ(int number, float scale)
        {
            float floatNumber = CommonMethods.ConvertIntToFloat(number); 
            float lenght = floatNumber * scale;
            return lenght;
        }

        public static float StartPositionXYZ(float newScale)
        {
            float startPositionXYZ = newScale / 2;
            return startPositionXYZ;
        }

        // GameBoardCreate - end
        // --------------------------------------------------------------------


        // --------------------------------------------------------------------
        // GameBoardCreateScale - start

        /// <summary>
        /// <para> default scale for X or Y or Z </para>
        /// <para> prefab "CubePlay" max number for X or Y or Z -> set by default </para>
        /// <para> numbers prefabs "CubePlay" for X or Y or Z -> given by user </para>
        /// </summary>
        /// <param name="defaultScaleForXYZ"></param>
        /// <param name="cubePlayMaxNumberForXYZ"></param>
        /// <param name="numbersCubePlayForXYZ"></param>
        /// <returns></returns>
        public static double CalculateNewScaleForPrefab(double defaultScaleForXYZ, double cubePlayMaxNumberForXYZ, double numbersCubePlayForXYZ)
        {
            double resut = (defaultScaleForXYZ * numbersCubePlayForXYZ) / cubePlayMaxNumberForXYZ;
            int numberAfterDecimal = 1;
            double newScale = CommonMethods.RoundDownWithDecimal(resut, numberAfterDecimal);
            return newScale;
        }


        public static float FindSmallestScaleXYZForPrefabCubePlay(float[] newScaleForXYZ, double numbersCubesForWidthX, double numbersCubesForHeightY)
        {
            float newScaleForXYZLenght = newScaleForXYZ.Length;

            float maxValue = 10000;
            float[] newScaleForPrefabCubePlay = { maxValue };

            if (numbersCubesForWidthX != 4 || numbersCubesForHeightY != 6)
            {
                for (int i = 0; i < newScaleForXYZLenght; i++)
                {
                    if (newScaleForXYZ[i] < newScaleForPrefabCubePlay[0])
                    {
                        newScaleForPrefabCubePlay[0] = newScaleForXYZ[i];
                    }
                }
            }
            else
            {
                newScaleForPrefabCubePlay[0] = newScaleForXYZ[0];
            }

            float newScale = newScaleForPrefabCubePlay[0];
            return newScale;
        }

        // GameBoardCreateScale - end
        // --------------------------------------------------------------------


        // --------------------------------------------------------------------
        // GameBoardCreateChangeText - start

        public static string[]  CreateTableWithCharactersByGivenString()
        {
            //string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string characters = "ABCD";
            int alphabetLenght = characters.Length;
            string[] allSeparatedCharacters = new string[alphabetLenght];
            
            for (int i = 0; i < alphabetLenght; i++)
            {
               string character = characters.Substring(i, 1);
                allSeparatedCharacters[i] = character;
            }

            return allSeparatedCharacters;
        }


        public static string[] CreateTableWithNumbersForPrefabCubePlay(int numbersCubesForWidthX, int numbersCubesForHeightY)
        {
            int allNumbers = numbersCubesForWidthX * numbersCubesForHeightY;
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

        public static int ChecksDifferenceBetweenLengthOfTableWithCharactersAndNumbersCubesForWidthX(int numbersCubesForWidthX, string[] tableWithCharacters)
        {
            int tableCharacters = tableWithCharacters.Length;
            int result = numbersCubesForWidthX - tableCharacters;
            //int resultAbs = Math.Abs(result);
            return result;
        }

        public static string[] CreateNewTableWithCharactersBasedOntheExistingTableWithCharacters(string[] oldTableWithCharacters, int numbersCubesForWidthX, int numbersCubesForHeightY)
        {
            int newTableWithCharactersLenght = numbersCubesForWidthX * numbersCubesForHeightY;
           
            int oldTableLenght = oldTableWithCharacters.Length;
            Debug.Log("oldTableLenght: " + oldTableLenght);

            string[] oldTable = new string[oldTableLenght];
            string[] newTableWithCharacters = new string[newTableWithCharactersLenght];

            string[] newString = new string[oldTableLenght];

            int[] newStringIndex = new int[1];
            newStringIndex[0] = 0;
            int indexForNewString;
            //indexForNewStrong = newStringIndex[0];

            int[] oldTableIndex = new int[1];
            oldTableIndex[0] = 0;
            int indexForOldTable;
            //indexForOldTable = oldTableIndex[0];

            /*
            int[] indexNumberCubesForWidthX = new int[1];
            indexNumberCubesForWidthX[0] = 0;
            int indexNumber;
            indexNumber = indexNumberCubesForWidthX[0];
            */

            int[] indexForNewTableWithCharacters = new int[1];
            indexForNewTableWithCharacters[0] = 0;
            //int indexForNewCharacter;
            // indexForNewCharacter = indexForNewTableWithCharacters[0];

            int indexOld;
            int indexNew;
            string oldText;
            string currentText;
            string newText;

            for (int i = 0; i < newTableWithCharactersLenght; i++)
            {
                indexForOldTable = oldTableIndex[0];
                //indexForNewCharacter = indexForNewTableWithCharacters[0];
                indexForNewString = newStringIndex[0];
                //Debug.Log("indexForNewString: " + indexForNewString);

                //     if (i < (oldTableLenght - 1))

                if (i < (oldTableLenght - 1))
                {
                    newTableWithCharacters[i] = oldTableWithCharacters[i];
                    newString[i] = oldTableWithCharacters[i];
                    oldTable[i] = oldTableWithCharacters[i];

                    oldTableIndex[0] = oldTableIndex[0] + 1;
                    newStringIndex[0] = newStringIndex[0] + 1;
                    //indexForNewTableWithCharacters[0] = indexForNewTableWithCharacters[0] + 1;
                }
                
                else if (i == oldTableLenght - 1)
                {
                    newTableWithCharacters[i] = oldTableWithCharacters[i];
                    newString[i] = oldTableWithCharacters[i];
                    oldTable[i] = oldTableWithCharacters[i];

                    oldTableIndex[0] = 0;
                    newStringIndex[0] = 0;
                }
                
                else
                {
                    if (indexForNewString < oldTableLenght - 1)
                    {
                        indexOld = oldTableIndex[0];
                        indexNew = newStringIndex[0];
                        //Debug.Log($"IF indexNew newStringIndex[{i}] = " + newStringIndex[i]);

                        oldText = oldTable[indexOld]; ;
                        currentText = newString[indexNew];
                        newText = oldText + currentText;

                        newString[indexNew] = newText;
                        newTableWithCharacters[i] = newText;

                        //Debug.Log($"IF newText newTableWithCharacters[{i}] = " + newTableWithCharacters[i]);

                        oldTableIndex[0] = oldTableIndex[0] + 1;
                        newStringIndex[0] = newStringIndex[0] + 1;
                    } 
                    else
                    {
                        indexOld = oldTableIndex[0];
                        indexNew = newStringIndex[0];
                        //Debug.Log($"ELSE indexNew newStringIndex[{i}] = " + newStringIndex[i]);

                        oldText = oldTable[indexOld]; ;
                        currentText = newString[indexNew];
                        newText = oldText + currentText;

                        newString[indexNew] = newText;
                        newTableWithCharacters[i] = newText;

                        oldTableIndex[0] = 0;
                        newStringIndex[0] = 0;
                    }


                    /*
                     oldText = oldTable[indexOld];;
                     currentText = newString[indexNew];
                     newText = oldText + currentText;

                    newTableWithCharacters[i] = newText;
                    */
                    //oldTableIndex[0] = oldTableIndex[0] + 1;
                    //indexForNewTableWithCharacters[0] = indexForNewTableWithCharacters[0] + 1;
                }













                /*
                if (oldTableLenght == numbersCubesForWidthX - index)
                {

                    newTableWithCharacters[i] = oldTableWithCharacters[index];
                    oldTableIndex[0] = 0;
                    indexNumberCubesForWidthX[0] = indexNumberCubesForWidthX[0] + 1;
                }
                else
                {
                    if (i < oldTableLenght)
                    {
                        newTableWithCharacters[i] = oldTableWithCharacters[index];
                        newString[i] = oldTableWithCharacters[index];

                        oldTableIndex[0] = oldTableIndex[0] + 1;
                        indexNumberCubesForWidthX[0] = indexNumberCubesForWidthX[0] + 1;
                    }
                    else
                    {
                        newTableWithCharacters[i] = oldTableIndex[i] + newString[i];
                        //oldTableIndex[0] = oldTableIndex[0] + 1;
                        indexNumberCubesForWidthX[0] = indexNumberCubesForWidthX[0] + 1;
                    }

                    //newTableWithCharacters[i] = oldTableWithCharacters[index];
                    oldTableIndex[0] = oldTableIndex[0] + 1;
                    indexNumberCubesForWidthX[0] = indexNumberCubesForWidthX[0] + 1;
                }
                */
                /*
                if (oldTableLenght <= numbersCubesForWidthX - indexNumber)
                {
                    if (oldTableLenght == numbersCubesForWidthX - index)
                    {
                        newTableWithCharacters[i] = oldTableWithCharacters[index];
                        oldTableIndex[0] = 0;
                        indexNumberCubesForWidthX[0] = indexNumberCubesForWidthX[0] + 1;
                    }
                    else
                    {
                        newTableWithCharacters[i] = oldTableWithCharacters[index];
                        oldTableIndex[0] = oldTableIndex[0] + 1;
                        indexNumberCubesForWidthX[0] = indexNumberCubesForWidthX[0] + 1;
                    }
                }
                else
                {
                    if (oldTableLenght == numbersCubesForWidthX - index)
                    {
                        string newText = oldTableWithCharacters[index] + oldTableWithCharacters[index];
                        newTableWithCharacters[i] = newText;
                        oldTableIndex[0] = 0;
                        indexNumberCubesForWidthX[0] = indexNumberCubesForWidthX[0] + 1;
                    }
                    else
                    {
                        string newText = oldTableWithCharacters[index] + oldTableWithCharacters[index];
                        newTableWithCharacters[i] = newText;
                        oldTableIndex[0] = oldTableIndex[0] + 1;
                        indexNumberCubesForWidthX[0] = indexNumberCubesForWidthX[0] + 1;
                    }
                }
                */
            }
           // Debug.Log("-------------------------------: ");
            /*
            for (int i = 0; i < newString.Length; i++)
            {
                Debug.Log($"newString[{i}] = " + newString[i]);
            }
            */
           // Debug.Log("-------------------------------: ");
           // Debug.Log("-------------------------------: ");

            /*
            for (int i = 0; i < newTableWithCharacters.Length; i++)
            {
                Debug.Log($"numbersCubesForWidthX[{i}] = " + newTableWithCharacters[i]);
            }
            */





            return newTableWithCharacters;
        }


        public static string[] CreateTableWithCharactersForPrefabCubePlay(int numbersCubesForWidthX, int numbersCubesForHeightY)
        {
            string[] newTableWithCharacters = new string[numbersCubesForWidthX];
            string[] tableWithCharacters = CreateTableWithCharactersByGivenString();
            int difference = ChecksDifferenceBetweenLengthOfTableWithCharactersAndNumbersCubesForWidthX(numbersCubesForWidthX, tableWithCharacters);

            if (difference <= 0 )
            {
                return tableWithCharacters;
            }
            else
            {
                newTableWithCharacters = CreateNewTableWithCharactersBasedOntheExistingTableWithCharacters(tableWithCharacters, numbersCubesForWidthX, numbersCubesForHeightY);
                return newTableWithCharacters;
            }
        }


        public static string [,] CreateTableWithTextForPrefabCubePlay(int numbersCubesForWidthX, int numbersCubesForHeightY)
        {
            string[,] tableWithText = new string[numbersCubesForWidthX, numbersCubesForHeightY];
            string[] alphabet = CreateTableWithCharactersForPrefabCubePlay(numbersCubesForWidthX, numbersCubesForHeightY);
            string[] numbers = CreateTableWithNumbersForPrefabCubePlay(numbersCubesForWidthX, numbersCubesForHeightY);
            int[] indexForNumbers = new int[1];
            indexForNumbers[0] = 0;
            int indexForNumber;

            /*
            for (int i = 0; i < alphabet.Length; i++)
            {
                Debug.Log($"numbersCubesForWidthX[{i}] = " + alphabet[i]);
            }
            */
            //Debug.Log($"------------------------------------------------------ ");
            /*
            for (int i = 0; i < numbers.Length; i++)
            {
                Debug.Log($"numbers[{i}] = " + numbers[i]);
            }
            */
            /*
              numbersCubesForHeightY
             numbersCubesForWidthX
             */
            int indexStaticForX = 0;

            for (int indexX = 0; indexX < numbersCubesForWidthX; indexX++)
            {
                // for (int indexY = numbersCubesForHeightY - 1; indexY >= 0; indexY--)

                for (int indexY = 0; indexY < numbersCubesForHeightY; indexY++)
                {
                    indexForNumber = indexForNumbers[0];
                    //string stringNumber = numbers[indexForNumber];
                    string stringAlphabet = alphabet[indexForNumber];
                    //string textForPrebaCubePlay = stringAlphabet + stringNumber;
                    string textForPrebaCubePlay = stringAlphabet;

                    //tableWithText[indexX, indexY] = textForPrebaCubePlay;
                    //Debug.Log($"tableWithText[{indexX}, {indexY}]: " + tableWithText[indexX, indexY]);

                    tableWithText[indexStaticForX, indexY] = textForPrebaCubePlay;
                    Debug.Log($"tableWithText[{indexStaticForX}, {indexY}]: " + tableWithText[indexStaticForX, indexY]);

                    indexForNumbers[0] = indexForNumbers[0] + 1;

                }
            }
            
            return tableWithText;

        }


        






        // GameBoardCreateChangeText - end
        // --------------------------------------------------------------------
    }
}
