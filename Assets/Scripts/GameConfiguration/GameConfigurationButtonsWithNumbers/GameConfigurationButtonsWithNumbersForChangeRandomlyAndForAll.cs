using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsWithNumbersForChangeRandomlyAndForAll
    {

        public static void SetUpDefaultTime(string gameObjectTagName)
        {
            GameObject button = CommonMethods.GetObjectByTagName(gameObjectTagName);
            string defaultTime = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonTimeForChange();
            CommonMethods.ChangeTextForCubePlay(button, defaultTime);
        }

        public static int SetUpChosenTimeForConfigurationRandomly(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagConfigurationBoardGameChangeNumberForAll = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberForAll();
            SetUpDefaultTime(tagConfigurationBoardGameChangeNumberForAll);
            int time = GameConfigurationButtonsCommonMethods.SetUpChosenNumberForConfigurationRandomly(_buttonsWithNumbers, gameObjectName);
            return time;
        }

        public static int SetUpChosenTimeForConfigurationForAll(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagConfigurationBoardGameChangeNumberRandomly = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberRandomly();
            SetUpDefaultTime(tagConfigurationBoardGameChangeNumberRandomly);
            int time = GameConfigurationButtonsCommonMethods.SetUpChosenNumberForConfigurationForAll(_buttonsWithNumbers, gameObjectName);
            return time;
        }

        public static int SetUpChosenTimeForConfigurationBetweenTeams(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagConfigurationBoardGameChangeNumberBetweenTeams = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberBetweenTeams();
            SetUpDefaultTime(tagConfigurationBoardGameChangeNumberBetweenTeams);
            int time = GameConfigurationButtonsCommonMethods.SetUpChosenNumberForConfigurationBetweenTeams(_buttonsWithNumbers, gameObjectName);
            return time;
        }

    }
}
