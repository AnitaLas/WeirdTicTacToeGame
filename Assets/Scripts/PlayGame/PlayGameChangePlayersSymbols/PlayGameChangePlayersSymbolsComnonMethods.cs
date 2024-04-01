using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;

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

                string newSymbols = untakenSymbolsString.Substring(randomIndex, 1);

                newSymbolsForPlayers[i] = newSymbols;

                string newString = untakenSymbolsString.Remove(randomIndex, 1);

                untakenSymbolsString = newString;
                //UnityEngine.Debug.Log($"untakenSymbolsString: " + untakenSymbolsString);
            }

            //UnityEngine.Debug.Log($"--------------------------------------------------------------");

            //for (int z = 0; z < newSymbolsForPlayersLenght; z++)
            //{
            //    UnityEngine.Debug.Log($"newSymbolsForPlayersLenght[{z}]" + newSymbolsForPlayers[z]);
            //}

            return newSymbolsForPlayers;
        }

    }
}
