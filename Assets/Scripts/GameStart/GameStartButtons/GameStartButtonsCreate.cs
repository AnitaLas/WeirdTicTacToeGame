using Assets;
using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameStartButtonsCreate
    {
 
        public static void CreateButtonsStartGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameNameButtons.CreateButtonGameName(prefabCubePlay, prefabCubePlayDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, isGame2D);

            CreateButtonStartGameBackgroundForStartGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            CreateButtonStartGame(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);


            CreateButtonStartGameBackgroundForStartTeamGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            CreateButtonStartTeamGame(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);



            CreateButtonStartGameInformation(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);

           
        }

        // button background

        public static GameObject[,,] CreateButtonStartGameBackgroundForStartGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] button;

            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagStartGame(); ;
            string buttonText = GameStartCommonButtonsName.GetButtonNameForGameBackground();

            int numberOfDepths = 1;
            int numberOfRows = 4;
            int numberOfColumns = 18;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 1.2f;
            //ButtonsCommonMethods.ChangeDataForSingleGameButtons(button, newCoordinateY, tagGameButtonNewGame);

            //float newCoordinateY2 = 0f;
            float newCoordinateX = 0f;

            ButtonsCommonMethods.ChangeDataForSingleGameStartButtons(button, newCoordinateY, newCoordinateX, tagName);

            return button;
        }

        // button - standard/ normal game version
        public static GameObject[,,] CreateButtonStartGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] button;

            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagStartGame();;
            string buttonText = GameStartCommonButtonsName.GetButtonNameForTraditionalGame();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0.7f;
           // ButtonsCommonMethods.ChangeDataForSingleGameButtons(button, newCoordinateY, tagName);

            //float newCoordinateY2 = 0f;
            float newCoordinateX = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameStartButtons(button, newCoordinateY, newCoordinateX, tagName);

            return button;
        }

        // buutton - team game

        public static GameObject[,,] CreateButtonStartGameBackgroundForStartTeamGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] button;

            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagStartTeamGame();
            string buttonText = GameStartCommonButtonsName.GetButtonNameForGameBackground();

            int numberOfDepths = 1;
            int numberOfRows = 4;
            int numberOfColumns = 18;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -1.0f;
            //ButtonsCommonMethods.ChangeDataForSingleGameButtons(button, newCoordinateY, tagName);

            //float newCoordinateY2 = 0f;
            float newCoordinateX = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameStartButtons(button, newCoordinateY, newCoordinateX, tagName);


            return button;
        }

        public static GameObject[,,] CreateButtonStartTeamGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] button;

            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagStartTeamGame();
            string buttonText = GameStartCommonButtonsName.GetButtonNameForTeamGame();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -1.5f;
            //ButtonsCommonMethods.ChangeDataForSingleGameButtons(button, newCoordinateY, tagName);

            //float newCoordinateY2 = 0f;
            float newCoordinateX = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameStartButtons(button, newCoordinateY, newCoordinateX, tagName);


            return button;
        }


        // button: information "?"

        public static GameObject[,,] CreateButtonStartGameInformation(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInformation();
            string buttonText = GameStartCommonButtonsName.GetButtonNameForQuestionMark();

            GameObject[,,] button = StartGameButtonsMethods.CreateButtonForInformations(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = -4.7f;
            float newCoordinateX = 1.7f;

            StartGameButtonsMethods.ChangeDataForSingleStartGameButtonInformations(button, tagName);

            StartGameButtonsMethods.ChangingCoordinatesXYButtons(button, newCoordinateX, newCoordinateY);

            return button;
        }
    }
}
