using Assets.Scripts.PlayGameFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CreateGameHelpButton
{
    internal class PlayGameHelpButtonsCreate : MonoBehaviour
    {
        public static void CreateHelpButtons(GameObject prefabHelpButtons)
        {
            Instantiate(prefabHelpButtons);
        }

        public static void CreateAtStartHelpButtons(GameObject prefabHelpButtons, int numberOfRows, int numberOfColumns, bool isCellphoneMode)
        {
            if (isCellphoneMode == true)
            {
                if (numberOfColumns > 5 || numberOfRows > 5)
                {
                    CreateHelpButtons(prefabHelpButtons);
                }
            }

        }

    }
}
