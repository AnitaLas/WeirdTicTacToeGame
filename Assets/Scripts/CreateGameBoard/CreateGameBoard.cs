using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CreateGameBoard : MonoBehaviour
    {
        public static ArrayList CreateBoardGame(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode, int numberOfGaps)
        {
            GameObject[,,] boardGame;
            GameObject cubePlayForFrame;
            float[] coordinatesForCubePlayFrame;
            ArrayList dataForBoardGame = new ArrayList();

            boardGame = CreateBoardGameStandard(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode);

            cubePlayForFrame = boardGame[0, numberOfRows - 1, 0];
            float x = cubePlayForFrame.transform.position.x;
            float y = cubePlayForFrame.transform.position.y;
            float z = cubePlayForFrame.transform.position.z;

            coordinatesForCubePlayFrame = new float[] { x, y, z };

            if (numberOfGaps > 0)
                boardGame = CreateBoardGameWithGaps(boardGame, numberOfDepths, numberOfColumns, numberOfRows, numberOfGaps);

            dataForBoardGame.Insert(0, boardGame);
            dataForBoardGame.Insert(1, coordinatesForCubePlayFrame);

            return dataForBoardGame;
        }

        public static GameObject[,,] CreateBoardGameStandard(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateGameBoardCommonMethods.CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
            tableWithNumber = CreateTableMainMethodsForGame.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode, defaultTextForPrefabCubePlay);
            CreateGameBoardCommonMethods.ChangeDataForBoardGameAtStart(tableWithNumber);
            return tableWithNumber;
        }

        public static GameObject[,,] CreateBoardGameWithGaps(GameObject[,,] boardGame, int numberOfDepths, int numberOfColumns, int numberOfRows, int numberOfGaps)
        {
            int numbersCubePlayMax = numberOfDepths * numberOfColumns * numberOfRows;
            string[] cubePlayNumbers = CreateGameBoardWithGaps.SetUpRightCurrentNumberForCubePlay(numbersCubePlayMax, numberOfRows, numberOfGaps);

            string[] fullCubePlayName = CreateGameBoardWithGaps.GetFullCubePlayNames(cubePlayNumbers, boardGame);

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