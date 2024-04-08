using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameDictionariesSceneTeamMembers
    {

        public static Dictionary<int, string> DictionaryTagsNameConfigurationTeamMembers()
        {
            Dictionary<int, string> tagTeamNumbers = new Dictionary<int, string>
            {
                { 1, "ConfigurationTeamMembersDefaultNumber" },
                { 2, "ConfigurationTeamMembersTableWithTeamSymbols" },
                { 3, "ConfigurationTeamMembersChange" },
                { 4, "ConfigurationTeamMembersInactiveField" },
                { 5, "ConfigurationTeamMembersButtonSave" },
                { 6, "ConfigurationTeamMembersButtonBack" },
                { 7, "ConfigurationTeamMembersTableWithAllSymbols" }
            };

            return tagTeamNumbers;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationTeamMembersName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "TEAM GAME" },
                { 2, "NUMBERS" },
                { 3, "TEAM" },
                { 4, "PLAYERS" },
            };

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationTeamMembersDefaultNumbers()
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
