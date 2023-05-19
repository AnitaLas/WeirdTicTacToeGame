using Assets.Scripts.Buttons;
using Assets.Scripts.CreateGameHelpButton;
using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


    }
}
