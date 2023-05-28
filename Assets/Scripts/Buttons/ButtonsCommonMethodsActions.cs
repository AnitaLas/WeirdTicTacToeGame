using Assets.Scripts.PlayGameMenu;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Buttons
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
            float newCoordinateY = -100f;;
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

        // ---

        public static void HideVisibleTablesWithNumber(List<GameObject[,,]> tablesWithNumber)
        {
            GameObject[,,] table;
            GameObject gameObject;

            bool isTableVisible;
            string tagName;
            int tableNumber = tablesWithNumber.Count;

            for (int i = 0; i < tableNumber; i++)
            {
                table = tablesWithNumber[i];
                gameObject = table[0, 0, 0];
                isTableVisible = ButtonsCommonMethods.IsTableWithNumberVisible(table);
                tagName = CommonMethods.GetObjectTag(gameObject);

                if (tagName != null)
                {
                    if (isTableVisible == true)
                    {
                        GameObjectToHide(table);
                    }
                }
            }
        }
    }
}
