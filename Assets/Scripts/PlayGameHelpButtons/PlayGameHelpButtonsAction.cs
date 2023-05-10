using Assets.Scripts.CreateGameHelpButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayGameHelpButtons
{
    internal class PlayGameHelpButtonsAction : MonoBehaviour
    {
        public static void DestroyHelpButtons(string[] helpButtons)
        {
            string tagName;
            int helpButtonsLength = helpButtons.Length;
            GameObject helpButton;

            for (int i = 0; i < helpButtonsLength; i++)
            {
                tagName = helpButtons[i];
                helpButton = CommonMethods.GetObjectByTagName(tagName);

                Destroy(helpButton);
            }
        }

        public static void HelpButtonsActions(GameObject prefabHelpButtons, string[] helpButtonsTag, string _tagGameButtonParentObjectHelpButtons)
        {
            bool isGameButtonParentObjectHelpButtons = CommonMethods.IsGameObjectWithTagExsist(_tagGameButtonParentObjectHelpButtons);

            if (isGameButtonParentObjectHelpButtons == true)
            {
                DestroyHelpButtons(helpButtonsTag);
            }
            else
            {
                PlayGameHelpButtonsCreate.CreateHelpButtons(prefabHelpButtons);

            }
        }

        public static void HelpButtonsDestroy(GameObject prefabHelpButtons, string[] helpButtonsTag, string _tagGameButtonParentObjectHelpButtons)
        {
            bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(_tagGameButtonParentObjectHelpButtons);

            if (isGameObjectWithTagExsist == true)
            {
                DestroyHelpButtons(helpButtonsTag);
            }
        }


    }
}
