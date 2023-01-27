using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerificationCheckerBackslash
    {

        public static bool CheckerBackslash(string[,] boardToCheck, int lenghtToCheck)
        {
            int boardRowLength = boardToCheck.GetLength(0) - 1;
            int boardColumnLength = boardToCheck.GetLength(1) - 1;

            int nextRowIndexToCheck;
            int nextColumnIndexToCheck;

            bool checker = false;

            for (nextRowIndexToCheck = 0; nextRowIndexToCheck < boardRowLength; nextRowIndexToCheck++)
            {

                for (nextColumnIndexToCheck = boardColumnLength; nextColumnIndexToCheck >= 0; nextColumnIndexToCheck--)
                {

                    checker = CheckerBackslashForOne(boardToCheck, nextRowIndexToCheck, nextColumnIndexToCheck, lenghtToCheck);

                    if (checker == true)
                    {
                        checker = true;
                        return checker;
                    }
                    else if (checker == false && (nextRowIndexToCheck == boardRowLength)) 
                    {
                        checker = false;
                        return checker;
                    }
                }
            }

            return checker;

        }




        public static bool CheckerBackslashForOne(string[,] boardToCheck, int startRowIndexToCheck, int startColumnIndexToCheck, int lenghtToCheck)
        {
            int boardRowLength = boardToCheck.GetLength(0) - 1;
            int boardColumnLength = boardToCheck.GetLength(1) - 1;

            bool checker = false;
            int columnIndex;
            int rowIndex;

            // CubePlay symbol
            string[] matchingSymbol = new string[1];
            matchingSymbol[0] = "";

            //
            int[] numberOfMatchingSymbols = new int[1];
            int increaseNumberForMatchingSymbol = 1;

            //
            int[] crossedOut = new int[2];
            int increaseNumberForCrossedOutRww = 1;
            int decreaseNumberForCrossedOutColumn = 1;


            for (rowIndex = startRowIndexToCheck; rowIndex <= boardRowLength; rowIndex++)
            {
                for (columnIndex = startColumnIndexToCheck; columnIndex >= 0; columnIndex--)
                {
                    if (matchingSymbol[0].Equals(""))
                    {
                        matchingSymbol[0] = boardToCheck[rowIndex, columnIndex];
                        numberOfMatchingSymbols[0] = increaseNumberForMatchingSymbol;
                        crossedOut[0] = rowIndex + increaseNumberForCrossedOutRww;
                        crossedOut[1] = columnIndex - decreaseNumberForCrossedOutColumn;

                    }
                    else if (rowIndex == crossedOut[0] && columnIndex == crossedOut[1])
                    {

                            if (matchingSymbol[0].Equals(boardToCheck[rowIndex, columnIndex]))
                            {


                                if (numberOfMatchingSymbols[0] < lenghtToCheck)
                                {
                                    numberOfMatchingSymbols[0] = numberOfMatchingSymbols[0] + increaseNumberForMatchingSymbol;
                                    crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                    crossedOut[1] = crossedOut[1] - decreaseNumberForCrossedOutColumn;

                                }
                                else if (numberOfMatchingSymbols[0] == lenghtToCheck)
                                {
                                    checker = true;
                                    return checker;
                                }
                            }
                            else if (matchingSymbol[0] != boardToCheck[rowIndex, columnIndex])
                            {

                                if ((boardColumnLength - columnIndex) > lenghtToCheck)
                                {
                                    if ((boardRowLength - rowIndex) > lenghtToCheck)
                                    {
                                        numberOfMatchingSymbols[0] = numberOfMatchingSymbols[0] + increaseNumberForMatchingSymbol;
                                        crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                        crossedOut[1] = crossedOut[1] - decreaseNumberForCrossedOutColumn;

                                        checker = false;
                                        return checker;

                                    }

                                }
                                else if ((boardColumnLength - lenghtToCheck) < lenghtToCheck)
                                {
                                    checker = false;
                                    return checker;

                                }

                            }
                    }

                }

            }
        
            return checker;
        }









    }
}
