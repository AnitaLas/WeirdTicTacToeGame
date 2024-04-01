using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class PlayGameCommonPlayersSymbols
    {

        public static string GetStringWithPlayersSymbols(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesCommonPlayersSymbols.DictionaryPlayersSymbols();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetStringWithAllSymbols()
        {
            int dictionatyId = 1;
            string currentNumber = GetStringWithPlayersSymbols(dictionatyId);
            return currentNumber;
        }

        public static string GetStringWitDefaultSymbols()
        {
            int dictionatyId = 2;
            string currentNumber = GetStringWithPlayersSymbols(dictionatyId);
            return currentNumber;
        }


    }
}
