using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamNumbersButtonsCreate
    {
        public static List<GameObject[,,]> GameConfigurationChangePlayerSymbolCreateButtons(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();

            // buttons: save and back
            GameObject[,,] buttonSave = GameConfigurationTeamNumbersCreateButtonSave(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationTeamNumbersCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
            
            // buttons: top
            GameObject[,,] buttonTopTextTeamGame = GameConfigurationTeamNumbersCreateButtonTopTeamNumbers(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonTopTextNumber = GameConfigurationTeamNumbersCreateButtonTopNumbers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
            GameObject[,,] buttonTopNumber = GameConfigurationTeamNumbersCreateButtonChangeNumber(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
            //GameObject[,,] buttonsWithNumbers = CreateTableForTeamGameWithNumbers(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);

            //buttons: table with numbers to change
            List<GameObject[,,]> tableWithButtonsNumber = new List<GameObject[,,]>();

            buttonsAll.Insert(0, buttonSave);
            buttonsAll.Insert(1, buttonBack);
            buttonsAll.Insert(2, buttonTopTextTeamGame);
            buttonsAll.Insert(3, buttonTopTextNumber);
            //buttonsAll.Insert(4, buttonTopNumber);
            //buttonsAll.Insert(5, buttonsWithNumbers);
            //buttonsAll.Insert(5, buttonForAllText);
            //buttonsAll.Insert(6, battonForAllNumber);





            return buttonsAll;
        }

        // -------------------------------------------------------------------------------------------
        // buttons: save & back
        public static GameObject[,,] GameConfigurationTeamNumbersCreateButtonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersButtonSave();
            GameObject[,,] buttonSave = GameConfigurationButtonsCommonCreate.CreateCommonButtonSave(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName);
            return buttonSave;
        }

        public static GameObject[,,] GameConfigurationTeamNumbersCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersButtonBack();
            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);
            return buttonBack;
        }

        // -------------------------------------------------------------------------------------------
        // buttons: top: team game, numbers, default number

        public static GameObject[,,] GameConfigurationTeamNumbersCreateButtonTopTeamNumbers(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersInactiveField();
            string buttonText = GameConfigurationButtonsTeamNumbersButtonsName.GetButtonNameForTeamGame();

            GameObject[,,] button = GameConfigurationTeamNumbersButtonsCreateCommon.CreateCommonButtonForTeamNumbersFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 4.35f;
            float newCoordinateX = -0.8f;
            GameConfigurationTeamNumbersButtonsMethods.ChangeDataForSingleGameConfigurationTeamNumbersButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] GameConfigurationTeamNumbersCreateButtonTopNumbers(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {

            string tagName = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersInactiveField();
            string buttonText = GameConfigurationButtonsTeamNumbersButtonsName.GetButtonNameForNumbers();

            GameObject[,,] button = GameConfigurationTeamNumbersButtonsCreateCommon.CreateCommonButtonForTeamNumbersNumber(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 3.9f;
            float newCoordinateX = -0.4f;
            GameConfigurationTeamNumbersButtonsMethods.ChangeDataForSingleGameConfigurationTeamNumbersButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] GameConfigurationTeamNumbersCreateButtonChangeNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersChange();
            string buttonText = GameConfigurationButtonsTeamNumbersButtonsName.GetDefaultButtonNumberForTeamNumbers();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 3.1f;
            float newCoordinateX = 0.9f;

            GameConfigurationTeamNumbersButtonsMethods.ChangeDataForSingleGameConfigurationTeamNumbersButtonNumber(button, newCoordinateY, newCoordinateX);

            return button;
        }

        // buttons: change team number


        public static GameObject[,,] CreateTableForTeamGameWithNumbers(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            int numberOfDepths = 1;
            int numberOfRows = 2;
            int numberOfColumns = 3;

            tableWithNumbers = GameConfigurationButtonsWithNumbersForTeamNumbers.CreateTableWithTeamNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = GameConfigurationButtonsWithNumbersForTeamNumbers.ChangeDataForTableWithTeamNumbers(tableWithNumbers);

            return tableWithNumberFinal;
        }

    }
}
