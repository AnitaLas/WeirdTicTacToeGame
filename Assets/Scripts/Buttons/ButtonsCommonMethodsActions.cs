using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class ButtonsCommonMethodsActions
    {
        public static void GameObjectToHide(List<GameObject[,,]> gameObjects)
        {
            float newCoordinateY = 100f;
            ButtonsCommonMethods.ChangeCoordinateYForGameObjectOneList(gameObjects, newCoordinateY);
        }

        public static void GameObjectToUnhide(List<GameObject[,,]> gameObjects)
        {
            float newCoordinateY = -100f;
            ButtonsCommonMethods.ChangeCoordinateYForGameObjectOneList(gameObjects, newCoordinateY);
        }

        // ---
        public static void GameObjectToHide(GameObject[,,] tableWtithNumber)
        {
            float newCoordinateY = 100f;
            ButtonsCommonMethods.ChangeCoordinateYForTable(tableWtithNumber, newCoordinateY);
        }

        public static void GameObjectToUnhide(GameObject[,,] tableWtithNumber)
        {
            float newCoordinateY = -100f;
            ButtonsCommonMethods.ChangeCoordinateYForTable(tableWtithNumber, newCoordinateY);
        }

        // ---

        public static void GameObjectToHide(List<List<GameObject[,,]>> gameObjectsLists)
        {
            float newCoordinateY = 100f;
            ButtonsCommonMethods.ChangeCoordinateYForGameObjectLists(gameObjectsLists, newCoordinateY);
        }

        public static void GameObjectToUnhide(List<List<GameObject[,,]>> gameObjectsLists)
        {
            float newCoordinateY = -100f;
            ButtonsCommonMethods.ChangeCoordinateYForGameObjectLists(gameObjectsLists, newCoordinateY);
        }

        // ---

        public static void GameObjectToHide(string gameObjectTagName)
        {
            float newCoordinateY = 100f;
            ButtonsCommonMethods.ChangeCoordinateYForOneGameObjectByTagName(gameObjectTagName, newCoordinateY);
        }

        public static void GameObjectToUnhide(string gameObjectTagName)
        {
            float newCoordinateY = -100f; ;
            ButtonsCommonMethods.ChangeCoordinateYForOneGameObjectByTagName(gameObjectTagName, newCoordinateY);
        }

        // ---

        public static void GameObjectToHide(Dictionary<int, string> gameObjectTagsName)
        {
            float newCoordinateY = 100f;
            ButtonsCommonMethods.ChangeCoordinateYForGameObjectsTagName(gameObjectTagsName, newCoordinateY);
        }

        public static void GameObjectToUnhide(Dictionary<int, string> gameObjectTagsName)
        {
            float newCoordinateY = -100f; ;
            ButtonsCommonMethods.ChangeCoordinateYForGameObjectsTagName(gameObjectTagsName, newCoordinateY);
        }
    }
}