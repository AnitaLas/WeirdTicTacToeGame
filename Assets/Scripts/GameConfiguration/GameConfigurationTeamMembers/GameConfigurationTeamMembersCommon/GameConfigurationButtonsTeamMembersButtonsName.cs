using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsTeamMembersButtonsName
    {

        public static string GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersName(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneTeamMembers.DictionaryButtonsConfigurationTeamMembersName();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetButtonNameForTeamGame()
        {
            int dictionatyId = 1;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForNumbers()
        {
            int dictionatyId = 2;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForTeam()
        {
            int dictionatyId = 3;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForPlayers()
        {
            int dictionatyId = 4;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForPlayersNo()
        {
            int dictionatyId = 5;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersName(dictionatyId);
            return tagName;
        }

        public static string GetButtonNameForPlayer()
        {
            int dictionatyId = 6;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersName(dictionatyId);
            return tagName;
        }

        // default numbers:

        public static string GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersDefaultNumbers(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneTeamMembers.DictionaryButtonsConfigurationTeamMembersDefaultNumbers();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetDefaultButtonNumberForTeamMembers()
        {
            int dictionatyId = 3;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersDefaultNumbers(dictionatyId);
            return tagName;
        }

        public static string GetDefaultButtonMaxNumberForTeamMembers()
        {
            int dictionatyId = 19;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersDefaultNumbers(dictionatyId);
            return tagName;
        }

        // default symbols:

        public static string GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersDefaultSymbols(int dictionatyId)
        {
            Dictionary<int, string> buttonsNames = GameDictionariesSceneTeamMembers.DictionaryButtonsConfigurationTeamMembersDefaultSymbols();
            string buttonName = buttonsNames[dictionatyId];
            return buttonName;
        }

        public static string GetDefaultButtonSymolLeftForTeamMembers()
        {
            int dictionatyId = 1;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersDefaultSymbols(dictionatyId);
            return tagName;
        }

        public static string GetDefaultButtonSymolRightForTeamMembers()
        {
            int dictionatyId = 2;
            string tagName = GetButtonsNameFromDictionaryButtonsConfigurationTeamMembersDefaultSymbols(dictionatyId);
            return tagName;
        }
    }
}
