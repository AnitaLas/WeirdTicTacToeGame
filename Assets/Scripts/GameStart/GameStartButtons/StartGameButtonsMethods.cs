using UnityEngine;
using Assets.Scripts;
using Assets;

namespace Assets.Scripts
{
    internal class StartGameButtonsMethods
    {
        public static GameObject[,,] CreateButtonForInformations(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] buttonInformation;

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 3;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            buttonInformation = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            return buttonInformation;
        }

        public static void ChangeDataForSingleStartGameButtonInformations(GameObject[,,] singleConfigurationButtonTable, string tagToSetUp)
        {
            int maxIndexDepth = singleConfigurationButtonTable.GetLength(0);
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            float newCoordinateZ = 0.4f;
            float fontSize = 0.5f;
            float newScale = 0.8f;

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

        public static void ChangingCoordinatesXYButtons(GameObject[,,] singleConfigurationButtonTable, float newCoordinateX, float newCoordinateY)
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
                        GameCommonMethodsSetUpCoordinates.ChangeXForGameObject(cubePlay, newCoordinateX);
                        GameCommonMethodsSetUpCoordinates.ChangeYForGameObject(cubePlay, newCoordinateY);
                    }
                }
            }
        }
    }
}
