using Assets.Scripts.GameDictionaries;
using System.Collections.Generic;

namespace Assets.Scripts.Scenes
{
    internal class ScenesChange
    {
        public static void GoToSceneStartGame()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string _sceneSceneConfigurationBoardGame = scenceDictionary[5];
            CommonMethods.ChangeScene(_sceneSceneConfigurationBoardGame);
        }

        public static void GoToSceneInformations()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string _sceneInformations = scenceDictionary[4];
            CommonMethods.ChangeScene(_sceneInformations);
        }

        public static void GoToSceneConfigurationBoardGame()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string _sceneSceneConfigurationBoardGame = scenceDictionary[3];
            CommonMethods.ChangeScene(_sceneSceneConfigurationBoardGame);
        }

        public static void GoToSceneConfigurationPlayersSymbols()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string _sceneConfigurationPlayersSymbols = scenceDictionary[2];
            CommonMethods.ChangeScene(_sceneConfigurationPlayersSymbols);
        }

        public static void GoToSceneGame()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string _sceneGame = scenceDictionary[1];
            CommonMethods.ChangeScene(_sceneGame);
        }
    }
}
