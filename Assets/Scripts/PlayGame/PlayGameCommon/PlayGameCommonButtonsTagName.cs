using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class PlayGameCommonButtonsTagName
    {
        // tag name: common
        public static string GetTagsNameFromDictionaryTagsGame(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneGame.DictionaryTagsGame();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagForButtonNameByTagMenuConfigurationLeft()
        {
            int dictionatyId = 1;
            string currentNumber = GetTagsNameFromDictionaryTagsGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagMenuConfigurationRight()
        {
            int dictionatyId = 2;
            string currentNumber = GetTagsNameFromDictionaryTagsGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagNewGame()
        {
            int dictionatyId = 3;
            string currentNumber = GetTagsNameFromDictionaryTagsGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagHelpButtons()
        {
            int dictionatyId = 4;
            string currentNumber = GetTagsNameFromDictionaryTagsGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagMenuBack()
        {
            int dictionatyId = 5;
            string currentNumber = GetTagsNameFromDictionaryTagsGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagParentObjectHelpButtons()
        {
            int dictionatyId = 6;
            string currentNumber = GetTagsNameFromDictionaryTagsGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagMenuConfigurationDisactivate()
        {
            int dictionatyId = 7;
            string currentNumber = GetTagsNameFromDictionaryTagsGame(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagBoardGameHelpText()
        {
            int dictionatyId = 8;
            string currentNumber = GetTagsNameFromDictionaryTagsGame(dictionatyId);
            return currentNumber;
        }

        // ---------------------------------------------------------------------------------------
        // tags name: cubePlay

        public static string GetTagsNameFromDictionaryTagsCubePlay(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneGame.DictionaryTagsCubePlay();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagForButtonNameByTagFree()
        {
            int dictionatyId = 1;
            string currentNumber = GetTagsNameFromDictionaryTagsCubePlay(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagTaken()
        {
            int dictionatyId = 2;
            string currentNumber = GetTagsNameFromDictionaryTagsCubePlay(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagFrame()
        {
            int dictionatyId = 3;
            string currentNumber = GetTagsNameFromDictionaryTagsCubePlay(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagGameOver()
        {
            int dictionatyId = 4;
            string currentNumber = GetTagsNameFromDictionaryTagsCubePlay(dictionatyId);
            return currentNumber;
        }
        public static string GetTagForButtonNameByTagGameWin()
        {
            int dictionatyId = 5;
            string currentNumber = GetTagsNameFromDictionaryTagsCubePlay(dictionatyId);
            return currentNumber;
        }

        // ---------------------------------------------------------------------------------------
        // tags name: help buttons

        public static string GetTagsNameFromDictionaryTagsHelpButtons(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneGame.DictionaryTagsHelpButtons();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagForButtonNameByTagArrowRight()
        {
            int dictionatyId = 1;
            string currentNumber = GetTagsNameFromDictionaryTagsHelpButtons(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagArrowDown()
        {
            int dictionatyId = 2;
            string currentNumber = GetTagsNameFromDictionaryTagsHelpButtons(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagArrowLeft()
        {
            int dictionatyId = 3;
            string currentNumber = GetTagsNameFromDictionaryTagsHelpButtons(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagArrowUp()
        {
            int dictionatyId = 4;
            string currentNumber = GetTagsNameFromDictionaryTagsHelpButtons(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagButtonConfirm()
        {
            int dictionatyId = 5;
            string currentNumber = GetTagsNameFromDictionaryTagsHelpButtons(dictionatyId);
            return currentNumber;
        }

        // ---------------------------------------------------------------------------------------
        // tags name: players symbol PlayGameCommonButtonsTagName

        public static string GetTagsNameFromDictionaryTagPlayerSymbolMove(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneGame.DictionaryTagsPlayerSymbolMove();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagForButtonNameByTagPlayerSymbolCurrent()
        {
            int dictionatyId = 1;
            string currentNumber = GetTagsNameFromDictionaryTagPlayerSymbolMove(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagPlayerSymbolPrevious()
        {
            int dictionatyId = 2;
            string currentNumber = GetTagsNameFromDictionaryTagPlayerSymbolMove(dictionatyId);
            return currentNumber;
        }

        public static string GetTagForButtonNameByTagPlayerSymbolNext()
        {
            int dictionatyId = 3;
            string currentNumber = GetTagsNameFromDictionaryTagPlayerSymbolMove(dictionatyId);
            return currentNumber;
        }

        
    }
}
