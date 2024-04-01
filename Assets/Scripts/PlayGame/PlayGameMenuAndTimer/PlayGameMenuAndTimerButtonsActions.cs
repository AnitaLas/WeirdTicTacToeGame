using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameMenuAndTimerButtonsActions : MonoBehaviour
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
            //Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagsGame();
            //string tagGameButtonParentObjectHelpButtons = tagGameDictionary[6];
            string tagGameButtonParentObjectHelpButtons = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagParentObjectHelpButtons();

            bool isGameObjectWithTagExsist = GameCommonMethodsMain.IsGameObjectWithTagExsist(tagGameButtonParentObjectHelpButtons);

            if (isGameObjectWithTagExsist == true)
            {
                ButtonsCommonMethodsActions.GameObjectToHide(tagGameButtonParentObjectHelpButtons);
            }
        }

        public static void UnhideHelpButtons()
        {
            //Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagsGame();
            //string tagGameButtonParentObjectHelpButtons = tagGameDictionary[6];
            string tagGameButtonParentObjectHelpButtons = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagParentObjectHelpButtons();

            bool isGameObjectWithTagExsist = GameCommonMethodsMain.IsGameObjectWithTagExsist(tagGameButtonParentObjectHelpButtons);

            if (isGameObjectWithTagExsist == true)
            {
                ButtonsCommonMethodsActions.GameObjectToUnhide(tagGameButtonParentObjectHelpButtons);
            }          
        }

        // ---

        public static void HideTopObjects()
        {
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagsTopObjecs();
            ButtonsCommonMethodsActions.GameObjectToHide(tagGameDictionary);
        }

        public static void UnhideTopObjects()
        {
            Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagsTopObjecs();
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
            string tagGameButtonMenuConfigurationDisactivate = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuConfigurationDisactivate();
            string tagGameButtonMenuConfigurationRight = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuConfigurationLeft();
            string tagGameButtonMenuConfigurationLeft = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuConfigurationRight();

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
                    GameCommonMethodsMain.ChangeTagForGameObject(gameObject, tagNameNew);
                }
            }
        }

        // ---

        public static void DestroyPlayGameButtons(List<GameObject[,,]> helpButtons)
        {
            int helpButtonsNumber = helpButtons.Count;
            GameObject helpButton;

            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;

            for (int i = 0; i < helpButtonsNumber; i++)
            {
                GameObject[,,] buttonToRemove = helpButtons[i];

                maxIndexDepth = buttonToRemove.GetLength(0);
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

        // timer

        public static void HideObjectPlayerSymbolPrevious()
        {
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolPrevious();
            ButtonsCommonMethodsActions.GameObjectToHide(tagName);
        }

        public static void HideTimerForGameBoard()
        {
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForBoardGame();
            ButtonsCommonMethodsActions.GameObjectToHide(tagName);
        }
        //public static void HideTimerForGameBoardIfExist()
        //{
        //    string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForBoardGame();
        //    ButtonsCommonMethodsActions.GameObjectToHide(tagName);
        //}

        public static void HideTimerForChangePlayersSymbols()
        {
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForPlayers();
            ButtonsCommonMethodsActions.GameObjectToHide(tagName);
        }

        public static void UnhideTimerForGameBoard()
        {
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForBoardGame(); 
            ButtonsCommonMethodsActions.GameObjectToUnhide(tagName);
        }

        public static void UnhideTimerForChangePlayersSymbols()
        {
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForPlayers();
            ButtonsCommonMethodsActions.GameObjectToUnhide(tagName);
        }

        public static void ShowTimerForChangePlayersSymbols()
        {
            HideTimerForGameBoard();
            UnhideTimerForChangePlayersSymbols();
        }

        public static void ShowTimerFoGameBoard()
        {
            HideTimerForChangePlayersSymbols();
            UnhideTimerForGameBoard();
        }
    }
}
