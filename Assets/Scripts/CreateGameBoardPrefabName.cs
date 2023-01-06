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
        /// <para> Row_ and Column_ are used to: get/set: player symbol <para>
        /// <para> Row_ and Column_ are used to: check the validation for game field (prefab "CubePlay") </para>
        /// <para> !!! ATTENTION !!! <para>
        /// </summary>
        /// <param name="currentNumberCubePlayName"></param>
        /// <param name="indexRowYForPrefabCubePlay"></param>
        /// <returns></returns>
        public static string CreateNameForPrefabCubePlay(int currentNumberCubePlayName, Tuple<int, int> indexRowYForPrefabCubePlay)
        {
            int cubePlayIndexRow = indexRowYForPrefabCubePlay.Item1;
            int cubePlayIndexColumn = indexRowYForPrefabCubePlay.Item2;

            string cubePlayName = $"CubePlayUI_No_{currentNumberCubePlayName}_CubePlayGame2d_Row_{cubePlayIndexRow}_Column_{cubePlayIndexColumn}";

            return cubePlayName;
        }

    }
}
