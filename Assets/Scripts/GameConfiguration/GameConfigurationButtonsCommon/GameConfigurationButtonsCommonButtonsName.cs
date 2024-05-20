using Assets.Scripts.GameDictionaries.GameDictionariesScenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsCommonButtonsName
    {

        // --- button name

        public static string GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsName(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameButtonsName();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNameForPlayers()
        {
            int dictionatyId = 1;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForRows()
        {
            int dictionatyId = 2;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForColumns()
        {
            int dictionatyId = 3;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForLenghtToCheck()
        {
            int dictionatyId = 4;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForGaps()
        {
            int dictionatyId = 5;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForBoardGame()
        {
            int dictionatyId = 6;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForTeamGameBoardGame()
        {
            int dictionatyId = 7;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForNumber()
        {
            int dictionatyId = 8;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        // more specific configuration for board game configuration

        public static string GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsNameForMoreSpecificConfiguration(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameButtonsNameForMoreSpecificConfiguration();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNameForStaticTextForAll()
        {
            int dictionatyId = 1;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsNameForMoreSpecificConfiguration(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForPlayersInformation()
        {
            int dictionatyId = 2;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsNameForMoreSpecificConfiguration(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForRowsInformation()
        {
            int dictionatyId = 3;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsNameForMoreSpecificConfiguration(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForColumnsInformation()
        {
            int dictionatyId = 4;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsNameForMoreSpecificConfiguration(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForLenghtToCheckInformation()
        {
            int dictionatyId = 5;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsNameForMoreSpecificConfiguration(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForGapsInformation()
        {
            int dictionatyId = 6;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationBoardGameButtonsNameForMoreSpecificConfiguration(dictionatyId);
            return tagName;
        }

        // buttons: name back &  save
        public static string GetButtonNameFromGameDictionariesScenesCommon(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesScenesCommon.DictionaryCommonButtonsName();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNameForButtonSave()
        {
            int dictionatyId = 1;
            string tagName = GetButtonNameFromGameDictionariesScenesCommon(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForButtonBack()
        {
            int dictionatyId = 2;
            string tagName = GetButtonNameFromGameDictionariesScenesCommon(dictionatyId);
            return tagName;
        }

        // buttons: players symbol set up

        public static string GetButtonNameFromDictionaryButtonsConfigurationPlayerSymbolDefaultText(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryButtonsConfigurationPlayerSymbolDefaultText();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNamePlayer()
        {
            int dictionatyId = 1;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationPlayerSymbolDefaultText(dictionatyId);
            return tagName;
        }

        public static string GetButtonNamePlayers()
        {
            int dictionatyId = 2;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationPlayerSymbolDefaultText(dictionatyId);
            return tagName;
        }

        // button: P - tablet mode
        public static string GetButtonNameP()
        {
            int dictionatyId = 3;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationPlayerSymbolDefaultText(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameSetUp()
        {
            int dictionatyId = 4;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationPlayerSymbolDefaultText(dictionatyId);
            return tagName;
        }

        public static string GetButtonNamePlayersSymbols()
        {
            int dictionatyId = 5;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationPlayerSymbolDefaultText(dictionatyId);
            return tagName;
        }

        // butons: players symbols change/ switch
        public static string GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneConfigurationChangePlayersSymbols.DictionaryButtonsConfigurationChangePlayersSymbolsButtonsName();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNameToPlayersSymbols()
        {
            int dictionatyId = 1;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameTopChange()
        {
            int dictionatyId = 2;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameChangeRandomly()
        {
            int dictionatyId = 3;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameChangeAll()
        {
            int dictionatyId = 4;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameTimeInSeconds()
        {
            int dictionatyId = 5;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameChangeRandomlyForInformation()
        {
            int dictionatyId = 6;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameChangeForAllForInformation()
        {
            int dictionatyId = 7;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameChangeBetweenTeams()
        {
            int dictionatyId = 8;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameChangeBetweenTeamsForInformation()
        {
            int dictionatyId = 9;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameChangeEqualMoveQuantity()
        {
            int dictionatyId = 10;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameSwitchBetweenTeamsForInformation()
        {
            int dictionatyId = 11;
            string tagName = GetButtonNameFromDictionaryButtonsConfigurationBoardGameButtonsName(dictionatyId);
            return tagName;
        }
    }
}
