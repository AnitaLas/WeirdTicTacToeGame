using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.ScreenVerification;

namespace Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers
{
    internal class GameConfigurationButtonsWithNumbersForLenghtToCheck : MonoBehaviour
    {
        public static int GetNumberFromConfiguration(string tagName)
        {
            GameObject objectNumber = CommonMethods.GetObjectByTagName(tagName);
            string numberString = CommonMethods.GetCubePlayText(objectNumber);
            int numberInt = CommonMethods.ConvertStringToInt(numberString);
            return numberInt;
        }

        public static int[] CreateTableWithNumberFromConfiguration(string tagNameRows, string tagNameColumns)
        {
            string[] tagsName = { tagNameRows, tagNameColumns };
            int tagsNameLenght = tagsName.Length;

            string tagName;
            int[] numbers = new int[tagsNameLenght];

            for (int i = 0; i < tagsNameLenght; i++)
            {
                tagName = tagsName[i];
                int number = GetNumberFromConfiguration(tagName);
                numbers[i] = number;
            }

            return numbers;
        }

        public static int GetLenghtToCheckMax()
        {
            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameChangeNumberRows = configurationBoardGameDictionaryTag[7];
            string tagConfigurationBoardGameChangeNumberColumns = configurationBoardGameDictionaryTag[8];

            int[] numbers = CreateTableWithNumberFromConfiguration(tagConfigurationBoardGameChangeNumberRows, tagConfigurationBoardGameChangeNumberColumns);
            int rows = numbers[0];
            int columns = numbers[1];

            int maxNumberInt = CommonMethods.CheckAndReturnLowerNumber(rows, columns);

            return maxNumberInt;
        }

        public static int GetNumberGivenByUser(string tagName)
        {
            GameObject gameObject = CommonMethods.GetObjectByTagName(tagName);
            string gameObjectText = CommonMethods.GetCubePlayText(gameObject);

            int number = CommonMethods.ConvertStringToInt(gameObjectText);
            return number;
        }


        public static void VerifyAndSetUpNewMaxLength(string[] tableWithChangedNumber)
        {
            string tagConfigurationBoardGameChangeNumberRows = tableWithChangedNumber[0];
            string tagConfigurationBoardGameChangeNumberColumns = tableWithChangedNumber[1];
            string tagConfigurationBoardGameChangeNumberLenghtToCheck = tableWithChangedNumber[2];

            GameObject gameObject = CommonMethods.GetObjectByTagName(tagConfigurationBoardGameChangeNumberLenghtToCheck);

            int rowsNumber = GetNumberGivenByUser(tagConfigurationBoardGameChangeNumberRows);
            int columnsNumber = GetNumberGivenByUser(tagConfigurationBoardGameChangeNumberColumns);
            int currentLenghtToCheck = GetNumberGivenByUser(tagConfigurationBoardGameChangeNumberLenghtToCheck);

            int lowerNumber = CommonMethods.CheckAndReturnLowerNumber(rowsNumber, columnsNumber);

            string defaulNumber = "3";

            if (lowerNumber < currentLenghtToCheck)
            {
                CommonMethods.ChangeTextForFirstChild(gameObject, defaulNumber);
            }
        }

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

            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameTableNumberLenghtToCheck = configurationBoardGameDictionaryTag[14];
            string tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];

            var numbers = ScreenVerificationMethods.GetNumberOfRowsAndColumnsForDefaulTableWithNumber(isCellphoneMode);
            int numberOfDepths = 1;
            int numberOfRows = numbers.Item1;
            int numberOfColumns = numbers.Item2;

            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = CreateTableForMaxLenghtToCheck(tableWithNumbers, tagConfigurationBoardGameTableNumberLenghtToCheck, tagConfigurationBoardGameInactiveField, lenghtToCheckMax);

            return tableWithNumberFinal;
        }
    }
}
