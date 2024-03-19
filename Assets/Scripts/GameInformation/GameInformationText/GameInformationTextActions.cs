using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameInformationTextActions : MonoBehaviour
    {
        public static void DestroyText(string gameObjectTag)
        {
            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(gameObjectTag);
            Destroy(gameObject);
        }

        public static void DestroyOneGameObjectByTag(string gameObjectTagToDestoy)
        {
            bool isGameObjectWithTagExsist = GameCommonMethodsMain.IsGameObjectWithTagExsist(gameObjectTagToDestoy);

            if (isGameObjectWithTagExsist == true)
            {
                DestroyText(gameObjectTagToDestoy);
            }
        }

        public static void DestroyGameObjectsWithText(List<string> gameObjectTagToDestoy)
        {
            int numberOfGameObjectTagToDestroy = gameObjectTagToDestoy.Count;

            for (int i = 0; i < numberOfGameObjectTagToDestroy; i++)
            {
                string gameObjectTagToDestroy = gameObjectTagToDestoy[i];
                DestroyOneGameObjectByTag(gameObjectTagToDestroy);
            }
        }
    }
}
