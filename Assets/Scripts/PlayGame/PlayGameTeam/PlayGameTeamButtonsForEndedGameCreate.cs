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

            float newCoordinateY = 4.8f;
            float newCoordinateX = 0f;

            ButtonsCommonMethods.ChangeDataForButtonsGameEnded(button, newCoordinateY, newCoordinateX, tagName);

            return button;
        }

        public static GameObject[,,] CreateCommonButtonGameTeamTopForEndedGameForText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, string buttonText)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            GameObject[,,] button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 4.95f;
            float newCoordinateX = 1.5f;

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

            GameObject[,,] button = CreateCommonButtonGameTeamBackgroundForEndedGameForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

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

            GameObject[,,] button = CreateCommonButtonGameTeamBackgroundForEndedGameForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            return button;
        }

        public static GameObject[,,] CreateButtonGameTeamForTextTeamNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, string teamNumber, bool isGame2D)
        {
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInactiveField();
            string buttonText = $"  {teamNumber}";
            //string buttonText = $"33";

            GameObject[,,] button = CreateCommonButtonGameTeamTopForEndedGameForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            return button;
        }
    }
}
