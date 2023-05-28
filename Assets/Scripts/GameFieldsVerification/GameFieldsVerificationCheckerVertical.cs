using System.Collections;
using System.Collections.Generic;

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
                            int currentIndexY = indexYToMark[0];
                            coordinateXYToMark[currentIndexY, 0] = rowIndex;
                            coordinateXYToMark[currentIndexY, 1] = columnIndex;

                            listCheckerVertical.Insert(0, checker);
                            listCheckerVertical.Insert(1, coordinateXYToMark);

                            Dictionary<int, string> checkerDictionary = GameDictionaries.GameDictionariesGameFieldsVerification.DictionaryChecker();
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

                            coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                            coordinateXYToMark[0, 0] = rowIndex;
                            coordinateXYToMark[0, 1] = columnIndex;                       
                        }
                        else if ((boardRowLength - rowIndex) < lenghtToCheck)
                        {
                           if (columnIndex == boardColumnLength)
                           {
                                checker = false;

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

            return listCheckerVertical;
        }
    }
}
