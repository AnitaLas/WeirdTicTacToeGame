using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsActions
    {
        // button: hide
        public static void HideTeamMembersElements(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            HideButtons(buttonsStatic);
            HideButtonsList(buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForChangeNumber(gameObjectName);
        }


        public static void HideButtons(List<GameObject[,,]> buttons)
        {
            int buttonsNumber = buttons.Count;

            for (int i = 0; i < buttonsNumber; i++)
            {
                GameObject[,,] button = buttons[i];
                ButtonsCommonMethodsActions.GameObjectToHide(button);

            }
        }

        public static void HideButtonsList(List<List<GameObject[,,]>> listWithListElements)
        {
            int listElements = listWithListElements.Count;

            for (int i = 0; i < listElements; i++)
            {
                List<GameObject[,,]> list = listWithListElements[i];
                ButtonsCommonMethodsActions.GameObjectToHide(list);

            }
        }

        // button: unhide

        public static void UnhideTeamMembersElements(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            UnhideButtons(buttonsStatic);
            UnhideButtonsList(buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.SetUpNewPlayersNumberForTeam(gameObjectName);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForDefaultNumber();
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

        public static void UnhideButtonsList(List<List<GameObject[,,]>> listWithListElements)
        {
            int listElements = listWithListElements.Count;

            for (int i = 0; i < listElements; i++)
            {
                List<GameObject[,,]> list = listWithListElements[i];
                ButtonsCommonMethodsActions.GameObjectToUnhide(list);

            }
        }

        // button: destroy 

        public static void DestroyButtons(List<GameObject[,,]> gameObjectsList)
        {
            //DestroyButtonsWithNumber(gameObjects);
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
