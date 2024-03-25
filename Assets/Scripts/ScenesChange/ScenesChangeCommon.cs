using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Scenes
{
    internal class ScenesChangeCommon
    {
        public static void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
