using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationBase
{
    internal class GameConfigurationButtons
    {

        public static void GameConfigurationCreateBattons(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameConfigurationCreateBattonSave(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameConfigurationCreateBattonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

        }


        public static void GameConfigurationCreateBattonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesCommon.DictionaryTagConfigurationBoardGame();

            string tagName = tagNameDictionary[1];

            GameConfigurationCommonButtons.CreateCommonBattonSave(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName);
        }

        public static void GameConfigurationCreateBattonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesCommon.DictionaryTagConfigurationBoardGame();

            string tagName = tagNameDictionary[1];

            GameConfigurationCommonButtons.CreateCommonBattonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);

        }
    }
}
