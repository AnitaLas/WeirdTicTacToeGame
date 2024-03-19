using Assets.Scripts;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts
{
    internal class ButtonsGameConfigurationPlayerSymbolMethods
    {     
        public static void ChangeGameConfigurationPlayerSymbolInformationButtonsWithPlayerNumber(GameObject[,,] singleConfigurationButtonTable)
        {
            //Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagNameConfigurationPlayersSymbols();
            //string tagName = tagNameDictionary[3];
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolChange();

            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(tagName);
            string gameObjectName = GameCommonMethodsMain.GetObjectName(gameObject);

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
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        GameCommonMethodsMain.ChangeTextForCubePlay(cubePlay, playerNumberToSetUp);
                    }
                }
            }
        }
    }
}
