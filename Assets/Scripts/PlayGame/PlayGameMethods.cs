using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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








    }
}
