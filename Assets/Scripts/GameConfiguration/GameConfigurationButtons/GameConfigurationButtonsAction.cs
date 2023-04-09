using Assets.Scripts.Buttons;
using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationBase
{
    internal class GameConfigurationButtonsAction
    {

        public static void UnhideConfiguration(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToUnhide(gameObjects);
        }

        public static void HideConfiguration(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToHide(gameObjects);
        }

        // ---

        public static void HideTableWithNumber(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToHide(gameObjects);
        }

        public static void UnhideTableWithNumber(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToUnhide(gameObjects);
        }

        // ---

        public static void HideButtonBackToConfiguration(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToHide(gameObjects);
        }

        public static void UnhideButtonBackToConfiguration(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsAction.GameObjectToUnhide(gameObjects);
        }

        // ---

        public static bool IsTableWithNumberVisible(GameObject[,,] tableWithNumber)
        {
            bool isTableVisible = ButtonsCommonMethods.IsTableWithNumberVisible(tableWithNumber);
            return isTableVisible;
        }

        public static void HideVisibleTablesWithNumber(List<GameObject[,,]> tablesWithNumber)
        {
            GameObject[,,] table;
            GameObject gameObject;

            bool isTableVisible;
            string tagName;
            int tableNumber = tablesWithNumber.Count;

            for (int i = 0; i < tableNumber; i++)
            {
                table = tablesWithNumber[i];
                gameObject = table[0, 0, 0];
                isTableVisible = IsTableWithNumberVisible(table);
                tagName = CommonMethods.GetObjectTag(gameObject);

                if (tagName != null)
                {                   
                    if (isTableVisible == true)
                    {
                        GameConfigurationButtonsAction.HideTableWithNumber(table);
                    }
                }
            }

            //bool isTableWithNumberForPlayersVisible = GameConfigurationButtonsAction.IsTableWithNumberVisible(_tableWithNumberForPlayers);
            //bool isTableWithNumberForRowsVisible = GameConfigurationButtonsAction.IsTableWithNumberVisible(_tableWithNumberForRows);
            //bool isTableWithNumberForColumnsVisible = GameConfigurationButtonsAction.IsTableWithNumberVisible(_tableWithNumberForColumns);
            //bool isTableWithNumberForLenghtToCheckVisible;



            //if (isTableWithNumberForPlayersVisible == true)
            //{
            //    GameConfigurationButtonsAction.HideTableWithNumber(_tableWithNumberForPlayers);
            //}

            //if (isTableWithNumberForRowsVisible == true)
            //{
            //    GameConfigurationButtonsAction.HideTableWithNumber(_tableWithNumberForRows);
            //}

            //if (isTableWithNumberForColumnsVisible == true)
            //{
            //    GameConfigurationButtonsAction.HideTableWithNumber(_tableWithNumberForColumns);
            //}

            //if (_tableWithNumberForLenghtToCheckBase != null)
            //{
            //    bool isTableWithNumberForLenghtToCheckVisible = GameConfigurationButtonsAction.IsTableWithNumberVisible(_tableWithNumberForLenghtToCheck);

            //    if (isTableWithNumberForLenghtToCheckVisible == true)
            //    {
            //        GameConfigurationButtonsAction.HideTableWithNumber(_tableWithNumberForLenghtToCheck);
            //    }
            //}

        }
    }
}
