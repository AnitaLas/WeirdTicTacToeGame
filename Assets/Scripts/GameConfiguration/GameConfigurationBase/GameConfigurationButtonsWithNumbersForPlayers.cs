using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationBase
{
    internal class GameConfigurationButtonsWithNumbersForPlayers
    {

        //public static int[] CreateTableWithPlayersNumber(int playersNumber)
        //{
        //    int[] players = new int[playersNumber];

        //    for (int i = 0; i < playersNumber; i++)
        //    {
        //        players[i] = i;
        //    }

        //    return players;
        //}

        public static GameObject[,,] CreateTableWithOptionToChooseForPlayers(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField)
        {
            GameObject[,,] table;
            int start = 1;
            int end = 8;
            //float newCoordinateY = 100f; 
            float newCoordinateY = 0f; 
            string inactiveText = "-";

            table = GameConfigurationButtonsWithNumbersCommonMethods.ChangeDataForTableWithNumbers( tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
            return table;

        }

        public static GameObject[,,] CreateTableForPlayers(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameTableNumberPlayers = configurationBoardGameDictionaryTag[11];
            string tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 3;


            tableWithNumbers = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = CreateTableWithOptionToChooseForPlayers(tableWithNumbers, tagConfigurationBoardGameTableNumberPlayers, tagConfigurationBoardGameInactiveField);

            return tableWithNumberFinal;

        }

    }

}

