using Assets.Scripts.Buttons;
using Assets.Scripts.GameConfigurationPlayerSymbol;
using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationPlayerSymbolButtons
{
    internal class GameConfigurationPlayerSymbolButtonsActions
    {

        //public static void UnhideConfiguration(List<GameObject[,,]> gameObjects)
        //{
        //    ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjects);
        //}

        //public static void HideConfiguration(List<GameObject[,,]> gameObjects)
        //{
        //    ButtonsCommonMethodsActions.GameObjectToHide(gameObjects);
        //}

        // ---

        //public static void HideTableWithNumber(GameObject[,,] gameObjects)
        //{
        //    ButtonsCommonMethodsActions.GameObjectToHide(gameObjects);
        //}

        public static void UnhideTableWithNumber(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjects);
        }

        // ---

        //public static void HideButtonBackToConfiguration(GameObject[,,] gameObjects)
        //{
        //    ButtonsCommonMethodsActions.GameObjectToHide(gameObjects);
        //}

        //public static void UnhideButtonBackToConfiguration(GameObject[,,] gameObjects)
        //{
        //    ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjects);
        //}

        // --- 

        public static void HideConfigurationBaseButtons(List<List<GameObject[,,]>> gameObjectsLists, string gameObjectName)
        //public static void HideConfigurationBaseButtons(List<List<GameObject[,,]>> gameObjectsLists )
        {
            ButtonsCommonMethodsActions.GameObjectToHide(gameObjectsLists);
            ChangeTagForPlayerDefaultSymbol(gameObjectName);
        }

        public static void UnhideConfigurationBaseButtons(List<List<GameObject[,,]>> gameObjectsLists)
        {
            ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjectsLists);
            ChangeTagForPlayerDefaultSymbol();
        }

        public static void UnhideConfigurationBaseButtons(List<List<GameObject[,,]>> gameObjectsLists, RaycastHit touch)
        {
            ButtonsCommonMethodsActions.GameObjectToUnhide(gameObjectsLists);
            //ChangeTagForPlayerDefaultSymbol();
            ChangeChosenSymbolForPlayer(touch);
        }

        // --- 

        public static void DestroyButtons(GameObject[,,] table)
        {
            ButtonsCommonMethodsActionsDestroy.DestroyTable3D(table);
        }

        public static void DestroyButtons(List<GameObject[,,]> tableList)
        {
            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsList(tableList);
        }

        public static void DestroyButtons(GameObject[,,] table, List<GameObject[,,]> tableList)
        {
            ButtonsCommonMethodsActionsDestroy.DestroyTable3D(table);
            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsList(tableList);
        }

        // ---

        public static void ChangeChosenSymbolForPlayer(RaycastHit touch)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();
            string _tagConfigurationPlayerSymbolChange = tagNameDictionary[3];
            string _tagConfigurationPlayerSymbolDefaultSymbol = tagNameDictionary[2];

            GameConfigurationPlayerSymbolCommonMethods.ChangeChosenSymbolForPlayer(touch, _tagConfigurationPlayerSymbolChange, _tagConfigurationPlayerSymbolDefaultSymbol);

        }

        public static void ChangeTagForPlayerDefaultSymbol(string gameObjectName)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();
            string tagConfigurationPlayerSymbolChange = tagNameDictionary[3];
            string tagConfigurationPlayerSymbolDefaultSymbol = tagNameDictionary[2];

            GameConfigurationPlayerSymbolCommonMethods.ChangeTagForPlayerDefaultSymbol(gameObjectName, tagConfigurationPlayerSymbolChange, tagConfigurationPlayerSymbolDefaultSymbol);

        }

        public static void ChangeTagForPlayerDefaultSymbol()
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();
            string tagConfigurationPlayerSymbolChange = tagNameDictionary[3];
            string tagConfigurationPlayerSymbolDefaultSymbol = tagNameDictionary[2];

            GameConfigurationPlayerSymbolCommonMethods.ChangeGameObjectTag(tagConfigurationPlayerSymbolChange, tagConfigurationPlayerSymbolDefaultSymbol);

        }
    }
}
