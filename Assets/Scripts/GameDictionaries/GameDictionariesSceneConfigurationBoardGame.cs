using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameDictionaries
{
    internal class GameDictionariesSceneConfigurationBoardGame
    {
        public static Dictionary<int, string> DictionaryTagConfigurationBoardGame()
        {
            Dictionary<int, string> configurationBoardGameDictionaryTag = new Dictionary<int, string>();

            configurationBoardGameDictionaryTag.Add(1, "ConfigurationBoardGameButtonSave");
            configurationBoardGameDictionaryTag.Add(2, "ConfigurationBoardGameButtonBack");
            configurationBoardGameDictionaryTag.Add(3, "ConfigurationBoardGameTableNumberRows");
            configurationBoardGameDictionaryTag.Add(4, "ConfigurationBoardGameTableNumberColumns");
            configurationBoardGameDictionaryTag.Add(5, "ConfigurationBoardGameRows");
            configurationBoardGameDictionaryTag.Add(6, "ConfigurationBoardGameColumns");
            configurationBoardGameDictionaryTag.Add(7, "ConfigurationBoardGameChangeNumberRows");
            configurationBoardGameDictionaryTag.Add(8, "ConfigurationBoardGameChangeNumberColumns");
            configurationBoardGameDictionaryTag.Add(9, "ConfigurationBoardGamePlayers");
            configurationBoardGameDictionaryTag.Add(10, "ConfigurationBoardGameChangeNumberPlayers");
            configurationBoardGameDictionaryTag.Add(11, "ConfigurationBoardGameTableNumberPlayers");
            configurationBoardGameDictionaryTag.Add(12, "ConfigurationBoardGameLenghtToCheck");
            configurationBoardGameDictionaryTag.Add(13, "ConfigurationBoardGameChangeNumberLenghtToCheck");
            configurationBoardGameDictionaryTag.Add(14, "ConfigurationBoardGameTableNumberLenghtToCheck");
            configurationBoardGameDictionaryTag.Add(20, "ConfigurationBoardGameInactiveField");
            configurationBoardGameDictionaryTag.Add(21, "ConfigurationBoardGameButtonBackToConfiguration");

            return configurationBoardGameDictionaryTag;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationBoardGameButtonsName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>();

            buttonsNameDictionary.Add(1, "PLAYERS");
            buttonsNameDictionary.Add(2, "ROWS");
            buttonsNameDictionary.Add(3, "COLUMNS");
            //buttonsNameDictionary.Add(4, "CROSS OUT");
            buttonsNameDictionary.Add(4, "MARK TO WIN");
            //buttonsNameDictionary.Add(4, "LENGTH TO CHECK");
            buttonsNameDictionary.Add(5, "HOLES");

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationBoardGameDefaultNumbers()
        {
            Dictionary<int, string> buttonsDefaultNumberDictionary = new Dictionary<int, string>();

            buttonsDefaultNumberDictionary.Add(1, "2");
            buttonsDefaultNumberDictionary.Add(2, "3");

            return buttonsDefaultNumberDictionary;
        }
    }
}
