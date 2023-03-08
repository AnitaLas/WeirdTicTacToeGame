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
            Debug.Log("1 tagNameFirstChild = " + tagNameFirstChild);

            string tagNameSecondChild = dictionaryTag[2];
            Debug.Log("2 tagNameSecondChild = " + tagNameSecondChild);

            if (gameObjectTagNameTouched.Equals(tagNameFirstChild))
            {
                Debug.Log("2 child");
                gameObject.transform.GetChild(0).transform.tag = gameObjectTagNameToChange;
            } 
            else if (gameObjectTagNameTouched.Equals(tagNameSecondChild))
            {
                Debug.Log("1 child");
                gameObject.transform.tag = gameObjectTagNameToChange;
            }    
           
        }




    }
}
