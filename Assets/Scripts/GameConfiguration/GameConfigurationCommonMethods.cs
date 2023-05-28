using Assets.Scripts.GameDictionaries;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfigurationCommonMethods
    {
     
        //public static string[] CreateTableWithPlayersSymbols()
        //{
        //    //string[] playersSymbols = { "x", "o", "H", "y", "z", "t" };
        //    string[] playersSymbols = { "x", "00" };
        //    //string[] playersSymbols = { "x", "00" };
        //    //string[] playersSymbols = { "x", "0", "3" };
        //    //string[] playersSymbols = { "x", "o", "H", "Z"};
        //    //string[] playersSymbols = { "1", "2", "3", "4" };
        //    return playersSymbols;
        //}
        
        public static string[,] CreateEmptyTable2D(int numberOfRows, int numberOfColumns)
        {
            string[,] table = new string[numberOfRows, numberOfColumns];

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    table[row, column] = "";
                }
            }
            return table;
        }
        
        //public static void ChangeCoordinateYForTable(GameObject[,,] tableWtithNumber, float newCoordinateZ)
        //{

        //    int maxIndexDepth = 1;
        //    int maxIndexColumn = tableWtithNumber.GetLength(2);
        //    int maxIndexRow = tableWtithNumber.GetLength(1);

        //    for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
        //    {
        //        for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
        //        {
        //            for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
        //            {
        //                GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
        //                CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateZ);

        //            }
        //        }
        //    }
        //}
        
        /*
        public static void UnhideTableWithNumber(GameObject[,,] tableWtithNumber)
        {
            float newCoordinateZ = -100f;
            ChangeCoordinateYForTable(tableWtithNumber, newCoordinateZ);
        }

        public static void HideTableWithNumber(GameObject[,,] tableWtithNumber)
        {
            float newCoordinateY = 100f;
            ChangeCoordinateYForTable(tableWtithNumber, newCoordinateY);
        }
        */
        //-------------------------

        public static void ChangeCoordinateYForConfiguration(float newCoordinateZ, string[] tagConfigurationHideOrUnhide)
        {

            int tagNameLenght = tagConfigurationHideOrUnhide.Length;

            for (int i = 0; i < tagNameLenght; i++)
            {
                string tag = tagConfigurationHideOrUnhide[i];
                GameObject gameObjectToChange = CommonMethods.GetObjectByTagName(tag);
                CommonMethods.SetUpNewYForGameObject(gameObjectToChange, newCoordinateZ);
            }
        }

        //public static void UnhideConfiguration( string[] tagConfigurationHideOrUnhide)
        //{
        //    float newCoordinateY = -100f;
        //    ChangeCoordinateYForConfiguration(newCoordinateY, tagConfigurationHideOrUnhide);
        //}

        //public static void HideConfiguration( string[] tagConfigurationHideOrUnhide)
        //{
        //    float newCoordinateY = 100f;
        //    ChangeCoordinateYForConfiguration(newCoordinateY, tagConfigurationHideOrUnhide);
        //}


        public static int SetUpChosenNumberForConfiguration( GameObject[,,] tableWithNumber, string gameObjectName, string tagName)
        {
            int number;
            GameObject cubePlay = CommonMethods.GetCubePlay(tableWithNumber, gameObjectName);
            string numberString = CommonMethods.GetCubePlayText(cubePlay);

            GameObject cubePlayToChange = CommonMethods.GetObjectByTagName(tagName);
            CommonMethods.ChangeTextForFirstChild(cubePlayToChange, numberString);

            number = CommonMethods.ConvertStringToInt(numberString);
            return number;
        }

        // ---
        public static int SetUpChosenNumberForConfigurationPlayers(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameChangeNumberPlayers = configurationBoardGameDictionaryTag[10];

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberPlayers);
            return number;
        }

        public static int SetUpChosenNumberForConfigurationRows(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameChangeNumberRows = configurationBoardGameDictionaryTag[7];

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberRows);
            return number;
        }

        public static int SetUpChosenNumberForConfigurationColumns(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameChangeNumberColumns = configurationBoardGameDictionaryTag[8];

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberColumns);
            return number;
        }

        public static int SetUpChosenNumberForConfigurationLenghtToCheck(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagConfigurationBoardGameChangeNumberLenghtToCheck = configurationBoardGameDictionaryTag[13];

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberLenghtToCheck);
            return number;
        }
    } 
}
