using Assets.Scripts;
using Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers;
using System.Collections.Generic;
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
            //int lowerNumberBetweenRowsNumberAndColumnsNumber = GameCommonMethodsSetUpButtonWithNumber.GetLowerNumberBetweenRowsNumberAndColumnsNumber();
            //int currentLenghtToCheck = GetLengthToCheckNumber();
            //int currentGapsNumber = GetGapsNumber();
            //bool isCurrentLenghtToCheckBiggerThanRowsNumberAndColumnsNumber = VerifyIfCurrentNumberIsLowerThanRowsNumberOrColumnsNumber(lowerNumberBetweenRowsNumberAndColumnsNumber, currentLenghtToCheck);
            //bool isCurrentGapsNumberBiggerThanRowsNumberAndColumnsNumber = VerifyIfCurrentNumberIsLowerThanRowsNumberOrColumnsNumber(lowerNumberBetweenRowsNumberAndColumnsNumber, currentGapsNumber);

            GameConfigurationButtonsWithNumbersForLenghtToCheck.VerifyAndSetUpLenghtToCheck();
            GameConfigurationButtonsWithNumbersForGaps.VerifyAndSetUpGapsNumber();


        }
    }
}
