using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameMenuButtonsCreate : MonoBehaviour
    {
        public static List<GameObject[,,]> CreateButtonsMenu(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            List<GameObject[,,]> buttons = new List<GameObject[,,]>();

            GameObject[,,] tableConfigurationHelpButtons;
            GameObject[,,] tableConfigurationButtonNewGame;
            GameObject[,,] tableConfigurationButtonBackToGame;
            GameObject[,,] tableConfigurationButtonBoarGameHelpText;

            tableConfigurationHelpButtons = CreateButtonGameMenuHelpButtons(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            tableConfigurationButtonNewGame = CreateButtonGameMenuNewGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            tableConfigurationButtonBackToGame = CreateButtoGameMenuBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
            tableConfigurationButtonBoarGameHelpText = CreateButtonGameMenunBoarGameHelpText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);

            buttons.Insert(0, tableConfigurationHelpButtons);
            buttons.Insert(1, tableConfigurationButtonNewGame);
            buttons.Insert(2, tableConfigurationButtonBackToGame);
            buttons.Insert(3, tableConfigurationButtonBoarGameHelpText);

            return buttons;
        }

        public static GameObject[,,] CreateButtonGameMenuNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneGame.DictionaryButtonsGameName();

            string tagGameButtonNewGame = tagCubePlayDictionary[3];
            string buttonText = buttonsGameNameDictionary[1];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -1;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

            return tableButtonNewGame;
        }

        public static void CreateButtonNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneGame.DictionaryButtonsGameName();

            string tagGameButtonNewGame = tagCubePlayDictionary[3];
            string buttonText = buttonsGameNameDictionary[1];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.75f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);
        }

        public static GameObject[,,] CreateButtonGameMenuHelpButtons(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonHelpButtons;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneGame.DictionaryButtonsGameName();

            string tagGameButtonHelpButtons = tagCubePlayDictionary[4];
            string buttonText = buttonsGameNameDictionary[3];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonHelpButtons = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);
       
            float newCoordinateY = 2;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonHelpButtons, newCoordinateY, tagGameButtonHelpButtons);

            return tableButtonHelpButtons;
        }

        public static GameObject[,,] CreateButtoGameMenuBack(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonBack;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneGame.DictionaryButtonsGameName();

            string tagGameButtonHelpButtons = tagCubePlayDictionary[5];
            string buttonText = buttonsGameNameDictionary[2];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonBack = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.75f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonBack, newCoordinateY, tagGameButtonHelpButtons);

            return tableButtonBack;
        }

        public static GameObject[,,] CreateButtonGameMenunBoarGameHelpText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneGame.DictionaryButtonsGameName();

            string tagGameButtonNewGame = tagCubePlayDictionary[8];
            string buttonText = buttonsGameNameDictionary[4];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0.5f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

            return tableButtonNewGame;
        }
    }
}
