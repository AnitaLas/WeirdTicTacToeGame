using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameDictionaries
{
    internal class GameDictionariesScenesCommon
    {
        public static Dictionary<int, string> DictionaryScencesName()
        {
            Dictionary<int, string> scenceDictionary = new Dictionary<int, string>();

            scenceDictionary.Add(1, "SceneGame");
            scenceDictionary.Add(2, "SceneConfigurationPlayersSymbols");
            scenceDictionary.Add(3, "SceneConfigurationBoardGame");
            scenceDictionary.Add(4, "SceneInformations");
            scenceDictionary.Add(5, "SceneStartGame");

            return scenceDictionary;
        }

        public static Dictionary<int, string> DictionaryTagCommon()
        {
            Dictionary<int, string> tagCommonDictionary = new Dictionary<int, string>();

            tagCommonDictionary.Add(1, "Untagged");
            return tagCommonDictionary;

        }

        public static Dictionary<int, string> DictionaryButtonsCommonName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>();

            buttonsNameDictionary.Add(1, "SAVE");
            buttonsNameDictionary.Add(2, "BACK");

            return buttonsNameDictionary;
        }

        public static Dictionary<int, Tuple<float, float, float, float>> DictionaryColor()
        {
            // Tuple<float, float, float, float> => r g b a
            Dictionary<int, Tuple<float, float, float, float>> colorDictionary = new Dictionary<int, Tuple<float, float, float, float>>();

            // text colour for all cubePlay - when game is over
            var colorValue1 = Tuple.Create(200f, 33f, 33f, 0.6f);

            // test colour for winner cubePlay - when game is over
            var colorValue2 = Tuple.Create(3f, 0f, 1f, 1f);

            colorDictionary.Add(1, colorValue1);
            colorDictionary.Add(2, colorValue2);

            return colorDictionary;
        }
    }
}
