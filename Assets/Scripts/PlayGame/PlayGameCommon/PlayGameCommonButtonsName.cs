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

        // ---------------------------------------------------------------------------------------

    }
}
