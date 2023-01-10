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
        public static GameObject[,,] CreateBoardGame(GameObject prefab, int numberOfDepths, int numberOfRows, int numberOfColumns,  Material[] prefabCubePlayDefaultColour)
        {
            // [prefabColor] lenght of array colour assigned to object "GameBoard"
            int cubePlayColourLenght = prefabCubePlayDefaultColour.Length;

            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [prefabCubePlay] calculate data for game board - start
            // [prefabCubePlay] calculate new scale for prefab "CubaPlay"
            float newScale = CreateGameBoardPrefabCalculateScale.ScaleForPrefabCubePlay(prefab, numberOfDepths, numberOfRows, numberOfColumns);

            // [prefabCubePlay] calculate data for first prefab "CubaPlay" X and Y and Z
            float startPositionForPrefabCubePlayXYZ = CreateGameBoardMethods.StartPositionXYZ(newScale);

            // [prefabCubePlay] change the scale for prefab "CubePlay" using a new scale 
            CreateGameBoardPrefabCalculateScale.TransformPrefabCubePlayToNewScale(prefab, newScale);

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

            // [prefabCubePlayColorDefault]
            bool isNumberOfRowsEven = CommonMethods.IsNumberEven(numberOfRows);

            // [prefabCubePlay] table wiht number for prefab "CubePlay", number added to prefab as are created in UI (in the same direction),
            int[,,] prefabCubePlayNumbers = CreateGameBoardMethods.CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI(numberOfDepths, numberOfRows, numberOfColumns);

            // [prefabCubePlay] calculate data for game board - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------


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
            int[] currentCountedNumberCubePlayForY = new int[1];
            currentCountedNumberCubePlayForY[0] = 0;

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
                        int currentCountedNumberForCubeRows = currentCountedNumberCubePlayForY[0];

                        // [prefabCubePlayColorDefault] calculate new data - change colour for new prefab "CubePlay"
                        var newDataForCubePlayColour = CreateGameBoardPrefabDefaultColour.NewIndexColourForPrefabCubePlay(cubePlayColourLenght, currentIndexForPreviousColour, numberOfRows, currentCountedNumberForCubeRows, isNumberOfRowsEven);

                        int newIndexForCubePlayColour = newDataForCubePlayColour.Item1;
                        int newCountedNumberForCubePlayHeightY = newDataForCubePlayColour.Item2;

                        // [prefabCubePlayColorDefault] new data - change colour for new prefab "CubePlay"
                        indexForPreviousCubePlayColour[0] = newIndexForCubePlayColour;
                        currentCountedNumberCubePlayForY[0] = newCountedNumberForCubePlayHeightY;

                        // [prefabCubePlayColorDefault] change colour for new prefab "CubePlay"
                        CreateGameBoardPrefabDefaultColour.ChangeColourForPrefabCubePlay(prefab, prefabCubePlayDefaultColour, newIndexForCubePlayColour);

                        //[prefabCubePlayTextDefault] - change text for new prefab "CubePlay"
                        int currentNumberForPrefabCubePlay = countedPrefabCubePlay[0];
                        string prefabCubePlayDefaultText = CreateGameBoardPrefabDefaultText.SetUpNewDefaultTextForPrefaCubePlay(prefabCubePlayNumbers, defaultTextForPrefabCubePlay, currentNumberForPrefabCubePlay);
                        
                        CreateGameBoardPrefabDefaultText.SetUpDefaultTextForPrefaCubePlay(prefab, prefabCubePlayDefaultText);

                        //[prefabCubePlayTextDefault] - set up new currentNumberForPrefabCubePlay
                        countedPrefabCubePlay = CommonMethods.SetUpNewNumberForCurrentNumber(countedPrefabCubePlay);
                        

                        // create new prefab "CubePlay"
                        var newPrefabCubePlay = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
;
                        // [prefabCubePlayName] chcange the name for new prefab "CubePlay"
                        int currentNumberCubePlayName = numbersCubePlayName[0];
                        var currentIndexXYForPrefabCubePlay = CommonMethods.GetIndexZYXForGameObject(prefabCubePlayNumbers, currentNumberCubePlayName);

                        // [prefabCubePlayName]
                        string prefabCubePlayName = CreateGameBoardPrefabName.CreateNameForPrefabCubePlay(currentNumberCubePlayName, currentIndexXYForPrefabCubePlay);
                        newPrefabCubePlay.name = prefabCubePlayName;

                        // [prefabCubePlayName] set up new currentNumberCubePlayName
                        numbersCubePlayName = CommonMethods.SetUpNewNumberForCurrentNumber(numbersCubePlayName);


                        // [gameBoard]
                        GameObject newCublePlayOnTheBoard = newPrefabCubePlay;
                       
                        var newXYZFornewCubePlayOnTheBoard = CommonMethods.GetIndexZYXForGameObject(prefabCubePlayNumbers, currentNumberForPrefabCubePlay);

                        int newNumberOfDepth = newXYZFornewCubePlayOnTheBoard.Item1;
                        int newNumberOfRow = newXYZFornewCubePlayOnTheBoard.Item2;
                        int newNumberOfColumn = newXYZFornewCubePlayOnTheBoard.Item3;

                        gameBoard[newNumberOfDepth, newNumberOfRow, newNumberOfColumn] = newCublePlayOnTheBoard;
                                               
                        //currentNumberOfRows[0] = newNumberOfRow;
                       // currentNumberOfColumns[0] = newNumberOfColumn;
                       // currentNumberOfDepths[0] = newNumberOfDepth;
                        
                    }
                }
            }

            return gameBoard;
            // [gameBoard] create game board - end
        }

    }

}
