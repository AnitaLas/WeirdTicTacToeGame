using Assets.Scripts.CreateFrame;
using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayGame
{
    internal class PlayGameChangeCubePlaForWinner
    {
        private static bool _isGame2D = true;
        private static float _newCoordinateZForWinner = -0.5f;


        public static void ChangeOneCubePlay(GameObject cubePlay, float newCoordinateZForAll, string tagCubePlayGameOver, Color newTextColor)
        {
            CommonMethods.ChangeZForGameObject(cubePlay, newCoordinateZForAll);
            CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameOver);
            CommonMethods.ChangeTextColourForCubePlay(cubePlay, newTextColor);
        }

        public static void ChangeAllCubePlay(GameObject[,,] gameBoard, string tagCubePlayGameOver)
        {
            GameObject cubePlay;
            float newCoordinateZForAll = 0;

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

                        ChangeOneCubePlay(cubePlay, newCoordinateZForAll, tagCubePlayGameOver, newTextColor);
                    }
                }
            }


        }

        public static void ChangeOneWinnerCubePlayForChecker(GameObject cubePlay, GameObject prefabCubePlayFrame, Color newTextColor, Material winColourForCubePlay, bool _isGame2D, float newFontSize, string tagCubePlayGameWin)
        {
            CommonMethods.ChangeColourForGameObject(cubePlay, winColourForCubePlay);
            CommonMethods.ChangeZForGameObject(cubePlay, _newCoordinateZForWinner);
            CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);

            CommonMethods.ChangeTextColourForCubePlay(cubePlay, newTextColor);
            CommonMethods.ChangeTextFontSize(cubePlay, newFontSize);

            PlayGameFrameCreate.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, _isGame2D);
        }

        public static void ChangeWinnerCubePlayForChecker(GameObject[,,] gameBoard, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            GameObject cubePlay;
            int indexDepth = 0;
            //float newFontSize = 0.65f;

            //int dictionaryColorId = 2;
            //Color newTextColor = CommonMethods.GetNewColor(dictionaryColorId);

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
            CommonMethods.ChangeZForGameObject(cubePlay, _newCoordinateZForWinner);
            CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);
            CommonMethods.ChangeColourForGameObject(cubePlay, winColourForCubePlay);

            CommonMethods.ChangeTextColourForCubePlay(cubePlay, newTextColor);
            CommonMethods.ChangeTextFontSize(cubePlay, newFontSize);

            PlayGameFrameCreate.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, true);
            
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






        public static void ChangeOtherCubePlayForCheckerBackslash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            GameObject cubePlay;
            int indexDepth = 0;

            int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);

            int winnerLenghtForRows = winnerCoordinateXYForCubePlay.GetLength(0);

            int startIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
            int startIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 1];

            int firstIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
            int firstIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];

            int maxIndexXForGameBoard = lenghtForColumns - 1;
            int maxIndexYForGameBoard = lenghtForRows - 1;

            int minIndexXToCheck = SetUpMinIndexXForCheckerBackslash(firstIndexYForOtherCubePlay, firstIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);

            int y;
            int x;

            int[] newIndexY = new int[1];
            newIndexY[0] = startIndexYForOtherCubePlay;

            int[] newIndexX = new int[1];
            newIndexX[0] = startIndexXForOtherCubePlay;



            for (int i = startIndexXForOtherCubePlay - 1; i >= minIndexXToCheck; i--)
            {
                y = newIndexY[0] + 1;
                newIndexY[0] = y;

                x = newIndexX[0] - 1;
                newIndexX[0] = x;

                cubePlay = gameBoard[indexDepth, y, x];

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

        public static int SetUpMinIndexXForCheckerBackslash(int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay, int maxIndexYForGameBoard, int maxIndexXForGameBoard)
        {
            int minIndexXToCheck;
            int maxIndexYCountedForOtherCubePlay = firstIndexXForOtherCubePlay + firstIndexYForOtherCubePlay;

            if (firstIndexXForOtherCubePlay == 0)
            {
                if (maxIndexYCountedForOtherCubePlay <= maxIndexYForGameBoard)
                {
                    minIndexXToCheck = maxIndexYCountedForOtherCubePlay - maxIndexYForGameBoard;
                    return minIndexXToCheck;

                }
                else
                {
                    minIndexXToCheck = maxIndexYCountedForOtherCubePlay - maxIndexYForGameBoard;
                    return minIndexXToCheck;

                }
            }
            else
            {

                if (maxIndexYCountedForOtherCubePlay <= maxIndexYForGameBoard)
                {
                    minIndexXToCheck = 0;
                    return minIndexXToCheck;
                }
                else
                {
                    minIndexXToCheck = firstIndexYForOtherCubePlay + firstIndexXForOtherCubePlay - maxIndexYForGameBoard;
                    return minIndexXToCheck;

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

            int startIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
            int startIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 1];

            int firstIndexYForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 0];
            int firstIndexXForOtherCubePlay = winnerCoordinateXYForCubePlay[0, 1];

            int maxIndexXForGameBoard = lenghtForColumns - 1;
            int maxIndexYForGameBoard = lenghtForRows - 1;

            int maxIndexXToCheck = SetUpMinIndexXForCheckerSlash(lenghtForRows, lenghtForColumns, firstIndexYForOtherCubePlay, firstIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);

            int y;
            int x;

            int[] newIndexY = new int[1];
            newIndexY[0] = startIndexYForOtherCubePlay;

            int[] newIndexX = new int[1];
            newIndexX[0] = startIndexXForOtherCubePlay;

            for (int i = startIndexXForOtherCubePlay; i < maxIndexXToCheck; i++)
            {
                y = newIndexY[0] + 1;
                newIndexY[0] = y;

                x = newIndexX[0] + 1;
                newIndexX[0] = x;

                cubePlay = gameBoard[indexDepth, y, x];

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

        public static int SetUpMinIndexXForCheckerSlash(int lenghtForRows, int lenghtForColumns, int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay, int maxIndexYForGameBoard, int maxIndexXForGameBoard)
        {
            int maxIndexXToCheck;
            int maxIndexYCountedForOtherCubePlay = firstIndexYForOtherCubePlay + maxIndexYForGameBoard;

            if (firstIndexXForOtherCubePlay == 0)
            {

                if (maxIndexYCountedForOtherCubePlay <= maxIndexXForGameBoard)
                {
                    maxIndexXToCheck = maxIndexXForGameBoard - firstIndexYForOtherCubePlay - 1;
                    return maxIndexXToCheck;

                }
                else
                {
                    maxIndexXToCheck = maxIndexXForGameBoard - firstIndexYForOtherCubePlay - 1;
                    return maxIndexXToCheck;

                }
            }
            else
            {
                if (maxIndexYCountedForOtherCubePlay <= maxIndexXForGameBoard)
                {
                    maxIndexXToCheck = maxIndexXForGameBoard;
                    return maxIndexXToCheck;

                }
                else
                {
                    maxIndexXToCheck = maxIndexYForGameBoard - firstIndexYForOtherCubePlay + firstIndexXForOtherCubePlay;
                    return maxIndexXToCheck;

                }

            }
        }

        public static void ChangeAllCubePlayForCheckerSlash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame, Material winColourForCubePlay, Color newTextColor, float newFontSize)
        {
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
            ChangeOtherCubePlayForCheckerSlash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame, winColourForCubePlay, newTextColor, newFontSize);
        }






        public static void ChangeAllCubePlayAfterWin(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string winnerKindOfChecker, string tagCubePlayGameWin, string tagCubePlayGameOver, GameObject prefabCubePlayFrame, Material[] cubePlayColourWin)
        {
            Dictionary<int, string> checkerDictionary = GameDictionaries.GameDictionariesGameFieldsVerification.DictionaryChecker();

            string checkerHorizontal = checkerDictionary[1];
            string checkerVertical = checkerDictionary[2];
            string checkerSlash = checkerDictionary[3];
            string checkerBackslash = checkerDictionary[4];

            Material winColourForCubePlay = cubePlayColourWin[0];

            int dictionaryColorId = 2;
            Color newTextColor = CommonMethods.GetNewColor(dictionaryColorId);

            float newFontSize = 0.65f;

            ChangeAllCubePlay(gameBoard, tagCubePlayGameOver);

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
