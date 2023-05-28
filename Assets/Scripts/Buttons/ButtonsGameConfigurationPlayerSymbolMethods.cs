using Assets.Scripts.CommonMethods;
using Assets.Scripts.GameDictionaries;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts.Buttons
{
    internal class ButtonsGameConfigurationPlayerSymbolMethods
    {     
        public static void ChangeGameConfigurationPlayerSymbolInformationButtonsWithPlayerNumber(GameObject[,,] singleConfigurationButtonTable)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();
            string tagName = tagNameDictionary[3];

            GameObject gameObject = CommonMethodsMain.GetObjectByTagName(tagName);
            string gameObjectName = CommonMethodsMain.GetObjectName(gameObject);

            int gameObjectNameLenght = gameObjectName.Length;
            int startIndex = gameObjectNameLenght - 2;

            string playerNumber = gameObjectName.Substring(startIndex, 2);
            string zeroNumber = playerNumber.Substring(0, 1);
            string stringToCompare = "0";
            string playerNumberToSetUp;

            if (zeroNumber.Equals(stringToCompare))
            {
                playerNumberToSetUp = playerNumber.Substring(1,1);
            }
            else
            {
                playerNumberToSetUp = playerNumber;
            }

            int maxIndexDepth = singleConfigurationButtonTable.GetLength(0);
            int maxIndexColumn = singleConfigurationButtonTable.GetLength(2);
            int maxIndexRow = singleConfigurationButtonTable.GetLength(1);

            float newCoordinateY = 4.1f;
            float newCoordinateX = 1.75f;
            float newCoordinateZ = 0.5f;
            float fontSize = 0.45f;
            float newScale = 1f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = singleConfigurationButtonTable[indexDepth, indexRow, indexColumn];
                        CommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        CommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        CommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        CommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        CommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        CommonMethodsMain.ChangeTextForCubePlay(cubePlay, playerNumberToSetUp);
                    }
                }
            }
        }
    }
}
