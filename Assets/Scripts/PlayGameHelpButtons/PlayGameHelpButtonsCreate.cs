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
            // GameObject prefabCubePlay;
            // create arrow or confirm button
            var newPrefabCubePlay = Instantiate(prefabHelpButtons);
        }

        public static void CreateHelpButtonsAtStart(GameObject prefabHelpButtons, int numberOfRows, int numberOfColumns)
        {
            //Debug.Log(" 1 ");
            //Debug.Log(" numberOfColumns = " + numberOfColumns);
            //Debug.Log(" numberOfRows =  " + numberOfRows);

            // phone mode
            //if ((numberOfColumns < 5 && numberOfRows > 5) || (numberOfColumns > 5 && numberOfRows < 5))
            if (numberOfColumns > 5 || numberOfRows > 5)
            {
                //Debug.Log("  2  ");
                CreateHelpButtons(prefabHelpButtons);
            }

        }
    }
}
