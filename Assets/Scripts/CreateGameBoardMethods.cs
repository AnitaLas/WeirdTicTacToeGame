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
    internal class CreateGameBoardMethods
    {
        // --------------------------------------------------------------------
        // GameBoardCreate - start

        /// <summary>
        /// <para> Calculate the min X or Y or Z for first prefab "cubePlay" </para>
        /// <para> Calculate the max X or Y or Z for last prefab "cubePlay" </para>
        /// <para> e.g  number = 14, device = 34, round = 2, result = 0,411</para>
        /// </summary>
        /// <param name="lengthForAllPrefabCubePlayInOneLine"></param>
        /// <param name="divide"></param>
        /// <param name="round"></param>
        /// <returns></returns>

        public static double PositionMinOrMaxXYZForCubePlayCalculate(double lengthForAllPrefabCubePlayInOneLine, int divide, int round)
        {
            double result = lengthForAllPrefabCubePlayInOneLine / divide;
            double roundedNumber = Math.Round(result, round);
            return roundedNumber;
        }

        public static float PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(double lengthForAllPrefabCubePlayInOneLine)
        {
            int round = 2;
            // default divide = 2 to find half of length, point [0,0] in Unity
            int divide = 2;
            double doubleNumber = PositionMinOrMaxXYZForCubePlayCalculate(lengthForAllPrefabCubePlayInOneLine, divide, round);
            float floatNumber = CommonMethods.ConvertDoubleToFloat(doubleNumber);
            return floatNumber;         
        }

        /// <summary>
        /// <para> return the first position for X, Y, and Z for the first prefab, e.g. prefab "CubePlay"  </para>
        /// <para> e.g. prefab "CubePlay" - on the screen, the first cube/ square on the left down the bottom </para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float PositionForFirstPrefab(double lengthForAllPrefabCubePlayInOneLine, float startPositionXYZ)
        {
            float floatNumber = PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(lengthForAllPrefabCubePlayInOneLine);
            float positionForFirstCubePlay = startPositionXYZ - floatNumber;
            return positionForFirstCubePlay;
        }

        /// <summary>
        /// <para> return the last position for X, Y, and Z for the last prefab, e.g. prefab "CubePlay" </para>
        /// <para> e.g. prefab "CubePlay" - on the screen, the first cube/ square on the right top </para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float PositionForLastPrefab(double lengthForAllPrefabCubePlayInOneLine)
        {
            float positionForLastPrefab = PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(lengthForAllPrefabCubePlayInOneLine);
            return positionForLastPrefab;
        }

        /// <summary>
        /// <para> calculate length for all prefab in one line for X or Y or Z (number column, number rows) </para>
        /// <para> calculate length according to new scale </para>
        /// <para> number = numberOfRows or numberOfColumns </para>
        /// </summary>
        /// <param name="number"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static float CalculateLengthForAllPrefabInOneLineXYZ(int number, float newScale)
        {
            float floatNumber = CommonMethods.ConvertIntToFloat(number); 
            float lenght = floatNumber * newScale;
            return lenght;
        }

        /// <summary>
        /// <para> calculate data for first prefab "CubaPlay" X and Y and Z </para>
        /// </summary>
        /// <param name="newScale"></param>
        /// <returns></returns>
        public static float StartPositionXYZ(float newScale)
        {
            float startPositionXYZ = newScale / 2;
            return startPositionXYZ;
        }

        /// <summary>
        /// <para> set the new number for current number -> GameBoardCreate </para>
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <returns></returns>
        public static int SetUpNewNumberForCurrentNumber(int currentNumber)
        {
            int newNumbersCubePlayName = currentNumber + 1;
            return newNumbersCubePlayName;
        }

        /// <summary>
        /// <para> currentNumberForPrefabCubePlay = number created for prefab "Cube Play" from the table created by CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI() </para>
        /// <para> table2D = CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI() </para>
        /// <para> it is returned the indexRow and indexColumn for the 2D array [X, Y] / [indexRow, indexColumn] as it is in the regular 2D array</para>
        /// </summary>
        /// <param name="table2D"></param>
        /// <param name="currentNumberForPrefabCubePlay"></param>
        /// <returns></returns>
        public static Tuple<int, int> GetIndexXYForPrefaCubePlay(int[,] table2D, int currentNumberForPrefabCubePlay)
        {
            int cubePlayIndexRow;
            int cubePlayIndexColumn;

            int lenghtForX = table2D.GetLength(0);
            int lenghtForY = table2D.GetLength(1);

            for (int indexColumn = 0; indexColumn < lenghtForY; indexColumn++)
            {
                for (int indexRow = 0; indexRow < lenghtForX; indexRow++)
                {
                    if (table2D[indexRow, indexColumn].Equals(currentNumberForPrefabCubePlay))
                    {
                        cubePlayIndexRow = indexRow;
                        cubePlayIndexColumn = indexColumn;
                        return Tuple.Create(cubePlayIndexRow, cubePlayIndexColumn);
                    }
                }
            }

            return Tuple.Create(0, 0);

        }


        /// <summary>
        /// <para> cubes/ squares are created from the left bottom to the right top in the UI</para>
        /// <para> e.g. board game 3x3, numbers assigned to cube </para>
        /// <para>  |   3   |   6   |   9   | </para>
        /// <para>  |   2   |   5   |   8   | </para>
        /// <para>  |   1   |   4   |   7   | </para>
        /// <para> --------------------------- </para>
        /// <para>  int [,] numbers = { { 3, 6, 9 },    </para>
        /// <para>                      { 2, 5, 8 },    </para>
        /// <para>                      { 1, 4, 7 } };  </para>
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static int[,] CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI(int numberOfRows, int numberOfColumns)
        {

            int[,] PrefabCubePlayNumbers = new int[numberOfRows, numberOfColumns];
            int number = 0;

            for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
            {
                for (int indexRow = numberOfRows - 1; indexRow >= 0; indexRow--)
                {
                    number = number + 1;
                    PrefabCubePlayNumbers[indexRow, indexColumn] = number;
                }
            }

            return PrefabCubePlayNumbers;
        }
















        /// <summary>
        /// <para> create 2D table for board game - for logic </para>
        /// <para> create the table which is identictal as is create in logic </para>
        /// GameBoardCreate line 54 int[,] tableForBoardGame
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static int[,] Create2DTableForBoardGame(int numberOfRows, int numberOfColumns)
        {

            int[,] PrefabCubePlayNumbers = new int[numberOfRows, numberOfColumns];

            for (int indexRow = 0; indexRow < numberOfRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                {
                    
                }
            }

            return PrefabCubePlayNumbers;
        }

    }
}
