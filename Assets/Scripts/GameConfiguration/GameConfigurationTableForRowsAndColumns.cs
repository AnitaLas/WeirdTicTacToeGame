using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfigurationTableForRowsAndColumns
    {

        public static GameObject[,,] CreateTableForRowsAndColumns(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField)
        {
            string text = "-";
            string one = "1";
            string two = "2";

            float newCoordinateZ = 0.75f;
           // float newCoordinateZ = 0.05f;

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

                        CommonMethods.ChangeTagForGameObject(cubePlay, tagConfigurationBoardGameTableNumberForAll);
                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZ);

                        if (cubePlayText.Equals(one) || cubePlayText.Equals(two))
                        {
                            CommonMethods.ChangeTextForCubePlay(cubePlay, text);
                            CommonMethods.ChangeTagForGameObject(cubePlay, tagConfigurationBoardGameInactiveField);
                        }

                    }

                }
            }

            return tableWtithNumber;

        }

    }
}
