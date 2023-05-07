using Assets.Scripts.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameDictionaries
{
    internal class GameDictionariesSceneGame
    {
        public static Dictionary<int, string> DictionaryTagGame()
        {
            Dictionary<int, string> tagGameDictionary = new Dictionary<int, string>
            {
                { 1, "GameButtonMenuConfigurationLeft" },
                { 2, "GameButtonMenuConfigurationRight" },
                { 3, "GameButtonNewGame" },
                { 4, "GameButtonHelpButtons" },
                { 5, "GameButtonMenuBack" },
                { 6, "GameButtonParentObjectHelpButtons" },
                { 7, "GameButtonMenuConfigurationDisactivate" }
            };
            //tagGameDictionary.Add(4, "GameButtonHideHelpButtons");
            //tagGameDictionary.Add(5, "GameButtonUnhideHelpButtons");

            return tagGameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsGameName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "NEW GAME" },
                { 2, "BACK" },
                { 3, "HELP BUTTONS" }
            };

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryTagCubePlay()
        {
            Dictionary<int, string> tagCubePlayDictionary = new Dictionary<int, string>
            {
                { 1, "CubePlayFree" },
                { 2, "CubePlayTaken" },
                { 3, "CubePlayFrame" },
                { 4, "CubePlayGameOver" },
                { 5, "CubePlayGameWin" }
            };

            return tagCubePlayDictionary;
        }

        public static Dictionary<int, string> DictionaryTagHelpButtons()
        {
            Dictionary<int, string> tagHelpButtonDictionary = new Dictionary<int, string>
            {
                { 1, "ArrowRight" },
                { 2, "ArrowDown" },
                { 3, "ArrowLeft" },
                { 4, "ArrowUp" },
                { 5, "ButtonConfirm" }
            };

            return tagHelpButtonDictionary;
        }

        public static Dictionary<int, string> DictionaryTagPlayerSymbolMove()
        {
            Dictionary<int, string> tagPlayerSymbolMoveDictionary = new Dictionary<int, string>
            {
                { 1, "PlayerSymbolCurrent" },
                { 2, "PlayerSymbolPrevious" },
                { 3, "PlayerSymbolNext" }
            };

            return tagPlayerSymbolMoveDictionary;
        }

        public static Dictionary<int, string> DictionaryTagTopObjecs()
        {
            Dictionary<int, string> tagTopObjecsDictionary = new Dictionary<int, string>
            {
                { 1, "GameButtonMenuConfigurationLeft" },
                { 2, "GameButtonMenuConfigurationRight" },
                { 3, "PlayerSymbolCurrent" },
                { 4, "PlayerSymbolPrevious" },
                { 5, "PlayerSymbolNext" }
            };

            return tagTopObjecsDictionary;
        }

    }
}


