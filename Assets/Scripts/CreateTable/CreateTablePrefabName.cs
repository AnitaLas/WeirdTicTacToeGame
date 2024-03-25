using System;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    internal class CreateTablePrefabName
    {
        // [prefabCubePlayName]

        /// <summary>
        /// <para> creates name for prefab "CubePlay" </para> 
        /// <para> !!! ATTENTION !!! <para>
        /// <para> the prefab "CubePlay" name is used for the "Tic Tac Tom Game" logic </para>
        /// <para> !!! ATTENTION !!! <para>
        /// </summary>
        /// <param name="currentNumberCubePlayName"></param>
        /// <param name="indeZYXForPrefabCubePlay"></param>
        /// <returns></returns>
        //public static string CreateNameForPrefabCubePlay_oldVersion(int currentNumberCubePlayName, Tuple<int, int, int> indeZYXForPrefabCubePlay)
        //{
        //    int cubePlayIndexDepths = indeZYXForPrefabCubePlay.Item1;
        //    int cubePlayIndexRow = indeZYXForPrefabCubePlay.Item2;
        //    int cubePlayIndexColumn = indeZYXForPrefabCubePlay.Item3;

        //    string cubePlayName = $"CubePlayUI_No_{currentNumberCubePlayName}_Table3DCoOrdinates_Depths_{cubePlayIndexDepths}_Row_{cubePlayIndexRow}_Column_{cubePlayIndexColumn}";
            
        //    return cubePlayName;
        //}

        public static string CreateNameForPrefabCubePlay(int currentNumberCubePlayName, int numbersCubePlayMax, Tuple<int, int, int> indeZYXForPrefabCubePlay)
        {
            int cubePlayIndexDepths = indeZYXForPrefabCubePlay.Item1;
            int cubePlayIndexRow = indeZYXForPrefabCubePlay.Item2;
            int cubePlayIndexColumn = indeZYXForPrefabCubePlay.Item3;
            string rightCurrentNumber = SetUpRightCurrentNumber(currentNumberCubePlayName, numbersCubePlayMax);
           

            string cubePlayName = $"CubePlayUI_No_{rightCurrentNumber}_Table3DCoOrdinates_Depths_{cubePlayIndexDepths}_Row_{cubePlayIndexRow}_Column_{cubePlayIndexColumn}";

            return cubePlayName;
        }

        public static string SetUpRightCurrentNumber(int currentNumberCubePlayName, int numbersCubePlayMax)
        {
            string currentNumber = CommonMethods.ConverIntToString(currentNumberCubePlayName);
            string maxNumber = CommonMethods.ConverIntToString(numbersCubePlayMax);
            string staticString = "0";
            string finalNumber;
            int currentNumbertLenght = currentNumber.Length;
            int maxNumberLenght = maxNumber.Length;
            
            string number = currentNumber;

            if (currentNumbertLenght <= maxNumberLenght)
            {
                for (int i = currentNumbertLenght; i < maxNumberLenght; i++)
                {
                    number = staticString + number;               
                }
            }

            finalNumber = staticString + number;
            //Debug.Log("finalNumber: " + finalNumber);
            
            return finalNumber;
        }


    }
}
