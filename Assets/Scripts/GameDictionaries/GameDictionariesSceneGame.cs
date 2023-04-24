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

        public static Dictionary<int, string> DictionaryButtonsGameName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>();

            buttonsNameDictionary.Add(1, "NEW GAME");
            buttonsNameDictionary.Add(2, "BACK");
            buttonsNameDictionary.Add(3, "HELP BUTTONS");

            return buttonsNameDictionary;
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

    }
}
