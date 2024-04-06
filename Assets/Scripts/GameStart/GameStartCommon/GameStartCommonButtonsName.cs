using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameStartCommonButtonsName
    {
        // --- button name

        public static string GetButtonsNameFromDictionaryButtonsStartGameName(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneStartGame.DictionaryButtonsStartGameName();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNameForTraditionalGame()
        {
            int dictionatyId = 1;
            string tagName = GetButtonsNameFromDictionaryButtonsStartGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForTeamGame()
        {
            int dictionatyId = 2;
            string tagName = GetButtonsNameFromDictionaryButtonsStartGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForQuestionMark()
        {
            int dictionatyId = 3;
            string tagName = GetButtonsNameFromDictionaryButtonsStartGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForGameBackground()
        {
            int dictionatyId = 4;
            string tagName = GetButtonsNameFromDictionaryButtonsStartGameName(dictionatyId);
            return tagName;
        }



        // buttons: game name
        public static string GetButtonsNameFromDictionaryButtonstGameName(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneStartGame.DictionaryButtonsGameName();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNameForWeird()
        {
            int dictionatyId = 1;
            string tagName = GetButtonsNameFromDictionaryButtonstGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForTic()
        {
            int dictionatyId = 2;
            string tagName = GetButtonsNameFromDictionaryButtonstGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForTac()
        {
            int dictionatyId = 3;
            string tagName = GetButtonsNameFromDictionaryButtonstGameName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForToe()
        {
            int dictionatyId = 4;
            string tagName = GetButtonsNameFromDictionaryButtonstGameName(dictionatyId);
            return tagName;
        }

    }
}
