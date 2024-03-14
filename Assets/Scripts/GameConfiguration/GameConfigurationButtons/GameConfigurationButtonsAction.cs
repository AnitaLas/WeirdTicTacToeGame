using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsAction
    {

        public static void UnhideConfiguration(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjects);
        }

        public static void HideConfiguration(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToHide(gameObjects);
        }

        // ---

        public static void HideTableWithNumber(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToHide(gameObjects);
        }

        public static void UnhideTableWithNumber(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjects);
        }

        // ---

        public static void HideButtonBackToConfiguration(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToHide(gameObjects);
        }

        public static void UnhideButtonBackToConfiguration(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjects);
        }

        // ---

        public static void HideVisibleTablesWithNumber(List<GameObject[,,]> gameObjects)
        {
           // ButtonsCommonMethodsActions.HideVisibleTablesWithNumber(gameObjects);
  
        }


    }
}
