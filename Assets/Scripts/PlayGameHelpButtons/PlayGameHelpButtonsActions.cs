using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameHelpButtonsActions : MonoBehaviour
    {
        public static void HelpButtonsActionsCreateOrDestroy(GameObject prefabHelpButtons)
        {
            Dictionary<int, string> tagHelpButtonDictionary = GameDictionariesSceneGame.DictionaryTagsGame();
            string tagGameButtonParentObjectHelpButtons = tagHelpButtonDictionary[6];

            bool isGameButtonParentObjectHelpButtons = GameCommonMethodsMain.IsGameObjectWithTagExsist(tagGameButtonParentObjectHelpButtons);

            if (isGameButtonParentObjectHelpButtons == true)
            {
                ButtonsCommonMethodsActionsDestroy.DestroySingleGameObjectWithTag(tagGameButtonParentObjectHelpButtons);
            }
            else
            {
                PlayGameHelpButtonsCreate.CreateHelpButtons(prefabHelpButtons);
            }
        }

        public static void DestroyHelpButtons()
        {
            Dictionary<int, string> tagArrowDictionary = GameDictionariesSceneGame.DictionaryTagHelpButtons();
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagsGame();

            string tagGameButtonParentObjectHelpButtons = tagGameDictionary[6];

            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsWithTag(tagArrowDictionary, tagGameButtonParentObjectHelpButtons);
        }
    }
}
