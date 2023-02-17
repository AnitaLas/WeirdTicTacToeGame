using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfiguration
    {


        public static int[] CreateTableWithPlayersNumber(int playersNumber)
        {
            int[] players = new int[playersNumber];

            for (int i = 0; i < playersNumber; i++)
            {
                players[i] = i;
            }

            return players;
        }

        public static string[] CreateTableWithPlayersSymbols()
        {
            //string[] playersSymbols = { "x", "o", "H", "y", "z", "t" };
            //string[] playersSymbols = { "x", "00" };
            //string[] playersSymbols = { "x", "0", "3" };
            //string[] playersSymbols = { "x", "o", "H", "Z"};
            string[] playersSymbols = { "1", "2", "3", "4" };
            return playersSymbols;
        }

        public static string[,] CreateEmptyTable2D(int numberOfRows, int numberOfColumns)
        {
            string[,] table = new string[numberOfRows, numberOfColumns];

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    table[row, column] = "";
                }

            }
            return table;

        }




        /*
        public static string[] SetUpPlayerSymbol(string[] playersSymbols, int playerNumber, string palayerSymbol)
        {
            playersSymbols[playerNumber] = palayerSymbol;
            return playersSymbols;
        }
        */
        /*
        public static string[] CreatetableWithPlayersSymbols(string[] playerSymbols, int currentPlayerSymbol, string playerSymbol)
        { 
            string[] newPlayersSymbols = playerSymbols;
            newPlayersSymbols[currentPlayerSymbol] = playerSymbol;
            return newPlayersSymbols;
        }
        */

    }
}
