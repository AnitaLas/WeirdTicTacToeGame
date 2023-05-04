using Assets.Scripts.Buttons;
using Assets.Scripts.GameConfiguration.GameConfigurationButtons;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationButtonsCommon
{
    internal class GameConfigurationButtonsCommonCreate
    {
        // ---
        public static GameObject[,,] CreateCommonButtonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesScenesCommon.DictionaryButtonsCommonName();

            string buttonText = buttonsGameNameDictionary[1];
            //string buttonText = "X";

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            //float newCoordinateY = -4.5f;
            float newCoordinateY = -4.5f;
            float newCoordinateX = 1.75f;

            ButtonsCommonMethods.ChangeDataForSingleCommonButton(tableButtonNewGame, newCoordinateY, newCoordinateX, tagNameDictionary);

            return tableButtonNewGame;

        }

        public static GameObject[,,] CreateCommonButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesScenesCommon.DictionaryButtonsCommonName();

            string buttonText = buttonsGameNameDictionary[2];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.5f;
            float newCoordinateX = -1f;

            ButtonsCommonMethods.ChangeDataForSingleCommonButton(tableButtonNewGame, newCoordinateY, newCoordinateX, tagNameDictionary);

            return tableButtonNewGame;

        }

        public static GameObject[,,] CreateCommonButtonBackToConfiguration(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesScenesCommon.DictionaryButtonsCommonName();

            string buttonText = buttonsGameNameDictionary[2];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.5f;
            float newCoordinateX = 0.42f;

            ButtonsCommonMethods.ChangeDataForSingleCommonButton(tableButtonNewGame, newCoordinateY, newCoordinateX, tagNameDictionary);
            GameConfigurationButtonsActions.HideButtonBackToConfiguration(tableButtonNewGame);

            return tableButtonNewGame;

        }
        // ---

        public static GameObject[,,] CreateCommonButtonForText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] tableButtonNewGame;

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(tableButtonNewGame, newCoordinateY, tagNameDictionary);
            
            float newScale = 0.3f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(tableButtonNewGame, newScale);

            return tableButtonNewGame;

        }

        public static GameObject[,,] CreateCommonButtonForNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] tableButtonNewGame;

            int numberOfDepths = 1;
            int numberOfRows = 1;
            int numberOfColumns = 1;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;

            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(tableButtonNewGame, newCoordinateY, tagNameDictionary);

            return tableButtonNewGame;

        }

        public static GameObject[,,] CreateCommonButtonForSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] tableButtonNewGame;

            int numberOfDepths = 1;
            int numberOfRows = 1;
            int numberOfColumns = 1;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;

            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(tableButtonNewGame, newCoordinateY, tagNameDictionary);

            return tableButtonNewGame;

        }

    }
}
