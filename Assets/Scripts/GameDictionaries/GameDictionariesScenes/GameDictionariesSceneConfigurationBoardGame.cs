using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class GameDictionariesSceneConfigurationBoardGame
    {
        public static Dictionary<int, string> DictionaryTagsNameConfigurationBoardGame()
        {
            Dictionary<int, string> configurationBoardGameDictionaryTag = new Dictionary<int, string>
            {
                { 1, "ConfigurationBoardGameButtonSave" },
                { 2, "ConfigurationBoardGameButtonBack" },
                { 3, "ConfigurationBoardGameTableNumberRows" },
                { 4, "ConfigurationBoardGameTableNumberColumns" },
                { 5, "ConfigurationBoardGameRows" },
                { 6, "ConfigurationBoardGameColumns" },
                { 7, "ConfigurationBoardGameChangeNumberRows" },
                { 8, "ConfigurationBoardGameChangeNumberColumns" },
                { 9, "ConfigurationBoardGamePlayers" },
                { 10, "ConfigurationBoardGameChangeNumberPlayers" },
                { 11, "ConfigurationBoardGameTableNumberPlayers" },
                { 12, "ConfigurationBoardGameLenghtToCheck" },
                { 13, "ConfigurationBoardGameChangeNumberLenghtToCheck" },
                { 14, "ConfigurationBoardGameTableNumberLenghtToCheck" },
                { 15, "ConfigurationBoardGameGaps" },
                { 16, "ConfigurationBoardGameChangeNumberGaps" },
                { 17, "ConfigurationBoardGameTableNumberGaps" },
                { 20, "ConfigurationBoardGameInactiveField" },
                { 21, "ConfigurationBoardGameButtonBackToConfiguration" },
                { 22, "ConfigurationBoardGameButtonInformation" }
            };

            return configurationBoardGameDictionaryTag;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationBoardGameButtonsName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "PLAYERS" },
                { 2, "ROWS" },
                { 3, "COLUMNS" },
                //buttonsNameDictionary.Add(4, "CROSS OUT");
                //{ 4, "MARK TO WIN" },
                //{ 4, "TO WIN" },
                { 4, "VICTORY" },
                //buttonsNameDictionary.Add(4, "LENGTH TO CHECK");
                { 5, "GAPS" },
                { 6, "GAME" },
                { 7, "TEAM GAME" }
            };

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationBoardGameButtonsNameForMoreSpecificConfiguration()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "    CHANGE" },
                { 2, "PLAYERS NUMBER" },
                { 3, "ROWS NUMBER" },
                { 4, "COLUMNS NUMBER" },
                //buttonsNameDictionary.Add(4, "LENGTH TO CHECK");
                { 5, "LENGTH TO CHECK" },
                { 6, "GAPS NUMBER" }
            };

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationBoardGameDefaultNumbers()
        {
            Dictionary<int, string> buttonsDefaultNumberDictionary = new Dictionary<int, string>
            {
                { 1, "2" }, // players
                { 2, "3" }, // rows & columns % lenght to check
                { 3, "0" } // gaps
            };

            return buttonsDefaultNumberDictionary;
        }
    }
}
