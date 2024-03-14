using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class GameDictionariesSceneInformations
    {
        public static Dictionary<int, string> DictionaryTagGameInformations()
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

        public static Dictionary<int, string> DictionaryButtonsGameInformations()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "CONTACT" },
                //buttonsNameDictionary.Add(2, "NEXT VERSIONS");
                { 2, "GAME VERSIONS" },
                //{ 3, "SET" }
                { 3, "DEFAULT SET" }
            };

            return buttonsNameDictionary;
        }
    }
}
