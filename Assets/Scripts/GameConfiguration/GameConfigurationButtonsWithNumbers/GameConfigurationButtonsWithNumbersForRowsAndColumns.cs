using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsWithNumbersForRowsAndColumns
    {
        public static GameObject[,,] CreateTableForRowsAndColumns(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField, bool isCellphoneMode)
        {
            GameObject[,,] table;
            int start = 2;
            //int end = 10;
            int end = ScreenVerificationMethods.GetMaxPRowsOrColumnsNumberForConfiguration(isCellphoneMode);
            //float newCoordinateY = 100f;
            float newCoordinateY = 0f;
            string inactiveText = "-";

            table = GameConfigurationButtonsWithNumbersCommonMethods.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end, newCoordinateY, inactiveText);
            return table;

        }
    }
}
