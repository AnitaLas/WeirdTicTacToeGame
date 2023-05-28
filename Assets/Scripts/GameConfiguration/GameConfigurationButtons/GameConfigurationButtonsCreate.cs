using Assets.Scripts.Buttons;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameMenu;
using Assets.Scripts.GameConfiguration.GameConfigurationButtonsCommon;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GameConfiguration.GameConfigurationButtonsBase;

namespace Assets.Scripts.GameConfiguration.GameConfigurationButtons
{
    internal class GameConfigurationButtonsCreate
    {
        public static List<GameObject[,,]> GameConfigurationCreateButtons(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsBackColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            // buttons with text
            GameObject[,,] battonPlayerText = GameConfigurationCreateButtonPlayerText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonRowText = GameConfigurationCreateButtonRowText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonColumnText = GameConfigurationCreateButtonColumnText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonLenghtToCheckText = GameConfigurationCreateButtonLenghtToCheckText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);

            List<GameObject[,,]> buttonsText = new List<GameObject[,,]>();
            buttonsText.Insert(0, battonPlayerText);
            buttonsText.Insert(1, battonRowText);
            buttonsText.Insert(2, battonColumnText);
            buttonsText.Insert(3, battonLenghtToCheckText);

            // buttons with number
            GameObject[,,] battonPlayerNumber = GameConfigurationCreateButtonPlayerNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonRowNumber = GameConfigurationCreateButtonRowNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonColumnNumber = GameConfigurationCreateButtonColumnNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonLenghtToCheckNumber = GameConfigurationCreateButtonLenghtToCheckNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);

            List<GameObject[,,]> buttonsNumber = new List<GameObject[,,]>();
            buttonsNumber.Insert(0, battonPlayerNumber);
            buttonsNumber.Insert(1, battonRowNumber);
            buttonsNumber.Insert(2, battonColumnNumber);
            buttonsNumber.Insert(3, battonLenghtToCheckNumber);

            ButtonsCommonMethods.ChangeColourForButtonsWithNumbers(buttonsNumber, prefabCubePlayButtonsNumberColour);

            GameObject gameObjectBase = battonPlayerText[0, 0, 0];
            int numberOfButton = buttonsText.Count;

            float[] newYForButtons = GameConfigurationButtonsMethods.GetTableWithNewYForGameConfigurationButtons(gameObjectBase, numberOfButton);

            GameConfigurationButtonsMethods.ChangeDataForGameConfigurationButtons(buttonsText, buttonsNumber, newYForButtons);

            // button save and back
            GameObject[,,] buttonSave = GameConfigurationCreateButtonSave(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, battonPlayerText);
            buttonsAll.Insert(1, battonRowText);
            buttonsAll.Insert(2, battonColumnText);
            buttonsAll.Insert(3, battonLenghtToCheckText);
            buttonsAll.Insert(4, battonPlayerNumber);
            buttonsAll.Insert(5, battonRowNumber);
            buttonsAll.Insert(6, battonColumnNumber);
            buttonsAll.Insert(7, battonLenghtToCheckNumber);
            buttonsAll.Insert(8, buttonSave);
            buttonsAll.Insert(9, buttonBack);

            return buttonsAll;
        }

        // ---

        public static GameObject[,,] GameConfigurationCreateButtonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();

            string tagName = tagNameDictionary[1];

            GameObject[,,] buttonSave = GameConfigurationButtonsCommonCreate.CreateCommonButtonSave(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName);
            return buttonSave;
        }

        public static GameObject[,,] GameConfigurationCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();

            string tagName = tagNameDictionary[2];

            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);
            return buttonBack;
        }

        public static GameObject[,,] GameConfigurationCreateButtonBackToConfiguration(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] tableButtonBack;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesScenesCommon.DictionaryButtonsCommonName();

            string tagName = tagCubePlayDictionary[21];
            string buttonText = buttonsGameNameDictionary[2];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonBack = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.75f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonBack, newCoordinateY, tagName);

            return tableButtonBack;
        }
        // ---

        public static GameObject[,,] GameConfigurationCreateButtonPlayerText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[9];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameButtonsName();
            string buttonText = buttonsGameNameDictionary[1];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonPlayer_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;;
        }

        public static GameObject[,,] GameConfigurationCreateButtonRowText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[5];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameButtonsName();
            string buttonText = buttonsGameNameDictionary[2];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonRow_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonColumnText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[6];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameButtonsName();
            string buttonText = buttonsGameNameDictionary[3];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonColumn_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonLenghtToCheckText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[12];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameButtonsName();
            string buttonText = buttonsGameNameDictionary[4];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonLenghtToCheck_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            return button;
        }

        // ---
        public static GameObject[,,] GameConfigurationCreateButtonPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[10];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameDefaultNumbers();
            string buttonText = buttonsGameNameDictionary[1];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonRowNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[7];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameDefaultNumbers();
            string buttonText = buttonsGameNameDictionary[2];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button; ;
        }

        public static GameObject[,,] GameConfigurationCreateButtonColumnNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[8];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameDefaultNumbers();
            string buttonText = buttonsGameNameDictionary[2];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button; ;
        }

        public static GameObject[,,] GameConfigurationCreateButtonLenghtToCheckNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[13];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameDefaultNumbers();
            string buttonText = buttonsGameNameDictionary[2];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }

        // --- information buttons

        public static GameObject[,,] GameConfigurationCreateInformationButtonPlayer(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[22];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameButtonsName();
            string buttonText = buttonsGameNameDictionary[1];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonPlayer_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button; 
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndPlayer(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] buttonInformation = GameConfigurationCreateInformationButtonPlayer(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBack =  GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonInformation);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;
        }


        public static GameObject[,,] GameConfigurationCreateInformationButtonRow(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[22];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameButtonsName();
            string buttonText = buttonsGameNameDictionary[2];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonRow_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndRow(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] buttonInformation = GameConfigurationCreateInformationButtonRow(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonInformation);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;
        }

        public static GameObject[,,] GameConfigurationCreateInformationButtonColumns(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[22];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameButtonsName();
            string buttonText = buttonsGameNameDictionary[3];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonColumn_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndColumn(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] buttonInformation = GameConfigurationCreateInformationButtonColumns(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonInformation);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;
        }


        public static GameObject[,,] GameConfigurationCreateInformationButtonlenghtToCheck(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();
            string tagName = tagNameDictionary[22];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationBoardGame.DictionaryButtonsConfigurationBoardGameButtonsName();
            string buttonText = buttonsGameNameDictionary[4];

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonLenghtToCheck_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndLenghtToCheck(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] buttonInformation = GameConfigurationCreateInformationButtonlenghtToCheck(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonInformation);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;
        }
    }
}
