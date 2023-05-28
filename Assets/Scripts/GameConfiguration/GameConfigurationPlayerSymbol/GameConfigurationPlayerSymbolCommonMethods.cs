using Assets.Scripts.PlayGameMenu;
using UnityEngine;

namespace Assets.Scripts.GameConfigurationPlayerSymbol
{
    internal class GameConfigurationPlayerSymbolCommonMethods
    {      
        public static void ChangeTagForPlayerDefaultSymbol(string gameObjectName, string gameObjectTagNameToChange, string tagConfigurationPlayerSymbolDefaultSymbol)
        {
            GameObject[] listOfSymbol = CommonMethods.GetObjectsListWithTagName(tagConfigurationPlayerSymbolDefaultSymbol);
            int tagNumber = listOfSymbol.Length;
      
            string gameObjectNameEndNumber = ButtonsCommonMethods.GetSubstringFromCubePlayName(gameObjectName);

            for (int i = 0; i < tagNumber; i++)
            {
                GameObject cubePlay = listOfSymbol[i];
                string gameObjectNameToCompare = CommonMethods.GetObjectName(cubePlay);
                string gameObjectNameNumberToCompare = ButtonsCommonMethods.GetSubstringFromCubePlayName(gameObjectNameToCompare);

                if (gameObjectNameEndNumber.Equals(gameObjectNameNumberToCompare))
                {
                    CommonMethods.ChangeTagForGameObject(cubePlay, gameObjectTagNameToChange);
                }
            }
        }


        public static void ChangeCoordinateYForTable(GameObject[,,] tableWtithNumber, float newCoordinateZ)
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
                        CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateZ);

                    }
                }
            }
        }

        public static void ChangeSymbolForPlayer(string newSymbol, string tagConfigurationPlayerSymbolChooseSymbol)
        {
            GameObject objectWithChosenSymbol = CommonMethods.GetObjectByTagName(tagConfigurationPlayerSymbolChooseSymbol);
            CommonMethods.ChangeTextForFirstChild(objectWithChosenSymbol, newSymbol);
        }


        public static void ChangeGameObjectTag(string currentTag, string newTag)
        {
            GameObject gameObject = CommonMethods.GetObjectByTagName(currentTag);
            CommonMethods.ChangeTagForGameObject(gameObject, newTag);
        }

        public static void ChangeChosenSymbolForPlayer(RaycastHit touch, string tagConfigurationPlayerSymbolChange, string tagConfigurationPlayerSymbolDefaultSymbol)
        {
            string gameObjectNameForChosenSymbol = CommonMethods.GetObjectName(touch);
            GameObject gameObjectForChosenSymbol = CommonMethods.GetObjectByName(gameObjectNameForChosenSymbol);
            string newSymbol = CommonMethods.GetCubePlayText(gameObjectForChosenSymbol);

            ChangeSymbolForPlayer(newSymbol, tagConfigurationPlayerSymbolChange);
            ChangeGameObjectTag(tagConfigurationPlayerSymbolChange, tagConfigurationPlayerSymbolDefaultSymbol);
        }
    }
}
