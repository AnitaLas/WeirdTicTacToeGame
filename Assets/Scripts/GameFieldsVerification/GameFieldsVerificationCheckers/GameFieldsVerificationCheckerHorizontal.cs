using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts
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
                        checkArray[0] = boardToCheck[rowIndex, columnIndex];
                        matchingArray[0] = 1;

                        coordinateXYToMark[0, 0] = rowIndex;
                        coordinateXYToMark[0, 1] = columnIndex;
                        indexYToMark[0] = 1;

                        listCheckerHorizontal.Insert(0, checker);
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

                            listCheckerHorizontal.Insert(0, checker);
                        }
                        else if (matchingArray[0] == lenghtToCheck)
                        {
                            checker = true;

                            int currentIndexY = indexYToMark[0];
                            coordinateXYToMark[currentIndexY, 0] = rowIndex;
                            coordinateXYToMark[currentIndexY, 1] = columnIndex;
                           
                            listCheckerHorizontal.Insert(0, checker);
                            listCheckerHorizontal.Insert(1, coordinateXYToMark);


                            //for (int z = 0; z < coordinateXYToMark.GetLength(0); z++)
                            //{
                            //    for (int j = 0; j < coordinateXYToMark.GetLength(1); j++)
                            //    {
                            //        UnityEngine.Debug.Log($"coordinateXYToMark: [{z}, {j}] = " + coordinateXYToMark[z, j]);

                            //    }
                            //}

                            string kindOfChecker = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerHorizontal();
                            listCheckerHorizontal.Insert(2, kindOfChecker);

                            return listCheckerHorizontal;
                        }
                    }
                    else if (checkArray[0] != boardToCheck[rowIndex, columnIndex])
                    {
                        if ((boardMaxColumnIndex - columnIndex) >= lenghtToCheck)
                        {
                            checkArray[0] = boardToCheck[rowIndex, columnIndex];
                            matchingArray[0] = 1;

                            indexYToMark[0] = 1;
                            coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                            coordinateXYToMark[0, 0] = rowIndex;
                            coordinateXYToMark[0, 1] = columnIndex;
                        }
                        else if ((boardMaxColumnIndex - columnIndex) < lenghtToCheck)
                        {
                            if (rowIndex == boardMaxRowIndex)
                            {
                                checker = false;
                                listCheckerHorizontal.Insert(0, checker);

                                return listCheckerHorizontal;
                            }
                            else if (rowIndex < boardMaxRowIndex)
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

            return listCheckerHorizontal;
        }
    }
}
