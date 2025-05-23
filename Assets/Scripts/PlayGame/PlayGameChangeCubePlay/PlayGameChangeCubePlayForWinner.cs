﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameChangeCubePlayForWinner
    {
        private static bool _isGame2D = true;
        private static float _newCoordinateZForAllCubePlay = 0f;
        private static float _newCoordinateZForAllCubePlayWinner = -0.2f;
        private static float _newCoordinateZForCubePlayFrame = 0f;

        public static void ChangeForAllCubePlayText(GameObject[,,] boardGame, string[] playersSymbols)
        {
            int dictionaryColorIdForTextInvisible = 4;
            Color textInvisible = GameCommonMethodsMain.GetNewColor(dictionaryColorIdForTextInvisible);

            int dictionaryColorIdForOtherPlayersSymbols = 5;
            Color textForOtherPlayersSymbols = GameCommonMethodsMain.GetNewColor(dictionaryColorIdForOtherPlayersSymbols);

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
                        string cubePlayText = GameCommonMethodsMain.GetCubePlayText(cubePlay);

                        GameCommonMethodsMain.ChangeTextColourForCubePlay(cubePlay, textInvisible);

                        for (int player = 0; player < playersNumber; player++)
                        {
                            string playerSymbol = playersSymbols[player];

                            if (cubePlayText == playerSymbol)
                            {
                                GameCommonMethodsMain.ChangeTextColourForCubePlay(cubePlay, textForOtherPlayersSymbols);
                            }                         
                        }
                    }
                }
            }
        }


        public static void ChangesForOneCubePlay(GameObject cubePlay, string tagCubePlayGameOver, Color newTextColor)
        {
            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, _newCoordinateZForAllCubePlay);
            GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagCubePlayGameOver);
        }

        public static void ChangesForAllCubePlay(GameObject[,,] gameBoard, string tagCubePlayGameOver)
        {
            GameObject cubePlay;

            int dictionaryColorId = 1;
            Color newTextColor = GameCommonMethodsMain.GetNewColor(dictionaryColorId);

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
            GameCommonMethodsMain.ChangeColourForGameObject(cubePlay, winColourForCubePlay);
            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, _newCoordinateZForAllCubePlayWinner);

            GameObject frame = PlayGameFrameCreate.CreateCubePlayFrameForWinner(prefabCubePlayFrame, cubePlay, _isGame2D);
            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(frame, _newCoordinateZForCubePlayFrame);

            GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);

            GameCommonMethodsMain.ChangeTextColourForCubePlay(cubePlay, newTextColor);
            GameCommonMethodsMain.ChangeTextFontSize(cubePlay, newFontSize);       
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
            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, _newCoordinateZForAllCubePlayWinner);

            GameObject frame = PlayGameFrameCreate.CreateCubePlayFrameForWinner(prefabCubePlayFrame, cubePlay, true);
            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(frame, _newCoordinateZForCubePlayFrame);

            GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);
            GameCommonMethodsMain.ChangeColourForGameObject(cubePlay, winColourForCubePlay);

            GameCommonMethodsMain.ChangeTextColourForCubePlay(cubePlay, newTextColor);
            GameCommonMethodsMain.ChangeTextFontSize(cubePlay, newFontSize);  
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

                    string symbolToCompare = GameCommonMethodsMain.GetCubePlayPlayerSymbol(cubePlay);

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

                    string symbolToCompare = GameCommonMethodsMain.GetCubePlayPlayerSymbol(cubePlay);

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

        public static int SetUpMaxIndexXForCheckerBackslash(int lenghtForRows, int lenghtForColumns, int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay)
        {
            int maxIndexToCheck;

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
                        currentX = currentX + 1;
                        currentY = currentY - 1;
                    }
                }

                maxIndexToCheck = currentX;
                return maxIndexToCheck;
            }
            else
            {
                maxIndexToCheck = firstIndexXForOtherCubePlay;
                return maxIndexToCheck;
            }
        }

        public static void ChangeOtherCubePlayForCheckerBackslash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            GameObject cubePlay;
            int indexDepth = 0;

            int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);

            int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);

            int startUpIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
            int startUpIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 1];

            int lastIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
            int lastIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];
            int maxIndexXToCheck = SetUpMaxIndexXForCheckerBackslash(lenghtForRows, lenghtForColumns, lastIndexYForOtherCubePlay, lastIndexXForOtherCubePlay);

            int minIndexXToCheck = SetUpMinIndexXForCheckerBackslash(lenghtForRows, lenghtForColumns, startUpIndexYForOtherCubePlay, startUpIndexXForOtherCubePlay);

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

                string symbolToCompare = GameCommonMethodsMain.GetCubePlayPlayerSymbol(cubePlay);

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
                yForLastCubePlay = newIndexYForLastCubePlay[0] - 1;
                newIndexYForLastCubePlay[0] = yForLastCubePlay;

                xForLastCubePlay = newIndexXForLastCubePlay[0] + 1;
                newIndexXForLastCubePlay[0] = xForLastCubePlay;

                cubePlay = gameBoard[indexDepth, yForLastCubePlay, xForLastCubePlay];

                string symbolToCompare = GameCommonMethodsMain.GetCubePlayPlayerSymbol(cubePlay);

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
            GameObject cubePlay;
            int indexDepth = 0;

            int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);

            int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);

            int startUpIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
            int startUpIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 1];

            int lastIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
            int lastIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];

            int maxIndexXToCheck = SetUpMaxIndexXForCheckerSlash(lenghtForRows, lenghtForColumns, startUpIndexYForOtherCubePlay, startUpIndexXForOtherCubePlay);

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

                string symbolToCompare = GameCommonMethodsMain.GetCubePlayPlayerSymbol(cubePlay);


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

            int yForLastCubePlay;
            int xForLastCubePlay;

            int[] newIndexYForLastCubePlay = new int[1];
            newIndexYForLastCubePlay[0] = lastIndexYForOtherCubePlay;

            int[] newIndexXForLastCubePlay = new int[1];
            newIndexXForLastCubePlay[0] = lastIndexXForOtherCubePlay;

            for (int i = lastIndexXForOtherCubePlay; i > minIndexXToCheck; i--)
            {
                yForLastCubePlay = newIndexYForLastCubePlay[0] - 1;
                newIndexYForLastCubePlay[0] = yForLastCubePlay;

                xForLastCubePlay = newIndexXForLastCubePlay[0] - 1;
                newIndexXForLastCubePlay[0] = xForLastCubePlay;

                cubePlay = gameBoard[indexDepth, yForLastCubePlay, xForLastCubePlay];

                string symbolToCompare = GameCommonMethodsMain.GetCubePlayPlayerSymbol(cubePlay);


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
                        currentX = currentX + 1;
                        currentY = currentY + 1;
                    }
                }

                maxIndexToCheck = currentX;
                return maxIndexToCheck;
            }
            else
            {
                maxIndexToCheck = firstIndexXForOtherCubePlay;
                return maxIndexToCheck;
            }
        }

        public static int SetUpMinIndexXForCheckerSlash(int lenghtForRows, int lenghtForColumns, int lastIndexYForOtherCubePlay, int lastIndexXForOtherCubePlay)
        {
            int minIndexToCheck;
            int maxIndexX = lenghtForColumns - 1;
            int maxIndexY = lenghtForRows - 1;

            if (lastIndexXForOtherCubePlay < maxIndexX && lastIndexYForOtherCubePlay < maxIndexY)
            {
                int lengthToCheck = maxIndexX - lastIndexXForOtherCubePlay;
                int currentX = lastIndexXForOtherCubePlay;
                int currentY = lastIndexYForOtherCubePlay;

                for (int i = 0; i < lengthToCheck; i++)
                {
                    if (currentX > 0 && currentY > 0)
                    {
                        currentX = currentX - 1;
                        currentY = currentY - 1;                   
                    }
                }

                minIndexToCheck = currentX;
                return minIndexToCheck;
            }
            else
            {
                minIndexToCheck = lastIndexXForOtherCubePlay;
                return minIndexToCheck;
            }
        }

        public static int SetUpMinIndexXForCheckerBackslash(int lenghtForRows, int lenghtForColumns, int lastIndexYForOtherCubePlay, int lastIndexXForOtherCubePlay)
        {
            int minIndexToCheck;
            int maxIndexX = lenghtForColumns - 1;
            int maxIndexY = lenghtForRows - 1;

            if (lastIndexXForOtherCubePlay < maxIndexX && lastIndexYForOtherCubePlay < maxIndexY)
            {
                int lengthToCheck = maxIndexX - lastIndexXForOtherCubePlay;
                int currentX = lastIndexXForOtherCubePlay;
                int currentY = lastIndexYForOtherCubePlay;

                for (int i = 0; i < lengthToCheck; i++)
                {
                    if (currentX > 0 && currentY < maxIndexY)
                    {
                        currentX = currentX - 1;
                        currentY = currentY + 1;                    
                    }
                }

                minIndexToCheck = currentX;
                return minIndexToCheck;
            }
            else
            {
                minIndexToCheck = lastIndexXForOtherCubePlay;
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
            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();

            //string tagCubePlayGameOver = tagCubePlayDictionary[4];
            string tagCubePlayGameOver = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagGameOver();
            //string tagCubePlayGameWin = tagCubePlayDictionary[5];
            string tagCubePlayGameWin = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagGameWin();

            int[,]  winnerCoordinateXYForCubePlay = (int[,])listCheckerForWinner[1];
            string winnerKindOfChecker = (string)listCheckerForWinner[2];

            //Dictionary<int, string> checkerDictionary = GameDictionariesGameFieldsVerification.DictionaryChecker();

            //string checkerHorizontal = checkerDictionary[1];
            //string checkerVertical = checkerDictionary[2];
            //string checkerSlash = checkerDictionary[3];
            //string checkerBackslash = checkerDictionary[4];

            string checkerHorizontal = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerHorizontal();
            string checkerVertical = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerVertical();
            string checkerSlash = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerSlash();
            string checkerBackslash = GameFieldsVerificationCommonMethods.GetFieldsVerificationCheckerBackslash();

            Material winColourForCubePlay = cubePlayColourWin[0];

            int dictionaryColorId = 2;
            Color newTextColor = GameCommonMethodsMain.GetNewColor(dictionaryColorId);

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
