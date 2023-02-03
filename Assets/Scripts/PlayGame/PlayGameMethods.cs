using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameMethods
    {

        public static string GetPlayerSymbol(string[] playersSymbols, int currentPlayer)
        {
            string playerSymbol = playersSymbols[currentPlayer];
            return playerSymbol;
        }


        public static void ChangeCoordinateZForCubePlayAfterClickOnTheCubePlay(GameObject cubePlay)
        {
            float newCoordinateZ = 0;
            CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZ);
        }

       public static int[] CreateTableForMoveIndexForFrame(int numberOfRows)
        {
            int[] table = CommonMethods.CreateTableWithGivenLengthAndGivenValue(2, 0);
           // table[0] = -1;
            table[1] = numberOfRows - 1;
            return table;
        }




        public static void ChangeAllCubePlay(GameObject[,,] gameBoard, string _tagCubePlayGameOver)
        {
            GameObject cubePlay;
            float newCoordinateZForAll = 0;

            int lenghtForDepths = gameBoard.GetLength(0);
            int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);


            for (int indexDepth = 0; indexDepth < lenghtForDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < lenghtForRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < lenghtForColumns; indexColumn++)
                    {

                        cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                       
                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForAll);
                        CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameOver);

                    }
                }
            }


        }






        public static void ChangeWinnerCubePlayForCheckerHorizontal(GameObject[,,] gameBoard, int[,] _winnerCoordinateXYForCubePlay, string _tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;

            // gameBoard
            // int lenghtForDepths = gameBoard.GetLength(0);
            //int lenghtForRows = gameBoard.GetLength(1);
            //int lenghtForColumns = gameBoard.GetLength(2);

            // _winnerCoordinateXYForCubePlay
            //int winnerLenghtForRows = _winnerCoordinateXYForCubePlay.GetLength(0);
            int winnerLenghtForColumns = _winnerCoordinateXYForCubePlay.GetLength(1);

            for (int indexColumnsWinner = 0; indexColumnsWinner < winnerLenghtForColumns; indexColumnsWinner++)
            {
                int coordinateYToMark = _winnerCoordinateXYForCubePlay[indexColumnsWinner, 0];
                int coordinateXToMark = _winnerCoordinateXYForCubePlay[indexColumnsWinner, 1];
                Debug.Log("coordinateYToMark = " + coordinateYToMark);
                Debug.Log("coordinateXToMark = " + coordinateXToMark);
                Debug.Log(" ----------------------------------------------- ");

                cubePlay = gameBoard[indexDepth, coordinateYToMark, coordinateXToMark];
                

                CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameWin);

            }

        }

        public static void ChangeOtherCubePlayForCheckerHorizontal(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;
            // string playerSymbol = "x";

            // gameBoard
            //int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);

            // _winnerCoordinateXYForCubePlay
            //int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);
            int winnerLenghtForColumns = winnerCoordinateXYForCubePlay.GetLength(1);

            int coordinateYToMarkOther = winnerCoordinateXYForCubePlay[winnerLenghtForColumns - 1, 0];
            int coordinateXToMarkOther = winnerCoordinateXYForCubePlay[0, 1];


            int startIndexXForOtherCubePlay = coordinateXToMarkOther + 1;
            int maxIndexXForLenghtForColumns = lenghtForColumns - 1;
            int maxIndexXForWinnerLenghtForColumns = winnerLenghtForColumns - 1;

            if (winnerCoordinateXYForCubePlay[0, maxIndexXForWinnerLenghtForColumns] < maxIndexXForLenghtForColumns)
            {
                for (int i = startIndexXForOtherCubePlay; i < lenghtForColumns; i++)
                {
                    cubePlay = gameBoard[indexDepth, coordinateYToMarkOther, i];

                    string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);

                    if (playerSymbol.Equals(symbolToCompare))
                    {
                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                        CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);

                    }
                    else
                    {
                        break;

                    }

                }
            }

        }

        public static void ChangeAllCubePlayForCheckerHorizontal(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin)
        {
            ChangeWinnerCubePlayForCheckerHorizontal(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            ChangeOtherCubePlayForCheckerHorizontal(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
        }








        public static void ChangeWinnerCubePlayForCheckerVertical(GameObject[,,] gameBoard, int[,] _winnerCoordinateXYForCubePlay, string _tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;

            // gameBoard
            // int lenghtForDepths = gameBoard.GetLength(0);
            //int lenghtForRows = gameBoard.GetLength(1);
            //int lenghtForColumns = gameBoard.GetLength(2);

            // _winnerCoordinateXYForCubePlay
            int winnerLenghtForRows = _winnerCoordinateXYForCubePlay.GetLength(0);
            //int winnerLenghtForColumns = _winnerCoordinateXYForCubePlay.GetLength(1);

            for (int indexRowWinner = 0; indexRowWinner < winnerLenghtForRows; indexRowWinner++)
            {
                int coordinateYToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 0];
                int coordinateXToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 1];

                cubePlay = gameBoard[indexDepth, coordinateYToMark, coordinateXToMark];
  
                CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameWin);

            }

            //for (int y = 0; y < _winnerCoordinateXYForCubePlay.GetLength(0) -1 ; y++)
            //{
            //    for (int x = 0; x < _winnerCoordinateXYForCubePlay.GetLength(1) - 1; x++)
            //    {
            //        Debug.Log($"coordinateXYToMark [{y},{x}] = " + _winnerCoordinateXYForCubePlay[y, x]);

            //    }
            //    Debug.Log($"----------------------------------------");
            //}
            //Debug.Log($"---------- ************************************  ------------------------------");

        }

        public static void ChangeOtherCubePlayForCheckerVertical(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;
            // string playerSymbol = "x";

            // gameBoard
            int lenghtForRows = gameBoard.GetLength(1);
            // int lenghtForColumns = gameBoard.GetLength(2);

            // _winnerCoordinateXYForCubePlay
            int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);
            //int winnerLenghtForColumns = _winnerCoordinateXYForCubePlay.GetLength(1);

            int coordinateYToMarkOther = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
            int coordinateXToMarkOther = winnerCoordinateXYForCubePlay[0, 1];


            int startIndexYForOtherCubePlay = coordinateYToMarkOther + 1;
            int maxIndexYForLenghtForRows = lenghtForRows - 1;
            int maxIndexYForWinnerLenghtForRows = winnerLenghtForRows - 1;

            if (winnerCoordinateXYForCubePlay[maxIndexYForWinnerLenghtForRows, 0] < maxIndexYForLenghtForRows)
            {
                for (int i = startIndexYForOtherCubePlay; i < lenghtForRows; i++)
                {
                    cubePlay = gameBoard[indexDepth, i, coordinateXToMarkOther];

                    string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);

                    if (playerSymbol.Equals(symbolToCompare))
                    {
                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                        CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);

                    }
                    else
                    {
                        break;

                    }

                }
            }

        }

        public static void ChangeAllCubePlayForCheckerVertical(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin)
        {
            ChangeWinnerCubePlayForCheckerVertical(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            ChangeOtherCubePlayForCheckerVertical(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
        }






        public static void ChangeWinnerCubePlayForCheckerBackslash(GameObject[,,] gameBoard, int[,] _winnerCoordinateXYForCubePlay, string _tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;

            // gameBoard
            // int lenghtForDepths = gameBoard.GetLength(0);
            //int lenghtForRows = gameBoard.GetLength(1);
            //int lenghtForColumns = gameBoard.GetLength(2);

            // _winnerCoordinateXYForCubePlay
            int winnerLenghtForRows = _winnerCoordinateXYForCubePlay.GetLength(0);
            //int winnerLenghtForColumns = _winnerCoordinateXYForCubePlay.GetLength(1);

            for (int indexRowWinner = 0; indexRowWinner < winnerLenghtForRows; indexRowWinner++)
            {
                int coordinateYToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 0];
                int coordinateXToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 1];

                cubePlay = gameBoard[indexDepth, coordinateYToMark, coordinateXToMark];

                CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameWin);

            }

            //for (int y = 0; y < _winnerCoordinateXYForCubePlay.GetLength(0); y++)
            //{
            //    for (int x = 0; x < _winnerCoordinateXYForCubePlay.GetLength(1); x++)
            //    {
            //        Debug.Log($"coordinateXYToMark [{y},{x}] = " + _winnerCoordinateXYForCubePlay[y, x]);

            //    }
            //    Debug.Log($"----------------------------------------");
            //}
            //Debug.Log($"---------- ************************************  ------------------------------");

        }

        public static void ChangeOtherCubePlayForCheckerBackslash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;
            // string playerSymbol = "x";

            // gameBoard
            int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);

            // _winnerCoordinateXYForCubePlay
            int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);
           // int winnerLenghtForColumns = winnerCoordinateXYForCubePlay.GetLength(1);

            int coordinateYToMarkOther = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
            int coordinateXToMarkOther = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 1];

            int firstIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
            int firstIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];

            int maxIndexXForGameBoard = gameBoard.GetLength(2) - 1;
            int maxIndexYForGameBoard = gameBoard.GetLength(1) - 1;

            int minIndexXToCheck = SetUpMinIndexXForCheckerBackslash(lenghtForRows, lenghtForColumns, firstIndexYForOtherCubePlay, firstIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);
            Debug.Log("minIndexXToCheck = " + minIndexXToCheck);

            int startIndexYForOtherCubePlay = coordinateYToMarkOther;// - 1;
                                                                     // Debug.Log(" startIndexYForOtherCubePlay  = " + startIndexYForOtherCubePlay);
                                                                     //int maxIndexYForLenghtForRows = lenghtForRows - 1;
                                                                     // int maxIndexYForWinnerLenghtForRows = winnerLenghtForRows - 1;

            int startIndexXForOtherCubePlay = coordinateXToMarkOther;// + 1;
            

           // int maxIndexXForLenghtForColumns = lenghtForColumns;
           // Debug.Log(" maxIndexXForLenghtForColumns = " + maxIndexXForLenghtForColumns);

            //int maxIndexXForWinnerLenghtForColumns = winnerLenghtForColumns - 1;
            //Debug.Log(" maxIndexXForWinnerLenghtForColumns = " + maxIndexXForWinnerLenghtForColumns);

            //Debug.Log(" winnerCoordinateXYForCubePlay[maxIndexYForLenghtForRows, 1] " + winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 1]);
            // Debug.Log(" maxIndexXForLenghtForColumns " + lenghtForColumns);
            int y;
            int x;

            // if ((winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0] - 0) < lenghtForColumns)
            //{
            // Debug.Log(" yyyy " );

            int[] newIndexY = new int[1];
            newIndexY[0] = startIndexYForOtherCubePlay;

            int[] newIndexX = new int[1];
            newIndexX[0] = startIndexXForOtherCubePlay;

           // int lowerNumber = CommonMethods.CheckAndReturnLowerNumber(lenghtForRows, lenghtForColumns);

            //int minIndexX = lenghtForColumns - lowerNumber;
            //int minIndexX = lenghtForColumns - firstIndexYForOtherCubePlay;
            //int minIndexX =  firstIndexYForOtherCubePlay + 1;

            //int minIndexX = firstIndexYForOtherCubePlay - 1;
            //   Debug.Log(" lenghtForColumns  = " + (lenghtForColumns - 1));
            //Debug.Log(" startIndexXForOtherCubePlay  = " + (startIndexXForOtherCubePlay + 1));
            //  Debug.Log(" firstIndexYForOtherCubePlay  = " + (firstIndexYForOtherCubePlay - 0));
            //  Debug.Log(" minIndexX  = " + minIndexX);



           






            // for (int i = startIndexXForOtherCubePlay - 1 ; i >= minIndexX; i--)
            //for (int i = startIndexXForOtherCubePlay - 0 ; i > 0; i--)
            // for (int i = startIndexXForOtherCubePlay - 1 ; i >= minIndexX; i--)
            for (int i = startIndexXForOtherCubePlay - 1 ; i >= minIndexXToCheck; i--)
                {
                   // Debug.Log(" newIndexY[0]  = " + newIndexY[0]);
                y = newIndexY[0] + 1;
                newIndexY[0] = y;


                //y = newIndexY[0];
                //newIndexY[0] = newIndexY[0] + 1;
                //Debug.Log(" y " + y);

                   // Debug.Log(" newIndexX[0]  = " + newIndexX[0]);
                x = newIndexX[0] - 1;
                newIndexX[0] = x;
                //x = newIndexX[0];
                //newIndexX[0] = newIndexX[0] + 1;
               // Debug.Log(" x " + x);
                 //  Debug.Log(" ---------------- ");

                    cubePlay = gameBoard[indexDepth, y, x];

                    string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);
                    //Debug.Log(" playerSymbol =  " + playerSymbol);
                   //Debug.Log(" symbolToCompare =  " + symbolToCompare);
                   // Debug.Log(" ---------------- ");
                    if (playerSymbol.Equals(symbolToCompare))
                    {
                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                        CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);

                    }
                    else
                    {
                        break;

                    }

                }
            //}

        }

        public static int SetUpMinIndexXForCheckerBackslash(int lenghtForRows, int lenghtForColumns, int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay, int maxIndexYForGameBoard, int maxIndexXForGameBoard)
        {


            int minIndexXToCheck;

            //int lowerNumber = CommonMethods.CheckAndReturnLowerNumber(lenghtForRows, lenghtForColumns);


            int maxIndexYCountedForOtherCubePlay = firstIndexYForOtherCubePlay + maxIndexXForGameBoard;

            if (firstIndexXForOtherCubePlay == maxIndexXForGameBoard)
            {

                if (maxIndexYCountedForOtherCubePlay <= maxIndexYForGameBoard)
                {

                    //if (maxIndexYCountedForOtherCubePlay <= lowerNumber)
                    //{
                    int difference = 0;
                    minIndexXToCheck = difference;
                    return minIndexXToCheck;

                    //}
                    //  else
                    //  {
                    //int difference = 0; // ?
                    // minIndexXToCheck = difference;
                    // return minIndexXToCheck;
                    // }

                }
                else
                {
                    int difference = maxIndexYCountedForOtherCubePlay - maxIndexYForGameBoard;
                   // Debug.Log("maxIndexYCountedForOtherCubePlay = " + maxIndexYCountedForOtherCubePlay);
                    //Debug.Log("maxIndexXForGameBoard = " + maxIndexXForGameBoard);
                   // Debug.Log("difference = " + difference);
                    minIndexXToCheck = difference;
                    return minIndexXToCheck;

                }

            }
            else
            {
                return minIndexXToCheck = 0;

            }


            //return minIndexXToCheck;






        }

        public static void ChangeAllCubePlayForCheckerBackslash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin)
        {
            ChangeWinnerCubePlayForCheckerBackslash(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            ChangeOtherCubePlayForCheckerBackslash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
        }



















        public static void ChangeWinnerCubePlayForCheckerSlash(GameObject[,,] gameBoard, int[,] _winnerCoordinateXYForCubePlay, string _tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;
            int winnerLenghtForRows = _winnerCoordinateXYForCubePlay.GetLength(0);

            for (int indexRowWinner = 0; indexRowWinner < winnerLenghtForRows; indexRowWinner++)
            {
                int coordinateYToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 0];
                int coordinateXToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 1];

                cubePlay = gameBoard[indexDepth, coordinateYToMark, coordinateXToMark];

                CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameWin);

            }

            //for (int y = 0; y < _winnerCoordinateXYForCubePlay.GetLength(0); y++)
            //{
            //    for (int x = 0; x < _winnerCoordinateXYForCubePlay.GetLength(1); x++)
            //    {
            //        Debug.Log($"coordinateXYToMark [{y},{x}] = " + _winnerCoordinateXYForCubePlay[y, x]);

            //    }
            //    Debug.Log($"----------------------------------------");
            //}
            //Debug.Log($"---------- ************************************  ------------------------------");

        }

        public static void ChangeOtherCubePlayForCheckerSlash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;

            // gameBoard
            int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);

            // _winnerCoordinateXYForCubePlay
            int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);
            // int winnerLenghtForColumns = winnerCoordinateXYForCubePlay.GetLength(1);

            int coordinateYToMarkOther = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
            int coordinateXToMarkOther = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 1];

            int firstIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
            int firstIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];

            int maxIndexXForGameBoard = gameBoard.GetLength(2) - 1;
            int maxIndexYForGameBoard = gameBoard.GetLength(1) - 1;

            int minIndexXToCheck = SetUpMinIndexXForCheckerSlash(lenghtForRows, lenghtForColumns, firstIndexYForOtherCubePlay, firstIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);
            Debug.Log("minIndexXToCheck = " + minIndexXToCheck);

            int startIndexYForOtherCubePlay = coordinateYToMarkOther;
            int startIndexXForOtherCubePlay = coordinateXToMarkOther;
            int y;
            int x;

            int[] newIndexY = new int[1];
            newIndexY[0] = startIndexYForOtherCubePlay;
            //newIndexY[0] = 0;

            int[] newIndexX = new int[1];
            newIndexX[0] = startIndexXForOtherCubePlay;
            //newIndexX[0] = 0;

            //  for (int i = startIndexXForOtherCubePlay - 1; i >= minIndexXToCheck; i--)
            for (int i = startIndexXForOtherCubePlay; i < minIndexXToCheck; i++)
            {
                Debug.Log(" i  = " + i);
                y = newIndexY[0] + 1;
                newIndexY[0] = y;


                //y = newIndexY[0];
                //newIndexY[0] = newIndexY[0] + 1;
                //Debug.Log(" y " + y);

                // Debug.Log(" newIndexX[0]  = " + newIndexX[0]);
                x = newIndexX[0] + 1;
                newIndexX[0] = x;
                //x = newIndexX[0];
                //newIndexX[0] = newIndexX[0] + 1;
                // Debug.Log(" x " + x);
                //  Debug.Log(" ---------------- ");

                cubePlay = gameBoard[indexDepth, y, x];

                string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);
                //Debug.Log(" playerSymbol =  " + playerSymbol);
                //Debug.Log(" symbolToCompare =  " + symbolToCompare);
                // Debug.Log(" ---------------- ");
                if (playerSymbol.Equals(symbolToCompare))
                {
                    CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                    CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);

                }
                else
                {
                    break;

                }

            }
            //}

        }

        public static int SetUpMinIndexXForCheckerSlash(int lenghtForRows, int lenghtForColumns, int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay, int maxIndexYForGameBoard, int maxIndexXForGameBoard)
        {


            int minIndexXToCheck;

           // int lowerNumber = CommonMethods.CheckAndReturnLowerNumber(lenghtForRows, lenghtForColumns);
           // 22/ 29 /15

            int maxIndexXCountedForOtherCubePlay = firstIndexXForOtherCubePlay + maxIndexXForGameBoard;

            Debug.Log("maxIndexYCountedForOtherCubePlay = " + maxIndexXCountedForOtherCubePlay);
            Debug.Log("firstIndexXForOtherCubePlay = " + firstIndexXForOtherCubePlay);
            Debug.Log("maxIndexXForGameBoard = " + maxIndexXForGameBoard);
            Debug.Log("maxIndexYForGameBoard = " + maxIndexYForGameBoard);
            Debug.Log(" ---------------------------- ");

            //if (firstIndexXForOtherCubePlay == maxIndexXForGameBoard)
            if (firstIndexXForOtherCubePlay > 0)
            {
                Debug.Log("  1  ");
                if (maxIndexXCountedForOtherCubePlay <= maxIndexYForGameBoard)
                {
                    Debug.Log("  2  ");
                    //if (maxIndexYCountedForOtherCubePlay <= lowerNumber)
                    //{
                    int difference = 0;
                    minIndexXToCheck = difference;
                    return minIndexXToCheck;

                    //}
                    //  else
                    //  {
                    //int difference = 0; // ?
                    // minIndexXToCheck = difference;
                    // return minIndexXToCheck;
                    // }


                }
                else
                {
                    Debug.Log("  3  ");
                    //int difference = maxIndexYCountedForOtherCubePlay - maxIndexYForGameBoard;

                    //int difference = maxIndexXCountedForOtherCubePlay - maxIndexXForGameBoard; // + firstIndexYForOtherCubePlay;
                    //int difference = maxIndexXCountedForOtherCubePlay - firstIndexXForOtherCubePlay;
                    int difference = maxIndexXForGameBoard;

                    Debug.Log("maxIndexXCountedForOtherCubePlay = " + maxIndexXCountedForOtherCubePlay);
                    Debug.Log("maxIndexXForGameBoard = " + maxIndexXForGameBoard);
                    Debug.Log("difference = " + difference);
                    minIndexXToCheck = difference;
                    return minIndexXToCheck;

                }

            }
            else
            {
                Debug.Log("  4  " );
                return minIndexXToCheck = lenghtForRows - firstIndexYForOtherCubePlay; // - 1

            }


        }

        public static void ChangeAllCubePlayForCheckerSlash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin)
        {
            ChangeWinnerCubePlayForCheckerSlash(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            ChangeOtherCubePlayForCheckerSlash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
        }






        public static void ChangeAllCubePlayAfterWin(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string winnerKindOfChecker, string tagCubePlayGameWin, string tagCubePlayGameOver)
        {
            Dictionary<int, string> checkerDictionary = GameDictionariesCommon.DictionaryChecker();

            string checkerHorizontal = checkerDictionary[1];
            string checkerVertical = checkerDictionary[2];
            string checkerSlash = checkerDictionary[3];
            string checkerBackslash = checkerDictionary[4];


            ChangeAllCubePlay(gameBoard, tagCubePlayGameOver);

            // checkerHorizontal
            if (winnerKindOfChecker.Equals(checkerHorizontal))
            {
                ChangeAllCubePlayForCheckerHorizontal(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            }

            // checkerVertical
            if (winnerKindOfChecker.Equals(checkerVertical))
            {
                ChangeAllCubePlayForCheckerVertical(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            }


            // checkerSlash
            if (winnerKindOfChecker.Equals(checkerSlash))
            {
                ChangeAllCubePlayForCheckerSlash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            }

            // checkerBackslash
            if (winnerKindOfChecker.Equals(checkerBackslash))
            {
                ChangeAllCubePlayForCheckerBackslash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            }
           
        }












    }


}
