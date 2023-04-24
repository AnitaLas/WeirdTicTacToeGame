using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameDictionaries
{
    internal class GameDictionariesGameFieldsVerification
    {
       
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
