using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameBoardCreate : MonoBehaviour
    {

        public static void CreateBoardGame(GameObject prefab, int numbersCubesForWidthX, int numbersCubesForHeightY, int numbersCubesForDepthZ)
        {
            float newScale = GameBoardCreateScale.ScaleForPrefabCubePlay(prefab, numbersCubesForWidthX, numbersCubesForHeightY);
            float startPositionXYZ = GameBoardCreateScale.StartPositionXYZ(newScale);
            GameBoardCreateScale.TransformPrefabCubePlayToNewScale(prefab, newScale);
            /*
            float positionForFirstCubePlayWidthX = GameBoardCreateMethods.PositionForFirstPrefab(numbersCubesForWidthX);
            float positionForFirstCubePlayHeightY = GameBoardCreateMethods.PositionForFirstPrefab(numbersCubesForHeightY); // max 2 down, the other field mast be seen if 
            float positionForFirstCubePlayDepthZ = GameBoardCreateMethods.PositionForFirstPrefab(numbersCubesForDepthZ);

            float positionForLastCubePlayWidthX = GameBoardCreateMethods.PositionForLastPrefab(numbersCubesForWidthX);
            float positionForLastCubePlayHeightY = GameBoardCreateMethods.PositionForLastPrefab(numbersCubesForHeightY);
            float positionForLastCubePlayDepthZ = GameBoardCreateMethods.PositionForLastPrefab(numbersCubesForDepthZ);
            */

            float lengthForAllPrefabInOneLineX = GameBoardCreateMethods.CalculateLengthForAllPrefabInOneLineXYZ(numbersCubesForWidthX, newScale);
            //Debug.Log("??????????????????????????? lengthForAllPrefabInOneLineX: " + lengthForAllPrefabInOneLineX);

            float lengthForAllPrefabInOneLineY = GameBoardCreateMethods.CalculateLengthForAllPrefabInOneLineXYZ(numbersCubesForHeightY, newScale);
           // Debug.Log("lengthForAllPrefabInOneLineY: " + lengthForAllPrefabInOneLineY);

            float lengthForAllPrefabInOneLineZ = GameBoardCreateMethods.CalculateLengthForAllPrefabInOneLineXYZ(numbersCubesForDepthZ, newScale);
           // Debug.Log("lengthForAllPrefabInOneLineZ: " + lengthForAllPrefabInOneLineZ);

            float positionForFirstCubePlayWidthX = GameBoardCreateMethods.PositionForFirstPrefab(lengthForAllPrefabInOneLineX, startPositionXYZ);
           // float positionForFirstCubePlayWidthX = -1.15f;
            Debug.Log("positionForFirstCubePlayWidthX: " + positionForFirstCubePlayWidthX);

            float positionForFirstCubePlayHeightY = GameBoardCreateMethods.PositionForFirstPrefab(lengthForAllPrefabInOneLineY, startPositionXYZ); // max 2 down, the other field mast be seen if 
           // float positionForFirstCubePlayHeightY = -2.3f;
            Debug.Log("positionForFirstCubePlayHeightY: " + positionForFirstCubePlayHeightY);

            float positionForFirstCubePlayDepthZ = GameBoardCreateMethods.PositionForFirstPrefab(lengthForAllPrefabInOneLineZ, startPositionXYZ);
            //float positionForFirstCubePlayDepthZ = 0;
            Debug.Log("positionForFirstCubePlayDepthZ: " + positionForFirstCubePlayDepthZ);

            float positionForLastCubePlayWidthX = GameBoardCreateMethods.PositionForLastPrefab(lengthForAllPrefabInOneLineX);
            float positionForLastCubePlayHeightY = GameBoardCreateMethods.PositionForLastPrefab(lengthForAllPrefabInOneLineY);
            float positionForLastCubePlayDepthZ = GameBoardCreateMethods.PositionForLastPrefab(lengthForAllPrefabInOneLineZ);


            for (float x = positionForFirstCubePlayWidthX; x < positionForLastCubePlayWidthX; x = x + newScale)          
            {
                 for(float y = positionForFirstCubePlayHeightY; y < positionForLastCubePlayHeightY; y = y + newScale)
                 {

                     for (float z = positionForFirstCubePlayDepthZ; z < positionForLastCubePlayDepthZ; z = z + newScale)
                     {
                        Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
                     }
                 }
            }

        }



        /*
        public static void ScaleForCubePlay(GameObject prefab, double numbersCubesForWidthX, double numbersCubesForHeightY)
        {


            if (numbersCubesForWidthX < 5 && numbersCubesForHeightY < 7)
            {
                prefab.transform.localScale = new Vector3(1, 1, 1);
            }

          else
            {
                prefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }

        
        }

         */






    }
}
