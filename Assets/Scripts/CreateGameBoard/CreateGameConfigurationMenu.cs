using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CreateGameConfigurationMenu
    {

        // ---

        public static GameObject[,,] CreateConfigurationButton(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 12;
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }

        public static string[,,] CreateTableForDefaultTextWithNumbers(string[] table, int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];
            int[] index = new int[1];
            index[0] = 0;
            int currentIndex;

            for (int indexDepth = 0; indexDepth < numberOfDepths; indexDepth++)
            {
                for (int indexRow = numberOfRows - 1; indexRow >= 0; indexRow--)
                {

                    for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                    {
                        currentIndex = index[0];
                        string stringNumber = table[currentIndex];

                        newTable[indexDepth, indexRow, indexColumn] = stringNumber;
                        index[0] = index[0] + 1;
                    }
                }

                index[0] = 0;
            }

            return newTable;
        }

        public static string[] CreateTableWithTextForPrefabCubePlay(int numberOfRows, int numberOfColumns)
        {
            int indexNumber = 0;
            int indexTextLineOne = 0;
            int indexTextLineThree = 0;
            int allNumbers = numberOfRows * numberOfColumns;
            string[] numbers = new string[allNumbers];
            string symbol;
            string textForHelpButtonLineOne = "    HIDE    ";
            string textForHelpButtonLineTwo = "";
            string textForHelpButtonLineThree = "HELP BUTTONS";

            for (int number = 1; number <= allNumbers; number++)
            {
                if (number < numberOfColumns - 1)
                {         
                    symbol = textForHelpButtonLineOne.Substring(indexTextLineOne, 1);

                    indexNumber = number - 1;
                    numbers[indexNumber] = symbol;
                    indexTextLineOne = indexTextLineOne + 1;
                    indexNumber = indexNumber + 1;
                }

                 if (number <= numberOfColumns * 2 && number > numberOfColumns)
                {
                    symbol = textForHelpButtonLineTwo;
                    //symbol = "v";
                    indexNumber = number - 1;
                    numbers[indexNumber] = symbol;
                    indexNumber = indexNumber + 1;


                }

                if (number <= numberOfColumns * 3 && number > numberOfColumns * 2)
                {
                    //symbol = "x";
                    symbol = textForHelpButtonLineThree.Substring(indexTextLineThree, 1);

                    indexNumber = number - 1;
                    numbers[indexNumber] = symbol;
                    indexTextLineThree = indexTextLineThree + 1;
                    indexNumber = indexNumber + 1;


                }
                //else  
                //{
                //    symbol = textForHelpButtonLineThree.Substring(indexNumber, 1);

                //    indexNumber = number - 1;
                //    numbers[indexNumber] = symbol;
                //    indexNumber = indexNumber + 1;
                //}

                //else if(number < numberOfColumns * 2 - 1)
                //{
                //    symbol = textForHelpButtonLineTwo;
                //    indexNumber = number - 1;
                //    numbers[indexNumber] = symbol;
                //    indexNumber = indexNumber + 1;
                //}


                //else if (number < numberOfColumns * 3 - 1)
                //{
                //    symbol = textForHelpButtonLineThree.Substring(indexNumber, 1);

                //    indexNumber = number - 1;
                //    numbers[indexNumber] = symbol;
                //    indexNumber = indexNumber + 1;
                //}



                for (int i = 0; i < numbers.Length; i++)
                {
                    Debug.Log($"numbers[{i}] = " + numbers[i]);
                }
                //numberString = "";
                //int indexNumber = number - 1;
                //numbers[indexNumber] = numberString;
            }

            return numbers;

        }

        public static string[,,] CreateTableWithTextForPrefabCubePlay(int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];

            string[] numbers = CreateTableWithTextForPrefabCubePlay(numberOfRows, numberOfColumns);
            /*
            for (int i = 0; i < numbers.Length; i++)
            {
                Debug.Log(" i = " + numbers[i]);
            }
            */

            string[,,] numbers3D = CreateTableForDefaultTextWithNumbers(numbers, numberOfDepths, numberOfRows, numberOfColumns);

            for (int indexDepth = 0; indexDepth < numberOfDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < numberOfRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                    {
                        string stringNumber = numbers3D[indexDepth, indexRow, indexColumn];
                        newTable[indexDepth, indexRow, indexColumn] = stringNumber;
                    }
                }
            }

            return newTable;
        }









        // ---

        //public static void ChangeCoordinateYForTable(GameObject[,,] tableWtithNumber, GameObject cubePlayFrame, float newCoordinateZ)
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


        // ---

        public static void HideConfigurationMenu(GameObject[,,] gameBoard)
        {
           // float newCoordinateZ = -100f;
            //ChangeCoordinateYForTable(gameBoard, newCoordinateZ);

        }

        public static void HidePlayersSymbol()
        {

        }

        public static void HideBoardGame(GameObject[,,] gameBoard)
        {
            float newCoordinateY = -100f;
            ChangeCoordinateYForTable(gameBoard, newCoordinateY);

        }

        public static void HideCubePlayFrame(string tagCubePlayFrame)
        {
            float newCoordinateY = -100f;
            GameObject cubePlayFrame = CommonMethods.GetObjectByTagName(tagCubePlayFrame);
            CommonMethods.SetUpNewYForGameObject(cubePlayFrame, newCoordinateY);

        }

        // it does not work for case -> sceneGame, do not clik on the bord game, click the menu configuration, cubePlayFrame does not move, if clik on field A1 then configuration it works
        //public static void HideCubePlayFrame2(GameObject cubePlayFrame)
        //{
        //    Debug.Log(" cubePlayFrame.name =  " + cubePlayFrame.name);
        //    float newCoordinateY = -100f;

        //    CommonMethods.SetUpNewYForGameObject(cubePlayFrame, newCoordinateY);

        //    float x = cubePlayFrame.transform.position.x;
        //    float y = cubePlayFrame.transform.position.y;
        //    float z = cubePlayFrame.transform.position.z;

        //    Debug.Log(" y =  " + y);
        //    Debug.Log(" y + newCoordinateY =  " + (y + newCoordinateY));
        //    float newY = y + newCoordinateY;

        //    cubePlayFrame.transform.position = new Vector3(x, newY, z);

        //}

        public static void HideHelpButtons()
        {

        }

        // ---
        public static void UnhideConfigurationMenu(GameObject gameBoard)
        {
 

        }
    }
}
