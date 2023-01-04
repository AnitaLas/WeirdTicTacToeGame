using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{

    internal class GameBoardCreateChangeText : MonoBehaviour
    {

        internal static void SetUpFirstTextForPrefaCubePlay(GameObject prefab, string prefabDefaultText)
        {

            //string test = "A1";
            var newPrefabCubePlayText = prefab.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            newPrefabCubePlayText.text = prefabDefaultText;

        }



    }
}
