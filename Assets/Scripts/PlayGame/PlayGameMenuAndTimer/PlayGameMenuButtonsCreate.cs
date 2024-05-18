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
            List<GameObject[,,]> buttonsMenu = new List<GameObject[,,]>();

            //GameObject[,,] tableConfigurationHelpButtons;
            //GameObject[,,] tableConfigurationButtonNewGame;
            //GameObject[,,] tableConfigurationButtonBackToGame;
            //GameObject[,,] tableConfigurationButtonBoarGameHelpText;

            GameObject[,,] tableConfigurationHelpButtons = CreateButtonGameMenuHelpButtons(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] tableConfigurationButtonNewGame = CreateButtonGameMenuNewGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] tableConfigurationButtonBackToGame = CreateButtoGameMenuBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
            GameObject[,,] tableConfigurationButtonBoarGameHelpText = CreateButtonGameMenunBoarGameHelpText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonToHide = CreateButtonGameMenunButtonToHide(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);

            buttonsMenu.Insert(0, tableConfigurationButtonBoarGameHelpText);
            buttonsMenu.Insert(1, tableConfigurationHelpButtons);
            buttonsMenu.Insert(2, buttonToHide);
            buttonsMenu.Insert(3, tableConfigurationButtonNewGame);


            GameObject gameObjectBase = tableConfigurationHelpButtons[0, 0, 0];
            int numberOfButton = buttonsMenu.Count;

            float[] newYForButtons = GameConfigurationButtonsMethods.GetTableWithNewYForTeamGameConfigurationButtons(gameObjectBase, numberOfButton);

            GameConfigurationButtonsMethods.ChangeDataForGameMenuButtons(buttonsMenu, newYForButtons);

            GameConfigurationButtonsMethods.ChangeDataForGameMenuButtonToHide(buttonToHide);

            buttons.Insert(0, tableConfigurationButtonBoarGameHelpText);
            buttons.Insert(1, tableConfigurationHelpButtons);
            buttons.Insert(2, buttonToHide);
            buttons.Insert(3, tableConfigurationButtonNewGame);
            buttons.Insert(4, tableConfigurationButtonBackToGame);




            return buttons;
        }

        public static GameObject[,,] CreateButtonGameMenuNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //GameObject[,,] tableButtonNewGame;

            //string tagGameButtonNewGame = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagNewGame();
            //string buttonText = PlayGameCommonButtonsName.GetButtonNameForNewGame();

            //int numberOfDepths = 1;
            //int numberOfRows = 3;
            //int numberOfColumns = 14;

            //string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            //tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            //float newCoordinateY = -1;
            //ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

            //return tableButtonNewGame;

            // new


            string buttonText = PlayGameCommonButtonsName.GetButtonNameForNewGame();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagNewGame();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            //GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //float newCoordinateY = 1f;
            //ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagName);

            string frontTextToAdd = "HelpButtons_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }

        public static void CreateButtonNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonNewGame;

            string tagGameButtonNewGame = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagNewGame();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForNewGame();

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
            //GameObject[,,] tableButtonHelpButtons;

            //string tagGameButtonHelpButtons = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagHelpButtons();
            //string buttonText = PlayGameCommonButtonsName.GetButtonNameForHelpButtons();

            //int numberOfDepths = 1;
            //int numberOfRows = 3;
            //int numberOfColumns = 14;

            //string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            //tableButtonHelpButtons = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            //float newCoordinateY = 2;
            //ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonHelpButtons, newCoordinateY, tagGameButtonHelpButtons);
            // return tableButtonHelpButtons;
            //--- new

            string buttonText = PlayGameCommonButtonsName.GetButtonNameForHelpButtons();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagHelpButtons();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            //GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //float newCoordinateY = 1f;
            //ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagName);

            string frontTextToAdd = "HelpButtons_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
            
        }

        public static GameObject[,,] CreateButtoGameMenuBack(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonBack;

            string tagGameButtonHelpButtons = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuBack();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForGameMenuBack();

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
            //GameObject[,,] tableButtonNewGame;

            //string tagGameButtonNewGame = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagBoardGameHelpText();
            //string buttonText = PlayGameCommonButtonsName.GetButtonNameForBoardText();

            //int numberOfDepths = 1;
            //int numberOfRows = 3;
            //int numberOfColumns = 14;

            //string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            //tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            //float newCoordinateY = 0.5f;
            //ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

            //return tableButtonNewGame;

            // new

            //--- new

            string buttonText = PlayGameCommonButtonsName.GetButtonNameForBoardText();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagBoardGameHelpText();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            //GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //float newCoordinateY = 1f;
            //ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagName);

            string frontTextToAdd = "HelpText_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }

        public static GameObject[,,] CreateButtonGameMenunButtonToHide(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForButtonToHide();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagButtonToHide();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //float newCoordinateY = 1f;
            //ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagName);

            string frontTextToAdd = "ButtonToHide_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }
    }
}
