using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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


        /// <summary>
        /// that will be work only max for 13 players, GameDictionariesCommonPlayersSymbols -> DictionaryPlayersSymbols
        /// </summary>
        /// <param name="playersSymbols"></param>
        /// <returns></returns>
        public static string[] GetNewPlayersSymbols(string[] playersSymbols)
        {

            string allPossibleSymbols = PlayGameCommonPlayersSymbols.GetStringWithAllSymbols();          
            int allPossibleSymbolsLenght = allPossibleSymbols.Length;

            //UnityEngine.Debug.Log($"allPossibleSymbols: " + allPossibleSymbols);
            //UnityEngine.Debug.Log($"--------------------------------------------------------------");

            string[] takenSymbols = playersSymbols;
            int takenSymbolsLenght = playersSymbols.Length; // change for all players.


            //for (int i = 0; i < takenSymbolsLenght; i++)
            //{
                //UnityEngine.Debug.Log($"takenSymbols[{i}] = " + takenSymbols[i]);

            //}
            //UnityEngine.Debug.Log($"--------------------------------------------------------------");


            string untakenSymbolsString;
            

            string[] newSymbolsForPlayers = new string[takenSymbolsLenght];
            int newSymbolsForPlayersLenght = newSymbolsForPlayers.Length;

            int maxNumberForUntakenSymbol = allPossibleSymbolsLenght - takenSymbolsLenght;
            //string[] untakenSymbolsForPlayers = new string[maxNumberForUntakenSymbol];











            // create string with free symbols

            untakenSymbolsString = allPossibleSymbols;

            for (int i = 0; i < takenSymbolsLenght; i++)
            {
                string takenSymbol = takenSymbols[i];
                int index = untakenSymbolsString.IndexOf(takenSymbol);
                string newString = untakenSymbolsString.Remove(index,1);
                untakenSymbolsString = newString;
            }

            //int untakenSymbolsLenght = untakenSymbolsString.Length;
            //string[] untakenSymbols = new string[untakenSymbolsLenght];













            // create table with free symbol

            //for (int i = 0; i < untakenSymbolsLenght; i++)  // create common method for that
            //{
            //    string character = untakenSymbolsString.Substring(i, 1);
            //    untakenSymbols[i] = character;

            //}

            //for (int i = 0; i < untakenSymbolsLenght; i++)
            //{
            //    UnityEngine.Debug.Log($"untakenSymbols[{i}]" + untakenSymbols[i]);
            //}

            // -----------------------------

            //UnityEngine.Debug.Log($"maxNumberForUntakenSymbol: " + maxNumberForUntakenSymbol);
           // UnityEngine.Debug.Log($"untakenSymbolsString.lenght: " + untakenSymbolsString.Length);
            //UnityEngine.Debug.Log($"--------------------------------------------------------------");

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

            //UnityEngine.Debug.Log($"--------------------------------------------------------------");

            //for (int z = 0; z < newSymbolsForPlayersLenght; z++)
            //{
            //    UnityEngine.Debug.Log($"newSymbolsForPlayersLenght[{z}]" + newSymbolsForPlayers[z]);
            //}

            return newSymbolsForPlayers;
        }

        public static void SetUpPlayerSymbols(List<GameObject[,,]> buttons, string[] playersSymbols)
        {
            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumber = buttons.Count;
            Debug.Log("buttonsNumber" + buttonsNumber);
           //sss GameObject[,,] table;

            for (int i = 0; i < buttonsNumber; i++)
            {
                GameObject[,,] table = buttons[i];
                maxIndexDepth = table.GetLength(0);
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                Debug.Log("maxIndexDepth" + maxIndexDepth);
                Debug.Log("maxIndexColumn" + maxIndexColumn);
                Debug.Log("maxIndexRow" + maxIndexRow);


                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = table[indexDepth, indexRow, indexColumn];
                           
                            string symbol = playersSymbols[i];
                            Debug.Log("symbol" + symbol);
                            //CommonMethods.ChangeTextForCubePlay(cubePlay, symbol);
                            CommonMethods.ChangeTextForFirstChild(cubePlay, symbol);

                        }
                    }
                }
            }

        }

    }
}
