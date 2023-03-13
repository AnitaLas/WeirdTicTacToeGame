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
    internal class GameConfigurationCommonMethods
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




        public static void ChangeCoordinateYForTable(GameObject[,,] tableWtithNumber, float newCoordinateZ)
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
                        //Debug.Log(" Y ");
                        //Debug.Log(" newCoordinateZ = " + newCoordinateZ);
                        CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateZ);

                    }

                }
            }
        }

        public static void UnhideTableWithNumber(GameObject[,,] tableWtithNumber)
        {
            float newCoordinateZ = -100f;
            ChangeCoordinateYForTable(tableWtithNumber, newCoordinateZ);
        }

        public static void HideTableWithNumber(GameObject[,,] tableWtithNumber)
        {
            //float newCoordinateZ = 0.75f;
            float newCoordinateY = 100f;
            ChangeCoordinateYForTable(tableWtithNumber, newCoordinateY);
        }

        //-------------------------

        public static void ChangeCoordinateYForConfiguration(float newCoordinateZ, string tagName1, string tagName2, string tagName3, string tagName4, string tagName5, string tagName6, string tagName7, string tagName8, string tagName9, string tagName10)
        {
            string[] tagName = { tagName1, tagName2, tagName3, tagName4, tagName5, tagName6, tagName7, tagName8, tagName9, tagName10 };
            int tagNameLenght = tagName.Length;
            //float newCoordinateZ = 0.75f;

            for (int i = 0; i < tagNameLenght; i++)
            {
                string tag = tagName[i];
                GameObject[] gameObjectForChange = CommonMethods.GetObjectByTagName(tag);
                GameObject gameObjectToChange = gameObjectForChange[0];
                //CommonMethods.SetUpNewZForGameObject(gameObjectToChange, newCoordinateZ);
                CommonMethods.SetUpNewYForGameObject(gameObjectToChange, newCoordinateZ);


            }
        }

        public static void UnhideConfiguration(string tagName1, string tagName2, string tagName3, string tagName4, string tagName5, string tagName6, string tagName7, string tagName8, string tagName9, string tagName10)
        {
            float newCoordinateY = -100f;
            ChangeCoordinateYForConfiguration(newCoordinateY, tagName1, tagName2, tagName3, tagName4, tagName5, tagName6, tagName7, tagName8, tagName9, tagName10);
        }


        public static void HideConfiguration(string tagName1, string tagName2, string tagName3, string tagName4, string tagName5, string tagName6, string tagName7, string tagName8, string tagName9, string tagName10)
        {
            float newCoordinateY = 100f;
            ChangeCoordinateYForConfiguration(newCoordinateY, tagName1, tagName2, tagName3, tagName4, tagName5, tagName6, tagName7, tagName8, tagName9, tagName10);
        }


        public static int SetUpChosenNumberForConfiguration(GameObject[,,] tableWithNumber, string gameObjectName, string tagName)
        {
            int number;
            GameObject cubePlay = CommonMethods.GetCubePlay(tableWithNumber, gameObjectName);
            string numberString = CommonMethods.GetCubePlayText(cubePlay);

            GameObject[] cubePlayForChange = CommonMethods.GetObjectByTagName(tagName);
            GameObject cubePlayToChange = cubePlayForChange[0];
            CommonMethods.ChangeTextForFirstChild(cubePlayToChange, numberString);

            number = CommonMethods.ConvertStringToInt(numberString);
            return number;

        }






    }

    
}
