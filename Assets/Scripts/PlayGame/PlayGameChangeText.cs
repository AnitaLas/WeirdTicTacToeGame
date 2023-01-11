using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameChangeText
    {

        public static void GameChangeTextForCubePlay(GameObject cubePlay, string cubePlayText)
        {
                CommonMethods.ChangeTextForCubePlay(cubePlay, cubePlayText);
        }



        public static int[] SetUpCurrentPlayer(int[] currentPlayer, int currentPlayerNumber, int playersNumberGivenForConfiguration)
        {
            int[] newCurrentPlayer = new int[1];
            if (currentPlayerNumber < playersNumberGivenForConfiguration - 1)
            {
                currentPlayer[0] = currentPlayer[0] + 1;
                return currentPlayer;
            } 
            else
            {
                currentPlayer[0] = 0;
                return currentPlayer;
            }

        }
        public static Tuple<Tuple<int, int, int>, string> SetUpPlayerSymbolForCubePlay(GameObject[,,] gameBoard, string cubePlayName, string[] playersSymbols, int currentPlayerNumber)
        {
            //int currentPlayerNumber = currentPlayer[playersNumber];
            string symbol = PlayGameMethods.GetPlayerSymbol(playersSymbols, currentPlayerNumber);

            var cubePlayDataZYX = CommonMethods.GetIndexZYXForGameObject(gameBoard, cubePlayName);
            int cubePlayIndexZ = cubePlayDataZYX.Item1;
            int cubePlayIndexY = cubePlayDataZYX.Item2;
            int cubePlayIndexX = cubePlayDataZYX.Item3;

            GameObject cubePlay = gameBoard[cubePlayIndexZ, cubePlayIndexY, cubePlayIndexX];

            CommonMethods.ChangeTextForCubePlay(cubePlay, symbol);

            return Tuple.Create(cubePlayDataZYX, symbol);
        }

        /*
        public static Tuple<int, int, int> GetIndexZYXForCubePlay(GameObject[,,] gameBoard, string cubePlayName)
        {
            var cubePlayDataZYX = CommonMethods.GetIndexZYXForGameObject(gameBoard, cubePlayName);
            return cubePlayDataZYX;
        }
        */








        /*
        public static int[] SetUpNewCurrentPlayerNumber(int[] currentPlayer, int currentPlayerNumber, int playersNumber)
        {
            int[] newCurrentPlayer = SetUpCurrentPlayer(currentPlayer, currentPlayerNumber, playersNumber);
            return newCurrentPlayer;
        }
        */
    }
}
