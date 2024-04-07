using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsTeamNumbersTagName
    {

        public static string GetTagsNameFromDictionaryTagsConfigurationTeamNumbers(int dictionatyId)
        {
            Dictionary<int, string> defaulNumbers = GameDictionariesSceneTeamNumbers.DictionaryTagsNameConfigurationTeamNumbers();
            string defaulNumber = defaulNumbers[dictionatyId];
            return defaulNumber;
        }

        public static string GetTagNameForButtonByTagTeamNumbersDefaultNumber()
        {
            int dictionatyId = 1;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamNumbers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamNumbersTableWithNumbers()
        {
            int dictionatyId = 2;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamNumbers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamNumbersChange()
        {
            int dictionatyId = 3;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamNumbers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamNumbersInactiveField()
        {
            int dictionatyId = 4;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamNumbers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamNumbersButtonSave()
        {
            int dictionatyId = 5;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamNumbers(dictionatyId);
            return currentNumber;
        }

        public static string GetTagNameForButtonByTagTeamNumbersButtonBack()
        {
            int dictionatyId = 6;
            string currentNumber = GetTagsNameFromDictionaryTagsConfigurationTeamNumbers(dictionatyId);
            return currentNumber;
        }
    }
}
