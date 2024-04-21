using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Scripts
{
    internal class GameTeamFieldsVerificationCheckerMainMethod
    {
        public static ArrayList FieldsVerificationGameTeam(string[,] boardToCheck, int lenghtToCheck, List<string[]> teamGameSymbols)
        {
            ArrayList listChecker = new ArrayList(); 

            bool checker = false;

            ArrayList checkerHorizontal;
            ArrayList checkerVertical;
            ArrayList checkerSlash;
            ArrayList checkerBackslash;

            if(checker == false)
            {
                checkerHorizontal = GameTeamFieldsVerificationCheckerHorizontal.GameTeamCheckerHorizontal(boardToCheck, lenghtToCheck, teamGameSymbols);
                bool isHorizontalWin = (bool)checkerHorizontal[0];
                

                //if (isHorizontalWin == false)
                //{
                //    checkerVertical = GameFieldsVerificationCheckerVertical.CheckerVertical(boardToCheck, lenghtToCheck);
                //    bool isVerticalWin = (bool)checkerVertical[0];

                //    if (isVerticalWin == false)
                //    {
                //        checkerSlash = GameFieldsVerificationCheckerSlash.CheckerSlash(boardToCheck, lenghtToCheck);
                //        bool isSlashlWin = (bool)checkerSlash[0];

                //        if (isSlashlWin == false)
                //        {                     
                //            checkerBackslash = GameFieldsVerificationCheckerBackslash.CheckerBackslash(boardToCheck, lenghtToCheck);
                //            return checkerBackslash;
                //        }

                //        return checkerSlash;
                //    }

                //    return checkerVertical;
                //}

                return checkerHorizontal;

            }
            else
            {
                return listChecker;
            }         
        }
    }
}
