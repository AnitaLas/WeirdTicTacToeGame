using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CreateGameHelpButton
{
    internal class PlayGameHelpButtons : MonoBehaviour
    {
        public static void CreateHelpButtons(GameObject prefabHelpButtons)
        {
           // GameObject prefabCubePlay;
            // create arrow or confirm button
            var newPrefabCubePlay = Instantiate(prefabHelpButtons);
        }

        public static void DestroyHelpButtons(string[] helpButtons)
        {
            //Destroy(prefabHelpButtons);
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

       

    }
}
