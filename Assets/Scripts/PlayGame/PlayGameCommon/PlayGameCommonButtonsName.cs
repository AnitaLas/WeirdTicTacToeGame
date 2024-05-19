using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class PlayGameCommonButtonsName
    {
        // --- button name

        public static string GetButtonsNameFromDictionaryButtonsGameName(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneGame.DictionaryButtonsGameName();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNameForNewGame()
        {
            int dictionatyId = 1;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForGameMenuBack()
        {
            int dictionatyId = 2;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForHelpButtons()
        {
            int dictionatyId = 3;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForBoardText()
        {
            int dictionatyId = 4;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForPlayerSymbol()
        {
            int dictionatyId = 5;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForPlayersSymbols()
        {
            int dictionatyId = 6;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForChange()
        {
            int dictionatyId = 7;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForSwitch()
        {
            int dictionatyId = 8;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForOldAndNew()
        {
            int dictionatyId = 9;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }
        public static string GetButtonNameForButtonToHide()
        {
            int dictionatyId = 10;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForHelpStaticText()
        {
            int dictionatyId = 11;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForTextGame()
        {
            int dictionatyId = 12;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForTextOver()
        {
            int dictionatyId = 13;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }
        public static string GetButtonNameForTextTeam()
        {
            int dictionatyId = 14;
            string tagName = GetButtonsNameFromDictionaryButtonsGameName(dictionatyId);
            return tagName;
        }

        // ---------------------------------------------------------------------------------------

    }
}
