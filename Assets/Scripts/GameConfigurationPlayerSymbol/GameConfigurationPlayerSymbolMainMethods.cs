using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfigurationPlayerSymbol
{
    internal class GameConfigurationPlayerSymbolMainMethods
    {

        public static void ChangeTagForDefaultPlayerSymbol(GameObject gameObject, string gameObjectTagNameTouched, string gameObjectTagNameToChange)
        {
            //gameObject.transform.tag = gameObjectTagName;
            Dictionary<int, string> dictionaryTag = GameDictionariesCommon.DictionaryTagConfigurationPlayersSymbols();

            string tagNameFirstChild = dictionaryTag[1];
            //string tagNameSecondChild = dictionaryTag[2];
            if (gameObjectTagNameTouched.Equals(tagNameFirstChild))
            {
                gameObject.transform.GetChild(1).transform.tag = gameObjectTagNameToChange;
            } 
            else
            {
                gameObject.transform.tag = gameObjectTagNameToChange;
            }    
           
        }


    }
}
