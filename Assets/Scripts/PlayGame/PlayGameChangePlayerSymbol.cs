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

        public static void SetUpPlayerSymbol(string[] playersSymbols, Dictionary<int, string> tagPlayerSymbolDictionary, int indexForDictionary, int indexForPlayerSymbol)
        {
            string gameObjectTagName = tagPlayerSymbolDictionary[indexForDictionary];
            GameObject[] gameObjectForPlayerSymbol = CommonMethods.GetObjectByTagName(gameObjectTagName);

            string playerSymbol = playersSymbols[indexForPlayerSymbol];

            GameObject playerSymbolMove = gameObjectForPlayerSymbol[0];
            CommonMethods.ChangeTextForCubePlay(playerSymbolMove, playerSymbol);
        }

        public static void SetUpPlayerSymbolCurrent(string[] playersSymbols, Dictionary<int, string> tagPlayerSymbolDictionary)
        {
            int indexForDictionaryCurrent = 1;
            int indexForPlayerSymbolCurrent = 0;
            SetUpPlayerSymbol(playersSymbols, tagPlayerSymbolDictionary, indexForDictionaryCurrent, indexForPlayerSymbolCurrent);
        }

        public static void SetUpPlayerSymbolPrevious(string[] playersSymbols, Dictionary<int, string> tagPlayerSymbolDictionary)
        {
            int indexForDictionaryPrevious = 2;
            int indexForPlayerSymbolPrevious = playersSymbols.Length - 1;
            SetUpPlayerSymbol(playersSymbols, tagPlayerSymbolDictionary, indexForDictionaryPrevious, indexForPlayerSymbolPrevious);
        }

        public static void SetUpPlayerSymbolNext(string[] playersSymbols, Dictionary<int, string> tagPlayerSymbolDictionary)
        {
            int indexForDictionaryNext = 3;
            int indexForPlayerSymbolNext = 1;
            SetUpPlayerSymbol(playersSymbols, tagPlayerSymbolDictionary, indexForDictionaryNext, indexForPlayerSymbolNext);
        }

        public static void SetUpPlayerSymbolForMove(string[] playersSymbols)
        {
            Dictionary<int, string> tagPlayerSymbolDictionary = GameDictionariesCommon.DictionaryTagPlayerSymbol();
            int playersNumber = playersSymbols.Length;

            SetUpPlayerSymbolCurrent(playersSymbols, tagPlayerSymbolDictionary);

            if (playersNumber >= 3)
            {
                SetUpPlayerSymbolPrevious(playersSymbols, tagPlayerSymbolDictionary);
                SetUpPlayerSymbolNext(playersSymbols, tagPlayerSymbolDictionary);

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


        public static string[] ChangeCurrentPlayersSymbolsMove(string[] playerSymbolMove, string[] playersSymbols, int playersNumberGivenForConfiguration, int[] currentPlayer)
        {
            int playerSymbolMoveLenght = 3;
            int currentPlayerNumber = currentPlayer[0];
            Debug.Log("currentPlayerNumber = " + currentPlayerNumber);

            string[] newPlayerSymbolMove = new string[playerSymbolMoveLenght];

            Dictionary<int, string> tagPlayerSymbolDictionary = GameDictionariesCommon.DictionaryTagPlayerSymbol();

            string tagPlayerSymbolCurrent = tagPlayerSymbolDictionary[1];
            string tagPlayerSymbolPrevious = tagPlayerSymbolDictionary[2];
            string tagPlayerSymbolNext = tagPlayerSymbolDictionary[3];

            if (playersNumberGivenForConfiguration == 2)
            {



            }
            else
            {
                string newPlayerSymbolCurrent = playerSymbolMove[2];
                string newPlayerSymbolPrevious = playerSymbolMove[1];

                newPlayerSymbolMove[0] = newPlayerSymbolPrevious;
                newPlayerSymbolMove[1] = newPlayerSymbolCurrent;

                ChangePlayerSymbol(newPlayerSymbolCurrent, tagPlayerSymbolCurrent);
                ChangePlayerSymbol(newPlayerSymbolPrevious, tagPlayerSymbolPrevious);

                int nextPlayersSymbolsIndex = currentPlayerNumber + 2;
                Debug.Log("test = " + nextPlayersSymbolsIndex);

                if (currentPlayerNumber > 0 && currentPlayerNumber < playersSymbols.Length - 1)
                {
                   

                    if (nextPlayersSymbolsIndex > playersSymbols.Length - 1)
                    {
                        Debug.Log("  1  ");
                        Debug.Log("test = " + nextPlayersSymbolsIndex);
                        string newPlayerSymbolNext = playersSymbols[0];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }
                //else if (nextPlayersSymbolsIndex == playersSymbols.Length - 1)
                //{
                //    Debug.Log("  2  ");
                //    Debug.Log("test = " + nextPlayersSymbolsIndex);
                //    string newPlayerSymbolNext = playersSymbols[2];
                //    newPlayerSymbolMove[2] = newPlayerSymbolNext;
                //    ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                //}
                else
                {
                        Debug.Log("  3  ");
                        Debug.Log("test = " + nextPlayersSymbolsIndex);
                        string newPlayerSymbolNext = playersSymbols[currentPlayerNumber + 2];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }

            }
                else
            {
                    if (currentPlayerNumber == playersSymbols.Length - 1)
                    {
                        Debug.Log("  4  ");
                        string newPlayerSymbolNext = playersSymbols[1];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);

                    }
                    else
                    {
                        Debug.Log("  5  ");
                        string newPlayerSymbolNext = playersSymbols[2];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }


                }

            Debug.Log(" ----------------------------------------------------- ");

                return newPlayerSymbolMove;
            }





            return newPlayerSymbolMove;

        }









        /*
        public static GameObject[] CreateTableWithPlayersSymbolsMove(string[] playersSymbols)
        {
            Dictionary<int, string> tagPlayerSymbolDictionary = GameDictionariesCommon.DictionaryTagPlayerSymbol();

            int dictionaryLenght = tagPlayerSymbolDictionary.Count;
            int playersNumber = playersSymbols.Length;

            GameObject[] playerSymbolMove = new GameObject[dictionaryLenght];


            SetUpPlayerSymbolCurrent(playersSymbols, tagPlayerSymbolDictionary);

            if(playersNumber >= 3)
            {

                SetUpPlayerSymbolPrevious(playersSymbols, tagPlayerSymbolDictionary);
                SetUpPlayerSymbolNext(playersSymbols, tagPlayerSymbolDictionary);



            }


            return playerSymbolMove;
        }

        */
    }
}
