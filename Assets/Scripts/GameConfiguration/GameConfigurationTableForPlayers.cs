using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfigurationTableForPlayers
    {

        public static int[] CreateTableWithPlayersNumber(int playersNumber)
        {
            int[] players = new int[playersNumber];

            for (int i = 0; i < playersNumber; i++)
            {
                players[i] = i;
            }

            return players;
        }

        public static GameObject[,,] CreateTableForPlayers(GameObject[,,] tableWtithNumber, string configurationBoardGameInactiveField)
        {
            string text = "-";
            string one = "1";

            int maxIndexDepth = 1;
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
                        string cubePlayText = CommonMethods.GetCubePlayText(cubePlay);

                        if (cubePlayText.Equals(one))
                        {
                            CommonMethods.ChangeTextForCubePlay(cubePlay, text);
                            CommonMethods.ChangeTagForGameObject(cubePlay, configurationBoardGameInactiveField);
                        }

                    }

                }
            }

            return tableWtithNumber;

        }



    }
}
