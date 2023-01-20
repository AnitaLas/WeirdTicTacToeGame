using System;
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
            Dictionary<int, string> tagArrowDictionary = new Dictionary<int, string>();

            tagArrowDictionary.Add(1, "CubePlayFree");
            tagArrowDictionary.Add(2, "CubePlayTaken");
            tagArrowDictionary.Add(3, "CubePlayFrame");

            return tagArrowDictionary;
        }

        public static Dictionary<int, string> DictionaryTagArrow()
        {
            Dictionary<int, string> tagArrowDictionary = new Dictionary<int, string>();

            tagArrowDictionary.Add(1, "ArrowRight");
            tagArrowDictionary.Add(2, "ArrowDown");
            tagArrowDictionary.Add(3, "ArrowLeft");
            tagArrowDictionary.Add(4, "ArrowUp");

            return tagArrowDictionary;
        }
        
        

        

    }
}
