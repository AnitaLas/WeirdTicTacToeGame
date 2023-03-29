using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CreateGameHelpButton
{
    internal class CreateGameHelpButton : MonoBehaviour
    {
        public static void CreateHelpButtons(GameObject prefabHelpButtons)
        {
           // GameObject prefabCubePlay;
            // create arrow or confirm button
            var newPrefabCubePlay = Instantiate(prefabHelpButtons);
        }

        public static void DestroyHelpButtons (GameObject prefabHelpButtons)
        {
            Destroy(prefabHelpButtons);

        }


    }
}
