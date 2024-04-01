using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameDictionariesCommonPlayersSymbols
    {

        public static Dictionary<int, string> DictionaryPlayersSymbols()
        {
            Dictionary<int, string> tagStartGameDictionary = new Dictionary<int, string>
            {
                { 1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ" }, // that will be work only max for 13 players, PlayGameChangePlayersSymbolsComnonMethods -> GetNewPlayersSymbols
                { 2, "OXWTALFUNVCRDEGHIJKLMPQSYZ" }, // up
            };

            return tagStartGameDictionary;
        }

    }
}
