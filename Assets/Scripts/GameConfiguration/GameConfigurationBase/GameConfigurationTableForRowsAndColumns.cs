using Assets.Scripts.GameConfiguration.GameConfigurationBase;
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
            GameObject[,,] table;
            int start = 2;
            int end = 10;
            float newCoordinateY = 100f;
            string inactiveText = "-";

            table = GameConfigurationTableForSetUp.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
            return table;

        }

    }
}
