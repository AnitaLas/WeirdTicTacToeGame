using Assets.Scripts.Buttons;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameFrame;
using Assets.Scripts.PlayGameHelpButtons;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameMenuButtonsActions : MonoBehaviour
    {
        public static void HideBoardGame(GameObject[,,] gameBoard)
        {
            ButtonsCommonMethodsActions.GameObjectToHide(gameBoard);
        }

        public static void UnhideBoardGame(GameObject[,,] gameBoard)
        {
            ButtonsCommonMethodsActions.GameObjectToUnhide(gameBoard);
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
                ButtonsCommonMethodsActions.GameObjectToUnhide(tagGameButtonParentObjectHelpButtons);
            }          
        }

        // ---

        public static void HideTopObjects()
        {
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagTopObjecs();
            ButtonsCommonMethodsActions.GameObjectToHide(tagGameDictionary);
        }

        public static void UnhideTopObjects()
        {
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagTopObjecs();
            ButtonsCommonMethodsActions.GameObjectToUnhide(tagGameDictionary);
        }

        // ---

        public static void UnhidePlayGameElements(GameObject[,,] gameBoard)
        {
            UnhideTopObjects();
            UnhideBoardGame(gameBoard);
            PlayGameFrameActions.UnhideCubePlayFrame();
            UnhideHelpButtons();
        }

        public static void HidePlayGameElements(GameObject[,,] gameBoard)
        {
            HideTopObjects();
            HideBoardGame(gameBoard);
            PlayGameFrameActions.HideCubePlayFrame();
            HideHelpButtons();
        }

        public static void UnhidePlayGameElementsHelpButtons(GameObject[,,] gameBoard)
        {
            UnhideTopObjects();
            UnhideBoardGame(gameBoard);
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

        public static void DestroyElements()
        {
            PlayGameFrameActions.DestroyCubePlayFrame();
            PlayGameHelpButtonsActions.DestroyHelpButtons();
        }
    }
}
