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

        //public static int GetRandomNumberPlayersToChangeSymbols(int newSymbolsForPlayersLenght)
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


        // to fix - again xD
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
        /// that will be work only max for 13 players, GameDictionariesCommonPlayersSymbols -> DictionaryPlayersSymbols
        /// </summary>
        /// <param name="playersSymbols"></param>
        /// <returns></returns>
        public static List<string[]> GetNewPlayersSymbols(string[] playersSymbols, float timeForChandeRandomly)
        {
            List<string[]> symbolsLists = new List<string[]>();

            string[] takenSymbols = playersSymbols;
            int takenSymbolsLenght = playersSymbols.Length;

            bool isChangeForAll;            

            if (timeForChandeRandomly > 0)
            {
                isChangeForAll = false;  
            }
            else
            {
                isChangeForAll = true;
            }


            int numberSymbolsToChange;

            //if (timeForChandeRandomly > 0)
            if (isChangeForAll == false)
            {
                int minNumber = 1;
                int maxNumber = takenSymbolsLenght;
                numberSymbolsToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            }
            else
            {
                //Debug.Log("  for all   1");
                numberSymbolsToChange = takenSymbolsLenght;
            }
                


            // create table for changes
            string[]  randomNewSymbolsForChandeSingle = new string[numberSymbolsToChange];
            string[]  randomOldSymbolsForChandeSingle = new string[numberSymbolsToChange];


            // create string with untaken symbols
            string untakenSymbols = PlayGameCommonPlayersSymbols.GetStringWithAllSymbols();
            

            for (int i = 0; i < takenSymbolsLenght; i++)
            {
                string takenSymbol = takenSymbols[i];
                int index = untakenSymbols.IndexOf(takenSymbol);
                string newString = untakenSymbols.Remove(index, 1);
                untakenSymbols = newString;
            }


            // get random symbol - new symbols - for change from untaken players symbols for single game

            //Debug.Log("untakenSymbols: " + untakenSymbols);

            int untakenSymbolsLength = untakenSymbols.Length;

            int randomIndex = untakenSymbolsLength;
           //Debug.Log("randomIndex: " + randomIndex);


            for (int i = 0; i < numberSymbolsToChange; i++)
            {
                int startIndex = GetRandomStartIndexForSymbol(randomIndex);
                //Debug.Log("startIndex: " + startIndex);
                randomIndex--;

                string newSymbols = untakenSymbols.Substring(startIndex, 1);

                randomNewSymbolsForChandeSingle[i] = newSymbols;

                untakenSymbols = untakenSymbols.Remove(startIndex, 1);


            }

            // get random symbol - old symbols - for change from taken players symbols for single game


            if (isChangeForAll == true)
            {
                //Debug.Log("  for all   2");
                //randomOldSymbolsForChandeSingle = takenSymbols;

                for (int i = 0; i < playersSymbols.Length; i++)
                {
                    string symbol = playersSymbols[i];
                    randomOldSymbolsForChandeSingle[i] = symbol;
                }

                //for (int i = 0; i < randomOldSymbolsForChandeSingle.Length; i++)
                //{
                //    Debug.Log($"randomOldSymbolsForChandeSingle[{i}]: " + randomOldSymbolsForChandeSingle[i]);
                //}
            }
            else
            {
                //Debug.Log("  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!                     ");
                // turn players symbols to one string
                string oldSymbols = "";

                for (int i = 0; i < takenSymbolsLenght; i++)
                {
                    string symbol = takenSymbols[i];
                    oldSymbols = oldSymbols + symbol;
                }

                //Debug.Log("oldSymbols: " + oldSymbols);

                // get random symbol - old symbol
                int takenSymbolsLenght2 = playersSymbols.Length;
                int randomIndex2 = takenSymbolsLenght2;
                //Debug.Log("randomIndex2: " + randomIndex2);

                for (int i = 0; i < numberSymbolsToChange; i++)
                {
                    int startIndex = GetRandomStartIndexForSymbol(randomIndex2);
                    //Debug.Log("startIndex: " + startIndex);
                    randomIndex2--;
                    string oldSymbol = oldSymbols.Substring(startIndex, 1);

                    randomOldSymbolsForChandeSingle[i] = oldSymbol;

                    oldSymbols = oldSymbols.Remove(startIndex, 1);


                }
            }





            //// new players symbols - all

            for (int i = 0; i < numberSymbolsToChange; i++)
            {
                string oldSymbol = randomOldSymbolsForChandeSingle[i];
                string newSymbol = randomNewSymbolsForChandeSingle[i];

                for (int j = 0; j < takenSymbolsLenght; j++)
                {
                    string takenSymbol = takenSymbols[j];

                    if (takenSymbol == oldSymbol)
                    {
                        takenSymbols[i] = newSymbol;
                    }
                }
            }


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

            symbolsLists.Insert(0, randomOldSymbolsForChandeSingle);
            symbolsLists.Insert(1, randomNewSymbolsForChandeSingle);
            symbolsLists.Insert(2, takenSymbols);

            return symbolsLists;
        }



        /// <summary>
        /// that will be work only max for 13 players, GameDictionariesCommonPlayersSymbols -> DictionaryPlayersSymbols
        /// </summary>
        /// <param name="playersSymbols"></param>
        /// <returns></returns>
        public static List<string[]> GetNewRandomPlayersSymbolsOldVersion(string[] playersSymbols, List<float> gameChangeTimeConfiguration)
        {
            List<string[]> symbolsLists = new List<string[]>();

            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            float timeForChandeForAll = gameChangeTimeConfiguration[1];
            float timeForSwitchBetweenTeams = gameChangeTimeConfiguration[2];

            string[] takenSymbols = playersSymbols;
            int takenSymbolsLenght = playersSymbols.Length;

            string[] newPlayersSymbols = new string[takenSymbolsLenght];


            bool isDoubleRandomChange;// = false;

            if ((timeForChandeRandomly > 0 || timeForChandeForAll > 0 ) && timeForSwitchBetweenTeams > 0)
            {
                isDoubleRandomChange = true;
            }
            else
            {
                isDoubleRandomChange = false;
            }


            int doubleRandom;

            if (isDoubleRandomChange == true)
            {
                doubleRandom = 2;
            }
            else
            {
                doubleRandom = 1;
            }

            int[] randomNumberToChange = new int[doubleRandom];


            for (int i = 0; i < doubleRandom; i++)
            {
                int minNumber = 1;
                int maxNumber = takenSymbolsLenght;
                int random = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
                takenSymbolsLenght = random;
                randomNumberToChange[i] = random;
            }


            // create table for changes
            string[] randomNewSymbolsForChandeSingle; // for all or randomly
            string[] randomOldSymbolsForChandeSingle; // for all or randomly
            string[] randomSymbolsForSwitchBetweenTeams;

            int singleChange = randomNumberToChange[0];
            int teamChange;
            randomNewSymbolsForChandeSingle = new string[singleChange];
            randomOldSymbolsForChandeSingle = new string[singleChange];

            if (isDoubleRandomChange == true)
            {
                teamChange = randomNumberToChange[1];  
                randomSymbolsForSwitchBetweenTeams = new string[teamChange];
            }

            // create string with untaken symbols
            string untakenSymbols = PlayGameCommonPlayersSymbols.GetStringWithAllSymbols();
            int untakenSymbolsLength = untakenSymbols.Length;

            for (int i = 0; i < takenSymbolsLenght; i++)
            {
                string takenSymbol = takenSymbols[i];
                int index = untakenSymbols.IndexOf(takenSymbol);
                string newString = untakenSymbols.Remove(index, 1);
                untakenSymbols = newString;
            }


            // get random symbol - new symbols - for change from untaken players symbols for single game

            
            for (int i = 0; i < singleChange; i++)
            {
                int startIndex = GetRandomStartIndexForSymbol(untakenSymbolsLength);

                string newSymbols = untakenSymbols.Substring(startIndex, 1);

                randomNewSymbolsForChandeSingle[i] = newSymbols;

                untakenSymbols = untakenSymbols.Remove(startIndex, 1);

                //untakenSymbols = newString;

            }

            // get random symbol - old symbols - for change from taken players symbols for single game

            // turn players symbols to one string
            string oldSymbols = "";

            for (int i = 0; i < takenSymbolsLenght; i++)
            {
                string symbol = takenSymbols[i];
                oldSymbols = oldSymbols + symbol;
            }



            // get random symbol - old symbol
            for (int i = 0; i < singleChange; i++)
            {
                int startIndex = GetRandomStartIndexForSymbol(takenSymbolsLenght);

                string oldSymbol = oldSymbols.Substring(startIndex, 1);

                randomOldSymbolsForChandeSingle[i] = oldSymbol;

                oldSymbols = oldSymbols.Remove(startIndex, 1);

                //oldSymbols = newString;

            }

            // new players symbols 

            for (int i = 0; i < singleChange; i++)
            {
                string oldSymbol = randomOldSymbolsForChandeSingle[i];
                string newSymbol = randomNewSymbolsForChandeSingle[i];

                for (int j = 0; j < takenSymbolsLenght; j++)
                {
                    string takenSymbol = takenSymbols[j];

                    if (takenSymbol == oldSymbol)
                    {
                        takenSymbols[i] = newSymbol;
                    }
                }
            }









            // get random symbol for team game



            //string[] newSymbolsForPlayers = new string[takenSymbolsLenght];
            //int newSymbolsForPlayersLength = newSymbolsForPlayers.Length;
            //int maxNumberForUntakenSymbol = untakenSymbolsLength - takenSymbolsLenght;


            //int maxRandomNumber = maxNumberForUntakenSymbol - 1;
            //for (int i = 0; i < newSymbolsForPlayersLength; i++)
            //{
            //    int randomIndex = GetRandomNumberPlayersToChangeSymbolsAll(maxRandomNumber);
            //    maxRandomNumber--;

            //    string newSymbols = untakenSymbols.Substring(randomIndex, 1);

            //    newSymbolsForPlayers[i] = newSymbols;

            //    string newString = untakenSymbols.Remove(randomIndex, 1);

            //    untakenSymbols = newString;

            //}

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

        public static void SetUpNewDataForGame(GameObject[,,] gameBoard, string[] oldSymbols, string[] newSymbols)
        {
            SetUpNewPlayersSymbolsForGameBoard(gameBoard, oldSymbols, newSymbols);
        }

        public static string[,] SetUpNewGameBoardVerification2D(string[,] gameBoardVerification2D, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            int cubePlayIndexY = gameBoardVerification2D.GetLength(0);
            int cubePlayIndexX = gameBoardVerification2D.GetLength(1);
            //string[,] newGameBoardVerification2D = new string[cubePlayIndexY, cubePlayIndexX];

            int newSymbolsToChange = newSymbolsForChande.Length;


            for (int z = 0; z < newSymbolsToChange; z++)
            {
                string newSymbol = newSymbolsForChande[z];
                string oldSymbol = oldSymbolsForChande[z];

                for (int i = 0; i < gameBoardVerification2D.GetLength(0); i++)
                {
                    for (int j = 0; j < gameBoardVerification2D.GetLength(1); j++)
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

        public static string[] SetUpNewPlayerSymbolMove(string[] playerSymbolMove, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            int playerSymbolMoveLength = playerSymbolMove.Length;
            int newSymbolsToChangeLength = newSymbolsForChande.Length;
            string[] newPlayerSymbolMove = new string[playerSymbolMoveLength];

            for (int z = 0; z < newSymbolsToChangeLength; z++)
            {
                string newSymbol = newSymbolsForChande[z];
                string oldSymbol = oldSymbolsForChande[z];

                for (int i = 0; i < playerSymbolMoveLength; i++)
                {

                    string currentSymbol = playerSymbolMove[i];

                    if (currentSymbol == oldSymbol)
                    {
                        newPlayerSymbolMove[i] = newSymbol;
                    }
                }

            }


            string tagPlayerSymbolCurrent = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolCurrent();
            string tagPlayerSymbolPrevious = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolPrevious();
            string tagPlayerSymbolNext = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolNext();

            string[] table = new string[3];
            table[0] = tagPlayerSymbolPrevious;
            table[1] = tagPlayerSymbolCurrent;
            table[2] = tagPlayerSymbolNext;

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


            return newPlayerSymbolMove;
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
