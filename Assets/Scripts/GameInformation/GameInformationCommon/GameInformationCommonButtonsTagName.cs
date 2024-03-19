using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameInformationCommonButtonsTagName
    {
        public static string GetTagsNameFromDictionaryTagsGameInformation(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneInformation.DictionaryTagsGameInformation();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetTagForButtonNameByTagInformationButtonBack()
        {
            int dictionatyId = 1;
            string tagName = GetTagsNameFromDictionaryTagsGameInformation(dictionatyId);
            return tagName;
        }

        public static string GetTagForButtonNameByTagInformationButtonContact()
        {
            int dictionatyId = 2;
            string tagName = GetTagsNameFromDictionaryTagsGameInformation(dictionatyId);
            return tagName;
        }

        public static string GetTagForButtonNameByTagInformationButtonNextVersions()
        {
            int dictionatyId = 3;
            string tagName = GetTagsNameFromDictionaryTagsGameInformation(dictionatyId);
            return tagName;
        }

        public static string GetTagForButtonNameByTagInformationTextNextVersions()
        {
            int dictionatyId = 6;
            string tagName = GetTagsNameFromDictionaryTagsGameInformation(dictionatyId);
            return tagName;
        }

        public static string GetTagForButtonNameByTagInformationButtontSet()
        {
            int dictionatyId = 7;
            string tagName = GetTagsNameFromDictionaryTagsGameInformation(dictionatyId);
            return tagName;
        }

        public static string GetTagForButtonNameByTagName()
        {
            int dictionatyId = 9;
            string tagName = GetTagsNameFromDictionaryTagsGameInformation(dictionatyId);
            return tagName;
        }


        // button: text

        public static string GetTagTextByTagInformationButtonBackToMenu()
        {
            int dictionatyId = 4;
            string tagName = GetTagsNameFromDictionaryTagsGameInformation(dictionatyId);
            return tagName;
        }

        public static string GetTagTextByTagInformationTextContact()
        {
            int dictionatyId = 5;
            string tagName = GetTagsNameFromDictionaryTagsGameInformation(dictionatyId);
            return tagName;
        }

        public static string GetTagTextByTagInformationTextSet()
        {
            int dictionatyId = 8;
            string tagName = GetTagsNameFromDictionaryTagsGameInformation(dictionatyId);
            return tagName;
        }

    }
}
