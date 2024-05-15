using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsCommonCreate
    {
        // ---
        public static GameObject[,,] CreateCommonButtonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary)
        {
            GameObject[,,] tableButtonNewGame;

            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesScenesCommon.DictionaryButtonsCommonName();

            //string buttonText = buttonsGameNameDictionary[1];
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForButtonSave();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.5f;
            float newCoordinateX = 1.7f;

            ButtonsCommonMethods.ChangeDataForSingleCommonButton(tableButtonNewGame, newCoordinateY, newCoordinateX, tagNameDictionary);

            return tableButtonNewGame;
        }

        public static GameObject[,,] CreateCommonButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary)
        {
            GameObject[,,] tableButtonNewGame;

            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesScenesCommon.DictionaryButtonsCommonName();

            //string buttonText = buttonsGameNameDictionary[2];
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForButtonBack();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.5f;
            float newCoordinateX = -0.9f;

            ButtonsCommonMethods.ChangeDataForSingleCommonButton(tableButtonNewGame, newCoordinateY, newCoordinateX, tagNameDictionary);

            return tableButtonNewGame;
        }

        //public static GameObject[,,] CreateCommonButtonBackToConfiguration(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary)
        //{
        //    GameObject[,,] tableButtonNewGame;

        //    Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesScenesCommon.DictionaryButtonsCommonName();

        //    string buttonText = buttonsGameNameDictionary[2];

        //    int numberOfDepths = 1;
        //    int numberOfRows = 3;
        //    int numberOfColumns = 6;

        //    string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

        //    tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

        //    float newCoordinateY = -4.5f;
        //    float newCoordinateX = 0.42f;

        //    ButtonsCommonMethods.ChangeDataForSingleCommonButton(tableButtonNewGame, newCoordinateY, newCoordinateX, tagNameDictionary);
        //    GameConfigurationButtonsActions.HideButtonBackToConfiguration(tableButtonNewGame);

        //    return tableButtonNewGame;
        //}
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

        public static GameObject[,,] CreateCommonButtonTopForTextInformation(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] button;

            int numberOfDepths = 1;
            int numberOfRows = 4;
            int numberOfColumns = 17;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagNameDictionary);

            float newScale = 0.3f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(button, newScale);

            return button;
        }

        public static GameObject[,,] CreateCommonButtonTopForStaticText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] button;

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 16;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagNameDictionary);

            float newScale = 0.25f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(button, newScale);

            return button;
        }


        public static GameObject[,,] CreateCommonButtonForNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] tableButtonNewGame;

            int numberOfDepths = 1;
            int numberOfRows = 1;
            int numberOfColumns = 1;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0.25f; // 0 without button gaps

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

        // --- short buttons P1, P2, ...

        public static GameObject[,,] CreateCommonButtonForShortText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] tableButtonNewGame;

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 5;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(tableButtonNewGame, newCoordinateY, tagNameDictionary);

            float newScale = 0.3f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(tableButtonNewGame, newScale);

            return tableButtonNewGame;
        }
    }
}
