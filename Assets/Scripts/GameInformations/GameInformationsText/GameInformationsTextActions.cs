using Assets.Scripts.CommonMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameInformations.GameInformationsText
{
    internal class GameInformationsTextActions : MonoBehaviour
    {
        public static void DestroyText(string gameObjectTag)
        {
            GameObject gameObject = CommonMethodsMain.GetObjectByTagName(gameObjectTag);
            Destroy(gameObject);
        }

        public static void DestroyOneGameObjectByTag(string gameObjectTagToDestoy)
        {
            bool isGameObjectWithTagExsist = CommonMethodsMain.IsGameObjectWithTagExsist(gameObjectTagToDestoy);

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
