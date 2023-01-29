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




        public static void ChangeAllCubePlay(GameObject[,,] gameBoard, string _tagCubePlayGameOver, int[,] _winnerCoordinateXYForCubePlay, string _tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForAll = 0;
            float newCoordinateZForWinner = -0.5f;

            //Debug.Log(" 4 ");
            // gameBoard
            int lenghtForDepths = gameBoard.GetLength(0);
            int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);

            // _winnerCoordinateXYForCubePlay
            int winnerLenghtForRows = _winnerCoordinateXYForCubePlay.GetLength(0);
            int winnerLenghtForColumns = _winnerCoordinateXYForCubePlay.GetLength(1);

            for (int indexDepth = 0; indexDepth < lenghtForDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < lenghtForRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < lenghtForColumns; indexColumn++)
                    {

                        cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                       // Debug.Log($"gameBoard[{indexDepth}, {indexRow}, {indexColumn}] = " + gameBoard[indexDepth, indexRow, indexColumn]);

                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForAll);
                        CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameOver);


                    }
                }
            }



            /*
            for (int indexRowWinner = 0; indexRowWinner < winnerLenghtForRows; indexRowWinner++)
            {
                for (int indexColumnWinner = 0; indexColumnWinner < winnerLenghtForColumns; indexColumnWinner++)
                {

                    Debug.Log($"winner[{indexRowWinner}, {indexColumnWinner}] = " + _winnerCoordinateXYForCubePlay[indexRowWinner, indexColumnWinner]);



                }
            }
            */








        }

        public static void ChangeWinnerCubePlay(GameObject[,,] gameBoard, string _tagCubePlayGameOver, int[,] _winnerCoordinateXYForCubePlay, string _tagCubePlayGameWin)
        {
            GameObject cubePlay;
            float newCoordinateZForAll = 0;
            float newCoordinateZForWinner = -0.5f;
            int indexDepth = 0;

            //Debug.Log(" 4 ");
            // gameBoard
            int lenghtForDepths = gameBoard.GetLength(0);
            int lenghtForRows = gameBoard.GetLength(1);
            int lenghtForColumns = gameBoard.GetLength(2);

            // _winnerCoordinateXYForCubePlay
            int winnerLenghtForRows = _winnerCoordinateXYForCubePlay.GetLength(0);
            int winnerLenghtForColumns = _winnerCoordinateXYForCubePlay.GetLength(1);



            for (int indexRowWinner = 0; indexRowWinner < winnerLenghtForRows; indexRowWinner++)
            {
                //for (int indexColumnWinner = 0; indexColumnWinner < winnerLenghtForColumns; indexColumnWinner++)
                //{
                    int coordinateYToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 0];
                    int coordinateXToMark = _winnerCoordinateXYForCubePlay[indexRowWinner, 1];

                    cubePlay = gameBoard[indexDepth, coordinateYToMark, coordinateXToMark];
                     //Debug.Log($"gameBoard[{indexDepth}, {indexRow}, {indexColumn}] = " + gameBoard[indexDepth, indexRow, indexColumn]);

                     //Debug.Log("indexColumn -> " + indexColumn + " = " + indexColumnWinner + " <- indexColumnWinner");

                     //Debug.Log($"winner[{indexRowWinner}, {indexColumnWinner}] = " + _winnerCoordinateXYForCubePlay[indexRowWinner, indexColumnWinner]);

                     CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                     CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameWin);

            }

            // start
            int coordinateYToMarkOther = _winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0];
            Debug.Log("coordinateYToMarkOther = " + coordinateYToMarkOther);

            int coordinateXToMarkOther = _winnerCoordinateXYForCubePlay[0, 1];
            Debug.Log("coordinateXToMarkOther = " + coordinateXToMarkOther);

            //Debug.Log("winnerLenghtForRows - 1 = " + (winnerLenghtForRows - 1));
            //Debug.Log("lenghtForRows - 1  = " + (lenghtForRows - 1));
            //Debug.Log("winnerLenghtForRows - 1 = " + (winnerLenghtForRows - 1));
            string playerSymbol = "x";

            if (_winnerCoordinateXYForCubePlay[winnerLenghtForRows - 1, 0] < lenghtForRows - 1)
            {
                for (int i = coordinateYToMarkOther + 1; i < (lenghtForRows); i++)
                {
                    Debug.Log("i = " + i);

                    cubePlay = gameBoard[indexDepth, i, coordinateXToMarkOther];
                    var cubePlayText = cubePlay.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                    string symbolToCompare = cubePlayText.text;
                    Debug.Log("symbolToCompare = " + symbolToCompare);

                    if (playerSymbol.Equals(symbolToCompare))
                    {
                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZForWinner);
                        CommonMethods.ChangeTagForGameObject(cubePlay, _tagCubePlayGameWin);
                    }

                   

                }
            }





        }


    }
}
