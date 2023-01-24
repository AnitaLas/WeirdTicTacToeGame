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
            string[,] board = boardToCheck;

            int boardRowLength = board.GetLength(0) - 1;
            int boardColumnLength = board.GetLength(1) - 1;
            // Console.WriteLine("boardRowLength: " + boardRowLength);
            // Console.WriteLine("boardColumnLength: " + boardColumnLength);

            //int lenghtToCheck = GameFieldsVerificationCheckerLenght.CheckerLenght(boardColumnLength, boardRowLength);
            //int lenghtToCheck = 3 - 1; // 3 = 3x index, number to check given by ueser = 3 - 1
            // Console.WriteLine("lenghtToCheck: " + lenghtToCheck);
            //Debug.Log("lenghtToCheck = " + lenghtToCheck);


            bool checker = false;
            int columnIndex;
            int rowIndex;

            // check string
            string[] checkArray = new string[1];

            // incoment only for crossed, for hor and vet must be commented
            checkArray[0] = "";

            // count matching
            int[] matchingArray = new int[1];


            for (rowIndex = 0; rowIndex <= boardRowLength; rowIndex++)
            {
                // Console.WriteLine("------------------------------------------------");
                checkArray[0] = "";
                //matchingArray[0] = 0;
                // Console.WriteLine("checkArray[0]: " + checkArray[0]);
                // Console.WriteLine("matchingArray[0]: " + matchingArray[0]);
                // Console.WriteLine("------------------------------------------------");
                // Console.WriteLine("ROW INDEX rowIndex: " + rowIndex);

                for (columnIndex = 0; columnIndex <= boardColumnLength; columnIndex++)
                {
                    //checkArray[0] = "";
                    // matchingArray[0] = 0;
                    // Console.WriteLine("columnIndex: " + columnIndex);


                    if (checkArray[0].Equals(""))
                    {

                        checkArray[0] = board[rowIndex, columnIndex];
                        //countedMatching = 1;
                        matchingArray[0] = 1;
                        // Console.WriteLine("------------------------------------------------");
                        // Console.WriteLine(" if (checkArray[0].Equals())------------------------------------------------");
                        //  Console.WriteLine("matchingArray[0] = 1: " + matchingArray[0]);
                        //  Console.WriteLine("checkArray[0]: " + checkArray[0]);
                        //  Console.WriteLine($"board[{rowIndex}, {columnIndex}]: " + board[rowIndex, columnIndex]);
                        //  Console.WriteLine("------------------------------------------------");
                    }
                    else if (checkArray[0].Equals(board[rowIndex, columnIndex]))
                    {
                        // Console.WriteLine("------------------------------------------------");
                        // Console.WriteLine("matchingArray[0] < lenghtToCheck-----------------------------------------------");
                        // Console.WriteLine("matchingArray[0] = 1: " + matchingArray[0]);

                        if (matchingArray[0] < lenghtToCheck)
                        {
                            // Console.WriteLine("matchingArray[0] < lenghtToCheck-----------------------------------------------");
                            // Console.WriteLine("rowIndex: " + rowIndex);
                            //  Console.WriteLine("columnIndex: " + columnIndex);
                            // Console.WriteLine($"board[{rowIndex}, {columnIndex}]: " + board[rowIndex, columnIndex]);
                            //Console.WriteLine("------------------------------------------------");
                            checkArray[0] = board[rowIndex, columnIndex];

                            //Console.WriteLine("------------------------------------------------");
                            // Console.WriteLine("matchingArray[0] < lenghtToCheck-----------------------------------------------");
                            // Console.WriteLine("matchingArray[0] = 1: " + matchingArray[0]);
                            // Console.WriteLine("checkArray[0]: " + checkArray[0]);
                            // Console.WriteLine($"board[{rowIndex}, {columnIndex}]: " + board[rowIndex, columnIndex]);
                            // Console.WriteLine("------------------------------------------------");

                            matchingArray[0] = matchingArray[0] + 1;


                        }
                        else if (matchingArray[0] == lenghtToCheck)
                        {
                            checker = true;
                            // Console.WriteLine("checker: " + checker);
                            return checker;
                        }
                    }
                    else if (checkArray[0] != board[rowIndex, columnIndex])
                    {
                        //Console.WriteLine("------------------------------------------------");
                        //Console.WriteLine("else if (checkArray[0] != board[rowIndex, columnIndex])----------------------------------------");
                        // Console.WriteLine("checkArray[0]: " + checkArray[0]);
                        // Console.WriteLine("matchingArray[0]: " + matchingArray[0]);
                        // Console.WriteLine("lenghtToCheck: " + lenghtToCheck);
                        //Console.WriteLine($"roznica: " + (lenghtToCheck - matchingArray[0]));
                       // Console.WriteLine("------------------------------------------------");



                        if ((boardColumnLength - columnIndex) >= lenghtToCheck)
                        //if ((boardColumnLength - matchingArray[0]) >= lenghtToCheck)
                        {
                            checkArray[0] = board[rowIndex, columnIndex];
                            //checkArray[0] = "";
                            matchingArray[0] = 1;
                            //Console.WriteLine("------------------------------------------------");
                            //Console.WriteLine("((lenghtToCheck - matchingArray[0]) > lenghtToCheck)-----------------------------------------------");
                            //Console.WriteLine("checkArray[0]: " + checkArray[0]);
                            //Console.WriteLine("matchingArray[0]: " + matchingArray[0]);
                            //Console.WriteLine($"board[{rowIndex}, {columnIndex}]: " + board[rowIndex, columnIndex]);
                            //Console.WriteLine("------------------------------------------------");

                        }
                        //else if ((lenghtToCheck - matchingArray[0]) < lenghtToCheck)
                        //else if ((boardColumnLength - matchingArray[0]) < lenghtToCheck)
                        else if ((boardColumnLength - columnIndex) < lenghtToCheck)
                        {
                            //Console.WriteLine("------------------------------------------------");
                            //Console.WriteLine("( if ((lenghtToCheck - matchingArray[0]) < lenghtToCheck)-----------------------------------------------");
                            // Console.WriteLine("rowIndex: " + rowIndex);
                            // Console.WriteLine("boardRowLength: " + boardRowLength);
                            // Console.WriteLine("boardRowLength =  rowIndex " + boardRowLength + " = " + rowIndex);
                            // Console.WriteLine("------------------------------------------------");

                            if (rowIndex == boardRowLength)
                            {
                                checker = false;
                                //Console.WriteLine("------------------------------------------------");
                                // Console.WriteLine("( if (rowIndex == boardRowLength)-----------------------------------------------");
                                // Console.WriteLine("checker: " + checker);
                                // Console.WriteLine("------------------------------------------------");
                                return checker;
                            }

                            else if (rowIndex < boardRowLength)
                            {
                                //Console.WriteLine("------------------------------------------------");
                                checkArray[0] = "";
                                matchingArray[0] = 0;
                                //Console.WriteLine("LAST checkArray[0]: " + checkArray[0]);
                                //Console.WriteLine("LAST matchingArray[0]: " + matchingArray[0]);
                                //Console.WriteLine("------------------------------------------------");


                            }

                        }

                    }



                }
                //checkArray[0] = "";
            }
            return checker;

        }

        /*
        public static bool CheckerHorizontal(string[,] boardToCheck)
        {
            string[,] board = boardToCheck;

            int boardRowLength = board.GetLength(0) - 1;
            int boardColumnLength = board.GetLength(1) - 1;
            // Console.WriteLine("boardRowLength: " + boardRowLength);
            // Console.WriteLine("boardColumnLength: " + boardColumnLength);

            int lenghtToCheck = GameFieldsVerificationCheckerLenght.CheckerLenght(boardColumnLength, boardRowLength);
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


            for (rowIndex = 0; rowIndex <= boardRowLength; rowIndex++)
            {
                // Console.WriteLine("------------------------------------------------");
                checkArray[0] = "";
                //matchingArray[0] = 0;
                // Console.WriteLine("checkArray[0]: " + checkArray[0]);
                // Console.WriteLine("matchingArray[0]: " + matchingArray[0]);
                // Console.WriteLine("------------------------------------------------");
                // Console.WriteLine("ROW INDEX rowIndex: " + rowIndex);

                for (columnIndex = 0; columnIndex <= boardColumnLength; columnIndex++)
                {
                    //checkArray[0] = "";
                    // matchingArray[0] = 0;
                    // Console.WriteLine("columnIndex: " + columnIndex);


                    if (checkArray[0].Equals(""))
                    {

                        checkArray[0] = board[rowIndex, columnIndex];
                        //countedMatching = 1;
                        matchingArray[0] = 1;
                        // Console.WriteLine("------------------------------------------------");
                        // Console.WriteLine(" if (checkArray[0].Equals())------------------------------------------------");
                        //  Console.WriteLine("matchingArray[0] = 1: " + matchingArray[0]);
                        //  Console.WriteLine("checkArray[0]: " + checkArray[0]);
                        //  Console.WriteLine($"board[{rowIndex}, {columnIndex}]: " + board[rowIndex, columnIndex]);
                        //  Console.WriteLine("------------------------------------------------");
                    }
                    else if (checkArray[0].Equals(board[rowIndex, columnIndex]))
                    {
                        // Console.WriteLine("------------------------------------------------");
                        // Console.WriteLine("matchingArray[0] < lenghtToCheck-----------------------------------------------");
                        // Console.WriteLine("matchingArray[0] = 1: " + matchingArray[0]);

                        if (matchingArray[0] < lenghtToCheck)
                        {
                            // Console.WriteLine("matchingArray[0] < lenghtToCheck-----------------------------------------------");
                            // Console.WriteLine("rowIndex: " + rowIndex);
                            //  Console.WriteLine("columnIndex: " + columnIndex);
                            // Console.WriteLine($"board[{rowIndex}, {columnIndex}]: " + board[rowIndex, columnIndex]);
                            Console.WriteLine("------------------------------------------------");
                            checkArray[0] = board[rowIndex, columnIndex];

                            //Console.WriteLine("------------------------------------------------");
                            // Console.WriteLine("matchingArray[0] < lenghtToCheck-----------------------------------------------");
                            // Console.WriteLine("matchingArray[0] = 1: " + matchingArray[0]);
                            // Console.WriteLine("checkArray[0]: " + checkArray[0]);
                            // Console.WriteLine($"board[{rowIndex}, {columnIndex}]: " + board[rowIndex, columnIndex]);
                            // Console.WriteLine("------------------------------------------------");

                            matchingArray[0] = matchingArray[0] + 1;


                        }
                        else if (matchingArray[0] == lenghtToCheck)
                        {
                            checker = true;
                            // Console.WriteLine("checker: " + checker);
                            return checker;
                        }
                    }
                    else if (checkArray[0] != board[rowIndex, columnIndex])
                    {
                        //Console.WriteLine("------------------------------------------------");
                        //Console.WriteLine("else if (checkArray[0] != board[rowIndex, columnIndex])----------------------------------------");
                        // Console.WriteLine("checkArray[0]: " + checkArray[0]);
                        // Console.WriteLine("matchingArray[0]: " + matchingArray[0]);
                        // Console.WriteLine("lenghtToCheck: " + lenghtToCheck);
                        //Console.WriteLine($"roznica: " + (lenghtToCheck - matchingArray[0]));
                        Console.WriteLine("------------------------------------------------");



                        if ((boardColumnLength - columnIndex) >= lenghtToCheck)
                        //if ((boardColumnLength - matchingArray[0]) >= lenghtToCheck)
                        {
                            checkArray[0] = board[rowIndex, columnIndex];

                            matchingArray[0] = 1;
                            //Console.WriteLine("------------------------------------------------");
                            //Console.WriteLine("((lenghtToCheck - matchingArray[0]) > lenghtToCheck)-----------------------------------------------");
                            //Console.WriteLine("checkArray[0]: " + checkArray[0]);
                            //Console.WriteLine("matchingArray[0]: " + matchingArray[0]);
                            //Console.WriteLine($"board[{rowIndex}, {columnIndex}]: " + board[rowIndex, columnIndex]);
                            //Console.WriteLine("------------------------------------------------");

                        }
                        //else if ((lenghtToCheck - matchingArray[0]) < lenghtToCheck)
                        //else if ((boardColumnLength - matchingArray[0]) < lenghtToCheck)
                        else if ((boardColumnLength - columnIndex) < lenghtToCheck)
                        {
                            //Console.WriteLine("------------------------------------------------");
                            //Console.WriteLine("( if ((lenghtToCheck - matchingArray[0]) < lenghtToCheck)-----------------------------------------------");
                            // Console.WriteLine("rowIndex: " + rowIndex);
                            // Console.WriteLine("boardRowLength: " + boardRowLength);
                            // Console.WriteLine("boardRowLength =  rowIndex " + boardRowLength + " = " + rowIndex);
                            // Console.WriteLine("------------------------------------------------");

                            if (rowIndex == boardRowLength)
                            {
                                checker = false;
                                //Console.WriteLine("------------------------------------------------");
                                // Console.WriteLine("( if (rowIndex == boardRowLength)-----------------------------------------------");
                                // Console.WriteLine("checker: " + checker);
                                // Console.WriteLine("------------------------------------------------");
                                return checker;
                            }

                            else if (rowIndex < boardRowLength)
                            {
                                //Console.WriteLine("------------------------------------------------");
                                checkArray[0] = "";
                                matchingArray[0] = 0;
                                //Console.WriteLine("LAST checkArray[0]: " + checkArray[0]);
                                //Console.WriteLine("LAST matchingArray[0]: " + matchingArray[0]);
                                //Console.WriteLine("------------------------------------------------");


                            }

                        }

                    }



                }
                //checkArray[0] = "";
            }
            return checker;

        }
        */
    }
}
