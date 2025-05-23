﻿using Assets.Scripts;
using UnityEngine;


namespace Assets.Scripts
{
    internal class CreateTablePrefabCalculateScale : MonoBehaviour
    {

        //start and deaful scale for prefab "CubePlay"
        private static float _prefabCubePlayDefaultScaleX = 1;
        private static float _prefabCubePlayDefaultScaleY = 1;
        private static float _prefabCubePlayDefaultScaleZ = 1;
        //private static float _prefabCubePlayDefaultLowerScale = 1;

        // max number cube for cellphone
        private static int _prefabCubePlayMaxNumberWidthXPhone = 4;
        private static int _prefabCubePlayMaxNumberHeightYPhone = 6;
        private static int _prefabCubePlayMaxNumberDetphZPhone = 1;

        // max number cube for tablet
        private static int _prefabCubePlayMaxNumberWidthXTablet = 6;
        private static int _prefabCubePlayMaxNumberHeightYTablet = 7;
        private static int _prefabCubePlayMaxNumberDetphZTblet = 1;

        public static void TransformGameObjectPrefabToNewScale(GameObject prefab, float newScaleX, float newScaleY, float newScaleZ)
        {
            prefab.transform.localScale = new Vector3(newScaleX, newScaleY, newScaleZ);
        }
        
        /// <summary>
        /// <para> prefab = CubePlay </para>
        /// </summary>
        /// <param name="numberOfDepths"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <returns></returns>
        public static float  ScaleForPrefabCubePlay(double numberOfDepths, double numberOfRows, double numberOfColumns)
        {
            double newScaleForX = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleX, numberOfColumns, _prefabCubePlayMaxNumberWidthXPhone);
            double newScaleForY = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleY, numberOfRows, _prefabCubePlayMaxNumberHeightYPhone);
            double newScaleForZ = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleZ, numberOfDepths, _prefabCubePlayMaxNumberDetphZPhone);

            int roundDouble = 6;

            float floatNewScaleForX = GameCommonMethodsMain.RoundAndConvertDoubleToFloat(newScaleForX, roundDouble);
            float floatNewScaleForY = GameCommonMethodsMain.RoundAndConvertDoubleToFloat(newScaleForY, roundDouble);
            float floatNewScaleForZ = GameCommonMethodsMain.RoundAndConvertDoubleToFloat(newScaleForZ, roundDouble);

            float[] newScaleForXYZ = { floatNewScaleForX, floatNewScaleForY, floatNewScaleForZ };

            float newScale = FindSmallestScaleXYZForPrefabCubePlay(newScaleForXYZ, numberOfDepths, numberOfRows, numberOfColumns);

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
            double newScale = GameCommonMethodsMain.RoundDownWithDecimal(resut, numberAfterDecimal);
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
        public static float FindSmallestScaleXYZForPrefabCubePlay(float[] newScaleForXYZ, double numberOfDepths, double numberOfRows, double numberOfColumns)
        {
            // maxNumberOfRows = 4, maxNnumberOfColumns = 6 - the max numbers prefab "CubePlay" for phone
            // to do: add the method checking the screen width and height, than add the method return the max rows and max rows for tablet
            double maxNumberOfRows = 6;
            double maxNnumberOfColumns = 4;
            double maxNnumberOfDepths = 1;

            float newScaleForXYZLenght = newScaleForXYZ.Length;

            float maxValue = 10000;
            float[] newScaleForPrefabCubePlay = { maxValue };

            if (numberOfRows != maxNumberOfRows || numberOfColumns != maxNnumberOfColumns || numberOfDepths != maxNnumberOfDepths)
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

        // ---

        public static float FindSmallestScaleXYZForPrefabCubePlayGameBoard(float[] newScaleForXYZ, double numberOfDepths, double numberOfRows, double numberOfColumns, bool isCellphoneMode)
        {
            // maxNumberOfRows = 4, maxNnumberOfColumns = 6 - the max numbers prefab "CubePlay" for phone
            // to do: add the method checking the screen width and height, than add the method return the max rows and max rows for tablet
            double maxNumberOfRows = 6;
            double maxNnumberOfColumns = 4;
            double maxNnumberOfDepths = 1;

            float newScaleForXYZLenght = newScaleForXYZ.Length;

            float maxValue = 10000;
            float[] newScaleForPrefabCubePlay = { maxValue };

            // cellphone mode
            if (isCellphoneMode == true)
            {
                if (numberOfRows != maxNumberOfRows || numberOfColumns != maxNnumberOfColumns || numberOfDepths != maxNnumberOfDepths)
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
            }
            // tablet mode
            else
            {
                if (numberOfRows != 10 || numberOfColumns != 10 || numberOfDepths != maxNnumberOfDepths)
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
            }


            if (numberOfRows != maxNumberOfRows || numberOfColumns != maxNnumberOfColumns || numberOfDepths != maxNnumberOfDepths)
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

        public static float ScaleForPrefabCubePlayGameBoard(double numberOfDepths, double numberOfRows, double numberOfColumns, bool isCellphoneMode)
        {
            double newScaleForX;
            double newScaleForY;
            double newScaleForZ;

            if (isCellphoneMode == true)
            {
                newScaleForX = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleX, numberOfColumns, _prefabCubePlayMaxNumberWidthXPhone);
                newScaleForY = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleY, numberOfRows, _prefabCubePlayMaxNumberHeightYPhone);
                newScaleForZ = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleZ, numberOfDepths, _prefabCubePlayMaxNumberDetphZPhone);
            }
            else
            {
                newScaleForX = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleX, numberOfColumns, _prefabCubePlayMaxNumberWidthXTablet);
                newScaleForY = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleY, numberOfRows, _prefabCubePlayMaxNumberHeightYTablet);
                newScaleForZ = CalculateNewScaleForPrefab(_prefabCubePlayDefaultScaleZ, numberOfDepths, _prefabCubePlayMaxNumberDetphZTblet);
            }

            int roundDouble = 6;

            float floatNewScaleForX = GameCommonMethodsMain.RoundAndConvertDoubleToFloat(newScaleForX, roundDouble);
            float floatNewScaleForY = GameCommonMethodsMain.RoundAndConvertDoubleToFloat(newScaleForY, roundDouble);
            float floatNewScaleForZ = GameCommonMethodsMain.RoundAndConvertDoubleToFloat(newScaleForZ, roundDouble);

            float[] newScaleForXYZ = { floatNewScaleForX, floatNewScaleForY, floatNewScaleForZ };

            float newScale = FindSmallestScaleXYZForPrefabCubePlayGameBoard(newScaleForXYZ, numberOfDepths, numberOfRows, numberOfColumns, isCellphoneMode);

            return newScale;
        }
    }
}
