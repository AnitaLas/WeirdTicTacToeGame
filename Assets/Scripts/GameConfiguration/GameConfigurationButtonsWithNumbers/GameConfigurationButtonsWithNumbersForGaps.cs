using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers
{
    internal class GameConfigurationButtonsWithNumbersForGaps : MonoBehaviour
    {

        public static int GetGapsNumber()
        {
            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameChangeNumberRows = configurationBoardGameDictionaryTag[7];
            string tagConfigurationBoardGameChangeNumberColumns = configurationBoardGameDictionaryTag[8];



            /// TO DO - ADD LOGIC FOR GAPS - PAPER GREEN NOTEs No 2



            //int[] numbers = CreateTableWithNumberFromConfiguration(tagConfigurationBoardGameChangeNumberRows, tagConfigurationBoardGameChangeNumberColumns);
            //int rows = numbers[0];
            //int columns = numbers[1];

            //int maxNumberInt = GameCommonMethodsMain.CheckAndReturnLowerNumber(rows, columns);
            int maxNumberInt = 4;

            return maxNumberInt;
        }

        public static GameObject[,,] CreateTableForMaxGaps(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField, int gapsNumberMax)
        {
            GameObject[,,] table;
            int start = 0;
            int end = gapsNumberMax;
            float newCoordinateY = 0f;
            string inactiveText = "-";

            table = GameConfigurationButtonsWithNumbersCommonMethods.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
            return table;
        }

        public static GameObject[,,] CreateTableForGaps(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, int lenghtToCheckMax, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameTableNumberLenghtToCheck = configurationBoardGameDictionaryTag[17];
            string tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];

            var numbers = ScreenVerificationMethods.GetNumberOfRowsAndColumnsForDefaulTableWithNumber(isCellphoneMode);
            int numberOfDepths = 1;
            int numberOfRows = numbers.Item1;
            int numberOfColumns = numbers.Item2;

            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = CreateTableForMaxGaps(tableWithNumbers, tagConfigurationBoardGameTableNumberLenghtToCheck, tagConfigurationBoardGameInactiveField, lenghtToCheckMax);

            return tableWithNumberFinal;
        }



    }
}
