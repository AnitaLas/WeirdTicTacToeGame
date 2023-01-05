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

        public static void SetUpFirstTextForPrefaCubePlay(GameObject prefab, string prefabDefaultText)
        {
            var newPrefabCubePlayCanvas = prefab.transform.GetChild(0);
            var newPrefabCubePlayCanvasText = newPrefabCubePlayCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            newPrefabCubePlayCanvasText.text = prefabDefaultText;

        }

        public static string t()
        {
            return "t";  
        }

    }
}
