using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = System.Object;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerification
    {

        public static ArrayList FieldsVerification(string[,] boardToCheck, int lenghtToCheck)
        {
            ArrayList listChecker = new ArrayList(); 

            bool checker = false;

            ArrayList checkerHorizontal; // = false;
            ArrayList checkerVertical; // = false;
            ArrayList checkerSlash; //= false;
            ArrayList checkerBackslash; //= false;

            //bool[] isWin = { checkerHorizontal, checkerVerticall, checkerSlash, checkerBackslash };
            //int isWinLenght = isWin.Length;

            //Debug.Log(" 0 = " + checker);

            if(checker == false)
            {
                checkerHorizontal = GameFieldsVerificationCheckerHorizontal.CheckerHorizontal(boardToCheck, lenghtToCheck);
                //Debug.Log(" ?????????????????????????????????????????????????????? ");
                bool isHorizontalWin = (bool)checkerHorizontal[0];
               // Debug.Log("isHorizontalWin = " + isHorizontalWin);
               // string ischeckerHorizontalWin = checkerHorizontal2.ToString();
               // Debug.Log(" 1 ischeckerHorizontalWin = " + ischeckerHorizontalWin);

                if (isHorizontalWin == false)
                {
                    checkerVertical = GameFieldsVerificationCheckerVertical.CheckerVertical(boardToCheck, lenghtToCheck);
                    //Debug.Log(" 2 checkerVerticall = " + checkerVertical);
                    bool isVerticalWin = (bool)checkerVertical[0];

                    if (isVerticalWin == false)
                    {
                        checkerSlash = GameFieldsVerificationCheckerSlash.CheckerSlash(boardToCheck, lenghtToCheck);
                        //Debug.Log(" 3 checkerSlash = " + checkerSlash);
                        bool isSlashlWin = (bool)checkerSlash[0];

                        if (isSlashlWin == false)
                        {                     
                            checkerBackslash = GameFieldsVerificationCheckerBackslash.CheckerBackslash(boardToCheck, lenghtToCheck);
                            //bool isBacklashlWin = (bool)checkerBackslash[0];

                            //return isBacklashlWin;
                            return checkerBackslash;

                        }

                        //return isSlashlWin;
                        return checkerSlash;


                    }

                    //return isVerticalWin;
                    return checkerVertical;

                }

                //return isHorizontalWin;
                return checkerHorizontal;
                //return false;
            }
            else
            {
                return listChecker;
            }
           





            //Debug.Log(" 2 = " + checker);


            //Debug.Log(" 3 = " + checker);


            //return checker;

            //checkerHorizontal = GameFieldsVerificationCheckerHorizontal.CheckerHorizontal(boardToCheck, lenghtToCheck);

            ////
            //checkerVerticall = GameFieldsVerificationCheckerVertical.CheckerVerticall(boardToCheck, lenghtToCheck);

            ////
            //checkerSlash = GameFieldsVerificationCheckerSlash.CheckerSlash(boardToCheck, lenghtToCheck);

            ////
            //checkerBackslash = GameFieldsVerificationCheckerBackslash.CheckerBackslash(boardToCheck, lenghtToCheck);


            //if (checkerHorizontal == true || checkerVerticall == true || checkerSlash == true || checkerBackslash == true)
            //{
            //    checker = true;
            //    return checker;
            //}
            //else
            //{
            //    checker = false;
            //    return checker;
            //}


            //string stringTest = "1";
            //bool boolTest = true;
            //int[,] intArrayTest = { { 1, 2 }, {2,3} };


            //ArrayList myList = new ArrayList();

            //myList.Add(stringTest);
            //myList.Add(boolTest);
            //myList.Add(intArrayTest);










        }


    }
}
