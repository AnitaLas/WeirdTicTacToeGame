using Assets.Scripts.GameDictionaries.GameDictionariesScenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsCommonButtonsDefaultNumber
    {
        // --- default buttons number
        public static string GetDefaultButtonNumber(int defaultNumberForButton)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameDefaultNumbers();
            string defaulNumber = defaulNumbers[defaultNumberForButton];
            return defaulNumber;
        }

        public static string GetDefaultButtonNumberForPlayers()
        {
            int dictionatyId = 1;
            string defaulNumber = GetDefaultButtonNumber(dictionatyId);
            return defaulNumber;
        }

        public static string GetDefaultButtonNumberForRowsAndColumns()
        {
            int dictionatyId = 2;
            string defaulNumber = GetDefaultButtonNumber(dictionatyId);
            return defaulNumber;
        }

        public static string GetDefaultButtonNumberForLenghtToCheck()
        {
            int dictionatyId = 2;
            string defaulNumber = GetDefaultButtonNumber(dictionatyId);
            return defaulNumber;
        }

        public static string GetDefaultButtonNumberForGaps()
        {
            int dictionatyId = 3;
            string defaulNumber = GetDefaultButtonNumber(dictionatyId);
            return defaulNumber;
        }

        //---

        // buttons change palyers symbols

        public static string GetDefaultButtonNumberForChangePlayersSymbols(int defaultNumberForButton)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneConfigurationChangePlayersSymbols.DictionaryButtonsConfigurationChangePlayersSymbolsDefaultNumbers();
            string defaulNumber = defaulNumbers[defaultNumberForButton];
            return defaulNumber;
        }

        public static string GetDefaultButtonTimeForChange()
        {
            int dictionatyId = 1;
            string defaulNumber = GetDefaultButtonNumberForChangePlayersSymbols(dictionatyId);
            return defaulNumber;
        }
    }
}
