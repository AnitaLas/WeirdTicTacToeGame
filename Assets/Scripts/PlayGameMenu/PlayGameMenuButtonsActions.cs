using Assets.Scripts.Buttons;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameMenuButtonsActions : MonoBehaviour
    {

        //// to change class -> ButtonsCommonMethodsAction
        //public static void ChangeCoordinateYForTable(GameObject[,,] tableWtithNumber, float newCoordinateZ)
        //{
        //    int maxIndexDepth = 1;
        //    int maxIndexColumn = tableWtithNumber.GetLength(2);
        //    int maxIndexRow = tableWtithNumber.GetLength(1);

        //    for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
        //    {
        //        for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
        //        {
        //            for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
        //            {
        //                GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
        //                CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateZ);
        //            }

        //        }
        //    }
        //}

        // ---

        public static void HideBoardGame(GameObject[,,] gameBoard)
        {
            //float newCoordinateY = -100f;
            //ChangeCoordinateYForTable(gameBoard, newCoordinateY);
            ButtonsCommonMethodsActions.GameObjectToHide(gameBoard);

        }

        public static void UnhideBoardGame(GameObject[,,] gameBoard)
        {
            //float newCoordinateY = 100f;
            //ChangeCoordinateYForTable(gameBoard, newCoordinateY);
            ButtonsCommonMethodsActions.GameObjectToUnhide(gameBoard);

        }

        // ---

        public static void HideCubePlayFrame()
        {
            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            string tagCubePlayFrame = tagCubePlayDictionary[3];
            ButtonsCommonMethodsActions.GameObjectToHide(tagCubePlayFrame);

        }

        public static void UnhideCubePlayFrame()
        {
            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            string tagCubePlayFrame = tagCubePlayDictionary[3];
            ButtonsCommonMethodsActions.GameObjectToUnhide(tagCubePlayFrame);
        }

        // --
        public static void HideHelpButtons()
        {
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagGame();
            string tagGameButtonParentObjectHelpButtons = tagGameDictionary[6];

            bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(tagGameButtonParentObjectHelpButtons);

            if (isGameObjectWithTagExsist == true)
            {
                ButtonsCommonMethodsActions.GameObjectToHide(tagGameButtonParentObjectHelpButtons);
            }

        }

        public static void UnhideHelpButtons()
        {
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagGame();
            string tagGameButtonParentObjectHelpButtons = tagGameDictionary[6];

            bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(tagGameButtonParentObjectHelpButtons);

            if (isGameObjectWithTagExsist == true)
            {
                //PlayGameMenuButtonsActions.UnhideGameObjectWithTag(_tagGameButtonParentObjectHelpButtons);
                ButtonsCommonMethodsActions.GameObjectToUnhide(tagGameButtonParentObjectHelpButtons);
            }
            
        }

        // ---

        //public static void ChangeCoordinateYForGameObject(string[] helpButtons, float newCoordinateY)
        //{
        //    string tagName;
        //    int helpButtonsLength = helpButtons.Length;
        //    //GameObject topObject;

        //    for (int i = 0; i < helpButtonsLength; i++)
        //    {
        //        //tagName = helpButtons[i];
        //        //topObject = CommonMethods.GetObjectByTagName(tagName);

        //        //CommonMethods.SetUpNewYForGameObject(topObject, newCoordinateY);

        //        tagName = helpButtons[i];
        //        GameObject[] gameObjects = CommonMethods.GetObjectsListWithTagName(tagName);
        //        int NumberOfgameObjects = gameObjects.Length;

        //        for (int j = 0; j < NumberOfgameObjects; j++)
        //        {
        //            GameObject gameObject = gameObjects[j];
        //            CommonMethods.SetUpNewYForGameObject(gameObject, newCoordinateY);
        //        }
                
        //    }
        //}

        public static void HideTopObjects()
        {
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagTopObjecs();
            //string tagGameButtonParentObjectHelpButtons = tagGameDictionary[6];

            ButtonsCommonMethodsActions.GameObjectToHide(tagGameDictionary);
        }

        public static void UnhideTopObjects()
        {
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagTopObjecs();
            ButtonsCommonMethodsActions.GameObjectToUnhide(tagGameDictionary);
        }

        // ---

        //public static void DisactivateConfigurationMenu(string[] tagConfigurationMenu)
        //{
        //    //Debug.Log(" 1 ");
        //    string tagNameOld;
        //    string tagNameNew = tagConfigurationMenu[0];
        //    //Debug.Log("tagNameNew = " + tagNameNew);

        //    int tagConfigurationMenuLength = tagConfigurationMenu.Length;

        //    //Debug.Log("tagConfigurationMenuLength = " + tagConfigurationMenuLength);

        //    for (int i = 1; i < tagConfigurationMenuLength; i++)
        //    {
        //        tagNameOld = tagConfigurationMenu[i];
        //        //Debug.Log("tagNameOld = " + tagNameOld);

        //        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tagNameOld);
        //        //GameObject gameObject;
        //        //GameObject gameObjectByName;

        //        //int gameObjectsNumber = gameObjects.Length;

        //        //Debug.Log("gameObjectsNumber = " + gameObjectsNumber);

        //        //for (int j = 0; j < gameObjectsNumber; j++)
        //        //{
        //        //    GameObject gameObject = gameObjects[i];
        //        //    string gameObjectName = CommonMethods.GetObjectName(gameObject);
        //        //    Debug.Log("gameObjectName = " + gameObjectName);

        //        //    gameObjectByName = CommonMethods.GetObjectByName(gameObjectName);

        //        //   CommonMethods.ChangeTagForGameObject(gameObject, tagNameNew);
        //        //}

        //        foreach (var gameObject in gameObjects)
        //        {
        //            CommonMethods.ChangeTagForGameObject(gameObject, tagNameNew);
        //        }

        //    }



        //}

        public static void UnhidePlayGameElements(GameObject[,,] gameBoard)
        {
            UnhideTopObjects();
            UnhideBoardGame(gameBoard);
            UnhideCubePlayFrame();
            UnhideHelpButtons();
        }

        public static void HidePlayGameElements(GameObject[,,] gameBoard)
        {
            HideTopObjects();
            HideBoardGame(gameBoard);
            HideCubePlayFrame();
            HideHelpButtons();
        }

        public static void UnhidePlayGameElementsHelpButtons(GameObject[,,] gameBoard)
        {
            UnhideTopObjects();
            UnhideBoardGame(gameBoard);
            UnhideCubePlayFrame();
        }

        public static void DisactivateConfigurationMenu()
        {
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagGame();
            string tagGameButtonMenuConfigurationDisactivate = tagGameDictionary[7];
            string tagGameButtonMenuConfigurationRight = tagGameDictionary[1];
            string tagGameButtonMenuConfigurationLeft = tagGameDictionary[2];

            string[] tagConfigurationMenu = new string[3];
            tagConfigurationMenu[0] = tagGameButtonMenuConfigurationDisactivate;
            tagConfigurationMenu[1] = tagGameButtonMenuConfigurationRight;
            tagConfigurationMenu[2] = tagGameButtonMenuConfigurationLeft;

            string tagNameOld;
            string tagNameNew = tagConfigurationMenu[0];

            int tagConfigurationMenuLength = tagConfigurationMenu.Length;

            for (int i = 1; i < tagConfigurationMenuLength; i++)
            {
                tagNameOld = tagConfigurationMenu[i];

                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tagNameOld);

                foreach (var gameObject in gameObjects)
                {
                    CommonMethods.ChangeTagForGameObject(gameObject, tagNameNew);
                }

            }
        }


        // ---

        //public static void HideHelpButtons(string[] helpButtons)
        //{
        //    float newCoordinateY = 100f;
        //    ChengeCoordinateYForGameObject(helpButtons, newCoordinateY);
        //}

        public static void DestroyGameConfigurationMenuButtons(List<GameObject[,,]> helpButtons)
        {
            int helpButtonsNumber = helpButtons.Count;
            GameObject helpButton;

            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;

            for (int i = 0; i < helpButtonsNumber; i++)
            {
                GameObject[,,] buttonToRemove = helpButtons[i];

                maxIndexDepth = buttonToRemove.GetLength(0); ;
                maxIndexColumn = buttonToRemove.GetLength(2);
                maxIndexRow = buttonToRemove.GetLength(1);

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            helpButton = buttonToRemove[indexDepth, indexRow, indexColumn];
                            Destroy(helpButton);
                        }

                    }
                }
            }
        }


        // it does not work for case -> sceneGame, do not clik on the bord game, click the menu configuration, cubePlayFrame does not move, if clik on field A1 then configuration it works
        //public static void HideCubePlayFrame2(GameObject cubePlayFrame)
        //{
        //    Debug.Log(" cubePlayFrame.name =  " + cubePlayFrame.name);
        //    float newCoordinateY = -100f;

        //    CommonMethods.SetUpNewYForGameObject(cubePlayFrame, newCoordinateY);

        //    float x = cubePlayFrame.transform.position.x;
        //    float y = cubePlayFrame.transform.position.y;
        //    float z = cubePlayFrame.transform.position.z;

        //    Debug.Log(" y =  " + y);
        //    Debug.Log(" y + newCoordinateY =  " + (y + newCoordinateY));
        //    float newY = y + newCoordinateY;

        //    cubePlayFrame.transform.position = new Vector3(x, newY, z);

        //}

    }
}
