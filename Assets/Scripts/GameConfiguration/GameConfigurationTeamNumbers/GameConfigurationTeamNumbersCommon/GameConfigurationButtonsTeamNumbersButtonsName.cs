using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsTeamNumbersButtonsName
    {

        public static string GetButtonsNameFromDictionaryButtonsConfigurationTeamNumbersName(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneTeamNumbers.DictionaryButtonsConfigurationTeamNumbersName();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNameForTeamGame()
        {
            int dictionatyId = 1;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamNumbersName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForNumbers()
        {
            int dictionatyId = 2;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamNumbersName(dictionatyId);
            return tagName;
        }

        // default numbers:

        public static string GetButtonsNameFromDictionaryButtonsConfigurationTeamNumbersDefaultNumbers(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneTeamNumbers.DictionaryButtonsConfigurationTeamNumbersDefaultNumbers();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetDefaultButtonNumberForTeamNumbers()
        {
            int dictionatyId = 3;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamNumbersDefaultNumbers(dictionatyId);
            return tagName;
        }
    }
}
