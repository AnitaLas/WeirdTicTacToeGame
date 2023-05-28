using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers
{
    internal class GameConfigurationButtonsWithNNNForPlayersSymbols
    {
        public static GameObject[,,] CreateTableForPlayersSymbols(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField)
        {
            GameObject[,,] table;
            int start = 1;
            int end = 8;
            float newCoordinateY = 100f;
            string inactiveText = "-";

            table = GameConfigurationButtonsWithNumbersCommonMethods.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
            return table;
        }
    }
}
