using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.Windows;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    internal class PlayGameChangePlayersSymbolsMethods
    {

        public static int GetRandomNumberPlayersToChangeSymbols(string[] playerSymbolMove)
        {
            int minNumber = 1;
            int maxNumber = playerSymbolMove.Length;
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
                oldSymbols = oldSymbols + symbol;
            }

            int minNumber = 0;
            int maxNumber = oldSymbols.Length;

            for (int i = 0; i < randomPlayersSymbolsLength; i++)
            {
                int randomIndexToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
                maxNumber--;

                string oldSymbol = oldSymbols.Substring(randomIndexToChange, 1);
                oldSymbols.Remove(randomIndexToChange, 1);

                for (int j = 0; j < playersSymbolsLength; j++)
                {
                    if (oldSymbol == oldSymbolsForPlayers[j])
                        newSymbolsForPlayers[j] = randomPlayersSymbols[i];
                }
            }

            return newSymbolsForPlayers;
        }

        public static bool IsDoubleRandomChange(List<float> gameChangeTimeConfiguration)
        {
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            float timeForChandeForAll = gameChangeTimeConfiguration[1];
            float timeForSwitchBetweenTeams = gameChangeTimeConfiguration[2];

            bool isDoubleRandomChange;

            if ((timeForChandeRandomly > 0 || timeForChandeForAll > 0) && timeForSwitchBetweenTeams > 0)
                isDoubleRandomChange = true;
            else
                isDoubleRandomChange = false;

            return isDoubleRandomChange;
        }

        // change for list of int
        public static int[] SetUpStartSwitchChange(List<float> gameChangeTimeConfiguration)
        {
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            float timeForChandeForAll = gameChangeTimeConfiguration[1];
            float timeForSwitchBetweenTeams = gameChangeTimeConfiguration[2];

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
            int minNumber = 0;
            int maxNumber = takenSymbolsNumber;
            int numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            return numberSymbolsToChange;
        }

        public static int GetRandomMaxIndexForSymbols(int takenSymbolsLenght)
        {
            int minNumber = 0;
            int maxNumber = takenSymbolsLenght - 1;
            int numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            return numberSymbolsToChange;
        }

        public static int GetMaxIndexForNewSymbols(bool isChangeForAll, string[] playersSymbols)
        {
            int numberSymbolsToChange;
            int takenSymbolsNumber = playersSymbols.Length - 1;

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

                if (a == 0)
                    minNumber = playersNumber;

                else if (playersNumber < minNumber)
                    minNumber = playersNumber;
            }

            return minNumber;
        }

        public static string GetUntakenSymbols(string[] takenSymbols)
        {
            string textWithDoubleSymbols = "";

            for (int i = 0; i < takenSymbols.Length; i++)
            {
                string symbol = takenSymbols[i];
                textWithDoubleSymbols = textWithDoubleSymbols + symbol;
            }

            char[] newSymbols = textWithDoubleSymbols.ToCharArray().Distinct().ToArray();
            string untakenSymbols = PlayGameCommonPlayersSymbols.GetStringWithAllSymbols();

            for (int i = 0; i < newSymbols.Length; i++)
            {
                char takenSymbol = newSymbols[i];
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

            for (int i = 0; i < numberSymbolsToChange; i++)
            {
                int startIndex = GetRandomStartIndexForSymbol(randomIndex);

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
                        playersSymbols[j] = newSymbol;
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

            return oldTeamGameSymbols;
        }

        public static List<string[]> GetNewDataForPlayersSymbols(string[] playersSymbols, List<string[]> teamGameSymbols, List<float> gameChangeTimeConfiguration, bool isSameQuantityForMovePerTeam, bool isTeamGame)
        {
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            List<string[]> symbolsLists = GetNewPlayersSymbols(playersSymbols, teamGameSymbols, timeForChandeRandomly, isSameQuantityForMovePerTeam, isTeamGame);
            return symbolsLists;

        }

        public static string[] GetPlayersSymbolsInOneTable(List<string[]> teamGameSymbols)
        {
            int playersNumber = 0;

            int teamsNumbers = teamGameSymbols.Count;

            for (int a = 0; a < teamsNumbers; a++)
            {
                string[] team = teamGameSymbols[a];
                int playersNumberInOneTeam = team.Length;
                playersNumber = playersNumber + playersNumberInOneTeam;
            }

            string[] playersSymbols = new string[playersNumber];
            int index = 0;

            for (int l = 0; l < teamsNumbers; l++)
            {
                string[] team = teamGameSymbols[l];
                int playersNumberInOneTeam = team.Length;

                for (int z = 0; z < playersNumberInOneTeam; z++)
                {
                    string symbol = team[z];
                    playersSymbols[index] = symbol;
                    index++;
                }
            }

            return playersSymbols;
        }


        /// <summary>
        /// that will be work only max for 13 players, GameDictionariesCommonPlayersSymbols -> DictionaryPlayersSymbols,
        /// hmmm new method to generate that string is required if more than 13 
        /// </summary>
        /// <param name="playersSymbols"></param>
        /// <param name="timeForChandeRandomly"></param>
        /// <returns></returns>
        public static List<string[]> GetNewPlayersSymbols(string[] playersSymbols, List<string[]> teamGameSymbols, float timeForChandeRandomly, bool isSameQuantityForMovePerTeam, bool isTeamGame)
        {
            List<string[]> symbolsLists = new List<string[]>();

            if (isTeamGame == true)
                playersSymbols = GetPlayersSymbolsInOneTable(teamGameSymbols);

            bool isChangeForAll = IsChangeForAll(timeForChandeRandomly);

            int maxIndexForChange = GetMaxIndexForNewSymbols(isChangeForAll, playersSymbols);
            int numberSymbolsToChange = maxIndexForChange + 1;

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

        public static string[,] SetUpNewGameBoardVerification2D(string[,] gameBoardVerification2D, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            int cubePlayIndexY = gameBoardVerification2D.GetLength(0);
            int cubePlayIndexX = gameBoardVerification2D.GetLength(1);
            int newSymbolsToChange = newSymbolsForChande.Length;

            for (int z = 0; z < newSymbolsToChange; z++)
            {
                string newSymbol = newSymbolsForChande[z];
                string oldSymbol = oldSymbolsForChande[z];

                for (int i = 0; i < cubePlayIndexY; i++)
                {
                    for (int j = 0; j < cubePlayIndexX; j++)
                    {
                        string currentSymbol = gameBoardVerification2D[i, j];

                        if (currentSymbol == oldSymbol)
                            gameBoardVerification2D[i, j] = newSymbol;
                    }
                }
            }

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
            playerSymbolMove = GetNewPlayersSymbolsMove(playerSymbolMove, oldSymbolsForChande, newSymbolsForChande);
            ChangeDataForPlayersSymbolsMoveGameObjects(oldSymbolsForChande, newSymbolsForChande);
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
                                CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                        }
                    }
                }
            }
        }

        public static string[] ChangeDataForSymbolsForChange(string[] symbols, string staticText)
        {
            int numberOfSymbols = symbols.Length;
            string[] newSymbols = new string[numberOfSymbols];

            for (int i = 0; i < numberOfSymbols; i++)
            {
                string symbol = symbols[i];
                string newSymbol = symbol + staticText;
                newSymbols[i] = newSymbol;
            }

            return newSymbols;
        }

        public static string[] ChangeDataForNewSymbolsForChange(string[] newSymbolsForChange)
        {
            string staticText = "new";
            string[] newSymbols = ChangeDataForSymbolsForChange(newSymbolsForChange, staticText);
            return newSymbols;

        }

        public static string[] ChangeDataForOldSymbolsForChange(string[] oldSymbolsForChange)
        {
            string staticText = "old";
            string[] newSymbols = ChangeDataForSymbolsForChange(oldSymbolsForChange, staticText);
            return newSymbols;
        }

        public static string[] ChangeDataForPlayersSymbolsForChange(string[] playersSymbols)
        {
            int numberOfSymbols = playersSymbols.Length;
            string[] newPlayersSymbols = new string[numberOfSymbols];

            string staticText = "old";

            for (int i = 0; i < numberOfSymbols; i++)
            {
                string symbol = playersSymbols[i];
                string newSymbol = symbol + staticText;
                newPlayersSymbols[i] = newSymbol;
            }

            return newPlayersSymbols;
        }

        public static string RemoveExtraStaticTextFromStringToGetSymbol(string symbol)
        {
            string newSymbol = symbol.Substring(0, 1);
            return newSymbol;
        }

        public static string[] ChangePlayersSymbols(string[] playersSymbolsForChange, string[] symbolsForChangeNew, string[] symbolsForChangeOld)
        {
            int numberOfSymbols = playersSymbolsForChange.Length;
            int numberOfSymbolsForChange = symbolsForChangeNew.Length;

            for (int i = 0; i < numberOfSymbols; i++)
            {
                string currentSymbol = playersSymbolsForChange[i];

                for (int a = 0; a < numberOfSymbolsForChange; a++)
                {
                    string oldSymbol = symbolsForChangeOld[a];

                    if (currentSymbol == oldSymbol)
                    {
                        string newSymbol = symbolsForChangeNew[a];
                        playersSymbolsForChange[i] = newSymbol;
                    }
                }
            }

            return playersSymbolsForChange;
        }

        public static string[] FinalPlayersSymbols(string[] playersSymbolsAfterChange)
        {
            int numberOfSymbols = playersSymbolsAfterChange.Length;
            string[] finalSymbols = new string[numberOfSymbols];

            for (int i = 0; i < numberOfSymbols; i++)
            {
                string symbol = playersSymbolsAfterChange[i];
                string newSymbol = RemoveExtraStaticTextFromStringToGetSymbol(symbol);
                finalSymbols[i] = newSymbol;
            }

            return finalSymbols;
        }
        public static string[] SetUpNewPlayersSymbolsForTeamGame(string[] playersSymbols, string[] oldSymbolsForChange, string[] newSymbolsForChange)
        {
            string[] playersSymbolsForChange = ChangeDataForPlayersSymbolsForChange(playersSymbols);
            string[] symbolsForChangeNew = ChangeDataForNewSymbolsForChange(newSymbolsForChange);
            string[] symbolsForChangeOld = ChangeDataForOldSymbolsForChange(oldSymbolsForChange);


            int numberOfSymbols = playersSymbols.Length;
            int numberOfSymbolsForChange = symbolsForChangeNew.Length;

            string[] newPlayersSymbols = new string[numberOfSymbols];
            string[] playersSymbolsAfterChange = ChangePlayersSymbols(playersSymbolsForChange, symbolsForChangeNew, symbolsForChangeOld);
            string[] playersSymbolsFinal = FinalPlayersSymbols(playersSymbolsAfterChange);

            return playersSymbolsFinal;
        }
    }
}