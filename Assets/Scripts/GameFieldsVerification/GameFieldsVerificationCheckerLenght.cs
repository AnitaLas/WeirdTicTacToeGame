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

        public static int SetUpLengthOfFieldsToCheck(int numberOfRows, int numberOfColumns, int numberToCheckGivenByUser)
        {
            int maxlength = CheckerLenght(numberOfRows, numberOfColumns);


  
            return 1;
        }
    }
}
