using Assets.Scripts.Buttons;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.GameInformations.GameInformationsBase;
using Assets.Scripts.GameInformations.GameInformationsButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameInformationsButtons
{
    internal class GameInformationsButtonsAction
    {
        public static void UnhideButtons(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToUnhide(gameObjects);
        }

        public static void HideButtons(List<GameObject[,,]> gameObjects)
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

        public static void ChangeTagForButtonBackToSceneInformations()
        {
            Dictionary<int, string> tagGameInformationsDictionary = GameDictionariesSceneInformations.DictionaryTagGameInformations();
            string oldTag = tagGameInformationsDictionary[1];
            string newTag = tagGameInformationsDictionary[4];

            GameInformationsButtonsMethods.ChangeTagForButtonBack(oldTag, newTag);
        }

        public static void ChangeTagForButtonBackToSceneStartGame()
        {
            Dictionary<int, string> tagGameInformationsDictionary = GameDictionariesSceneInformations.DictionaryTagGameInformations();
            string oldTag = tagGameInformationsDictionary[4];
            string newTag = tagGameInformationsDictionary[1];

            GameInformationsButtonsMethods.ChangeTagForButtonBack(oldTag, newTag);
        }


    }
}
