using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    internal class GameBoardCreateScale : MonoBehaviour
    {

        //start and deaful scale for prefab "CubePlay"
        private static float _prefabCubePlayDefaultScaleX = 1;
        private static float _prefabCubePlayDefaultScaleY = 1;
        private static float _prefabCubePlayDefaultScaleZ = 1;
        private static float _prefabCubePlayDefaultLowerScale = 1;

        // max number cube for phone
        private static int _prefabCubePlayMaxNumberWidthXPhone = 4;
        private static int _prefabCubePlayMaxNumberHeightYPhone = 6;
        private static int _prefabCubePlayMaxNumberDetphZPhone = 1;

        /// <summary>
        /// <para> prefab = CubePlay </para>
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="numbersCubesForWidthX"></param>
        /// <param name="numbersCubesForHeightY"></param>
        public static float  ScaleForPrefabCubePlay(GameObject prefab, double numbersCubesForWidthX, double numbersCubesForHeightY)
        {
            double newScaleForX = GameBoardCreateMethods.CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleX, numbersCubesForWidthX, _prefabCubePlayMaxNumberWidthXPhone);
            double newScaleForY = GameBoardCreateMethods.CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleY, numbersCubesForWidthX, _prefabCubePlayMaxNumberHeightYPhone);
            //double newScaleForZ = GameBoardCreateMethods.CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleZ, numbersCubesForWidthX, _prefabCubePlayMaxNumberDetphZPhone);

            float floatNewScaleForX = CommonMethods.ConvertDoubleToFloat(newScaleForX);
            float floatNewScaleForY = CommonMethods.ConvertDoubleToFloat(newScaleForY);
            //float floatNewScaleForZ = CommonMethods.ConvertDoubleToFloat(newScaleForZ);

            //float[] newScaleForXYZ = { floatNewScaleForX, floatNewScaleForY, floatNewScaleForZ };
            float[] newScaleForXYZ = { floatNewScaleForX, floatNewScaleForY };

            float newScale = GameBoardCreateMethods.FindSmallestScaleXYZForPrefabCubePlay(newScaleForXYZ, numbersCubesForWidthX, numbersCubesForHeightY);

            return newScale;

        }

        public static void TransformPrefabCubePlayToNewScale(GameObject prefab, float newScale)
        {
            prefab.transform.localScale = new Vector3(newScale, newScale, newScale);
        }




    }
}
