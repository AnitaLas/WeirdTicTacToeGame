using Assets.Scripts;
using Assets.Scripts.Scenes;
using System.Collections.Generic;
using System.Diagnostics;


namespace Assets.Scripts
{
    internal class ScenesChangeMainMethods
    {

        public static void GoToSceneStartGame()
        {
            //Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            //string sceneConfigurationBoardGame = scenceDictionary[5];
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneStartGame();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneInformations()
        {
            //Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            //string sceneInformations = scenceDictionary[4];
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneInformations();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneConfigurationBoardGame()
        {
            //Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            //string sceneConfigurationBoardGame = scenceDictionary[3];
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneConfigurationBoardGame();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        //public static void GoToSceneConfigurationGameTeamsNumber()
        //{
        //    //Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
        //    //string sceneConfigurationGameTeamsNumber = scenceDictionary[6];
        //    string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneConfigurationGameTeamsNumber();
        //    ScenesChangeCommon.ChangeScene(sceneName);
        //}

        public static void GoToSceneConfigurationPlayersSymbols()
        {
            //Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            //string sceneConfigurationPlayersSymbols = scenceDictionary[2];
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneConfigurationPlayersSymbols();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneGame()
        {
            //Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            //string sceneGame = scenceDictionary[1];
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneGame();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        public static void GoToSceneConfigurationChangePlayersSymbols()
        {
            //Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            //string sceneGame = scenceDictionary[1];
            string sceneName = ScenesChangeCommonSceneName.GetScenceNameSceneConfigurationChangePlayersSymbols();
            ScenesChangeCommon.ChangeScene(sceneName);
        }

        
    }
}
