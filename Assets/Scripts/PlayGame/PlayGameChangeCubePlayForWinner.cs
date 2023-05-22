using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameFrame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayGame
{
    internal class PlayGameChangeCubePlayForWinner
    {
        private static bool _isGame2D = true;
        //private static float _newCoordinateZForWinner = -0.5f;
        //private static float _newCoordinateZForWinner = -0.2f;
        private static float _newCoordinateZForAllCubePlay = 0f;
        private static float _newCoordinateZForAllCubePlayWinner = -0.2f;
        private static float _newCoordinateZForCubePlayFrame = 0f;

        public static void ChangeForAllCubePlayText(GameObject[,,] boardGame, string[] playersSymbols)
        {
            //int dictionaryColorId = 2;
            //Color textColour2 = CommonMethods.GetNewColor(dictionaryColorId);

            int dictionaryColorIdForTextInvisible = 4;
            Color textInvisible = CommonMethods.GetNewColor(dictionaryColorIdForTextInvisible);

            int dictionaryColorIdForOtherPlayersSymbols = 3;
            Color textForOtherPlayersSymbols = CommonMethods.GetNewColor(dictionaryColorIdForOtherPlayersSymbols);

            int maxIndexDepth = boardGame.GetLength(0);
            int maxIndexColumn = boardGame.GetLength(2);
            int maxIndexRow = boardGame.GetLength(1);

            int playersNumber = playersSymbols.Length;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = boardGame[indexDepth, indexRow, indexColumn];
                        string cubePlayText = CommonMethods.GetCubePlayText(cubePlay);

                        CommonMethods.ChangeTextColourForCubePlay(cubePlay, textInvisible);

                        for (int player = 0; player < playersNumber; player++)
                        {
                            string playerSymbol = playersSymbols[player];

                            if (cubePlayText == playerSymbol)
                            {
                                CommonMethods.ChangeTextColourForCubePlay(cubePlay, textForOtherPlayersSymbols);
                            }
                            //else
                            //{
                                //Debug.Log(" 1  ");
                                //CommonMethods.ChangeTextColourForCubePlay(cubePlay, textInvisible);
                            //}

                        }

                    }
                }
            }
        }


        public static void ChangesForOneCubePlay(GameObject cubePlay, string tagCubePlayGameOver, Color newTextColor)
        {
            CommonMethods.ChangeZForGameObject(cubePlay, _newCoordinateZForAllCubePlay);
            CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameOver);
            //CommonMethods.ChangeTextColourForCubePlay(cubePlay, newTextColor);
            //ChangeOneCubePlayText(cubePlay);
        }

        public static void ChangesForAllCubePlay(GameObject[,,] gameBoard, string tagCubePlayGameOver)
        {
            GameObject cubePlay;

            int dictionaryColorId = 1;
            Color newTextColor = CommonMethods.GetNewColor(dictionaryColorId);

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

                        ChangesForOneCubePlay(cubePlay, tagCubePlayGameOver, newTextColor);
                    }
                }
            }


        }

        public static void ChangeOneWinnerCubePlayForChecker(GameObject cubePlay, GameObject prefabCubePlayFrame, Color newTextColor, Material winColourForCubePlay, bool _isGame2D, float newFontSize, string tagCubePlayGameWin)
        {
            //float newCoordinateZForAll = 0;
            //float newCoordinateZForCubePlayFrame = -0.15f;

            CommonMethods.ChangeColourForGameObject(cubePlay, winColourForCubePlay);
            CommonMethods.ChangeZForGameObject(cubePlay, _newCoordinateZForAllCubePlayWinner);

            GameObject frame = PlayGameFrameCreate.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, _isGame2D);

            //float ChangeOneWinnerZ = frame.transform.position.z;
            //Debug.Log("ChangeOneWinnerZ =  " + ChangeOneWinnerZ);

            //CommonMethods.ChangeZForGameObject(prefabCubePlayFrame, _newCoordinateZForCubePlayFrame);
            CommonMethods.ChangeZForGameObject(frame, _newCoordinateZForCubePlayFrame);

            //float z = prefabCubePlayFrame.transform.position.z;
            //Debug.Log(" z = " + z);


            //CommonMethods.ChangeZForGameObject(prefabCubePlayFrame, newCoordinateZForCubePlayFrame);

            CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);

            CommonMethods.ChangeTextColourForCubePlay(cubePlay, newTextColor);
            CommonMethods.ChangeTextFontSize(cubePlay, newFontSize);

            
        }

        public static void ChangeWinnerCubePlayForChecker(GameObject[,,] gameBoard, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            GameObject cubePlay;
            int indexDepth = 0;
            int winnerLenghtForColumns = winnerCoordinateXYForCubePlay.GetLength(0);

            for (int indexColumnsWinner = 0; indexColumnsWinner < winnerLenghtForColumns; indexColumnsWinner++)
            {
                int coordinateYToMark = winnerCoordinateXYForCubePlay[indexColumnsWinner, 0];
                int coordinateXToMark = winnerCoordinateXYForCubePlay[indexColumnsWinner, 1];

                cubePlay = gameBoard[indexDepth, coordinateYToMark, coordinateXToMark];

                ChangeOneWinnerCubePlayForChecker(cubePlay, prefabCubePlayFrame, newTextColor, winColourForCubePlay, _isGame2D, newFontSize, tagCubePlayGameWin);

            }

        }

        public static void ChangeOneOtherCubePlay(GameObject prefabCubePlayFrame, GameObject cubePlay, Material winColourForCubePlay, string tagCubePlayGameWin, Color newTextColor, float newFontSize)
        {
            GameObject frame = PlayGameFrameCreate.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, true);
            
            //float ChangeOneOtherCubePlayZ = frame.transform.position.z;
            //Debug.Log("ChangeOneOtherCubePlayZ =  " + ChangeOneOtherCubePlayZ);

            CommonMethods.ChangeZForGameObject(frame, _newCoordinateZForCubePlayFrame);

            CommonMethods.ChangeZForGameObject(cubePlay, _newCoordinateZForAllCubePlayWinner);
           // CommonMethods.ChangeZForGameObject(prefabCubePlayFrame, _newCoordinateZForCubePlayFrame);
          
            
            CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);
            CommonMethods.ChangeColourForGameObject(cubePlay, winColourForCubePlay);

            CommonMethods.ChangeTextColourForCubePlay(cubePlay, newTextColor);
            CommonMethods.ChangeTextFontSize(cubePlay, newFontSize);
     
        }

        public static void ChangeOtherCubePlayForCheckerHorizontal(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            GameObject cubePlay;
            int indexDepth = 0;

            int lenghtForColumns = gameBoard.GetLength(2);

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
                        ChangeOneOtherCubePlay(prefabCubePlayFrame, cubePlay, winColourForCubePlay, tagCubePlayGameWin, newTextColor, newFontSize);

                    }
                    else
                    {
                        break;

                    }

                }
            }

        }

        public static void ChangeAllCubePlayForCheckerHorizontal(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
            ChangeOtherCubePlayForCheckerHorizontal(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
        }




        public static void ChangeOtherCubePlayForCheckerVertical(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            GameObject cubePlay;
            int indexDepth = 0;

            int lenghtForRows = gameBoard.GetLength(1);

            int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);

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
                        ChangeOneOtherCubePlay(prefabCubePlayFrame, cubePlay, winColourForCubePlay, tagCubePlayGameWin, newTextColor, newFontSize);
                    
                    }
                    else
                    {
                        break;

                    }

                }
            }

        }

        public static void ChangeAllCubePlayForCheckerVertical(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
            ChangeOtherCubePlayForCheckerVertical(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
        }






        //public static void ChangeOtherCubePlayForCheckerBackslash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        //{
        //    GameObject cubePlay;
        //    int indexDepth = 0;

        //    int lenghtForRows = gameBoard.GetLength(1);
        //    int lenghtForColumns = gameBoard.GetLength(2);

        //    int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);

        //    int startIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
        //    int startIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 1];

        //    int firstIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
        //    int firstIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];

        //    int maxIndexXForGameBoard = lenghtForColumns - 1;
        //    int maxIndexYForGameBoard = lenghtForRows - 1;

        //    int minIndexXToCheck = SetUpMinIndexXForCheckerBackslash(firstIndexYForOtherCubePlay, firstIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);

        //    int y;
        //    int x;

        //    int[] newIndexY = new int[1];
        //    newIndexY[0] = startIndexYForOtherCubePlay;

        //    int[] newIndexX = new int[1];
        //    newIndexX[0] = startIndexXForOtherCubePlay;



        //    for (int i = startIndexXForOtherCubePlay - 1; i >= minIndexXToCheck; i--)
        //    {
        //        y = newIndexY[0] + 1;
        //        newIndexY[0] = y;

        //        x = newIndexX[0] - 1;
        //        newIndexX[0] = x;

        //        cubePlay = gameBoard[indexDepth, y, x];

        //        string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);

        //        if (playerSymbol.Equals(symbolToCompare))
        //        {
        //            ChangeOneOtherCubePlay(prefabCubePlayFrame, cubePlay, winColourForCubePlay, tagCubePlayGameWin, newTextColor, newFontSize);

        //        }
        //        else
        //        {
        //            break;

        //        }

        //    }

        //}

        //public static int SetUpMinIndexXForCheckerBackslash(int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay, int maxIndexYForGameBoard, int maxIndexXForGameBoard)
        //{
        //    int minIndexXToCheck;
        //    int maxIndexYCountedForOtherCubePlay = firstIndexXForOtherCubePlay + firstIndexYForOtherCubePlay;

        //    if (firstIndexXForOtherCubePlay == 0)
        //    {
        //        if (maxIndexYCountedForOtherCubePlay <= maxIndexYForGameBoard)
        //        {
        //            minIndexXToCheck = maxIndexYCountedForOtherCubePlay - maxIndexYForGameBoard;
        //            return minIndexXToCheck;

        //        }
        //        else
        //        {
        //            minIndexXToCheck = maxIndexYCountedForOtherCubePlay - maxIndexYForGameBoard;
        //            return minIndexXToCheck;

        //        }
        //    }
        //    else
        //    {

        //        if (maxIndexYCountedForOtherCubePlay <= maxIndexYForGameBoard)
        //        {
        //            minIndexXToCheck = 0;
        //            return minIndexXToCheck;
        //        }
        //        else
        //        {
        //            minIndexXToCheck = firstIndexYForOtherCubePlay + firstIndexXForOtherCubePlay - maxIndexYForGameBoard;
        //            return minIndexXToCheck;

        //        }
        //    }
        //}


        public static int SetUpMaxIndexXForCheckerBackslash(int lenghtForRows, int lenghtForColumns, int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay)
        {
            int maxIndexToCheck;
            //int maxIndexYCountedForOtherCubePlay = firstIndexYForOtherCubePlay + maxIndexYForGameBoard;

            int maxIndexX = lenghtForColumns - 1;
            int maxIndexY = lenghtForRows - 1;

            if (firstIndexXForOtherCubePlay < maxIndexX && firstIndexYForOtherCubePlay < maxIndexY)
            {
                int lengthToCheck = maxIndexX - firstIndexXForOtherCubePlay;
                int currentX = firstIndexXForOtherCubePlay;
                int currentY = firstIndexYForOtherCubePlay;

                for (int i = 0; i < lengthToCheck; i++)
                {
                    if (currentX < maxIndexX && currentY > 0)
                    {
                        //++currentX;
                        //Debug.Log("--- 1 ----- currentX = " + currentX + " , maxIndexX = " + maxIndexX);

                        currentX = currentX + 1;
                        currentY = currentY - 1;
                        //Debug.Log("--- 1 ----- currentX = " + currentX);
                    }
                }

                maxIndexToCheck = currentX;
                //Debug.Log("--- 2 ----- maxIndexToCheck = " + maxIndexToCheck);
                return maxIndexToCheck;

            }
            else
            {
                maxIndexToCheck = firstIndexXForOtherCubePlay;
                //Debug.Log("--- 1 ----- maxIndexToCheck = " + maxIndexToCheck);
                return maxIndexToCheck;
            }

        }

        public static void ChangeOtherCubePlayForCheckerBackslash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            // Debug.Log(" 3 ");
            GameObject cubePlay;
            int indexDepth = 0;

            int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);

            int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);

            int startUpIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
            int startUpIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 1];
           // Debug.Log(" startUpIndexYForOtherCubePlay = " + startUpIndexYForOtherCubePlay);
            //Debug.Log(" startUpIndexXForOtherCubePlay = " + startUpIndexXForOtherCubePlay);


            int lastIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
            int lastIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];
            //Debug.Log(" lastIndexYForOtherCubePlay = " + lastIndexYForOtherCubePlay);
            //Debug.Log(" lastIndeXForOtherCubePlay = " + lastIndexXForOtherCubePlay);

            //int firstIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
            //int firstIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];

            //int maxIndexXForGameBoard = lenghtForColumns - 1;
            //int maxIndexYForGameBoard = lenghtForRows - 1;

            //int maxIndexXToCheck = SetUpMaxIndexXForCheckerSlash2(lenghtForRows, lenghtForColumns, startUpIndexYForOtherCubePlay, startUpIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);
            //int maxIndexXToCheck = SetUpMaxIndexXForCheckerSlash(lenghtForRows, lenghtForColumns, lastIndexYForOtherCubePlay, lastIndexXForOtherCubePlay);
            int maxIndexXToCheck = SetUpMaxIndexXForCheckerBackslash(lenghtForRows, lenghtForColumns, lastIndexYForOtherCubePlay, lastIndexXForOtherCubePlay);
            //int maxIndexXToCheck = lenghtForColumns;
            //Debug.Log(" maxIndexXToCheck = " + maxIndexXToCheck);

            //int minIndexXToCheck = SetUpMinIndexXForCheckerSlash(lenghtForRows, lenghtForColumns, lastIndexYForOtherCubePlay, lastIndexXForOtherCubePlay);
            int minIndexXToCheck = SetUpMinIndexXForCheckerBackslash(lenghtForRows, lenghtForColumns, startUpIndexYForOtherCubePlay, startUpIndexXForOtherCubePlay);
            //Debug.Log(" minIndexXToCheck = " + minIndexXToCheck);


            //int minIndexXToCheck = SetUpMinIndexXForCheckerSlash2(lenghtForRows, lenghtForColumns, firstIndexYForOtherCubePlay, firstIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);
            // int minIndexXToCheck = 0;
            //Debug.Log(" minIndexXToCheck = " + minIndexXToCheck);

            int yForFirstCubePlay;
            int xForFirstCubePlay;

            int[] newIndexYForFirstCubePlay = new int[1];
            newIndexYForFirstCubePlay[0] = startUpIndexYForOtherCubePlay;

            int[] newIndexXForFirstCubePlay = new int[1];
            newIndexXForFirstCubePlay[0] = startUpIndexXForOtherCubePlay;

            for (int i = startUpIndexXForOtherCubePlay; i > minIndexXToCheck; i--)
            {
                yForFirstCubePlay = newIndexYForFirstCubePlay[0] + 1;
                newIndexYForFirstCubePlay[0] = yForFirstCubePlay;

                xForFirstCubePlay = newIndexXForFirstCubePlay[0] - 1;
                newIndexXForFirstCubePlay[0] = xForFirstCubePlay;

                cubePlay = gameBoard[indexDepth, yForFirstCubePlay, xForFirstCubePlay];

                string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);


                if (playerSymbol.Equals(symbolToCompare))
                {
                    ChangeOneOtherCubePlay(prefabCubePlayFrame, cubePlay, winColourForCubePlay, tagCubePlayGameWin, newTextColor, newFontSize);

                }
                else
                {
                    break;

                }
            }

            // ----


            int yForLastCubePlay;
            int xForLastCubePlay;

            int[] newIndexYForLastCubePlay = new int[1];
            newIndexYForLastCubePlay[0] = lastIndexYForOtherCubePlay;

            int[] newIndexXForLastCubePlay = new int[1];
            newIndexXForLastCubePlay[0] = lastIndexXForOtherCubePlay;

            for (int i = lastIndexXForOtherCubePlay; i < maxIndexXToCheck; i++)
            {
                //Debug.Log(" TEST 1 ");
                yForLastCubePlay = newIndexYForLastCubePlay[0] - 1;
                newIndexYForLastCubePlay[0] = yForLastCubePlay;

                xForLastCubePlay = newIndexXForLastCubePlay[0] + 1;
                newIndexXForLastCubePlay[0] = xForLastCubePlay;

                cubePlay = gameBoard[indexDepth, yForLastCubePlay, xForLastCubePlay];

                string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);


                if (playerSymbol.Equals(symbolToCompare))
                {
                    ChangeOneOtherCubePlay(prefabCubePlayFrame, cubePlay, winColourForCubePlay, tagCubePlayGameWin, newTextColor, newFontSize);

                }
                else
                {
                    break;

                }
            }

        }
        public static void ChangeAllCubePlayForCheckerBackslash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
            ChangeOtherCubePlayForCheckerBackslash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
        }






        public static void ChangeOtherCubePlayForCheckerSlash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
           // Debug.Log(" 3 ");
            GameObject cubePlay;
            int indexDepth = 0;

            int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);

            int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);

            int startUpIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
            int startUpIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 1];
            //Debug.Log(" startUpIndexYForOtherCubePlay = " + startUpIndexYForOtherCubePlay);
            //Debug.Log(" startUpIndexXForOtherCubePlay = " + startUpIndexXForOtherCubePlay);


            int lastIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
            int lastIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];
            //Debug.Log(" lastIndexYForOtherCubePlay = " + lastIndexYForOtherCubePlay);
          // Debug.Log(" lastIndeXForOtherCubePlay = " + lastIndexXForOtherCubePlay);

            //int firstIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
            //int firstIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];

            //int maxIndexXForGameBoard = lenghtForColumns - 1;
            //int maxIndexYForGameBoard = lenghtForRows - 1;

            //int maxIndexXToCheck = SetUpMaxIndexXForCheckerSlash2(lenghtForRows, lenghtForColumns, startUpIndexYForOtherCubePlay, startUpIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);
            int maxIndexXToCheck = SetUpMaxIndexXForCheckerSlash(lenghtForRows, lenghtForColumns, startUpIndexYForOtherCubePlay, startUpIndexXForOtherCubePlay);
            //int maxIndexXToCheck = lenghtForColumns;
           // Debug.Log(" maxIndexXToCheck = " + maxIndexXToCheck);


            //int minIndexXToCheck = SetUpMinIndexXForCheckerSlash2(lenghtForRows, lenghtForColumns, firstIndexYForOtherCubePlay, firstIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);
           // int minIndexXToCheck = 0;
            //Debug.Log(" minIndexXToCheck = " + minIndexXToCheck);

            int yForFirstCubePlay;
            int xForFirstCubePlay;

            int[] newIndexYForFirstCubePlay = new int[1];
            newIndexYForFirstCubePlay[0] = startUpIndexYForOtherCubePlay;

            int[] newIndexXForFirstCubePlay = new int[1];
            newIndexXForFirstCubePlay[0] = startUpIndexXForOtherCubePlay;

            for (int i = startUpIndexXForOtherCubePlay; i < maxIndexXToCheck; i++)
            {
                yForFirstCubePlay = newIndexYForFirstCubePlay[0] + 1;
                newIndexYForFirstCubePlay[0] = yForFirstCubePlay;

                xForFirstCubePlay = newIndexXForFirstCubePlay[0] + 1;
                newIndexXForFirstCubePlay[0] = xForFirstCubePlay;

                cubePlay = gameBoard[indexDepth, yForFirstCubePlay, xForFirstCubePlay];

                string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);


                if (playerSymbol.Equals(symbolToCompare))
                {
                    ChangeOneOtherCubePlay(prefabCubePlayFrame, cubePlay, winColourForCubePlay, tagCubePlayGameWin, newTextColor, newFontSize);

                }
                else
                {
                    break;

                }
            }

            // ----

            int minIndexXToCheck = SetUpMinIndexXForCheckerSlash(lenghtForRows, lenghtForColumns, lastIndexYForOtherCubePlay, lastIndexXForOtherCubePlay);
            //Debug.Log(" minIndexXToCheck = " + minIndexXToCheck);

            int yForLastCubePlay;
            int xForLastCubePlay;

            int[] newIndexYForLastCubePlay = new int[1];
            newIndexYForLastCubePlay[0] = lastIndexYForOtherCubePlay;

            int[] newIndexXForLastCubePlay = new int[1];
            newIndexXForLastCubePlay[0] = lastIndexXForOtherCubePlay;

            for (int i = lastIndexXForOtherCubePlay; i > minIndexXToCheck; i--)
            {
                //Debug.Log(" TEST 1 ");
                yForLastCubePlay = newIndexYForLastCubePlay[0] - 1;
                newIndexYForLastCubePlay[0] = yForLastCubePlay;

                xForLastCubePlay = newIndexXForLastCubePlay[0] - 1;
                newIndexXForLastCubePlay[0] = xForLastCubePlay;

                cubePlay = gameBoard[indexDepth, yForLastCubePlay, xForLastCubePlay];

                string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);


                if (playerSymbol.Equals(symbolToCompare))
                {
                    ChangeOneOtherCubePlay(prefabCubePlayFrame, cubePlay, winColourForCubePlay, tagCubePlayGameWin, newTextColor, newFontSize);

                }
                else
                {
                    break;

                }
            }
        }


        public static int SetUpMaxIndexXForCheckerSlash(int lenghtForRows, int lenghtForColumns, int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay)
        {
            int maxIndexToCheck;
            //int maxIndexYCountedForOtherCubePlay = firstIndexYForOtherCubePlay + maxIndexYForGameBoard;

            int maxIndexX = lenghtForColumns - 1;
            int maxIndexY = lenghtForRows - 1;

            if (firstIndexXForOtherCubePlay < maxIndexX && firstIndexYForOtherCubePlay < maxIndexY)
            {
                int lengthToCheck = maxIndexX - firstIndexXForOtherCubePlay;
                int currentX = firstIndexXForOtherCubePlay;
                int currentY = firstIndexYForOtherCubePlay;

                for (int i = 0; i < lengthToCheck; i++)
                {
                    if (currentX < maxIndexX && currentY < maxIndexY)
                    {
                        //++currentX;
                        //Debug.Log("--- 1 ----- currentX = " + currentX + " , maxIndexX = " + maxIndexX);

                        currentX = currentX + 1;
                        currentY = currentY + 1;
                        //Debug.Log("--- 1 ----- currentX = " + currentX);
                    }
                }

                maxIndexToCheck = currentX;
                //Debug.Log("--- 2 ----- maxIndexToCheck = " + maxIndexToCheck);
                return maxIndexToCheck;

            }
            else
            {
                maxIndexToCheck = firstIndexXForOtherCubePlay;
                //Debug.Log("--- 1 ----- maxIndexToCheck = " + maxIndexToCheck);
                return maxIndexToCheck;
            }

        }

        public static int SetUpMinIndexXForCheckerSlash(int lenghtForRows, int lenghtForColumns, int lastIndexYForOtherCubePlay, int lastIndexXForOtherCubePlay)
        {
            int minIndexToCheck;
            int maxIndexX = lenghtForColumns - 1;
            int maxIndexY = lenghtForRows - 1;

           // int maxIndexYCountedForOtherCubePlay = lastIndexYForOtherCubePlay + maxIndexY;



            if (lastIndexXForOtherCubePlay < maxIndexX && lastIndexYForOtherCubePlay < maxIndexY)
            {
                int lengthToCheck = maxIndexX - lastIndexXForOtherCubePlay;
                int currentX = lastIndexXForOtherCubePlay;
                int currentY = lastIndexYForOtherCubePlay;

                for (int i = 0; i < lengthToCheck; i++)
                {
                    if (currentX > 0 && currentY > 0)
                    {
                        //++currentX;
                        //Debug.Log("--- 1 ----- currentX = " + currentX + " , maxIndexX = " + maxIndexX);

                        currentX = currentX - 1;
                        currentY = currentY - 1;
                        //Debug.Log("--- 1 ----- currentX = " + currentX);
                    }
                }

                minIndexToCheck = currentX;
                //Debug.Log("--- 2 ----- minIndexToCheck = " + minIndexToCheck);
                return minIndexToCheck;

            }
            else
            {
                minIndexToCheck = lastIndexXForOtherCubePlay;
                //Debug.Log("--- 1 ----- minIndexToCheck = " + minIndexToCheck);
                return minIndexToCheck;
            }



        }

        public static int SetUpMinIndexXForCheckerBackslash(int lenghtForRows, int lenghtForColumns, int lastIndexYForOtherCubePlay, int lastIndexXForOtherCubePlay)
        {
            int minIndexToCheck;
            int maxIndexX = lenghtForColumns - 1;
            int maxIndexY = lenghtForRows - 1;

            // int maxIndexYCountedForOtherCubePlay = lastIndexYForOtherCubePlay + maxIndexY;



            if (lastIndexXForOtherCubePlay < maxIndexX && lastIndexYForOtherCubePlay < maxIndexY)
            {
                int lengthToCheck = maxIndexX - lastIndexXForOtherCubePlay;
                int currentX = lastIndexXForOtherCubePlay;
                int currentY = lastIndexYForOtherCubePlay;

                for (int i = 0; i < lengthToCheck; i++)
                {
                    if (currentX > 0 && currentY < maxIndexY)
                    {
                        //++currentX;
                        //Debug.Log("--- 1 ----- currentX = " + currentX + " , maxIndexX = " + maxIndexX);

                        currentX = currentX - 1;
                        currentY = currentY + 1;
                        //Debug.Log("--- 1 ----- currentX = " + currentX);
                    }
                }

                minIndexToCheck = currentX;
                //Debug.Log("--- 2 ----- minIndexToCheck = " + minIndexToCheck);
                return minIndexToCheck;

            }
            else
            {
                minIndexToCheck = lastIndexXForOtherCubePlay;
                //Debug.Log("--- 1 ----- minIndexToCheck = " + minIndexToCheck);
                return minIndexToCheck;
            }



        }

        public static void ChangeAllCubePlayForCheckerSlash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
            ChangeOtherCubePlayForCheckerSlash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
        }

        public static void ChangeAllCubePlayAfterWin(GameObject[,,] gameBoard, string playerSymbol, ArrayList listCheckerForWinner, GameObject prefabCubePlayFrame, Material[] cubePlayColourWin, string[] playersSymbols)
        {
            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();

            string tagCubePlayGameOver = tagCubePlayDictionary[4];
            string tagCubePlayGameWin = tagCubePlayDictionary[5];

            int[,]  winnerCoordinateXYForCubePlay = (int[,])listCheckerForWinner[1];
            string winnerKindOfChecker = (string)listCheckerForWinner[2];

            Dictionary<int, string> checkerDictionary = GameDictionariesGameFieldsVerification.DictionaryChecker();

            string checkerHorizontal = checkerDictionary[1];
            string checkerVertical = checkerDictionary[2];
            string checkerSlash = checkerDictionary[3];
            string checkerBackslash = checkerDictionary[4];

            Material winColourForCubePlay = cubePlayColourWin[0];

            int dictionaryColorId = 2;
            //int dictionaryColorId = 5;
            Color newTextColor = CommonMethods.GetNewColor(dictionaryColorId);

            float newFontSize = 0.55f;

            ChangesForAllCubePlay(gameBoard, tagCubePlayGameOver);
            ChangeForAllCubePlayText(gameBoard, playersSymbols);

            // checkerHorizontal
            if (winnerKindOfChecker.Equals(checkerHorizontal))
            {
                ChangeAllCubePlayForCheckerHorizontal(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
            }

            // checkerVertical
            if (winnerKindOfChecker.Equals(checkerVertical))
            {
                ChangeAllCubePlayForCheckerVertical(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
            }


            // checkerSlash
            if (winnerKindOfChecker.Equals(checkerSlash))
            {
                ChangeAllCubePlayForCheckerSlash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
            }

            // checkerBackslash
            if (winnerKindOfChecker.Equals(checkerBackslash))
            {
                ChangeAllCubePlayForCheckerBackslash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
            }

        }










    }
}
