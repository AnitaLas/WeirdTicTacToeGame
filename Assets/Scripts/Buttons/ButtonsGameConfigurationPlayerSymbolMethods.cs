using Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers;
using Assets.Scripts.GameConfiguration.GameConfigurationButtonsCommon;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Buttons
{
    internal class ButtonsGameConfigurationPlayerSymbolMethods
    {
        // --- button name "PLAYER 1"
        public static GameObject[,,] GameConfigurationPlayerSymbolCreateOneButtonForPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, string buttonText)
        {

            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return buttonBack;
        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolAllCreateButtonsForPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, int playersNumber, string[] defaultTextForButtons)
        {
            string finalTextForButton;

            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            for (int i = 0; i < playersNumber; i++)
            {
                finalTextForButton = defaultTextForButtons[i];
                GameObject[,,] buttonBack = GameConfigurationPlayerSymbolCreateOneButtonForPlayerNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, finalTextForButton);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }

        // --- button with symbol "X"
        public static GameObject[,,] GameConfigurationPlayerSymbolCreateOneButtonForPlayerSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, string buttonText)
        {

            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonForSymbol(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return buttonBack;
        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolAllCreateButtonsForPlayerSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, int playersNumber, string[] defaultTextForButtons)
        {
            string finalTextForButton;

            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            for (int i = 0; i < playersNumber; i++)
            {
                finalTextForButton = defaultTextForButtons[i];
                GameObject[,,] buttonBack = GameConfigurationPlayerSymbolCreateOneButtonForPlayerSymbol(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, finalTextForButton);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }

        public static void ChangeGameConfigurationPlayerSymbolInformationButtonsWithPlayerNumber(GameObject[,,] singleConfigurationButtonTable)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();
            string tagName = tagNameDictionary[3];


            GameObject gameObject = CommonMethods.GetObjectByTagName(tagName);
            string gameObjectName = CommonMethods.GetObjectName(gameObject);
            Debug.Log("gameObjectName = " + gameObjectName);

            int gameObjectNameLenght = gameObjectName.Length;
            //Debug.Log("gameObjectNameLenght = " + gameObjectNameLenght);

            int startIndex = gameObjectNameLenght - 2;
           // Debug.Log("startIndex = " + startIndex);

            //string playerNumber = gameObjectName.Substring(startIndex, gameObjectNameLenght);
            string playerNumber = gameObjectName.Substring(startIndex, 2);
            //Debug.Log("playerNumber = " + playerNumber);

            string zeroNumber = playerNumber.Substring(0, 1);

            string playerNumberToSetUp;

            if (zeroNumber.Equals("0"))
            {
                playerNumberToSetUp = playerNumber.Substring(1,1);
                Debug.Log("playerNumberToSetUp = " + playerNumberToSetUp);
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
                        CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        CommonMethods.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        CommonMethods.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        CommonMethods.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        CommonMethods.ChangeTextFontSize(cubePlay, fontSize);
                        CommonMethods.ChangeTextForCubePlay(cubePlay, playerNumber);
                        //CommonMethods.ChangeTextForCubePlay(cubePlay, playerNumberToSetUp);

                    }
                }
            }

        }
    }
}
