using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerification
    {

        public static bool FieldsVerification(string[,] boardToCheck, int lenghtToCheck)
        {
            bool checker;

            //
            bool checkerHorizontal = GameFieldsVerificationCheckerHorizontal.CheckerHorizontal(boardToCheck, lenghtToCheck);

            //
            bool checkerVerticall = GameFieldsVerificationCheckerVertical.CheckerVerticall(boardToCheck, lenghtToCheck);

            //
            bool checkerSlash = GameFieldsVerificationCheckerSlash.CheckerSlash(boardToCheck, lenghtToCheck);

            //
            bool checkerBackslash = GameFieldsVerificationCheckerBackslash.CheckerBackslash(boardToCheck, lenghtToCheck);


            //
            if (checkerHorizontal == true || checkerVerticall == true || checkerSlash == true || checkerBackslash == true)
            {
                checker = true;
                return checker;
            }
            else
            {
                checker = false;
                return checker;
            }

           
        }


    }
}
