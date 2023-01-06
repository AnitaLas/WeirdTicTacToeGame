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
    internal class CreateGameBoardPrefabCalculateScale : MonoBehaviour
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

        public static void TransformPrefabCubePlayToNewScale(GameObject prefab, float newScale)
        {
            prefab.transform.localScale = new Vector3(newScale, newScale, newScale);
        }

        /// <summary>
        /// <para> prefab = CubePlay </para>
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        public static float  ScaleForPrefabCubePlay(GameObject prefab, double numberOfRows, double numberOfColumns)
        {
            double newScaleForX = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleX, numberOfRows, _prefabCubePlayMaxNumberWidthXPhone);
            double newScaleForY = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleY, numberOfRows, _prefabCubePlayMaxNumberHeightYPhone);
            //double newScaleForZ = GameBoardCreateMethods.CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleZ, numberOfRows, _prefabCubePlayMaxNumberDetphZPhone);

            float floatNewScaleForX = CommonMethods.ConvertDoubleToFloat(newScaleForX);
            float floatNewScaleForY = CommonMethods.ConvertDoubleToFloat(newScaleForY);
            //float floatNewScaleForZ = CommonMethods.ConvertDoubleToFloat(newScaleForZ);

            //float[] newScaleForXYZ = { floatNewScaleForX, floatNewScaleForY, floatNewScaleForZ };
            float[] newScaleForXYZ = { floatNewScaleForX, floatNewScaleForY };

            float newScale = FindSmallestScaleXYZForPrefabCubePlay(newScaleForXYZ, numberOfRows, numberOfColumns);

            return newScale;

        }

        /// <summary>
        /// <para> default scale for X or Y or Z </para>
        /// <para> prefab "CubePlay" max number for X or Y or Z -> set by default </para>
        /// <para> numbers prefabs "CubePlay" for X or Y or Z -> given by user </para>
        /// </summary>
        /// <param name="defaultScaleForXYZ"></param>
        /// <param name="cubePlayMaxNumberForXYZ"></param>
        /// <param name="numbersCubePlayForXYZ"></param>
        /// <returns></returns>
        public static double CalculateNewScaleForPrefab(double defaultScaleForXYZ, double cubePlayMaxNumberForXYZ, double numbersCubePlayForXYZ)
        {
            double resut = (defaultScaleForXYZ * numbersCubePlayForXYZ) / cubePlayMaxNumberForXYZ;
            int numberAfterDecimal = 1;
            double newScale = CommonMethods.RoundDownWithDecimal(resut, numberAfterDecimal);
            return newScale;
        }


        /// <summary>
        /// <para> </para>
        /// <para> 3D Future: add to the method numberOfDepths (Z) and condition for if </para>
        /// </summary>
        /// <param name="newScaleForXYZ"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static float FindSmallestScaleXYZForPrefabCubePlay(float[] newScaleForXYZ, double numberOfRows, double numberOfColumns)
        {
            // maxNumberOfRows = 4, maxNnumberOfColumns = 6 - the max numbers prefab "CubePlay" for phone
            // to do: add the method checking the screen width and height, than add the method return the max rows and max rows for tablet
            int maxNumberOfRows = 4;
            int maxNnumberOfColumns = 6;

            float newScaleForXYZLenght = newScaleForXYZ.Length;

            float maxValue = 10000;
            float[] newScaleForPrefabCubePlay = { maxValue };

            if (numberOfRows != maxNumberOfRows || numberOfColumns != maxNnumberOfColumns)
            {
                for (int i = 0; i < newScaleForXYZLenght; i++)
                {
                    if (newScaleForXYZ[i] < newScaleForPrefabCubePlay[0])
                    {
                        newScaleForPrefabCubePlay[0] = newScaleForXYZ[i];
                    }
                }
            }
            else
            {
                newScaleForPrefabCubePlay[0] = newScaleForXYZ[0];
            }

            float newScale = newScaleForPrefabCubePlay[0];
            return newScale;
        }


    }
}
