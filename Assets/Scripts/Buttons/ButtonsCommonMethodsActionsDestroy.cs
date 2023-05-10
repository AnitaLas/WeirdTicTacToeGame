using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Buttons
{
    internal class ButtonsCommonMethodsActionsDestroy :MonoBehaviour
    {
        public static void DestroySingleGameObjectWithTag(string gameObjectTag)
        {
            GameObject gameObject = CommonMethods.GetObjectByTagName(gameObjectTag);
            Destroy(gameObject);
        }

        public static void DestroySingleGameObjectWithTagIfExsist(string gameObjectTagToDestoy)
        {
            bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(gameObjectTagToDestoy);

            //Debug.Log(" isGameObjectWithTagExsist " + isGameObjectWithTagExsist);
            if (isGameObjectWithTagExsist == true)
            {
                DestroySingleGameObjectWithTag(gameObjectTagToDestoy);
            }
        }

        public static void DestroyGameObjectsWithTag(List<string> gameObjectsWithTagToDestoy)
        {
            int numberOfGameObjectTagToDestroy = gameObjectsWithTagToDestoy.Count;

            for (int i = 0; i < numberOfGameObjectTagToDestroy; i++)
            {
                string gameObjectTagToDestroy = gameObjectsWithTagToDestoy[i];
                Debug.Log("gameObjectTagToDestroy = " + gameObjectTagToDestroy);
                DestroySingleGameObjectWithTagIfExsist(gameObjectTagToDestroy);
            }
        }

        public static void DestroyGameObjectsWithTag(Dictionary<int, string> gameObjectsWithTagToDestoy)
        {
            int numberOfGameObjectTagToDestroy = gameObjectsWithTagToDestoy.Count;

            for (int i = 1; i <= numberOfGameObjectTagToDestroy; i++)
            {
                string gameObjectTagToDestroy = gameObjectsWithTagToDestoy[i];
                DestroySingleGameObjectWithTagIfExsist(gameObjectTagToDestroy);
            }
        }

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
            //Debug.Log(" 1 ");
            //int numberOfGameObjectTagToDestroy = gameObjects.Count;
            //Debug.Log(" numberOfGameObjectTagToDestroy " + numberOfGameObjectTagToDestroy);

            //for (int i = 0; i < numberOfGameObjectTagToDestroy; i++)
            //{
            //    GameObject[,,] table = gameObjects[i];
            //    Debug.Log($" gameObjects[{i}] " + gameObjects[i]);
            //    GameObject gameObject = table[0,0,0];
            //    string gameObjectTagToDestroy = CommonMethods.GetObjectTag(gameObject);
            //    Debug.Log(" gameObjectTagToDestroy = " + gameObjectTagToDestroy);
            //    //DestroySingleGameObjectWithTagIfExsist(gameObjectTagToDestroy);
            //    DestroyTable3D(table);
            //}

            foreach (var button in gameObjects)
            {
                DestroyTable3D(button);
            }
        }

        public static void DestroyGameObjectsWithTag(string[] helpButtonsTag, string tagGameButtonParentObjectHelpButtons)
        {
            bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(tagGameButtonParentObjectHelpButtons);

            if (isGameObjectWithTagExsist == true)
            {
                DestroyGameObjectsWithTag(helpButtonsTag);
            }
        }


        public static void DestroyGameObjectsWithTag(string[] gameObjectsWithTagToDestoy)
        {
            string tagName;
            int helpButtonsLength = gameObjectsWithTagToDestoy.Length;
            GameObject helpButton;

            for (int i = 0; i < helpButtonsLength; i++)
            {
                tagName = gameObjectsWithTagToDestoy[i];
                helpButton = CommonMethods.GetObjectByTagName(tagName);

                Destroy(helpButton);
            }
        }

        public static void DestroyTable3D(GameObject[,,] table)
        {
            //Debug.Log(" 1 ");
            int maxIndexDepth = table.GetLength(0);
            int maxIndexColumn = table.GetLength(2);
            int maxIndexRow = table.GetLength(1);

            GameObject baseGameObject = table[0, 0, 0];
            string tagName = CommonMethods.GetObjectTag(baseGameObject);

            bool isTagExsist = CommonMethods.IsGameObjectWithTagExsist(tagName);

            if (isTagExsist == true)
            {
                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject gameObjectToRemove = table[indexDepth, indexRow, indexColumn];
                            string gameObjectTagToDestroy = CommonMethods.GetObjectTag(gameObjectToRemove);
                            //Debug.Log(" gameObjectTagToDestroy = " + gameObjectTagToDestroy);
                            Destroy(gameObjectToRemove);

                        }
                    }
                }

            } 
            else
            {

            }
            
        }

    }
}
