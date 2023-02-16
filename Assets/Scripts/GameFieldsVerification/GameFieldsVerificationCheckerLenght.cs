using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerificationCheckerLenght
    {
        public static int SetUpMaxLenghtToCheck(int numberOfRows, int numberOfColumns)
        {
            //int x = numberOfColumns - 1;
            //int y = numberOfRows - 1;

            //int lowerNumber = CommonMethods.CheckAndReturnLowerNumber(x, y);
            int lowerNumber = CommonMethods.CheckAndReturnLowerNumber(numberOfColumns, numberOfRows);
            return lowerNumber;

        }
        
        public static int SetUpLenghtToCheck(int lenghtToCheckMax, int lenghtToCheckGivenByUser)
        {           
            int lenghtToCheck = CommonMethods.CheckAndReturnLowerNumber(lenghtToCheckMax, lenghtToCheckGivenByUser);
            int tableIndex = lenghtToCheck - 1;
            return tableIndex;
        }



        public static int CheckerLenght(int numberOfRows, int numberOfColumns)
        {

            if (numberOfColumns > numberOfRows)
            {
                return numberOfRows;
            }
            else if (numberOfColumns < numberOfRows)
            {
                return numberOfColumns;
            }
            else
            {
                // verticalLenght = horizontalLenght
                return numberOfColumns;
            }

        }
        

    }
}
