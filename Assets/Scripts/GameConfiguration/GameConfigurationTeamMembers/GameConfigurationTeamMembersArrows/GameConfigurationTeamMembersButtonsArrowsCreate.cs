using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsArrowsCreate
    {

        public static List<GameObject> GameConfigurationTeamMembersCreateButtonsArrows(GameObject buttonArrowLeft, GameObject buttonArrowRight)
        {

            List<GameObject> buttonsAll = new List<GameObject>();

            GameObject arrowLeft = GameConfigurationTeamMembersButtonsCreateCommon.CreateButtonArrow(buttonArrowLeft);
            GameObject arrowRight = GameConfigurationTeamMembersButtonsCreateCommon.CreateButtonArrow(buttonArrowRight);

            buttonsAll.Insert(0, arrowLeft);
            buttonsAll.Insert(1, arrowRight);

            return buttonsAll;
        }


    }
}
