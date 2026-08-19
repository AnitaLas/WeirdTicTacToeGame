using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
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
            string tagConfigurationPlayerSymbolChange = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolChange();
            string tagConfigurationPlayerSymbolDefaultSymbol = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolDefaultSymbol();
            GameConfigurationPlayerSymbolCommonMethods.ChangeChosenSymbolForPlayer(touch, tagConfigurationPlayerSymbolChange, tagConfigurationPlayerSymbolDefaultSymbol);
        }

        public static void ChangeTagForPlayerDefaultSymbol(string gameObjectName)
        {
            string tagConfigurationPlayerSymbolChange = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolChange();
            string tagConfigurationPlayerSymbolDefaultSymbol = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolDefaultSymbol();
            GameConfigurationPlayerSymbolCommonMethods.ChangeTagForPlayerDefaultSymbol(gameObjectName, tagConfigurationPlayerSymbolChange, tagConfigurationPlayerSymbolDefaultSymbol);
        }

        public static void ChangeTagForPlayerDefaultSymbol()
        {
            string tagConfigurationPlayerSymbolChange = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolChange();
            string tagConfigurationPlayerSymbolDefaultSymbol = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolDefaultSymbol();
            GameConfigurationPlayerSymbolCommonMethods.ChangeGameObjectTag(tagConfigurationPlayerSymbolChange, tagConfigurationPlayerSymbolDefaultSymbol);
        }
    }
}