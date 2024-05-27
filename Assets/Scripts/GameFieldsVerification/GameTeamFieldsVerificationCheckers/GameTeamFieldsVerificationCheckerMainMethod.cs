using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

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
            //Debug.Log(" ------------------------------------------------------------- ");
            if (checker == false)
            {
                checkerHorizontal = GameTeamFieldsVerificationCheckerHorizontal.GameTeamCheckerHorizontal(boardToCheck, lenghtToCheck, teamGameSymbols);
                bool isHorizontalWin = (bool)checkerHorizontal[0];
                //Debug.Log("isHorizontalWin: " + isHorizontalWin);

                if (isHorizontalWin == false)
                {
                    checkerVertical = GameTeamFieldsVerificationCheckerVertical.GameTeamCheckerVertical(boardToCheck, lenghtToCheck, teamGameSymbols);
                    bool isVerticalWin = (bool)checkerVertical[0];
                    //Debug.Log("isVerticalWin: " + isVerticalWin);

                    if (isVerticalWin == false)
                    {
                        checkerSlash = GameTeamFieldsVerificationCheckerSlash.GmaeTeamCheckerSlash(boardToCheck, lenghtToCheck, teamGameSymbols);
                        bool isSlashlWin = (bool)checkerSlash[0];
                        //Debug.Log("isSlashlWin: " + isSlashlWin);

                        if (isSlashlWin == false)
                        {
                            checkerBackslash = GameTeamFieldsVerificationCheckerBackslash.GameTeamCheckerBackslash(boardToCheck, lenghtToCheck, teamGameSymbols);

                            bool isBackslashWin = (bool)checkerBackslash[0];
                            //Debug.Log("isBackslashWin: " + isBackslashWin);
                            return checkerBackslash;
                        }

                        return checkerSlash;
                    }

                       return checkerVertical;
                }
                //Debug.Log(" ------------------------------------------------------------- ");
                return checkerHorizontal;

            }
            else
            {
                return listChecker;
            }         
        }
    }
}
