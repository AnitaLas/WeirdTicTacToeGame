using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;
using Debug = UnityEngine.Debug;
using System.Diagnostics;
using System.Runtime.CompilerServices;



namespace Assets.Scripts
{
    internal class GameTeamFieldsVerificationCheckerHorizontal
    {
        public static ArrayList GameTeamCheckerHorizontal(string[,] boardToCheck, int lenghtToCheck, List<string[]> teamGameSymbols)
        {
            ArrayList listCheckerHorizontal = new ArrayList();

            int boardRowLength = boardToCheck.GetLength(0);
            int boardColumnLength = boardToCheck.GetLength(1);

            int boardMaxRowIndex = boardRowLength - 1;          
            int boardMaxColumnIndex = boardColumnLength - 1;

            bool checker = false;
            int columnIndex;
            int rowIndex;
   
            int teamsNumbers = teamGameSymbols.Count;

            Debug.Log("1 lenghtToCheck" + lenghtToCheck);

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamGameSymbols[i];
                int playersNumber = teamSymbols.Length;

                Debug.Log(" ---------- TEAM SYMBOLS ------------ ");
                for (int zz = 0; zz < teamSymbols.Length; zz++)
                {
                    Debug.Log($"teamSymbols[{zz}]: " + teamSymbols[zz]);
                }

                Debug.Log(" ---------- TEAM SYMBOLS ------------ ");


                //Debug.Log(" ----------------------- ");
                //// check string
                string[] checkArray = new string[1];
                checkArray[0] = "";

                
                // count matching
                int[] matchingArray = new int[1];
                //?
                //matchingArray[0] = 0;
                //

                Debug.Log("0 matchingArray[0]: " + matchingArray[0]);
                Debug.Log(" --------------------------------------------------------------------- "); 
                Debug.Log(" --------------------------------------------------------------------- ");

                int[,] coordinateXYToMark = new int[lenghtToCheck + 1, 2];
                int[] indexYToMark = new int[1];
                int increaseIndexXY = 1;

                //Debug.Log(" ------------------------------------------------------------- ");


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
                        else //if (checkArray[0] != "")
                        {

                            bool isMatchingArrayIncreased = false;

                            string currentSymbolToCheck = checkArray[0];
                            //Debug.Log("1 checkArray[0]" + checkArray[0]);
                            //Debug.Log("1 matchingArray[0]: " + matchingArray[0]);
                            //Debug.Log("--------");



                            string matchedSymbol = "";

                            for (int z = 0; z < playersNumber; z++)
                            {
                                string teamSymbol = teamSymbols[z];

                                //if (teamSymbol != currentSymbolToCheck && isMatchingArrayIncreased == false)
                                //{

                                    if (teamSymbol.Equals(boardToCheck[rowIndex, columnIndex]))
                                    {
                                        matchedSymbol = teamSymbol;
                                        //Debug.Log("2 matchedSymbol: " + matchedSymbol);

                                        isMatchingArrayIncreased = true;
                                        break;
                                    }

                                //}

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


                            Debug.Log($" 3  ----------------------- ");
                            Debug.Log("3 !!! checkArray[0]: " + checkArray[0]);
                            Debug.Log($"3 !!! boardToCheck[{rowIndex}, {columnIndex}]: " + boardToCheck[rowIndex, columnIndex]);
                            Debug.Log("3 !!! isMatchingArrayIncreased: " + isMatchingArrayIncreased);
                            Debug.Log("3 !!! isPreviousSymbolBelongToTeam: " + isPreviousSymbolBelongToTeam);
                            Debug.Log($" 3  ----------------------- ");
                            //}

                            //Debug.Log("1 isMatchingArrayIncreased: " + isMatchingArrayIncreased);

                            if (isMatchingArrayIncreased == true)
                            {
                                Debug.Log("3 TRUE !!! isMatchingArrayIncreased: " + isMatchingArrayIncreased);
                                //Debug.Log("3 TRUE checkArray[0]: " + checkArray[0]);
                                //Debug.Log("3 TRUE matchedSymbol" + matchedSymbol);
                                //Debug.Log("3 TRUE matchingArray[0]: " + matchingArray[0]);



                                if (matchingArray[0] < lenghtToCheck)
                                {



                                    Debug.Log("3 matchingArray[0] < lenghtToCheck ---------------------- ");


                                    //  o for first element

                                    if (isPreviousSymbolBelongToTeam == false)
                                    {
                                        Debug.Log("3 A isPreviousSymbolBelongToTeam == FALSE ");
                                        checkArray[0] = boardToCheck[rowIndex, columnIndex];
                                        //matchingArray[0] = 1;
                                        matchingArray[0] = 1;
                                        Debug.Log("3 A checkArray[0]: " + checkArray[0]);
                                        Debug.Log("3 A matchingArray[0]: " + matchingArray[0]);
                                        
                                        
                                        indexYToMark[0] = 1;
                                        coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                                        coordinateXYToMark[0, 0] = rowIndex;
                                        coordinateXYToMark[0, 1] = columnIndex;

                                        listCheckerHorizontal.Insert(0, checker);
                                    }
                                    else
                                    {
                                        Debug.Log("3 B isPreviousSymbolBelongToTeam == TRUE ");
                                        matchingArray[0] = matchingArray[0] + 1;
                                        //Debug.Log("3 TRUE Ab if-> matchingArray[0]: " + matchingArray[0]);

                                        checkArray[0] = boardToCheck[rowIndex, columnIndex];

                                        Debug.Log("3 B checkArray[0]: " + checkArray[0]);
                                        Debug.Log("3 B matchingArray[0]: " + matchingArray[0]);

                                        int currentIndexY = indexYToMark[0];
                                        coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                        coordinateXYToMark[currentIndexY, 1] = columnIndex;
                                        indexYToMark[0] = currentIndexY + increaseIndexXY;
                                    }

                                    //matchingArray[0] = matchingArray[0] + 1;
                                    //Debug.Log("3 TRUE Ab if-> matchingArray[0]: " + matchingArray[0]);

                                    //checkArray[0] = boardToCheck[rowIndex, columnIndex];

                                    //int currentIndexY = indexYToMark[0];
                                    //coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                    //coordinateXYToMark[currentIndexY, 1] = columnIndex;
                                    //indexYToMark[0] = currentIndexY + increaseIndexXY;





                                }
                                else if (matchingArray[0] == lenghtToCheck)
                                {
                                    Debug.Log("3 TRUE WIN ------------------------");
                                    Debug.Log("3 TRUE -> matchingArray[0]: " + matchingArray[0]);
                                    checker = true;

                                    int currentIndexY = indexYToMark[0];
                                    coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                    coordinateXYToMark[currentIndexY, 1] = columnIndex;

                                    listCheckerHorizontal.Insert(0, checker);
                                    listCheckerHorizontal.Insert(1, coordinateXYToMark);

                                    string kindOfChecker = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerHorizontal();
                                    listCheckerHorizontal.Insert(2, kindOfChecker);

                                    return listCheckerHorizontal;
                                }
                            }


                            if (isMatchingArrayIncreased == false)
                            {

                                if ((boardMaxColumnIndex - columnIndex) >= lenghtToCheck)
                                {
                                    checkArray[0] = boardToCheck[rowIndex, columnIndex];
                                    matchingArray[0] = 1;
                                    //matchingArray[0] = 0;

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

                            //Debug.Log("FALSE END checkArray[0]: " + checkArray[0]);
                            //}

                        }










                    }






                }









                //---------------------------------------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------

                //for (rowIndex = 0; rowIndex <= boardMaxRowIndex; rowIndex++)
                //{
                //    checkArray[0] = "";

                //    for (columnIndex = 0; columnIndex <= boardMaxColumnIndex; columnIndex++)
                //    {
                //        if (checkArray[0].Equals(""))
                //        {
                //            checkArray[0] = boardToCheck[rowIndex, columnIndex];
                //            matchingArray[0] = 1;

                //            coordinateXYToMark[0, 0] = rowIndex;
                //            coordinateXYToMark[0, 1] = columnIndex;
                //            indexYToMark[0] = 1;

                //            listCheckerHorizontal.Insert(0, checker);
                //        }
                //        else if (checkArray[0].Equals(boardToCheck[rowIndex, columnIndex]))
                //        {
                //            //Debug.Log("2 - EQUALS checkArray[0]: " + checkArray[0]);

                //            if (matchingArray[0] < lenghtToCheck)
                //            {
                //                checkArray[0] = boardToCheck[rowIndex, columnIndex];
                //                matchingArray[0] = matchingArray[0] + 1;

                //                int currentIndexY = indexYToMark[0];
                //                coordinateXYToMark[currentIndexY, 0] = rowIndex;
                //                coordinateXYToMark[currentIndexY, 1] = columnIndex;
                //                indexYToMark[0] = currentIndexY + increaseIndexXY;

                //                listCheckerHorizontal.Insert(0, checker);




                //            }
                //            else if (matchingArray[0] == lenghtToCheck)
                //            {
                //                checker = true;

                //                int currentIndexY = indexYToMark[0];
                //                coordinateXYToMark[currentIndexY, 0] = rowIndex;
                //                coordinateXYToMark[currentIndexY, 1] = columnIndex;

                //                listCheckerHorizontal.Insert(0, checker);
                //                listCheckerHorizontal.Insert(1, coordinateXYToMark);

                //                string kindOfChecker = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerHorizontal();
                //                listCheckerHorizontal.Insert(2, kindOfChecker);

                //                return listCheckerHorizontal;
                //            }
                //        }
                //        else if (checkArray[0] != boardToCheck[rowIndex, columnIndex])
                //        {

                //            bool isMatchingArrayIncreased = false;

                //            string currentSymbolToCheck = checkArray[0];
                //            //Debug.Log("1 checkArray[0]" + checkArray[0]);
                //            //Debug.Log("1 matchingArray[0]: " + matchingArray[0]);
                //            //Debug.Log("--------");



                //            string matchedSymbol = "";

                //            for (int z = 0; z < playersNumber; z++)
                //            {
                //                string teamSymbol = teamSymbols[z];

                //                if (teamSymbol != currentSymbolToCheck && isMatchingArrayIncreased == false)
                //                {

                //                    if (teamSymbol.Equals(boardToCheck[rowIndex, columnIndex]))
                //                    {
                //                        matchedSymbol = teamSymbol;
                //                        //Debug.Log("2 matchedSymbol: " + matchedSymbol);

                //                        isMatchingArrayIncreased = true;
                //                        break;
                //                    }

                //                }

                //            }


                //            bool isPreviousSymbolBelongToTeam = false;

                //            for (int z = 0; z < playersNumber; z++)
                //            {
                //                string teamSymbol = teamSymbols[z];

                //                    if (teamSymbol.Equals(currentSymbolToCheck))
                //                    {
                //                        isPreviousSymbolBelongToTeam = true;
                //                        break;
                //                    }

                //            }


                //            // Debug.Log($" 2 - Team symbols ----------------------- ");
                //            //}

                //            //Debug.Log("1 isMatchingArrayIncreased: " + isMatchingArrayIncreased);

                //            if (isMatchingArrayIncreased == true)
                //            {
                //                Debug.Log("3 TRUE !!! isMatchingArrayIncreased: " + isMatchingArrayIncreased);
                //                Debug.Log("3 TRUE checkArray[0]: " + checkArray[0]);
                //                //Debug.Log("3 TRUE matchedSymbol" + matchedSymbol);
                //                Debug.Log("3 TRUE matchingArray[0]: " + matchingArray[0]);



                //                if (matchingArray[0] < lenghtToCheck)
                //                {



                //                        Debug.Log("3 matchingArray[0] < lenghtToCheck ---------------------- ");
                //                        Debug.Log("3 TRUE Aa checkArray[0]: " + checkArray[0]);
                //                        Debug.Log("3 TRUE Aa if-> matchingArray[0]: " + matchingArray[0]);

                //                    //  o for first element

                //                    if (isPreviousSymbolBelongToTeam == false)
                //                    {
                //                        Debug.Log("3 isPreviousSymbolBelongToTeam == false ");
                //                        checkArray[0] = boardToCheck[rowIndex, columnIndex];
                //                        //matchingArray[0] = 1;
                //                        matchingArray[0] = 1;

                //                        indexYToMark[0] = 1;
                //                        coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                //                        coordinateXYToMark[0, 0] = rowIndex;
                //                        coordinateXYToMark[0, 1] = columnIndex;

                //                        listCheckerHorizontal.Insert(0, checker);
                //                    }
                //                    else
                //                    {
                //                        Debug.Log("3 isPreviousSymbolBelongToTeam == true ");
                //                        matchingArray[0] = matchingArray[0] + 1;
                //                        //Debug.Log("3 TRUE Ab if-> matchingArray[0]: " + matchingArray[0]);

                //                        checkArray[0] = boardToCheck[rowIndex, columnIndex];

                //                        int currentIndexY = indexYToMark[0];
                //                        coordinateXYToMark[currentIndexY, 0] = rowIndex;
                //                        coordinateXYToMark[currentIndexY, 1] = columnIndex;
                //                        indexYToMark[0] = currentIndexY + increaseIndexXY;
                //                    }

                //                        //matchingArray[0] = matchingArray[0] + 1;
                //                        //Debug.Log("3 TRUE Ab if-> matchingArray[0]: " + matchingArray[0]);

                //                        //checkArray[0] = boardToCheck[rowIndex, columnIndex];

                //                        //int currentIndexY = indexYToMark[0];
                //                        //coordinateXYToMark[currentIndexY, 0] = rowIndex;
                //                        //coordinateXYToMark[currentIndexY, 1] = columnIndex;
                //                        //indexYToMark[0] = currentIndexY + increaseIndexXY;





                //                    }
                //                    else if (matchingArray[0] == lenghtToCheck)
                //                    {
                //                        Debug.Log("3 TRUE WIN ------------------------");
                //                        Debug.Log("3 TRUE -> matchingArray[0]: " + matchingArray[0]);
                //                        checker = true;

                //                        int currentIndexY = indexYToMark[0];
                //                        coordinateXYToMark[currentIndexY, 0] = rowIndex;
                //                        coordinateXYToMark[currentIndexY, 1] = columnIndex;

                //                        listCheckerHorizontal.Insert(0, checker);
                //                        listCheckerHorizontal.Insert(1, coordinateXYToMark);

                //                        string kindOfChecker = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerHorizontal();
                //                        listCheckerHorizontal.Insert(2, kindOfChecker);

                //                        return listCheckerHorizontal;
                //                    }
                //            }


                //            if (isMatchingArrayIncreased == false)
                //            {                              

                //                if ((boardMaxColumnIndex - columnIndex) >= lenghtToCheck)
                //                {
                //                    checkArray[0] = boardToCheck[rowIndex, columnIndex];
                //                    matchingArray[0] = 1;
                //                    //matchingArray[0] = 0;

                //                    indexYToMark[0] = 1;
                //                    coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                //                    coordinateXYToMark[0, 0] = rowIndex;
                //                    coordinateXYToMark[0, 1] = columnIndex;
                //                }
                //                else if ((boardMaxColumnIndex - columnIndex) < lenghtToCheck)
                //                {
                //                    if (rowIndex == boardMaxRowIndex)
                //                    {
                //                        checker = false;
                //                        listCheckerHorizontal.Insert(0, checker);

                //                        return listCheckerHorizontal;
                //                    }
                //                    else if (rowIndex < boardMaxRowIndex)
                //                    {
                //                        checkArray[0] = "";
                //                        matchingArray[0] = 0;
                //                        indexYToMark[0] = 0;
                //                        coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                //                    }
                //                }

                //            }

                //                //Debug.Log("FALSE END checkArray[0]: " + checkArray[0]);
                //            //}

                //        }










                //    }






                //}




                //checkArray[0] = "";
                //matchingArray[0] = 0;
                // indexYToMark[0] = 0;
                //coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];


            }

            Debug.Log(" ------------------------------------------------------------- ");
            return listCheckerHorizontal;
        }
    }
}
