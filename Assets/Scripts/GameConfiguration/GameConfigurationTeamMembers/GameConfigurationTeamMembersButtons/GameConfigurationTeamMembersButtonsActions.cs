using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsActions
    {
        // button: hide

        public static void HideButtons(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams)
        {
            HideButtons(buttonsStatic);
            HideButtons(buttonsWithTeams);
        }


        public static void HideTeamMembersElementsPlayersNumbers(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            //HideButtons(buttonsStatic);
            //HideButtons(buttonsWithTeams);
            HideButtons(buttonsStatic, buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForChangeNumber(gameObjectName);
            //GameConfigurationTeamMembersButtonsMethods.ChangeTagForChangeSymbol(gameObjectName);
        }

        public static void HideTeamMembersElementsPlayersSymbols(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            //HideButtons(buttonsStatic);
            //HideButtons(buttonsWithTeams);
            HideButtons(buttonsStatic, buttonsWithTeams);
            //GameConfigurationTeamMembersButtonsMethods.ChangeTagForChangeNumber(gameObjectName);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForChangeSymbol(gameObjectName);
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
        // button: unhide
        public static void UnhideButtons(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams)
        {
            UnhideButtons(buttonsStatic);
            UnhideButtons(buttonsWithTeams);
        }
        public static void UnhideTeamMembersElementsAfterChangePlayersNumber(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            //UnhideButtons(buttonsStatic);
            //UnhideButtonsList(buttonsWithTeams);
            UnhideButtons(buttonsStatic, buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.SetUpNewPlayersNumberForTeam(gameObjectName);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForDefaultNumber();
        }

        public static void UnhideTeamMembersElementsWhenBackFromViewTableNumbers(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            //UnhideButtons(buttonsStatic);
            //UnhideButtonsList(buttonsWithTeams);
            UnhideButtons(buttonsStatic, buttonsWithTeams);
            //GameConfigurationTeamMembersButtonsMethods.SetUpNewPlayersNumberForTeam(gameObjectName);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForDefaultNumber();
        }

        public static void UnhideTeamMembersElementsWhenBackFromViewTableSymbols(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            //UnhideButtons(buttonsStatic);
            //UnhideButtonsList(buttonsWithTeams);
            UnhideButtons(buttonsStatic, buttonsWithTeams);
            //GameConfigurationTeamMembersButtonsMethods.SetUpNewPlayersNumberForTeam(gameObjectName);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForDefaultTeamSymbol();
        }

        public static void UnhideTeamMembersElementsAfterChangePlayerSymbol(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            //UnhideButtons(buttonsStatic);
            //UnhideButtonsList(buttonsWithTeams);
            UnhideButtons(buttonsStatic, buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.SetUpNewPlayersNumberForTeam(gameObjectName);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForDefaultTeamSymbol();
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

        //public static void UnhideButtonsList(List<List<GameObject[,,]>> listWithListElements)
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
            //DestroyButtonsWithNumber(gameObjects);
            DestroyBackButton(gameObjectsList);
        }

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
