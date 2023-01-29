using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerificationCheckerHorizontal
    {

        public static ArrayList CheckerHorizontal(string[,] boardToCheck, int lenghtToCheck)
        {
            ArrayList listCheckerHorizontal = new ArrayList();

            int boardRowLength = boardToCheck.GetLength(0);
            int boardColumnLength = boardToCheck.GetLength(1);

            int boardMaxRowIndex = boardRowLength - 1;          
            int boardMaxColumnIndex = boardColumnLength - 1;

            bool checker = false;
            int columnIndex;
            int rowIndex;

            // check string
            string[] checkArray = new string[1];
            checkArray[0] = "";

            // count matching
            int[] matchingArray = new int[1];

            //
            int[,] coordinateXYToMark = new int[lenghtToCheck + 1, 2];
            int[] indexYToMark = new int[1];
            int increaseIndexXY = 1;

            for (rowIndex = 0; rowIndex <= boardMaxRowIndex; rowIndex++)
            {
                checkArray[0] = "";

                for (columnIndex = 0; columnIndex <= boardMaxColumnIndex; columnIndex++)
                {
                    if (checkArray[0].Equals(""))
                    {
                        //Debug.Log(" 1 rowIndex = " + rowIndex + " , columnIndex = " + columnIndex);
                        checkArray[0] = boardToCheck[rowIndex, columnIndex];
                        matchingArray[0] = 1;

                        coordinateXYToMark[0, 0] = rowIndex;
                        coordinateXYToMark[0, 1] = columnIndex;
                        indexYToMark[0] = 1;

                        //listCheckerHorizontal.Add(checker);
                        //bool test = (bool)listCheckerHorizontal[0];
                        listCheckerHorizontal.Insert(0, checker);
                        //Debug.Log("FALSE 0 = test = ");
                        //return listCheckerHorizontal;
                    }
                    else if (checkArray[0].Equals(boardToCheck[rowIndex, columnIndex]))
                    {
                       
                        if (matchingArray[0] < lenghtToCheck)
                        {
                            //Debug.Log(" 2 rowIndex = " + rowIndex + " , columnIndex = " + columnIndex);
                            checkArray[0] = boardToCheck[rowIndex, columnIndex];
                            matchingArray[0] = matchingArray[0] + 1;

                            int currentIndexY = indexYToMark[0];
                            coordinateXYToMark[currentIndexY, 0] = rowIndex;
                            coordinateXYToMark[currentIndexY, 1] = columnIndex;
                            indexYToMark[0] = currentIndexY + increaseIndexXY;

                            //listCheckerHorizontal[0] = checker;
                            //listCheckerHorizontal.Add(checker);
                            listCheckerHorizontal.Insert(0, checker);
                            //listCheckerHorizontal.Add(coordinateXYToMark);
                            //bool test = (bool)listCheckerHorizontal[0];
                            // Debug.Log("FALSE 1 = test = ");
                            //return listCheckerHorizontal;

                        }
                        else if (matchingArray[0] == lenghtToCheck)
                        {
                            checker = true;

                            int currentIndexY = indexYToMark[0];
                            coordinateXYToMark[currentIndexY, 0] = rowIndex;
                            coordinateXYToMark[currentIndexY, 1] = columnIndex;

                            //for (int y = 0; y < coordinateXYToMark.GetLength(0); y++)
                            //{
                            //    for (int x = 0; x < coordinateXYToMark.GetLength(1); x++)
                            //    {
                            //        Debug.Log($"coordinateXYToMark [{y},{x}] = " + coordinateXYToMark[y, x]);

                            //    }
                            //    Debug.Log($"----------------------------------------");
                            //}
                            //listCheckerHorizontal[0] = checker;
                            //listCheckerHorizontal.Add(checker);
                            listCheckerHorizontal.Insert(0, checker);
                            //listCheckerHorizontal.Add(coordinateXYToMark);
                            listCheckerHorizontal.Insert(1, coordinateXYToMark);



                            //Object test = listCheckerHorizontal[0];
                            //var test2 = test.GetType(); // boolean
                            //bool test3 = (bool)listCheckerHorizontal[0];
                            //bool test5 = listCheckerHorizontal[0].va


                            //Debug.Log("test" + test3);

                            return listCheckerHorizontal;
                            //return checker;

                        }
                    }
                    else if (checkArray[0] != boardToCheck[rowIndex, columnIndex])
                    {
                        if ((boardMaxColumnIndex - columnIndex) >= lenghtToCheck)
                        {
                            checkArray[0] = boardToCheck[rowIndex, columnIndex];
                            matchingArray[0] = 1;

                            indexYToMark[0] = 0;
                            coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];

                        }
                        else if ((boardMaxColumnIndex - columnIndex) < lenghtToCheck)
                        {
                            if (rowIndex == boardMaxRowIndex)
                            {
                                checker = false;
                                //return checker;
                                //listCheckerHorizontal[0] = checker;
                                //listCheckerHorizontal.Add(checker1);
                                listCheckerHorizontal.Insert(0, checker);
                               // bool test = (bool)listCheckerHorizontal[0];
                                //Debug.Log("FALSE = test = ");
                                return listCheckerHorizontal;




                            }
                            else if (rowIndex < boardMaxRowIndex)
                            {
                                checkArray[0] = "";
                                matchingArray[0] = 0;
                                indexYToMark[0] = 0;
                                coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                                //checker = false;
                                //return checker;

                                //listCheckerHorizontal.Add(checker);
                                ////bool test = (bool)listCheckerHorizontal[0];
                                //Debug.Log("FALSE 2 = test = ");
                                //return listCheckerHorizontal;


                            }
                        }
                    }
                }
            }


            return listCheckerHorizontal;

            //return listCheckerHorizontal;


        }

    }
}
