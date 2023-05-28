using UnityEngine;

namespace Assets.Scripts
{
    internal class CreateTablePrefabDefaultText : MonoBehaviour
    {  
        public static void SetUpDefaultTextForPrefaCubePlay(GameObject prefab, string prefabDefaultText)
        {
            CommonMethods.ChangeTextForCubePlay(prefab, prefabDefaultText);
        }
        
        public static string SetUpNewDefaultTextForPrefaCubePlay(int[,,] prefabCubePlayNumbers, string[,,] defaultTextForPrefabCubePlay, int currentNumberForPrefabCubePlay)
        {
            var cublePlayIndex = CommonMethods.GetIndexZYXForGameObject(prefabCubePlayNumbers, currentNumberForPrefabCubePlay);

            int cubePlayIndexDepth = cublePlayIndex.Item1;
            int cubePlayIndexRow = cublePlayIndex.Item2;
            int cubePlayIndexColumn = cublePlayIndex.Item3;

            string defaultText = defaultTextForPrefabCubePlay[cubePlayIndexDepth, cubePlayIndexRow, cubePlayIndexColumn];
            return defaultText;
        }
    }
}
