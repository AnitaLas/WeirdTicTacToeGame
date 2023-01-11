using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerification
    {

        public static bool FieldsVerification(string[,] boardToCheck)
        {
            string[,] board = boardToCheck;

            bool checker;
            bool checkerHorizontal = GameFieldsVerificationCheckerHorizontal.CheckerHorizontal(board);
            //Console.WriteLine("checkerHorizontal: " + checkerHorizontal);

            bool checkerVerticall = GameFieldsVerificationCheckerVertical.CheckerVerticall(board);
            //Console.WriteLine("checkerVerticall: " + checkerVerticall);

            bool checkerFromLefTopToRightBottomForAll = GameFieldsVerificationCheckerBackslash.CheckerBackslash(board);
            //Console.WriteLine("checkerFromLefTopToRightBottomForAll: " + checkerFromLefTopToRightBottomForAll);

            bool checkerFromLeftBottomToRightTopForAll = GameFieldsVerificationCheckerSlash.CheckerSlash(board);
            //Console.WriteLine("checkerFromLeftBottomToRightTopForAll: " + checkerFromLeftBottomToRightTopForAll);

            if (checkerHorizontal == true || checkerVerticall == true || checkerFromLefTopToRightBottomForAll == true || checkerFromLeftBottomToRightTopForAll == true)
            {
                checker = true;
               // Console.WriteLine(" checker = true: " + checker);
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
