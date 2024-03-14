using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameFrameCreate : MonoBehaviour
    {
        public static GameObject CreateCubePlayFrameForWinner(GameObject prefabCubePlayFrame, GameObject cubePlayForFrame, bool isGame2D)
        {
            if (isGame2D == true)
            {
                float cubePlayScaleX = cubePlayForFrame.transform.localScale.x;
                float cubePlayScaleY = cubePlayForFrame.transform.localScale.y;
                float cubePlayScaleZ = cubePlayForFrame.transform.localScale.z;

                CreateTablePrefabCalculateScale.TransformGameObjectPrefabToNewScale(prefabCubePlayFrame, cubePlayScaleX, cubePlayScaleY, cubePlayScaleZ);

                float x = cubePlayForFrame.transform.position.x;
                float y = cubePlayForFrame.transform.position.y;
                float z = cubePlayForFrame.transform.position.z;

                // create new prefab "CubePlayFrame"
                var newPrefabCubePlay = Instantiate(prefabCubePlayFrame, new Vector3(x, y, z), Quaternion.identity);

                return cubePlayForFrame;
            }

            return cubePlayForFrame;
        }


        public static GameObject CreateCubePlayFrameForPlayerMove(GameObject prefabCubePlayFrame, GameObject cubePlayForFrame, bool isGame2D)
        {
            if (isGame2D == true)
            {
                float cubePlayScaleX = cubePlayForFrame.transform.localScale.x;
                float cubePlayScaleY = cubePlayForFrame.transform.localScale.y;
                float cubePlayScaleZ = cubePlayForFrame.transform.localScale.z;

                CreateTablePrefabCalculateScale.TransformGameObjectPrefabToNewScale(prefabCubePlayFrame, cubePlayScaleX, cubePlayScaleY, cubePlayScaleZ);

                float topForAllCubePlay = 0.15f;

                float x = cubePlayForFrame.transform.position.x;
                float y = cubePlayForFrame.transform.position.y;
                float z = cubePlayForFrame.transform.position.z - cubePlayScaleX / 2 - topForAllCubePlay;

                var newPrefabCubePlay = Instantiate(prefabCubePlayFrame, new Vector3(x, y, z), Quaternion.identity);

                return cubePlayForFrame;
            }

            return cubePlayForFrame;
        }       
    }
}
