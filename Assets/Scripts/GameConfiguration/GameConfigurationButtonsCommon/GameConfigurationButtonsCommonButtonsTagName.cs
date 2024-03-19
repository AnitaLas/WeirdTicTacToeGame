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
        public static string GetTagNameFromDictionaryTagConfigurationBoardGame(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneConfigurationBoardGame.DictionaryTagNameConfigurationBoardGame();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        // buttons: players
        public static string GetTagForButtonNameByTagPlayers()
        {
            int dictionatyId = 9;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagButtonNumberByTagChangeNumberPlayers()
        {
            int dictionatyId = 10;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForTableWithNumbersByTagTableNumberPlayers()
        {
            int dictionatyId = 11;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // buttons: rows
        public static string GetTagForButtonNameByTagRows()
        {
            int dictionatyId = 5;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNumberByTagChangeNumberRows()
        {
            int dictionatyId = 7;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForTableWithNumbersByTagTableNumberRows()
        {
            int dictionatyId = 3;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // buttons: columns
        public static string GetTagForButtonNameByTagColumns()
        {
            int dictionatyId = 6;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNumberByTagChangeNumberColumns()
        {
            int dictionatyId = 8;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForTableWithNumbersByTagTableNumberColumns()
        {
            int dictionatyId = 4;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // buttons: lenght to check (UI - button - victory)
        public static string GetTagForButtonNameByTagLenghtToCheck()
        {
            int dictionatyId = 12;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagButtonNumberByTagChangeNumberLenghtToCheck()
        {
            int dictionatyId = 13;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForTableWithNumbersByTagTableLenghtToCheck()
        {
            int dictionatyId = 14;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // buttons: gaps
        public static string GetTagForButtonNameByTagGaps()
        {
            int dictionatyId = 15;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagButtonNumberByTagChangeNumberGaps()
        {
            int dictionatyId = 16;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForTableWithNumbersByTagTableNumberGaps()
        {
            int dictionatyId = 17;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // buttons: back $ save - for scene 
        public static string GetTagForButtonSaveByTagButtonSave()
        {
            int dictionatyId = 1;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonSaveByTagButtonBack()
        {
            int dictionatyId = 2;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // button: back - back from view with table for set up palyers/ rows/ columns/ lenght to check/ gaps to configuration menu 

        public static string GetTagForButtonSaveByTagButtonBackToConfiguration()
        {
            int dictionatyId = 21;
            string currentNumber = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            return currentNumber;
        }

        // tags: common
        public static string GetTagNameForInactiveField()
        {
            int dictionaryId = 20;
            string tagName = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionaryId);
            return tagName;
        }

        public static string GetTagNameForInformation()
        {
            int dictionaryId = 22;
            string tagName = GetTagNameFromDictionaryTagConfigurationBoardGame(dictionaryId);
            return tagName;
        }

        // --

        public static string GetTagNameFromDictionaryTagCommon(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesScenesCommon.DictionaryCommonTagName();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagNameUntagged()
        {
            int dictionaryId = 1;
            string tagName = GetTagNameFromDictionaryTagCommon(dictionaryId);
            return tagName;
        }


        // ----------------------------------------------------------------------------------------------------------------------------------------------
        // tags: players symbol set up

        public static string GetTagNameFromDictionaryTagNameConfigurationPlayersSymbols(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagNameConfigurationPlayersSymbols();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagForButtonPlayerSymbolDefaultNumber()
        {
            int dictionaryId = 1;
            string tagName = GetTagNameFromDictionaryTagNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolDefaultSymbol()
        {
            int dictionaryId = 2;
            string tagName = GetTagNameFromDictionaryTagNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolChange()
        {
            int dictionaryId = 3;
            string tagName = GetTagNameFromDictionaryTagNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolChooseSymbol()
        {
            int dictionaryId = 4;
            string tagName = GetTagNameFromDictionaryTagNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolInactiveField()
        {
            int dictionaryId = 5;
            string tagName = GetTagNameFromDictionaryTagNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolButtonSave()
        {
            int dictionaryId = 6;
            string tagName = GetTagNameFromDictionaryTagNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolButtonBack()
        {
            int dictionaryId = 7;
            string tagName = GetTagNameFromDictionaryTagNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonPlayerSymbolButtonBackToConfiguration()
        {
            int dictionaryId = 8;
            string tagName = GetTagNameFromDictionaryTagNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }

        public static string GetTagForButtonBoardGameButtonInformation()
        {
            int dictionaryId = 9;
            string tagName = GetTagNameFromDictionaryTagNameConfigurationPlayersSymbols(dictionaryId);
            return tagName;
        }














    }
}
