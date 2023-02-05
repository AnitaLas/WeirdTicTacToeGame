using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

namespace Assets.Scripts
{
    internal class CreateGameBoard : MonoBehaviour
    {

        // public static GameObject[,,] CreateBoardGame(GameObject prefab, int numberOfRows, int numberOfColumns, int numberOfDepths, Material[] prefabCubePlayDefaultColour)
        public static GameObject[,,] CreateBoardGame(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns,  Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            // [prefabCubePlay][prefabCubePlayNewZ]
            bool isNumberOfRowsEven = CommonMethods.IsNumberEven(numberOfRows);

            // [prefabCubePlayColor] lenght of array colour assigned to object "GameBoard"
            int cubePlayColourLenght = prefabCubePlayDefaultColour.Length;

            // [prefabCubePlayNewZ]
            float[] coordinateZForPrefabCubePlay = CreateGameBoardMethods.CreateTableWithCoordinatesZ();
            int coordinateZForPrefabCubePlayLenght = coordinateZForPrefabCubePlay.Length;

            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [prefabCubePlay] calculate data for game board - start
            // [prefabCubePlay] calculate new scale for prefab "CubaPlay"
            float newScale = CreateGameBoardPrefabCalculateScale.ScaleForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);

            // [prefabCubePlay] calculate data for first prefab "CubaPlay" X and Y and Z
            float startPositionForPrefabCubePlayXYZ = CreateGameBoardMethods.StartPositionXYZ(newScale);

            // [prefabCubePlay] change the scale for prefab "CubePlay" using a new scale 
            CreateGameBoardPrefabCalculateScale.TransformGameObjectPrefabToNewScale(prefabCubePlay, newScale, newScale, newScale);

            // [prefabCubePlay] finding the lenght for all prefab "CubePlay" in one line for X, Y, Z
            float lengthForAllPrefabCubePlayInOneLineY = CreateGameBoardMethods.CalculateLengthForAllPrefabInOneLineXYZ(numberOfRows, newScale);
            float lengthForAllPrefabCubePlayInOneLineX = CreateGameBoardMethods.CalculateLengthForAllPrefabInOneLineXYZ(numberOfColumns, newScale);
            float lengthForAllPrefabCubePlayInOneLineZ = CreateGameBoardMethods.CalculateLengthForAllPrefabInOneLineXYZ(numberOfDepths, newScale);

            // [prefabCubePlay] finding position X, Y, Z for fisrt prefab "CubePlay"
            float positionForFirstCubePlayX = CreateGameBoardMethods.PositionForFirstPrefab(lengthForAllPrefabCubePlayInOneLineX, startPositionForPrefabCubePlayXYZ);
            float positionForFirstCubePlayY = CreateGameBoardMethods.PositionForFirstPrefab(lengthForAllPrefabCubePlayInOneLineY, startPositionForPrefabCubePlayXYZ);
            float positionForFirstCubePlayZ = CreateGameBoardMethods.PositionForFirstPrefab(lengthForAllPrefabCubePlayInOneLineZ, startPositionForPrefabCubePlayXYZ);

            // [prefabCubePlay] finding position X, Y, Z for last prefab "CubePlay"
            float positionForLastCubePlayX = CreateGameBoardMethods.PositionForLastPrefab(lengthForAllPrefabCubePlayInOneLineX);
            float positionForLastCubePlayY = CreateGameBoardMethods.PositionForLastPrefab(lengthForAllPrefabCubePlayInOneLineY);
            float positionForLastCubePlayZ = CreateGameBoardMethods.PositionForLastPrefab(lengthForAllPrefabCubePlayInOneLineZ);

            // [prefabCubePlay] table wiht number for prefab "CubePlay", number added to prefab as are created in UI (in the same direction),
            int[,,] prefabCubePlayNumbers = CreateGameBoardMethods.CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI(numberOfDepths, numberOfRows, numberOfColumns);

            // [prefabCubePlay] calculate data for game board - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------

            // idenx for  CommonMethods.SetUpNewCurrentNumberByAddition()
            int index = 0;

            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            //[prefabCubePlayName] - start

            // [prefabCubePlayName] change name for prefab "CubePlay"
            int[] numbersCubePlayName = new int[1];
            numbersCubePlayName[0] = 1;

            //[prefabCubePlayName] - end 
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------


            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [prefabCubePlayColor] - start

            // [prefabCubePlayColor] change last index for material -> colour for prefab "CubePlay"
            // variant of material colour assigne to object "GameBoard"
            int[] indexForPreviousCubePlayColour = new int[1];
            indexForPreviousCubePlayColour[0] = 0;

