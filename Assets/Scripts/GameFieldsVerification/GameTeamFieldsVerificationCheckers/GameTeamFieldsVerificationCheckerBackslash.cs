using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameTeamFieldsVerificationCheckerBackslash
    {

        public static ArrayList GameTeamCheckerBackslash(string[,] boardToCheck, int lenghtToCheck, List<string[]> teamGameSymbols)
        {
            ArrayList listCheckerBackslash = new ArrayList();

            int boardRowLength = boardToCheck.GetLength(0) - 1;
            int boardColumnLength = boardToCheck.GetLength(1) - 1;

            int nextRowIndexToCheck;
            int nextColumnIndexToCheck;

            for (nextRowIndexToCheck = 0; nextRowIndexToCheck < boardRowLength; nextRowIndexToCheck++)
            {
                for (nextColumnIndexToCheck = boardColumnLength; nextColumnIndexToCheck >= 0; nextColumnIndexToCheck--)
                {
                    listCheckerBackslash = CheckerBackslashForOne(boardToCheck, nextRowIndexToCheck, nextColumnIndexToCheck, lenghtToCheck, teamGameSymbols);

                    bool isBackslashWin = (bool)listCheckerBackslash[0];

                    if (isBackslashWin == true)
                    {
                        return listCheckerBackslash;
                    }
                    else if (isBackslashWin == false && (nextRowIndexToCheck == boardRowLength)) 
                    {
                        return listCheckerBackslash;
                    }
                }
            }

            return listCheckerBackslash;
        }

        public static ArrayList CheckerBackslashForOne(string[,] boardToCheck, int startRowIndexToCheck, int startColumnIndexToCheck, int lenghtToCheck, List<string[]> teamGameSymbols)
        {
            ArrayList listCheckerBackslash = new ArrayList();

            int boardRowLength = boardToCheck.GetLength(0) - 1;
            int boardColumnLength = boardToCheck.GetLength(1) - 1;

            bool checker = false;
            int columnIndex;
            int rowIndex;

            string[] matchingSymbol = new string[1];
            matchingSymbol[0] = "";

            //
            int[] numberOfMatchingSymbols = new int[1];
            int increaseNumberForMatchingSymbol = 1;

            //
            int[] crossedOut = new int[2];
            int increaseNumberForCrossedOutRww = 1;
            int decreaseNumberForCrossedOutColumn = 1;

            //
            int[,] coordinateXYToMark = new int[lenghtToCheck + 1, 2];
            int[] indexYToMark = new int[1];
            indexYToMark[0] = 0;
            int increaseIndexXY = 1;

            int teamsNumbers = teamGameSymbols.Count;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamGameSymbols[i];
                int playersNumber = teamSymbols.Length;


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

                        coordinateXYToMark[0, 0] = rowIndex;
                        coordinateXYToMark[0, 1] = columnIndex;
                        indexYToMark[0] = 1;

                        listCheckerBackslash.Insert(0, checker);
                    }
                    else if (rowIndex == crossedOut[0] && columnIndex == crossedOut[1])
                    {
                        //if (matchingSymbol[0].Equals(boardToCheck[rowIndex, columnIndex]))
                        //{
                                bool isMatchingArrayIncreased = false;

                                string currentSymbolToCheck = matchingSymbol[0];


                                string matchedSymbol = "";

                                for (int z = 0; z < playersNumber; z++)
                                {
                                    string teamSymbol = teamSymbols[z];

                                    if (teamSymbol.Equals(boardToCheck[rowIndex, columnIndex]))
                                    {
                                        matchedSymbol = teamSymbol;

                                        isMatchingArrayIncreased = true;
                                        break;
                                    }


                                }

                                bool isPreviousSymbolBelongToTeam = false;

                                for (int z = 0; z < playersNumber; z++)
                                {
                                    string teamSymbol = teamSymbols[z];

                                    if (teamSymbol.Equals(currentSymbolToCheck))
                                    {
                                        isPreviousSymbolBelongToTeam = true;
                                        break;
                                    }

                                }


                                if (isMatchingArrayIncreased == true)
                                {

                                    if (numberOfMatchingSymbols[0] < lenghtToCheck)
                                    {

                                        if (isPreviousSymbolBelongToTeam == false)
                                        {
                                        matchingSymbol[0] = boardToCheck[rowIndex, columnIndex];
                                        numberOfMatchingSymbols[0] = increaseNumberForMatchingSymbol;

                                            crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                            crossedOut[1] = crossedOut[1] - decreaseNumberForCrossedOutColumn;

                                            int currentIndexY = indexYToMark[0];
                                            coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                            coordinateXYToMark[currentIndexY, 1] = columnIndex;

                                            indexYToMark[0] = currentIndexY + increaseIndexXY;

                                            listCheckerBackslash.Insert(0, checker);


                                        }
                                        else
                                        {

                                            numberOfMatchingSymbols[0] = numberOfMatchingSymbols[0] + increaseNumberForMatchingSymbol;

                                            crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                            crossedOut[1] = crossedOut[1] - decreaseNumberForCrossedOutColumn;

                                            int currentIndexY = indexYToMark[0];
                                            coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                            coordinateXYToMark[currentIndexY, 1] = columnIndex;

                                            indexYToMark[0] = currentIndexY + increaseIndexXY;

                                            listCheckerBackslash.Insert(0, checker);



                                        }

                                    }
                                    else if (numberOfMatchingSymbols[0] == lenghtToCheck)
                                    {
                                        checker = true;

                                        int currentIndexY = indexYToMark[0];
                                        coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                        coordinateXYToMark[currentIndexY, 1] = columnIndex;

                                        listCheckerBackslash.Insert(0, checker);
                                        listCheckerBackslash.Insert(1, coordinateXYToMark);

                                        string kindOfChecker = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerBackslash();
                                        listCheckerBackslash.Insert(2, kindOfChecker);
                                    }







                                }







                                if (isMatchingArrayIncreased == false)
                                {


                                    if ((boardColumnLength - columnIndex) > lenghtToCheck)
                                    {
                                        if ((boardRowLength - rowIndex) > lenghtToCheck)
                                        {
                                            checker = false;
                                            listCheckerBackslash.Insert(0, checker);
                                            return listCheckerBackslash;
                                        }
                                    }
                                    else if ((boardRowLength - rowIndex) < lenghtToCheck)
                                    {
                                        checker = false;
                                        listCheckerBackslash.Insert(0, checker);
                                        return listCheckerBackslash;
                                    }





                                }



                               
                        //}
                        //else if (matchingSymbol[0] != boardToCheck[rowIndex, columnIndex])
                        //{
                        //    if ((boardColumnLength - columnIndex) > lenghtToCheck)
                        //    {
                        //        if ((boardRowLength - rowIndex) > lenghtToCheck)
                        //        {
                        //            checker = false;
                        //            listCheckerBackslash.Insert(0, checker);
                        //            return listCheckerBackslash;
                        //        }
                        //    }
                        //    else if ((boardRowLength - rowIndex) < lenghtToCheck)
                        //    {
                        //        checker = false;
                        //        listCheckerBackslash.Insert(0, checker);
                        //        return listCheckerBackslash;
                        //    }
                        //}
                        //else if ((boardColumnLength - lenghtToCheck) < lenghtToCheck)
                        //{
                        //    checker = false;
                        //    listCheckerBackslash.Insert(0, checker);
                        //    return listCheckerBackslash;
                        //}
                    }
                }
            }

        }
            return listCheckerBackslash;
        }

    }
}
