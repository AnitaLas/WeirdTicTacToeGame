using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class CreateGameBoardPrefabName
    {
        // [prefabCubePlayName]

        /// <summary>
        /// <para> creates name for prefab "CubePlay" </para> 
        /// <para> !!! ATTENTION !!! <para>
        /// <para> the prefab "CubePlay" name is used for the "Tic Tac Tom Game" logic </para>
        /// <para> !!! ATTENTION !!! <para>
        /// </summary>
        /// <param name="currentNumberCubePlayName"></param>
        /// <param name="indexRowYForPrefabCubePlay"></param>
        /// <returns></returns>
        public static string CreateNameForPrefabCubePlay(int currentNumberCubePlayName, Tuple<int, int, int> indexRowYForPrefabCubePlay)
        {
            int cubePlayIndexDepths = indexRowYForPrefabCubePlay.Item1;
            int cubePlayIndexRow = indexRowYForPrefabCubePlay.Item2;
            int cubePlayIndexColumn = indexRowYForPrefabCubePlay.Item3;

            string cubePlayName = $"CubePlayUI_No_{currentNumberCubePlayName}_Table3DCoOrdinates_Depths_{cubePlayIndexDepths}_Row_{cubePlayIndexRow}_Column_{cubePlayIndexColumn}";
            //string cubePlayName = $"CubePlayUI_No_{currentNumberCubePlayName}";

            return cubePlayName;
        }

    }
}
