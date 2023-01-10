using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEditor.XR;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CommonMethods : MonoBehaviour
    {

        // double 14/15 digits after coma
        // float 6/7 digits after coma

        public static float ConvertDoubleToFloat(double number)
        {
            string doubleToString = number.ToString();
            float doubleToFloat = float.Parse(doubleToString);
            return doubleToFloat;
        }

        public static float ConvertIntToFloat(float number)
        {
            string intToString = number.ToString();
            float intToFloat = int.Parse(intToString);
            return intToFloat;
        }

        public static string ConverIntToString(int number)
        {
            string intToString = number.ToString();
            return intToString;
        }

        public static float RoundAndConvertDoubleToFloat(double number, int round)
        {
            double roundedNumber = Math.Round(number, round);
            float doubleToFloat = ConvertDoubleToFloat(roundedNumber);
            return doubleToFloat;
        }

        public static double RoundDownWithDecimal(double number, int numberAfterDecimal)
        {
            double newNumber = number * 10;
            double newNumberRounded = Math.Floor(newNumber);
            double resul = newNumberRounded / Math.Pow(10, numberAfterDecimal);
            return resul;
        }

        // even number - 2 4 6 
        // odd number - 3 5 7 444

        public static bool IsNumberEven(int number)
        {
            bool isNumberEven;

            if (number %2 == 0) 
            {
                isNumberEven = true;
                return isNumberEven;
            }
            else
            {
                isNumberEven = false;
                return isNumberEven;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------------------------------------------------
        // [CurrentNumber] - start

        /// <summary>
        /// <para> set the new number for current number, it's increase current number by one </para>
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <returns></returns>
        public static int SetUpNewNumberForCurrentNumber(int currentNumber)
        {
            int newCurrentNumber = currentNumber + 1;
            return newCurrentNumber;
        }

        /// <summary>
        /// <para> set the new number for current number, it's increase current number by one </para>
        /// </summary>
        /// <param name="currentCountedNumber"></param>
        /// <returns></returns>
        public static int[] SetUpNewNumberForCurrentNumber(int[] currentCountedNumber)
        {
            currentCountedNumber[0] = currentCountedNumber[0] + 1;
            return currentCountedNumber;

        }

            // [CurrentNumber] - end
            // --------------------------------------------------------------------------------------------------------------------------------------------------------------

            // --------------------------------------------------------------------------------------------------------------------------------------------------------------
            // [TextChange] - start
            public static void ChangeTextForCubePlay(GameObject gameObject, string gameObjectText)
        {
            // game object: prefab CubePlay -> CubePlayCanvas ->
            var newPrefabCubePlayCanvas = gameObject.transform.GetChild(0);
            // game object: prefab CubePlay -> CubePlayCanvas -> CubePlayText
            var newPrefabCubePlayCanvasText = newPrefabCubePlayCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            newPrefabCubePlayCanvasText.text = gameObjectText;
        }

        //[TextChange] - end
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------



        // --------------------------------------------------------------------------------------------------------------------------------------------------------------
        // [GetIndexZYXForGameObject] - start

        /// <summary>
        /// <para> currentNumberForPrefabCubePlay = number created for prefab "Cube Play" from the table created by CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI() </para>
        /// <para> table3D = CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI() </para>
        /// <para> it is returned the indexDepth, indexRow and indexColumn for the 3D array [Z, Y, X] / [indexDepth, indexRow, indexColumn] as it is in the regular 3D array</para>
        /// </summary>
        /// <param name="table"></param>
        /// <param name="currentNumberForPrefabCubePlay"></param>
        /// <returns></returns>
        public static Tuple<int, int, int> GetIndexZYXForGameObject(int[,,] table, int currentNumberForPrefabCubePlay)
        {
            int lenghtForDepths = table.GetLength(0);
            int lenghtForRows = table.GetLength(1);
            int lenghtForColumns = table.GetLength(2);

            for (int indexDepth = 0; indexDepth < lenghtForDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < lenghtForRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < lenghtForColumns; indexColumn++)
                    {
                        if (table[indexDepth, indexRow, indexColumn].Equals(currentNumberForPrefabCubePlay))
                        {

                            return Tuple.Create(indexDepth, indexRow, indexColumn);

                        }
                    }
                }
            }

            return Tuple.Create(0, 0, 0);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="cubePlayName"></param>
        /// <returns></returns>
        public static Tuple<int, int, int> GetIndexZYXForGameObject(GameObject[,,] table, string cubePlayName)
        {
            int lenghtForDepths = table.GetLength(0);
            int lenghtForRows = table.GetLength(1);
            int lenghtForColumns = table.GetLength(2);

            for (int indexDepth = 0; indexDepth < lenghtForDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < lenghtForRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < lenghtForColumns; indexColumn++)
                    {
                        GameObject cubePlay = table[indexDepth, indexRow, indexColumn];
                        string cubePlayNameFromTable = cubePlay.name;

                        if (cubePlayNameFromTable == cubePlayName)
                        {

                            return Tuple.Create(indexDepth, indexRow, indexColumn);

                        }
                    }
                }
            }

            return Tuple.Create(0, 0, 0);

        }

        //[GetIndexZYXForGameObject] - end
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
