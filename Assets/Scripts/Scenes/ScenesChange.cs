using Assets.Scripts;
using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class ScenesChange
    {

        public static void GoToSceneStartGame()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string sceneConfigurationBoardGame = scenceDictionary[5];
            GameCommonMethodsMain.ChangeScene(sceneConfigurationBoardGame);
        }

        public static void GoToSceneInformations()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string sceneInformations = scenceDictionary[4];
            GameCommonMethodsMain.ChangeScene(sceneInformations);
        }

        public static void GoToSceneConfigurationBoardGame()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string sceneConfigurationBoardGame = scenceDictionary[3];
            GameCommonMethodsMain.ChangeScene(sceneConfigurationBoardGame);
        }

        public static void GoToSceneConfigurationGameTeamsNumber()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string sceneConfigurationGameTeamsNumber = scenceDictionary[6];
            GameCommonMethodsMain.ChangeScene(sceneConfigurationGameTeamsNumber);
        }

        public static void GoToSceneConfigurationPlayersSymbols()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string sceneConfigurationPlayersSymbols = scenceDictionary[2];
            GameCommonMethodsMain.ChangeScene(sceneConfigurationPlayersSymbols);
        }

        public static void GoToSceneGame()
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string sceneGame = scenceDictionary[1];
            GameCommonMethodsMain.ChangeScene(sceneGame);
        }
    }
}
