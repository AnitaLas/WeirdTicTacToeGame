using System.Collections;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerification
    {
        public static ArrayList FieldsVerification(string[,] boardToCheck, int lenghtToCheck)
        {
            ArrayList listChecker = new ArrayList(); 

            bool checker = false;

            ArrayList checkerHorizontal; // == false;
            ArrayList checkerVertical; // == false;
            ArrayList checkerSlash; // == false;
            ArrayList checkerBackslash; // == false;

            if(checker == false)
            {
                checkerHorizontal = GameFieldsVerificationCheckerHorizontal.CheckerHorizontal(boardToCheck, lenghtToCheck);
                bool isHorizontalWin = (bool)checkerHorizontal[0];

                if (isHorizontalWin == false)
                {
                    checkerVertical = GameFieldsVerificationCheckerVertical.CheckerVertical(boardToCheck, lenghtToCheck);
                    bool isVerticalWin = (bool)checkerVertical[0];

                    if (isVerticalWin == false)
                    {
                        checkerSlash = GameFieldsVerificationCheckerSlash.CheckerSlash(boardToCheck, lenghtToCheck);
                        bool isSlashlWin = (bool)checkerSlash[0];

                        if (isSlashlWin == false)
                        {                     
                            checkerBackslash = GameFieldsVerificationCheckerBackslash.CheckerBackslash(boardToCheck, lenghtToCheck);
                            return checkerBackslash;
                        }

                        return checkerSlash;
                    }

                    return checkerVertical;
                }

                return checkerHorizontal;

            }
            else
            {
                return listChecker;
            }         
        }
    }
}
