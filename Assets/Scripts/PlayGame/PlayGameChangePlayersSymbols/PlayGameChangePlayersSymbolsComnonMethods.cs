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
    internal class PlayGameChangePlayersSymbolsComnonMethods
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

                string oldSymbol = oldSymbols.Substring(randomIndexToChange,1);
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

            bool isDoubleRandomChange;

            if ((timeForChandeRandomly > 0 || timeForChandeForAll > 0) && timeForSwitchBetweenTeams > 0)
            {
                isDoubleRandomChange = true;
            }
            else
            {
                isDoubleRandomChange = false;
            }

            return isDoubleRandomChange;
        }

        public static int SetUpStartSwitchChange()
        {
            return 0;
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

        public static int GetRandomMaxIndexForNewSymbols(int takenSymbolsLenght)
        {
            int minNumber = 1;
            int maxNumber = takenSymbolsLenght;
            int numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            return numberSymbolsToChange;

            //int minNumber = 0;
            //int maxNumber = takenSymbolsLenght - 1;
            //int numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            //return numberSymbolsToChange + 1;
        }

        public static int GetMaxIndexForNewSymbols(bool isChangeForAll, int takenSymbolsLenght)
        {
            int numberSymbolsToChange;

            if (isChangeForAll == false)
                numberSymbolsToChange = GetRandomMaxIndexForNewSymbols(takenSymbolsLenght);
            else
                numberSymbolsToChange = takenSymbolsLenght;

            return numberSymbolsToChange;
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
            string[] oldSymbolsForChange= new string[numberSymbolsToChange];
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

        public static List<string[]> GetNewDataForPlayersSymbols(string[] playersSymbols, List<float> gameChangeTimeConfiguration, int switchChange)
        {
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            float timeForChandeForAll = gameChangeTimeConfiguration[1];

            List<string[]> symbolsLists = new List<string[]>();

            if (switchChange == 0)
            {
                symbolsLists = GetNewPlayersSymbols(playersSymbols, timeForChandeRandomly);
            }
            else
            {

                Debug.Log("Upss it does not implemented yet, sorry :( ");

            }

            return symbolsLists;

        }

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

            //string[] takenSymbols = playersSymbols;
            int takenSymbolsLenght = playersSymbols.Length;

            bool isChangeForAll = IsChangeForAll(timeForChandeRandomly);

            //if (timeForChandeRandomly > 0)
            //{
            //    isChangeForAll = false;  
            //}
            //else
            //{
            //    isChangeForAll = true;
            //}


            //int numberSymbolsToChange;


            //if (timeForChandeRandomly > 0)
            //if (isChangeForAll == false)
            //{
            //    int minNumber = 1;
            //    int maxNumber = takenSymbolsLenght;
            //    //numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            //    numberSymbolsToChange = GetRandomMaxIndexForNewSymbols(takenSymbolsLenght);
            //}
            //else
            //{
            //    //Debug.Log("  for all   1");
            //    numberSymbolsToChange = takenSymbolsLenght;
            //}

            //Debug.Log("takenSymbolsLenght: " + takenSymbolsLenght);
            int numberSymbolsToChange = GetMaxIndexForNewSymbols(isChangeForAll, takenSymbolsLenght);
            //Debug.Log("numberSymbolsToChange: " + numberSymbolsToChange);
            //Debug.Log(" -------------------------------------------------------------- ");
            // create table for changes
            string[] newSymbolsForChange = new string[numberSymbolsToChange];
            string[] oldSymbolsForChange = new string[numberSymbolsToChange];


            // create string with untaken symbols
            //string untakenSymbols = PlayGameCommonPlayersSymbols.GetStringWithAllSymbols();


            //for (int i = 0; i < takenSymbolsLenght; i++)
            //{
            //    string takenSymbol = takenSymbols[i];
            //    int index = untakenSymbols.IndexOf(takenSymbol);
            //    string newString = untakenSymbols.Remove(index, 1);
            //    untakenSymbols = newString;
            //}

            //string untakenSymbols = SetUpUntakenSymbols(takenSymbols);


            // get random symbol - new symbols - for change from untaken players symbols for single game

            //Debug.Log("untakenSymbols: " + untakenSymbols);

            //int untakenSymbolsLength = untakenSymbols.Length;

            //int randomIndex = untakenSymbolsLength;
            ////Debug.Log("randomIndex: " + randomIndex);


            //for (int i = 0; i < numberSymbolsToChange; i++)
            //{
            //    int startIndex = GetRandomStartIndexForSymbol(randomIndex);
            //    //Debug.Log("startIndex: " + startIndex);
            //    randomIndex--;

            //    string newSymbols = untakenSymbols.Substring(startIndex, 1);

            //    randomNewSymbolsForChandeSingle[i] = newSymbols;

            //    untakenSymbols = untakenSymbols.Remove(startIndex, 1);


            //}



            //randomNewSymbolsForChandeSingle = GetNewSymbols(takenSymbols, numberSymbolsToChange);
            newSymbolsForChange = GetNewSymbols(playersSymbols, numberSymbolsToChange);

            // get random symbol - old symbols - for change from taken players symbols for single game


            //if (isChangeForAll == true)
            //{
            //    //Debug.Log("  for all   2");
            //    //randomOldSymbolsForChandeSingle = takenSymbols;

            //    for (int i = 0; i < playersSymbols.Length; i++)
            //    {
            //        string symbol = playersSymbols[i];
            //        randomOldSymbolsForChandeSingle[i] = symbol;
            //    }

            //    //for (int i = 0; i < randomOldSymbolsForChandeSingle.Length; i++)
            //    //{
            //    //    Debug.Log($"randomOldSymbolsForChandeSingle[{i}]: " + randomOldSymbolsForChandeSingle[i]);
            //    //}
            //}
            //else
            //{
            //    //    //Debug.Log("  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!                     ");
            //    //    // turn players symbols to one string
            //       string oldSymbols = "";

            //    for (int i = 0; i < takenSymbolsLenght; i++)
            //    {
            //    string symbol = takenSymbols[i];
            //    oldSymbols = oldSymbols + symbol;
            //    }

            ////Debug.Log("oldSymbols: " + oldSymbols);

            //// get random symbol - old symbol
            //int takenSymbolsLenght2 = playersSymbols.Length;
            //int randomIndex2 = takenSymbolsLenght2;
            ////Debug.Log("randomIndex2: " + randomIndex2);

            //    for (int i = 0; i < numberSymbolsToChange; i++)
            //    {
            //    int startIndex = GetRandomStartIndexForSymbol(randomIndex2);
            //    //Debug.Log("startIndex: " + startIndex);
            //    randomIndex2--;
            //    string oldSymbol = oldSymbols.Substring(startIndex, 1);

            //    randomOldSymbolsForChandeSingle[i] = oldSymbol;

            //    oldSymbols = oldSymbols.Remove(startIndex, 1);


            //    }

            //}


            //randomOldSymbolsForChandeSingle = GetOldSymbols(takenSymbols, numberSymbolsToChange, isChangeForAll);
            oldSymbolsForChange = GetOldSymbols(playersSymbols, numberSymbolsToChange, isChangeForAll);


            //// new players symbols - all layersSymbols.Length

            //for (int i = 0; i < numberSymbolsToChange; i++)
            //{
            //    string oldSymbol = randomOldSymbolsForChandeSingle[i];
            //    string newSymbol = randomNewSymbolsForChandeSingle[i];

            //    for (int j = 0; j < playersSymbols.Length; j++)
            //    {
            //        string takenSymbol = playersSymbols[j];

            //        if (takenSymbol == oldSymbol)
            //        {
            //            playersSymbols[j] = newSymbol;
            //        }
            //    }
            //}

            playersSymbols = GetNewPlayersSymbols(playersSymbols, oldSymbolsForChange, newSymbolsForChange, numberSymbolsToChange);
            //for (int i = 0; i < numberSymbolsToChange; i++)
            //{
            //    string oldSymbol = randomOldSymbolsForChandeSingle[i];
            //    string newSymbol = randomNewSymbolsForChandeSingle[i];

            //    for (int j = 0; j < takenSymbolsLenght; j++)
            //    {
            //        string takenSymbol = takenSymbols[j];

            //        if (takenSymbol == oldSymbol)
            //        {
            //            takenSymbols[i] = newSymbol;
            //        }
            //    }
            //}


            //Debug.Log("  ----------------------------------------    ");

            //for (int i = 0; i < randomOldSymbolsForChandeSingle.Length; i++)
            //{
            //    Debug.Log($"randomOldSymbolsForChandeSingle[{i}]: " + randomOldSymbolsForChandeSingle[i]);
            //}

            //Debug.Log("  ----------------------------------------    ");
            //for (int i = 0; i < randomNewSymbolsForChandeSingle.Length; i++)
            //{
            //    Debug.Log($"randomNewSymbolsForChandeSingle[{i}]: " + randomNewSymbolsForChandeSingle[i]);
            //}

            symbolsLists.Insert(0, oldSymbolsForChange);
            symbolsLists.Insert(1, newSymbolsForChange);
            //symbolsLists.Insert(2, takenSymbols);
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
        public static void SetUpNewPlayersSymbolsForGameBoard(GameObject[,, ] gameBoard, string[] oldSymbolsForChande, string[] newSymbolsForChande)
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


    }
}
