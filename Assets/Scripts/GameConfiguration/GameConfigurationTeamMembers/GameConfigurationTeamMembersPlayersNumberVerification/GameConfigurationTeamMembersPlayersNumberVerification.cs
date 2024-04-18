using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersPlayersNumberVerification
    {
        //--
        public static int SetUpMaxPlayersNumbersForTeamGameAtStart()
        {
            string defaultMaxPlayersNumbersFromDictionary = GameConfigurationButtonsTeamMembersButtonsName.GetDefaultButtonMaxNumberForTeamMembers();
            int number = CommonMethods.ConvertStringToInt(defaultMaxPlayersNumbersFromDictionary);
            return number;
        }


        //public static int SetUpPlayersNumbersForTeamGameAtStart(int teamNumbers)
        //{
        //    string defaultPlayersNumbersFromDictionary = GameConfigurationButtonsTeamMembersButtonsName.GetDefaultButtonNumberForTeamMembers();
        //    int defaultPlayersNumbersForTeams = CommonMethods.ConvertStringToInt(defaultPlayersNumbersFromDictionary);
        //    int playersNumbers = teamNumbers * defaultPlayersNumbersForTeams;
        //    return playersNumbers;
        //}

        public static int GatSumOfPlayersNumbers(List<List<GameObject[,,]>> buttonsWithTeams)
        {
            int playersNumbersForTeamGameMax = SetUpMaxPlayersNumbersForTeamGameAtStart();
            int teamsNumers = buttonsWithTeams.Count;
            int indexNumber = 0; // buttons with number
            int countedPlayersNumber = 0;

            for (int i = 0; i < teamsNumers; i++)
            {
                List<GameObject[,,]> teamButtons = buttonsWithTeams[i];
                GameObject[,,] buttonNumber = teamButtons[indexNumber];
                GameObject button = buttonNumber[0, 0, 0];
                string numberText = CommonMethods.GetCubePlayText(button);
                int number = CommonMethods.ConvertStringToInt(numberText);
                countedPlayersNumber = countedPlayersNumber + number;
            }

            //Debug.Log(" countedPlayersNumber:" + countedPlayersNumber);

            return countedPlayersNumber;
        }

        public static int GetMaxPlayersNumbersForTeam(List<List<GameObject[,,]>> buttonsWithTeams, string gameObjectName)
        {
            int playersNumbersForTeamGameMax = SetUpMaxPlayersNumbersForTeamGameAtStart();
            int teamNo = GameConfigurationTeamMembersButtonsMethods.GetTeamNumber(gameObjectName);
            int teamPlayersNumber = teamNo - 1;

            int indexNumber = 0; // buttons with number
            List<GameObject[,,]> teamButtons = buttonsWithTeams[teamPlayersNumber];
            GameObject[,,] buttonNumber = teamButtons[indexNumber];
            GameObject button = buttonNumber[0, 0, 0];
            string numberText = CommonMethods.GetCubePlayText(button);
            int number = CommonMethods.ConvertStringToInt(numberText);

            int sumOfPlayersNumbers = GatSumOfPlayersNumbers(buttonsWithTeams);
            int teamsNumers = buttonsWithTeams.Count;

            int maxPlayersNumbers = 0;

            if (sumOfPlayersNumbers < playersNumbersForTeamGameMax)
            {
                maxPlayersNumbers = playersNumbersForTeamGameMax - sumOfPlayersNumbers + number;
            }
            else
            {
                maxPlayersNumbers = number;
            }

            return maxPlayersNumbers;
        }

        public static void SetUpMaxPlayersNumbersForTableWithNumber(GameObject[,,] buttonsNumbers, int maxPlayersNumbersForTeam)
        {
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();
            string inactiveField = "-";

            int maxIndexDepth = buttonsNumbers.GetLength(0);
            int maxIndexColumn = buttonsNumbers.GetLength(2);
            int maxIndexRow = buttonsNumbers.GetLength(1);

            int index = 0;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexRow = maxIndexRow - 1; indexRow >= 0; indexRow--)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {

                        if (index > maxPlayersNumbersForTeam - 1)
                        {
                            GameObject cubePlay = buttonsNumbers[indexDepth, indexRow, indexColumn];

                            CommonMethods.ChangeTextForFirstChild(cubePlay, inactiveField);
                            CommonMethods.ChangeTagForGameObject(cubePlay, tagName);
                        }

                        index++;
                    }
                }
            }
        }
    }
}
