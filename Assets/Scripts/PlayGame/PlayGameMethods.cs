using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static void ChangeTagForGameObject(GameObject gameObject , string tagName)
        {
            gameObject.transform.tag = tagName;
        }

        public static void ChangeTagForGameObject(RaycastHit touchGameObject, string tagName)
        {
            touchGameObject.collider.transform.tag = tagName;
        }


        public static void ChangeCoordinateZForAllCubePlay(GameObject[,,] table)
        {
            GameObject cubePlay;
            float newCoordinateZ = 0;

            int lenghtForDepths = table.GetLength(0);
            int lenghtForRows = table.GetLength(1);
            int lenghtForColumns = table.GetLength(2);

            for (int indexDepth = 0; indexDepth < lenghtForDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < lenghtForRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < lenghtForColumns; indexColumn++)
                    {
                        cubePlay = table[indexDepth, indexRow, indexColumn];

                        
                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZ);
                    }
                }
            }

        }

    }
}
