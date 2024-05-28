using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsWithNumbersForGaps : MonoBehaviour
    {

        public static GameObject[,,] CreateTableForMaxGapsNumber(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField, int gapsNumberMax)
        {
            GameObject[,,] table;
            int start = GetGapsNumberMin();
            int end = GetGapsNumberMax();
            float newCoordinateY = 0f;
            string inactiveText = "-";

            table = GameConfigurationButtonsWithNumbersCommonMethods.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
            return table;
        }

        public static GameObject[,,] CreateTableForGapsNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, int lenghtToCheckMax, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            //Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            //string tagConfigurationBoardGameTableNumberLenghtToCheck = configurationBoardGameDictionaryTag[17];
            //string tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];

            //int dictionatyId = 17;
            //string tagConfigurationBoardGameTableNumberLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagConfigurationBoardGameTableNumberLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberGaps();
            
            string tagConfigurationBoardGameInactiveField = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInactiveField();

            var numbers = ScreenVerificationMethods.GetNumberOfRowsAndColumnsForDefaulTableWithNumber(isCellphoneMode);
            int numberOfDepths = 1;
            int numberOfRows = numbers.Item1;
            int numberOfColumns = numbers.Item2;

            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = CreateTableForMaxGapsNumber(tableWithNumbers, tagConfigurationBoardGameTableNumberLenghtToCheck, tagConfigurationBoardGameInactiveField, lenghtToCheckMax);

            return tableWithNumberFinal;
        }

        public static int GetGapsNumberMax()
        {
            int maxNumber = 0;
            int[] numbers = GameConfigurationButtonsCommonMethodsForButtonsWithNumberForLenghtToChcekAndGaps.GetCurrentRowsAndColumnsNumber();
            int number1 = numbers[0];
            int number2 = numbers[1];

            if ((number1 == 3) && (number2 == 3))
                maxNumber = 0;

            else
            {
                int lowerNumber = GameCommonMethodsMain.GetLowerNumber(number1, number2);
                int biggerNumber = GameCommonMethodsMain.GetLowerNumber(number1, number2);
                //int result = biggerNumber / lowerNumber; // hmmm ???
                int result = lowerNumber - 1;
                maxNumber = result;
            }

            return maxNumber;
        }

        public static int GetGapsNumberMin()
        {
            int minNumber;
            int[] numbers = GameConfigurationButtonsCommonMethodsForButtonsWithNumberForLenghtToChcekAndGaps.GetCurrentRowsAndColumnsNumber();
            int number1 = numbers[0];
            int number2 = numbers[1];

            if ((number1 == 3) && (number2 == 3))
                minNumber = 2; // because -> GameConfigurationButtonsWithNumbersCommonMethods.ChangeDataForTableWithNumbers
            else
                minNumber = 0;
            
            return minNumber;
        }

        public static void VerifyAndSetUpGapsNumber()
        {
            int currentGapsNumber = GetCurrentGapsNumber();
            int maxGapsNumber = GetGapsNumberMax();

            if (currentGapsNumber > maxGapsNumber)
            {
                string defaulNumber = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonNumberForGaps();
                GameObject gameObject = GetObjectGaps();
                GameCommonMethodsMain.ChangeTextForFirstChild(gameObject, defaulNumber);
            }
        }

        public static GameObject GetObjectGaps()
        {
            //string tagConfigurationBoardGameChangeNumberGaps = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(16);
            string tagConfigurationBoardGameChangeNumberGaps = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberGaps();
            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(tagConfigurationBoardGameChangeNumberGaps);
            return gameObject;
        }

        public static int GetCurrentGapsNumber()
        {
            //string tagConfigurationBoardGameChangeNumberGaps = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(16);
            string tagConfigurationBoardGameChangeNumberGaps = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberGaps();
            int number = GameConfigurationButtonsCommonMethodsForButtonsWithNumberForLenghtToChcekAndGaps.GetNumberFromConfiguration(tagConfigurationBoardGameChangeNumberGaps);
            return number;
        }





    }
}
