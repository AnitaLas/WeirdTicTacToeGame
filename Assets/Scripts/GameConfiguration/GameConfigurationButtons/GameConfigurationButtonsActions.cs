using Assets.Scripts;using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
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

        public static void HideButtonBackToConfiguration(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToHide(gameObjects);
        }
      
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

        public static void VerifyButtonsWithNumberForLenghtToCheckAndGaps()
        {
            GameConfigurationButtonsWithNumbersForLenghtToCheck.VerifyAndSetUpLenghtToCheck();
            GameConfigurationButtonsWithNumbersForGaps.VerifyAndSetUpGapsNumber();
        }

        //public static void VerifyButtonsWithNumberFordGaps(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsBackColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, bool isTeamGame, int lenghtToCheckMax)
        //{
        //    int minGapsNumber = 3;

        //    GameConfigurationButtonsWithNumbersForLenghtToCheck.VerifyAndSetUpLenghtToCheck();

        //    if (lenghtToCheckMax > minGapsNumber)
        //        GameConfigurationButtonsWithNumbersForGaps.VerifyAndSetUpGapsNumber();
        //    else
        //        GameConfigurationButtonsCreate.GameConfigurationCreateButtonsGap(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, isGame2D, isTeamGame, lenghtToCheckMax);
        //}
    }
}
