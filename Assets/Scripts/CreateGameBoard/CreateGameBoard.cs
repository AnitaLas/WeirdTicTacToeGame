using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CreateGameBoard : MonoBehaviour
    {
        public static GameObject[,,] CreateBoardGame(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode, int numberOfGaps)
        {
            //int numberOfGaps = 2;
            GameObject[,,] boardGame;

            boardGame = CreateBoardGameStandard(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode);

            if (numberOfGaps > 0)
            {
                int numbersCubePlayMax = numberOfDepths * numberOfColumns * numberOfRows;
                boardGame = CreateBoardGameWithGaps(boardGame, numbersCubePlayMax, numberOfGaps);
            }

            return boardGame;
        }

        public static GameObject[,,] CreateBoardGameStandard(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateGameBoardCommonMethods.CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
            tableWithNumber = CreateTableMainMethodsForGame.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode, defaultTextForPrefabCubePlay);
            CreateGameBoardCommonMethods.ChangeDataForBoardGameAtStart(tableWithNumber);
            return tableWithNumber;
        }

        public static GameObject[,,] CreateBoardGameWithGaps(GameObject[,,] boardGame, int numbersCubePlayMax, int numberOfGaps)
        {
            string[] cubePlayNumbers = CreateGameBoardWithGaps.SetUpRightCurrentNumberForCubePlay( numbersCubePlayMax, numberOfGaps);
            string[] fullCubePlayName = CreateGameBoardWithGaps.GetFullCubePlayNames(cubePlayNumbers, boardGame);

            //Debug.Log(" ----------------------------   CreateBoardGameWithGaps  --------------------------------------");
            //for (int i = 0; i < fullCubePlayName.Length; i++)
            //{
            //    Debug.Log($"{i} - fullCubePlayName: " + fullCubePlayName[i]);
            //}

            int cubePlayNumbersLenght = cubePlayNumbers.Length;
                
            for (int i = 0; i < cubePlayNumbersLenght; i++)
            {
                string cubePlayName = fullCubePlayName[i];
                CreateGameBoardWithGaps.CubePlayToHide(cubePlayName);
            }

            return boardGame;

        }
    }
}
