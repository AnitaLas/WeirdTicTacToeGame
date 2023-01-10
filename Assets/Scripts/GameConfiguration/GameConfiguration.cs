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

        public static string[] CreatetableWithPlayersSymbolsV2()
        {
            string[] newPlayersSymbols = { "x", "o", "i"};
            return newPlayersSymbols;
        }

        public static int[] CreateTableWithLengthOneAndValueZero()
        {
            int[] table = new int[1];
            table[0] = 0;
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
