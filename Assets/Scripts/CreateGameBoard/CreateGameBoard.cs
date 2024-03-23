using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CreateGameBoard : MonoBehaviour
    {
        public static GameObject[,,] CreateBoardGame(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            int numberOfGaps = 2;
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

        public static void DestroySingleGameObjectWithName(string gameObjectName)
        {
            GameObject gameObject = GameCommonMethodsMain.GetObjectByName(gameObjectName);
            Destroy(gameObject);
        }


        //public List<GameObject>
        public static GameObject[,,] CreateBoardGameWithGaps(GameObject[,,] boardGame, int numbersCubePlayMax, int numberOfGaps)
        {
            string[] cubePlayNumbers = CreateGameBoardWithGaps.SetUpRightCurrentNumberForCubePlayToDestroy( numbersCubePlayMax, numberOfGaps);
            int cubePlayNumbersLenght = cubePlayNumbers.Length;

            for (int i = 0; i < cubePlayNumbersLenght; i++)
            {
                string cubePlayName = decimal;
                GameObject cubePlay = CommonMethods.GetObjectByName(cubePlayName);
                DestroySingleGameObjectWithName(cubePlayName);


            }



            //int maxIndexDepth = boardGame.GetLength(0);
            //int maxIndexColumn = boardGame.GetLength(2);
            //int maxIndexRow = boardGame.GetLength(1);

            //Color colour = GameCommonMethodsMain.GetNewColor(3);

            //for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            //{
            //    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
            //    {
            //        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
            //        {
            //            GameObject cubePlay = boardGame[indexDepth, indexRow, indexColumn];
            //            GameCommonMethodsMain.ChangeTextColourForCubePlay(cubePlay, colour);
            //        }
            //    }
            //}


            return boardGame;

        }
    }
}
