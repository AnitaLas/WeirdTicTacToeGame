using Assets.Scripts.GameDictionaries;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.CommonMethods;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfigurationCommonMethods
    {  
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

        //public static void ChangeCoordinateYForConfiguration(float newCoordinateZ, string[] tagConfigurationHideOrUnhide)
        //{

        //    int tagNameLenght = tagConfigurationHideOrUnhide.Length;

        //    for (int i = 0; i < tagNameLenght; i++)
        //    {
        //        string tag = tagConfigurationHideOrUnhide[i];
        //        GameObject gameObjectToChange = CommonMethodsMain.GetObjectByTagName(tag);
        //        CommonMethodsSetUpCoordinates.SetUpNewYForGameObject(gameObjectToChange, newCoordinateZ);
        //    }
        //}


        public static int SetUpChosenNumberForConfiguration( GameObject[,,] tableWithNumber, string gameObjectName, string tagName)
        {
            int number;
            GameObject cubePlay = CommonMethodsMain.GetCubePlay(tableWithNumber, gameObjectName);
            string numberString = CommonMethodsMain.GetCubePlayText(cubePlay);

            GameObject cubePlayToChange = CommonMethodsMain.GetObjectByTagName(tagName);
            CommonMethodsMain.ChangeTextForFirstChild(cubePlayToChange, numberString);

            number = CommonMethodsMain.ConvertStringToInt(numberString);
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
