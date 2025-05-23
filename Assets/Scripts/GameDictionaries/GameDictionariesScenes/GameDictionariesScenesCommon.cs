﻿using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class GameDictionariesScenesCommon
    {
        public static Dictionary<int, string> DictionaryScencesName()
        {
            Dictionary<int, string> scenceDictionary = new Dictionary<int, string>
            {
                { 1, "SceneGame" },
                { 2, "SceneConfigurationPlayersSymbols" },
                { 3, "SceneConfigurationBoardGame" },
                { 4, "SceneInformations" },
                { 5, "SceneStartGame" },
                { 6, "SceneConfigurationChangePlayersSymbolsByTime" },
                { 7, "SceneConfigurationTeamNumbers" },
                { 8, "SceneConfigurationTeamMembers" },

            };

            return scenceDictionary;
        }

        public static Dictionary<int, string> DictionaryCommonTagsName()
        {
            Dictionary<int, string> tagCommonDictionary = new Dictionary<int, string>
            {
                { 1, "Untagged" }
            };
            return tagCommonDictionary;
        }

        public static Dictionary<int, string> DictionaryCommonButtonsName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "SAVE" },
                { 2, "BACK" }
            };

            return buttonsNameDictionary;
        }

        public static Dictionary<int, Tuple<float, float, float, float>> DictionaryColor()
        {
            // Tuple<float, float, float, float> => r g b a
            Dictionary<int, Tuple<float, float, float, float>> colorDictionary = new Dictionary<int, Tuple<float, float, float, float>>();

            // text colour for all cubePlay - when game is over
            var colorValue1 = Tuple.Create(6f, 0f, 2f, 0.4f);

            // test colour for winner cubePlay - when game is over
            var colorValue2 = Tuple.Create(3f, 0f, 1f, 1f);

            // text colour for all cubePlay - when game start
            var colorValue3 = Tuple.Create(1f, 0f, 2f, 0.2f);

            var colorValue4 = Tuple.Create(0f, 0f, 0f, 0.0f);

            // text colour for other cubePlay wiht symbol after win
            var colorValue5 = Tuple.Create(6f, 0f, 2f, 0.7f);

            colorDictionary.Add(1, colorValue1);
            colorDictionary.Add(2, colorValue2);
            colorDictionary.Add(3, colorValue3);
            colorDictionary.Add(4, colorValue4);
            colorDictionary.Add(5, colorValue5);

            return colorDictionary;
        }
    }
}
