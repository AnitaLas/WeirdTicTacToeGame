using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Scripts.PlayGame
{
    internal class PlayGameChangePlayerSymbol
    {
        public static void SetUpPlayerSymbol(string playerSymbol, string tagPlayerSymbol)
        {
            GameObject playerSymbolMove = CommonMethods.GetObjectByTagName(tagPlayerSymbol);
            CommonMethods.ChangeTextForFirstChild(playerSymbolMove, playerSymbol);
        }

        public static void SetUpPlayerSymbolForMoveAtStart(string[] playersSymbols)
        {
            Dictionary<int, string> tagPlayerSymbolMoveDictionary = GameDictionariesSceneGame.DictionaryTagPlayerSymbolMove();
            string tagPlayerSymbolCurrent = tagPlayerSymbolMoveDictionary[1];
            string tagPlayerSymbolPrevious = tagPlayerSymbolMoveDictionary[2];
            string tagPlayerSymbolNext = tagPlayerSymbolMoveDictionary[3];

            // use only when number players = 2
            string defaultSymbol = "-";

            int playersNumber = playersSymbols.Length;
            int indexForPlayerSymbolPrevious = playersSymbols.Length - 1;

            // when players number >= 3 
            string firstPlayerSymbol = playersSymbols[0];
            string secondPlayerSymbol = playersSymbols[1];
            string lastPlayerSymbol = playersSymbols[indexForPlayerSymbolPrevious];

            // SetUpPlayerSymbolCurrent
            SetUpPlayerSymbol(firstPlayerSymbol, tagPlayerSymbolCurrent);

            if (playersNumber >= 3)
            {
                // SetUpPlayerSymbolPrevious
                SetUpPlayerSymbol(lastPlayerSymbol, tagPlayerSymbolPrevious);
                // SetUpPlayerSymbolNext
                SetUpPlayerSymbol(secondPlayerSymbol, tagPlayerSymbolNext);

            } 
            else
            {
                // SetUpPlayerSymbolPrevious
                SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolPrevious);
                // SetUpPlayerSymbolNext
                SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolNext);
            }
        }

        public static string[] CreateTableWithPlayersSymbolsMove(string[] playersSymbols)
        {
            int playersNumber = playersSymbols.Length;

            // 3x cube 
            int playerSymbolMoveLenght = 3;
            string[] playerSymbolMove = new string[playerSymbolMoveLenght];

            // PlayerSymbolCurrent
            playerSymbolMove[1] = playersSymbols[0];

            if (playersNumber >= 3)
            {
                // PlayerSymbolPrevious
                playerSymbolMove[0] = playersSymbols[playersNumber-1];
                // PlayerSymbolNext
                playerSymbolMove[2] = playersSymbols[1];

            }

            return playerSymbolMove;
        }


        public static void ChangePlayerSymbol(string playerSymbol, string tagPlayerSymbolDictionary)
        {
            GameObject playerSymbolMove = CommonMethods.GetObjectByTagName(tagPlayerSymbolDictionary);
            CommonMethods.ChangeTextForFirstChild(playerSymbolMove, playerSymbol);
        }   

        public static string[] ChangeCurrentPlayersSymbolsMove(string[] playerSymbolMove, string[] playersSymbols, int playersNumberGivenForConfiguration, int[] currentPlayer)
        {
            Dictionary<int, string> tagPlayerSymbolMoveDictionary = GameDictionariesSceneGame.DictionaryTagPlayerSymbolMove();

            string tagPlayerSymbolCurrent = tagPlayerSymbolMoveDictionary[1];
            string tagPlayerSymbolPrevious = tagPlayerSymbolMoveDictionary[2];
            string tagPlayerSymbolNext = tagPlayerSymbolMoveDictionary[3];

            int playerSymbolMoveLenght = 3;
            int currentPlayerNumber = currentPlayer[0];

            string[] newPlayerSymbolMove = new string[playerSymbolMoveLenght];
            string newPlayerSymbolCurrent;
            string newPlayerSymbolPrevious;
            string newPlayerSymbolNext;

            if (playersNumberGivenForConfiguration == 2)
            {            
                if (playersSymbols[0] == playerSymbolMove[1])
                {
                    newPlayerSymbolCurrent = playersSymbols[1];
                    newPlayerSymbolMove[1] = newPlayerSymbolCurrent;
                }
                else
                {
                    newPlayerSymbolCurrent = playersSymbols[0];
                    newPlayerSymbolMove[1] = newPlayerSymbolCurrent;
                }

                ChangePlayerSymbol(newPlayerSymbolCurrent, tagPlayerSymbolCurrent);
            }
            else
            {
                newPlayerSymbolCurrent = playerSymbolMove[2];
                newPlayerSymbolPrevious = playerSymbolMove[1];

                newPlayerSymbolMove[0] = newPlayerSymbolPrevious;
                newPlayerSymbolMove[1] = newPlayerSymbolCurrent;

                ChangePlayerSymbol(newPlayerSymbolCurrent, tagPlayerSymbolCurrent);
                ChangePlayerSymbol(newPlayerSymbolPrevious, tagPlayerSymbolPrevious);

                int nextPlayersSymbolsIndex = currentPlayerNumber + 2;

                if (currentPlayerNumber > 0 && currentPlayerNumber < playersSymbols.Length - 1)
                {
                    if (nextPlayersSymbolsIndex > playersSymbols.Length - 1)
                    {
                        newPlayerSymbolNext = playersSymbols[0];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }
                    else
                    {
                        newPlayerSymbolNext = playersSymbols[currentPlayerNumber + 2];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }
                }
                else
                {
                    if (currentPlayerNumber == playersSymbols.Length - 1)
                    {
                        newPlayerSymbolNext = playersSymbols[1];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }
                    else
                    {
                        newPlayerSymbolNext = playersSymbols[2];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }
                }

                return newPlayerSymbolMove;
            }

            return newPlayerSymbolMove;
        }

        public static void SetUpPlayerSymbolForWinner(bool isWinner, string winnerPlayerSymbol)
        {
            Dictionary<int, string> tagPlayerSymbolMoveDictionary = GameDictionariesSceneGame.DictionaryTagPlayerSymbolMove();

            string tagPlayerSymbolCurrent = tagPlayerSymbolMoveDictionary[1];
            string tagPlayerSymbolPrevious = tagPlayerSymbolMoveDictionary[2];
            string tagPlayerSymbolNext = tagPlayerSymbolMoveDictionary[3];
            string defaultSymbol = "-";

            if (isWinner == true)
            {
                // SetUpPlayerSymbolCurrent
                SetUpPlayerSymbol(winnerPlayerSymbol, tagPlayerSymbolCurrent);
            }
            else
            {
                SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolCurrent);
            }

            // SetUpPlayerSymbolPrevious
            SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolPrevious);
            // SetUpPlayerSymbolNext
            SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolNext);
        }
    }
}
