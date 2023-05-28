using Assets.Scripts.Buttons;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationButtons
{
    internal class GameConfigurationButtonsActions
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

        //public static void HideTableWithNumber(GameObject[,,] gameObjects)
        //{
        //    ButtonsCommonMethodsActions.GameObjectToHide(gameObjects);
        //}

        //public static void UnhideTableWithNumber(GameObject[,,] gameObjects)
        //{
        //    ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjects);
        //}

        // ---

        public static void HideButtonBackToConfiguration(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToHide(gameObjects);
        }

        //public static void UnhideButtonBackToConfiguration(GameObject[,,] gameObjects)
        //{
        //    ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjects);
        //}

        //// ---

        //public static void HideVisibleTablesWithNumber(List<GameObject[,,]> gameObjects)
        //{
        //    ButtonsCommonMethodsActions.HideVisibleTablesWithNumber(gameObjects);
  
        //}

        // --- 

        //public static void DestroyTableWithLenghtToCheckBase(GameObject[,,] table)
        //{
        //    ButtonsCommonMethodsActionsDestroy.DestroyTable3D(table);
        //}

        public static void DestroyHelpButtons(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsList(gameObjects);
        }

        public static void DestroyButtonsWithNumber(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsActionsDestroy.DestroyTable3D(gameObjects);
        }

        public static void DestroyButtons(List<GameObject[,,]> gameObjectsList, GameObject[,,] gameObjects)
        {
            DestroyButtonsWithNumber(gameObjects);
            DestroyHelpButtons(gameObjectsList);
        }
    }
}
