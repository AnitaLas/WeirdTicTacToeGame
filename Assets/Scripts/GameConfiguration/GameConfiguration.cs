using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string[] CreatetableWithPlayersSymbols()
        {
            string[] newPlayersSymbols = { "x", "o", "i"};
            return newPlayersSymbols;
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
