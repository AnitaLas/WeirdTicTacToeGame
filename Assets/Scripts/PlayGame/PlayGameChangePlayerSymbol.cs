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

        public void PlayerSymbolMove()
        {


             
        }

        // SetUpPlayerSymbol

        public static void SetUpPlayerSymbol(string[] playersSymbols, Dictionary<int, string> tagPlayerSymbolDictionary, int indexForDictionary, int indexForPlayerSymbol)
        {
            string gameObjectTagName = tagPlayerSymbolDictionary[indexForDictionary];
            GameObject[] gameObjectForPlayerSymbol = CommonMethods.GetObjectByTagName(gameObjectTagName);
            string playerSymbol = playersSymbols[indexForPlayerSymbol];
            GameObject playerSymbolMove = gameObjectForPlayerSymbol[0];
            CommonMethods.ChangeTextForCubePlay(playerSymbolMove, playerSymbol);
        }

        public static GameObject[] CreateTableWithPlayersSymbolsMove(string[] playersSymbols)
        {
            Dictionary<int, string> tagPlayerSymbolDictionary = GameDictionariesCommon.DictionaryTagPlayerSymbol();

            int dictionaryLenght = tagPlayerSymbolDictionary.Count;

            GameObject[] playerSymbolMove = new GameObject[dictionaryLenght];

            //string playerSymbolCurrent = tagPlayerSymbolDictionary[1];
            //GameObject[] playerSymbolMoveCurrent = CommonMethods.GetObjectByTagName(playerSymbolCurrent);
            //string firstPlayerSymbol = playersSymbols[0];
            //GameObject firstPlayerMove = playerSymbolMoveCurrent[0];
            //CommonMethods.ChangeTextForCubePlay(firstPlayerMove, firstPlayerSymbol);
            int indexForDictionaryCurrent = 1;
            int indexForPlayerSymbolCurrent = 0;
            SetUpPlayerSymbol(playersSymbols, tagPlayerSymbolDictionary, indexForDictionaryCurrent, indexForPlayerSymbolCurrent);



            //int lastPlayerSymbol = playersSymbols.Length - 1;
            //string playerSymbolPrevious = tagPlayerSymbolDictionary[2];
            //GameObject[] playerSymbolMovePrevious = CommonMethods.GetObjectByTagName(playerSymbolPrevious);
            //string previousPlayerSymbol = playersSymbols[lastPlayerSymbol];
            //GameObject previousPlayerMove = playerSymbolMovePrevious[0];
            //CommonMethods.ChangeTextForCubePlay(previousPlayerMove, previousPlayerSymbol);

            int indexForDictionaryPrevious = 2;
            int indexForPlayerSymbolPrevious = playersSymbols.Length - 1;
            SetUpPlayerSymbol(playersSymbols, tagPlayerSymbolDictionary, indexForDictionaryPrevious, indexForPlayerSymbolPrevious);


            //string playerSymbolNext = tagPlayerSymbolDictionary[3];
            //GameObject[] playerSymbolMoveNext = CommonMethods.GetObjectByTagName(playerSymbolNext);
            //string nextPlayerSymbol = playersSymbols[1];
            //GameObject nextPlayerMove = playerSymbolMoveNext[0];
            //CommonMethods.ChangeTextForCubePlay(nextPlayerMove, nextPlayerSymbol);

            int indexForDictionaryNext = 3;
            int indexForPlayerSymbolNext = 1;
            SetUpPlayerSymbol(playersSymbols, tagPlayerSymbolDictionary, indexForDictionaryNext, indexForPlayerSymbolNext);

            return playerSymbolMove;
        }


    }
}
