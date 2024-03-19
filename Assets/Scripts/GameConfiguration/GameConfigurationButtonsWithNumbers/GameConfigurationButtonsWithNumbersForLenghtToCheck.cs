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

            //Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            //string tagConfigurationBoardGameTableNumberLenghtToCheck = configurationBoardGameDictionaryTag[14];
            //string tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];

            //int dictionatyId = 14;
            //string tagConfigurationBoardGameTableNumberLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
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


        //public static int GetNumberFromConfiguration(string tagName)
        //{
        //    GameObject objectNumber = GameCommonMethodsMain.GetObjectByTagName(tagName);
        //    string numberString = GameCommonMethodsMain.GetCubePlayText(objectNumber);
        //    int numberInt = GameCommonMethodsMain.ConvertStringToInt(numberString);
        //    return numberInt;
        //}

        //public static int[] CreateTableWithNumberFromConfiguration(string tagNameRows, string tagNameColumns)
        //{
        //    string[] tagsName = { tagNameRows, tagNameColumns };
        //    int tagsNameLenght = tagsName.Length;

        //    string tagName;
        //    int[] numbers = new int[tagsNameLenght];

        //    for (int i = 0; i < tagsNameLenght; i++)
        //    {
        //        tagName = tagsName[i];
        //        int number = GetNumberFromConfiguration(tagName);
        //        numbers[i] = number;
        //    }

        //    return numbers;
        //}

        public static int GetLenghtToCheckMax()
        {
            //Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            //string tagConfigurationBoardGameChangeNumberRows = configurationBoardGameDictionaryTag[7];
            //string tagConfigurationBoardGameChangeNumberColumns = configurationBoardGameDictionaryTag[8];

            //int[] numbers = GameCommonMethodsSetUpButtonWithNumber.CreateTableWithNumberFromConfiguration(tagConfigurationBoardGameChangeNumberRows, tagConfigurationBoardGameChangeNumberColumns);
            int[] numbers = GameConfigurationButtonsCommonButtonsWithNumberForLenghtToChcekAndGaps.GetCurrentRowsAndColumnsNumber();
            int rows = numbers[0];
            int columns = numbers[1];

            int maxNumberInt = GameCommonMethodsMain.GetLowerNumber(rows, columns);

            return maxNumberInt;
        }

       // public static void VerifyAndSetUpNewMaxLength(string[] tableWithChangedNumber)
        //{
            //Dictionary<int, string> defaulNumbers = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameDefaultNumbers();
            //Dictionary<int, string> tagConfigurationBoardGameChangeNumbers = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();

            //string defaulNumber = defaulNumbers[3];

            //string tagConfigurationBoardGameChangeNumberLenghtToCheck = tagConfigurationBoardGameChangeNumbers[13];

            //string tagConfigurationBoardGameChangeNumberRows = tableWithChangedNumber[0];
            //string tagConfigurationBoardGameChangeNumberColumns = tableWithChangedNumber[1];
            //string tagConfigurationBoardGameChangeNumberLenghtToCheck = tableWithChangedNumber[2];

            //GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(tagConfigurationBoardGameChangeNumberLenghtToCheck);
            

            //int rowsNumber = GetNumberGivenByUser(tagConfigurationBoardGameChangeNumberRows);
            //int columnsNumber = GetNumberGivenByUser(tagConfigurationBoardGameChangeNumberColumns);
            //int currentLenghtToCheck = GetNumberGivenByUser(tagConfigurationBoardGameChangeNumberLenghtToCheck);

            
            // currentLenghtToCheck = GameCommonMethodsSetUpButtonWithNumber.GetLengthToCheckNumber();
            //int lowerNumberBetweenRowsNumberAndColumnsNumber = GameCommonMethodsSetUpButtonWithNumber.GetLowerNumberBetweenRowsNumberAndColumnsNumber();

            //if (lowerNumberBetweenRowsNumberAndColumnsNumber < currentLenghtToCheck)
            //{
            //    string defaulNumber = GameCommonMethodsSetUpButtonWithNumber.GetDefaulButtonNumberForLenghtToCheck();
            //    GameObject gameObject = GameCommonMethodsSetUpButtonWithNumber.GetObjectLenghToCheck();

            //    GameCommonMethodsMain.ChangeTextForFirstChild(gameObject, defaulNumber);
            //}

            //bool isCurrentLenghtToCheckBiggerThatRowsNumberAndColumnsNumber = GameCommonMethodsSetUpButtonWithNumber.VerifyIfCurrentNumberIsLowerThatRowsNumberOrColumnsNumber(currentLenghtToCheck);

            //if (isCurrentLenghtToCheckBiggerThatRowsNumberAndColumnsNumber == true)
            //{
            //    string defaulNumber = GameCommonMethodsSetUpButtonWithNumber.GetDefaulButtonNumberForLenghtToCheck();
            //    GameObject gameObject = GameCommonMethodsSetUpButtonWithNumber.GetObjectLenghToCheck();

            //    GameCommonMethodsMain.ChangeTextForFirstChild(gameObject, defaulNumber);
            //}
        //}


        public static void VerifyAndSetUpLenghtToCheck()
        {
            int lowerNumberBetweenRowsNumberAndColumnsNumber = GameConfigurationButtonsCommonButtonsWithNumberForLenghtToChcekAndGaps.GetLowerNumberBetweenRowsNumberAndColumnsNumber();
            int currentLenghtToCheck = GetCurrentLengthToCheckNumber();
            //bool isCurrentLenghtToCheckBiggerThanRowsNumberOrColumnsNumber = GameCommonMethodsSetUpButtonWithNumber.VerifyIfCurrentNumberIsLowerThanRowsNumberOrColumnsNumber(lowerNumberBetweenRowsNumberAndColumnsNumber, currentLenghtToCheck);

            //if (isCurrentLenghtToCheckBiggerThanRowsNumberOrColumnsNumber == true)
            if (lowerNumberBetweenRowsNumberAndColumnsNumber < currentLenghtToCheck)
            {
                string defaulNumber = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonNumberForLenghtToCheck();
                GameObject gameObject = GetObjectLenghToCheck();
                GameCommonMethodsMain.ChangeTextForFirstChild(gameObject, defaulNumber);
            }
        }

        public static GameObject GetObjectLenghToCheck()
        {
            //string tagConfigurationBoardGameChangeNumberLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(13);
            string tagConfigurationBoardGameChangeNumberLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberLenghtToCheck();
            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(tagConfigurationBoardGameChangeNumberLenghtToCheck);
            return gameObject;
        }

        public static int GetCurrentLengthToCheckNumber()
        {
            //string tagConfigurationBoardGameChangeNumbeLengthToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(13);
            string tagConfigurationBoardGameChangeNumbeLengthToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberLenghtToCheck();
            int number = GameConfigurationButtonsCommonButtonsWithNumberForLenghtToChcekAndGaps.GetNumberFromConfiguration(tagConfigurationBoardGameChangeNumbeLengthToCheck);
            return number;
        }



    }
}
