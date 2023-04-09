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
        public static Dictionary<int, string> DictionaryTagCommon()
        {
            Dictionary<int, string> tagCommonDictionary = new Dictionary<int, string>();

            tagCommonDictionary.Add(1, "Untagged");
            return tagCommonDictionary;

        }
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
        

        public static Dictionary<int, string> DictionaryTagConfigurationBoardGame()
        {
            Dictionary<int, string> configurationBoardGameDictionaryTag = new Dictionary<int, string>();

            configurationBoardGameDictionaryTag.Add(1, "ConfigurationBoardGameButtonSave");
            configurationBoardGameDictionaryTag.Add(2, "ConfigurationBoardGameButtonBack");
            configurationBoardGameDictionaryTag.Add(3, "ConfigurationBoardGameTableNumberRows");
            configurationBoardGameDictionaryTag.Add(4, "ConfigurationBoardGameTableNumberColumns");
            configurationBoardGameDictionaryTag.Add(5, "ConfigurationBoardGameRows");
            configurationBoardGameDictionaryTag.Add(6, "ConfigurationBoardGameColumns");
            configurationBoardGameDictionaryTag.Add(7, "ConfigurationBoardGameChangeNumberRows");
            configurationBoardGameDictionaryTag.Add(8, "ConfigurationBoardGameChangeNumberColumns");
            configurationBoardGameDictionaryTag.Add(9, "ConfigurationBoardGamePlayers");
            configurationBoardGameDictionaryTag.Add(10, "ConfigurationBoardGameChangeNumberPlayers");
            configurationBoardGameDictionaryTag.Add(11, "ConfigurationBoardGameTableNumberPlayers");
            configurationBoardGameDictionaryTag.Add(12, "ConfigurationBoardGameLenghtToCheck");
            configurationBoardGameDictionaryTag.Add(13, "ConfigurationBoardGameChangeNumberLenghtToCheck");
            configurationBoardGameDictionaryTag.Add(14, "ConfigurationBoardGameTableNumberLenghtToCheck");
            configurationBoardGameDictionaryTag.Add(20, "ConfigurationBoardGameInactiveField");
            configurationBoardGameDictionaryTag.Add(21, "ConfigurationBoardGameButtonBackToConfiguration");

            return configurationBoardGameDictionaryTag;
        }


        public static Dictionary<int, string> DictionaryTagConfigurationPlayersSymbols()
        {
            Dictionary<int, string> configurationPlayersSymbolsDictionaryTag = new Dictionary<int, string>();

            configurationPlayersSymbolsDictionaryTag.Add(1, "ConfigurationPlayerSymbolDefaultNumber");
            configurationPlayersSymbolsDictionaryTag.Add(2, "ConfigurationPlayerSymbolDefaultSymbol");
            configurationPlayersSymbolsDictionaryTag.Add(3, "ConfigurationPlayerSymbolChange");
            configurationPlayersSymbolsDictionaryTag.Add(4, "ConfigurationPlayerSymbolChooseSymbol");
            configurationPlayersSymbolsDictionaryTag.Add(5, "ConfigurationPlayerSymbolInactiveField");
            configurationPlayersSymbolsDictionaryTag.Add(6, "ConfigurationPlayerSymbolButtonSave");
            configurationPlayersSymbolsDictionaryTag.Add(7, "ConfigurationPlayerSymbolButtonBack");
            configurationPlayersSymbolsDictionaryTag.Add(8, "ConfigurationPlayerSymbolButtonBackToConfiguration");

            return configurationPlayersSymbolsDictionaryTag;
        }

        public static Dictionary<int, string> DictionaryTagGame()
        {
            Dictionary<int, string> tagGameDictionary = new Dictionary<int, string>();

            tagGameDictionary.Add(1, "GameButtonMenuConfigurationLeft");
            tagGameDictionary.Add(2, "GameButtonMenuConfigurationRight");
            tagGameDictionary.Add(3, "GameButtonNewGame");
            tagGameDictionary.Add(4, "GameButtonHelpButtons");
            tagGameDictionary.Add(5, "GameButtonMenuBack");
            tagGameDictionary.Add(6, "GameButtonParentObjectHelpButtons");
            tagGameDictionary.Add(7, "GameButtonMenuConfigurationDisactivate");
            //tagGameDictionary.Add(4, "GameButtonHideHelpButtons");
            //tagGameDictionary.Add(5, "GameButtonUnhideHelpButtons");

            return tagGameDictionary;
        }


        public static Dictionary<int, string> DictionaryScence()
        {
            Dictionary<int, string> scenceDictionary = new Dictionary<int, string>();

            scenceDictionary.Add(1, "SceneGame");
            scenceDictionary.Add(2, "SceneConfigurationPlayersSymbols");
            scenceDictionary.Add(3, "SceneConfigurationBoardGame");

            return scenceDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsGameName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>();

            buttonsNameDictionary.Add(1, "NEW GAME");
            buttonsNameDictionary.Add(2, "BACK");
            buttonsNameDictionary.Add(3, "HELP BUTTONS");

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsGameConfigurationCommonButtons()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>();

            buttonsNameDictionary.Add(1, "SAVE");
            buttonsNameDictionary.Add(2, "BACK");

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationBoardGameDefaultText()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>();

            buttonsNameDictionary.Add(1, "PLAYERS");
            buttonsNameDictionary.Add(2, "ROWS");
            buttonsNameDictionary.Add(3, "COLUMNS");
            //buttonsNameDictionary.Add(4, "CROSS OUT");
            buttonsNameDictionary.Add(4, "MARK TO WIN");
            //buttonsNameDictionary.Add(4, "LENGTH TO CHECK");

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsConfigurationBoardGameDefaultNumbers()
        {
            Dictionary<int, string> buttonsDefaultNumberDictionary = new Dictionary<int, string>();

            buttonsDefaultNumberDictionary.Add(1, "2");
            buttonsDefaultNumberDictionary.Add(2, "3");

            return buttonsDefaultNumberDictionary;
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
