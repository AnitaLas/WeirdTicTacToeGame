using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    internal class PlayGameChangePlayersSymbolsMethods
    {

        public static int GetRandomNumberPlayersToChangeSymbols(string[] playerSymbolMove)
        {
            int minNumber = 1;
            int maxNumber = playerSymbolMove.Length;
            //int maxNumber = newSymbolsForPlayersLenght;
            int randomNumber = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            return randomNumber;
        }

        public static int GetRandomStartIndexForSymbol(int maxNumber)
        {
            int minNumber = 0;
            int randomNumber = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            return randomNumber;
        }



        public static string[] SetUpNewPlayersSymbols(string[] playersSymbols, string[] randomPlayersSymbols)
        {
            int playersSymbolsLength = playersSymbols.Length;
            int randomPlayersSymbolsLength = randomPlayersSymbols.Length;

            string[] oldSymbolsForPlayers = playersSymbols;
            string[] newSymbolsForPlayers = playersSymbols;

            string oldSymbols = "";

            for (int i = 0; i < playersSymbolsLength; i++)
            {
                string symbol = oldSymbolsForPlayers[i];
                //Debug.Log($" oldSymbols: " + oldSymbols);
                oldSymbols = oldSymbols + symbol;
            }

            //Debug.Log($" oldSymbols: " + oldSymbols);



            int minNumber = 0;
            int maxNumber = oldSymbols.Length;


            for (int i = 0; i < randomPlayersSymbolsLength; i++)
            {
                int randomIndexToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
                maxNumber--;

                string oldSymbol = oldSymbols.Substring(randomIndexToChange, 1);
                Debug.Log($" oldSymbols: " + oldSymbols);
                oldSymbols.Remove(randomIndexToChange, 1);

                for (int j = 0; j < playersSymbolsLength; j++)
                {
                    //Debug.Log($" oldSymbols: " + oldSymbols + $" oldSymbolsForPlayers[{j}]: " + oldSymbolsForPlayers[j]);
                    if (oldSymbol == oldSymbolsForPlayers[j])
                    {
                        //Debug.Log($" oldSymbol: " + oldSymbol + $" oldSymbolsForPlayers[{j}]: " + oldSymbolsForPlayers[j]);
                        newSymbolsForPlayers[j] = randomPlayersSymbols[i];
                    }


                }
                // Debug.Log($" -------------------------------- ");

            }


            Debug.Log($" -------------- 12 ------------------ ");

            for (int i = 0; i < randomPlayersSymbols.Length; i++)
            {
                Debug.Log($"randomPlayersSymbols[{i}]: " + randomPlayersSymbols[i]);
            }

            Debug.Log($" -------------------------------- ");

            for (int i = 0; i < newSymbolsForPlayers.Length; i++)
            {
                Debug.Log($"newSymbolsForPlayers[{i}]: " + newSymbolsForPlayers[i]);
            }





            return newSymbolsForPlayers;
        }

        public static bool IsDoubleRandomChange(List<float> gameChangeTimeConfiguration)
        {
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            float timeForChandeForAll = gameChangeTimeConfiguration[1];
            float timeForSwitchBetweenTeams = gameChangeTimeConfiguration[2];

            //int timeRandomly = CommonMethods.ConvertStringToInt(CommonMethods.ConverFloatToString(timeForChandeRandomly));
            //int timeForAll = CommonMethods.ConvertStringToInt(CommonMethods.ConverFloatToString(timeForChandeForAll));
            //int timeBetweenTeams = CommonMethods.ConvertStringToInt(CommonMethods.ConverFloatToString(timeForSwitchBetweenTeams));

            //Debug.Log("timeRandomly: " + timeRandomly);
            //Debug.Log("timeForAll: " + timeForAll);
            // Debug.Log("timeBetweenTeams: " + timeBetweenTeams);
            bool isDoubleRandomChange;

            if ((timeForChandeRandomly > 0 || timeForChandeForAll > 0) && timeForSwitchBetweenTeams > 0)
                isDoubleRandomChange = true;
            else
                isDoubleRandomChange = false;

            //Debug.Log("isDoubleRandomChange: " + isDoubleRandomChange);

            return isDoubleRandomChange;
        }

        // change for list of int
        public static int[] SetUpStartSwitchChange(List<float> gameChangeTimeConfiguration)
        {
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            float timeForChandeForAll = gameChangeTimeConfiguration[1];
            float timeForSwitchBetweenTeams = gameChangeTimeConfiguration[2];


            //Debug.Log("timeForChandeRandomly: " + timeForChandeRandomly);
            //Debug.Log("timeForChandeForAll: " + timeForChandeForAll);
            //Debug.Log("timeForSwitchBetweenTeams: " + timeForSwitchBetweenTeams);

            int[] newData = new int[2];

            int switchChange = 0;
            int indexStartTime = 0;

            if (timeForChandeRandomly == 0 && timeForChandeForAll == 0 && timeForSwitchBetweenTeams > 0)
            {
                switchChange = 1;
                indexStartTime = 1;
            }

            else
            {
                switchChange = 0;
                indexStartTime = 0;
            }
            newData[0] = switchChange;
            newData[1] = indexStartTime;

            return newData;
        }

        public static int SetUpNewSwitchChange(int currentNumberForSwitchChange)
        {
            int newSwitchChange;

            if (currentNumberForSwitchChange == 0)
                newSwitchChange = 1;
            else
                newSwitchChange = 0;

            return newSwitchChange;
        }


        public static bool IsChangeForAll(float timeForChandeRandomly)
        {
            bool isChangeForAll;

            if (timeForChandeRandomly > 0)
                isChangeForAll = false;
            else
                isChangeForAll = true;

            return isChangeForAll;
        }

        public static int GetRandomMaxIndexForNewSymbols(int takenSymbolsNumber)
        {
            //int minNumber = 1;
            //int maxNumber = takenSymbolsLenght;
            //int numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            //return numberSymbolsToChange;

            int minNumber = 0;
            int maxNumber = takenSymbolsNumber;
            int numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            return numberSymbolsToChange;

            //int minNumber = 0;
            //int maxNumber = takenSymbolsLenght - 1;
            //int numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            //return numberSymbolsToChange;
        }

        public static int GetRandomMaxIndexForSymbols(int takenSymbolsLenght)
        {
            int minNumber = 0;
            int maxNumber = takenSymbolsLenght - 1;
            int numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            return numberSymbolsToChange;

            //int minNumber = 0;
            //int maxNumber = takenSymbolsLenght - 1;
            //int numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            //return numberSymbolsToChange + 1;
        }

        public static int GetMaxIndexForNewSymbols(bool isChangeForAll, string[] playersSymbols)
        {
            int numberSymbolsToChange;
            int takenSymbolsNumber = playersSymbols.Length - 1 ;

            if (isChangeForAll == false)
                numberSymbolsToChange = GetRandomMaxIndexForNewSymbols(takenSymbolsNumber);
            else
                numberSymbolsToChange = takenSymbolsNumber;

            return numberSymbolsToChange;
        }


        public static int GetMinPlayersNumberForTeam(List<string[]> teamGameSymbols)
        {
            int minNumber = 1;

            int teamsNumbers = teamGameSymbols.Count;

            for (int a = 0; a < teamsNumbers; a++)
            {
                string[] team = teamGameSymbols[a];

                int playersNumber = team.Length;

                if (playersNumber > minNumber)
                {
                    minNumber = playersNumber;
                }
            }

            return minNumber;

        }



        public static string GetUntakenSymbols(string[] takenSymbols)
        {
            int takenSymbolsLength = takenSymbols.Length;
            string untakenSymbols = PlayGameCommonPlayersSymbols.GetStringWithAllSymbols();

            for (int i = 0; i < takenSymbolsLength; i++)
            {
                string takenSymbol = takenSymbols[i];
                int index = untakenSymbols.IndexOf(takenSymbol);
                string newString = untakenSymbols.Remove(index, 1);
                untakenSymbols = newString;
            }

            return untakenSymbols;
        }

        public static string SetUpTakenSymbols(string[] playersSymbols)
        {
            int playersSymbolsLength = playersSymbols.Length;
            string oldSymbols = "";

            for (int i = 0; i < playersSymbolsLength; i++)
            {
                string symbol = playersSymbols[i];
                oldSymbols = oldSymbols + symbol;
            }

            return oldSymbols;
        }

        public static string[] GetSymbolsForChange(string symbols, int numberSymbolsToChange)
        {
            int symbolsLength = symbols.Length;
            string[] symbolsForChange = new string[numberSymbolsToChange];
            int randomIndex = symbolsLength;
            //Debug.Log("randomIndex: " + randomIndex);

            for (int i = 0; i < numberSymbolsToChange; i++)
            {
                int startIndex = GetRandomStartIndexForSymbol(randomIndex);
                //Debug.Log("startIndex: " + startIndex);
                randomIndex--;

                string symbol = symbols.Substring(startIndex, 1);

                symbolsForChange[i] = symbol;

                symbols = symbols.Remove(startIndex, 1);

            }
            return symbolsForChange;
        }

        // GameConfigurationTeamMembersButtonsMethods - add one class for that method
        public static string[] GetNewSymbols(string[] playersSymbols, int numberSymbolsToChange)
        {
            string untakenSymbolsText = GetUntakenSymbols(playersSymbols);
            string[] newSymbols = GetSymbolsForChange(untakenSymbolsText, numberSymbolsToChange);
            return newSymbols;
        }

        public static string[] GetOldSymbolsByRandom(string[] playersSymbols, int numberSymbolsToChange)
        {
            string takenSymbolsText = SetUpTakenSymbols(playersSymbols);
            string[] oldSymbols = GetSymbolsForChange(takenSymbolsText, numberSymbolsToChange);
            return oldSymbols;
        }

        public static string[] GetOldSymbols(string[] playersSymbols, int numberSymbolsToChange, bool isChangeForAll)
        {
            string[] oldSymbolsForChange = new string[numberSymbolsToChange];
            int playersSymbolsLength = playersSymbols.Length;

            if (isChangeForAll == true)
            {
                for (int i = 0; i < playersSymbolsLength; i++)
                {
                    string symbol = playersSymbols[i];
                    oldSymbolsForChange[i] = symbol;
                }
            }
            else
            {
                oldSymbolsForChange = GetOldSymbolsByRandom(playersSymbols, numberSymbolsToChange);
            }

            return oldSymbolsForChange;
        }

        public static string[] GetNewPlayersSymbols(string[] playersSymbols, string[] oldSymbolsForChange, string[] newSymbolsForChange, int numberSymbolsToChange)
        {
            int playersSymbolsLength = playersSymbols.Length;
            for (int i = 0; i < numberSymbolsToChange; i++)
            {
                string oldSymbol = oldSymbolsForChange[i];
                string newSymbol = newSymbolsForChange[i];

                for (int j = 0; j < playersSymbolsLength; j++)
                {
                    string takenSymbol = playersSymbols[j];

                    if (takenSymbol == oldSymbol)
                    {
                        playersSymbols[j] = newSymbol;
                    }
                }
            }

            return playersSymbols;
        }


        public static List<string[]> SetUpNewTeamGameSymbols(List<string[]> oldTeamGameSymbols, string[] oldSymbolsForChange, string[] newSymbolsForChange)
        {
            int teamsNumbers = oldTeamGameSymbols.Count;

            for (int team = 0; team < teamsNumbers; team++)
            {
                string[] playersSymbols = oldTeamGameSymbols[team];
                int playersNumber = playersSymbols.Length;

                for (int i = 0; i < playersNumber; i++)
                {
                    string teamSymbol = playersSymbols[i];
                    int oldSymbolsLength = oldSymbolsForChange.Length;

                    for (int a = 0; a < oldSymbolsLength; a++)
                    {
                        string oldSymbol = oldSymbolsForChange[a];

                        if (teamSymbol.Equals(oldSymbol))
                        {
                            string newSymbol = newSymbolsForChange[a];
                            playersSymbols[i] = newSymbol;
                        }
                    }
                }
            }


            //for (int team = 0; team < teamsNumbers; team++)
            //{
            //    string[] test = oldTeamGameSymbols[team];
            //    for (int i = 0; i < test.Length; i++)
            //    {

            //        Debug.Log($"team {team}, symbol test[{i}] = " + test[i]);

            //    }

            //}






            //return newTeamGameSymbols;
            return oldTeamGameSymbols;
        }

        public static List<string[]> GetNewDataForPlayersSymbols(string[] playersSymbols, List<float> gameChangeTimeConfiguration)
        {
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            //Debug.Log(" 1 random or for all ------");
            //List<string[]> symbolsLists = new List<string[]>();

            List<string[]> symbolsLists = GetNewPlayersSymbols(playersSymbols, timeForChandeRandomly);

            return symbolsLists;

        }




        ///// <summary>
        ///// that will be work only max for 13 players, GameDictionariesCommonPlayersSymbols -> DictionaryPlayersSymbols,
        ///// hmmm new method to generate that string is required if more than 13 
        ///// </summary>
        ///// <param name="playersSymbols"></param>
        ///// <returns></returns>
        //public static List<string[]> GetNewPlayersSymbolsForSwitch(string[] playersSymbols, List<string[]> teamGameSymbols)
        //{
        //    List<string[]> symbolsLists = new List<string[]>();

        //    int takenSymbolsLenght = playersSymbols.Length;

        //    int numberSymbolsToChange = GetMaxIndexForSwitchSymbols(teamGameSymbols);

        //    //string[] newSymbolsForChange = new string[numberSymbolsToChange];
        //    //string[] oldSymbolsForChange = new string[numberSymbolsToChange];

        //    //string[] newSymbolsForChange = GetNewSymbols(playersSymbols, numberSymbolsToChange);
        //    //string[] oldSymbolsForChange = GetOldSymbols(playersSymbols, numberSymbolsToChange, isChangeForAll);
        //    //playersSymbols = GetNewPlayersSymbols(playersSymbols, oldSymbolsForChange, newSymbolsForChange, numberSymbolsToChange);

        //    //symbolsLists.Insert(0, oldSymbolsForChange);
        //    //symbolsLists.Insert(1, newSymbolsForChange);
        //    symbolsLists.Insert(2, playersSymbols);

        //    return symbolsLists;
        //}


        /// <summary>
        /// that will be work only max for 13 players, GameDictionariesCommonPlayersSymbols -> DictionaryPlayersSymbols,
        /// hmmm new method to generate that string is required if more than 13 
        /// </summary>
        /// <param name="playersSymbols"></param>
        /// <param name="timeForChandeRandomly"></param>
        /// <returns></returns>
        public static List<string[]> GetNewPlayersSymbols(string[] playersSymbols, float timeForChandeRandomly)
        {
            List<string[]> symbolsLists = new List<string[]>();
            
            //int takenSymbolsLenght = playersSymbols.Length;
            //int takenSymbolsLenght = playersSymbols.Length;
            bool isChangeForAll = IsChangeForAll(timeForChandeRandomly);
            //int numberSymbolsToChange = GetMaxIndexForNewSymbols(isChangeForAll, takenSymbolsLenght);
            int maxIndexForChange = GetMaxIndexForNewSymbols(isChangeForAll, playersSymbols);
            int numberSymbolsToChange = maxIndexForChange + 1;
            Debug.Log("numberSymbolsToChange: " + numberSymbolsToChange);
            //string[] newSymbolsForChange = new string[numberSymbolsToChange];
            //string[] oldSymbolsForChange = new string[numberSymbolsToChange];

            string[] newSymbolsForChange = GetNewSymbols(playersSymbols, numberSymbolsToChange);
            string[] oldSymbolsForChange = GetOldSymbols(playersSymbols, numberSymbolsToChange, isChangeForAll);
            playersSymbols = GetNewPlayersSymbols(playersSymbols, oldSymbolsForChange, newSymbolsForChange, numberSymbolsToChange);

            symbolsLists.Insert(0, oldSymbolsForChange);
            symbolsLists.Insert(1, newSymbolsForChange);
            symbolsLists.Insert(2, playersSymbols);

            return symbolsLists;
        }

        public static void SetUpPlayerSymbols(List<GameObject[,,]> buttons, string[] playersSymbols)
        {
            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumber = buttons.Count;

            for (int i = 0; i < buttonsNumber; i++)
            {
                GameObject[,,] table = buttons[i];
                maxIndexDepth = table.GetLength(0);
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = table[indexDepth, indexRow, indexColumn];
                            string symbol = playersSymbols[i];
                            CommonMethods.ChangeTextForFirstChild(cubePlay, symbol);
                        }
                    }
                }
            }
        }

        //public static void SetUpNewDataForGame(GameObject[,,] gameBoard, string[] oldSymbols, string[] newSymbols)
        //{
        //    SetUpNewPlayersSymbolsForGameBoard(gameBoard, oldSymbols, newSymbols);
        //}

        public static string[,] SetUpNewGameBoardVerification2D(string[,] gameBoardVerification2D, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            int cubePlayIndexY = gameBoardVerification2D.GetLength(0);
            int cubePlayIndexX = gameBoardVerification2D.GetLength(1);
            int newSymbolsToChange = newSymbolsForChande.Length;

            for (int z = 0; z < newSymbolsToChange; z++)
            {
                string newSymbol = newSymbolsForChande[z];
                string oldSymbol = oldSymbolsForChande[z];

                //for (int i = 0; i < gameBoardVerification2D.GetLength(0); i++)
                for (int i = 0; i < cubePlayIndexY; i++)
                {
                    //for (int j = 0; j < gameBoardVerification2D.GetLength(1); j++)
                    for (int j = 0; j < cubePlayIndexX; j++)
                    {
                        string currentSymbol = gameBoardVerification2D[i, j];

                        if (currentSymbol == oldSymbol)
                        {
                            gameBoardVerification2D[i, j] = newSymbol;
                        }
                    }
                }
            }









            //for (int i = 0; i < cubePlayIndexY; i++)
            //{
            //    for (int j = 0; j < cubePlayIndexX; j++)
            //    {
            //        string currentSymbol = gameBoardVerification2D[i, j];

            //        Debug.Log($"gameBoardVerification2D[{i}, {j}]: " + gameBoardVerification2D[i, j]);
            //    }
            //}

            //Debug.Log($" ---------------------------------------------------------- ");
            //for (int z = 0; z < newSymbolsToChange; z++)
            //{
            //    string newSymbol = newSymbols[z];
            //    string oldSymbol = oldSymbols[z];

            //    for (int i = 0; i < gameBoardVerification2D.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < gameBoardVerification2D.GetLength(1); j++)
            //        {
            //            string currentSymbol = gameBoardVerification2D[i, j];

            //            if (currentSymbol == oldSymbol)
            //            {
            //                newGameBoardVerification2D[i, j] = newSymbol;
            //            }
            //            else
            //            {
            //                newGameBoardVerification2D[i, j] = newSymbol;
            //            }

            //        }
            //    }

            //}


            //for (int i = 0; i < cubePlayIndexY; i++)
            //{
            //    for (int j = 0; j < cubePlayIndexX; j++)
            //    {
            //        string currentSymbol = gameBoardVerification2D[i, j];

            //        Debug.Log($"newGameBoardVerification2D[{i}, {j}]: " + newGameBoardVerification2D[i, j]);
            //    }
            //}





            //return newGameBoardVerification2D;
            return gameBoardVerification2D;
        }

        public static string[] CreateTableWithTagsForPlayerSymbolMove()
        {
            string tagPlayerSymbolCurrent = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolCurrent();
            string tagPlayerSymbolPrevious = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolPrevious();
            string tagPlayerSymbolNext = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolNext();

            string[] table = new string[3];
            table[0] = tagPlayerSymbolPrevious;
            table[1] = tagPlayerSymbolCurrent;
            table[2] = tagPlayerSymbolNext;

            return table;
        }

        public static void ChangeDataForPlayersSymbolsMoveGameObjects(string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            string[] table = CreateTableWithTagsForPlayerSymbolMove();
            int newSymbolsToChangeLength = newSymbolsForChande.Length;

            for (int i = 0; i < table.Length; i++)
            {
                string tagName = table[i];
                GameObject cubePlay = GameCommonMethodsMain.GetObjectByTagName(tagName);
                string currentSymbol = CommonMethods.GetCubePlayText(cubePlay);

                for (int j = 0; j < newSymbolsToChangeLength; j++)
                {
                    string oldSymbol = oldSymbolsForChande[j];

                    if (currentSymbol == oldSymbol)
                    {
                        string newSymbol = newSymbolsForChande[j];
                        GameCommonMethodsMain.ChangeTextForFirstChild(cubePlay, newSymbol);
                    }
                }
            }
        }

        public static string[] GetNewPlayersSymbolsMove(string[] playerSymbolMove, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            int playerSymbolMoveLength = playerSymbolMove.Length;
            int newSymbolsToChangeLength = newSymbolsForChande.Length;

            for (int z = 0; z < newSymbolsToChangeLength; z++)
            {
                string newSymbol = newSymbolsForChande[z];
                string oldSymbol = oldSymbolsForChande[z];

                for (int i = 0; i < playerSymbolMoveLength; i++)
                {
                    string currentSymbol = playerSymbolMove[i];

                    if (currentSymbol == oldSymbol)
                        playerSymbolMove[i] = newSymbol;
                }
            }

            return playerSymbolMove;
        }

        public static string[] SetUpNewPlayersSymbolsMove(string[] playerSymbolMove, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            //int playerSymbolMoveLength = playerSymbolMove.Length;
            //int newSymbolsToChangeLength = newSymbolsForChande.Length;

            //for (int z = 0; z < newSymbolsToChangeLength; z++)
            //{
            //    string newSymbol = newSymbolsForChande[z];
            //    string oldSymbol = oldSymbolsForChande[z];

            //    for (int i = 0; i < playerSymbolMoveLength; i++)
            //    {
            //        string currentSymbol = playerSymbolMove[i];

            //        if (currentSymbol == oldSymbol)
            //            playerSymbolMove[i] = newSymbol;
            //    }
            //}


            //string tagPlayerSymbolCurrent = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolCurrent();
            //string tagPlayerSymbolPrevious = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolPrevious();
            //string tagPlayerSymbolNext = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolNext();

            //string[] table = new string[3];
            //table[0] = tagPlayerSymbolPrevious;
            //table[1] = tagPlayerSymbolCurrent;
            //table[2] = tagPlayerSymbolNext;


            //string[] table = CreateTableWithTagsForPlayerSymbolMove();


            //for (int i = 0; i < table.Length; i++)
            //{
            //    string tagName = table[i];
            //    GameObject cubePlay = GameCommonMethodsMain.GetObjectByTagName(tagName);
            //    string currentSymbol = CommonMethods.GetCubePlayText(cubePlay);

            //    for (int j = 0; j < newSymbolsToChangeLength; j++)
            //    {
            //        string oldSymbol = oldSymbolsForChande[j];

            //        if (currentSymbol == oldSymbol)
            //        {
            //            string newSymbol = newSymbolsForChande[j];
            //            GameCommonMethodsMain.ChangeTextForFirstChild(cubePlay, newSymbol);
            //        }

            //    }

            //}
            playerSymbolMove = GetNewPlayersSymbolsMove(playerSymbolMove, oldSymbolsForChande, newSymbolsForChande);
            ChangeDataForPlayersSymbolsMoveGameObjects(oldSymbolsForChande, newSymbolsForChande);

            //Debug.Log($" -------------------- AFTER -------------------------------------- ");

            //for (int i = 0; i < playerSymbolMove.Length; i++)
            //{
            //    Debug.Log($"_playersSymbols[{i}]: " + playerSymbolMove[i]);
            //}

            return playerSymbolMove;
        }


        //--------------------------------------------------------------------------------------------------------
        public static void SetUpNewPlayersSymbolsForGameBoard(GameObject[,,] gameBoard, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);
            int newSymbolsToChange = newSymbolsForChande.Length;

            for (int i = 0; i < newSymbolsToChange; i++)
            {
                string newSymbol = newSymbolsForChande[i];
                string oldSymbol = oldSymbolsForChande[i];

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                            string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

                            if (currentCubePlaySymbol == oldSymbol)
                            {
                                CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                            }
                        }
                    }
                }
            }
        }

        // switch symbols between team

        //public static string GetIndexesAsString(int playersSymbols)
        //{
        //    string numbers = "";

        //    for (int i = 0; i < playersSymbols; i++)
        //    {
        //        numbers = numbers + i;
        //        //Debug.Log("numbers: " + numbers);
        //    }
        //    //Debug.Log(" -----------  ");
        //    return numbers;
        //}

        //public static int[] GetIndexesForSwitch(int playersSymbols, int maxSymbolsNumberForChange)
        //{
        //    int[] indexes = new int[maxSymbolsNumberForChange];

        //    string allNumbers = GetIndexesAsString(playersSymbols);
        //    //Debug.Log("allNumbers: " + allNumbers);

        //    string numbers = allNumbers;
        //    //Debug.Log("numbers: " + numbers);

        //    int minNumber = 0;
        //    int maxNumber = playersSymbols;

        //    for (int i = 0; i < maxSymbolsNumberForChange; i++)
        //    {
        //        //Debug.Log("1 numbers: " + numbers);
        //        //Debug.Log("i: " + i);
        //        //Debug.Log("minNumber: " + minNumber);
        //        //Debug.Log("maxNumber: " + maxNumber);
        //        int randomIndexToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
        //        //Debug.Log("randomIndexToChange: " + randomIndexToChange);

        //        string index = numbers.Substring(randomIndexToChange, 1);
        //        //Debug.Log($" index: " + index);
        //        int finaleIndex = CommonMethods.ConvertStringToInt(index);
        //        //Debug.Log($" finaleIndex: " + finaleIndex);
        //        indexes[i] = finaleIndex;
                

        //        maxNumber--;
        //        numbers = numbers.Remove(randomIndexToChange, 1);
        //        //Debug.Log("2 numbers: " + numbers);
        //        //Debug.Log("2 numbers: " + numbers.Remove(randomIndexToChange,1));
        //    }
        //    //Debug.Log(" -----------  ");

        //    //for (int i = 0; i < indexes.Length; i++)
        //    //{
        //    //    Debug.Log($" indexes[{i}]: " + indexes[i]);

        //    //}

        //    //Debug.Log(" -----------  ");

        //    //Debug.Log(" -----------  ");
        //    return indexes;
        //}

        ////public static List<string[]> GetSymoblsForSwitch(List<string[]> teamGameSymbols, int maxSymbolsNumberForChange)
        //public static List<string[]> GetSymoblsForSwitch(List<string[]> teamGameSymbols)
        //{
        //    List<string[]> oldSymbolsForSwitch = new List<string[]>();

        //    // change for random, works = 2
        //    //int maxSymbolsNumberForChange = GetMinPlayersNumberForTeam(teamGameSymbols);
        //    int maxSymbolsNumberForChange = 1;

        //    int teamsNumbers = teamGameSymbols.Count;
        //    //Debug.Log(" teamsNumbers: " + teamsNumbers);
        //    //Debug.Log($" --------------------------------------- ");
        //    for (int t = 0; t < teamsNumbers; t++)
        //    {
               
        //        string[] teamSymbols = teamGameSymbols[t];
        //        int playersSymbols = teamSymbols.Length;
        //        int[] indexesForSwitch = GetIndexesForSwitch(playersSymbols, maxSymbolsNumberForChange);
        //        int numbersOfSymbolsToSwitch = indexesForSwitch.Length;

        //        string[] symbolsToSwitch = new string[maxSymbolsNumberForChange];

        //        for (int a = 0; a < numbersOfSymbolsToSwitch; a++)
        //        {

        //            int indexToSwitch = indexesForSwitch[a];
        //            string symbol = teamSymbols[indexToSwitch];
        //            symbolsToSwitch[a] = symbol;

        //        }

        //        //for (int i = 0; i < symbolsToSwitch.Length; i++)
        //        //{
        //        //    Debug.Log($"symbolsToSwitch[{i}] :" + symbolsToSwitch[i]);
        //        //}
        //        //Debug.Log($" --------------------------------------- ");

        //        oldSymbolsForSwitch.Insert(0, symbolsToSwitch);
        //    }





        //    return oldSymbolsForSwitch;
        //}

        //public static string[] GetNewSymbolsForSwitch(List<string[]> symbolsForSwitch)
        //{
        //    int teamsNumbers = symbolsForSwitch.Count;
        //    string[] teamSymbols = symbolsForSwitch[0];
        //    int numbersOfSymbols = teamSymbols.Length;
        //    int numberOfSymbolsToSwitch = teamsNumbers * numbersOfSymbols;

        //    string[] oldSymbolsForSwitch = new string[numberOfSymbolsToSwitch];

        //    int index = 0;

        //    for (int i = 0; i < teamsNumbers; i++)
        //    {
        //        string[] team = symbolsForSwitch[0];
        //        int playersNumbers = teamSymbols.Length;

        //        for (int a = 0; a < teamsNumbers; a++)
        //        {
        //            string symbols = teamSymbols[a];
        //            oldSymbolsForSwitch[index] = symbols;
        //            index++;
        //        }


        //    }

        //    return oldSymbolsForSwitch;

        //}
        //public static List<string[]> GetNewPlayersSymbolsForSwitch(string[] playersSymbols, List<string[]> teamGameSymbols)
        //{
        //    List<string[]> symbolsLists = new List<string[]>();

        //    //Debug.Log(" 2 switch ------");
        //    int takenSymbolsLenght = playersSymbols.Length;

        //    //int maxSymbolsNumberForChange = GetMinPlayersNumberForTeam(teamGameSymbols);
        //    //Debug.Log("maxSymbolsNumberForChange: " + maxSymbolsNumberForChange);
        //   //Debug.Log(" -----------  ");
        //    //int[] maxandomIndexForChange = GetRandomNumbersForSwitch(numberSymbolsToChange);

        //    //List<string[]> symbolsForSwitch = GetSymoblsForSwitch(teamGameSymbols, maxSymbolsNumberForChange);
        //    List<string[]> symbolsForSwitch = GetSymoblsForSwitch(teamGameSymbols);

        //    string[] oldSymbolsForSwitch = GetNewSymbolsForSwitch(symbolsForSwitch); 
        //    //string[] newSymbolsForSwitch;


        //    //string[] newSymbolsForChange = new string[numberSymbolsToChange];
        //    //string[] oldSymbolsForChange = new string[numberSymbolsToChange];

        //    //string[] newSymbolsForChange = GetNewSymbols(playersSymbols, numberSymbolsToChange);
        //    //string[] oldSymbolsForChange = GetOldSymbols(playersSymbols, numberSymbolsToChange, isChangeForAll);

        //    //playersSymbols = GetNewPlayersSymbols(playersSymbols, oldSymbolsForChange, newSymbolsForChange, numberSymbolsToChange);

        //    //symbolsLists.Insert(0, oldSymbolsForChange);
        //    //symbolsLists.Insert(1, newSymbolsForChange);
        //    //symbolsLists.Insert(2, playersSymbols);

        //    return symbolsLists;

        //}
    }
}
