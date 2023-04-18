using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CreateTable
{
    internal class CreateTableCommonMethods
    {

        public static float[] CreateTableWithCoordinatesZ()
        {
            //float[] table = new float[3];
            float[] table = new float[2];
            table[0] = -0.05f;
            table[1] = 0.05f;
            //table[2] = 1; and that is an interesting idea!
            return table;
        }


        /// <summary>
        /// <para> calculate length for all prefab in one line for X or Y or Z (number column, number rows) </para>
        /// <para> calculate length according to new scale </para>
        /// <para> number = numberOfRows or numberOfColumns </para>
        /// </summary>
        /// <param name="number"></param>
        /// <param name="newScale"></param>
        /// <returns></returns>
        public static float CalculateLengthForAllPrefabInOneLineXYZ(int number, float newScale)
        {
            float floatNumber = CommonMethods.ConvertIntToFloat(number);
            float lenght = floatNumber * newScale;
            return lenght;
        }

        /// <summary>
        /// <para> return the first position for X, Y, and Z for the first prefab, e.g. prefab "CubePlay"  </para>
        /// <para> e.g. prefab "CubePlay" - on the screen, the first cube/ square on the left down the bottom </para>
        /// </summary>
        /// <param name="lengthForAllPrefabCubePlayInOneLine"></param>
        /// <param name="startPositionXYZ"></param>
        /// <returns></returns>
        public static float PositionForFirstPrefab(double lengthForAllPrefabCubePlayInOneLine, float startPositionXYZ)
        {
            float floatNumber = PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(lengthForAllPrefabCubePlayInOneLine);
            float positionForFirstCubePlay = startPositionXYZ - floatNumber;
            return positionForFirstCubePlay;
        }



        public static float PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(double lengthForAllPrefabCubePlayInOneLine)
        {
            int round = 2;
            // default divide = 2 to find half of length, point [0,0] in Unity
            int divide = 2;
            double doubleNumber = PositionMinOrMaxXYZForCubePlayCalculate(lengthForAllPrefabCubePlayInOneLine, divide, round);
            //float floatNumber = CommonMethods.RoundAndConvertDoubleToFloat(doubleNumber, 6);
            float floatNumber = CommonMethods.RoundAndConvertDoubleToFloat(doubleNumber, round);
            return floatNumber;
        }

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

        /// <summary>
        /// <para> return the last position for X, Y, and Z for the last prefab, e.g. prefab "CubePlay" </para>
        /// <para> e.g. prefab "CubePlay" - on the screen, the first cube/ square on the right top </para>
        /// </summary>
        /// <param name="lengthForAllPrefabCubePlayInOneLine"></param>
        /// <returns></returns>
        public static float PositionForLastPrefab(double lengthForAllPrefabCubePlayInOneLine)
        {
            float positionForLastPrefab = PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(lengthForAllPrefabCubePlayInOneLine);
            return positionForLastPrefab;
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
        public static int[,,] CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI(int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            int[,,] PrefabCubePlayNumbers = new int[numberOfDepths, numberOfRows, numberOfColumns];
            int number = 0;

            for (int indexDepth = 0; indexDepth < numberOfDepths; indexDepth++)
            {

                for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < numberOfRows; indexRow++)
                    {
                        number = number + 1;
                        PrefabCubePlayNumbers[indexDepth, indexRow, indexColumn] = number;

                    }
                }
            }

            return PrefabCubePlayNumbers;
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
        /// <para> cubePlayDataLenght: </para>
        /// <para> lenght of array colour assigned to object "GameBoard" </para>
        /// <para> lenght of array with coordinates "Z" </para>
        /// <para> ----------------------------------------------------- </para>
        /// </summary>
        /// <param name="cubePlayDataLenght"></param>
        /// <param name="indexForPreviousColour"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="currentCountedNumberForCubeRows"></param>
        /// <param name="isNumberOfRowsEven"></param>
        /// <returns></returns>
        public static Tuple<int, int> GetNewCountedNumberForCubeRowsAndNewIndexForTheTableSetting(int cubePlayDataLenght, int indexForPreviousColour, int numberOfRows, int currentCountedNumberForCubeRows, bool isNumberOfRowsEven)
        {
            int maxIndexForCubePlayData = cubePlayDataLenght - 1;
            int newIndexForCubePlayData;

            int currentCountedNumberOfRows;

            if (indexForPreviousColour == 0)
            {

                if (currentCountedNumberForCubeRows == numberOfRows)
                {
                    currentCountedNumberOfRows = 1;

                    if (isNumberOfRowsEven == true)
                    {
                        newIndexForCubePlayData = indexForPreviousColour;
                    }
                    else
                    {
                        newIndexForCubePlayData = indexForPreviousColour + 1;
                    }

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayData, currentCountedNumberOfRows);
                    return newDataForCubePlayColour;

                }
                else
                {
                    currentCountedNumberOfRows = currentCountedNumberForCubeRows + 1;
                    newIndexForCubePlayData = indexForPreviousColour + 1;

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayData, currentCountedNumberOfRows);
                    return newDataForCubePlayColour;
                }
            }

            else if (indexForPreviousColour == maxIndexForCubePlayData)
            {

                if (currentCountedNumberForCubeRows == numberOfRows)
                {
                    currentCountedNumberOfRows = 1;

                    if (isNumberOfRowsEven == true)
                    {
                        newIndexForCubePlayData = indexForPreviousColour;
                    }
                    else
                    {
                        newIndexForCubePlayData = 0;
                    }

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayData, currentCountedNumberOfRows);
                    return newDataForCubePlayColour;

                }
                else
                {
                    currentCountedNumberOfRows = currentCountedNumberForCubeRows + 1;
                    newIndexForCubePlayData = 0;

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayData, currentCountedNumberOfRows);
                    return newDataForCubePlayColour;
                }

            }
            else if (indexForPreviousColour < maxIndexForCubePlayData)
            {

                if (currentCountedNumberForCubeRows == numberOfRows)
                {
                    currentCountedNumberOfRows = 0;

                    if (isNumberOfRowsEven == true)
                    {
                        newIndexForCubePlayData = indexForPreviousColour;
                    }
                    else
                    {
                        newIndexForCubePlayData = indexForPreviousColour + 1;
                    }

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayData, currentCountedNumberOfRows);
                    return newDataForCubePlayColour;
                }
                else
                {
                    currentCountedNumberOfRows = currentCountedNumberForCubeRows + 1;
                    newIndexForCubePlayData = indexForPreviousColour + 1;

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayData, currentCountedNumberOfRows);
                    return newDataForCubePlayColour;
                }
            }
            else
            {
                currentCountedNumberOfRows = 0;
                newIndexForCubePlayData = 0;

                var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayData, currentCountedNumberOfRows);
                return newDataForCubePlayColour;
            }
        }
    }
}
