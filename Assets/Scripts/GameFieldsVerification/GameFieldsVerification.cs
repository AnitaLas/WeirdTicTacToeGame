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
            //string[,] board = boardToCheck;

            bool checker;
            bool checkerHorizontal = GameFieldsVerificationCheckerHorizontal.CheckerHorizontal(boardToCheck, lenghtToCheck);
            //Console.WriteLine("checkerHorizontal: " + checkerHorizontal);

            bool checkerVerticall = GameFieldsVerificationCheckerVertical.CheckerVerticall(boardToCheck, lenghtToCheck);
            //Console.WriteLine("checkerVerticall: " + checkerVerticall);

            bool checkerFromLefTopToRightBottomForAll = GameFieldsVerificationCheckerBackslash.CheckerBackslash(boardToCheck, lenghtToCheck);
            //Console.WriteLine("checkerFromLefTopToRightBottomForAll: " + checkerFromLefTopToRightBottomForAll);

            bool checkerFromLeftBottomToRightTopForAll = GameFieldsVerificationCheckerSlash.CheckerSlash(boardToCheck, lenghtToCheck);
            //Console.WriteLine("checkerFromLeftBottomToRightTopForAll: " + checkerFromLeftBottomToRightTopForAll);

            //if (checkerHorizontal == true || checkerVerticall == true || checkerFromLefTopToRightBottomForAll == true || checkerFromLeftBottomToRightTopForAll == true)

            if  (checkerFromLefTopToRightBottomForAll == true )
            {
                checker = true;
                Debug.Log("checker = " + checker);
                return checker;
                //return true
            }
            else
            {
                checker = false;
                //Console.WriteLine("checker = false: " + checker);
                return checker;
            }

            /*
            else if (checkerVerticall == true)
            {
                checker = checkerVerticall;
                return checker;
            }
            else if (checkerFromLefTopToRightBottomForAll == true)
            {
                checker = checkerFromLefTopToRightBottomForAll;
                return checker;
            }
            else if (checkerFromLeftBottomToRightTopForAll == true)
            {
                checker = checkerFromLeftBottomToRightTopForAll;
                return checker;
            } else
            {
                checker = false;
                return checker;
            }
            */

            // return checker;
        }



    }
}
