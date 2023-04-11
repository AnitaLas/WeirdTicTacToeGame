using Assets.Scripts.Buttons;
using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationBase
{
    internal class GameConfigurationButtonsAction
    {

        public static void UnhideConfiguration(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToUnhide(gameObjects);
        }

        public static void HideConfiguration(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToHide(gameObjects);
        }

        // ---

        public static void HideTableWithNumber(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToHide(gameObjects);
        }

        public static void UnhideTableWithNumber(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToUnhide(gameObjects);
        }

        // ---

        public static void HideButtonBackToConfiguration(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToHide(gameObjects);
        }

        public static void UnhideButtonBackToConfiguration(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToUnhide(gameObjects);
        }

        // ---

        public static void HideVisibleTablesWithNumber(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsAction.HideVisibleTablesWithNumber(gameObjects);
  
        }


    }
}
