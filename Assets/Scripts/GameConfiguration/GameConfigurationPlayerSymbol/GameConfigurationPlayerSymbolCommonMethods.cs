using Assets.Scripts.PlayGameMenu;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.CommonMethods;

namespace Assets.Scripts.GameConfigurationPlayerSymbol
{
    internal class GameConfigurationPlayerSymbolCommonMethods
    {      
        public static void ChangeTagForPlayerDefaultSymbol(string gameObjectName, string gameObjectTagNameToChange, string tagConfigurationPlayerSymbolDefaultSymbol)
        {
            GameObject[] listOfSymbol = CommonMethodsMain.GetObjectsListWithTagName(tagConfigurationPlayerSymbolDefaultSymbol);
            int tagNumber = listOfSymbol.Length;
      
            string gameObjectNameEndNumber = ButtonsCommonMethods.GetSubstringFromCubePlayName(gameObjectName);

            for (int i = 0; i < tagNumber; i++)
            {
                GameObject cubePlay = listOfSymbol[i];
                string gameObjectNameToCompare = CommonMethodsMain.GetObjectName(cubePlay);
                string gameObjectNameNumberToCompare = ButtonsCommonMethods.GetSubstringFromCubePlayName(gameObjectNameToCompare);

                if (gameObjectNameEndNumber.Equals(gameObjectNameNumberToCompare))
                {
                    CommonMethodsMain.ChangeTagForGameObject(cubePlay, gameObjectTagNameToChange);
                }
            }
        }

        //public static void ChangeCoordinateYForTable(GameObject[,,] tableWtithNumber, float newCoordinateZ)
        //{
        //    int maxIndexDepth = 1;
        //    int maxIndexColumn = tableWtithNumber.GetLength(2);
        //    int maxIndexRow = tableWtithNumber.GetLength(1);

        //    for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
        //    {
        //        for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
        //        {
        //            for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
        //            {
        //                GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
        //                CommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateZ);

        //            }
        //        }
        //    }
        //}

        public static void ChangeSymbolForPlayer(string newSymbol, string tagConfigurationPlayerSymbolChooseSymbol)
        {
            GameObject objectWithChosenSymbol = CommonMethodsMain.GetObjectByTagName(tagConfigurationPlayerSymbolChooseSymbol);
            CommonMethodsMain.ChangeTextForFirstChild(objectWithChosenSymbol, newSymbol);
        }

        public static void ChangeGameObjectTag(string currentTag, string newTag)
        {
            GameObject gameObject = CommonMethodsMain.GetObjectByTagName(currentTag);
            CommonMethodsMain.ChangeTagForGameObject(gameObject, newTag);
        }

        public static void ChangeChosenSymbolForPlayer(RaycastHit touch, string tagConfigurationPlayerSymbolChange, string tagConfigurationPlayerSymbolDefaultSymbol)
        {
            string gameObjectNameForChosenSymbol = CommonMethodsMain.GetObjectName(touch);
            GameObject gameObjectForChosenSymbol = CommonMethodsMain.GetObjectByName(gameObjectNameForChosenSymbol);
            string newSymbol = CommonMethodsMain.GetCubePlayText(gameObjectForChosenSymbol);

            ChangeSymbolForPlayer(newSymbol, tagConfigurationPlayerSymbolChange);
            ChangeGameObjectTag(tagConfigurationPlayerSymbolChange, tagConfigurationPlayerSymbolDefaultSymbol);
        }
    }
}
