using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Buttons
{
    internal class StartGameButtonsMethods
    {

        public static GameObject[,,] CreateButtonForInformations(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] buttonInformation;

            int numberOfDepths = 1;
            int numberOfRows = 1;
            int numberOfColumns = 1;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            buttonInformation = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            return buttonInformation;

        }

        public static void ChangeDataForSingleStartGameButtonInformations(GameObject[,,] singleConfigurationButtonTable, string tagToSetUp)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            float newCoordinateZ = 0.4f;
            float fontSize = 0.7f;
            float newScale = 0.8f;

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

        public static void ChangingCoordinatesXYButtons(GameObject[,,] singleConfigurationButtonTable, float newCoordinateX, float newCoordinateY)
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

                        CommonMethods.ChangeXForGameObject(cubePlay, newCoordinateX);
                        CommonMethods.ChangeYForGameObject(cubePlay, newCoordinateY);

                    }
                }
            }
        }

    }
}
