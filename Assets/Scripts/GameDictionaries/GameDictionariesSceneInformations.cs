using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameDictionaries
{
    internal class GameDictionariesSceneInformations
    {

        public static Dictionary<int, string> DictionaryTagGameInformations()
        {
            Dictionary<int, string> tagGameInformationsDictionary = new Dictionary<int, string>();

            tagGameInformationsDictionary.Add(1, "GameInformationButtonBack");
            tagGameInformationsDictionary.Add(2, "GameInformationButtonContact");
            tagGameInformationsDictionary.Add(3, "GameInformationButtonNextVersions");
            tagGameInformationsDictionary.Add(4, "GameInformationButtonBackToMenu");



            return tagGameInformationsDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsGameInformations()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>();

            buttonsNameDictionary.Add(1, "CONTACT");
            buttonsNameDictionary.Add(2, "NEXT VERSIONS");

            return buttonsNameDictionary;
        }

    }
}
