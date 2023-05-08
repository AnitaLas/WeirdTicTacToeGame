using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScreenVerification
{
    internal class ScreenVerificationMethods
    {
        public static Tuple<int, int > GetScreenSize()
        {

            int sizeWidth = Screen.width;
            int sizeHeight = Screen.height;

            Debug.Log(" sizeWidth = " + sizeWidth);
            Debug.Log(" sizeHeight = " + sizeHeight);
            Debug.Log(" ---------------------------- ");
           
            var screenSize = new Tuple<int, int>(sizeWidth, sizeHeight);
            return screenSize;
        }

        public static bool IsCellphoneMode()
        {
            bool isCellphoneMode;
            var screenSize = GetScreenSize();
            int sizeWidth = screenSize.Item1;
            int sizeHeight = screenSize.Item2;


            //if (sizeWidth < 1200 && sizeHeight < 2600)
            //if (sizeWidth < 1200)
            if (sizeWidth < 1400)
            {
                isCellphoneMode = true;
                
            }
            else
            {
                isCellphoneMode = false;
            }

           Debug.Log("isCellphoneMode = " + isCellphoneMode);
           return isCellphoneMode;

        }

        public static Tuple<int, int> GetNumberOfRowsAndColumnsForDefaulTableWithNumber(bool isCellphoneMode)
        {
            int rowsNumberModeCellphone = 3;
            int columnsNumberModeCellphone = 3;

            int rowsNumberModeTablet = 4;
            int columnsNumberModeTablet = 4;

            if (isCellphoneMode)
            {
                var numbers = new Tuple<int, int>(rowsNumberModeCellphone, columnsNumberModeCellphone);
                return numbers;
            }
            else
            {
                var numbers = new Tuple<int, int>(rowsNumberModeTablet, columnsNumberModeTablet);
                return numbers;
            }
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
