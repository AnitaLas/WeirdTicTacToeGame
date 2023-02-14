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

        public static Dictionary<int, string> DictionaryChecker()
        {
            Dictionary<int, string> checkerDictionary = new Dictionary<int, string>();

            checkerDictionary.Add(1, "Horizontal");
            checkerDictionary.Add(2, "Vertical");
            checkerDictionary.Add(3, "Slash");
            checkerDictionary.Add(4, "Backslash");

            return checkerDictionary;

        }
        
        
        public static Dictionary<int, Tuple<float, float, float, float>> DictionaryColor()
        {
            //ArrayList colorDictionaryValue = new ArrayList();
            //Dictionary<int, ArrayList> colorDictionary = new Dictionary<int, ArrayList>();

            // r g b a
            Dictionary<int, Tuple<float, float, float, float>> colorDictionary = new Dictionary<int, Tuple<float, float, float, float>>();

            // text colour for all cubePlay - when game is over
            var colorValue1 = Tuple.Create(200f, 33f, 33f, 0.6f);

            // test colour for winner cubePlay - when game is over
            //var colorValue2 = Tuple.Create(33f, 11f, 1f, 1f);
            var colorValue2 = Tuple.Create(3f, 0f, 1f, 1f);


            colorDictionary.Add(1, colorValue1);
            colorDictionary.Add(2, colorValue2);


            return colorDictionary;


        }
        

        

    }
}
