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
            float newCoordinateY = 100f;
            ChangeCoordinateYForTable(tableWtithNumber, newCoordinateY);
        }

        //-------------------------

        public static void ChangeCoordinateYForConfiguration(float newCoordinateZ, string[] tagConfigurationHideOrUnhide)
        {

            int tagNameLenght = tagConfigurationHideOrUnhide.Length;

            for (int i = 0; i < tagNameLenght; i++)
            {
                string tag = tagConfigurationHideOrUnhide[i];
                GameObject gameObjectToChange = CommonMethods.GetObjectByTagName(tag);
                CommonMethods.SetUpNewYForGameObject(gameObjectToChange, newCoordinateZ);

            }
        }

        public static void UnhideConfiguration( string[] tagConfigurationHideOrUnhide)
        {
            float newCoordinateY = -100f;
            ChangeCoordinateYForConfiguration(newCoordinateY, tagConfigurationHideOrUnhide);
        }


        public static void HideConfiguration( string[] tagConfigurationHideOrUnhide)
        {
            float newCoordinateY = 100f;
            ChangeCoordinateYForConfiguration(newCoordinateY, tagConfigurationHideOrUnhide);
        }


        public static int SetUpChosenNumberForConfiguration( GameObject[,,] tableWithNumber, string gameObjectName, string tagName)
        {
            int number;
            GameObject cubePlay = CommonMethods.GetCubePlay(tableWithNumber, gameObjectName);
            string numberString = CommonMethods.GetCubePlayText(cubePlay);

            //GameObject[] cubePlayForChange = CommonMethods.GetObjectByTagName(tagName);
            GameObject cubePlayToChange = CommonMethods.GetObjectByTagName(tagName);
            CommonMethods.ChangeTextForFirstChild(cubePlayToChange, numberString);

            number = CommonMethods.ConvertStringToInt(numberString);
            return number;

        }






    }

    
}
