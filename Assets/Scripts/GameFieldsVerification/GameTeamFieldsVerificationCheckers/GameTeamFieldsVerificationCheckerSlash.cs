using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class GameTeamFieldsVerificationCheckerSlash
    {
        public static ArrayList GmaeTeamCheckerSlash(string[,] boardToCheck, int lenghtToCheck, List<string[]> teamGameSymbols)
        {
            ArrayList listCheckerSlash = new ArrayList();

            int boardRowLength = boardToCheck.GetLength(0) - 1;
            int boardColumnLength = boardToCheck.GetLength(1) - 1;

            int nextRowIndexToCheck;
            int nextColumnIndexToCheck;

            for (nextRowIndexToCheck = 0; nextRowIndexToCheck < boardRowLength; nextRowIndexToCheck++)
            {
                for (nextColumnIndexToCheck = 0; nextColumnIndexToCheck < boardColumnLength; nextColumnIndexToCheck++)
                {
                    listCheckerSlash = CheckerFromLeftBottomToRightTopForOne(boardToCheck, nextRowIndexToCheck, nextColumnIndexToCheck, lenghtToCheck, teamGameSymbols);

                    bool isSlashWin = (bool)listCheckerSlash[0];
;
                    if (isSlashWin == true)
                    {
                        return listCheckerSlash;

                    }
                    else if (isSlashWin == false && (nextRowIndexToCheck == boardRowLength || nextColumnIndexToCheck == boardColumnLength))
                    {
                        return listCheckerSlash;
                    }
                }
            }

            return listCheckerSlash;
        }


        //
        public static ArrayList CheckerFromLeftBottomToRightTopForOne(string[,] boardToCheck, int startRowIndexToCheck, int startColumnIndexToCheck, int lenghtToCheck, List<string[]> teamGameSymbols)
        {
            ArrayList listCheckerSlash = new ArrayList();

            int startRowIndex = startRowIndexToCheck;
            int startColumnIndex = startColumnIndexToCheck;

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
            int increaseNumberForCrossedOutColumn = 1;

            //
            int[,] coordinateXYToMark = new int[lenghtToCheck + 1, 2];
            int[] indexYToMark = new int[1];
            int increaseIndexXY = 1;

            int teamsNumbers = teamGameSymbols.Count;

            //Debug.Log("1 lenghtToCheck" + lenghtToCheck);

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamGameSymbols[i];
                int playersNumber = teamSymbols.Length;

                for (rowIndex = startRowIndex; rowIndex <= boardRowLength; rowIndex++)
            {
                    for (columnIndex = startColumnIndex; columnIndex <= boardColumnLength; columnIndex++)
                    {
                        if (matchingSymbol[0].Equals(""))
                        {
                            matchingSymbol[0] = boardToCheck[rowIndex, columnIndex];
                            numberOfMatchingSymbols[0] = increaseNumberForMatchingSymbol;

                            crossedOut[0] = rowIndex + increaseNumberForCrossedOutRww;
                            crossedOut[1] = columnIndex + increaseNumberForCrossedOutColumn;

                            coordinateXYToMark[0, 0] = rowIndex;
                            coordinateXYToMark[0, 1] = columnIndex;
                            indexYToMark[0] = 1;

                            listCheckerSlash.Insert(0, checker);
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
                                        //numberOfMatchingSymbols[0] = numberOfMatchingSymbols[0] + increaseNumberForMatchingSymbol;

                                        //crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                        //crossedOut[1] = crossedOut[1] + increaseNumberForCrossedOutColumn;

                                        //int currentIndexY = indexYToMark[0];
                                        //coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                        //coordinateXYToMark[currentIndexY, 1] = columnIndex;
                                        //indexYToMark[0] = currentIndexY + increaseIndexXY;

                                        //listCheckerSlash.Insert(0, checker);


                                        if (isPreviousSymbolBelongToTeam == false)
                                        {
                                            matchingSymbol[0] = boardToCheck[rowIndex, columnIndex];
                                            numberOfMatchingSymbols[0] = increaseNumberForMatchingSymbol;

                                            crossedOut[0] = rowIndex + increaseNumberForCrossedOutRww;
                                            crossedOut[1] = columnIndex + increaseNumberForCrossedOutColumn;

                                        //coordinateXYToMark[0, 0] = rowIndex;
                                        //coordinateXYToMark[0, 1] = columnIndex;
                                        //indexYToMark[0] = 1;

                                        int currentIndexY = indexYToMark[0];
                                            coordinateXYToMark[0, 0] = rowIndex;
                                            coordinateXYToMark[0, 1] = columnIndex;
                                            indexYToMark[0] = currentIndexY;

                                            listCheckerSlash.Insert(0, checker);



                                        }
                                        else
                                        {
                                            numberOfMatchingSymbols[0] = numberOfMatchingSymbols[0] + increaseNumberForMatchingSymbol;

                                            crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                            crossedOut[1] = crossedOut[1] + increaseNumberForCrossedOutColumn;

                                            int currentIndexY = indexYToMark[0];
                                            coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                            coordinateXYToMark[currentIndexY, 1] = columnIndex;
                                            indexYToMark[0] = currentIndexY + increaseIndexXY;

                                            listCheckerSlash.Insert(0, checker);


                                        }


                                    }
                                    else if (numberOfMatchingSymbols[0] == lenghtToCheck)
                                    {
                                        checker = true;

                                        int currentIndexY = indexYToMark[0];
                                        coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                        coordinateXYToMark[currentIndexY, 1] = columnIndex;

                                        listCheckerSlash.Insert(0, checker);
                                        listCheckerSlash.Insert(1, coordinateXYToMark);

                                        string kindOfChecker = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerSlash();
                                        listCheckerSlash.Insert(2, kindOfChecker);
                                    }












                                }

                                if (isMatchingArrayIncreased == false)
                                {



                                    if ((boardColumnLength - columnIndex) < lenghtToCheck)
                                    {
                                        if ((boardRowLength - rowIndex) < lenghtToCheck)
                                        {
                                            checker = false;
                                            listCheckerSlash.Insert(0, checker);
                                            return listCheckerSlash;
                                        }

                                    }
                                    else if ((boardColumnLength - lenghtToCheck) < lenghtToCheck)
                                    {
                                        checker = false;
                                        listCheckerSlash.Insert(0, checker);
                                        return listCheckerSlash;

                                    }











                                }


















                            //}
                            //else if (matchingSymbol[0] != boardToCheck[rowIndex, columnIndex])
                            //{
                            //    if ((boardColumnLength - columnIndex) < lenghtToCheck)
                            //    {
                            //        if ((boardRowLength - rowIndex) < lenghtToCheck)
                            //        {
                            //            checker = false;
                            //            listCheckerSlash.Insert(0, checker);
                            //            return listCheckerSlash;
                            //        }

                            //    }
                            //    else if ((boardColumnLength - lenghtToCheck) < lenghtToCheck)
                            //    {
                            //        checker = false;
                            //        listCheckerSlash.Insert(0, checker);
                            //        return listCheckerSlash;

                            //    }
                            //}
                        }

                    }
                }        
            }

            return listCheckerSlash;
        }
    }
}
