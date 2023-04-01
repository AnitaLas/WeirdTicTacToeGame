using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayGameMenu
{
    internal class ButtonsCommonMethods
    {

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

            }

            return numbers;

        }

        public static string[] CreateTableWithTextForPrefabCubePlay2(int numberOfDepths, int numberOfRows, int numberOfColumns, List<string[]> textForHelpButtonLines)
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

            string[] lineOne = textForHelpButtonLines[0];

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

            }

            return numbers;

        }

        public static string[,,] CreateTableWithTextForPrefabCubePlay(int numberOfDepths, int numberOfRows, int numberOfColumns, string[] textForHelpButtonLines)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];

            string[] numbers = CreateTableWithTextForPrefabCubePlay(numberOfRows, numberOfColumns, textForHelpButtonLines);

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


        //--


        public static GameObject[,,] CreateSingleConfigurationButton(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns,Material[] prefabCubePlayDefaultColour, bool isGame2D, string[] textForHelpButtonLines)
        {
            //int numberOfDepths = 1;
            //int numberOfRows = 3;
            //int numberOfColumns = 14;

            //string[] textForHelpButtonLines1 = new string[3];
            //textForHelpButtonLines1[0] = "    HIDE    ";
            //textForHelpButtonLines1[1] = "            ";
            //textForHelpButtonLines1[2] = "HELP BUTTONS";

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = ButtonsCommonMethods.CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }

        public static GameObject[,,] CreateSingleConfigurationButton2(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, List<string[]> listForButtonNewGame)
        {
            //int numberOfDepths = 1;
            //int numberOfRows = 3;
            //int numberOfColumns = 14;

            //string[] textForHelpButtonLines1 = new string[3];
            //textForHelpButtonLines1[0] = "    HIDE    ";
            //textForHelpButtonLines1[1] = "            ";
            //textForHelpButtonLines1[2] = "HELP BUTTONS";

            //string[] textForHelpButtonLines = new string[numberOfRows];

            //textForHelpButtonLines[0] = listForButtonNewGame[0];

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = ButtonsCommonMethods.CreateTableWithTextForPrefabCubePlay2(numberOfDepths, numberOfRows, numberOfColumns, listForButtonNewGame);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }

        public static void ChangeDataForSingleConfigurationButton(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, string tagToSetUp)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            float newCoordinateZ = 0.175f;
            float fontSize = 0.5f;
            float newScale = 0.5f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {

                        GameObject cubePlay = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];

                        CommonMethods.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);

                        CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZ);

                        CommonMethods.ChangeTextFontSize(cubePlay, fontSize);

                        CommonMethods.ChangeTagForGameObject(cubePlay, tagToSetUp);

                    }
                }
            }

        }

    }
}
