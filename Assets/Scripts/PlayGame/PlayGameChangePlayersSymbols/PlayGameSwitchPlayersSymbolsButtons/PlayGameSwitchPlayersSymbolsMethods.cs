using System;
using System.Collections;
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
    internal class PlayGameSwitchPlayersSymbolsMethods
    {
        public static string GetIndexesForSwitchAsString(int playersSymbols)
        {
            string numbers = "";

            for (int i = 0; i < playersSymbols; i++)
            {
                numbers = numbers + i;
            }

            return numbers;
        }

        public static string GetIndexesAsString(int playersSymbols)
        {
            string numbers = "";

            for (int i = 0; i < playersSymbols; i++)
            {
                numbers = numbers + i;
            }

            return numbers;
        }

        public static string GetStaicIndexesForSwitch()
        {
            string numbers = "10";
            return numbers;
        }

        public static int[] GetIndexesForSwitch(int playersSymbols, int maxSymbolsNumberForChange)
        {
            int maxSymbols = maxSymbolsNumberForChange;
            int[] indexes = new int[maxSymbolsNumberForChange];

            string allNumbers = GetIndexesAsString(playersSymbols);
            string numbers = allNumbers;

            int minIndexNumber = 0;
            int maxIndexNumber = playersSymbols - 1;

            for (int i = 0; i < maxSymbols; i++)
            {
                int randomIndexToChange = CommonMethods.ChooseRandomNumber(minIndexNumber, maxIndexNumber);
                string index = numbers.Substring(randomIndexToChange, 1);
                int finaleIndex = CommonMethods.ConvertStringToInt(index);
                indexes[i] = finaleIndex;
                maxIndexNumber--;
                numbers = numbers.Remove(randomIndexToChange, 1);
            }

            return indexes;
        }

        public static ArrayList GetSymoblsForSwitch(List<string[]> teamGameSymbols)
        {
            ArrayList dataForSwitch = new ArrayList();

            List<string[]> oldSymbolsForSwitch = new List<string[]>();
            List<int[]> randomIndexesForSwitch = new List<int[]>();

            int maxSymbolsNumberForSwitch = PlayGameChangePlayersSymbolsMethods.GetMinPlayersNumberForTeam(teamGameSymbols);
            int minSymbolsNumberForSwitch = 1;

            if (maxSymbolsNumberForSwitch > minSymbolsNumberForSwitch)
                maxSymbolsNumberForSwitch = CommonMethods.ChooseRandomNumber(minSymbolsNumberForSwitch, maxSymbolsNumberForSwitch);

            else
                maxSymbolsNumberForSwitch = minSymbolsNumberForSwitch;

            int teamsNumbers = teamGameSymbols.Count;

            int[] indexesForSwitch;
            int numbersOfSymbolsToSwitch;

            for (int t = 0; t < teamsNumbers; t++)
            {
                string[] teamSymbols = teamGameSymbols[t];
                int playersSymbols = teamSymbols.Length;

                indexesForSwitch = GetIndexesForSwitch(playersSymbols, maxSymbolsNumberForSwitch);
                randomIndexesForSwitch.Insert(t, indexesForSwitch);
                numbersOfSymbolsToSwitch = indexesForSwitch.Length;

                string[] symbolsToSwitch = new string[maxSymbolsNumberForSwitch];

                for (int a = 0; a < numbersOfSymbolsToSwitch; a++)
                {
                    int indexToSwitch = indexesForSwitch[a];
                    string symbol = teamSymbols[indexToSwitch];
                    symbolsToSwitch[a] = symbol;
                }

                oldSymbolsForSwitch.Insert(0, symbolsToSwitch);
            }

            dataForSwitch.Insert(0, randomIndexesForSwitch);
            dataForSwitch.Insert(1, oldSymbolsForSwitch);
            dataForSwitch.Insert(2, randomIndexesForSwitch);

            return dataForSwitch;
        }

        public static int[] GetIndexesForRightMove(int teamsNumbers)
        {
            int[] newIndexes = new int[teamsNumbers];
            newIndexes[0] = teamsNumbers - 1;

            for (int i = 1; i < teamsNumbers; i++)
            {
                int index = i - 1;
                newIndexes[i] = index;
            }

            return newIndexes;
        }


        public static int[] GetIndexesForLeftMove(int teamsNumbers)
        {
            int[] newIndexes = new int[teamsNumbers];
            int lastIndex = teamsNumbers - 1;
            newIndexes[lastIndex] = 0;

            for (int i = 0; i < teamsNumbers - 1; i++)
            {
                int index = i + 1;
                newIndexes[i] = index;
            }

            return newIndexes;
        }

        public static List<string[]> SetUpSymbolsForSwitch(List<string[]> symbolsForSwitch)
        {
            List<string[]> switchedSymbols = new List<string[]>();
            int teamsNumbers = symbolsForSwitch.Count;

            int[] indexes; // = new int[playersSymbols];

            int startIndex = 0;

            bool isStartIndexEven = CommonMethods.IsNumberEven(startIndex);

            if (isStartIndexEven == true)
                indexes = GetIndexesForRightMove(teamsNumbers);

            else
                indexes = GetIndexesForLeftMove(teamsNumbers);

            for (int i = 0; i < teamsNumbers; i++)
            {
                int finalIndex = indexes[i];
                string[] team = symbolsForSwitch[finalIndex];
                switchedSymbols.Insert(i, team);

            }

            return switchedSymbols;
        }

        public static ArrayList GetPlayersSymbolsForSwitch(List<string[]> teamGameSymbols)
        {
            ArrayList allDataForSwitch = new ArrayList();

            ArrayList dataForSwitch = GetSymoblsForSwitch(teamGameSymbols);
            List<string[]> symbolsForSwitch = (List<string[]>)dataForSwitch[1];
            List<int[]> randomIndexesForSwitch = (List<int[]>)dataForSwitch[0];

            // "new symbols"
            List<string[]> switchedSymbols = SetUpSymbolsForSwitch(symbolsForSwitch);

            allDataForSwitch.Insert(0, symbolsForSwitch);
            allDataForSwitch.Insert(1, switchedSymbols);
            allDataForSwitch.Insert(2, randomIndexesForSwitch);

            return allDataForSwitch;
        }

        //--------------------------------------------------------------------------------------------------------

        public static GameObject[,,] ChangeDataForOldSymbolsForSwitch(GameObject[,,] gameBoard, List<string[]> oldSymbols)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);

            int teamsNumbers = oldSymbols.Count;

            string staticText = "old"; // old

            for (int a = 0; a < teamsNumbers; a++)
            {
                string[] team = oldSymbols[a];
                int playersNumners = team.Length;

                for (int l = 0; l < playersNumners; l++)
                {
                    string oldSymbol = team[l];

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
                                    string newSymbol = currentCubePlaySymbol + staticText;
                                    CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                                }
                            }
                        }
                    }
                }
            }

            return gameBoard;
        }

        public static void SwitchOldSymbolsForNew(GameObject[,,] gameBoard, List<string[]> oldSymbols, List<string[]> symbolsForSwitch)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);
            int teamsNumbers = oldSymbols.Count;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamOldSymbols = oldSymbols[i];
                string[] teamNewSymbols = symbolsForSwitch[i];

                int playersNumbers = teamOldSymbols.Length;

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                            string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

                            for (int p = 0; p < playersNumbers; p++)
                            {
                                string oldSymbol = teamOldSymbols[p];

                                if (currentCubePlaySymbol == oldSymbol)
                                {
                                    string newSymbol = teamNewSymbols[p];
                                    CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void SetUpFinalSymbolsForGameBoard(GameObject[,,] gameBoard)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                        string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

                        int currentCubePlaySymbolLength = currentCubePlaySymbol.Length;

                        if (currentCubePlaySymbolLength == 4) // symbol A + new = Anew -> 4
                        {
                            string newSymbol = RemoveExtraStaticTextFromStringToGetSymbol(currentCubePlaySymbol);
                            CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                        }
                    }
                }
            }
        }

        public static List<string[]> ChangeDataForSymbolsForSwitch(List<string[]> symbols, string staticText)
        {
            int teamsNumbers = symbols.Count;

            List<string[]> newOldSymbols = new List<string[]>();

            for (int a = 0; a < teamsNumbers; a++)
            {
                string[] team = symbols[a];
                int playersNumners = team.Length;
                string[] newSymbols = new string[playersNumners];

                for (int l = 0; l < playersNumners; l++)
                {
                    string oldSymbol = team[l];
                    string newSymbol = oldSymbol + staticText;
                    newSymbols[l] = newSymbol;

                }
                newOldSymbols.Insert(a, newSymbols);
            }

            return newOldSymbols;
        }


        public static void SetUpSwitchedPlayersSymbolsForGameBoard(GameObject[,,] gameBoard, ArrayList newDataForPlayersSymbolsSwitch)
        {
            List<string[]> oldSymbolsForSwitch = (List<string[]>)newDataForPlayersSymbolsSwitch[1];
            List<string[]> newSymbolsForSwitch = (List<string[]>)newDataForPlayersSymbolsSwitch[0];
            int teamsNumbers = oldSymbolsForSwitch.Count - 1;

            ChangeDataForOldSymbolsForSwitch(gameBoard, oldSymbolsForSwitch);

            List<string[]> symbolsForSwitchNew = ChangeDataForNewSymbolsForSwitch(newSymbolsForSwitch);
            List<string[]> symbolsForSwitchOld = ChangeDataForOldSymbolsForSwitch(oldSymbolsForSwitch);

            SwitchOldSymbolsForNew(gameBoard, symbolsForSwitchOld, symbolsForSwitchNew);
            SetUpFinalSymbolsForGameBoard(gameBoard);
        }

        public static List<string[]> ChangeDataForNewSymbolsForSwitch(List<string[]> newSymbolsForSwitch)
        {
            string staticTextForNew = "new";
            List<string[]> symbolsForSwitchNew = ChangeDataForSymbolsForSwitch(newSymbolsForSwitch, staticTextForNew);
            return symbolsForSwitchNew;
        }

        public static List<string[]> ChangeDataForOldSymbolsForSwitch(List<string[]> oldSymbolsForSwitch)
        {
            string staticTextForOld = "old";
            List<string[]> symbolsForSwitchOld = ChangeDataForSymbolsForSwitch(oldSymbolsForSwitch, staticTextForOld);
            return symbolsForSwitchOld;
        }

        public static List<string[]> SetUpNewTeamGameSymbols(ArrayList newDataForPlayersSymbolsSwitch, List<string[]> teamGameSymbols)
        {
            List<string[]> newSymbolsForSwitch = (List<string[]>)newDataForPlayersSymbolsSwitch[0];

            List<int[]> randomIndexesForSwitch = (List<int[]>)newDataForPlayersSymbolsSwitch[2];

            int teamsNumbers = teamGameSymbols.Count;

            List<string[]> newTeamsSymbols = new List<string[]>();

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] oldTeamSymbols = teamGameSymbols[i];
                string[] newTeamSymbols = newSymbolsForSwitch[i];

                int[] indexesForSwitch = randomIndexesForSwitch[i];
                int oldSymbolsNumber = oldTeamSymbols.Length;

                int newSymbolsNumber = newTeamSymbols.Length;
                string[] switchedSymbols = new string[oldSymbolsNumber];

                int indexSymbol = 0;
                int indexesCounted = 0;
                int oldIndex = 0;

                for (int j = 0; j < oldSymbolsNumber; j++)
                {

                    if (indexesCounted < newSymbolsNumber)
                    {
                        oldIndex = indexesForSwitch[indexSymbol];
                        indexesCounted++;
                    }

                    if (oldIndex == j)
                    {
                        string newSymbol = newTeamSymbols[indexSymbol];
                        switchedSymbols[j] = newSymbol;
                        indexSymbol++;
                    }
                    else
                    {
                        string oldSymbol = oldTeamSymbols[j];
                        switchedSymbols[j] = oldSymbol;
                    }
                }

                newTeamsSymbols.Insert(i, switchedSymbols);
            }

            return newTeamsSymbols;
        }

        // -----
        public static string[] GetNewPlayersSymbolsMove(string[] playerSymbolMove, string[] oldSymbolsForChande, string[] finalNewSymbolsForSwitch)
        {
            int playerSymbolMoveLength = playerSymbolMove.Length;
            int oldSymbolsToChangeLength = oldSymbolsForChande.Length;

            for (int i = 0; i < playerSymbolMoveLength; i++)
            {
                string oldSymbol = playerSymbolMove[i];

                for (int j = 0; j < oldSymbolsToChangeLength; j++)
                {
                    string symbolToCompare = oldSymbolsForChande[j];

                    if (oldSymbol == symbolToCompare)
                    {
                        string symbol = finalNewSymbolsForSwitch[j];
                        string newSymbol = RemoveExtraStaticTextFromStringToGetSymbol(symbol);
                        playerSymbolMove[i] = newSymbol;

                    }

                }
            }

            return playerSymbolMove;
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

        public static string RemoveExtraStaticTextFromStringToGetSymbol(string symbol)
        {
            string newSymbol = symbol.Substring(0, 1);
            return newSymbol;
        }

        public static void ChangeDataForPlayersSymbolsMoveGameObjects(string[] oldSymbolsForChande, string[] finalNewSymbolsForSwitch)
        {
            string[] table = CreateTableWithTagsForPlayerSymbolMove();
            int newSymbolsToChangeLength = finalNewSymbolsForSwitch.Length;

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
                        string symbol = finalNewSymbolsForSwitch[j];
                        string newSymbol = RemoveExtraStaticTextFromStringToGetSymbol(symbol);
                        GameCommonMethodsMain.ChangeTextForFirstChild(cubePlay, newSymbol);
                    }
                }
            }
        }

        public static string[] GetSymbolsAsOneTable(List<string[]> teamsSymbols, int playersNumberForChangeSymbols)
        {
            string[] symbols = new string[playersNumberForChangeSymbols];
            int teamsNumbers = teamsSymbols.Count;
            int index = 0;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamsSymbols[i];
                int playersNumbers = teamSymbols.Length;

                for (int j = 0; j < playersNumbers; j++)
                {
                    string teamSymbol = teamSymbols[j];
                    symbols[index] = teamSymbol;
                    index++;
                }
            }

            return symbols;
        }

        public static int GetNumbersForCountedSymbolsToChange(List<string[]> teams)
        {
            int playersNumbers = 0;
            int teamsNumbers = teams.Count;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teams[i];
                int symbolsNumbers = teamSymbols.Length;
                playersNumbers = playersNumbers + symbolsNumbers;
            }

            return playersNumbers;
        }

        public static string[] SetUpNewPlayersSymbolsMove(string[] playerSymbolMove, ArrayList newDataForPlayersSymbolsSwitch)
        {

            List<string[]> oldTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[0];
            List<string[]> newTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[1];

            int playersNumberForChangeSymbols = GetNumbersForCountedSymbolsToChange(newTeamsSymbols);

            string[] oldSymbolsForSwitch = GetSymbolsAsOneTable(oldTeamsSymbols, playersNumberForChangeSymbols);
            string[] newSymbolsForSwitch = GetSymbolsAsOneTable(newTeamsSymbols, playersNumberForChangeSymbols);

            string[] finalNewSymbolsForSwitch = ChangeDataForNewSymbolsForSwitch(newSymbolsForSwitch);

            playerSymbolMove = GetNewPlayersSymbolsMove(playerSymbolMove, oldSymbolsForSwitch, finalNewSymbolsForSwitch);
            ChangeDataForPlayersSymbolsMoveGameObjects(oldSymbolsForSwitch, finalNewSymbolsForSwitch);

            return playerSymbolMove;
        }

        // player symbol switch
        public static string[] ChangeDataForNewSymbolsForSwitch(string[] newSymbolsForSwitch)
        {
            string staticText = "new";
            int oldSymbolsForSwitchNumber = newSymbolsForSwitch.Length;

            for (int i = 0; i < oldSymbolsForSwitchNumber; i++)
            {
                string symbol = newSymbolsForSwitch[i];
                string textForSwitch = symbol + staticText;
                newSymbolsForSwitch[i] = textForSwitch;
            }

            return newSymbolsForSwitch;
        }

        public static string[] GetNewPlayersSymbols(string[] playersSymbols, ArrayList newDataForPlayersSymbolsSwitch)
        {
            int symbolsNumbers = playersSymbols.Length;

            List<string[]> oldTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[0];
            List<string[]> newTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[1];

            int playersNumberForChangeSymbols = GetNumbersForCountedSymbolsToChange(newTeamsSymbols);

            string[] oldSymbolsForSwitch = GetSymbolsAsOneTable(oldTeamsSymbols, playersNumberForChangeSymbols);
            string[] newSymbolsForSwitch = GetSymbolsAsOneTable(newTeamsSymbols, playersNumberForChangeSymbols);

            string[] finalNewSymbolsForSwitch = ChangeDataForNewSymbolsForSwitch(newSymbolsForSwitch);

            int oldSymbolsNumbers = oldSymbolsForSwitch.Length;

            for (int i = 0; i < symbolsNumbers; i++)
            {
                string currentSymbol = playersSymbols[i];

                for (int a = 0; a < oldSymbolsNumbers; a++)
                {
                    string oldSymbol = oldSymbolsForSwitch[a];

                    if (currentSymbol == oldSymbol)
                        playersSymbols[i] = finalNewSymbolsForSwitch[a];
                }
            }

            for (int i = 0; i < symbolsNumbers; i++)
            {
                string symbol = playersSymbols[i];
                int symbolLength = symbol.Length;

                if (symbolLength > 1)
                {
                    string newSymbol = RemoveExtraStaticTextFromStringToGetSymbol(symbol);
                    playersSymbols[i] = newSymbol;
                }
            }

            return playersSymbols;
        }


        public static string[,] SetUpNewGameBoardVerification2D(string[,] gameBoardVerification2D, ArrayList newDataForPlayersSymbolsSwitch)
        {
            List<string[]> oldTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[0];
            List<string[]> newTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[1];

            int playersNumberForChangeSymbols = GetNumbersForCountedSymbolsToChange(newTeamsSymbols);

            string[] oldSymbolsForSwitch = GetSymbolsAsOneTable(oldTeamsSymbols, playersNumberForChangeSymbols);
            string[] newSymbolsForSwitch = GetSymbolsAsOneTable(newTeamsSymbols, playersNumberForChangeSymbols);

            // one method must be created PlayGameChangePlayersSymbolsMethods + PlayGameSwitchPlayersSymbolsMethods
            string[] finalNewSymbolsForSwitch = ChangeDataForNewSymbolsForSwitch(newSymbolsForSwitch);


            int cubePlayIndexY = gameBoardVerification2D.GetLength(0);
            int cubePlayIndexX = gameBoardVerification2D.GetLength(1);
            int newSymbolsToChange = newSymbolsForSwitch.Length;

            for (int z = 0; z < newSymbolsToChange; z++)
            {
                string newSymbol = finalNewSymbolsForSwitch[z];
                string oldSymbol = oldSymbolsForSwitch[z];

                for (int i = 0; i < cubePlayIndexY; i++)
                {
                    for (int j = 0; j < cubePlayIndexX; j++)
                    {
                        string currentSymbol = gameBoardVerification2D[i, j];

                        if (currentSymbol == oldSymbol)
                        {
                            string symbol = RemoveExtraStaticTextFromStringToGetSymbol(newSymbol);
                            gameBoardVerification2D[i, j] = symbol;
                        }
                    }
                }
            }

            return gameBoardVerification2D;
        }

    }
}