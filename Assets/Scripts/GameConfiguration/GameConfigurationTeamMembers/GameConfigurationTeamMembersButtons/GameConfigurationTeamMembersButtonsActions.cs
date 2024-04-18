using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsActions
    {
        // buttons: hide
        public static void HideButtons(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams)
        {
            GameConfigurationTeamMembersButtonsActionsCommon.HideButtons(buttonsStatic);
            GameConfigurationTeamMembersButtonsActionsCommon.HideButtons(buttonsWithTeams);
        }

        public static void HideTeamMembersElementsPlayersNumbers(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            HideButtons(buttonsStatic, buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForChangeNumber(gameObjectName);
        }

        public static void HideTeamMembersElementsPlayersSymbols(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            HideButtons(buttonsStatic, buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForChangeSymbol(gameObjectName);
        }

        // buttons: unhide
        public static void UnhideButtons(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams)
        {
            GameConfigurationTeamMembersButtonsActionsCommon.UnhideButtons(buttonsStatic);
            GameConfigurationTeamMembersButtonsActionsCommon.UnhideButtons(buttonsWithTeams);
        }

        // buttons: change players symbols and number for players for teams
        public static void UnhideTeamMembersElementsAfterChangePlayersNumber(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            UnhideButtons(buttonsStatic, buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.SetUpNewPlayersNumberForTeam(gameObjectName);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForDefaultNumber();
        }

        public static void UnhideTeamMembersElementsAfterChangePlayerSymbol(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            UnhideButtons(buttonsStatic, buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.SetUpNewPlayersNumberForTeam(gameObjectName);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForDefaultTeamSymbol();
        }

        // buttons: back from more specific configuration
        public static void UnhideTeamMembersElementsWhenBackFromViewTableNumbers(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            UnhideButtons(buttonsStatic, buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForDefaultNumber();
        }

        public static void UnhideTeamMembersElementsWhenBackFromViewTableSymbols(List<GameObject[,,]> buttonsStatic, List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            UnhideButtons(buttonsStatic, buttonsWithTeams);
            GameConfigurationTeamMembersButtonsMethods.ChangeTagForDefaultTeamSymbol();
        }
    }
}
