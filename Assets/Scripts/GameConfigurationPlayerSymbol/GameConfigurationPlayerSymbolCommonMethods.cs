using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfigurationPlayerSymbol
{
    internal class GameConfigurationPlayerSymbolCommonMethods
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

        public static void ChangeCoordinateYForTable(GameObject[,,] tableWtithNumber, float newCoordinateZ)
        {
            //float newCoordinateZ = 0.05f;

            int maxIndexDepth = 1;
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
                        //Debug.Log(" Y ");
                        //Debug.Log(" newCoordinateZ = " + newCoordinateZ);
                        CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateZ);

                    }

                }
            }
        }

        public static void UnhideTableWithNumber(GameObject[,,] tableWtithNumber)
        {
            float newCoordinateZ = -100f;
            ChangeCoordinateYForTable(tableWtithNumber, newCoordinateZ);
        }

        public static void HideTableWithNumber(GameObject[,,] tableWtithNumber)
        {
            //float newCoordinateZ = 0.75f;
            float newCoordinateY = 100f;
            ChangeCoordinateYForTable(tableWtithNumber, newCoordinateY);
        }


    }
}
