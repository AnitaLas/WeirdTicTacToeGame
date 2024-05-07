using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

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
                        int[,] winnerCoordinateXYForCubePlay = (int[,])listCheckerSlash[1];

                        //for (int aaai = 0; aaai < winnerCoordinateXYForCubePlay.GetLength(0); aaai++)
                        //{
                        //    for (int z = 0; z < winnerCoordinateXYForCubePlay.GetLength(1); z++)
                        //    {
                        //        UnityEngine.Debug.Log($"coordinateXYToMark: [{aaai}, {z}] = " + winnerCoordinateXYForCubePlay[aaai, z]);
                        //    }
                        //}

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

            //string kindOfChecker = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerSlash();


            int teamsNumbers = teamGameSymbols.Count;

            //UnityEngine.Debug.Log(" Test");

            for (int teamNumber = 0; teamNumber < teamsNumbers; teamNumber++)
            {
                string[] teamSymbols = teamGameSymbols[teamNumber];
                int playersNumber = teamSymbols.Length;


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

            //int teamsNumbers = teamGameSymbols.Count;

            ////UnityEngine.Debug.Log(" Test");

            //for (int i = 0; i < teamsNumbers; i++)
            //{
            //    string[] teamSymbols = teamGameSymbols[i];
            //    int playersNumber = teamSymbols.Length;

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
                        else //if (rowIndex == crossedOut[0] && columnIndex == crossedOut[1])
                        {

                            //if (matchingSymbol[0].Equals(boardToCheck[rowIndex, columnIndex]))
                            //{
                            if (rowIndex == crossedOut[0] && columnIndex == crossedOut[1])
                            {
                                //Debug.Log($"rowIndex: {rowIndex}, columnIndex: {columnIndex}");
                                //UnityEngine.Debug.Log($"S boardToCheck[{rowIndex}, {columnIndex}]: " + boardToCheck[rowIndex, columnIndex]);

                                bool isMatchingArrayIncreased = false;
                                string currentSymbolToCheck = matchingSymbol[0];




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



                             //Debug.Log("1 isMatchingArrayIncreased: " + isMatchingArrayIncreased);
                             //Debug.Log("1 isPreviousSymbolBelongToTeam: " + isPreviousSymbolBelongToTeam);
                                //Debug.Log("3 matchingSymbol[0]: " + matchingSymbol[0]);

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

                                            crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                            crossedOut[1] = crossedOut[1] + increaseNumberForCrossedOutColumn;

                                            //int currentIndexY = indexYToMark[0];
                                            //coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                            //coordinateXYToMark[currentIndexY, 1] = columnIndex;
                                            //indexYToMark[0] = currentIndexY + increaseIndexXY;


                                            indexYToMark[0] = 1;
                                            coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                                            coordinateXYToMark[0, 0] = rowIndex;
                                            coordinateXYToMark[0, 1] = columnIndex;


                                            listCheckerSlash.Insert(0, checker);
                                            //listCheckerSlash.Insert(1, coordinateXYToMark);
                                            //listCheckerSlash.Insert(2, kindOfChecker);

                                        }
                                        else 
                                        {
                                            matchingSymbol[0] = boardToCheck[rowIndex, columnIndex];
                                            numberOfMatchingSymbols[0] = numberOfMatchingSymbols[0] + increaseNumberForMatchingSymbol;
                                           
                                            //Debug.Log("4 numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                                            //Debug.Log("4 matchingSymbol[0]: " + matchingSymbol[0]);
                                            crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                            crossedOut[1] = crossedOut[1] + increaseNumberForCrossedOutColumn;

                                            int currentIndexY = indexYToMark[0];
                                            coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                            coordinateXYToMark[currentIndexY, 1] = columnIndex;
                                            indexYToMark[0] = currentIndexY + increaseIndexXY;

                                            //listCheckerSlash.Insert(0, checker);


                                        }


                                    }
                                    else if (numberOfMatchingSymbols[0] == lenghtToCheck)
                                    {

                                        //Debug.Log(" WINNER xD");
                                        checker = true;

                                        int currentIndexY = indexYToMark[0];
                                        coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                        coordinateXYToMark[currentIndexY, 1] = columnIndex;

                                        listCheckerSlash.Insert(0, checker);

                                        //for (int aaai = 0; aaai < coordinateXYToMark.GetLength(0); aaai++)
                                        //{
                                        //    for (int z = 0; z < coordinateXYToMark.GetLength(1); z++)
                                        //    {
                                        //        UnityEngine.Debug.Log($"coordinateXYToMark: [{aaai}, {z}] = " + coordinateXYToMark[aaai, z]);

                                        //        UnityEngine.Debug.Log($"TYPE _ = " + coordinateXYToMark[aaai, z].GetType());


                                        //    }
                                        //}

                                        listCheckerSlash.Insert(1, coordinateXYToMark);



                                        string kindOfChecker = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerSlash();
                                        listCheckerSlash.Insert(2, kindOfChecker);

                                        teamNumber = teamsNumbers + 13;

                                        //int[,] winnerCoordinateXYForCubePlay = (int[,])listCheckerSlash[1];

                                        //    for (int aaai = 0; aaai < winnerCoordinateXYForCubePlay.GetLength(0); aaai++)
                                        //    {
                                        //        for (int z = 0; z < winnerCoordinateXYForCubePlay.GetLength(1); z++)
                                        //        {
                                        //            UnityEngine.Debug.Log($"winnerCoordinateXYForCubePlay: [{aaai}, {z}] = " + winnerCoordinateXYForCubePlay[aaai, z]);

                                        //            //UnityEngine.Debug.Log($"TYPE _ = " + coordinateXYToMark[aaai, z].GetType());


                                        //        }
                                        //    }
                                        //break;
                                    }

                                }

                                if (isMatchingArrayIncreased == false)
                                {

                                    matchingSymbol[0] = boardToCheck[rowIndex, columnIndex];
                                    numberOfMatchingSymbols[0] = increaseNumberForMatchingSymbol;

                                    crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                    crossedOut[1] = crossedOut[1] + increaseNumberForCrossedOutColumn;

                                    indexYToMark[0] = 1;
                                    coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                                    coordinateXYToMark[0, 0] = rowIndex;
                                    coordinateXYToMark[0, 1] = columnIndex;


                                    listCheckerSlash.Insert(0, checker);
                                    //listCheckerSlash.Insert(1, coordinateXYToMark);
                                    //listCheckerSlash.Insert(2, kindOfChecker);
                                    //if ((boardColumnLength - columnIndex) < lenghtToCheck)
                                    //{
                                    //    if ((boardRowLength - rowIndex) < lenghtToCheck)
                                    //    {
                                    //        checker = false;
                                    //        listCheckerSlash.Insert(0, checker);
                                    //        return listCheckerSlash;
                                    //    }

                                    //}
                                    //else if ((boardColumnLength - lenghtToCheck) < lenghtToCheck)
                                    //{
                                    //    checker = false;
                                    //    listCheckerSlash.Insert(0, checker);
                                    //    return listCheckerSlash;

                                    //}










                                }


                            }


                            //int[,] winnerCoordinateXYForCubePlay6 = (int[,])listCheckerSlash[1];


                        }
                        //Debug.Log("----------");

                        //int[,] winnerCoordinateXYForCubePlay5 = (int[,])listCheckerSlash[1];

                    }

                   // Debug.Log("----------");
                    // int[,] winnerCoordinateXYForCubePlay4 = (int[,])listCheckerSlash[1];

                }


                //Debug.Log("----------");
                //int[,] winnerCoordinateXYForCubePlay3 = (int[,])listCheckerSlash[1];

            }
            //Debug.Log( "----------" );

            //for (int al = 0; al < listCheckerSlash.Count; al++)
            //{
            //    Debug.Log("al TYPE " + al + ", type: " + al.GetType());
            //}


            //int[,] winnerCoordinateXYForCubePlay3 = (int[,])listCheckerSlash[1];
            //for (int aaai = 0; aaai < winnerCoordinateXYForCubePlay.GetLength(0); aaai++)
            //{
            //    for (int z = 0; z < winnerCoordinateXYForCubePlay.GetLength(1); z++)
            //    {
            //        UnityEngine.Debug.Log($"coordinateXYToMark: [{aaai}, {z}] = " + winnerCoordinateXYForCubePlay[aaai, z]);
            //    }
            //}

            return listCheckerSlash;
        }
    }
}
