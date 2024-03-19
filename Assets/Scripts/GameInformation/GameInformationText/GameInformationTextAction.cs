using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameInformationTextAction : MonoBehaviour
    {
        public static void DestroyText(string gameObjectTag)
        {
            GameObject gameObject = CommonMethods.GetObjectByTagName(gameObjectTag);
            Destroy(gameObject);
        }

        public static void DestroyOneGameObjectByTag(string gameObjectTagToDestoy)
        {
            bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(gameObjectTagToDestoy);

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
