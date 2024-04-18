using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsActionsCommon
    {

        public static void HideButtons(List<GameObject[,,]> buttons)
        {
            int buttonsNumber = buttons.Count;

            for (int i = 0; i < buttonsNumber; i++)
            {
                GameObject[,,] button = buttons[i];
                ButtonsCommonMethodsActions.GameObjectToHide(button);

            }
        }

        public static void HideButtons(List<List<GameObject[,,]>> listWithListElements)
        {
            int listElements = listWithListElements.Count;

            for (int i = 0; i < listElements; i++)
            {
                List<GameObject[,,]> list = listWithListElements[i];
                ButtonsCommonMethodsActions.GameObjectToHide(list);

            }
        }

        public static void HideButtons(GameObject[,,] button)
        {
            ButtonsCommonMethodsActions.GameObjectToHide(button);
        }


        public static void UnhideButtons(List<GameObject[,,]> buttons)
        {
            int buttonsNumber = buttons.Count;

            for (int i = 0; i < buttonsNumber; i++)
            {
                GameObject[,,] button = buttons[i];
                ButtonsCommonMethodsActions.GameObjectToUnhide(button);

            }
        }


        public static void UnhideButtons(List<List<GameObject[,,]>> listWithListElements)
        {
            int listElements = listWithListElements.Count;

            for (int i = 0; i < listElements; i++)
            {
                List<GameObject[,,]> list = listWithListElements[i];
                ButtonsCommonMethodsActions.GameObjectToUnhide(list);

            }
        }

        // button: destroy 

        public static void DestroyButtonsForTeamNumbers(List<GameObject[,,]> gameObjectsList)
        {
            DestroyBackButton(gameObjectsList);
        }

        public static void DestroyButtons(List<GameObject[,,]> gameObjectsList)
        {
            DestroyBackButton(gameObjectsList);
        }

        public static void DestroyButtonsWithNumber(GameObject[,,] gameObjects)
        {
            ButtonsCommonMethodsActionsDestroy.DestroyTable3D(gameObjects);
        }

        public static void DestroyBackButton(List<GameObject[,,]> gameObjects)
        {
            ButtonsCommonMethodsActionsDestroy.DestroyGameObjectsList(gameObjects);
        }


    

    }
}
