using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameStartCommonButtonsTagName
    {
        public static string GetTagsNameFromDictionaryTagsStartGame(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneStartGame.DictionaryTagsStartGame();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetTagForButtonNameByTagStartGame()
        {
            int dictionatyId = 1;
            string tagName = GetTagsNameFromDictionaryTagsStartGame(dictionatyId);
            return tagName;
        }

        public static string GetTagForButtonNameByTagStartTeamGame()
        {
            int dictionatyId = 2;
            string tagName = GetTagsNameFromDictionaryTagsStartGame(dictionatyId);
            return tagName;
        }

        public static string GetTagForButtonNameByTagInformation()
        {
            int dictionatyId = 3;
            string tagName = GetTagsNameFromDictionaryTagsStartGame(dictionatyId);
            return tagName;
        }


    }
}
