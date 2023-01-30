using System;
using System.Collections;
using System.Collections.Generic;
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

        public static Dictionary<int, string> DictionaryChecker()
        {
            Dictionary<int, string> checkerDictionary = new Dictionary<int, string>();

            checkerDictionary.Add(1, "Horizontal");
            checkerDictionary.Add(2, "Vertical");
            checkerDictionary.Add(3, "Slash");
            checkerDictionary.Add(4, "Backslash");

            return checkerDictionary;

        }
        
        

        

    }
}
