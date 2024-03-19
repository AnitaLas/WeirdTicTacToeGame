using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class GameFieldsVerificationCommonMethods
    {
        public static string GetFieldsVerificationKindOfChecker(int dictionaryId)
        {
            Dictionary<int, string> kindOfCheckers = GameDictionariesGameFieldsVerificationCommon.DictionaryChecker();
            string kindOfChecker = kindOfCheckers[dictionaryId];
            return kindOfChecker;
        }

        public static string GetFieldsVerificationCheckerHorizontal()
        {
            int dictionatyId = 1;
            string defaulNumber = GetFieldsVerificationKindOfChecker(dictionatyId);
            return defaulNumber;
        }

        public static string GetFieldsVerificationCheckerVertical()
        {
            int dictionatyId = 2;
            string defaulNumber = GetFieldsVerificationKindOfChecker(dictionatyId);
            return defaulNumber;
        }

        public static string GetFieldsVerificationCheckerSlash()
        {
            int dictionatyId = 3;
            string defaulNumber = GetFieldsVerificationKindOfChecker(dictionatyId);
            return defaulNumber;
        }

        public static string GetFieldsVerificationCheckerBackslash()
        {
            int dictionatyId = 4;
            string defaulNumber = GetFieldsVerificationKindOfChecker(dictionatyId);
            return defaulNumber;
        }

    }
}
