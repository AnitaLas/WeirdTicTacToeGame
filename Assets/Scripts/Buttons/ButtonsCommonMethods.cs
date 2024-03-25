using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets;

namespace Assets.Scripts
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
            int maxIndexDepth = singleConfigurationButtonTable.GetLength(0);
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

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
                        GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagToSetUp);
                    }
                }
            }
        }

        public static void ChangeDataForSingleGameConfigurationButtons(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, string tagToSetUp)
        {
            int maxIndexDepth = singleConfigurationButtonTable.GetLength(0);
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
                        GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagToSetUp);
                    }
                }
            }
        }
    
        public static void ChangeDataForSingleCommonButton(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, float newCoordinateX, string tagToSetUp)
        {
            float newScale = 0.4f;

            ChangeBaseDataForSingleCommonButton(singleConfigurationButtonTable, newScale, tagToSetUp);
            CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(singleConfigurationButtonTable, newScale);
            ChangingCoordinatesXYForBoundaryPrefabCubePlay(singleConfigurationButtonTable, newScale);
            SetUpFinalCoordinatesXYForPrefabCubePlay(singleConfigurationButtonTable, newCoordinateY, newCoordinateX);
        }

        //public static void ChangeDataForSingleGameConfigurationCommonButton(GameObject[,,] singleConfigurationButtonTable, string tagToSetUp)
        //{
        //    float newScale = 0.5f;

        //    ChangeBaseDataForSingleCommonButton(singleConfigurationButtonTable, newScale, tagToSetUp);
        //    CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(singleConfigurationButtonTable, newScale);
        //    ChangingCoordinatesXYForBoundaryPrefabCubePlay(singleConfigurationButtonTable, newScale);
        //}

        public static void ChangeBaseDataForSingleCommonButton(GameObject[,,] singleConfigurationButtonTable, float newScale, string tagToSetUp)
        {
            int maxIndexDepth = singleConfigurationButtonTable.GetLength(0);
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            float newCoordinateZ = 0.225f;
            float fontSize = 0.55f;
  
            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagToSetUp);
                    }
                }
            }
        }


        public static void SetUpFinalCoordinatesXYForPrefabCubePlay(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, float newCoordinateX)
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
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                    }
                }
            }
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
            string[] tableWithEmptyText = GameCommonMethodsMain.CreateTableWithGivenLengthAndGivenValue(numberOfColumns, emptyValue);

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
                        symbol = tableWithEmptyText[indexTextLineOne];
                        indexNumber = number - 1;
                        numbers[indexNumber] = symbol;
                        indexTextLineOne = indexTextLineOne + 1;
                        indexNumber = indexNumber + 1;
                    }

                    if (number <= numberOfColumns * 2 && number > numberOfColumns)
                    {
                        symbol = nameForButton[indexTextLineTwo];
                        indexNumber = number - 1;
                        numbers[indexNumber] = symbol;
                        indexTextLineTwo = indexTextLineTwo + 1;
                        indexNumber = indexNumber + 1;
                    }

                    if (number <= numberOfColumns * 3 && number > numberOfColumns * 2)
                    {
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
            GameObject cubePlay;
            GameObject cubePlayForX;

            int maxIndexDepth = singleConfigurationButtonTable.GetLength(0);
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            float difference = newScale;
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
                            GameCommonMethodsSetUpCoordinates.ChangeYForGameObject(cubePlay, newStartY);
                        }

                        if (indexColumn >= 1)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn - 1];
                            float x = cubePlayForX.transform.position.x;
                            newStartX = x + newScale;
                            GameCommonMethodsSetUpCoordinates.ChangeXForGameObject(cubePlay, newStartX);
                        }
                    }
                }
            }
        }

        public static void ChangingCoordinatesXYForBoundaryPrefabCubePlay(GameObject[,,] singleConfigurationButtonTable, float newScale)
        {
            GameObject cubePlay;
            GameObject cubePlayForX;

            int maxIndexDepth = singleConfigurationButtonTable.GetLength(0);
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

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
                            GameCommonMethodsSetUpCoordinates.ChangeXForGameObject(cubePlay, newStartX);
                        }

                        if (indexColumn == maxIndexColumn - 1)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float x = cubePlayForX.transform.position.x;
                            newStartX = x - newScale * percetageOfNewScale;
                            GameCommonMethodsSetUpCoordinates.ChangeXForGameObject(cubePlay, newStartX);
                        }

                        if (indexRow == 0)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float y = cubePlayForX.transform.position.y;
                            newStartY = y + newScale * percetageOfNewScale;
                            GameCommonMethodsSetUpCoordinates.ChangeYForGameObject(cubePlay, newStartY);
                        }

                        if (indexRow == maxIndexRow - 1)
                        {
                            cubePlayForX = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                            float y = cubePlayForX.transform.position.y;
                            newStartY = y - newScale * percetageOfNewScale;
                            GameCommonMethodsSetUpCoordinates.ChangeYForGameObject(cubePlay, newStartY);
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

            int maxIndexDepth = tableWtithNumber.GetLength(0);
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsMain.ChangeColourForGameObject(cubePlay, newColour);
                    }
                }
            }
        }

        public static bool IsTableWithNumberVisible(GameObject[,,] tableWithNumber)
        {
            bool isTableVisible;        
            GameObject gameObject = tableWithNumber[0, 0, 0];

            float y = 70f; // reason -> hide/unkide 100/ -100
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
            GameObject gameOject = GameCommonMethodsMain.GetObjectByTagName(gameObjectTagName);
            GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(gameOject, newCoordinateY);
        }

        public static void ChangeCoordinateYForTable(GameObject[,,] tableWtithNumber, float newCoordinateY)
        {
            int maxIndexDepth = tableWtithNumber.GetLength(0);
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                    }
                }
            }
        }

        //public static void ChangeCoordinateYForGameObjectsTagName(string[] helpButtons, float newCoordinateY)
        //{
        //    string tagName;
        //    int helpButtonsLength = helpButtons.Length;

        //    for (int i = 0; i < helpButtonsLength; i++)
        //    {
        //        tagName = helpButtons[i];
        //        GameObject[] gameObjects = GameCommonMethodsMain.GetObjectsListWithTagName(tagName);
        //        int NumberOfgameObjects = gameObjects.Length;

        //        for (int j = 0; j < NumberOfgameObjects; j++)
        //        {
        //            GameObject gameObject = gameObjects[j];
        //            CommonMethodsSetUpCoordinates.SetUpNewYForGameObject(gameObject, newCoordinateY);
        //        }
        //    }
        //}

        public static void ChangeCoordinateYForGameObjectsTagName(Dictionary<int,string> tagsNameDictionary, float newCoordinateY)
        {
            string tagName;
            int helpButtonsLength = tagsNameDictionary.Count;

            for (int i = 1; i <= helpButtonsLength; i++)
            {
                tagName = tagsNameDictionary[i];
                GameObject[] gameObjects = GameCommonMethodsMain.GetObjectsListWithTagName(tagName);
                int NumberOfgameObjects = gameObjects.Length;

                for (int j = 0; j < NumberOfgameObjects; j++)
                {
                    GameObject gameObject = gameObjects[j];
                    GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(gameObject, newCoordinateY);
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

        public static string[] CreateTableWithefaultShortTextForButtons(int playersNumber, string buttonText)
        {
            string[] defaultTextForButtons = new string[playersNumber];
            string defaultTextForButton;
            int playerNumber;

            for (int i = 0; i < playersNumber; i++)
            {
                playerNumber = i + 1;
                defaultTextForButton = buttonText + $"{playerNumber}";
                defaultTextForButtons[i] = defaultTextForButton;
            }

            return defaultTextForButtons;
        }

        public static string GetSubstringFromCubePlayName(string gameObjectName)
        {
            int textLength = gameObjectName.Length;
            int startIndex = textLength - 2;
            int searchedTextLength = 2;
            string text = GameCommonMethodsMain.GetSubstringFromText(gameObjectName, startIndex, searchedTextLength);
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
                        string oldName = GameCommonMethodsMain.GetObjectName(cubePlay);
                        string newName = frontTextToAdd + oldName;
                        GameCommonMethodsMain.ChangeGameObjectName(cubePlay, newName);
                    }
                }
            }
        }

        // buttons change players symbols
        public static void ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(GameObject[,,] singleConfigurationButtonTable, float newCoordinateY, float newCoordinateX)
        {
            int maxIndexDepth = singleConfigurationButtonTable.GetLength(0);
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
                        GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        //GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagToSetUp);
                    }
                }
            }
        }

    }
}