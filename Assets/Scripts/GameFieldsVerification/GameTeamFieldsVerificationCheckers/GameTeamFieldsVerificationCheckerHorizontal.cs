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

            for (int teamNumber = 0; teamNumber < teamsNumbers; teamNumber++)
            {
                string[] teamSymbols = teamGameSymbols[teamNumber];
                int playersNumber = teamSymbols.Length;

                string[] checkArray = new string[1];
                checkArray[0] = "";

                int[] matchingArray = new int[1];

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
                        else
                        {
                            bool isMatchingArrayIncreased = false;

                            string currentSymbolToCheck = checkArray[0];

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
                                if (matchingArray[0] < lenghtToCheck)
                                {
                                    if (isPreviousSymbolBelongToTeam == false)
                                    {
                                        checkArray[0] = boardToCheck[rowIndex, columnIndex];
                                        matchingArray[0] = 1;

                                        indexYToMark[0] = 1;
                                        coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                                        coordinateXYToMark[0, 0] = rowIndex;
                                        coordinateXYToMark[0, 1] = columnIndex;

                                        listCheckerHorizontal.Insert(0, checker);
                                    }
                                    else
                                    {
                                        checkArray[0] = boardToCheck[rowIndex, columnIndex];
                                        matchingArray[0] = matchingArray[0] + 1;

                                        int currentIndexY = indexYToMark[0];
                                        coordinateXYToMark[currentIndexY, 0] = rowIndex;
                                        coordinateXYToMark[currentIndexY, 1] = columnIndex;
                                        indexYToMark[0] = currentIndexY + increaseIndexXY;
                                    }
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

                            if (isMatchingArrayIncreased == false)
                            {
                                checkArray[0] = boardToCheck[rowIndex, columnIndex];
                                matchingArray[0] = 1;

                                indexYToMark[0] = 1;
                                coordinateXYToMark = new int[lenghtToCheck + 1, lenghtToCheck + 1];
                                coordinateXYToMark[0, 0] = rowIndex;
                                coordinateXYToMark[0, 1] = columnIndex;

                                listCheckerHorizontal.Insert(0, checker);
                            }
                        }
                    }
                }
            }

            return listCheckerHorizontal;
        }
    }
}