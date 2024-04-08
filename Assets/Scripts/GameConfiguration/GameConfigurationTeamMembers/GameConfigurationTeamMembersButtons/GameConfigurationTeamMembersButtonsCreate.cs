using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsCreate
    {

        public static List<GameObject[,,]> GameConfigurationTeamMembersButtons(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();

            // buttons: save and back
            GameObject[,,] buttonSave = GameConfigurationTeamMembersCreateButtonSave(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationTeamMembersCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            // buttons: top
            GameObject[,,] buttonTopTextTeamGame = GameConfigurationTeammMembersCreateButtonTopTeamGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonTopTextNumber = GameConfigurationTeaMembersCreateButtonTopPlayers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);


            int teamNumber = 3;
            GameObject[,,] buttonTextTeamNumber = GameConfigurationTeamMembersCreateSingleButtonTextWithTeamNumbers(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, teamNumber);
            
            GameObject[,,] buttonNumberTeamMembers = GameConfigurationTeamMembersCreateSingleButtonNumbertWithTeamMembers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
            
            GameObject[,,] buttonsTeamSymbols = GameConfigurationTeamMembersCreateSingleTableWithButtonsSymbols(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);

            
            
            
            
            
            
            
            
            
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
        public static GameObject[,,] GameConfigurationTeamMembersCreateButtonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonSave();
            GameObject[,,] buttonSave = GameConfigurationButtonsCommonCreate.CreateCommonButtonSave(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName);
            return buttonSave;
        }

        public static GameObject[,,] GameConfigurationTeamMembersCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonBack();
            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);
            return buttonBack;
        }

        // -------------------------------------------------------------------------------------------
        // buttons: top: team game, players

        public static GameObject[,,] GameConfigurationTeammMembersCreateButtonTopTeamGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetButtonNameForTeamGame();

            GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.CreateCommonButtonForTeamMembersFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 4.35f;
            float newCoordinateX = -0.8f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] GameConfigurationTeaMembersCreateButtonTopPlayers(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {

            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetButtonNameForPlayers();

            GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.CreateCommonButtonForTeamMembersPlayers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 3.9f;
            float newCoordinateX = -0.4f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        // -------------------------------------------------------------------------------------------
        // single buttons : team 1, team 2 , ...

        public static GameObject[,,] GameConfigurationTeamMembersCreateSingleButtonTextWithTeamNumbers(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int teamNumber)
        {

            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersDefaultNumber();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetButtonNameForTeam();
            string buttonTextFinal = $"{buttonText} {teamNumber}";

            GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.CreateCommonButtonForTeamMembersFourRows(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonTextFinal);

            float newCoordinateY = 1f;
            float newCoordinateX = -0.8f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        // single buttons: 2 players, 3 players, ...
        public static GameObject[,,] GameConfigurationTeamMembersCreateSingleButtonNumbertWithTeamMembers(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {

            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersDefaultNumber();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetDefaultButtonNumberForTeamMembers();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 1.3f;
            float newCoordinateX = 1.6f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtonNumber(button, newCoordinateY, newCoordinateX);

            return button;
        }

        // single buttons: players symbol
        public static GameObject[,,] GameConfigurationTeamMembersCreateSingleTableWithButtonsSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersTableWithSymbols();
            //string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetDefaultButtonNumberForTeamMembers();

            //GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //float newCoordinateY = 1.3f;
            //float newCoordinateX = 1.6f;
            //GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtonNumber(button, newCoordinateY, newCoordinateX);

            //return button;


            GameObject[,,] tableWithNumbers;
            //GameObject[,,] tableWithNumberFinal;

            int numberOfDepths = 1;
            int numberOfRows = 2;
            int numberOfColumns = 6;

            tableWithNumbers = GameConfigurationButtonsWithNumbersForTeamMembers.CreateTableWithTeamMembersSymbols(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            //tableWithNumberFinal = GameConfigurationButtonsWithNumbersForTeamNumbers.ChangeDataForTableWithTeamNumbers(tableWithNumbers);

            //return tableWithNumberFinal;
            return tableWithNumbers;
        }


    }
}
