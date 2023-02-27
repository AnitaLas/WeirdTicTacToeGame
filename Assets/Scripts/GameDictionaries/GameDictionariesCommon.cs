using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameDictionaries
{
    internal class GameDictionariesCommon
    {
        public static Dictionary<int, string> DictionaryTagCubePlay()
        {
            Dictionary<int, string> tagCubePlayDictionary = new Dictionary<int, string>();

            tagCubePlayDictionary.Add(1, "CubePlayFree");
            tagCubePlayDictionary.Add(2, "CubePlayTaken");
            tagCubePlayDictionary.Add(3, "CubePlayFrame");
            tagCubePlayDictionary.Add(4, "CubePlayGameOver");
            tagCubePlayDictionary.Add(5, "CubePlayGameWin");

            return tagCubePlayDictionary;
        }

        public static Dictionary<int, string> DictionaryTagHelpButtons()
        {
            Dictionary<int, string> tagHelpButtonDictionary = new Dictionary<int, string>();

            tagHelpButtonDictionary.Add(1, "ArrowRight");
            tagHelpButtonDictionary.Add(2, "ArrowDown");
            tagHelpButtonDictionary.Add(3, "ArrowLeft");
            tagHelpButtonDictionary.Add(4, "ArrowUp");
            tagHelpButtonDictionary.Add(5, "ButtonConfirm");

            return tagHelpButtonDictionary;
        }

        public static Dictionary<int, string> DictionaryTagPlayerSymbol()
        {
            Dictionary<int, string> tagPlayerSymbolDictionary = new Dictionary<int, string>();

            tagPlayerSymbolDictionary.Add(1, "PlayerSymbolCurrent");
            tagPlayerSymbolDictionary.Add(2, "PlayerSymbolPrevious");
            tagPlayerSymbolDictionary.Add(3, "PlayerSymbolNext");

            return tagPlayerSymbolDictionary;
        }


        public static Dictionary<int, string> DictionaryChecker()
        {
            Dictionary<int, string> checkerDictionary = new Dictionary<int, string>();

            checkerDictionary.Add(1, "Horizontal");
            checkerDictionary.Add(2, "Vertical");
            checkerDictionary.Add(3, "Slash");
            checkerDictionary.Add(4, "Backslash");

            return checkerDictionary;

        }
        

        public static Dictionary<int, string> DictionaryConfiguration()
        {
            Dictionary<int, string> configurationDictionaryTag = new Dictionary<int, string>();

            configurationDictionaryTag.Add(1, "ConfigurationBoardGameButtonSave");
            configurationDictionaryTag.Add(2, "ConfigurationBoardGameButtonBack");
            configurationDictionaryTag.Add(3, "ConfigurationBoardGameTableNumberRows");
            configurationDictionaryTag.Add(4, "ConfigurationBoardGameTableNumberColumns");
            configurationDictionaryTag.Add(5, "ConfigurationBoardGameRows");
            configurationDictionaryTag.Add(6, "ConfigurationBoardGameColumns");
            configurationDictionaryTag.Add(7, "ConfigurationBoardGameChangeNumberRows");
            configurationDictionaryTag.Add(8, "ConfigurationBoardGameChangeNumberColumns");
            configurationDictionaryTag.Add(9, "ConfigurationBoardGamePlayers");
            configurationDictionaryTag.Add(10, "ConfigurationBoardGameChangeNumberPlayers");
            configurationDictionaryTag.Add(11, "ConfigurationBoardGameTableNumberPlayers");
            configurationDictionaryTag.Add(12, "ConfigurationBoardGameLenghtToCheck");
            configurationDictionaryTag.Add(13, "ConfigurationBoardGameChangeNumberLenghtToCheck");
            configurationDictionaryTag.Add(14, "ConfigurationBoardGameTableNumberLenghtToCheck");
            configurationDictionaryTag.Add(20, "ConfigurationBoardGameInactiveField");


            return configurationDictionaryTag;

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
