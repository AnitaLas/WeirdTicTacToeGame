using Assets.Scripts.Buttons;
using Assets.Scripts.CreateGameHelpButton;
using Assets.Scripts.GameDictionaries;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PlayGameHelpButtons
{
    internal class PlayGameHelpButtonsActions : MonoBehaviour
    {
        public static void HelpButtonsActionsCreateOrDestroy(GameObject prefabHelpButtons)
        {
            Dictionary<int, string> tagHelpButtonDictionary = GameDictionariesSceneGame.DictionaryTagGame();
            string tagGameButtonParentObjectHelpButtons = tagHelpButtonDictionary[6];

            bool isGameButtonParentObjectHelpButtons = CommonMethods.IsGameObjectWithTagExsist(tagGameButtonParentObjectHelpButtons);

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
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagGame();

            string tagGameButtonParentObjectHelpButtons = tagGameDictionary[6];

            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsWithTag(tagArrowDictionary, tagGameButtonParentObjectHelpButtons);
        }

        //public static void DestroyHelpButtons(string[] helpButtons)
        //{
        //    string tagName;
        //    int helpButtonsLength = helpButtons.Length;
        //    GameObject helpButton;

        //    for (int i = 0; i < helpButtonsLength; i++)
        //    {
        //        tagName = helpButtons[i];
        //        helpButton = CommonMethods.GetObjectByTagName(tagName);

        //        Destroy(helpButton);
        //    }
        //}
    }
}
