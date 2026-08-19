using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameHelpButtonsActions : MonoBehaviour
    {
        public static void HelpButtonsActionsCreateOrDestroy(GameObject prefabHelpButtons)
        {
            string tagGameButtonParentObjectHelpButtons = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagParentObjectHelpButtons();
            bool isGameButtonParentObjectHelpButtons = GameCommonMethodsMain.IsGameObjectWithTagExsist(tagGameButtonParentObjectHelpButtons);

            if (isGameButtonParentObjectHelpButtons == true)
                ButtonsCommonMethodsActionsDestroy.DestroySingleGameObjectWithTag(tagGameButtonParentObjectHelpButtons);

            else
                PlayGameHelpButtonsCreate.CreateHelpButtons(prefabHelpButtons);
        }

        public static void DestroyHelpButtons()
        {
            Dictionary<int, string> tagArrowDictionary = GameDictionariesSceneGame.DictionaryTagsHelpButtons();
            string tagGameButtonParentObjectHelpButtons = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagParentObjectHelpButtons();
            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsWithTag(tagArrowDictionary, tagGameButtonParentObjectHelpButtons);
        }
    }
}