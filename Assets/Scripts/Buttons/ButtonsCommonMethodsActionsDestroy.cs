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
                DestroySingleGameObjectWithTagIfExsist(gameObjectTagToDestroy);
            }
        }

        public static void DestroyGameObjectsWithTag(List<GameObject[,,]> gameObjects)
        {
            Debug.Log(" 1 ");
            int numberOfGameObjectTagToDestroy = gameObjects.Count;

            for (int i = 0; i < numberOfGameObjectTagToDestroy; i++)
            {
                GameObject[,,] table = gameObjects[i];
                GameObject gameObject = table[0,0,0];
                string gameObjectTagToDestroy = CommonMethods.GetObjectTag(gameObject);
                Debug.Log(" gameObjectTagToDestroy ");
                DestroySingleGameObjectWithTagIfExsist(gameObjectTagToDestroy);
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
            int maxIndexDepth = table.GetLength(0);
            int maxIndexColumn = table.GetLength(2);
            int maxIndexRow = table.GetLength(1);


            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject gameObjectToRemove = table[indexDepth, indexRow, indexColumn];
                        Destroy(gameObjectToRemove);

                    }
                }
            }
        }

    }
}
