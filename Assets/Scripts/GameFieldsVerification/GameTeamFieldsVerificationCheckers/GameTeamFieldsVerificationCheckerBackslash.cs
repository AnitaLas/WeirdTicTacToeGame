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

            // working one
            //string[] matchingSymbol = new string[1];
            //matchingSymbol[0] = "";


            int teamsNumbers = teamGameSymbols.Count;

            for (int teamNumber = 0; teamNumber < teamsNumbers; teamNumber++)
            {
                string[] teamSymbols = teamGameSymbols[teamNumber];
                int playersNumber = teamSymbols.Length;

                //Debug.Log(" BBBBBB ---------- TEAM SYMBOLS ------------ ");
                //Debug.Log($" BBBBBB ---------- {teamNumber} ------------ ");
                //for (int zz = 0; zz < teamSymbols.Length; zz++)
                //{
                //    Debug.Log($"teamSymbols[{zz}]: " + teamSymbols[zz]);
                //}

                //Debug.Log(" BBBBB ---------- TEAM SYMBOLS ------------ ");

                //
                //// CubePlay symbol - for slash
                string[] matchingSymbol = new string[1];
                matchingSymbol[0] = "";

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
                        else
                        {

                            if (rowIndex == crossedOut[0] && columnIndex == crossedOut[1])
                            {

                                //Debug.Log("TEST BACK ------------------------------------------");

                                //Debug.Log($"3 boardToCheck[{rowIndex}, {columnIndex}]: " + boardToCheck[rowIndex, columnIndex]);
                                bool isMatchingArrayIncreased = false;
                                string currentSymbolToCheck = matchingSymbol[0];
                                //Debug.Log("currentSymbolToCheck: " + currentSymbolToCheck); // + ", rowIndex" + crossedOut[0] + ", columnIndex = " + crossedOut[1]);


                                for (int z = 0; z < playersNumber; z++)
                                {
                                    string teamSymbol = teamSymbols[z];

                                    if (teamSymbol.Equals(boardToCheck[rowIndex, columnIndex]))
                                    {
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

                                            //Debug.Log("3 numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                                            //Debug.Log("3 matchingSymbol[0]: " + matchingSymbol[0]);

                                            crossedOut[0] = rowIndex + increaseNumberForCrossedOutRww;
                                            crossedOut[1] = columnIndex - decreaseNumberForCrossedOutColumn;

                                            indexYToMark[0] = 1;
                                            coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                                            coordinateXYToMark[0, 0] = rowIndex;
                                            coordinateXYToMark[0, 1] = columnIndex;
                                            
                                            

                                            listCheckerBackslash.Insert(0, checker);



                                        }
                                        else
                                        {
                                            matchingSymbol[0] = boardToCheck[rowIndex, columnIndex];
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
                                        //Debug.Log("WIN numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                                        checker = true;

                                        int currentIndexY = indexYToMark[0];
                                        coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                        coordinateXYToMark[currentIndexY, 1] = columnIndex;

                                        listCheckerBackslash.Insert(0, checker);
                                        listCheckerBackslash.Insert(1, coordinateXYToMark);
                                        string kindOfChecker = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerBackslash();
                                        listCheckerBackslash.Insert(2, kindOfChecker);

                                        teamNumber = teamsNumbers + 13;
                                    }
                                    





                                }



                                if (isMatchingArrayIncreased == false)
                                {
                                    matchingSymbol[0] = boardToCheck[rowIndex, columnIndex];
                                    numberOfMatchingSymbols[0] = increaseNumberForMatchingSymbol;

                                    //Debug.Log("3 numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                                    //Debug.Log("3 matchingSymbol[0]: " + matchingSymbol[0]);

                                    crossedOut[0] = rowIndex + increaseNumberForCrossedOutRww;
                                    crossedOut[1] = columnIndex - decreaseNumberForCrossedOutColumn;

                                    indexYToMark[0] = 1;
                                    coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                                    coordinateXYToMark[0, 0] = rowIndex;
                                    coordinateXYToMark[0, 1] = columnIndex;



                                    listCheckerBackslash.Insert(0, checker);


                                    //if ((boardColumnLength - columnIndex) > lenghtToCheck)
                                    //{
                                    //    if ((boardRowLength - rowIndex) > lenghtToCheck)
                                    //    {
                                    //        checker = false;
                                    //        listCheckerBackslash.Insert(0, checker);
                                    //        return listCheckerBackslash;
                                    //    }
                                    //}
                                    //else if ((boardRowLength - rowIndex) < lenghtToCheck)
                                    //{
                                    //    checker = false;
                                    //    listCheckerBackslash.Insert(0, checker);
                                    //    return listCheckerBackslash;
                                    //}

                                    //if ((boardColumnLength - columnIndex) < lenghtToCheck)
                                    //{
                                    //    if ((boardRowLength - rowIndex) < lenghtToCheck)
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





                            //    if (matchingSymbol[0].Equals(boardToCheck[rowIndex, columnIndex]))
                            //{
                                






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
