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
    internal class GameBoardCreate : MonoBehaviour
    {


        public static void CreateBoardGame(GameObject prefab, int numbersCubesForWidthX, int numbersCubesForHeightY, int numbersCubesForDepthZ, Material[] cubePlayColour)
        {
            // [prefabColor] lenght of array colour assigned to object "GameBoard"
            int cubePlayColourLenght = cubePlayColour.Length;

            // [prefabCubePlay] number for all created prefab "CubePlay"
            int maxCubePlayNumber = numbersCubesForWidthX * numbersCubesForHeightY * numbersCubesForDepthZ;

            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [prefabCubePlay] calculate data for game board - start
            // [prefabCubePlay] calculate new scale for prefab "CubaPlay"
            float newScale = GameBoardCreateScale.ScaleForPrefabCubePlay(prefab, numbersCubesForWidthX, numbersCubesForHeightY);

            // [prefabCubePlay] calculate data for first "CubaPlay"
            float startPositionForPrefabCubePlayXYZ = GameBoardCreateMethods.StartPositionXYZ(newScale);

            // [prefabCubePlay] change the scale for prefab "CubePlay" using a new scale 
            GameBoardCreateScale.TransformPrefabCubePlayToNewScale(prefab, newScale);

            // [prefabCubePlay] finding the lenght for all prefab "CubePlay" in one line for X, Y Z
            float lengthForAllPrefabCubePlayInOneLineX = GameBoardCreateMethods.CalculateLengthForAllPrefabInOneLineXYZ(numbersCubesForWidthX, newScale);
            float lengthForAllPrefabCubePlayInOneLineY = GameBoardCreateMethods.CalculateLengthForAllPrefabInOneLineXYZ(numbersCubesForHeightY, newScale);
            float lengthForAllPrefabCubePlayInOneLineZ = GameBoardCreateMethods.CalculateLengthForAllPrefabInOneLineXYZ(numbersCubesForDepthZ, newScale);

            // [prefabCubePlay] finding position X, Y, Z for fisrt prefab "CubePlay"
            float positionForFirstCubePlayWidthX = GameBoardCreateMethods.PositionForFirstPrefab(lengthForAllPrefabCubePlayInOneLineX, startPositionForPrefabCubePlayXYZ);
            float positionForFirstCubePlayHeightY = GameBoardCreateMethods.PositionForFirstPrefab(lengthForAllPrefabCubePlayInOneLineY, startPositionForPrefabCubePlayXYZ);
            float positionForFirstCubePlayDepthZ = GameBoardCreateMethods.PositionForFirstPrefab(lengthForAllPrefabCubePlayInOneLineZ, startPositionForPrefabCubePlayXYZ);

            // [prefabCubePlay] finding position X, Y, Z for last prefab "CubePlay"
            float positionForLastCubePlayWidthX = GameBoardCreateMethods.PositionForLastPrefab(lengthForAllPrefabCubePlayInOneLineX);
            float positionForLastCubePlayHeightY = GameBoardCreateMethods.PositionForLastPrefab(lengthForAllPrefabCubePlayInOneLineY);
            float positionForLastCubePlayDepthZ = GameBoardCreateMethods.PositionForLastPrefab(lengthForAllPrefabCubePlayInOneLineZ);

            // [prefabCubePlay] calculate data for game board - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            bool isNumbersCubesForHeightY = CommonMethods.IsNumberEven(numbersCubesForHeightY);

            // [prefabCubePlayName] change text and name for prefab "CubePlay"
            int[] cubePlayNumber = new int[1];
            cubePlayNumber[0] = 0;

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

            // [prefabCubePlayTextDefault] - table wiht number for prefab "CubePlay", number added to prefab as are creaiing in UI (var newPrefabCubePlay) 
            // first coulumn from button to up, then next column from button to up, from left to reight
            int[,] prefabCubePlayNumbers = GameBoardCreateMethods.CreateTableWithPrefabCubePlayNumbers(numbersCubesForWidthX, numbersCubesForHeightY);

            // [prefabCubePlayTextDefault] - default text for new prefab "CubePlay"
            string[,] defaultTextForPrefabCubePlay = GameBoardCreateMethods.CreateTableWithTextForPrefabCubePlay(numbersCubesForWidthX, numbersCubesForHeightY);

            int[] countedPrefabCubePlay = new int[1];
            countedPrefabCubePlay[0] = 1;
            //int currentPrefabCubePlayX;




            //[prefabCubePlayTextDefault] - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------



            // remove zz - only for help
            //int[] zz = new int[1];
            //zz[0] = 0;

            // [gameBoard] create game board - start
            for (float x = positionForFirstCubePlayWidthX; x < positionForLastCubePlayWidthX; x = x + newScale)          
            {
                //int newZ = zz[0] + 1;
                //zz[0] = newZ;
                // Debug.Log("----------------------------------------------------------------------------------");
                // Debug.Log("cube number: " + newZ);





                for (float y = positionForFirstCubePlayHeightY; y < positionForLastCubePlayHeightY; y = y + newScale)
                 {

 

                    for (float z = positionForFirstCubePlayDepthZ; z < positionForLastCubePlayDepthZ; z = z + newScale)
                     {
                        // [prefabCubePlayColorDefaule] old data - change colour for new prefab "CubePlay"
                        int currentIndexForPreviousColour = indexForPreviousCubePlayColour[0];
                        int currentCountedNumberForCubePlayHeightY = currentCountedNumberCubePlayForY[0];

                        // [prefabCubePlayColorDefaule] calculate new data - change colour for new prefab "CubePlay"
                        var newDataForCubePlayColour = GameBoardCreateChangeColour.NewIndexColourForPrefabCubePlay(cubePlayColourLenght, currentIndexForPreviousColour, numbersCubesForHeightY, currentCountedNumberForCubePlayHeightY, isNumbersCubesForHeightY);

                        int newIndexForCubePlayColour = newDataForCubePlayColour.Item1;
                        int newCountedNumberForCubePlayHeightY = newDataForCubePlayColour.Item2;

                        // [prefabCubePlayColorDefaule] new data - change colour for new prefab "CubePlay"
                        indexForPreviousCubePlayColour[0] = newIndexForCubePlayColour;
                        currentCountedNumberCubePlayForY[0] = newCountedNumberForCubePlayHeightY;

                        // [prefabCubePlayColorDefaule] change colour for new prefab "CubePlay"
                        GameBoardCreateChangeColour.ChangeColourForPrefabCubePlay(prefab, cubePlayColour, newIndexForCubePlayColour);







                        //[prefabCubePlayTextDefault] - change text for new prefab "CubePlay"
                        int currentNumberForPrefabCubePlay = countedPrefabCubePlay[0];
                        

                        
                       // var newPositionXYForPrefabCubePlayColour = GameBoardCreateMethods.GetIndexXYForDefaultNumberForPrefaCubePlay(prefabCubePlayNumbers, currentNumberForPrefabCubePlay);

                       // int newPositionXForPrefabCubePlayColour = newPositionXYForPrefabCubePlayColour.Item1;
                        //int newPositionYForPrefabCubePlayColour = newPositionXYForPrefabCubePlayColour.Item2;

                        //Debug.Log("X: " + newPositionXForPrefabCubePlayColour);
                        //Debug.Log("Y: " + newPositionYForPrefabCubePlayColour);

                        string prefabCubePlayDefaultText = GameBoardCreateMethods.GetDefaultTextForPrefaCubePlay(prefabCubePlayNumbers, defaultTextForPrefabCubePlay, currentNumberForPrefabCubePlay);

                        GameBoardCreateChangeText.SetUpDefaultTextForPrefaCubePlay(prefab, prefabCubePlayDefaultText);

                       
                        int newNumberForPrefabCubePlay = GameBoardCreateMethods.GetNumberForPrefabCubePlay(currentNumberForPrefabCubePlay);
                        countedPrefabCubePlay[0] = newNumberForPrefabCubePlay;













                        // create new prefab "CubePlay"
                        var newPrefabCubePlay = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);

                        // [prefabCubePlayName] chcange the name for new prefab "CubePlay"
                        newPrefabCubePlay.name = "CubePlay" + cubePlayNumber[0];
                        cubePlayNumber[0] = cubePlayNumber[0] + 1;




  
                    }
                 }


             




            }
            // [gameBoard] create game board - end
        }





    }
}
