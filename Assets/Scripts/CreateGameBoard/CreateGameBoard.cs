using UnityEngine;

namespace Assets.Scripts
{
    internal class CreateGameBoard : MonoBehaviour
    {
        public static GameObject[,,] CreateBoardGame(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateGameBoardMethods.CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);     
            tableWithNumber = CreateTableMainMethodsForGame.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode, defaultTextForPrefabCubePlay);
            CreateGameBoardMethods.ChangeDataForBoardGameAtStart(tableWithNumber);
            return tableWithNumber;
        }
    }
}
