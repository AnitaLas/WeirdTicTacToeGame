using Assets.Scripts.GameDictionaries;
using Assets.Scripts.ScreenVerification;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers
{
    internal class GameConfigurationButtonsWithNumbersForPlayers
    {
        public static GameObject[,,] CreateTableWithOptionToChooseForPlayers(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField, bool isCellphoneMode)
        {
            GameObject[,,] table;
            int start = 1;
            int end = ScreenVerificationMethods.GetMaxPlayerNumberForConfiguration(isCellphoneMode);
            float newCoordinateY = 0f; 
            string inactiveText = "-";

            table = GameConfigurationButtonsWithNumbersCommonMethods.ChangeDataForTableWithNumbers( tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
            return table;
        }

        public static GameObject[,,] CreateTableForPlayers(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameTableNumberPlayers = configurationBoardGameDictionaryTag[11];
            string tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];

            var numbers = ScreenVerificationMethods.GetNumberOfRowsAndColumnsForDefaulTableWithNumber(isCellphoneMode);
            int numberOfDepths = 1;
            int numberOfRows = numbers.Item1;
            int numberOfColumns = numbers.Item2;

            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = CreateTableWithOptionToChooseForPlayers(tableWithNumbers, tagConfigurationBoardGameTableNumberPlayers, tagConfigurationBoardGameInactiveField, isCellphoneMode);

            return tableWithNumberFinal;
        }
    }
}

