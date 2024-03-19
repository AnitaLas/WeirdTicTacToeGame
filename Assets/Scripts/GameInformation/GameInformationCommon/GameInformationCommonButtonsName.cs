using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameInformationCommonButtonsName
    {
        // --- button name

        public static string GetButtonsNameFromDictionaryTagGameInformation(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneInformation.DictionaryButtonsGameInformation();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNameForContcat()
        {
            int dictionatyId = 1;
            string tagName = GetButtonsNameFromDictionaryTagGameInformation(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForGameVersions()
        {
            int dictionatyId = 2;
            string tagName = GetButtonsNameFromDictionaryTagGameInformation(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForDefaultSet()
        {
            int dictionatyId = 3;
            string tagName = GetButtonsNameFromDictionaryTagGameInformation(dictionatyId);
            return tagName;
        }



    }
}
