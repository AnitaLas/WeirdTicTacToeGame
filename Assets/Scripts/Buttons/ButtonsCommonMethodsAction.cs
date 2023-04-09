using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Buttons
{
    internal class ButtonsCommonMethodsAction
    {

        public static void GameObjectToHide(List<GameObject[,,]> gameObjects)
        {
            float newCoordinateY = 100f;
            ButtonsCommonMethods.ChangeCoordinateYForSpecificTags(gameObjects, newCoordinateY);

        }

        public static void GameObjectToUnhide(List<GameObject[,,]> gameObjects)
        {
            float newCoordinateY = -100f;
            ButtonsCommonMethods.ChangeCoordinateYForSpecificTags(gameObjects, newCoordinateY);

        }

        // ---
        public static void GameObjectToHide(GameObject[,,] tableWtithNumber)
        {
            float newCoordinateY = 100f;
            ButtonsCommonMethods.ChangeCoordinateYForTable(tableWtithNumber, newCoordinateY);
        }

        public static void GameObjectToUnhide(GameObject[,,] tableWtithNumber)
        {
            float newCoordinateY = -100f;
            ButtonsCommonMethods.ChangeCoordinateYForTable(tableWtithNumber, newCoordinateY);
        }



    }
}
