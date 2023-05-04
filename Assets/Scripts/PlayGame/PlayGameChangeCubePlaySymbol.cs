using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameChangeCubePlaySymbol
    {
        /*
        public static void GameChangeTextForCubePlay(GameObject cubePlay, string cubePlayText)
        {
                CommonMethods.ChangeTextForCubePlay(cubePlay, cubePlayText);
        }
        */


        public static int[] SetUpCurrentPlayer(int[] currentPlayer, int currentPlayerNumber, int playersNumberGivenForConfiguration)
        {
            //int[] newCurrentPlayer = new int[1];
            //   if (currentPlayerNumber < playersNumberGivenForConfiguration - 1)
            //if (currentPlayerNumber < playersNumberGivenForConfiguration)
            //Debug.Log("CC currentPlayerNumber = " + currentPlayerNumber);
            //Debug.Log("CC playersNumberGivenForConfiguration = " + (playersNumberGivenForConfiguration  - 1));

            if (currentPlayerNumber < playersNumberGivenForConfiguration - 1)
            {
                currentPlayer[0] = currentPlayer[0] + 1;
                //Debug.Log("CC if currentPlayer[0] = " + currentPlayer[0]);
                return currentPlayer;
            } 
            else
            {
                currentPlayer[0] = 0;
                //Debug.Log("CC else currentPlayer[0] = " + currentPlayer[0]);
                return currentPlayer;
            }

        }

        public static Tuple<Tuple<int, int, int>, string> SetUpPlayerSymbolForCubePlay(GameObject[,,] gameBoard, string cubePlayName, string[] playersSymbols, int currentPlayerNumber)
        {
            Color symbolColor = CommonMethods.GetNewColor(2);
            string symbol = PlayGameMethods.GetPlayerSymbol(playersSymbols, currentPlayerNumber);

            var cubePlayDataZYX = CommonMethods.GetIndexZYXForGameObject(gameBoard, cubePlayName);
            int cubePlayIndexZ = cubePlayDataZYX.Item1;
            int cubePlayIndexY = cubePlayDataZYX.Item2;
            int cubePlayIndexX = cubePlayDataZYX.Item3;

            GameObject cubePlay = gameBoard[cubePlayIndexZ, cubePlayIndexY, cubePlayIndexX];

            CommonMethods.ChangeTextForCubePlay(cubePlay, symbol);
            CommonMethods.ChangeTextColourForCubePlay(cubePlay, symbolColor);

            return Tuple.Create(cubePlayDataZYX, symbol);
        }
    
    }
}
