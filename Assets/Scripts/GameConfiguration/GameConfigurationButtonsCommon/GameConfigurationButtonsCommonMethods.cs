using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsCommonMethods
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
            GameObject cubePlay = GameCommonMethodsMain.GetCubePlay(tableWithNumber, gameObjectName);
            string numberString = GameCommonMethodsMain.GetCubePlayText(cubePlay);

            GameObject cubePlayToChange = GameCommonMethodsMain.GetObjectByTagName(tagName);
            GameCommonMethodsMain.ChangeTextForFirstChild(cubePlayToChange, numberString);

            number = GameCommonMethodsMain.ConvertStringToInt(numberString);
            return number;
        }

        // ---
        public static int SetUpChosenNumberForConfigurationPlayers(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagConfigurationBoardGameChangeNumberPlayers = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberPlayers();


            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberPlayers);
            return number;
        }

        public static int SetUpChosenNumberForConfigurationRows(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagConfigurationBoardGameChangeNumberRows = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberRows();

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberRows);
            return number;
        }

        public static int SetUpChosenNumberForConfigurationColumns(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagConfigurationBoardGameChangeNumberColumns = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberColumns();

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberColumns);
            return number;
        }

        public static int SetUpChosenNumberForConfigurationLenghtToCheck(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagConfigurationBoardGameChangeNumberLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberLenghtToCheck();

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberLenghtToCheck);
            return number;
        }

        public static int SetUpChosenNumberForConfigurationGaps(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagConfigurationBoardGameChangeNumberGaps = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberGaps();

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberGaps);
            return number;
        }

        public static int SetUpChosenNumberForConfigurationRandomly(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {     
            string tagConfigurationBoardGameChangeNumberRandomly = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberRandomly();

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberRandomly);
            return number;
        }

        public static int SetUpChosenNumberForConfigurationForAll(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagConfigurationBoardGameChangeNumberForAll = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberForAll();

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberForAll);
            return number;
        }

        public static int SetUpChosenNumberForConfigurationBetweenTeams(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagConfigurationBoardGameChangeNumberBetweenTeams = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberBetweenTeams();

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagConfigurationBoardGameChangeNumberBetweenTeams);
            return number;
        }

        public static bool IsTeamGame(bool _configurationTraditionalGame, bool _configurationTeamGame1, bool _configurationTraditionalGame2, bool _configurationTeamGame2)
        {
            bool isTeamGame = false;

            //if (_configurationTraditionalGame1 == true && _configurationTeamGame1 == false)
            //    isTeamGame = false;

            //if (_configurationTraditionalGame2 == false && _configurationTeamGame2 == true)
            //    isTeamGame = true;

            if (_configurationTraditionalGame == true)
                isTeamGame = false;
            else
                isTeamGame = true;
            //if (_configurationTeamGame2 == true)
            //    isTeamGame = true;

            return isTeamGame;
        }
    } 
}
