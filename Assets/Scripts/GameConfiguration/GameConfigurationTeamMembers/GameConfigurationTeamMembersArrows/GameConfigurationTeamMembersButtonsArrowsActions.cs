using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsArrowsActions
    {

        public static int SetUpNewIndexForArrowLeft(List<List<GameObject[,,]>> buttonsGroupByTeams, int indexForOneTeamGameButtonsVisible, string tagName)
        {
            int teamsNumbers = buttonsGroupByTeams.Count - 1;
            int newIndex = 0;

            if (indexForOneTeamGameButtonsVisible == 0)
            {
                newIndex = teamsNumbers;

                List<GameObject[,,]> buttonsToUnhide = buttonsGroupByTeams[teamsNumbers];
                GameConfigurationTeamMembersButtonsActionsCommon.UnhideButtons(buttonsToUnhide);

                List<GameObject[,,]> buttonsToHide = buttonsGroupByTeams[0];
                GameConfigurationTeamMembersButtonsActionsCommon.HideButtons(buttonsToHide);
            }
            else
            {
                newIndex = indexForOneTeamGameButtonsVisible - 1;

                List<GameObject[,,]> buttonsToUnhide = buttonsGroupByTeams[newIndex];
                GameConfigurationTeamMembersButtonsActionsCommon.UnhideButtons(buttonsToUnhide);

                List<GameObject[,,]> buttonsToHide = buttonsGroupByTeams[indexForOneTeamGameButtonsVisible];
                GameConfigurationTeamMembersButtonsActionsCommon.HideButtons(buttonsToHide);
            }

            return newIndex;
        }

        public static int SetUpNewIndexForArrowRight(List<List<GameObject[,,]>> buttonsGroupByTeams, int indexForOneTeamGameButtonsVisible, string tagName)
        {
            int teamsNumbers = buttonsGroupByTeams.Count - 1;
            int newIndex = 0;

            if (indexForOneTeamGameButtonsVisible == teamsNumbers)
            {
                newIndex = 0;

                List<GameObject[,,]> buttonsToUnhide = buttonsGroupByTeams[0];
                GameConfigurationTeamMembersButtonsActionsCommon.UnhideButtons(buttonsToUnhide);

                List<GameObject[,,]> buttonsToHide = buttonsGroupByTeams[teamsNumbers];
                GameConfigurationTeamMembersButtonsActionsCommon.HideButtons(buttonsToHide);
            }
            else
            {
                newIndex = indexForOneTeamGameButtonsVisible + 1;

                List<GameObject[,,]> buttonsToUnhide = buttonsGroupByTeams[newIndex];
                GameConfigurationTeamMembersButtonsActionsCommon.UnhideButtons(buttonsToUnhide);

                List<GameObject[,,]> buttonsToHide = buttonsGroupByTeams[indexForOneTeamGameButtonsVisible];
                GameConfigurationTeamMembersButtonsActionsCommon.HideButtons(buttonsToHide);
            }

            return newIndex;
        }

        public static int SetUpNewIndexForOneTeamGameButtonsVisible(List<List<GameObject[,,]>> buttonsGroupByTeams, int indexForOneTeamGameButtonsVisible, string tagName)
        {
            string arrowLeft = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonArrowLeft();
            string arrowRight = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonArrowRight();
            int newIndex = 0;

            if (arrowLeft == tagName)
                newIndex = SetUpNewIndexForArrowLeft(buttonsGroupByTeams, indexForOneTeamGameButtonsVisible, tagName);

            if (arrowRight == tagName)
                newIndex = SetUpNewIndexForArrowRight(buttonsGroupByTeams, indexForOneTeamGameButtonsVisible, tagName);

            return newIndex;
        }


        // arrows

        public static void HideArrows(List<GameObject> buttonsArrows)
        {
            int listElements = buttonsArrows.Count;
            float newCoordinateY = 100;

            for (int i = 0; i < listElements; i++)
            {
                GameObject arrow = buttonsArrows[i];
                GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(arrow, newCoordinateY);
            }

        }

        public static void UnhideArrows(List<GameObject> buttonsArrows)
        {
            int listElements = buttonsArrows.Count;
            float newCoordinateY = -100;

            for (int i = 0; i < listElements; i++)
            {
                GameObject arrow = buttonsArrows[i];
                GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(arrow, newCoordinateY);
            }
        }


    }
}
