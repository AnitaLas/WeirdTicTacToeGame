using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfigurationTableForPlayersSymbols
    {
        public static GameObject[,,] CreateTableForPlayersSymbols(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField)
        {
            GameObject[,,] table;
            int start = 1;
            int end = 8;
            float newCoordinateY = 100f;
            string inactiveText = "-";

            table = GameConfigurationTableForSetUp.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
            return table;

        }

    }
}
