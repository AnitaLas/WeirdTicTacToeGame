using Assets.Scripts.GameDictionaries;
using Assets.Scripts.ScreenVerification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers
{
    internal class GameConfigurationButtonsWithNumbersForRows
    {
        public static GameObject[,,] CreateTableForRows(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameTableNumberRows = configurationBoardGameDictionaryTag[3];
            string tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];

            var numbers = ScreenVerificationMethods.GetNumberOfRowsAndColumnsForDefaulTableWithNumber(isCellphoneMode);
            int numberOfDepths = 1;
            //int numberOfRows = 3;
            //int numberOfColumns = 3;
            int numberOfRows = numbers.Item1;
            int numberOfColumns = numbers.Item2;

            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = GameConfigurationButtonsWithNumbersForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumbers, tagConfigurationBoardGameTableNumberRows, tagConfigurationBoardGameInactiveField, isCellphoneMode);

            return tableWithNumberFinal;
        }



    }
}
