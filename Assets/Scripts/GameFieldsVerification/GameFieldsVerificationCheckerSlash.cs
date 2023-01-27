using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerificationCheckerSlash
    {

        public static bool CheckerSlash(string[,] boardToCheck, int lenghtToCheck)
        {
            int boardRowLength = boardToCheck.GetLength(0) - 1;
            int boardColumnLength = boardToCheck.GetLength(1) - 1;

            int nextRowIndexToCheck;
            int nextColumnIndexToCheck;

            bool checker = false;

            for (nextRowIndexToCheck = 0; nextRowIndexToCheck < boardRowLength; nextRowIndexToCheck++)
            {

                for (nextColumnIndexToCheck = 0; nextColumnIndexToCheck < boardColumnLength; nextColumnIndexToCheck++)
                {
                    //
                    checker = CheckerFromLeftBottomToRightTopForOne(boardToCheck, nextRowIndexToCheck, nextColumnIndexToCheck, lenghtToCheck);

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
                }
            }

            return checker;

        }


        //
        public static bool CheckerFromLeftBottomToRightTopForOne(string[,] boardToCheck, int startRowIndexToCheck, int startColumnIndexToCheck, int lenghtToCheck)
        {
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

            for (rowIndex = startRowIndex; rowIndex <= boardRowLength; rowIndex++)
            {

                for (columnIndex = startColumnIndex; columnIndex <= boardColumnLength; columnIndex++)
                {

                    Debug.Log("0 checkArray[0]: " + matchingSymbol[0]);
                    Debug.Log("0 numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                    Debug.Log("0 crossedOut[0]: " + crossedOut[0]);
                    Debug.Log("0 crossedOut[1]: " + crossedOut[1]);
                    Debug.Log("0 startRowIndex: " + startRowIndex);
                    Debug.Log("0 startColumnIndex: " + startColumnIndex);
                    Debug.Log("0 ------------------------------------------------------------------ ");

                    if (matchingSymbol[0].Equals(""))
                    {
                        Debug.Log(" 1                    if (checkArray[0].Equals(\"\"))");
                        matchingSymbol[0] = boardToCheck[rowIndex, columnIndex];
                        numberOfMatchingSymbols[0] = increaseNumberForMatchingSymbol;
                        crossedOut[0] = rowIndex + increaseNumberForCrossedOutRww;
                        crossedOut[1] = columnIndex + increaseNumberForCrossedOutColumn;

                        Debug.Log("1 checkArray[0]: " + matchingSymbol[0]);
                        Debug.Log("1 numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                        Debug.Log("1 crossedOut[0]: " + crossedOut[0]);
                        Debug.Log("1 crossedOut[1]: " + crossedOut[1]);
                        Debug.Log("1 ------------------------------------------------");

                    }
                    else if (rowIndex == crossedOut[0] && columnIndex == crossedOut[1])
                    {
                        Debug.Log(" 2        else if (rowIndex == crossedOut[0] && columnIndex == crossedOut[1])");
                        Debug.Log("2 checkArray[0]: " + matchingSymbol[0]);
                        Debug.Log("2 numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                        Debug.Log("2 crossedOut[0]: " + crossedOut[0]);
                        Debug.Log("2 rowIndex: " + rowIndex);
                        Debug.Log("2 crossedOut[1]: " + crossedOut[1]);
                        Debug.Log("2 columnIndex: " + columnIndex);
                        Debug.Log("2 ------------------------------------------------");


                        if (matchingSymbol[0].Equals(boardToCheck[rowIndex, columnIndex]))
                        {

                            Debug.Log(" 3   if (checkArray[0].Equals(boardToCheck[rowIndex, columnIndex]))");
                            Debug.Log($"3 boardToCheck[{rowIndex}, {columnIndex}]: " + boardToCheck[rowIndex, columnIndex]);
                            Debug.Log("3 checkArray[0]: " + matchingSymbol[0]);
                            Debug.Log("3 lenghtToCheck " + lenghtToCheck);
                            Debug.Log("3 ------------------------------------------------");

                            if (numberOfMatchingSymbols[0] < lenghtToCheck)
                            {
                                Debug.Log(" 4          if (numberOfMatchingSymbols[0] < lenghtToCheck)");
                                Debug.Log("4 checkArray[0]: " + matchingSymbol[0]);
                                Debug.Log("4 lenghtToCheck " + lenghtToCheck);
                                Debug.Log("2 checkArray[0]: " + matchingSymbol[0]);
                                Debug.Log("2 numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                                Debug.Log("2 crossedOut[0]: " + crossedOut[0]);
                                Debug.Log("2 crossedOut[1]: " + crossedOut[1]);
                                Debug.Log("4 --------------------------------");
                                numberOfMatchingSymbols[0] = numberOfMatchingSymbols[0] + increaseNumberForMatchingSymbol;
                                crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                crossedOut[1] = crossedOut[1] + increaseNumberForCrossedOutColumn;

                                Debug.Log("4 checkArray[0]: " + matchingSymbol[0]);
                                Debug.Log("4 numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                                Debug.Log("4 crossedOut[0]: " + crossedOut[0]);
                                Debug.Log("4 crossedOut[1]: " + crossedOut[1]);
                                Debug.Log("4 ------------------------------------------------");


                            }
                            else if (numberOfMatchingSymbols[0] == lenghtToCheck)
                            {
                                Debug.Log(" 5 ");
                                checker = true;
                                return checker;

                            }
                        }
                        else if (matchingSymbol[0] != boardToCheck[rowIndex, columnIndex])
                        {
                            Debug.Log(" 6 ");
                            Debug.Log("6 ------------------------------------------------");

                            if ((boardColumnLength - columnIndex) < lenghtToCheck)
                            {
                                Debug.Log(" 7  if ((boardColumnLength - columnIndex) < lenghtToCheck)");
                                Debug.Log("7 boardColumnLength =  " + boardColumnLength);
                                Debug.Log("7 columnIndex =  " + columnIndex);
                                Debug.Log("7 boardColumnLength - columnIndex = " + (boardColumnLength - columnIndex) + " >  " + lenghtToCheck + " = lenghtToCheck");
                                Debug.Log("8 ------------------------------------------------");

                                if ((boardRowLength - rowIndex) < lenghtToCheck)
                                {
                                    Debug.Log(" 8     if ((boardRowLength - rowIndex) < lenghtToCheck)");
                                    Debug.Log("8 checkArray[0]: " + matchingSymbol[0]);
                                    Debug.Log("8 numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                                    Debug.Log("8 crossedOut[0]: " + crossedOut[0]);
                                    Debug.Log("8 rowIndex: " + rowIndex);
                                    Debug.Log("8 crossedOut[1]: " + crossedOut[1]);
                                    Debug.Log("8 columnIndex: " + columnIndex);
                                    Debug.Log("8 --------------------");

                                    matchingSymbol[0] = matchingSymbol[0];
                                    numberOfMatchingSymbols[0] = numberOfMatchingSymbols[0] + increaseNumberForMatchingSymbol;
                                    crossedOut[0] = crossedOut[0] + increaseNumberForCrossedOutRww;
                                    crossedOut[1] = crossedOut[1] - increaseNumberForCrossedOutColumn;

                                    Debug.Log("8 checkArray[0]: " + matchingSymbol[0]);
                                    Debug.Log("8 numberOfMatchingSymbols[0]: " + numberOfMatchingSymbols[0]);
                                    Debug.Log("8 crossedOut[0]: " + crossedOut[0]);
                                    Debug.Log("8 rowIndex: " + rowIndex);
                                    Debug.Log("8 crossedOut[1]: " + crossedOut[1]);
                                    Debug.Log("8 columnIndex: " + columnIndex);
                                    Debug.Log("8 ------------------------------------------------");
                                    checker = false;
                                    return checker;
                                }

                            }
                            else if ((boardColumnLength - lenghtToCheck) < lenghtToCheck)
                            {
                                Debug.Log(" 9 ");
                                checker = false;
                                return checker;

                            }
                        }
                    }
                }        
            }

            return checker;

        }

    }
}
