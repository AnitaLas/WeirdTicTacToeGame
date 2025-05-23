﻿using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class GameDictionariesSceneInformation
    {
        public static Dictionary<int, string> DictionaryTagsGameInformation()
        {
            Dictionary<int, string> tagGameInformationsDictionary = new Dictionary<int, string>
            {
                { 1, "GameInformationButtonBack" },
                { 2, "GameInformationButtonContact" },
                { 3, "GameInformationButtonNextVersions" },
                { 4, "GameInformationButtonBackToMenu" },
                { 5, "GameInformationTextContact" },
                { 6, "GameInformationTextNextVersions" },
                { 7, "GameInformationButtontSet" },
                { 8, "GameInformationTextSet" },
                { 9, "GameName" }
            };

            return tagGameInformationsDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsGameInformation()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "  CONTACT" },
                //buttonsNameDictionary.Add(2, "NEXT VERSIONS");
                //{ 2, "GAME VERSIONS" },
                { 2, "  VERSIONS" },
                //{ 3, "SET" }
                //{ 3, "DEFAULT SET" }
                { 3, "MAX SETTINGS" }
            };

            return buttonsNameDictionary;
        }
    }
}
