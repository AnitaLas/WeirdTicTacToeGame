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
        private static bool _isGame2D = true;
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


        public static void ChangeAllCubePlay(GameObject[,,] gameBoard, string tagCubePlayGameOver)
        {
            float newCoordinateZForAll = 0;
            GameObject cubePlay;

            //Dictionary<int, Tuple<float, float, float, float>> colorDictionary = GameDictionariesCommon.DictionaryColor();
            //var newColor = colorDictionary[1];
            //float r = newColor.Item1;
            //float g = newColor.Item2;
            //float b = newColor.Item3;
            //float a = newColor.Item4;
            //Color newTextColor = new Color(r, g, b, a);

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
                       
                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForAll);
                        CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameOver);
                        CommonMethods.ChangeTextColourForCubePlay(cubePlay, newTextColor);

                    }
                }
            }


        }

        public static void ChangeWinnerCubePlayForChecker(GameObject[,,] gameBoard, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
        {
            GameObject cubePlay;
            int indexDepth = 0;
            //float newFontSize = 0.7f;
            float newFontSize = 0.65f;

            //Dictionary<int, Tuple<float, float, float, float>> colorDictionary = GameDictionariesCommon.DictionaryColor();
            //var newColor = colorDictionary[2];
            //float r = newColor.Item1;
            //float g = newColor.Item2;
            //float b = newColor.Item3;
            //float a = newColor.Item4;
            //Color newTextColor = new Color(r, g, b, a);

            int dictionaryColorId = 2;
            Color newTextColor = CommonMethods.GetNewColor(dictionaryColorId);

            int winnerLenghtForColumns = winnerCoordinateXYForCubePlay.GetLength(0);

            for (int indexColumnsWinner = 0; indexColumnsWinner < winnerLenghtForColumns; indexColumnsWinner++)
            {
                int coordinateYToMark = winnerCoordinateXYForCubePlay[indexColumnsWinner, 0];
                int coordinateXToMark = winnerCoordinateXYForCubePlay[indexColumnsWinner, 1];
                cubePlay = gameBoard[indexDepth, coordinateYToMark, coordinateXToMark];

                CommonMethods.SetUpNewZForGameObject(cubePlay, _newCoordinateZForWinner);
                CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);
                CommonMethods.ChangeTextColourForCubePlay(cubePlay, newTextColor);
                CommonMethods.ChangeTextFontSize(cubePlay, newFontSize);
                CreateGameBoard.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, _isGame2D);

            }


            //for (int i = 0; i < _winnerCoordinateXYForCubePlay.GetLength(0); i++)
            //{
            //    for (int j = 0; j < _winnerCoordinateXYForCubePlay.GetLength(1); j++)
            //    {

            //        Debug.Log($"winnerCoordinateXYForCubePlay[{i}, {j},] = " + _winnerCoordinateXYForCubePlay[i, j]);


            //    }
            //}

            //Debug.Log(" ------------------------------------------------ ");
        }

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
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
            ChangeOtherCubePlayForCheckerHorizontal(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
        }




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
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
            ChangeOtherCubePlayForCheckerVertical(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
        }





      
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

            for (int i = 0; i < winnerCoordinateXYForCubePlay.GetLength(0); i++)
            {
                for (int j = 0; j < winnerCoordinateXYForCubePlay.GetLength(1); j++)
                {

                    Debug.Log($"winnerCoordinateXYForCubePlay[{i}, {j},] = " + winnerCoordinateXYForCubePlay[i, j]);


                }
            }

            Debug.Log(" ------------------------------------------------ ");

            int minIndexXToCheck = SetUpMinIndexXForCheckerBackslash( firstIndexYForOtherCubePlay, firstIndexXForOtherCubePlay, maxIndexYForGameBoard, maxIndexXForGameBoard);
            Debug.Log("minIndexXToCheck = " + minIndexXToCheck);

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
                    CommonMethods.SetUpNewZForGameObject(cubePlay, _newCoordinateZForWinner);
                    CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);
                    CreateGameBoard.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, true);

                }
                else
                {
                    break;

                }





                //for (int i = startIndexXForOtherCubePlay - 1 ; i >= minIndexXToCheck; i--)
                //{
                //    y = newIndexY[0] + 1;
                //    newIndexY[0] = y;

                //    x = newIndexX[0] - 1;
                //    newIndexX[0] = x;

                //    cubePlay = gameBoard[indexDepth, y, x];

                //    string symbolToCompare = CommonMethods.GetCubePlayPlayerSymbol(cubePlay);

                //    if (playerSymbol.Equals(symbolToCompare))
                //    {
                //       CommonMethods.SetUpNewZForGameObject(cubePlay, _newCoordinateZForWinner);
                //       CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayGameWin);
                //       CreateGameBoard.CreateCubePlayFrame(prefabCubePlayFrame, cubePlay, true);

                //    }
                //    else
                //    {
                //       break;

                //    }

            }

    }

        public static int SetUpMinIndexXForCheckerBackslash( int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay, int maxIndexYForGameBoard, int maxIndexXForGameBoard)
        {
            int minIndexXToCheck;
            int maxIndexYCountedForOtherCubePlay = firstIndexXForOtherCubePlay + firstIndexYForOtherCubePlay;
            //int maxIndexToCheck = CommonMethods.CheckAndReturnLowerNumber(maxIndexXForGameBoard, maxIndexXForGameBoard);

            //int maxIndexYCountedForOtherCubePlay = firstIndexYForOtherCubePlay + maxIndexXForGameBoard;

           // int maxIndexYCountedForOtherCubePlay = firstIndexXForOtherCubePlay + maxIndexToCheck;

            //Debug.Log("maxIndexYCountedForOtherCubePlay = " + maxIndexYCountedForOtherCubePlay);
            //Debug.Log("firstIndexYForOtherCubePlay = " + firstIndexYForOtherCubePlay);
            //Debug.Log("firstIndexXForOtherCubePlay = " + firstIndexXForOtherCubePlay);
            //Debug.Log("maxIndexXForGameBoard = " + maxIndexXForGameBoard);
            //Debug.Log("maxIndexYForGameBoard = " + maxIndexYForGameBoard);

            // min zamienic na max
            if (firstIndexXForOtherCubePlay == 0)
            {
                if (maxIndexYCountedForOtherCubePlay <= maxIndexYForGameBoard)
                {
                    Debug.Log(" b1 ");
                    minIndexXToCheck = maxIndexYCountedForOtherCubePlay - maxIndexYForGameBoard;
                    return minIndexXToCheck;

                }
                else
                {
                    Debug.Log(" b2 ");
                    minIndexXToCheck = maxIndexYCountedForOtherCubePlay - maxIndexYForGameBoard;
                    return minIndexXToCheck;

                }
            }
            else
            {

                if (maxIndexYCountedForOtherCubePlay <= maxIndexYForGameBoard)
                {
                    Debug.Log(" b3 ");
                    //minIndexXToCheck = firstIndexYForOtherCubePlay + firstIndexXForOtherCubePlay - maxIndexYForGameBoard;
                    minIndexXToCheck = 0;
                    return minIndexXToCheck;
                }
                else
                {
                    Debug.Log(" b4 ");
                    minIndexXToCheck = firstIndexYForOtherCubePlay + firstIndexXForOtherCubePlay - maxIndexYForGameBoard;
                    //minIndexXToCheck = maxIndexXForGameBoard - firstIndexXForOtherCubePlay; 
                    return minIndexXToCheck;

                }
            }
        }

        public static void ChangeAllCubePlayForCheckerBackslash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
        {
            ChangeWinnerCubePlayForChecker(gameBoard, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
            ChangeOtherCubePlayForCheckerBackslash(gameBoard, playerSymbol, winnerCoordinateXYForCubePlay, tagCubePlayGameWin, prefabCubePlayFrame);
        }


















      
        public static void ChangeOtherCubePlayForCheckerSlash(GameObject[,,] gameBoard, string playerSymbol, int[,] winnerCoordinateXYForCubePlay, string tagCubePlayGameWin, GameObject prefabCubePlayFrame)
        {
            GameObject cubePlay;
            int indexDepth = 0;

            //for (int i = 0; i < winnerCoordinateXYForCubePlay.GetLength(0); i++)
            //{
            //    for (int j = 0; j < winnerCoordinateXYForCubePlay.GetLength(1); j++)
            //    {

            //            Debug.Log($"winnerCoordinateXYForCubePlay[{i}, {j},] = " + winnerCoordinateXYForCubePlay[i, j]);
                    

            //    }
            //}
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
            Debug.Log("maxIndexXToCheck = " + maxIndexXToCheck);

            int y;
            int x;

            int[] newIndexY = new int[1];
            newIndexY[0] = startIndexYForOtherCubePlay;

            int[] newIndexX = new int[1];
            newIndexX[0] = startIndexXForOtherCubePlay;

            for (int i = startIndexXForOtherCubePlay; i < maxIndexXToCheck; i++)
            {
               // Debug.Log(" i  = " + i);
                y = newIndexY[0] + 1;
                newIndexY[0] = y;

               //Debug.Log(" y " + y);

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

        public static int SetUpMinIndexXForCheckerSlash(int lenghtForRows, int lenghtForColumns, int firstIndexYForOtherCubePlay, int firstIndexXForOtherCubePlay, int maxIndexYForGameBoard, int maxIndexXForGameBoard)
        {
            int maxIndexXToCheck;
            int maxIndexYCountedForOtherCubePlay = firstIndexYForOtherCubePlay + maxIndexYForGameBoard;
            //int maxIndexYCountedForOtherCubePlay = firstIndexYForOtherCubePlay + maxIndexYForGameBoard;
            //int maxIndexYCountedForOtherCubePlay = maxIndexYForGameBoard;
            //Debug.Log("maxIndexYCountedForOtherCubePlay = " + maxIndexYCountedForOtherCubePlay);
            //Debug.Log("firstIndexYForOtherCubePlay = " + firstIndexYForOtherCubePlay);
            //Debug.Log("firstIndexXForOtherCubePlay = " + firstIndexXForOtherCubePlay);
            //Debug.Log("maxIndexXForGameBoard = " + maxIndexXForGameBoard);
            //Debug.Log("maxIndexYForGameBoard = " + maxIndexYForGameBoard);

            if (firstIndexXForOtherCubePlay == 0)
            {
               
                if (maxIndexYCountedForOtherCubePlay <= maxIndexXForGameBoard)
                {
                    Debug.Log(" 1 ");
                    // int difference = 0;
                    maxIndexXToCheck = maxIndexXForGameBoard - firstIndexYForOtherCubePlay - 1;
                    return maxIndexXToCheck;

                }
                else
                {
                    Debug.Log(" 2 ");
                    //int difference = maxIndexXForGameBoard;
                    // maxIndexXToCheck = maxIndexXForGameBoard - firstIndexXForOtherCubePlay;
                    maxIndexXToCheck = maxIndexXForGameBoard - firstIndexYForOtherCubePlay - 1;


                    // int difference = maxIndexXCountedForOtherCubePlay - firstIndexXForOtherCubePlay - 1;
                    // Debug.Log("maxIndexXCountedForOtherCubePlay = " + maxIndexXCountedForOtherCubePlay);
                    // Debug.Log("firstIndexXForOtherCubePlay = " + firstIndexXForOtherCubePlay);
                    //Debug.Log("difference = " + difference);
                    return maxIndexXToCheck;
                }

            }
            else
            {
                if (maxIndexYCountedForOtherCubePlay <= maxIndexXForGameBoard)
                {
                    Debug.Log(" 3 ");
                    // int difference = 0;
                    //maxIndexXToCheck = maxIndexXForGameBoard - firstIndexYForOtherCubePlay;
                    // maxIndexXToCheck = firstIndexYForOtherCubePlay + firstIndexXForOtherCubePlay;// - maxIndexYForGameBoard;
                    //maxIndexXToCheck =  maxIndexYForGameBoard - firstIndexYForOtherCubePlay + firstIndexXForOtherCubePlay;
                    maxIndexXToCheck = maxIndexXForGameBoard;


                    return maxIndexXToCheck;

                }
                else
                {
                    Debug.Log(" 4 ");
                    // maxIndexXToCheck = maxIndexXForGameBoard;
                    //maxIndexXToCheck = maxIndexYForGameBoard - firstIndexYForOtherCubePlay;
                    //maxIndexXToCheck = maxIndexXForGameBoard - firstIndexYForOtherCubePlay - firstIndexXForOtherCubePlay;
                    //maxIndexXToCheck = maxIndexXForGameBoard - (maxIndexYForGameBoard - firstIndexYForOtherCubePlay) - firstIndexXForOtherCubePlay;
                    //maxIndexXToCheck =maxIndexYForGameBoard - firstIndexYForOtherCubePlay;
                    //maxIndexXToCheck = firstIndexYForOtherCubePlay;
                    maxIndexXToCheck = maxIndexYForGameBoard - firstIndexYForOtherCubePlay + firstIndexXForOtherCubePlay;

                    // int difference = maxIndexXCountedForOtherCubePlay - firstIndexXForOtherCubePlay - 1;
                    // Debug.Log("maxIndexXCountedForOtherCubePlay = " + maxIndexXCountedForOtherCubePlay);
                    // Debug.Log("firstIndexXForOtherCubePlay = " + firstIndexXForOtherCubePlay);
                    //Debug.Log("difference = " + difference);
                    return maxIndexXToCheck;
                }

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
