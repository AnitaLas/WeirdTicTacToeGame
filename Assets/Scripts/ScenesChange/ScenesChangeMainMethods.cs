using Assets.Scripts;
using Assets.Scripts.Scenes;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


namespace Assets.Scripts
{
    internal class ScenesChangeMainMethods
    {

        public static void GoToSceneStartGame()
        {
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneStartGame();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneInformations()
        {
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneInformations();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneConfigurationBoardGame()
        {
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneConfigurationBoardGame();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneConfigurationPlayersSymbols()
        {
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneConfigurationPlayersSymbols();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneGame()
        {
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneGame();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneConfigurationChangePlayersSymbols()
        {
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneConfigurationChangePlayersSymbols();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneConfigurationGameTeamNumbers()
        {
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneConfigurationGameTeamNumbers();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneConfigurationGameTeamMembers()
        {
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneConfigurationGameTeamMembers();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

    }
}
