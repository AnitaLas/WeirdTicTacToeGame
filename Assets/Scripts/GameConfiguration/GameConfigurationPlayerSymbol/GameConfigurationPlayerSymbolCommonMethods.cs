using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationPlayerSymbolCommonMethods
    {
        public static void ChangeTagForPlayerDefaultSymbol(string gameObjectName, string gameObjectTagNameToChange, string tagConfigurationPlayerSymbolDefaultSymbol)
        {
            GameObject[] listOfSymbol = GameCommonMethodsMain.GetObjectsListWithTagName(tagConfigurationPlayerSymbolDefaultSymbol);
            int tagNumber = listOfSymbol.Length;

            string gameObjectNameEndNumber = ButtonsCommonMethods.GetSubstringFromCubePlayName(gameObjectName);

            for (int i = 0; i < tagNumber; i++)
            {
                GameObject cubePlay = listOfSymbol[i];
                string gameObjectNameToCompare = GameCommonMethodsMain.GetObjectName(cubePlay);
                string gameObjectNameNumberToCompare = ButtonsCommonMethods.GetSubstringFromCubePlayName(gameObjectNameToCompare);

                if (gameObjectNameEndNumber.Equals(gameObjectNameNumberToCompare))
                    GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, gameObjectTagNameToChange);
            }
        }

        public static void ChangeSymbolForPlayer(string newSymbol, string tagConfigurationPlayerSymbolChooseSymbol)
        {
            GameObject objectWithChosenSymbol = GameCommonMethodsMain.GetObjectByTagName(tagConfigurationPlayerSymbolChooseSymbol);
            GameCommonMethodsMain.ChangeTextForFirstChild(objectWithChosenSymbol, newSymbol);
        }

        public static void ChangeGameObjectTag(string currentTag, string newTag)
        {
            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(currentTag);
            GameCommonMethodsMain.ChangeTagForGameObject(gameObject, newTag);
        }

        public static void ChangeChosenSymbolForPlayer(RaycastHit touch, string tagConfigurationPlayerSymbolChange, string tagConfigurationPlayerSymbolDefaultSymbol)
        {
            string gameObjectNameForChosenSymbol = GameCommonMethodsMain.GetObjectName(touch);
            GameObject gameObjectForChosenSymbol = GameCommonMethodsMain.GetObjectByName(gameObjectNameForChosenSymbol);
            string newSymbol = GameCommonMethodsMain.GetCubePlayText(gameObjectForChosenSymbol);

            ChangeSymbolForPlayer(newSymbol, tagConfigurationPlayerSymbolChange);
            ChangeGameObjectTag(tagConfigurationPlayerSymbolChange, tagConfigurationPlayerSymbolDefaultSymbol);
        }
    }
}