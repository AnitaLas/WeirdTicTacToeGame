using System;
using System.Collections.Generic;
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

        public static int GetRandomNumberPlayersToChangeSymbolsAll(int newSymbolsForPlayersLenght)
        {
            int minNumber = 1;
            //int maxNumber = playerSymbolMove.Length;
            int maxNumber = newSymbolsForPlayersLenght;
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

        /// <summary>
        /// that will be work only max for 13 players, GameDictionariesCommonPlayersSymbols -> DictionaryPlayersSymbols
        /// </summary>
        /// <param name="playersSymbols"></param>
        /// <returns></returns>
        public static string[] GetNewRandomPlayersSymbols(string[] playersSymbols, List<float> gameChangeTimeConfiguration)
        {
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            float timeForChandeForAll = gameChangeTimeConfiguration[1];
            float timeForSwitchBetweenTeams = gameChangeTimeConfiguration[2];

            //string[] takenSymbols = playersSymbols;
            //int takenSymbolsLenght = playersSymbols.Length; // change for all players.

            int takenSymbolsLenght = playersSymbols.Length;
            string[] takenSymbols = playersSymbols;



            if (timeForChandeForAll == 0 && timeForChandeRandomly > 0)
            {
                int minNumber = 1;
                int maxNumber = takenSymbolsLenght; 
                int random = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
                takenSymbolsLenght = random;
            }


            
            


            string allPossibleSymbols = PlayGameCommonPlayersSymbols.GetStringWithAllSymbols();
            int allPossibleSymbolsLenght = allPossibleSymbols.Length;

            

            string untakenSymbolsString;

            //string[] newSymbolsForPlayers = new string[takenSymbolsLenght];
            string[] newSymbolsForPlayers = new string[takenSymbolsLenght];
            int newSymbolsForPlayersLenght = newSymbolsForPlayers.Length;
            int maxNumberForUntakenSymbol = allPossibleSymbolsLenght - takenSymbolsLenght;

            untakenSymbolsString = allPossibleSymbols;

            for (int i = 0; i < takenSymbolsLenght; i++)
            {
                string takenSymbol = takenSymbols[i];
                int index = untakenSymbolsString.IndexOf(takenSymbol);
                string newString = untakenSymbolsString.Remove(index, 1);
                untakenSymbolsString = newString;
            }


            int maxRandomNumber = maxNumberForUntakenSymbol - 1;
            for (int i = 0; i < newSymbolsForPlayersLenght; i++)
            {
                int randomIndex = GetRandomNumberPlayersToChangeSymbolsAll(maxRandomNumber);
                maxRandomNumber--;

                string newSymbols = untakenSymbolsString.Substring(randomIndex, 1);

                newSymbolsForPlayers[i] = newSymbols;

                string newString = untakenSymbolsString.Remove(randomIndex, 1);

                untakenSymbolsString = newString;

            }

            return newSymbolsForPlayers;
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

        public static string[,] SetUpNewGameBoardVerification2D(string[,] gameBoardVerification2D, string[] oldSymbols, string[] newSymbols)
        {
            int cubePlayIndexY = gameBoardVerification2D.GetLength(0);
            int cubePlayIndexX = gameBoardVerification2D.GetLength(1);
            //string[,] newGameBoardVerification2D = new string[cubePlayIndexY, cubePlayIndexX];

            int newSymbolsToChange = newSymbols.Length;


            for (int z = 0; z < newSymbolsToChange; z++)
            {
                string newSymbol = newSymbols[z];
                string oldSymbol = oldSymbols[z];

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

        public static string[] SetUpNewPlayerSymbolMove(string[] playerSymbolMove, string[] playersSymbols, string[] newSymbols)
        {
            int playerSymbolMoveLength = playerSymbolMove.Length;
            int newSymbolsToChange = newSymbols.Length;
            string[] newPlayerSymbolMove = new string[playerSymbolMoveLength];

            for (int z = 0; z < newSymbolsToChange; z++)
            {
                string newSymbol = newSymbols[z];
                string oldSymbol = playersSymbols[z];

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
                string newSymbol = newPlayerSymbolMove[i];
                string tagName = table[i];
                GameObject cubePlay = GameCommonMethodsMain.GetObjectByTagName(tagName);
                GameCommonMethodsMain.ChangeTextForFirstChild(cubePlay, newSymbol);
            }


            return newPlayerSymbolMove;
        }


        //--------------------------------------------------------------------------------------------------------
        public static void SetUpNewPlayersSymbolsForGameBoard(GameObject[,, ] gameBoard, string[] oldSymbols, string[] newSymbols)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);
            int newSymbolsToChange = newSymbols.Length;

            for (int i = 0; i < newSymbolsToChange; i++)
            {
                string newSymbol = newSymbols[i];
                string oldSymbol = oldSymbols[i];

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
