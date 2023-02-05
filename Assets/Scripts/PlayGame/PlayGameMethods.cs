using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGame;
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

        private static float _newCoordinateZForWinner = -0.5f;


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

        public static void ChangeWinnerCubePlayForChecker(GameObject[,,] gameBoard, int[,] _winnerCoordinateXYForCubePlay, string _tagCubePlayGameWin, GameObject prefabCubePlayFrame)
        {
            GameObject cubePlay;
            int indexDepth = 0;

            int winnerLenghtForColumns = _winnerCoordinateXYForCubePlay.GetLength(0);

            for (int indexColumnsWinner = 0; indexColumnsWinner < winnerLenghtForColumns; indexColumnsWinner++)
            {
                int coordinateYToMark = _winnerCoordinateXYForCubePlay[indexColumnsWinner, 0];
                int coordinateXToMark = _winnerCoordinateXYForCubePlay[indexColumnsWinner, 1];
                cubePlay = gameBoard[indexDepth, coordinateYToMark, coordinateXToMark];

                CommonMethods.SetUpNewZForGameObject(cubePlay, _newCoordinateZForWinner);
                CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameWin);
                CreateGameBoard.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, true);

            }

        }



        /*
        public static void ChangeWinnerCubePlayForCheckerHorizontal(GameObject[,,] gameBoard, int[,] _winnerCoordinateXYForCubePlay, string _tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;

            // _winnerCoordinateXYForCubePlay
            //  int winnerLenghtForColumns = _winnerCoordinateXYForCubePlay.GetLength(1);
            int winnerLenghtForColumns = _winnerCoordinateXYForCubePlay.GetLength(0);

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
        */

        public static void ChangeOtherCubePlayForCheckerHorizontal(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
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
                        CommonMethods.SetUpNewZForGameObject(cubePlay, _newCoordinateZForWinner);
                        CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);
                        CreateGameBoard.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, true);

                    }
                    else
                    {
                        break;

                    }

                }
            }

        }

        public static void ChangeAllCubePlayForCheckerHorizontal(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
        {
            //ChangeWinnerCubePlayForCheckerHorizontal(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
            ChangeOtherCubePlayForCheckerHorizontal(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
        }







        /*
        public static void ChangeWinnerCubePlayForCheckerVertical(GameObject[,,] gameBoard, int[,] _winnerCoordinateXYForCubePlay, string _tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;

            // _winnerCoordinateXYForCubePlay
            int winnerLenghtForRows = _winnerCoordinateXYForCubePlay.GetLength(0);

            for (int indexRowWinner = 0; indexRowWinner < winnerLenghtForRows; indexRowWinner++)
            {
                int coordinateYToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 0];
                int coordinateXToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 1];

                cubePlay = gameBoard[indexDepth, coordinateYToMark, coordinateXToMark];
  
                CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameWin);

            }

        }
        */

        public static void ChangeOtherCubePlayForCheckerVertical(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
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
                        CommonMethods.SetUpNewZForGameObject(cubePlay, _newCoordinateZForWinner);
                        CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);
                        CreateGameBoard.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, true);
                    }
                    else
                    {
                        break;

                    }

                }
            }

        }

        public static void ChangeAllCubePlayForCheckerVertical(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
        {
            //ChangeWinnerCubePlayForCheckerVertical(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);

            ChangeOtherCubePlayForCheckerVertical(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
        }





        /*
        public static void ChangeWinnerCubePlayForCheckerBackslash(GameObject[,,] gameBoard, int[,] _winnerCoordinateXYForCubePlay, string _tagCubePlayGameWin)
        {
            GameObject cubePlay;
            //float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;

            int winnerLenghtForRows = _winnerCoordinateXYForCubePlay.GetLength(0);

            for (int indexRowWinner = 0; indexRowWinner < winnerLenghtForRows; indexRowWinner++)
            {
                int coordinateYToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 0];
                int coordinateXToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 1];

                cubePlay = gameBoard[indexDepth, coordinateYToMark, coordinateXToMark];

                CommonMethods.SetUpNewZForGameObject(cubePlay, _newCoordinateZForWinner);
                CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameWin);

            }
        }
        */

        public static void ChangeOtherCubePlayForCheckerBackslash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
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

            int minIndexXToCheck = SetUpMinIndexXForCheckerBackslash( firstIndexYForOtherCubePlay, firstIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);
            Debug.Log("minIndexXToCheck = " + minIndexXToCheck);

            //int startIndexYForOtherCubePlay = coordinateYToMarkOther;
            //int startIndexXForOtherCubePlay = coordinateXToMarkOther;

            int y;
            int x;

            int[] newIndexY = new int[1];
            newIndexY[0] = startIndexYForOtherCubePlay;

            int[] newIndexX = new int[1];
            newIndexX[0] = startIndexXForOtherCubePlay;

            for (int i = startIndexXForOtherCubePlay - 1 ; i >= minIndexXToCheck; i--)
            {
                y = newIndexY[0] + 1;
                newIndexY[0] = y;

                x = newIndexX[0] - 1;
                newIndexX[0] = x;

                cubePlay = gameBoard[indexDepth, y, x];

                string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);

                if (playerSymbol.Equals(symbolToCompare))
                {
                   CommonMethods.SetUpNewZForGameObject(cubePlay, _newCoordinateZForWinner);
                   CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);
                   CreateGameBoard.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, true);

                }
                else
                {
                   break;

                }

            }

        }

        public static int SetUpMinIndexXForCheckerBackslash( int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay, int maxIndexYForGameBoard, int maxIndexXForGameBoard)
        {
            int minIndexXToCheck;

            int maxIndexYCountedForOtherCubePlay = firstIndexYForOtherCubePlay + maxIndexXForGameBoard;

            if (firstIndexXForOtherCubePlay == maxIndexXForGameBoard)
            {

                if (maxIndexYCountedForOtherCubePlay <= maxIndexYForGameBoard)
                {
                    int difference = 0;
                    minIndexXToCheck = difference;
                    return minIndexXToCheck;

                }
                else
                {
                    int difference = maxIndexYCountedForOtherCubePlay - maxIndexYForGameBoard;
                    minIndexXToCheck = difference;
                    return minIndexXToCheck;

                }

            }
            else
            {
                return minIndexXToCheck = 0;

            }

        }

        public static void ChangeAllCubePlayForCheckerBackslash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
        {
            //ChangeWinnerCubePlayForCheckerBackslash(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);

            ChangeOtherCubePlayForCheckerBackslash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
        }


















        /*
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
        }
        */
        public static void ChangeOtherCubePlayForCheckerSlash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
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

            int maxIndexXToCheck = SetUpMinIndexXForCheckerSlash(lenghtForColumns, firstIndexYForOtherCubePlay, firstIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);
            Debug.Log("maxIndexXToCheck = " + maxIndexXToCheck);

            int y;
            int x;

            int[] newIndexY = new int[1];
            newIndexY[0] = startIndexYForOtherCubePlay;

            int[] newIndexX = new int[1];
            newIndexX[0] = startIndexXForOtherCubePlay;

            for (int i = startIndexXForOtherCubePlay; i < maxIndexXToCheck; i++)
            {
                Debug.Log(" i  = " + i);
                y = newIndexY[0] + 1;
                newIndexY[0] = y;

               Debug.Log(" y " + y);

                x = newIndexX[0] + 1;
                newIndexX[0] = x;

                cubePlay = gameBoard[indexDepth, y, x];

                string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);

                if (playerSymbol.Equals(symbolToCompare))
                {
                    CommonMethods.SetUpNewZForGameObject(cubePlay, _newCoordinateZForWinner);
                    CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);
                    CreateGameBoard.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, true);

                }
                else
                {
                    break;

                }

            }

        }

        public static int SetUpMinIndexXForCheckerSlash(int lenghtForColumns, int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay, int maxIndexYForGameBoard, int maxIndexXForGameBoard)
        {
            int maxIndexXToCheck;
            int maxIndexXCountedForOtherCubePlay = firstIndexXForOtherCubePlay + maxIndexXForGameBoard;

            if (firstIndexXForOtherCubePlay > 0)
            {
                Debug.Log(" 1 ");
                if (maxIndexXCountedForOtherCubePlay <= maxIndexYForGameBoard)
                {
                    Debug.Log(" 2 ");
                    int difference = 0;
                    maxIndexXToCheck = difference;
                    return maxIndexXToCheck;

                }
                else
                {
                    Debug.Log(" 3 ");
                    int difference = maxIndexXForGameBoard;
                    maxIndexXToCheck = difference;
                    return maxIndexXToCheck;

                }

            }
            else
            {
                Debug.Log(" 4 ");
                maxIndexXToCheck = (lenghtForColumns - 1 ) - firstIndexYForOtherCubePlay - 1;
                return maxIndexXToCheck;

            }
        }

        public static void ChangeAllCubePlayForCheckerSlash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
        {
            //ChangeWinnerCubePlayForCheckerSlash(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin);

            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);

            ChangeOtherCubePlayForCheckerSlash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
        }






        public static void ChangeAllCubePlayAfterWin(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string winnerKindOfChecker, string tagCubePlayGameWin, string tagCubePlayGameOver, GameObject prefabCubePlayFrame)
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
                ChangeAllCubePlayForCheckerHorizontal(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
            }

            // checkerVertical
            if (winnerKindOfChecker.Equals(checkerVertical))
            {
                ChangeAllCubePlayForCheckerVertical(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
            }


            // checkerSlash
            if (winnerKindOfChecker.Equals(checkerSlash))
            {
                ChangeAllCubePlayForCheckerSlash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
            }

            // checkerBackslash
            if (winnerKindOfChecker.Equals(checkerBackslash))
            {
                ChangeAllCubePlayForCheckerBackslash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
            }
           
        }












    }


}
