using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    internal class CreateGameBoardPrefabDefaultColour : MonoBehaviour
    {
        // [prefabCubePlayColorDefaul]

        /// <summary>
        /// <para> it returns colour for the new prefab "CubePlay" </para>
        /// <para> indexForNewColour come from method NewIndexColourForPrefabCubePlay() </para>
        /// </summary>
        /// <param name="cubePlayColour"></param>
        /// <param name="indexForNewColour"></param>
        /// <returns></returns>
        public static Material NewColourForPrefabCubePlay(Material[] cubePlayColour, int indexForNewColour)
        {
            Material cubeColour = cubePlayColour[indexForNewColour];
            return cubeColour;         
        }

        /// <summary>
        /// <para> it changes the colour for prefab "CubePlay" </para> 
        /// <para> indexForNewColour come from method NewIndexColourForPrefabCubePlay() </para>
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="cubePlayColour"></param>
        /// <param name="indexForNewColour"></param>
        public static void ChangeColourForPrefabCubePlay(GameObject prefab, Material[] cubePlayColour, int indexForNewColour)
        {
            Material cubeColour = NewColourForPrefabCubePlay(cubePlayColour, indexForNewColour);
            //prefab.GetComponent<Renderer>().material = cubeColour;
            CommonMethods.ChangeColourForGameObject(prefab, cubeColour);
        }


    }
}
