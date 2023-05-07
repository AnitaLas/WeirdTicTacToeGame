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
        private static void DestroyHelpButtons(string[] gameObjectsWithTagToDestoy)
        {
            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsWithTag(gameObjectsWithTagToDestoy);
        }

        //public static void HelpButtonsActions(GameObject prefabHelpButtons, string[] helpButtonsTag, string _tagGameButtonParentObjectHelpButtons)
        //{
        //    bool isGameButtonParentObjectHelpButtons = CommonMethods.IsGameObjectWithTagExsist(_tagGameButtonParentObjectHelpButtons);

        //    if (isGameButtonParentObjectHelpButtons == true)
        //    {
        //        DestroyHelpButtons(helpButtonsTag);
        //    }
        //    else
        //    {
        //        Debug.Log(" 1 ");
        //        PlayGameHelpButtonsCreate.CreateHelpButtons(prefabHelpButtons);

        //    }
        //}


        public static void HelpButtonsActionsCreateOrDestroy(GameObject prefabHelpButtons)
        {
            Dictionary<int, string> tagHelpButtonDictionary = GameDictionariesSceneGame.DictionaryTagGame();
            string tagGameButtonParentObjectHelpButtons = tagHelpButtonDictionary[6];

            bool isGameButtonParentObjectHelpButtons = CommonMethods.IsGameObjectWithTagExsist(tagGameButtonParentObjectHelpButtons);

            if (isGameButtonParentObjectHelpButtons == true)
            {
                //DestroyHelpButtons(helpButtonsTag);
                ButtonsCommonMethodsActionsDestroy.DestroySingleGameObjectWithTag(tagGameButtonParentObjectHelpButtons);

            }
            else
            {
                PlayGameHelpButtonsCreate.CreateHelpButtons(prefabHelpButtons);

            }


        }


        //public static void DestroyHelpButtons(string[] helpButtonsTag, string tagGameButtonParentObjectHelpButtons)
        //{
        //    ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsWithTag(helpButtonsTag, tagGameButtonParentObjectHelpButtons);
        //}

        //public static void DestroyHelpButtons(string[] helpButtonsTag, string tagGameButtonParentObjectHelpButtons)
        public static void DestroyHelpButtons()
        {
            Dictionary<int, string> tagArrowDictionary = GameDictionariesSceneGame.DictionaryTagHelpButtons();
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagGame();

            string tagGameButtonParentObjectHelpButtons = tagGameDictionary[6];

            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsWithTag(tagArrowDictionary, tagGameButtonParentObjectHelpButtons);

            //int tagArrowDictionaryLength = tagArrowDictionary.Count;

            //for (int i = 1; i <= tagArrowDictionaryLength; i++)
            //{
            //    string tagName = tagArrowDictionary[i];
            //    ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsWithTag(helpButtonsTag, tagGameButtonParentObjectHelpButtons);

            //}



        }


    }
}
