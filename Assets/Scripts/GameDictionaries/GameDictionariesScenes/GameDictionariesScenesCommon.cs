using System;
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

            // text colour for all cubePlay - game over - color for the symbol of the winning player
            // var colorValue1 = Tuple.Create(219f, 107f, 46f, 255f); // orange - debugging data, do not delete
            var colorValue1 = Tuple.Create(255f, 255f, 255f, 255f); // white

            // test colour for winner cubePlay - game running - color of player symbols on the board after clicking a field
            //var colorValue2 = Tuple.Create(57f, 220f, 46f, 255f); // green - debugging data, do not delete
            var colorValue2 = Tuple.Create(0f, 0f, 0f, 255f);

            // text colour for all cubePlay - game running - help buttons - color of the help text when it is not needed, i.e. transparent
            // var colorValue3 = Tuple.Create(20f, 6f, 172f, 172f); // blue - debugging data, do not delete
            var colorValue3 = Tuple.Create(20f, 6f, 172f, 0f);

            // text colour for all cubePlay - game running - help buttons - color of the help text
            //var colorValue4 = Tuple.Create(132f, 58f, 136f, 255f); // purple - debugging data, do not delete
            var colorValue4 = Tuple.Create(0f, 0f, 0f, 105f); // black

            // text colour for other cubePlay - game over - color for other symbols that participated in the game
            // var colorValue5 = Tuple.Create(251f, 234f, 123f, 255f); // yellow - debugging data, do not delete
            var colorValue5 = Tuple.Create(255f, 255f, 255f, 255f); // white
            //var colorValue5 = Tuple.Create(0f, 0f, 0f, 185f);

            // text colour for other cubePlay - game over - change A1, A2 help text on the board to invisible
            // var colorValue6 = Tuple.Create(121f, 9f, 9f, 255f); // red - debugging data, do not delete
            var colorValue6 = Tuple.Create(121f, 9f, 9f, 0f);


            colorDictionary.Add(1, colorValue1);
            colorDictionary.Add(2, colorValue2);
            colorDictionary.Add(3, colorValue3);
            colorDictionary.Add(4, colorValue4);
            colorDictionary.Add(5, colorValue5);
            colorDictionary.Add(6, colorValue6);

            return colorDictionary;
        }
    }
}