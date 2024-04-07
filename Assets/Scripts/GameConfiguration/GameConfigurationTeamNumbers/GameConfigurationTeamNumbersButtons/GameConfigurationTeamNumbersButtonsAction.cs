using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    namespace Assets.Scripts
    {
    internal class GameConfigurationTeamNumbersButtonsAction
    {

        public static int SetUpChosenNumberForConfigurationTeamNumbers(GameObject[,,] _buttonsWithNumbers, string gameObjectName)
        {
            string tagNameToChange = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersChange();

            int number = SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, tagNameToChange);
            return number;
        }

        public static int SetUpChosenNumberForConfiguration(GameObject[,,] tableWithNumber, string gameObjectName, string tagName)
        {
            int number;
            GameObject cubePlay = GameCommonMethodsMain.GetCubePlay(tableWithNumber, gameObjectName);
            string numberString = GameCommonMethodsMain.GetCubePlayText(cubePlay);

            GameObject cubePlayToChange = GameCommonMethodsMain.GetObjectByTagName(tagName);
            GameCommonMethodsMain.ChangeTextForFirstChild(cubePlayToChange, numberString);

            number = GameCommonMethodsMain.ConvertStringToInt(numberString);
            return number;
        }

    }
}
