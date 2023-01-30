using Assets.Scripts.GameDictionaries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerificationCheckerVertical
    {

        public static ArrayList CheckerVertical(string[,] boardToCheck, int lenghtToCheck)
        {
            ArrayList listCheckerVertical = new ArrayList();

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

            //
            int[,] coordinateXYToMark = new int[lenghtToCheck + 1, 2];
            int[] indexYToMark = new int[1];
            int increaseIndexXY = 1;

            for (columnIndex = 0; columnIndex <= boardColumnLength; columnIndex++)
            {
                checkArray[0] = "";
             
                for (rowIndex = 0; rowIndex <= boardRowLength; rowIndex++)
                {
                    if (checkArray[0].Equals(""))
                    {
                        checkArray[0] = boardToCheck[rowIndex, columnIndex];
                        matchingArray[0] = 1;

                        coordinateXYToMark[0, 0] = rowIndex;
                        coordinateXYToMark[0, 1] = columnIndex;
                        indexYToMark[0] = 1;

                        listCheckerVertical.Insert(0, checker);

                    }
                    else if (checkArray[0].Equals(boardToCheck[rowIndex, columnIndex]))
                    {
                        if (matchingArray[0] < lenghtToCheck)
                        {
                            checkArray[0] = boardToCheck[rowIndex, columnIndex];
                            matchingArray[0] = matchingArray[0] + 1;

                            int currentIndexY = indexYToMark[0];
                            coordinateXYToMark[currentIndexY, 0] = rowIndex;
                            coordinateXYToMark[currentIndexY, 1] = columnIndex;
                            indexYToMark[0] = currentIndexY + increaseIndexXY;

                            listCheckerVertical.Insert(0, checker);

                        }
                        else if (matchingArray[0] == lenghtToCheck)
                        {
                            checker = true;
                            //return checker;
                            int currentIndexY = indexYToMark[0];
                            coordinateXYToMark[currentIndexY, 0] = rowIndex;
                            coordinateXYToMark[currentIndexY, 1] = columnIndex;

                            listCheckerVertical.Insert(0, checker);
                            listCheckerVertical.Insert(1, coordinateXYToMark);

                            Dictionary<int, string> checkerDictionary = GameDictionariesCommon.DictionaryChecker();
                            string kindOfChecker = checkerDictionary[2];
                            listCheckerVertical.Insert(2, kindOfChecker);

                            return listCheckerVertical;

                        }
                    }
                    else if (checkArray[0] != boardToCheck[rowIndex, columnIndex])
                    {
                        if ((boardRowLength - rowIndex) >= lenghtToCheck) 
                        {
                            checkArray[0] = boardToCheck[rowIndex, columnIndex];
                            matchingArray[0] = 1;

                            indexYToMark[0] = 1;
                            //int currentIndexY = indexYToMark[0];
                            coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                            coordinateXYToMark[0, 0] = rowIndex;
                            coordinateXYToMark[0, 1] = columnIndex;
                            //Debug.Log($"coordinateXYToMark [{coordinateXYToMark[0, 0]},{columnIndex}] = " + coordinateXYToMark[rowIndex, columnIndex]);
                            Debug.Log("row = " + coordinateXYToMark[0, 0]);
                            Debug.Log("column = " + coordinateXYToMark[0, 1]);
                            Debug.Log(" ------------------------------------------------------ ");
                        }
                        else if ((boardRowLength - rowIndex) < lenghtToCheck)
                        {
                           if (columnIndex == boardColumnLength)
                           {
                                checker = false;
                                //return checker;

                                listCheckerVertical.Insert(0, checker);
                                return listCheckerVertical;
                            }
                           else if (columnIndex < boardColumnLength)
                           {
                                checkArray[0] = "";
                                matchingArray[0] = 0;
                                indexYToMark[0] = 0;
                                coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];

                            }
                        }
                    }
                }
            }



            //for (int y = 0; y < coordinateXYToMark.GetLength(0); y++)
            //{
            //    for (int x = 0; x < coordinateXYToMark.GetLength(1); x++)
            //    {
            //        Debug.Log($"coordinateXYToMark [{y},{x}] = " + coordinateXYToMark[y, x]);

            //    }
            //    Debug.Log($"----------------------------------------");
            //}
            //Debug.Log($"---------- ************************************  ------------------------------");


            return listCheckerVertical;

        }
    }
}
