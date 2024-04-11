using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsTeamMembersTagName
    {

        public static string GetTagsNameFromDictionaryTagsConfigurationTeamMembers(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneTeamMembers.DictionaryTagsNameConfigurationTeamMembers();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagNameForButtonByTagTeamMembersDefaultNumber()
        {
            int dictionatyId = 1;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamMembers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamMembersTableWithSymbols()
        {
            int dictionatyId = 2;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamMembers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamMembersTableWithNumbers()
        {
            int dictionatyId = 10;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamMembers(dictionatyId);
            return currentNumber;
        }


        public static string GetTagNameForButtonByTagTeamMembersChange()
        {
            int dictionatyId = 3;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamMembers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamMembersInactiveField()
        {
            int dictionatyId = 4;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamMembers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamMembersButtonSave()
        {
            int dictionatyId = 5;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamMembers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamMembersButtonBack()
        {
            int dictionatyId = 6;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamMembers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamMembersButtonArrowLeft()
        {
            int dictionatyId = 8;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamMembers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamMembersButtonArrowRight()
        {
            int dictionatyId = 9;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamMembers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamMembersButtonButtonBackToConfiguration()
        {
            int dictionatyId = 11;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamMembers(dictionatyId);
            return currentNumber;
        }
    }
}
