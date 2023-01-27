using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerificationCheckerHorizontal
    {

        public static bool CheckerHorizontal(string[,] boardToCheck, int lenghtToCheck)
        {
            int boardRowLength = boardToCheck.GetLength(0) - 1;
            int boardColumnLength = boardToCheck.GetLength(1) - 1;

            bool checker = false;
            int columnIndex;
            int rowIndex;

            // check string
            string[] checkArray = new string[1];
            checkArray[0] = "";

            // count matching
            int[] matchingArray = new int[1];


            for (rowIndex = 0; rowIndex <= boardRowLength; rowIndex++)
            {
                checkArray[0] = "";

                for (columnIndex = 0; columnIndex <= boardColumnLength; columnIndex++)
                {
                    if (checkArray[0].Equals(""))
                    {
                        checkArray[0] = boardToCheck[rowIndex, columnIndex];
                        matchingArray[0] = 1;

                    }
                    else if (checkArray[0].Equals(boardToCheck[rowIndex, columnIndex]))
                    {
                       
                        if (matchingArray[0] < lenghtToCheck)
                        {
                            checkArray[0] = boardToCheck[rowIndex, columnIndex];
                            matchingArray[0] = matchingArray[0] + 1;

                        }
                        else if (matchingArray[0] == lenghtToCheck)
                        {
                            checker = true;
                            return checker;

                        }
                    }
                    else if (checkArray[0] != boardToCheck[rowIndex, columnIndex])
                    {
                        if ((boardColumnLength - columnIndex) >= lenghtToCheck)
                        {
                            checkArray[0] = boardToCheck[rowIndex, columnIndex];
                            matchingArray[0] = 1;

                        }
                        else if ((boardColumnLength - columnIndex) < lenghtToCheck)
                        {
                            if (rowIndex == boardRowLength)
                            {
                                checker = false;
                                return checker;

                            }
                            else if (rowIndex < boardRowLength)
                            {
                                checkArray[0] = "";
                                matchingArray[0] = 0;

                            }
                        }
                    }
                }
            }

            return checker;

        }

    }
}
