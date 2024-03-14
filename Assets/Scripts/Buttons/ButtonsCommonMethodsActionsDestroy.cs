using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class ButtonsCommonMethodsActionsDestroy : MonoBehaviour
    {
        public static void DestroySingleGameObjectWithTag(string gameObjectTag)
        {
            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(gameObjectTag);
            Destroy(gameObject);
        }

        public static void DestroySingleGameObjectWithTagIfExsist(string gameObjectTagToDestoy)
        {
            bool isGameObjectWithTagExsist = GameCommonMethodsMain.IsGameObjectWithTagExsist(gameObjectTagToDestoy);

            if (isGameObjectWithTagExsist == true)
            {
                DestroySingleGameObjectWithTag(gameObjectTagToDestoy);
            }
        }

        //public static void DestroyGameObjectsWithTag(List<string> gameObjectsWithTagToDestoy)
        //{
        //    int numberOfGameObjectTagToDestroy = gameObjectsWithTagToDestoy.Count;

        //    for (int i = 0; i < numberOfGameObjectTagToDestroy; i++)
        //    {
        //        string gameObjectTagToDestroy = gameObjectsWithTagToDestoy[i];
        //        DestroySingleGameObjectWithTagIfExsist(gameObjectTagToDestroy);
        //    }
        //}

        //public static void DestroyGameObjectsWithTag(Dictionary<int, string> gameObjectsWithTagToDestoy)
        //{
        //    int numberOfGameObjectTagToDestroy = gameObjectsWithTagToDestoy.Count;

        //    for (int i = 1; i <= numberOfGameObjectTagToDestroy; i++)
        //    {
        //        string gameObjectTagToDestroy = gameObjectsWithTagToDestoy[i];
        //        DestroySingleGameObjectWithTagIfExsist(gameObjectTagToDestroy);
        //    }
        //}

        public static void DestroyGameObjectsWithTag(Dictionary<int, string> gameObjectsWithTagToDestoy, string parentObjectTagName)
        {
            int numberOfGameObjectTagToDestroy = gameObjectsWithTagToDestoy.Count;

            for (int i = 1; i <= numberOfGameObjectTagToDestroy; i++)
            {
                string gameObjectTagToDestroy = gameObjectsWithTagToDestoy[i];
                DestroySingleGameObjectWithTagIfExsist(gameObjectTagToDestroy);
            }
        }

        public static void DestroyGameObjectsList(List<GameObject[,,]> gameObjects)
        {
            foreach (var button in gameObjects)
            {
                DestroyTable3D(button);
            }
        }

        //public static void DestroyGameObjectsWithTag(string[] helpButtonsTag, string tagGameButtonParentObjectHelpButtons)
        //{
        //    bool isGameObjectWithTagExsist = GameCommonMethodsMain.IsGameObjectWithTagExsist(tagGameButtonParentObjectHelpButtons);

        //    if (isGameObjectWithTagExsist == true)
        //    {
        //        DestroyGameObjectsWithTag(helpButtonsTag);
        //    }
        //}


        //public static void DestroyGameObjectsWithTag(string[] gameObjectsWithTagToDestoy)
        //{
        //    string tagName;
        //    int helpButtonsLength = gameObjectsWithTagToDestoy.Length;

        //    GameObject helpButton;

        //    for (int i = 0; i < helpButtonsLength; i++)
        //    {
        //        tagName = gameObjectsWithTagToDestoy[i];
        //        helpButton = GameCommonMethodsMain.GetObjectByTagName(tagName);
        //        Destroy(helpButton);
        //    }
        //}

        public static void DestroyTable3D(GameObject[,,] table)
        {
            int maxIndexDepth = table.GetLength(0);
            int maxIndexColumn = table.GetLength(2);
            int maxIndexRow = table.GetLength(1);

            GameObject baseGameObject = table[0, 0, 0];

            string tagName = GameCommonMethodsMain.GetObjectTag(baseGameObject);

            bool isTagExsist = GameCommonMethodsMain.IsGameObjectWithTagExsist(tagName);

            if (isTagExsist == true)
            {
                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject gameObjectToRemove = table[indexDepth, indexRow, indexColumn];
                            string gameObjectTagToDestroy = GameCommonMethodsMain.GetObjectTag(gameObjectToRemove);
                            Destroy(gameObjectToRemove);

                        }
                    }
                }
            }            
        }
    }
}
