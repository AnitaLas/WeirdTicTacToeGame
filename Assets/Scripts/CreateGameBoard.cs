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


        public static void CreateBoardGame(GameObject prefab, int numberOfRows, int numberOfColumns, int numberOfDepths, Material[] cubePlayColour)
        {
            // [prefabColor] lenght of array colour assigned to object "GameBoard"
            int cubePlayColourLenght = cubePlayColour.Length;

            // [prefabCubePlay] number for all created prefab "CubePlay"
            int maxCubePlayNumber = numberOfRows * numberOfColumns * numberOfDepths;

            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [prefabCubePlay] calculate data for game board - start
            // [prefabCubePlay] calculate new scale for prefab "CubaPlay"
            float newScale = CreateGameBoardPrefabCalculateScale.ScaleForPrefabCubePlay(prefab, numberOfRows, numberOfColumns);

            // [prefabCubePlay] calculate data for first prefab "CubaPlay" X and Y and Z
            float startPositionForPrefabCubePlayXYZ = CreateGameBoardMethods.StartPositionXYZ(newScale);

            // [prefabCubePlay] change the scale for prefab "CubePlay" using a new scale 
            CreateGameBoardPrefabCalculateScale.TransformPrefabCubePlayToNewScale(prefab, newScale);

            // [prefabCubePlay] finding the lenght for all prefab "CubePlay" in one line for X, Y, Z
            float lengthForAllPrefabCubePlayInOneLineX = CreateGameBoardMethods.CalculateLengthForAllPrefabInOneLineXYZ(numberOfRows, newScale);
            float lengthForAllPrefabCubePlayInOneLineY = CreateGameBoardMethods.CalculateLengthForAllPrefabInOneLineXYZ(numberOfColumns, newScale);
            float lengthForAllPrefabCubePlayInOneLineZ = CreateGameBoardMethods.CalculateLengthForAllPrefabInOneLineXYZ(numberOfDepths, newScale);

            // [prefabCubePlay] finding position X, Y, Z for fisrt prefab "CubePlay"
            float positionForFirstCubePlayWidthX = CreateGameBoardMethods.PositionForFirstPrefab(lengthForAllPrefabCubePlayInOneLineX, startPositionForPrefabCubePlayXYZ);
            float positionForFirstCubePlayHeightY = CreateGameBoardMethods.PositionForFirstPrefab(lengthForAllPrefabCubePlayInOneLineY, startPositionForPrefabCubePlayXYZ);
            float positionForFirstCubePlayDepthZ = CreateGameBoardMethods.PositionForFirstPrefab(lengthForAllPrefabCubePlayInOneLineZ, startPositionForPrefabCubePlayXYZ);

            // [prefabCubePlay] finding position X, Y, Z for last prefab "CubePlay"
            float positionForLastCubePlayWidthX = CreateGameBoardMethods.PositionForLastPrefab(lengthForAllPrefabCubePlayInOneLineX);
            float positionForLastCubePlayHeightY = CreateGameBoardMethods.PositionForLastPrefab(lengthForAllPrefabCubePlayInOneLineY);
            float positionForLastCubePlayDepthZ = CreateGameBoardMethods.PositionForLastPrefab(lengthForAllPrefabCubePlayInOneLineZ);

            bool isNumberOfColumnsEven = CommonMethods.IsNumberEven(numberOfColumns);

            // [prefabCubePlay] table wiht number for prefab "CubePlay", number added to prefab as are created in UI (in the same direction),
            int[,] prefabCubePlayNumbers = CreateGameBoardMethods.CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI(numberOfRows, numberOfColumns);

            //int[,] tableForBoardGame = GameBoardCreateMethods.Create2DTableForBoardGame(numberOfRows, numberOfColumns);

            // [prefabCubePlay] calculate data for game board - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------


            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            //[prefabCubePlayName] - start

            // [prefabCubePlayName] change name for prefab "CubePlay"
            int[] numbersCubePlayName = new int[1];
            numbersCubePlayName[0] = 1;
            string prefabCubePlayName;

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
            string[,] defaultTextForPrefabCubePlay = CreateGameBoardPrefabDefaultText.CreateTableWithTextForPrefabCubePlay(numberOfRows, numberOfColumns);

            int[] countedPrefabCubePlay = new int[1];
            countedPrefabCubePlay[0] = 1;

            //[prefabCubePlayTextDefault] - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------

 
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [gameBoard] create game board - start
            for (float x = positionForFirstCubePlayWidthX; x < positionForLastCubePlayWidthX; x = x + newScale)          
            {

                for (float y = positionForFirstCubePlayHeightY; y < positionForLastCubePlayHeightY; y = y + newScale)
                 {

                    for (float z = positionForFirstCubePlayDepthZ; z < positionForLastCubePlayDepthZ; z = z + newScale)
                     {
                        // [prefabCubePlayColorDefaul] old data - change colour for new prefab "CubePlay"
                        int currentIndexForPreviousColour = indexForPreviousCubePlayColour[0];
                        int currentCountedNumberForCubePlayHeightY = currentCountedNumberCubePlayForY[0];

                        // [prefabCubePlayColorDefault] calculate new data - change colour for new prefab "CubePlay"
                        var newDataForCubePlayColour = CreateGameBoardPrefabDefaultColour.NewIndexColourForPrefabCubePlay(cubePlayColourLenght, currentIndexForPreviousColour, numberOfColumns, currentCountedNumberForCubePlayHeightY, isNumberOfColumnsEven);

                        int newIndexForCubePlayColour = newDataForCubePlayColour.Item1;
                        int newCountedNumberForCubePlayHeightY = newDataForCubePlayColour.Item2;

                        // [prefabCubePlayColorDefault] new data - change colour for new prefab "CubePlay"
                        indexForPreviousCubePlayColour[0] = newIndexForCubePlayColour;
                        currentCountedNumberCubePlayForY[0] = newCountedNumberForCubePlayHeightY;

                        // [prefabCubePlayColorDefault] change colour for new prefab "CubePlay"
                        CreateGameBoardPrefabDefaultColour.ChangeColourForPrefabCubePlay(prefab, cubePlayColour, newIndexForCubePlayColour);

                        //[prefabCubePlayTextDefault] - change text for new prefab "CubePlay"
                        int currentNumberForPrefabCubePlay = countedPrefabCubePlay[0];
                        string prefabCubePlayDefaultText = CreateGameBoardPrefabDefaultText.SetUpNewDefaultTextForPrefaCubePlay(prefabCubePlayNumbers, defaultTextForPrefabCubePlay, currentNumberForPrefabCubePlay);
                        
                        CreateGameBoardPrefabDefaultText.SetUpDefaultTextForPrefaCubePlay(prefab, prefabCubePlayDefaultText);

                        int newNumberForPrefabCubePlay = CreateGameBoardMethods.SetUpNewNumberForCurrentNumber(currentNumberForPrefabCubePlay);
                        countedPrefabCubePlay[0] = newNumberForPrefabCubePlay;

                        // create new prefab "CubePlay"
                        var newPrefabCubePlay = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);

                        // [prefabCubePlayName] chcange the name for new prefab "CubePlay"
                        int currentNumberCubePlayName = numbersCubePlayName[0];
                        var currentIndexXYForPrefabCubePlay = CreateGameBoardMethods.GetIndexXYForPrefaCubePlay(prefabCubePlayNumbers, currentNumberCubePlayName);

                        // [prefabCubePlayName]
                        prefabCubePlayName = CreateGameBoardPrefabName.CreateNameForPrefabCubePlay(currentNumberCubePlayName, currentIndexXYForPrefabCubePlay);
                        newPrefabCubePlay.name = prefabCubePlayName;

                        // [prefabCubePlayName] calculate new data - name for new prefab "CubePlay"
                        int newNumbersCubePlayName = CreateGameBoardMethods.SetUpNewNumberForCurrentNumber(currentNumberCubePlayName);
                        numbersCubePlayName[0] = newNumbersCubePlayName;

                    }
                }

            }
            // [gameBoard] create game board - end
        }

    }

}
