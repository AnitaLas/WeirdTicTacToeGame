using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameDictionaries.GameDictionariesScenes
{
    internal class GameDictionariesSceneConfigurationChangePlayersSymbols
    {
        public static Dictionary<int, string> DictionaryTagsNameConfigurationChangePlayersSymbols()
        {
            Dictionary<int, string> configurationBoardGameDictionaryTag = new Dictionary<int, string>
            {
                { 1, "ConfigurationChangePlayersSymbolsButtonSave" },
                { 2, "ConfigurationChangePlayersSymbolsButtonBack" },

                { 3, "ConfigurationChangePlayersSymbolsRandomly" },
                { 4, "ConfigurationChangePlayersSymbolsChangeNumberRandomly" },
                { 5, "ConfigurationChangePlayersSymbolsTableNumberRandomly" },

                { 6, "ConfigurationChangePlayersSymbolsForAll" },
                { 7, "ConfigurationChangePlayersSymbolsChangeNumberForAll" },
                { 8, "ConfigurationChangePlayersSymbolsTableNumberForAll" },

                // button: team game 1
                //{ 9, "ConfigurationChangePlayersSymbolsButtonChangeRandomlyPlayersSymbols" },
                //{ 10, "ConfigurationChangePlayersSymbolsButtonChangeRandomlyPlayersSymbols" },
                //{ 11, "ConfigurationChangePlayersSymbolsButtonChangeRandomlyPlayersSymbols" },

                // button: team game 2
                //{ 12, "ConfigurationChangePlayersSymbolsButtonChangeRandomlyPlayersSymbols" },
                //{ 13, "ConfigurationChangePlayersSymbolsButtonChangeRandomlyPlayersSymbols" },
                //{ 14, "ConfigurationChangePlayersSymbolsButtonChangeRandomlyPlayersSymbols" },

                { 15, "ConfigurationChangePlayersSymbolsButtonBackToConfiguration" },
                { 16, "ConfigurationChangePlayersSymbolsButtonInformation" },

            };

            return configurationBoardGameDictionaryTag;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationChangePlayersSymbolsButtonsName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                //{ 1, "CHANGE RANDOMLY PLAYERS SYMBOLS" },
                { 1, "PLAYERS SYMBOLS" },
                { 2, "    CHANGE" }, // spaces are needed for the button name; do not remove it! It is an easy (short/ lazy) fix, the method for button name requires changes
                { 3, "RANDOMLY" },
                { 4, "FOR ALL" },
                //{ 5, "TIME - SECONDS" },
                { 5, "TIME IN SECONDS" },
                { 6, "   RANDOMLY" }, // the same as in id 2
                { 7, "    FOR ALL" }, // the same as in id 2



            };

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationChangePlayersSymbolsDefaultNumbers()
        {
            Dictionary<int, string> buttonsDefaultNumberDictionary = new Dictionary<int, string>
            {
                { 1, "0" }, // time
            };

            return buttonsDefaultNumberDictionary;
        }


    }
}
