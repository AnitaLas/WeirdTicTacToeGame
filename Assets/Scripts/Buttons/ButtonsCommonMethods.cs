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



        //--


        public static GameObject[,,] CreateSingleConfigurationButton(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns,Material[] prefabCubePlayDefaultColour, bool isGame2D, string[] textForHelpButtonLines)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);

            return tableWithNumber;
        }

      
        
        public static void ChangeDataForSingleGameButtons(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, string tagToSetUp)
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
                        CommonMethods.ChangeZForGameObject(cubePlay, newCoordinateZ);

                        CommonMethods.ChangeTextFontSize(cubePlay, fontSize);

                        CommonMethods.ChangeTagForGameObject(cubePlay, tagToSetUp);

                    }
                }
            }

        }
        

        public static void ChangeDataForSingleCommonButton(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, float newCoordinateX, string tagToSetUp)
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

                        // to do -> create a different method that will set up only those two parameters
                        //CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        //CommonMethods.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        CommonMethods.ChangeZForGameObject(cubePlay, newCoordinateZ);

                        CommonMethods.ChangeTextFontSize(cubePlay, fontSize);

                        CommonMethods.ChangeTagForGameObject(cubePlay, tagToSetUp);

                    }
                }
            }

            // --- works only for 4x cubePlay - to fix
            ChangeCoordinateXYForPrefabCubePlay(singleConfigurationButtonTable, newScale);
            ChangeCoordinateXYForPrefabCubePlay2(singleConfigurationButtonTable, newScale);


        }

        // ----------------------------

        public static GameObject[,,] CreateSingleConfigurationButton2(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, string[] nameForButton)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, nameForButton);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);

            return tableWithNumber;
        }

        public static string[] CreateTableWithTextForPrefabCubePlay(int numberOfRows, int numberOfColumns, string[] nameForButton)
        {
            int indexNumber = 0;
            int indexTextLineOne = 0;
            int indexTextLineTwo = 0;
            int indexTextLineThree = 0;
            int allNumbers = numberOfRows * numberOfColumns;
            string[] numbers = new string[allNumbers];
            string symbol;

            string emptyValue = "";
            string[] tableWithEmptyText = CommonMethods.CreateTableWithGivenLengthAndGivenValue(numberOfColumns, emptyValue);

            for (int number = 1; number <= allNumbers; number++)
            {

                if (numberOfRows == 1)
                {
                    symbol = nameForButton[indexTextLineTwo];
                    indexNumber = number - 1;
                    numbers[indexNumber] = symbol;
                    indexTextLineTwo = indexTextLineTwo + 1;
                    indexNumber = indexNumber + 1;
                }

                if (numberOfRows > 1)
                {
                    if (number < numberOfColumns - 1)
                    {
                        //symbol = textForHelpButtonLineOne.Substring(indexTextLineOne, 1);
                        symbol = tableWithEmptyText[indexTextLineOne];

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

                        //symbol = textForHelpButtonLineTwo.Substring(indexTextLineTwo, 1);

                        symbol = nameForButton[indexTextLineTwo];
                        indexNumber = number - 1;
                        numbers[indexNumber] = symbol;
                        indexTextLineTwo = indexTextLineTwo + 1;
                        indexNumber = indexNumber + 1;

                    }

                    if (number <= numberOfColumns * 3 && number > numberOfColumns * 2)
                    {
                        //symbol = "x";
                        //symbol = textForHelpButtonLineThree.Substring(indexTextLineThree, 1);

                        symbol = tableWithEmptyText[indexTextLineThree];

                        indexNumber = number - 1;
                        numbers[indexNumber] = symbol;
                        indexTextLineThree = indexTextLineThree + 1;
                        indexNumber = indexNumber + 1;

                    }
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


        public static void ChangeCoordinateXYForPrefabCubePlay(GameObject[,,] singleConfigurationButtonTable, float newScale)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            //float baseScale = 1;
            //float difference = baseScale - newScale;
            float difference = newScale;

            //float increaseDifference = difference;

            GameObject cubePlay;
            GameObject cubePlayForX;

            float newStartX;
            float newStartY;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    //float newStartX = 
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {

                        cubePlay = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        //float x = cubePlay.transform.position.x;
                        //Debug.Log(" x = " + x);



                        //if (maxIndexColumn > 4)
                       // {

                            //if (indexColumn == 1)
                            //{
                            //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            //    float x = cubePlayForX.transform.position.x;
                            //    // float newX = x - increaseDifference;
                            //    //float newX = x - (difference * indexColumn);
                            //    //float newX = x - (difference/2);
                            //    newStartX = x - newScale * 1.1f;
                            //    //newStartX = x - 0.5f;
                            //    //Debug.Log(" newScale = " + newScale);
                            //    //Debug.Log(" x = " + x);
                            //    //Debug.Log(" newStartX = " + newStartX);

                            //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                            //}
                        
                        
                            //if (indexColumn == 1)
                            //{
                            //Debug.Log(" 1 ");
                            //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            //    float x = cubePlayForX.transform.position.x;
                            //    // float newX = x - increaseDifference;
                            //    //float newX = x - (difference * indexColumn);
                            //    //float newX = x - (difference/2);
                            //    newStartX = x - newScale * 1.1f;
                            //    //newStartX = x - 0.5f;
                            //    //Debug.Log(" newScale = " + newScale);
                            //    //Debug.Log(" x = " + x);
                            //    //Debug.Log(" newStartX = " + newStartX);

                            //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                            //}

                            
                            //if (indexColumn >= 2 && indexColumn < maxIndexColumn - 1)
                            //{
                            //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                            //    float x = cubePlayForX.transform.position.x;
                            //    // float newX = x - increaseDifference;
                            //    //float newX = x - (difference * indexColumn);
                            //    //float newX = x - (difference/2);
                            //    newStartX = x + newScale;
                            //    //Debug.Log(" newScale = " + newScale);
                            //    //Debug.Log(" x = " + x);
                            //    //Debug.Log(" newStartX = " + newStartX);

                            //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                            //}


                            //if (indexColumn > 1 && indexColumn < maxIndexColumn - 1)
                            //{
                            //    Debug.Log(" 2 ");
                            //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                            //    float x = cubePlayForX.transform.position.x;
                            //    // float newX = x - increaseDifference;
                            //    //float newX = x - (difference * indexColumn);
                            //    //float newX = x - (difference/2);
                            //    newStartX = x + newScale;
                            //    //Debug.Log(" newScale = " + newScale);
                            //    //Debug.Log(" x = " + x);
                            //    //Debug.Log(" newStartX = " + newStartX);

                            //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                            //}



                            //if (maxIndexColumn - 1 <= 4)
                            //{
                            //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            //    float x = cubePlayForX.transform.position.x;

                            //    newStartX = x + newScale;
                            //    //Debug.Log(" newScale = " + newScale);
                            //    //Debug.Log(" x = " + x);
                            //    //Debug.Log(" newStartX = " + newStartX);

                            //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                            //}




                            //if (indexColumn == maxIndexColumn - 1)
                            //{
                            //    Debug.Log(" 3 ");
                            //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                            //    float x = cubePlayForX.transform.position.x;
                            //    // float newX = x - increaseDifference;
                            //    //float newX = x - (difference * indexColumn);
                            //    //float newX = x - (difference/2);
                            //    newStartX = x + newScale * 0.5f;
                            //    //newStartX = x - 0.5f;
                            //    //Debug.Log(" newScale = " + newScale);
                            //    //Debug.Log(" x = " + x);
                            //    //Debug.Log(" newStartX = " + newStartX);

                            //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                            //}


                            if (indexRow >= 1)
                            {
                                Debug.Log(" 4 ");
                                cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow - 1, indexColumn];
                                float y = cubePlayForX.transform.position.y;

                                //newStartY = y + newScale / 2.5f;
                                newStartY = y + newScale;

                                //Debug.Log(" newScale = " + newScale);
                                //Debug.Log(" y = " + y);
                                //Debug.Log(" newStartX = " + newStartX);

                                CommonMethods.ChangeYForGameObject(cubePlay, newStartY);
                            }



                        if (indexColumn >= 1)
                        {
                            Debug.Log(" 3 ");
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                            float x = cubePlayForX.transform.position.x;

                            //newStartX = x + newScale * 0.5f;
                            newStartX = x + newScale;
                            //newStartX = x + newScale / 2.5f;
            
                            //Debug.Log(" newScale = " + newScale);
                            //Debug.Log(" x = " + x);
                            //Debug.Log(" newStartX = " + newStartX);

                            CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        }
                        // }


                        //if (indexColumn == 0)
                        //{
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        //    float x = cubePlayForX.transform.position.x;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartX = x + 1f;
                        //    //newStartX = x - 0.5f;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}

                        //if (indexColumn == maxIndexColumn - 1)
                        //{
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        //    float x = cubePlayForX.transform.position.x;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartX = x - newScale * 1.1f;
                        //    //newStartX = x - 0.5f;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}


                        //if (maxIndexColumn <= 4)
                        //{

                        //    if (indexRow >= 0)
                        //    {
                        //        cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        //        float y = cubePlayForX.transform.position.y;
                        //        // float newX = x - increaseDifference;
                        //        //float newX = x - (difference * indexColumn);
                        //        //float newX = x - (difference/2);
                        //        newStartY = y - newScale;
                        //        //Debug.Log(" newScale = " + newScale);
                        //        //Debug.Log(" y = " + y);
                        //        //Debug.Log(" newStartX = " + newStartX);

                        //        CommonMethods.ChangeYForGameObject(cubePlay, newStartY);
                        //    }


                        //    if (indexColumn >= 0)
                        //    {
                        //        cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        //        float x = cubePlayForX.transform.position.x;
                        //        // float newX = x - increaseDifference;
                        //        //float newX = x - (difference * indexColumn);
                        //        //float newX = x - (difference/2);
                        //        newStartX = x - newScale;
                        //        //Debug.Log(" newScale = " + newScale);
                        //        //Debug.Log(" y = " + y);
                        //        //Debug.Log(" newStartX = " + newStartX);

                        //        CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //    }
                        //}







                        //if (indexColumn == 1)
                        //{
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        //    float x = cubePlayForX.transform.position.x;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartX = x - newScale * 1.1f;
                        //    //newStartX = x - 0.5f;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}



                        //if (indexColumn >= 2 && indexColumn < maxIndexColumn - 1)
                        //{
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                        //    float x = cubePlayForX.transform.position.x;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartX = x + newScale;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}


                        //if (indexColumn == maxIndexColumn - 1)
                        //{
                        //    //Debug.Log(" 1 ");
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                        //    float x = cubePlayForX.transform.position.x;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartX = x + newScale * 0.5f;
                        //    //newStartX = x - 0.5f;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}


                        //if (indexRow >= 1)
                        //{
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow - 1, indexColumn];
                        //    float y = cubePlayForX.transform.position.y;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartY = y + newScale / 2.5f;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" y = " + y);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeYForGameObject(cubePlay, newStartY);
                        //}














                    }
                }
            }


        }

        public static void ChangeCoordinateXYForPrefabCubePlay2(GameObject[,,] singleConfigurationButtonTable, float newScale)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            //float baseScale = 1;
            //float difference = baseScale - newScale;
            float difference = newScale;

            //float increaseDifference = difference;

            GameObject cubePlay;
            GameObject cubePlayForX;

            float newStartX;
            float newStartY;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    //float newStartX = 
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {

                        cubePlay = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        //float x = cubePlay.transform.position.x;
                        //Debug.Log(" x = " + x);



                        //if (maxIndexColumn > 4)
                        // {

                        //if (indexColumn == 1)
                        //{
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        //    float x = cubePlayForX.transform.position.x;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartX = x - newScale * 1.1f;
                        //    //newStartX = x - 0.5f;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}


                        //if (indexColumn == 1)
                        //{
                        //Debug.Log(" 1 ");
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        //    float x = cubePlayForX.transform.position.x;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartX = x - newScale * 1.1f;
                        //    //newStartX = x - 0.5f;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}


                        //if (indexColumn >= 2 && indexColumn < maxIndexColumn - 1)
                        //{
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                        //    float x = cubePlayForX.transform.position.x;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartX = x + newScale;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}


                        //if (indexColumn > 1 && indexColumn < maxIndexColumn - 1)
                        //{
                        //    Debug.Log(" 2 ");
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                        //    float x = cubePlayForX.transform.position.x;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartX = x + newScale;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}



                        //if (maxIndexColumn - 1 <= 4)
                        //{
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        //    float x = cubePlayForX.transform.position.x;

                        //    newStartX = x + newScale;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}




                        //if (indexColumn == maxIndexColumn - 1)
                        //{
                        //    Debug.Log(" 3 ");
                        //    cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                        //    float x = cubePlayForX.transform.position.x;
                        //    // float newX = x - increaseDifference;
                        //    //float newX = x - (difference * indexColumn);
                        //    //float newX = x - (difference/2);
                        //    newStartX = x + newScale * 0.5f;
                        //    //newStartX = x - 0.5f;
                        //    //Debug.Log(" newScale = " + newScale);
                        //    //Debug.Log(" x = " + x);
                        //    //Debug.Log(" newStartX = " + newStartX);

                        //    CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        //}



                        // }


                        if (indexColumn == 0)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float x = cubePlayForX.transform.position.x;

                            // float newX = x - increaseDifference;
                            //float newX = x - (difference * indexColumn);
                            //float newX = x - (difference/2);
                            newStartX = x + newScale * 0.75f;
                            //newStartX = x - 0.5f;
                            //Debug.Log(" newScale = " + newScale);
                            //Debug.Log(" x = " + x);
                            //Debug.Log(" newStartX = " + newStartX);

                            CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        }


                        if (indexColumn == maxIndexColumn - 1)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float x = cubePlayForX.transform.position.x;

                            // float newX = x - increaseDifference;
                            //float newX = x - (difference * indexColumn);
                            //float newX = x - (difference/2);
                            newStartX = x - newScale * 0.75f;
                            //newStartX = x - 0.5f;
                            //Debug.Log(" newScale = " + newScale);
                            //Debug.Log(" x = " + x);
                            //Debug.Log(" newStartX = " + newStartX);

                            CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        }

                        if (indexRow == 0)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float y = cubePlayForX.transform.position.y;
                            // float newX = x - increaseDifference;
                            //float newX = x - (difference * indexColumn);
                            //float newX = x - (difference/2);
                            newStartY = y + newScale * 0.75f;
                            //Debug.Log(" newScale = " + newScale);
                            //Debug.Log(" y = " + y);
                            //Debug.Log(" newStartX = " + newStartX);

                            CommonMethods.ChangeYForGameObject(cubePlay, newStartY);
                        }

                        if (indexRow == maxIndexRow - 1)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float y = cubePlayForX.transform.position.y;
                            // float newX = x - increaseDifference;
                            //float newX = x - (difference * indexColumn);
                            //float newX = x - (difference/2);
                            newStartY = y - newScale * 0.75f;
                            //Debug.Log(" newScale = " + newScale);
                            //Debug.Log(" y = " + y);
                            //Debug.Log(" newStartX = " + newStartX);

                            CommonMethods.ChangeYForGameObject(cubePlay, newStartY);
                        }












                    }
                }
            }


        }

    }
}
