using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    internal class GameBoardCreateMethods
    {
        // --------------------------------------------------------------------
        // GameBoardCreate - start

        // double 14/15 digits after coma
        // float 6/7 digits after coma
        /*
        public static double MinOrMaxXYZForCubePlayCalculate(double number, int devide, int round)
        {
            double result = number / devide;
            double roundedNumber = Math.Round(result, round);
            return roundedNumber;
        }
        */
        /// <summary>
        /// <para> Calculate the min X or Y or Z for first prefab "cubePlay" </para>
        /// <para> Calculate the max X or Y or Z for last prefab "cubePlay" </para>
        /// <para> e.g  number = 14, device = 34, round = 2, result = 0,411</para>
        /// </summary>
        /// <param name="number"></param>
        /// <param name="devide"></param>
        /// <param name="round"></param>
        /// <returns></returns>

        public static double PositionMinOrMaxXYZForCubePlayCalculate(double number, int devide, int round)
        {
            double result = number / devide;
            //Debug.Log("number: " + number);
            //Debug.Log("devide: " + devide);
            //Debug.Log("result: " + result);

            double roundedNumber = Math.Round(result, round);
            //Debug.Log("roundedNumber: " + roundedNumber);
            return roundedNumber;
            //double position = roundedNumber + scale;
            //return position;
        }

        public static float PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(double number)
        {
            int round = 2;
            int devide = 2;
            double doubleNumber = PositionMinOrMaxXYZForCubePlayCalculate(number, devide, round);
            float floatNumber = CommonMethods.ConvertDoubleToFloat(doubleNumber);
            return floatNumber;
            /*
            float scale = 0.5f;
            float test = floatNumber * CommonMethods.RoundAndConvertDoubleToFloat(scale, 2);
            Debug.Log("test: " + test);
            return test;
            */
            
        }

        /// <summary>
        /// <para> prefab = CubePlay </para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float PositionForFirstPrefab(double number, float startPositionXYZ)
        {
            float floatNumber = PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(number);
            //float startPositionXYZ = 0.65f; // add scale scale/2
            //Debug.Log("PositionForFirstPrefab: floatNumber:" + floatNumber);
           
            float positionForFirstCubePlay = startPositionXYZ - floatNumber;
            //Debug.Log("positionForFirstCubePlay: " + positionForFirstCubePlay);

            return positionForFirstCubePlay;
        }

        /// <summary>
        /// <para> prefab = CubePlay </para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float PositionForLastPrefab(double number)
        {
            float positionForLastPrefab = PositionMinOrMaxXYZForCubePlayConvertResultInDoubleToFloat(number);
            return positionForLastPrefab;
        }


        public static float CalculateLengthForAllPrefabInOneLineXYZ(int number, float scale)
        {
            float floatNumber = CommonMethods.ConvertIntToFloat(number);
            //Debug.Log("CalculateLengthForAllPrefabInOneLineXYZ floatNumber: " + floatNumber);
            
            float lenght = floatNumber * scale;
            //Debug.Log("CalculateLengthForAllPrefabInOneLineXYZ lenght: " + lenght);
            return lenght;
        }

        // GameBoardCreate - end
        // --------------------------------------------------------------------


        // --------------------------------------------------------------------
        // GameBoardCreateScale - start



        /*
          prefab.transform.localScale = new Vector3(1, 1, 1);
           prefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        */



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


        public static float FindSmallestScaleXYZForPrefabCubePlay(float[] newScaleForXYZ, double numbersCubesForWidthX, double numbersCubesForHeightY)
        {
            float newScaleForXYZLenght = newScaleForXYZ.Length;

            float maxValue = 10000;
            float[] newScaleForPrefabCubePlay = { maxValue };

            if (numbersCubesForWidthX != 4 || numbersCubesForHeightY != 6)
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












        // GameBoardCreateScale - end
        // --------------------------------------------------------------------


    }
}
