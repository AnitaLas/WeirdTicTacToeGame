using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationBase
{
    internal class GameConfigurationButtonsWithNumbersForRows
    {
        /*
        tableWithNumberForRowsBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, _numberOfDepths, _numberOfRowsForTableNumber, _numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
        tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(_tableWithNumberForRowsBase, _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
        */


        //public static GameObject[,,] CreateTableWithOptionToChooseForRows(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField)
        //{
        //    GameObject[,,] table;
        //    int start = 2;
        //    int end = 10;
        //    //float newCoordinateY = 100f; 
        //    float newCoordinateY = 0f;
        //    string inactiveText = "-";

        //    table = GameConfigurationTableForSetUp.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
        //    return table;

        //}

        public static GameObject[,,] CreateTableForRows(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameTableNumberRows = configurationBoardGameDictionaryTag[3];
            string tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 3;


            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = GameConfigurationButtonsWithNumbersForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumbers, tagConfigurationBoardGameTableNumberRows, tagConfigurationBoardGameInactiveField);

            return tableWithNumberFinal;

        }



    }
}
