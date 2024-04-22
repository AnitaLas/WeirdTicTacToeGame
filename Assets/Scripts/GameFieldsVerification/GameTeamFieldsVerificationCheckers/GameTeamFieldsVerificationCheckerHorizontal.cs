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

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamGameSymbols[i];

                int playersNumber = teamSymbols.Length;


                //for (int z = 0; z < playersNumber; z++)
                //{
                    //// check string
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

                                    string kindOfChecker = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerHorizontal();
                                    listCheckerHorizontal.Insert(2, kindOfChecker);

                                    return listCheckerHorizontal;
                            }
                        }
                        else if (checkArray[0] != boardToCheck[rowIndex, columnIndex])
                        {
                            // to do - changes her - maybe?  xD 
                            Debug.Log(" --- 1 ---- ");

                            

                            string currentSymbolToCheck = checkArray[0];

                            bool isMatchingArrayIncreased = false;

                            //Debug.Log(" START --- 2 ---- ");
                            for (int z = 0; z < playersNumber; z++)
                            {
                                

                                string teamSymbol = teamSymbols[z];
                                

                                if (teamSymbol != currentSymbolToCheck && isMatchingArrayIncreased == false)
                                {
                                    //Debug.Log(" START --- 3 ---- ");

                                    Debug.Log(" teamSymbol: " + teamSymbol);
                                    Debug.Log(" checkArray[0]: " + checkArray[0]);
                                    Debug.Log("isMatchingArrayIncreased: " + isMatchingArrayIncreased);

                                    if (teamSymbol.Equals(boardToCheck[rowIndex, columnIndex]))
                                    {
                                        //Debug.Log(" START --- 4 ---- ");
                                        //checkArray[0] = teamSymbol;

                                        matchingArray[0] = matchingArray[0] + 1;

                                        int currentIndexY = indexYToMark[0];
                                        coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                        coordinateXYToMark[currentIndexY, 1] = columnIndex;
                                        indexYToMark[0] = currentIndexY + increaseIndexXY;

                                        listCheckerHorizontal.Insert(0, checker);
                                        isMatchingArrayIncreased = true;
                                        //Debug.Log(" - 4 - isMatchingArrayIncreased: " + isMatchingArrayIncreased);

                                        //Debug.Log(" END --- 4 ---- ");
                                        //break;
                                    }
                                    else
                                    {
                                        //isMatchingArrayIncreased = false;
                                        //Debug.Log(" - 4 - isMatchingArrayIncreased: " + isMatchingArrayIncreased);

                                    }
                                    break;

                                    //Debug.Log(" END --- 4 ---- ");
                                }



                               

                            }
                            //Debug.Log(" END --- 2 ---- ");


                            if (isMatchingArrayIncreased == false)
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

                                //checkArray[0] = boardToCheck[rowIndex, columnIndex];
                                //matchingArray[0] = 1;

                                //indexYToMark[0] = 1;
                                //coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                                //coordinateXYToMark[0, 0] = rowIndex;
                                //coordinateXYToMark[0, 1] = columnIndex;
                            }








                        }
                        
                    }










                }


               



            }



            return listCheckerHorizontal;
        }
    }
}
