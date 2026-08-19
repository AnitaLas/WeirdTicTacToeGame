using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameInformationButtonsAction
    {
        public static void UnhideButtons(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjects);
            ChangeTagForButtonBackToSceneStartGame();
        }

        public static void HideButtons(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToHide(gameObjects);
            ChangeTagForButtonBackToSceneInformations();
        }

        public static void ChangeTagForButtonBackToSceneInformations()
        {
            string oldTag = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBack();
            string newTag = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBackToMenu();
            GameInformationButtonsMethods.ChangeTagForButtonBack(oldTag, newTag);
        }

        public static void ChangeTagForButtonBackToSceneStartGame()
        {
            string oldTag = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBackToMenu();
            string newTag = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBack();
            GameInformationButtonsMethods.ChangeTagForButtonBack(oldTag, newTag);
        }
    }
}