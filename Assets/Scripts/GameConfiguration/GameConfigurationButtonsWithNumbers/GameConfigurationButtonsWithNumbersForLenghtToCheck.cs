using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsWithNumbersForLenghtToCheck : MonoBehaviour
    {

        public static GameObject[,,] CreateTableForMaxLenghtToCheck(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField, int lenghtToCheckMax)
        {
            GameObject[,,] table;
            int start = 2;
            int end = lenghtToCheckMax;
            float newCoordinateY = 0f;
            string inactiveText = "-";

            table = GameConfigurationButtonsWithNumbersCommonMethods.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
            return table;
        }

        public static GameObject[,,] CreateTableForLenghtToCheck(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, int lenghtToCheckMax, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            string tagConfigurationBoardGameTableNumberLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableLenghtToCheck();
            string tagConfigurationBoardGameInactiveField = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInactiveField();

            var numbers = ScreenVerificationMethods.GetNumberOfRowsAndColumnsForDefaulTableWithNumber(isCellphoneMode);
            int numberOfDepths = 1;
            int numberOfRows = numbers.Item1;
            int numberOfColumns = numbers.Item2;

            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = CreateTableForMaxLenghtToCheck(tableWithNumbers, tagConfigurationBoardGameTableNumberLenghtToCheck, tagConfigurationBoardGameInactiveField, lenghtToCheckMax);

            return tableWithNumberFinal;
        }

        public static int GetLenghtToCheckMax()
        {
            int[] numbers = GameConfigurationButtonsCommonMethodsForButtonsWithNumberForLenghtToChcekAndGaps.GetCurrentRowsAndColumnsNumber();
            int rows = numbers[0];
            int columns = numbers[1];

            int maxNumberInt = GameCommonMethodsMain.GetLowerNumber(rows, columns);

            return maxNumberInt;
        }


        public static void VerifyAndSetUpLenghtToCheck()
        {
            int lowerNumberBetweenRowsNumberAndColumnsNumber = GameConfigurationButtonsCommonMethodsForButtonsWithNumberForLenghtToChcekAndGaps.GetLowerNumberBetweenRowsNumberAndColumnsNumber();
            int currentLenghtToCheck = GetCurrentLengthToCheckNumber();

            if (lowerNumberBetweenRowsNumberAndColumnsNumber < currentLenghtToCheck)
            {
                string defaulNumber = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonNumberForLenghtToCheck();
                GameObject gameObject = GetObjectLenghToCheck();
                GameCommonMethodsMain.ChangeTextForFirstChild(gameObject, defaulNumber);
            }
        }

        public static GameObject GetObjectLenghToCheck()
        {
            string tagConfigurationBoardGameChangeNumberLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberLenghtToCheck();
            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(tagConfigurationBoardGameChangeNumberLenghtToCheck);
            return gameObject;
        }

        public static int GetCurrentLengthToCheckNumber()
        {
            string tagConfigurationBoardGameChangeNumbeLengthToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberLenghtToCheck();
            int number = GameConfigurationButtonsCommonMethodsForButtonsWithNumberForLenghtToChcekAndGaps.GetNumberFromConfiguration(tagConfigurationBoardGameChangeNumbeLengthToCheck);
            return number;
        }
    }
}