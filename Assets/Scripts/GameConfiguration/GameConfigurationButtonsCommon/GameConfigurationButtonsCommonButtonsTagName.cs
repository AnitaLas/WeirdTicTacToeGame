using Assets.Scripts.GameDictionaries.GameDictionariesScenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsCommonButtonsTagName
    {
        // --- tag name dictionary
        public static string GetTagsNameFromDictionaryTagsConfigurationBoardGame(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneConfigurationBoardGame.DictionaryTagsNameConfigurationBoardGame();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        // buttons: players
        public static string GetTagForButtonNameByTagPlayers()
        {
            int dictionatyId = 9;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagButtonNumberByTagChangeNumberPlayers()
        {
            int dictionatyId = 10;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForTableWithNumbersByTagTableNumberPlayers()
        {
            int dictionatyId = 11;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // buttons: rows
        public static string GetTagForButtonNameByTagRows()
        {
            int dictionatyId = 5;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNumberByTagChangeNumberRows()
        {
            int dictionatyId = 7;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForTableWithNumbersByTagTableNumberRows()
        {
            int dictionatyId = 3;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // buttons: columns
        public static string GetTagForButtonNameByTagColumns()
        {
            int dictionatyId = 6;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNumberByTagChangeNumberColumns()
        {
            int dictionatyId = 8;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForTableWithNumbersByTagTableNumberColumns()
        {
            int dictionatyId = 4;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // buttons: lenght to check (UI - button - victory)
        public static string GetTagForButtonNameByTagLenghtToCheck()
        {
            int dictionatyId = 12;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagButtonNumberByTagChangeNumberLenghtToCheck()
        {
            int dictionatyId = 13;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForTableWithNumbersByTagTableLenghtToCheck()
        {
            int dictionatyId = 14;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // buttons: gaps
        public static string GetTagForButtonNameByTagGaps()
        {
            int dictionatyId = 15;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagButtonNumberByTagChangeNumberGaps()
        {
            int dictionatyId = 16;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForTableWithNumbersByTagTableNumberGaps()
        {
            int dictionatyId = 17;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // buttons: back $ save - for scene 
        public static string GetTagForButtonSaveByTagButtonSave()
        {
            int dictionatyId = 1;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonSaveByTagButtonBack()
        {
            int dictionatyId = 2;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // button: back - back from view with table for set up palyers/ rows/ columns/ lenght to check/ gaps to configuration menu 

        public static string GetTagForButtonBackByTagButtonBackToConfiguration()
        {
            int dictionatyId = 21;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // tags: common
        public static string GetTagNameForInactiveField()
        {
            int dictionaryId = 20;
            string tagName = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionaryId);
            return tagName;
        }

        public static string GetTagNameForInformation()
        {
            int dictionaryId = 22;
            string tagName = GetTagsNameFromDictionaryTagsConfigurationBoardGame(dictionaryId);
            return tagName;
        }

        // --

        public static string GetTagsNameFromDictionaryTagsCommon(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesScenesCommon.DictionaryCommonTagsName();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagNameUntagged()
        {
            int dictionaryId = 1;
            string tagName = GetTagsNameFromDictionaryTagsCommon(dictionaryId);
            return tagName;
        }


        // ----------------------------------------------------------------------------------------------------------------------------------------------
        // tags: players symbol set up

        public static string GetTagsNameFromDictionaryTagsNameConfigurationPlayersSymbols(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagsNameConfigurationPlayersSymbols();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagForButtonPlayerSymbolDefaultNumber()
        {
            int dictionaryId = 1;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolDefaultSymbol()
        {
            int dictionaryId = 2;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolChange()
        {
            int dictionaryId = 3;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolChooseSymbol()
        {
            int dictionaryId = 4;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolInactiveField()
        {
            int dictionaryId = 5;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolButtonSave()
        {
            int dictionaryId = 6;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolButtonBack()
        {
            int dictionaryId = 7;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolButtonBackToConfiguration()
        {
            int dictionaryId = 8;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonBoardGameButtonInformation()
        {
            int dictionaryId = 9;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------------
        // tags: change/ swich players symbols set up

        public static string GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneConfigurationChangePlayersSymbols.DictionaryTagsNameConfigurationChangePlayersSymbols();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagForButtonChangePlayersSymbolsButtonSave()
        {
            int dictionaryId = 1;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonChangePlayersSymbolsButtonBack()
        {
            int dictionaryId = 2;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonChangeRandomly()
        {
            int dictionaryId = 3;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonNumberByTagChangeNumberRandomly()
        {
            int dictionaryId = 4;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForTableWithNumbersByTagTableNumberRandomly()
        {
            int dictionaryId = 5;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonChangForAll()
        {
            int dictionaryId = 6;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonNumberByTagChangeNumberForAll()
        {
            int dictionaryId = 7;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForTableWithNumbersByTagTableNumberForAll()
        {
            int dictionaryId = 8;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(dictionaryId);
            return tagName;
        }




        public static string GetTagForButtonBackByTagButtonBackToConfigurationChangePlayersSymbols()
        {
            int dictionaryId = 15;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonBoardGameButtonInformationChangePlayersSymbols()
        {
            int dictionaryId = 16;
            string tagName = GetTagsNameFromDictionaryTagsNameConfigurationChangePlayersSymbols(dictionaryId);
            return tagName;
        }













    }
}
