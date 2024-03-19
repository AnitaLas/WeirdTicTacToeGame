using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsWithNumbersForColumns
    {
        public static GameObject[,,] CreateTableForColumns(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            //Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            //string tagConfigurationBoardGameTableNumberRows = configurationBoardGameDictionaryTag[4];
            //string tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];

            //int dictionatyId = 4;
            //string tagConfigurationBoardGameTableNumberRows = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagConfigurationBoardGameTableNumberRows = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberColumns();
            
            string tagConfigurationBoardGameInactiveField = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInactiveField();

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