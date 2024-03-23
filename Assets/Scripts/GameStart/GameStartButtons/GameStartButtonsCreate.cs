using Assets;
using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameStartButtonsCreate
    {
 
        public static void CreateButtonsStartGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            CreateButtonStartGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            CreateButtonStartTeamGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            CreateButtonStartGameInformation(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
        }

        // button - standard/ normal game version
        public static GameObject[,,] CreateButtonStartGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonNewGame;

            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneStartGame.DictionaryTagsStartGame();
            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneStartGame.DictionaryButtonsStartGameName();

            //string tagGameButtonNewGame = tagCubePlayDictionary[1];
            string tagGameButtonNewGame = GameStartCommonButtonsTagName.GetTagForButtonNameByTagStartGame();
            //string buttonText = buttonsGameNameDictionary[1];
            string buttonText = GameStartCommonButtonsName.GetButtonNameForTraditionalGame();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 18;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 1.0f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

            return tableButtonNewGame;
        }

        // buutton - team game
        public static GameObject[,,] CreateButtonStartTeamGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonNewGame;

            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneStartGame.DictionaryTagsStartGame();
            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneStartGame.DictionaryButtonsStartGameName();

            //string tagGameButtonNewGame = tagCubePlayDictionary[2];
            string tagGameButtonNewGame = GameStartCommonButtonsTagName.GetTagForButtonNameByTagStartTeamGame();
            //string buttonText = buttonsGameNameDictionary[2];
            string buttonText = GameStartCommonButtonsName.GetButtonNameForTeamGame();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 18;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -1.0f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

            return tableButtonNewGame;
        }


        public static GameObject[,,] CreateButtonStartGameInformation(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneStartGame.DictionaryTagsStartGame();
            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneStartGame.DictionaryButtonsStartGameName();

            //string tagName = tagCubePlayDictionary[3];
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInformation();
            //string buttonText = buttonsGameNameDictionary[3];
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
