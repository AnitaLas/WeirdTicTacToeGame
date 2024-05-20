using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class GameDictionariesSceneGame
    {
        public static Dictionary<int, string> DictionaryTagsGame()
        {
            Dictionary<int, string> tagGameDictionary = new Dictionary<int, string>
            {
                { 1, "GameButtonMenuConfigurationLeft" },
                { 2, "GameButtonMenuConfigurationRight" },
                { 3, "GameButtonNewGame" },
                { 4, "GameButtonHelpButtons" },
                { 5, "GameButtonMenuBack" },
                { 6, "GameButtonParentObjectHelpButtons" },
                { 7, "GameButtonMenuConfigurationDisactivate" },
                { 8, "GameButtonBoardGameHelpText" },
                { 9, "GameButtonInformationTimerForPlayers" },
                { 10, "GameButtonInformationTimerForBoardGame" },
                { 11, "GameButtonButtonToHide" }
            };
            //tagGameDictionary.Add(4, "GameButtonHideHelpButtons");
            //tagGameDictionary.Add(5, "GameButtonUnhideHelpButtons");

            return tagGameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsGameName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "  NEW GAME" },
                //{ 2, "BACK" },
                { 2, "BACK TO GAME" },
                //{ 3, "HELP BUTTONS" },
                { 3, "BUTTONS" },
                //{ 4, "BUTTONS TEXT" }
                { 4, "BOARD TEXT" },
                { 5, " PLAYER SYMBOL" },
                { 6, "PLAYERS SYMBOLS" },
                { 7, "CHANGE" },
                { 8, "SWICH" },
                { 9, "OLD       NEW" },
                { 10, "ButtonToHide" },
                { 11, "HELP" },
                //{ 12, "GAME OVER" }
                { 12, " GAME" },
                { 13, "OVER" },
                { 14, "TEAM WIN     " }
            };

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryTagsCubePlay()
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

        public static Dictionary<int, string> DictionaryTagsHelpButtons()
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

        public static Dictionary<int, string> DictionaryTagsPlayerSymbolMove()
        {
            Dictionary<int, string> tagPlayerSymbolMoveDictionary = new Dictionary<int, string>
            {
                { 1, "PlayerSymbolCurrent" },
                { 2, "PlayerSymbolPrevious" },
                { 3, "PlayerSymbolNext" }
            };

            return tagPlayerSymbolMoveDictionary;
        }

        public static Dictionary<int, string> DictionaryTagsTopObjecs()
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


