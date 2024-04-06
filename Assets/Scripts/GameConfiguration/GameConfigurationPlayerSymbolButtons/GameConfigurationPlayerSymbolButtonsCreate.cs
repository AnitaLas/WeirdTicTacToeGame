using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationPlayerSymbolButtonsCreate
    {
        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtons(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsBackColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumber)
        {
            // button save and back
            GameObject[,,] buttonSave = GameConfigurationPlayerSymbolCreateButtonSave(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationPlayerSymbolCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonSave);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;
        }

        public static GameObject[,,] GameConfigurationPlayerSymbolCreateButtonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagNameConfigurationPlayersSymbols();
            //string tagName = tagNameDictionary[6];
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolButtonSave();

            GameObject[,,] buttonSave = GameConfigurationButtonsCommonCreate.CreateCommonButtonSave(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName);
            return buttonSave;
        }

        public static GameObject[,,] GameConfigurationPlayerSymbolCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            //Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagNameConfigurationPlayersSymbols();
            //string tagName = tagNameDictionary[7];
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolButtonBack();

            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);
            return buttonBack;
        }

        // ---

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtonsWithPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumber)
        {
            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            if (playersNumber <= 6)
            {
                buttonsList = GameConfigurationPlayerSymbolCreateButtonsForPlayerNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumber);
            }
            else
            {
                buttonsList = GameConfigurationPlayerSymbolCreateButtonsForPlayerNumberBiggerThanSix(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumber);
            }

            return buttonsList;
        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtonsForPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumber)
        {
            List<GameObject[,,]> buttonsList;

            //Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagNameConfigurationPlayersSymbols();
            //string tagName = tagNameDictionary[1];
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolDefaultNumber();

            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryButtonsConfigurationPlayerSymbolDefaultText();
            //string buttonText = buttonsGameNameDictionary[1];
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNamePlayer();

            string[] defaultTextForButtons = ButtonsCommonMethods.CreateTableWithefaultTextForButtons(playersNumber, buttonText);

            buttonsList = GameConfigurationPlayerSymbolButtonsMethods.GameConfigurationPlayerSymbolAllCreateButtonsForPlayerNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, playersNumber, defaultTextForButtons);

            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerNumber(buttonsList);

            return buttonsList;
        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtonsForPlayerNumberBiggerThanSix(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumber)
        {
            List<GameObject[,,]> buttonsList;

            //Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagNameConfigurationPlayersSymbols();
            //string tagName = tagNameDictionary[1];
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolDefaultNumber();


            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryButtonsConfigurationPlayerSymbolDefaultText();
            //string buttonText = buttonsGameNameDictionary[3];
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameP();

            string[] defaultTextForButtons = ButtonsCommonMethods.CreateTableWithefaultShortTextForButtons(playersNumber, buttonText);

            buttonsList = GameConfigurationPlayerSymbolButtonsMethods.GameConfigurationPlayerSymbolAllCreateButtonsForPlayerNumberBiggerThanSix(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, playersNumber, defaultTextForButtons);

            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerNumberBiggerThanSix(buttonsList);

            return buttonsList;
        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtonsForPlayerSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumber)
        {
            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            if (playersNumber <= 6)
            {
                buttonsList = GameConfigurationPlayerSymbolCreateButtonsForModeCellphone(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumber);
            }
            else
            {
                buttonsList = GameConfigurationPlayerSymbolCreateButtonsForModeTablet(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumber);
            }

            return buttonsList;
        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtonsForModeCellphone(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumber)
        {
            List<GameObject[,,]> buttonsList;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolDefaultSymbol();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNamePlayer();

            string[] defaultPlayersSymbols = CreateGameBoardCommonMethods.CreateTableWithDefaultPlayerSymbols();

            buttonsList = GameConfigurationPlayerSymbolButtonsMethods.GameConfigurationPlayerSymbolAllCreateButtonsForPlayerSymbol(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, playersNumber, defaultPlayersSymbols);

            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbols(buttonsList);

            return buttonsList;
        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtonsForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumber)
        {
            List<GameObject[,,]> buttonsList;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolDefaultSymbol();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNamePlayer();

            string[] defaultPlayersSymbols = CreateGameBoardCommonMethods.CreateTableWithDefaultPlayerSymbols();

            buttonsList = GameConfigurationPlayerSymbolButtonsMethods.GameConfigurationPlayerSymbolAllCreateButtonsForPlayerSymbol(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, playersNumber, defaultPlayersSymbols);

            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbolBiggerThanSix(buttonsList);

            return buttonsList;
        }

        public static GameObject[,,] GameConfigurationPlayerSymbolCreateButtonsWithSymbolsToChose(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabSymbolPlayerMaterialInactiveField, string[] tableWitPlayersChosenSymbols, bool isGame2D)
        {
            GameObject[,,] buttons;

            string tagConfigurationPlayerSymbolChooseSymbol = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolChooseSymbol();
            string tagConfigurationPlayerSymbolInactiveField = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolInactiveField();

            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNamePlayer();

            int numberOfDepths = 1;
            int numberOfColumns = 4;
            int numberOfRows = 7;

            buttons = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithSymbols(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);

            GameConfigurationPlayerSymbolTableWithSymbols.ChangeDataForTableWithSymbols(buttons, tableWitPlayersChosenSymbols, prefabSymbolPlayerMaterialInactiveField, tagConfigurationPlayerSymbolChooseSymbol, tagConfigurationPlayerSymbolInactiveField);

            return buttons;
        }

        // --- 

        public static List<GameObject[,,]> GameConfigurationCreateInformationBaseButtonPlayers(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagNameConfigurationPlayersSymbols();
            //string tagName = tagNameDictionary[9];
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonBoardGameButtonInformation();

            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryButtonsConfigurationPlayerSymbolDefaultText();
            //string buttonText = buttonsGameNameDictionary[2];
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNamePlayers();


            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonPlayers_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, button);

            return buttonsAll;
        }

        // --- information buttons

        public static GameObject[,,] GameConfigurationPlayerSymbolCreateButtonBackToConfiguration(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] tableButtonBack;

            //Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagNameConfigurationPlayersSymbols();
            //string tagName = tagNameDictionary[8];
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolButtonBackToConfiguration();

            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesScenesCommon.DictionaryButtonsCommonName();
            //string buttonText = buttonsGameNameDictionary[2];
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForButtonBack();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonBack = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.75f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonBack, newCoordinateY, tagName);

            string frontTextToAdd = "InformationButtonBackToConfiguration_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(tableButtonBack, frontTextToAdd);

            return tableButtonBack;
        }

        public static GameObject[,,] GameConfigurationCreateInformationButtonPlayer(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagNameConfigurationPlayersSymbols();
            //string tagName = tagNameDictionary[9];
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonBoardGameButtonInformation();

            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryButtonsConfigurationPlayerSymbolDefaultText();
            //string buttonText = buttonsGameNameDictionary[1];
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNamePlayer();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonPlayer_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] GameConfigurationPlayerSymbolCreateInformationButtonWithPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, string gameObjectName)
        {
            //Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            //string tagName = tagNameDictionary[10];

            //int dictionatyId = 10;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberPlayers();

            //string buttonText = "4";
            string buttonText = "5";

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            ButtonsGameConfigurationPlayerSymbolMethods.ChangeGameConfigurationPlayerSymbolInformationButtonsWithPlayerNumber(button);

            string frontTextToAdd = "InformationButtonWithNumber_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndPlayer(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, string gameObjectName)
        {
            GameObject[,,] buttonInformationText = GameConfigurationCreateInformationButtonPlayer(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonInformationNumber = GameConfigurationPlayerSymbolCreateInformationButtonWithPlayerNumber(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, gameObjectName);
            GameObject[,,] buttonBack = GameConfigurationPlayerSymbolCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonInformationText);
            buttonsAll.Insert(1, buttonInformationNumber);
            buttonsAll.Insert(2, buttonBack);

            return buttonsAll;
        }
    }
}
