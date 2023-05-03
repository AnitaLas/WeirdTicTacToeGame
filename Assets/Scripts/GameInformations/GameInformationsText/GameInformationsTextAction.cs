using Assets.Scripts.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameInformations.GameInformationsBase
{
    internal class GameInformationsTextAction : MonoBehaviour
    {
        //public static void DestroyText(string gameObjectTag)
        //{
        //    //GameObject gameObject = CommonMethods.GetObjectByTagName(gameObjectTag);
        //    //Destroy(gameObject);
        //    //ButtonsCommonMethodsActionsDestroy.DestroySingleGameObjectWithTag(gameObjectTag);
        //}

        //public static void DestroyOneGameObjectByTag(string gameObjectTagToDestoy)
        //{
        //    //bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(gameObjectTagToDestoy);

        //    //if (isGameObjectWithTagExsist == true)
        //    //{
        //    //    DestroyText(gameObjectTagToDestoy);
        //    //}
        //    //ButtonsCommonMethodsActionsDestroy.DestroySingleGameObjectWithTabIfExsist(gameObjectTagToDestoy);

        //}

        public static void DestroyGameObjectsWithText(List<string> gameObjectTagToDestoy)
        {
            //int numberOfGameObjectTagToDestroy = gameObjectTagToDestoy.Count;

            //for (int i = 0; i < numberOfGameObjectTagToDestroy; i++)
            //{
            //    string gameObjectTagToDestroy = gameObjectTagToDestoy[i];
            //    DestroyOneGameObjectByTag(gameObjectTagToDestroy);
            //}

            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsWithTag(gameObjectTagToDestoy);
        }
    }
}
