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

        // ---

        public static void ChangeTagForButtonBackToSceneInformations()
        {
           // Dictionary<int, string> tagGameInformationsDictionary = GameDictionariesSceneInformation.DictionaryTagsGameInformation();
            //string oldTag = tagGameInformationsDictionary[1];
            string oldTag = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBack();
            //string newTag = tagGameInformationsDictionary[4];
            string newTag = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBackToMenu();

            GameInformationButtonsMethods.ChangeTagForButtonBack(oldTag, newTag);
        }

        public static void ChangeTagForButtonBackToSceneStartGame()
        {
            //Dictionary<int, string> tagGameInformationsDictionary = GameDictionariesSceneInformation.DictionaryTagsGameInformation();
            //string oldTag = tagGameInformationsDictionary[4];
            string oldTag = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBackToMenu();
            //string newTag = tagGameInformationsDictionary[1];
            string newTag = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBack();

            GameInformationButtonsMethods.ChangeTagForButtonBack(oldTag, newTag);
        }
    }
}
