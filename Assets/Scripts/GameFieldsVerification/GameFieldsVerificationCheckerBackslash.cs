using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerificationCheckerBackslash
    {

        public static bool CheckerBackslash(string[,] boardToCheck, int lenghtToCheck)
        {

            string[,] board = boardToCheck;

            //Debug.Log("lenghtToCheck = " + lenghtToCheck);
            int boardRowLength = board.GetLength(0) - 1;
            int boardColumnLength = board.GetLength(1) - 1;

            int nextRowIndexToCheck;
            int nextColumnIndexToCheck;

            bool checker = false;

            // int rowIndex;

            for (nextRowIndexToCheck = 0; nextRowIndexToCheck < boardRowLength; nextRowIndexToCheck++)
            {

                for (nextColumnIndexToCheck = 0; nextColumnIndexToCheck < boardColumnLength; nextColumnIndexToCheck++)
                {


                    //Console.BackgroundColor = ConsoleColor.DarkCyan;
                    //Console.WriteLine("nextRowIndexToCheck: " + nextRowIndexToCheck);
                    //Console.BackgroundColor = ConsoleColor.Black;

                    checker = CheckerFromLefTopToRightBottomForOne(board, nextRowIndexToCheck, nextColumnIndexToCheck, lenghtToCheck);
                    //checker = CheckerFromLefTopToRightBottomForOne(board, nextRowIndexToCheck, nextColumnIndexToCheck);



                    //Console.BackgroundColor = ConsoleColor.DarkRed;
                    //Console.WriteLine(" if (checker == false) ");
                    //Console.WriteLine("nextRowIndexToCheck: " + nextRowIndexToCheck);
                    //Console.WriteLine("nextRowIndexToCheck: " + nextColumnIndexToCheck);
                    //Console.WriteLine("checker: " + checker);
                    //Console.BackgroundColor = ConsoleColor.Black;

                    if (checker == true)
                    {
                        checker = true;
                        return checker;
                    }
                    else if (checker == false && (nextRowIndexToCheck == boardRowLength || nextColumnIndexToCheck == boardColumnLength))
                    {
                        checker = false;
                        return checker;
                    }

                    /*
                     // work for row
                    if (checker == true)
                    {
                        checker = true;
                        return checker;
                    }
                    else if (checker == false && nextRowIndexToCheck == boardRowLength)
                    {
                        checker = false;
                        return checker;
                    }
                    */


                }

            }

            return checker;

        }






        public static bool CheckerFromLefTopToRightBottomForOne(string[,] boardToCheck, int startRowIndexToCheck, int startColumnIndexToCheck, int lenghtToCheck)
        {
            //string[,] board = boardToCheck;
            int startRowIndex = startRowIndexToCheck;
            int startColumnIndex = startColumnIndexToCheck;

            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            //Console.WriteLine("startRowIndex: " + startRowIndex);
            //Console.BackgroundColor = ConsoleColor.Black;

            int boardRowLength = boardToCheck.GetLength(0) - 1;
            int boardColumnLength = boardToCheck.GetLength(1) - 1;
            //Console.WriteLine("boardRowLength: " + boardRowLength);
            //Console.WriteLine("boardColumnLength: " + boardColumnLength);

            //int lenghtToCheck = GameFieldsVerificationCheckerLenght.CheckerLenght(boardColumnLength, boardRowLength);
            //int lenghtToCheck = 3;
            // Console.WriteLine("lenghtToCheck: " + lenghtToCheck);
            bool checker = false;
            int columnIndex;

            int rowIndex;

            // check string
            string[] checkArray = new string[1];

            // incoment only for crossed, for hor and vet must be commented
            checkArray[0] = "";

            // count matching
            int[] matchingArray = new int[1];
            //int countedMatching = 0;
            //matchingArray[0] = countedMatching;
            //matchingArray[0] = 0;

            // idex 0 = row, idex 1 = column
            int[] crossedOutLeftCorner = new int[2];
            //crossedOutLeftCorner[0] = 0;
            //crossedOutLeftCorner[1] = 0;
            int nextColumnIndex;
            int nextRowIndex;

            int crossedOutRow = 1;
            int crossedOutColumn = 1;


            // for cross left, top -> right bottom - start 
            for (rowIndex = startRowIndex; rowIndex <= boardRowLength; rowIndex++)
            {
                //Console.WriteLine("------------------------------------------------");
                //checkArray[0] = "";
                //matchingArray[0] = 0;
                //Console.WriteLine("checkArray[0]: " + checkArray[0]);
                //Console.WriteLine("matchingArray[0]: " + matchingArray[0]);
                //Console.WriteLine("------------------------------------------------");
                //Console.BackgroundColor = ConsoleColor.DarkYellow;
                //Console.WriteLine("ROW INDEX rowIndex: " + rowIndex);
                // Console.WriteLine("crossedOutLeftCorner[0]  = " + crossedOutLeftCorner[0]);
                //Console.WriteLine("crossedOutLeftCorner[1] " + columnIndex + " == " + crossedOutLeftCorner[1]);
                //Console.BackgroundColor = ConsoleColor.Black;

                for (columnIndex = startColumnIndex; columnIndex <= boardColumnLength; columnIndex++)
                {
                    //checkArray[0] = "";
                    // matchingArray[0] = 0;
                    //Console.WriteLine("------------------------------------------------");
                    //Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    //Console.WriteLine("COLUMNIndex: " + columnIndex);

                    //Console.WriteLine("for (columnIndex = 0; columnIndex <= boardColumnLength; columnIndex++)");
                    //Console.WriteLine("checkArray[0] = " + checkArray[0]);
                    //Console.WriteLine("matchingArray[0] = " + matchingArray[0]);
                    //Console.WriteLine("crossedOutLeftCorner[0] = rowIndex = " + crossedOutLeftCorner[0]);
                    //Console.WriteLine("crossedOutLeftCorner[1] = columnIndex = " + crossedOutLeftCorner[1]);
                    //Console.WriteLine("board value = " + board[rowIndex, columnIndex] + ", rowIndex = " + rowIndex + ", columnIndex = " + columnIndex);
                    //Console.BackgroundColor = ConsoleColor.Black;
                    //Console.WriteLine("------------------------------------------------");
                    //Console.WriteLine("------------------------------------------------");


                    //int numberRowsToCheck = boardRowLength - rowIndex;
                    //for (/nextRowIndex = 0; nextRowIndex < numberRowsToCheck; nextRowIndex++)
                    //{
                    //Console.WriteLine("------------------------------------------------");


                    if (checkArray[0].Equals(""))
                    {

                        checkArray[0] = boardToCheck[rowIndex, columnIndex];
                        matchingArray[0] = 1;
                        crossedOutLeftCorner[0] = startRowIndex + crossedOutRow;
                        crossedOutLeftCorner[1] = startColumnIndex + crossedOutColumn;
                        //Console.WriteLine("------------------------------------------------");
                        //Console.WriteLine("(checkArray[0].Equals( empty ))");
                        //Console.WriteLine("checkArray[0] = " + checkArray[0]);
                        //Console.WriteLine("matchingArray[0] = " + matchingArray[0]);
                        //Console.WriteLine("crossedOutLeftCorner[0] = rowIndex = " + crossedOutLeftCorner[0]);
                        //Console.WriteLine("crossedOutLeftCorner[1] = columnIndex = " + crossedOutLeftCorner[1]);
                        //Console.WriteLine("board value = " + board[rowIndex, columnIndex] + ", rowIndex = " + rowIndex + ", columnIndex = " + columnIndex);
                    }
                    else
                    {

                        if (rowIndex == crossedOutLeftCorner[0] && columnIndex == crossedOutLeftCorner[1])
                        {



                            if (checkArray[0].Equals(boardToCheck[rowIndex, columnIndex]))
                            {


                                if (matchingArray[0] < lenghtToCheck)
                                {
                                    // an update is not necessary to remove from hor and ver check!!!
                                    // checkArray[0] = board[rowIndex + crossedOutRow, columnIndex + crossedOutColumn];

                                    matchingArray[0] = matchingArray[0] + 1;
                                    // new row
                                    crossedOutLeftCorner[0] = rowIndex + crossedOutRow;
                                    // new column
                                    crossedOutLeftCorner[1] = columnIndex + crossedOutColumn;
                                    //Console.WriteLine("------------------------------------------------");
                                    //Console.WriteLine(" if (matchingArray[0] < lenghtToCheck)");
                                    //Console.WriteLine("checkArray[0] = " + checkArray[0]);
                                    //Console.WriteLine("matchingArray[0] = " + matchingArray[0]);
                                    //Console.WriteLine("crossedOutLeftCorner[0] = rowIndex = " + crossedOutLeftCorner[0]);
                                    //Console.WriteLine("crossedOutLeftCorner[1] = columnIndex = " + crossedOutLeftCorner[1]);
                                    //Console.WriteLine("board value = " + board[rowIndex, columnIndex] + ", rowIndex = " + rowIndex + ", columnIndex = " + columnIndex);




                                }
                                else if (matchingArray[0] == lenghtToCheck)
                                {
                                    checker = true;
                                    // Console.WriteLine("checker: " + checker);
                                    return checker;
                                }
                            }
                            else if (checkArray[0] != boardToCheck[rowIndex, columnIndex])
                            {

                                if ((boardColumnLength - columnIndex) >= lenghtToCheck)
                                {
                                    // Console.WriteLine("------------------------------------------------");
                                    //Console.WriteLine("(boardColumnLength - columnIndex) >= lenghtToCheck) " + (boardColumnLength - columnIndex) + " >= " + lenghtToCheck);

                                    if ((boardRowLength - rowIndex) >= lenghtToCheck)
                                    {
                                        //Console.WriteLine("------------------------------------------------");
                                        //Console.WriteLine("(boardColumnLength - (lenghtToCheck - columnIndex)) =  " + (boardRowLength - rowIndex) + " >= " + lenghtToCheck);
                                        checkArray[0] = checkArray[0];
                                        matchingArray[0] = matchingArray[0] + 1;
                                        crossedOutLeftCorner[0] = crossedOutLeftCorner[0] + 1;
                                        crossedOutLeftCorner[1] = crossedOutLeftCorner[1] + 1;
                                        //Console.WriteLine("------------------------------------------------");
                                        //Console.WriteLine(" else if (rowIndex != crossedOutLeftCorner[0] || columnIndex != crossedOutLeftCorner[1]");
                                        //Console.WriteLine("checkArray[0] = " + checkArray[0]);
                                        //Console.WriteLine("matchingArray[0] = " + matchingArray[0]);
                                        //Console.WriteLine("crossedOutLeftCorner[0] = rowIndex = " + crossedOutLeftCorner[0]);
                                        //Console.WriteLine("crossedOutLeftCorner[1] = columnIndex = " + crossedOutLeftCorner[1]);
                                        //Console.WriteLine("board value = " + board[rowIndex, columnIndex] + ", rowIndex = " + rowIndex + ", columnIndex = " + columnIndex);

                                    }
                                    else if ((boardRowLength - rowIndex) < lenghtToCheck)
                                    {
                                        checker = false;
                                        //Console.WriteLine("checker: " + checker);
                                        return checker;
                                    }
                                }
                                else if ((boardColumnLength - lenghtToCheck) < lenghtToCheck)
                                {

                                    checker = false;
                                    // Console.WriteLine("checker: " + checker);
                                    return checker;



                                }




                            }
                        }

                        else if (rowIndex != crossedOutLeftCorner[0] || columnIndex != crossedOutLeftCorner[1])
                        {

                            if (lenghtToCheck >= matchingArray[0])
                            {
                                checkArray[0] = checkArray[0];
                                matchingArray[0] = matchingArray[0];
                                crossedOutLeftCorner[0] = crossedOutLeftCorner[0];
                                crossedOutLeftCorner[1] = crossedOutLeftCorner[1];
                                //Console.WriteLine("------------------------------------------------");
                                //Console.WriteLine(" else if (rowIndex != crossedOutLeftCorner[0] || columnIndex != crossedOutLeftCorner[1]");
                                //Console.WriteLine("checkArray[0] = " + checkArray[0]);
                                //Console.WriteLine("matchingArray[0] = " + matchingArray[0]);
                                //Console.WriteLine("crossedOutLeftCorner[0] = rowIndex = " + crossedOutLeftCorner[0]);
                                //Console.WriteLine("crossedOutLeftCorner[1] = columnIndex = " + crossedOutLeftCorner[1]);
                            }
                            else if (lenghtToCheck < matchingArray[0])
                            {
                                if ((boardColumnLength - columnIndex) >= lenghtToCheck)
                                {
                                    //Console.WriteLine("------------------------------------------------");
                                    //Console.WriteLine("(boardColumnLength - columnIndex) >= lenghtToCheck) " + (boardColumnLength - columnIndex) + " >= " + lenghtToCheck);

                                    if ((boardRowLength - rowIndex) >= lenghtToCheck)
                                    {
                                        //Console.WriteLine("------------------------------------------------");
                                        //Console.WriteLine("(boardColumnLength - (lenghtToCheck - columnIndex)) =  " + (boardRowLength - rowIndex) + " >= " + lenghtToCheck);



                                    }
                                    else if ((boardRowLength - rowIndex) < lenghtToCheck)
                                    {
                                        checker = false;
                                        //Console.WriteLine("checker: " + checker);
                                        return checker;
                                    }
                                }
                                else if ((boardColumnLength - lenghtToCheck) < lenghtToCheck)
                                {

                                    checker = false;
                                    // Console.WriteLine("checker: " + checker);
                                    return checker;



                                }


                            }







                        }
                    }




                }
                //checkArray[0] = "";
            }

            return checker;
        }

    }
}
