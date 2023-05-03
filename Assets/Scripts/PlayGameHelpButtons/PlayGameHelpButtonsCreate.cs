using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CreateGameHelpButton
{
    internal class PlayGameHelpButtonsCreate : MonoBehaviour
    {
        public static void CreateHelpButtons(GameObject prefabHelpButtons)
        {
            //var newPrefabCubePlay = Instantiate(prefabHelpButtons);
            Instantiate(prefabHelpButtons);
        }

        public static void CreateHelpButtonsAtStart(GameObject prefabHelpButtons, int numberOfRows, int numberOfColumns)
        {
            if (numberOfColumns > 5 || numberOfRows > 5)
            {
                CreateHelpButtons(prefabHelpButtons);
            }

        }
    }
}
