using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CreateGameBoard : MonoBehaviour
    {
        //public static GameObject[,,] CreateBoardGame(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode, int numberOfGaps)
        public static ArrayList CreateBoardGame(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode, int numberOfGaps)
        {
            //int numberOfGaps = 2;
            GameObject[,,] boardGame;
            GameObject cubePlayForFrame;
            float[] coordinatesForCubePlayFrame;
            ArrayList dataForBoardGame = new ArrayList();

            boardGame = CreateBoardGameStandard(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode);

            cubePlayForFrame = boardGame[0, numberOfRows - 1, 0];
            float x = cubePlayForFrame.transform.position.x;
            float y = cubePlayForFrame.transform.position.y;
            float z = cubePlayForFrame.transform.position.z;

            //Debug.Log("x: " + x);
            //Debug.Log("y: " + y);
            //Debug.Log("z: " + z);

            coordinatesForCubePlayFrame = new float[] { x, y, z };

            if (numberOfGaps > 0)
            {
                //int numbersCubePlayMax = numberOfDepths * numberOfColumns * numberOfRows;
                boardGame = CreateBoardGameWithGaps(boardGame, numberOfDepths, numberOfColumns, numberOfRows, numberOfGaps);
            }
            dataForBoardGame.Insert(0, boardGame);
            dataForBoardGame.Insert(1, coordinatesForCubePlayFrame);

            
            
            //return boardGame;
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
            string[] cubePlayNumbers = CreateGameBoardWithGaps.SetUpRightCurrentNumberForCubePlay( numbersCubePlayMax, numberOfRows, numberOfGaps);

            //Debug.Log(" ----------------------------   cubePlayNumbers  --------------------------------------");
            //for (int i = 0; i < cubePlayNumbers.Length; i++)
            //{
            //    Debug.Log($"{i} - fullCubePlayName: " + cubePlayNumbers[i]);
            //}

            string[] fullCubePlayName = CreateGameBoardWithGaps.GetFullCubePlayNames(cubePlayNumbers, boardGame);

            //fullCubePlayName[0] = "CubePlayUI_No_004_Table3DCoOrdinates_Depths_0_Row_3_Column_0";
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
