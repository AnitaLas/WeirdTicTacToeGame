﻿using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class GameDictionariesSceneConfigurationPlayerSymbols
    {
        public static Dictionary<int, string> DictionaryTagsNameConfigurationPlayersSymbols()
        {
            Dictionary<int, string> configurationPlayersSymbolsDictionaryTag = new Dictionary<int, string>
            {
                { 1, "ConfigurationPlayerSymbolDefaultNumber" },
                { 2, "ConfigurationPlayerSymbolDefaultSymbol" },
                { 3, "ConfigurationPlayerSymbolChange" },
                { 4, "ConfigurationPlayerSymbolChooseSymbol" },
                { 5, "ConfigurationPlayerSymbolInactiveField" },
                { 6, "ConfigurationPlayerSymbolButtonSave" },
                { 7, "ConfigurationPlayerSymbolButtonBack" },
                { 8, "ConfigurationPlayerSymbolButtonBackToConfiguration" },
                { 9, "ConfigurationBoardGameButtonInformation" }
            };

            return configurationPlayersSymbolsDictionaryTag;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationPlayerSymbolDefaultText()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "PLAYER" },
                { 2, "PLAYERS" },
                { 3, "P" }, // tabletMode, more than six players
                { 4, "    SETUP" },
                { 5, "PLAYERS SYMBOLS" }
            };

            return buttonsNameDictionary;
        }
    }
}
