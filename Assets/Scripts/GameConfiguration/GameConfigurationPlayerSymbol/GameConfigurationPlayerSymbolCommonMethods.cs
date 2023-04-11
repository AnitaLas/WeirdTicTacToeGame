using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Assets.Scripts.GameConfigurationPlayerSymbol
{
    internal class GameConfigurationPlayerSymbolCommonMethods
    {
        
        public static void ChangeTagForDefaultPlayerSymbol(GameObject gameObjectParent, string gameObjectTagNameToChange)
        {
            //Debug.Log(" ChangeTagForDefaultPlayerSymbol child");
            gameObjectParent.transform.GetChild(1).transform.tag = gameObjectTagNameToChange;

        }

        public static void ChangeTagForDefaultPlayerSymbol2(string gameObjectName, string gameObjectTagNameToChange, string tagConfigurationPlayerSymbolDefaultSymbol)
        {
            //gameObjectParent.transform.GetChild(1).transform.tag = gameObjectTagNameToChange;
            //GameObject[] chosenPlayer;

            //List<GameObject[,,]> listOfCubePlayWithSymbol = new List<GameObject[,,]>();


            GameObject[] listOfSymbol = CommonMethods.GetObjectsListWithTagName(tagConfigurationPlayerSymbolDefaultSymbol);
            int tagNumber = listOfSymbol.Length;
            Debug.Log("tagNumber = " + tagNumber);

            int maxIndexDepth = 1;
            int maxIndexColumn;
            int maxIndexRow;


            for (int i = 0; i < tagNumber; i++)
            {
                Debug.Log(" 1 ");
                GameObject cubePlay = listOfSymbol[i];
                string gameObjectNameToCompare = CommonMethods.GetObjectName(cubePlay);
                Debug.Log("gameObjectNameToCompare = " + gameObjectNameToCompare);

                if (true)
                {
                    CommonMethods.ChangeTagForGameObject(cubePlay, gameObjectTagNameToChange);
                }

            }

                //for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                //{
                //    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                //    {
                //        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                //        {

                //            GameObject cubePlay = gameObject[indexDepth, indexRow, indexColumn];



                //        }
                //    }
                //}
            

            //for (int i = 0; i < tagNumber; i++)
            //{
            //    GameObject[] oneSymbol = listOfSymbol[i];
            //    maxIndexColumn = oneSymbol.GetLength(2);
            //    maxIndexRow = oneSymbol.GetLength(1);


            //    for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            //    {
            //        for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
            //        {
            //            for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
            //            {

            //                GameObject cubePlay = oneSymbol[indexDepth, indexRow, indexColumn];



            //            }
            //        }
            //    }
            //}

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

        public static TextMeshProUGUI GetTextForPlayerSymbolFirstChild(GameObject gameObject)
        {
            int childNumber = 0;
            TextMeshProUGUI playerText = CommonMethods.GetTextMeshProUGUIForPlayerSymbolChild( gameObject, childNumber);
            Debug.Log("playerText = " + playerText);
            return playerText;
        }













        public static void ChangeSymbolForPlayer( string newSymbol, string tagConfigurationPlayerSymbolChooseSymbol)
        {
            GameObject objectWithChosenSymbol = CommonMethods.GetObjectByTagName(tagConfigurationPlayerSymbolChooseSymbol);

            CommonMethods.ChangeTextForFirstChild(objectWithChosenSymbol, newSymbol);
            //string chosenSymbol = CommonMethods.GetCubePlayText(objectWithChosenSymbol);
            //Debug.Log("chosenSymbol = " + chosenSymbol);

            //CommonMethods.ChangeTextForCubePlay(objectToChange, chosenSymbol);
        }
    }
}