            // [prefabCubePlayColor] change last index for current counted number height for Y
            // max colour number = number columns given by user = number prefab "CubePlay" in one column for Y
            int[] countedNumberCubePlayForRowsForColour = new int[1];
            countedNumberCubePlayForRowsForColour[0] = 0;

            //[prefabCubePlayColor] - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------


            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [prefabCubePlayTextDefault] - start
            // [prefabCubePlayTextDefault] - default text for new prefab "CubePlay"
            string[,,] defaultTextForPrefabCubePlay = CreateGameBoardPrefabDefaultText.CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);

            int[] countedPrefabCubePlay = new int[1];
            countedPrefabCubePlay[0] = 1;

            //[prefabCubePlayTextDefault] - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------


            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [prefabCubePlayNewZ] - start
            int[] indexForCubePlayCoordinateZ = new int[1];
            indexForCubePlayCoordinateZ[0] = 0;

            int[] countedNumberCubePlayForRowsForCoordinateZ = new int[1];
            countedNumberCubePlayForRowsForCoordinateZ[0] = 0;

            //[prefabCubePlayNewZ] - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------


            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [gameBoard] - start

            GameObject[,,] gameBoard = new GameObject[numberOfDepths, numberOfRows, numberOfColumns];

            //int[] currentNumberOfRows = new int[1];
           //currentNumberOfRows[0] = numberOfRows;

            ///int[] currentNumberOfColumns = new int[1];
            //currentNumberOfColumns[0] = 0;

            //int[] currentNumberOfDepths = new int[1];
           // currentNumberOfDepths[0] = 0;

            // [gameBoard] - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------



            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [gameBoard] create game board - start

