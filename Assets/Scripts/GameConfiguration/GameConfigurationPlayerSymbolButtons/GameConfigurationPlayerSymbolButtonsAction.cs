using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationPlayerSymbolButtonsAction
    {

        public static void UnhideConfiguration(List<GameObject[,,]> gameObjects)
        {
            //ButtonsCommonMethodsAction.GameObjectToUnhide(gameObjects);
        }

        public static void HideConfiguration(List<GameObject[,,]> gameObjects)
        {
            //ButtonsCommonMethodsAction.GameObjectToHide(gameObjects);
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

    }
}
