using Assets.Scripts.Buttons;
using Assets.Scripts.GameConfigurationPlayerSymbol;
using Assets.Scripts.GameDictionaries;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationPlayerSymbolButtons
{
    internal class GameConfigurationPlayerSymbolButtonsActions
    {
        public static void HideConfigurationBaseButtons(List<List<GameObject[,,]>> gameObjectsLists, string gameObjectName)
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
            ChangeChosenSymbolForPlayer(touch);
        }

        public static void DestroyButtons(GameObject[,,] table, List<GameObject[,,]> tableList)
        {
            ButtonsCommonMethodsActionsDestroy.DestroyTable3D(table);
            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsList(tableList);
        }

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