            for (float x = positionForFirstCubePlayX; x < positionForLastCubePlayX; x = x + newScale)
            {

                for (float y = positionForFirstCubePlayY; y < positionForLastCubePlayY; y = y + newScale)
                 {

                    for (float z = positionForFirstCubePlayZ; z < positionForLastCubePlayZ; z = z + newScale)
                    {
                        // [prefabCubePlayColorDefaul] old data - change colour for new prefab "CubePlay"
                        int currentIndexForPreviousColour = indexForPreviousCubePlayColour[0];
                        int currentCountedNumberForCubeRows = countedNumberCubePlayForRowsForColour[0];

                        // [prefabCubePlayColorDefault] calculate new data - change colour for new prefab "CubePlay"
                        var newDataForCubePlayColour = CreateGameBoardMethods.GetnewCountedNumberForCubeRowsAndNewIndexForTheTableSetting(cubePlayColourLenght, currentIndexForPreviousColour, numberOfRows, currentCountedNumberForCubeRows, isNumberOfRowsEven);

                        int newIndexForCubePlayColour = newDataForCubePlayColour.Item1;
                        int newCountedNumberForCubePlayHeightY = newDataForCubePlayColour.Item2;

                        // [prefabCubePlayColorDefault] new data - change colour for new prefab "CubePlay"
                        indexForPreviousCubePlayColour[0] = newIndexForCubePlayColour;
                        countedNumberCubePlayForRowsForColour[0] = newCountedNumberForCubePlayHeightY;

                        // [prefabCubePlayColorDefault] change colour for new prefab "CubePlay"
                        CreateGameBoardPrefabDefaultColour.ChangeColourForPrefabCubePlay(prefabCubePlay, prefabCubePlayDefaultColour, newIndexForCubePlayColour);

                        //[prefabCubePlayTextDefault] - change text for new prefab "CubePlay"
                        int currentNumberForPrefabCubePlay = countedPrefabCubePlay[0];
                        string prefabCubePlayDefaultText = CreateGameBoardPrefabDefaultText.SetUpNewDefaultTextForPrefaCubePlay(prefabCubePlayNumbers, defaultTextForPrefabCubePlay, currentNumberForPrefabCubePlay);
                        
                        CreateGameBoardPrefabDefaultText.SetUpDefaultTextForPrefaCubePlay(prefabCubePlay, prefabCubePlayDefaultText);

                        //[prefabCubePlayTextDefault] - set up new currentNumberForPrefabCubePlay
                        countedPrefabCubePlay = CommonMethods.SetUpNewCurrentNumberByAddition(countedPrefabCubePlay, index);
                        

                        // create new prefab "CubePlay"
                        var newPrefabCubePlay = Instantiate(prefabCubePlay, new Vector3(x, y, z), Quaternion.identity);
;
                        // [prefabCubePlayName] chcange the name for new prefab "CubePlay"
                        int currentNumberCubePlayName = numbersCubePlayName[0];
                        var currentIndexXYForPrefabCubePlay = CommonMethods.GetIndexZYXForGameObject(prefabCubePlayNumbers, currentNumberCubePlayName);

                        // [prefabCubePlayName]
                        string prefabCubePlayName = CreateGameBoardPrefabName.CreateNameForPrefabCubePlay(currentNumberCubePlayName, currentIndexXYForPrefabCubePlay);
                        newPrefabCubePlay.name = prefabCubePlayName;

                        // [prefabCubePlayName] set up new currentNumberCubePlayName
                        numbersCubePlayName = CommonMethods.SetUpNewCurrentNumberByAddition(numbersCubePlayName, index);


                        // [gameBoard]
                        GameObject newCublePlayOnTheBoard = newPrefabCubePlay;
                       
                        var newXYZFornewCubePlayOnTheBoard = CommonMethods.GetIndexZYXForGameObject(prefabCubePlayNumbers, currentNumberForPrefabCubePlay);

                        int newNumberOfDepth = newXYZFornewCubePlayOnTheBoard.Item1;
                        int newNumberOfRow = newXYZFornewCubePlayOnTheBoard.Item2;
                        int newNumberOfColumn = newXYZFornewCubePlayOnTheBoard.Item3;

                        gameBoard[newNumberOfDepth, newNumberOfRow, newNumberOfColumn] = newCublePlayOnTheBoard;

                        //---------------------------------

                        int currentIndexPrefabCubePlayZ = indexForCubePlayCoordinateZ[0];
                       // Debug.Log("currentNumberPrefabCubePlayZ = " + currentIndexPrefabCubePlayZ);

                        //float currentCoordinateZ = coordinateZForPrefabCubePlay[currentIndexPrefabCubePlayZ];
                        //CreateGameBoardMethods.SetUpNewZForPrefabCubePlay(newPrefabCubePlay, currentCoordinateZ);
                        //Debug.Log("currentCoordinateZ = " + currentCoordinateZ);

                        var newCountedNumberPrefabCubePlayForYForNewZ = CreateGameBoardMethods.GetnewCountedNumberForCubeRowsAndNewIndexForTheTableSetting(coordinateZForPrefabCubePlayLenght, currentIndexPrefabCubePlayZ, numberOfRows, currentCountedNumberForCubeRows, isNumberOfRowsEven);

                        int newIndexPrefabCubePlayForCoordinateZ = newCountedNumberPrefabCubePlayForYForNewZ.Item1;
                       //Debug.Log("newNumberPrefabCubePlayZ = " + newNumberPrefabCubePlayZ);

                        int newCountedNumberOfRows = newCountedNumberPrefabCubePlayForYForNewZ.Item2;
                        // Debug.Log("newCountedNumberOfRows = " + newCountedNumberOfRows);

                        indexForCubePlayCoordinateZ[0] = newIndexPrefabCubePlayForCoordinateZ;
                        countedNumberCubePlayForRowsForCoordinateZ[0] = newCountedNumberOfRows;                     
                        float currentCoordinateZ = coordinateZForPrefabCubePlay[newIndexPrefabCubePlayForCoordinateZ];
                        CommonMethods.SetUpNewZForGameObject(newPrefabCubePlay, currentCoordinateZ);
                    }
                }
            }

            return gameBoard;
            // [gameBoard] create game board - end





        }

        public static GameObject CreateCubePlayFrame(GameObject prefabCubePlayFrame, GameObject cubePlayForFrame, bool isGame2D)
        {
            if (isGame2D == true)
            {
                float cubePlayScaleX = cubePlayForFrame.transform.localScale.x;
                float cubePlayScaleY = cubePlayForFrame.transform.localScale.y;
                float cubePlayScaleZ = cubePlayForFrame.transform.localScale.z;

                CreateGameBoardPrefabCalculateScale.TransformGameObjectPrefabToNewScale(prefabCubePlayFrame, cubePlayScaleX, cubePlayScaleY, cubePlayScaleZ);

                // same of game objects CubePlay have coordinate Z = -0,05
                float topForAllCubePlay = 0.15f;

                float x = cubePlayForFrame.transform.position.x;
                float y = cubePlayForFrame.transform.position.y;
                float z = cubePlayForFrame.transform.position.z - cubePlayScaleX/2 - topForAllCubePlay;

                // create new prefab "CubePlayFrame"
                var newPrefabCubePlay = Instantiate(prefabCubePlayFrame, new Vector3(x, y, z), Quaternion.identity);

                

                return cubePlayForFrame;
            }

            return cubePlayForFrame;
        }
















    }

}
