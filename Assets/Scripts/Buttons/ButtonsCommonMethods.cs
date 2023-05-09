using Assets.Scripts.Buttons;
using Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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


        public static GameObject[,,] CreateSingleConfigurationButton(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, string[] textForHelpButtonLines)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethodsForButtons.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);

            return tableWithNumber;
        }



        public static void ChangeDataForSingleGameButtons(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, string tagToSetUp)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            //float newCoordinateZ = 0.175f;
            float newCoordinateZ = 0.25f;
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

        public static void ChangeDataForSingleGameConfigurationButtons(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, string tagToSetUp)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            float newCoordinateZ = 0.175f;
            float fontSize = 0.7f;
            float newScale = 0.3f;

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

            /// it must be remove from here !!!
            // float newScale = 0.3f;
            //CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(singleConfigurationButtonTable, newScale);
        }

       

        public static void ChangeDataForSingleCommonButton(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, float newCoordinateX, string tagToSetUp)
        {
            float newScale = 0.45f;

            ChangeBaseDataForSingleCommonButton(singleConfigurationButtonTable, newScale, tagToSetUp);
            CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(singleConfigurationButtonTable, newScale);
            ChangingCoordinatesXYForBoundaryPrefabCubePlay(singleConfigurationButtonTable, newScale);
            SetUpFinalCoordinatesXYForPrefabCubePlay(singleConfigurationButtonTable, newCoordinateY, newCoordinateX);

        }



        //public static void ChangeDataForSingleGameConfigurationCommonButton(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, float newCoordinateX, string tagToSetUp)
        public static void ChangeDataForSingleGameConfigurationCommonButton(GameObject[,,] singleConfigurationButtonTable, string tagToSetUp)
        {
            float newScale = 0.5f;

            ChangeBaseDataForSingleCommonButton(singleConfigurationButtonTable, newScale, tagToSetUp);
            CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(singleConfigurationButtonTable, newScale);
            ChangingCoordinatesXYForBoundaryPrefabCubePlay(singleConfigurationButtonTable, newScale);
            //SetUpFinalCoordinatesXYFoPrefabCubePlay(singleConfigurationButtonTable, newCoordinateY, newCoordinateX);

        }

        public static void ChangeBaseDataForSingleCommonButton(GameObject[,,] singleConfigurationButtonTable, float newScale, string tagToSetUp)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            //float newCoordinateZ = 0.175f;
            //float newCoordinateZ = 0.2f;
            float newCoordinateZ = 0.225f;
            float fontSize = 0.55f;
            //float newScale = 0.5f;



            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];

                        CommonMethods.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);

                        CommonMethods.ChangeZForGameObject(cubePlay, newCoordinateZ);

                        CommonMethods.ChangeTextFontSize(cubePlay, fontSize);

                        CommonMethods.ChangeTagForGameObject(cubePlay, tagToSetUp);

                    }
                }
            }

        }


        public static void SetUpFinalCoordinatesXYForPrefabCubePlay(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, float newCoordinateX)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);


            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];

                        CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        CommonMethods.SetUpNewXForGameObject(cubePlay, newCoordinateX);

                    }
                }
            }

        }
        // ----------------------------

        //public static GameObject[,,] CreateSingleConfigurationButton2(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode, string[] nameForButton)
        //{
        //    GameObject[,,] tableWithNumber;
        //    string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, nameForButton);
        //    tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode, defaultTextForPrefabCubePlay);

        //    return tableWithNumber;
        //}

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


        public static void CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(GameObject[,,] singleConfigurationButtonTable, float newScale)
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
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {

                        cubePlay = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];

                        if (indexRow >= 1)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow - 1, indexColumn];
                            float y = cubePlayForX.transform.position.y;
                            newStartY = y + newScale;

                            CommonMethods.ChangeYForGameObject(cubePlay, newStartY);
                        }


                        if (indexColumn >= 1)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                            float x = cubePlayForX.transform.position.x;
                            newStartX = x + newScale;

                            CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        }

                    }
                }
            }


        }

        public static void ChangingCoordinatesXYForBoundaryPrefabCubePlay(GameObject[,,] singleConfigurationButtonTable, float newScale)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            GameObject cubePlay;
            GameObject cubePlayForX;

            float newStartX;
            float newStartY;
            float percetageOfNewScale = 0.75f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        cubePlay = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];


                        if (indexColumn == 0)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float x = cubePlayForX.transform.position.x;
                            newStartX = x + newScale * percetageOfNewScale;

                            CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        }


                        if (indexColumn == maxIndexColumn - 1)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float x = cubePlayForX.transform.position.x;
                            newStartX = x - newScale * percetageOfNewScale;

                            CommonMethods.ChangeXForGameObject(cubePlay, newStartX);
                        }

                        if (indexRow == 0)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float y = cubePlayForX.transform.position.y;
                            newStartY = y + newScale * percetageOfNewScale;

                            CommonMethods.ChangeYForGameObject(cubePlay, newStartY);
                        }

                        if (indexRow == maxIndexRow - 1)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float y = cubePlayForX.transform.position.y;
                            newStartY = y - newScale * percetageOfNewScale;

                            CommonMethods.ChangeYForGameObject(cubePlay, newStartY);

                        }
                    }
                }
            }
        }

        // --- 

        public static void ChangeColourForButtonsWithNumbers(List<GameObject[,,]> gameObjects, Material[] materialColour)
        {
            ChangeColourForSpecificGameObjects(gameObjects, materialColour);
        }

        public static void ChangeColourForSpecificGameObjects(List<GameObject[,,]> gameObjects, Material[] materialColour)
        {
            int gameObjectNumber = gameObjects.Count;
            GameObject[,,] table;

            for (int i = 0; i < gameObjectNumber; i++)
            {
                table = gameObjects[i];
                ChangeColourForGameObjectWithNumber(table, materialColour);

            }
        }

        public static void ChangeColourForGameObjectWithNumber(GameObject[,,] tableWtithNumber, Material[] materialColour)
        {
            Material newColour = materialColour[0];
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
                        CommonMethods.ChangeColourForGameObject(cubePlay, newColour);
                    }

                }
            }
        }

        public static bool IsTableWithNumberVisible(GameObject[,,] tableWithNumber)
        {
            bool isTableVisible;
            float y = 70f; // reason -> hide/unkide 100/ -100

            GameObject gameObject = tableWithNumber[0, 0, 0];
            float gameObjectY = gameObject.transform.position.y;

            if (y > gameObjectY)
            {
                isTableVisible = true;
            }
            else
            {
                isTableVisible = false;
            }

            return isTableVisible;
        }


        // --


        public static void ChangeCoordinateYForGameObjectLists(List<List<GameObject[,,]>> gameObjects, float newCoordinateY)
        {
            int gameObjectNumber = gameObjects.Count;
            //List<GameObject[,,]> gameObjectList;

            //for (int i = 0; i < gameObjectNumber; i++)
            //{
            //    gameObjectList = gameObjects[i];
            //    ChangeCoordinateYForGameObjectOneList(gameObjectList, newCoordinateY);

            //}

            foreach (List<GameObject[,,]> gameObjectOneList in gameObjects)
            {
                ChangeCoordinateYForGameObjectOneList(gameObjectOneList, newCoordinateY);
            }
        }


        public static void ChangeCoordinateYForGameObjectOneList(List<GameObject[,,]> gameObjects, float newCoordinateY)
        {
            int gameObjectNumber = gameObjects.Count;
            GameObject[,,] table;

            for (int i = 0; i < gameObjectNumber; i++)
            {
                table = gameObjects[i];
                ChangeCoordinateYForTable(table, newCoordinateY);

            }
        }

        public static void ChangeCoordinateYForOneGameObjectByTagName(string gameObjectTagName, float newCoordinateY)
        {
            GameObject gameOject = CommonMethods.GetObjectByTagName(gameObjectTagName);
            CommonMethods.SetUpNewYForGameObject(gameOject, newCoordinateY);
        }

        public static void ChangeCoordinateYForTable(GameObject[,,] tableWtithNumber, float newCoordinateY)
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
                        CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                    }

                }
            }
        }

        public static void ChangeCoordinateYForGameObjectsTagName(string[] helpButtons, float newCoordinateY)
        {
            string tagName;
            int helpButtonsLength = helpButtons.Length;
            //GameObject topObject;

            for (int i = 0; i < helpButtonsLength; i++)
            {
                //tagName = helpButtons[i];
                //topObject = CommonMethods.GetObjectByTagName(tagName);

                //CommonMethods.SetUpNewYForGameObject(topObject, newCoordinateY);

                tagName = helpButtons[i];
                GameObject[] gameObjects = CommonMethods.GetObjectsListWithTagName(tagName);
                int NumberOfgameObjects = gameObjects.Length;

                for (int j = 0; j < NumberOfgameObjects; j++)
                {
                    GameObject gameObject = gameObjects[j];
                    CommonMethods.SetUpNewYForGameObject(gameObject, newCoordinateY);
                }

            }
        }

        public static void ChangeCoordinateYForGameObjectsTagName(Dictionary<int,string> tagsNameDictionary, float newCoordinateY)
        {
            string tagName;
            int helpButtonsLength = tagsNameDictionary.Count;
            //GameObject topObject;

            for (int i = 1; i <= helpButtonsLength; i++)
            {
                //tagName = helpButtons[i];
                //topObject = CommonMethods.GetObjectByTagName(tagName);

                //CommonMethods.SetUpNewYForGameObject(topObject, newCoordinateY);

                tagName = tagsNameDictionary[i];
                GameObject[] gameObjects = CommonMethods.GetObjectsListWithTagName(tagName);
                int NumberOfgameObjects = gameObjects.Length;

                for (int j = 0; j < NumberOfgameObjects; j++)
                {
                    GameObject gameObject = gameObjects[j];
                    CommonMethods.SetUpNewYForGameObject(gameObject, newCoordinateY);
                }

            }
        }

        public static string[] CreateTableWithefaultTextForButtons(int playersNumber, string buttonText)
        {
            string[] defaultTextForButtons = new string[playersNumber];
            string defaultTextForButton;
            int playerNumber;

            for (int i = 0; i < playersNumber; i++)
            {
                playerNumber = i + 1;
                defaultTextForButton = buttonText + $" {playerNumber}";
                defaultTextForButtons[i] = defaultTextForButton;
            }

            return defaultTextForButtons;
        }

        public static string GetSubstringFromCubePlayName(string gameObjectName)
        {
            int textLength = gameObjectName.Length;
            int startIndex = textLength - 2;
            int searchedTextLength = 2;
            string text = CommonMethods.GetSubstringFromText(gameObjectName, startIndex, searchedTextLength);
            return text;
        }

        public static void ChangeNameForGameConfigurationButtons(GameObject[,,] singleConfigurationButtonTable, string frontTextToAdd)
        {
            int maxIndexDepth = singleConfigurationButtonTable.GetLength(0);
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {

                        GameObject cubePlay = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        string oldName = CommonMethods.GetObjectName(cubePlay);
                        string newName = frontTextToAdd + oldName;
                        CommonMethods.ChangeGameObjectName(cubePlay, newName);
                    }
                }
            }

            //float newScale = 0.3f;
            //CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(singleConfigurationButtonTable, newScale);
        }
    }
}