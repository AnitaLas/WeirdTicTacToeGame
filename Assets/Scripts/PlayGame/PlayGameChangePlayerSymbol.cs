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
            //string gameObjectTagName = tagPlayerSymbolDictionary[indexForDictionary];
            GameObject[] gameObjectForPlayerSymbol = CommonMethods.GetObjectByTagName(tagPlayerSymbol);

            //string playerSymbol = playersSymbols[indexForPlayerSymbol];

            GameObject playerSymbolMove = gameObjectForPlayerSymbol[0];
            CommonMethods.ChangeTextForCubePlay(playerSymbolMove, playerSymbol);
        }

        //public static void SetUpPlayerSymbolCurrent(string playerSymbol, string tagPlayerSymbolCurrent)
        //{
        //    //int indexForDictionaryCurrent = 1;
        //    //int indexForPlayerSymbolCurrent = 0;
        //    SetUpPlayerSymbol(playerSymbol, tagPlayerSymbolCurrent);
        //}

        //public static void SetUpPlayerSymbolPrevious(string playerSymbol, string tagPlayerSymbolPrevious)
        //{
        //    //int indexForDictionaryPrevious = 2;
        //   //int indexForPlayerSymbolPrevious = playersSymbols.Length - 1;
        //    SetUpPlayerSymbol(playerSymbol, tagPlayerSymbolPrevious);
        //}

        //public static void SetUpPlayerSymbolNext(string playerSymbol, string tagPlayerSymbolNext)
        //{
        //    //int indexForDictionaryNext = 3;
        //    //int indexForPlayerSymbolNext = 1;
        //    SetUpPlayerSymbol(playerSymbol, tagPlayerSymbolNext);
        //}

        public static void SetUpPlayerSymbolForMove(string[] playersSymbols, string tagPlayerSymbolCurrent, string tagPlayerSymbolPrevious, string tagPlayerSymbolNext)
        {
            //Dictionary<int, string> tagPlayerSymbolDictionary = GameDictionariesCommon.DictionaryTagPlayerSymbol();
            int playersNumber = playersSymbols.Length;
            int indexForPlayerSymbolPrevious = playersSymbols.Length - 1;

            // use only when number players = 2
            string defaultSymbol = "-";

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

            //for (int i = 0; i < playerSymbolMoveLenght; i++)
            //{
            //    Debug.Log($"playerSymbolMove[{i}] = " + playerSymbolMove[i]);
            //}

            return playerSymbolMove;
        }


        public static void ChangePlayerSymbol(string playerSymbol, string tagPlayerSymbolDictionary)
        {
            //string gameObjectTagName = tagPlayerSymbolDictionary[indexForDictionary];
            GameObject[] gameObjectForPlayerSymbol = CommonMethods.GetObjectByTagName(tagPlayerSymbolDictionary);

            //string playerSymbol = playersSymbols[indexForPlayerSymbol];

            GameObject playerSymbolMove = gameObjectForPlayerSymbol[0];
            CommonMethods.ChangeTextForCubePlay(playerSymbolMove, playerSymbol);
        }
        /*
        public static void ChangePlayerSymbolCurrent(string playerSymbol, string tagPlayerSymbolDictionary)
        {
            ChangePlayerSymbol(playerSymbol, tagPlayerSymbolDictionary);
        }
        */


        public static string[] ChangeCurrentPlayersSymbolsMove(string[] playerSymbolMove, string[] playersSymbols, int playersNumberGivenForConfiguration, int[] currentPlayer, string tagPlayerSymbolCurrent, string tagPlayerSymbolPrevious, string tagPlayerSymbolNext)
        {
            int playerSymbolMoveLenght = 3;
            int currentPlayerNumber = currentPlayer[0];
           // Debug.Log("currentPlayerNumber = " + currentPlayerNumber);

            string[] newPlayerSymbolMove = new string[playerSymbolMoveLenght];
            string newPlayerSymbolCurrent;
            string newPlayerSymbolPrevious;
            string newPlayerSymbolNext;

            // Dictionary<int, string> tagPlayerSymbolDictionary = GameDictionariesCommon.DictionaryTagPlayerSymbol();

            //string tagPlayerSymbolCurrent = tagPlayerSymbolDictionary[1];
            // string tagPlayerSymbolPrevious = tagPlayerSymbolDictionary[2];
            // string tagPlayerSymbolNext = tagPlayerSymbolDictionary[3];

            if (playersNumberGivenForConfiguration == 2)
            {
               
                if (playersSymbols[0] == playerSymbolMove[1])
                {
                    newPlayerSymbolCurrent = playersSymbols[1];
                    newPlayerSymbolMove[1] = newPlayerSymbolCurrent;
                    //ChangePlayerSymbol(newPlayerSymbolCurrent, tagPlayerSymbolCurrent);
                }
                else
                {
                    newPlayerSymbolCurrent = playersSymbols[0];
                    newPlayerSymbolMove[1] = newPlayerSymbolCurrent;
                    //ChangePlayerSymbol(newPlayerSymbolCurrent, tagPlayerSymbolCurrent);
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
                //Debug.Log("test = " + nextPlayersSymbolsIndex);

                if (currentPlayerNumber > 0 && currentPlayerNumber < playersSymbols.Length - 1)
                {
                   

                    if (nextPlayersSymbolsIndex > playersSymbols.Length - 1)
                    {
                       // Debug.Log("  1  ");
                       // Debug.Log("test = " + nextPlayersSymbolsIndex);
                        newPlayerSymbolNext = playersSymbols[0];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);

                    }
                    else
                    {
                        //Debug.Log("  3  ");
                       // Debug.Log("test = " + nextPlayersSymbolsIndex);
                        newPlayerSymbolNext = playersSymbols[currentPlayerNumber + 2];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);

                    }
                }
                else
                {
                    if (currentPlayerNumber == playersSymbols.Length - 1)
                    {
                       // Debug.Log("  4  ");
                        newPlayerSymbolNext = playersSymbols[1];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);

                    }
                    else
                    {
                        //Debug.Log("  5  ");
                        newPlayerSymbolNext = playersSymbols[2];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);

                    }
                }

                //Debug.Log(" ----------------------------------------------------- ");

                return newPlayerSymbolMove;
            }

            return newPlayerSymbolMove;

        }




        public static void SetUpPlayerSymbolForWinner(string winnerPlayerSymbol, string tagPlayerSymbolCurrent, string tagPlayerSymbolPrevious, string tagPlayerSymbolNext)
        {
            // use for smaller green cube for player symbol move
            string defaultSymbol = "-";


            // SetUpPlayerSymbolCurrent
           SetUpPlayerSymbol(winnerPlayerSymbol, tagPlayerSymbolCurrent);

           // SetUpPlayerSymbolPrevious
           SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolPrevious);
           // SetUpPlayerSymbolNext
           SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolNext);
           
        }

    }
}
