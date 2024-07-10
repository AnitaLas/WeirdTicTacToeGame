using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameTeamButtonsForEndedGameCreate
    {

        public static void CreateButtonsForWinnerTeam()
        {


        }

        public static void CreateButtonsForGameOver()
        {


        }

        public static GameObject[,,] CreateCommonButtonGameTeamBackgroundForEndedGameForText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, string buttonText)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 15;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            GameObject[,,]  button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            //float newCoordinateY = 4.8f;
            //float newCoordinateX = 0f;

            //ButtonsCommonMethods.ChangeDataForButtonsGameEnded(button, newCoordinateY, newCoordinateX, tagName);

            return button;
        }

        public static GameObject[,,] CreateCommonButtonGameTeamTopForEndedGameForText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, string buttonText)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            GameObject[,,] button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 5f;
            float newCoordinateX = 1.5f;

            ButtonsCommonMethods.ChangeDataForButtonsGameEnded(button, newCoordinateY, newCoordinateX, tagName);

            float newScale = 0.25f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(button, newScale);

            return button;
        }

        public static GameObject[,,] CreateButtonForTeamNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, string buttonText)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 5; // it looks ok for max 9 teams, for more tuples must be created

            string[] tableWithTextForButton = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            GameObject[,,] button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButton);

            float newCoordinateY = 5.2f;
            float newCoordinateX = 2.6f;

            ButtonsCommonMethods.ChangeDataForButtonsGameEnded(button, newCoordinateY, newCoordinateX, tagName);

            float newScale = 0.25f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(button, newScale);

            return button;
        }

        // buttons: game over
        public static GameObject[,,] CreateButtonGameTeamForTextGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInactiveField();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForTextGame();

            //GameObject[,,] button = CreateCommonButtonGameTeamBackgroundForEndedGameForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 4.8f;
            float newCoordinateX = -0.7f;

            ButtonsCommonMethods.ChangeDataForButtonsGameEnded(button, newCoordinateY, newCoordinateX, tagName);

            string frontTextToAdd = "WinnerTeamText_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            return button;
        }

        public static GameObject[,,] CreateButtonGameTeamForTextOver(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInactiveField();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForTextOver();

            GameObject[,,] button = CreateCommonButtonGameTeamTopForEndedGameForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            return button;
        }

        // buttons: winner team

        public static GameObject[,,] CreateButtonGameTeamForTextTeam(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInactiveField();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForTextTeam();

            //GameObject[,,] button = CreateCommonButtonGameTeamBackgroundForEndedGameForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 4.8f;
            float newCoordinateX = -0.8f;

            ButtonsCommonMethods.ChangeDataForButtonsGameEnded(button, newCoordinateY, newCoordinateX, tagName);

            string frontTextToAdd = "WinnerTeamText_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            return button;
        }

        public static GameObject[,,] CreateButtonGameTeamForTextTeamNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, string teamNumber, bool isGame2D)
        {
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInactiveField();
            //string buttonText = $"_{teamNumber}_";
            string buttonText = $"-{teamNumber}-";
            //string buttonText = "33";

            //Debug.Log("-- -- buttonText: " + buttonText);

            //GameObject[,,] button = CreateCommonButtonGameTeamTopForEndedGameForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            GameObject[,,] button = CreateButtonForTeamNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            return button;
        }
    }
}
