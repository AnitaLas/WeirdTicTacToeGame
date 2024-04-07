using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameDictionariesSceneTeamNumbers
    {

        public static Dictionary<int, string> DictionaryTagsNameConfigurationTeamNumbers()
        {
            Dictionary<int, string> tagTeamNumbers = new Dictionary<int, string>
            {
                { 1, "ConfigurationTeamNumbersDefaultNumber" },
                { 2, "ConfigurationTeamNumbersTableWithNumbers" },
                { 3, "ConfigurationTeamNumbersChange" },
                { 4, "ConfigurationTeamNumbersInactiveField" },
                { 5, "ConfigurationTeamNumbersButtonSave" },
                { 6, "ConfigurationTeamNumbersButtonBack" }
            };

            return tagTeamNumbers;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationTeamNumbersName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "TEAM GAME" },
                { 2, "NUMBERS" },             
            };

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationTeamNumbersDefaultNumbers()
        {
            Dictionary<int, string> buttonsDefaultNumberDictionary = new Dictionary<int, string>
            {
                //{ 1, "0" }, 
                //{ 2, "1" }, 
                { 3, "2" }, 
            };

            return buttonsDefaultNumberDictionary;
        }
    }
}
