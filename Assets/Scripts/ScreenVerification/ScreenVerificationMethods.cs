using System;
using UnityEngine;

namespace Assets.Scripts
{
    internal class ScreenVerificationMethods
    {
        public static Tuple<int, int > GetScreenSize()
        {
            int sizeWidth = Screen.width;
            int sizeHeight = Screen.height;

            var screenSize = new Tuple<int, int>(sizeWidth, sizeHeight);
            return screenSize;
        }

        public static bool IsCellphoneMode()
        {
            bool isCellphoneMode;
            var screenSize = GetScreenSize();
            int sizeWidth = screenSize.Item1;
            int sizeHeight = screenSize.Item2;

            if (sizeWidth < 1200)
            {
                isCellphoneMode = true;          
            }
            else
            {
                isCellphoneMode = false;
            }

           return isCellphoneMode;
        }

        public static Tuple<int, int> GetNumberOfRowsAndColumnsForDefaulTableWithNumber(bool isCellphoneMode)
        {
            //int rowsNumberModeCellphone = 3;
            //int columnsNumberModeCellphone = 3;

            //int rowsNumberModeTablet = 4;
            //int columnsNumberModeTablet = 4;

            //if (isCellphoneMode)
            //{
            //    var numbers = new Tuple<int, int>(rowsNumberModeCellphone, columnsNumberModeCellphone);
            //    return numbers;
            //}
            //else
            //{
            //    var numbers = new Tuple<int, int>(rowsNumberModeTablet, columnsNumberModeTablet);
            //    return numbers;
            //}


            Tuple<int, int> tableSize;

            if (isCellphoneMode)
            {
                tableSize = Tuple.Create(3, 3); // rows, columns
            }
            else
            {
                tableSize = Tuple.Create(4, 4);
            }

            return tableSize;
        }

        public static Tuple<int, int> GetSizeForTableWithSymbolsForTeamMembers(bool isCellphoneMode)
        {
            Tuple<int, int> tableSize;

            if (isCellphoneMode == true)
            {
                tableSize = Tuple.Create(1, 3); // rows, columns
            }
            else
            {
                tableSize = Tuple.Create(3, 3);
            }

            return tableSize;
        }

        public static Tuple<int, int> GetSizeForTableWithPlayersNumbersForTeamMembers(bool isCellphoneMode)
        {
            Tuple<int, int> tableSize;

            if (isCellphoneMode == true)
            {
                tableSize = Tuple.Create(1, 3); // rows, columns
            }
            else
            {
                tableSize = Tuple.Create(2, 3);
            }

            return tableSize;
        }

        public static int GetMaxPlayerNumberForConfiguration(bool isCellphoneMode)
        {
            int maxPlayerNumbeModeCellphone = 6;
            int maxPlayerNumbeNumberModeTablet = 12;

            if (isCellphoneMode)
            {
                return maxPlayerNumbeModeCellphone;
            }
            else
            {
                return maxPlayerNumbeNumberModeTablet;
            }
        }

        public static int GetMaxPRowsOrColumnsNumberForConfiguration(bool isCellphoneMode)
        {
            int maxRowsOrColumnsNumberModeCellphone = 9;
            int maxRowsOrColumnsNumberModeTablet = 15;

            if (isCellphoneMode)
            {
                return maxRowsOrColumnsNumberModeCellphone;
            }
            else
            {
                return maxRowsOrColumnsNumberModeTablet;
            }
        }
    }
}
