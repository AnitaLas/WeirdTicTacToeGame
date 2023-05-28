using Assets.Scripts.GameDictionaries;
using Assets.Scripts.ScreenVerification;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers
{
    internal class GameConfigurationButtonsWithNumbersForColumns
    {
        public static GameObject[,,] CreateTableForColumns(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameTableNumberRows = configurationBoardGameDictionaryTag[4];
            string tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];

            var numbers = ScreenVerificationMethods.GetNumberOfRowsAndColumnsForDefaulTableWithNumber(isCellphoneMode);
            int numberOfDepths = 1;
            int numberOfRows = numbers.Item1;
            int numberOfColumns = numbers.Item2;

            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = GameConfigurationButtonsWithNumbersForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumbers, tagConfigurationBoardGameTableNumberRows, tagConfigurationBoardGameInactiveField, isCellphoneMode);

            return tableWithNumberFinal;
        }
    }
}