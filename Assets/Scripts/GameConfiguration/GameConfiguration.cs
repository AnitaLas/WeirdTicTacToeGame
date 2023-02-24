using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfiguration
    {


        public static string[] CreateTableWithPlayersSymbols()
        {
            //string[] playersSymbols = { "x", "o", "H", "y", "z", "t" };
            //string[] playersSymbols = { "x", "00" };
            //string[] playersSymbols = { "x", "0", "3" };
            string[] playersSymbols = { "x", "o", "H", "Z"};
            //string[] playersSymbols = { "1", "2", "3", "4" };
            return playersSymbols;
        }

        public static string[,] CreateEmptyTable2D(int numberOfRows, int numberOfColumns)
        {
            string[,] table = new string[numberOfRows, numberOfColumns];

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    table[row, column] = "";
                }

            }
            return table;

        }




        public static void ChangeCoordinateZForTable(GameObject[,,] tableWtithNumber, float newCoordinateZ)
        {
            //float newCoordinateZ = 0.05f;

            int maxIndexDepth = 1;
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZ);

                    }

                }
            }
        }

        public static void UnhideTableWithNumber(GameObject[,,] tableWtithNumber)
        {
            float newCoordinateZ = 0.05f;
            ChangeCoordinateZForTable(tableWtithNumber, newCoordinateZ);
        }

        public static void HideTableWithNumber(GameObject[,,] tableWtithNumber)
        {
            float newCoordinateZ = 0.75f;
            ChangeCoordinateZForTable(tableWtithNumber, newCoordinateZ);
        }

        //-------------------------

        public static void ChangeCoordinateZForConfiguration(float newCoordinateZ, string tagName1, string tagName2, string tagName3, string tagName4)
        {
            string[] tagName = { tagName1, tagName2, tagName3, tagName4 };
            int tagNameLenght = tagName.Length;
            //float newCoordinateZ = 0.75f;

            for (int i = 0; i < tagNameLenght; i++)
            {
                string tag = tagName[i];
                GameObject[] gameObjectForChange = CommonMethods.GetObjectByTagName(tag);
                GameObject gameObjectToChange = gameObjectForChange[0];
                CommonMethods.SetUpNewZForGameObject(gameObjectToChange, newCoordinateZ);


            }
        }

        public static void UnhideConfiguration(string tagName1, string tagName2, string tagName3, string tagName4)
        {
            float newCoordinateZ = 0;
            ChangeCoordinateZForConfiguration(newCoordinateZ, tagName1, tagName2, tagName3, tagName4);
        }


        public static void HideConfiguration(string tagName1, string tagName2, string tagName3, string tagName4)
        {
            float newCoordinateZ = 0.75f;
            ChangeCoordinateZForConfiguration(newCoordinateZ, tagName1, tagName2, tagName3, tagName4);
        }


        public static int SetUpChosenNumberForConfiguration(GameObject[,,] tableWithNumber, string gameObjectName, string tagName)
        {
            int number;

            GameObject cubePlay = CommonMethods.GetCubePlay(tableWithNumber, gameObjectName);
            string numberString = CommonMethods.GetCubePlayText(cubePlay);
            Debug.Log(" 3 ");

            GameObject[] cubePlayForChange = CommonMethods.GetObjectByTagName(tagName);
            GameObject cubePlayToChange = cubePlayForChange[0];
            CommonMethods.ChangeTextForCubePlay(cubePlayToChange, numberString);

            number = CommonMethods.ConvertStringToInt(numberString);



            //return number;
            return number;

        }


    }
}
