using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    internal class ScenesChangeCommonSceneName
    {
        public static void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        // sccenes: name
        public static string GetScencesNameFromDictionaryScencesName(int dictionatyId)
        {
            Dictionary<int, string> scenceDictionary = GameDictionariesScenesCommon.DictionaryScencesName();
            string sceneName = scenceDictionary[dictionatyId];
            return sceneName;
        }

        public static string GetScenceNameSceneGame()
        {
            int dictionatyId = 1;
            string tagName = GetScencesNameFromDictionaryScencesName(dictionatyId);
            return tagName;
        }

        public static string GetScenceNameSceneConfigurationPlayersSymbols()
        {
            int dictionatyId = 2;
            string tagName = GetScencesNameFromDictionaryScencesName(dictionatyId);
            return tagName;
        }

        public static string GetScenceNameSceneConfigurationBoardGame()
        {
            int dictionatyId = 3;
            string tagName = GetScencesNameFromDictionaryScencesName(dictionatyId);
            return tagName;
        }

        public static string GetScenceNameSceneInformations()
        {
            int dictionatyId = 4;
            string tagName = GetScencesNameFromDictionaryScencesName(dictionatyId);
            return tagName;
        }

        public static string GetScenceNameSceneStartGame()
        {
            int dictionatyId = 5;
            string tagName = GetScencesNameFromDictionaryScencesName(dictionatyId);
            return tagName;
        }

        public static string GetScenceNameSceneConfigurationGameTeamsNumber()
        {
            int dictionatyId = 6;
            string tagName = GetScencesNameFromDictionaryScencesName(dictionatyId);
            return tagName;
        }

        public static string GetScenceNameSceneConfigurationGameTeamsPlayersNumber()
        {
            int dictionatyId = 7;
            string tagName = GetScencesNameFromDictionaryScencesName(dictionatyId);
            return tagName;
        }

        public static string GetScenceNameSceneConfigurationGameTeamsPlayersSymbols()
        {
            int dictionatyId = 8;
            string tagName = GetScencesNameFromDictionaryScencesName(dictionatyId);
            return tagName;
        }
    }
}
