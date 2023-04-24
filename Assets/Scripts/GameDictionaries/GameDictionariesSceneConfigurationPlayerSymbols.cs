using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameDictionaries
{
    internal class GameDictionariesSceneConfigurationPlayerSymbols
    {
        public static Dictionary<int, string> DictionaryTagConfigurationPlayersSymbols()
        {
            Dictionary<int, string> configurationPlayersSymbolsDictionaryTag = new Dictionary<int, string>();

            configurationPlayersSymbolsDictionaryTag.Add(1, "ConfigurationPlayerSymbolDefaultNumber");
            configurationPlayersSymbolsDictionaryTag.Add(2, "ConfigurationPlayerSymbolDefaultSymbol");
            configurationPlayersSymbolsDictionaryTag.Add(3, "ConfigurationPlayerSymbolChange");
            configurationPlayersSymbolsDictionaryTag.Add(4, "ConfigurationPlayerSymbolChooseSymbol");
            configurationPlayersSymbolsDictionaryTag.Add(5, "ConfigurationPlayerSymbolInactiveField");
            configurationPlayersSymbolsDictionaryTag.Add(6, "ConfigurationPlayerSymbolButtonSave");
            configurationPlayersSymbolsDictionaryTag.Add(7, "ConfigurationPlayerSymbolButtonBack");
            configurationPlayersSymbolsDictionaryTag.Add(8, "ConfigurationPlayerSymbolButtonBackToConfiguration");

            return configurationPlayersSymbolsDictionaryTag;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationPlayerSymbolDefaultText()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>();

            buttonsNameDictionary.Add(1, "PLAYER");

            return buttonsNameDictionary;
        }

    }
}
