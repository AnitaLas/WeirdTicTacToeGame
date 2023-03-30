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

        public static void CreateConfigurationButtons(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {

            // CreateConfigurationButtonHide(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            // GameObject[,,] tableConfigurationButtonShow = CreateConfigurationButtonShow(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            // GameObject[,,] tableConfigurationButtonNewGame = CreateConfigurationButtonNewGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            //  GameObject[,,] tableConfigurationButtonBackToGame = CreateConfigurationButtonBackToGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            
            //string[] textForHelpButtonLines = new string[3];
            //textForHelpButtonLines[0] = "    SHOW    ";
            //textForHelpButtonLines[1] = "            ";
            //textForHelpButtonLines[2] = "HELP BUTTONS";

            string[] tableWithTextConfigurationButtonShow = new string[3];
            tableWithTextConfigurationButtonShow[0] = "    HIDE    ";
            tableWithTextConfigurationButtonShow[1] = "            ";
            tableWithTextConfigurationButtonShow[2] = "HELP BUTTONS";

            string[] tableWithTextConfigurationButtonNewGame = new string[3];
            tableWithTextConfigurationButtonNewGame[0] = "            ";
            tableWithTextConfigurationButtonNewGame[1] = "  NEW GAME  ";
            tableWithTextConfigurationButtonNewGame[2] = "            ";

            string[] tableWithTextConfigurationButtonBackToGame = new string[3];
            tableWithTextConfigurationButtonBackToGame[0] = "    BACK    ";
            tableWithTextConfigurationButtonBackToGame[1] = "            ";
            tableWithTextConfigurationButtonBackToGame[2] = "   TO GAME  ";


            GameObject[,,] tableConfigurationButtonShow = CreateSingleConfigurationButton(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tableWithTextConfigurationButtonShow);
            GameObject[,,] tableConfigurationButtonNewGame = CreateSingleConfigurationButton(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tableWithTextConfigurationButtonNewGame);
            GameObject[,,] tableConfigurationButtonBackToGame = CreateSingleConfigurationButton(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tableWithTextConfigurationButtonBackToGame);

            float newCoordinateYUp = 2;
            ChangeDataForSingleConfigurationButton(tableConfigurationButtonShow, newCoordinateYUp);

            float newCoordinateYDown = -newCoordinateYUp;
            ChangeDataForSingleConfigurationButton(tableConfigurationButtonBackToGame, newCoordinateYDown);


        }

        public static GameObject[,,] CreateSingleConfigurationButton(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string[] textForHelpButtonLines)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 12;

            //string[] textForHelpButtonLines1 = new string[3];
            //textForHelpButtonLines1[0] = "    HIDE    ";
            //textForHelpButtonLines1[1] = "            ";
            //textForHelpButtonLines1[2] = "HELP BUTTONS";

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }

        public static void ChangeDataForSingleConfigurationButton(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            float newCoordinateZ = 0.175f;
            float fontSize = 0.8f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay= singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];

                        CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateY);

                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZ);

                        CommonMethods.ChangeTextFontSize(cubePlay, fontSize);



                    }
                }
            }

        }
        public static GameObject[,,] CreateConfigurationButtonHide(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 12;

            string[] textForHelpButtonLines = new string[3];
            textForHelpButtonLines[0] = "    HIDE    ";
            textForHelpButtonLines[1] = "            ";
            textForHelpButtonLines[2] = "HELP BUTTONS";

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }

        public static GameObject[,,] CreateConfigurationButtonShow(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 12;

            string[] textForHelpButtonLines = new string[3];
            textForHelpButtonLines[0] = "    SHOW    ";
            textForHelpButtonLines[1] = "            ";
            textForHelpButtonLines[2] = "HELP BUTTONS";

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }

        public static GameObject[,,] CreateConfigurationButtonNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 12;

            string[] textForHelpButtonLines = new string[3];
            textForHelpButtonLines[0] = "            ";
            textForHelpButtonLines[1] = "  NEW GAME  ";
            textForHelpButtonLines[2] = "            ";

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }

        public static GameObject[,,] CreateConfigurationButtonBackToGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 12;

            string[] textForHelpButtonLines = new string[3];
            textForHelpButtonLines[0] = "    BACK    ";
            textForHelpButtonLines[1] = "            ";
            textForHelpButtonLines[2] = "   TO GAME  ";

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }

        // ---

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

        public static string[] CreateTableWithTextForPrefabCubePlay(int numberOfRows, int numberOfColumns, string[] textForHelpButtonLines)
        {
            int indexNumber = 0;
            int indexTextLineOne = 0;
            int indexTextLineTwo = 0;
            int indexTextLineThree = 0;
            int allNumbers = numberOfRows * numberOfColumns;
            string[] numbers = new string[allNumbers];
            string symbol;
            //string textForHelpButtonLineOne = "    HIDE    ";
            //string textForHelpButtonLineTwo = "            ";
            //string textForHelpButtonLineThree = "HELP BUTTONS";
            
            string textForHelpButtonLineOne = textForHelpButtonLines[0];
            string textForHelpButtonLineTwo = textForHelpButtonLines[1];
            string textForHelpButtonLineThree = textForHelpButtonLines[2];

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
                    //symbol = textForHelpButtonLineTwo;
                    ////symbol = "v";
                    //indexNumber = number - 1;
                    //numbers[indexNumber] = symbol;
                    //indexNumber = indexNumber + 1;
                   
                    symbol = textForHelpButtonLineTwo.Substring(indexTextLineTwo, 1);
                    indexNumber = number - 1;
                    numbers[indexNumber] = symbol;
                    indexTextLineTwo = indexTextLineTwo + 1;
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

        public static string[,,] CreateTableWithTextForPrefabCubePlay(int numberOfDepths, int numberOfRows, int numberOfColumns, string[] textForHelpButtonLines)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];

            string[] numbers = CreateTableWithTextForPrefabCubePlay(numberOfRows, numberOfColumns, textForHelpButtonLines);
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
