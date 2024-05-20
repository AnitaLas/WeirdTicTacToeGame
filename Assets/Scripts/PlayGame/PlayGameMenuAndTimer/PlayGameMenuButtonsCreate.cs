using Assets.Scripts;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameMenuButtonsCreate : MonoBehaviour
    {
        public static List<GameObject[,,]> CreateButtonsMenu(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour,Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            List<GameObject[,,]> buttons = new List<GameObject[,,]>();
            List<GameObject[,,]> buttonsMenuMain = new List<GameObject[,,]>();
            List<GameObject[,,]> buttonsMenuMoreSpecificText = new List<GameObject[,,]>();

            //GameObject[,,] tableConfigurationHelpButtons;
            //GameObject[,,] tableConfigurationButtonNewGame;
            //GameObject[,,] tableConfigurationButtonBackToGame;
            //GameObject[,,] tableConfigurationButtonBoarGameHelpText;
            GameObject[,,] buttonHelpStaticText_v2 = CreateButtonGameMenuStaticTextForHelpButtons(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBoarGameHelpButtons = CreateButtonGameMenuHelpButtons(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);


            GameObject[,,] buttonHelpStaticText_v1 = CreateButtonGameMenuStaticTextForHelpBoardText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBoarGameHelpText = CreateButtonGameMenunBoarGameHelpText(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
            

            GameObject[,,] buttonNewGame = CreateButtonGameMenuNewGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);  
            GameObject[,,] buttonBackToGame = CreateButtoGameMenuBackToGame(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
           
            //GameObject[,,] buttonuttonBoarGameHelpText = CreateButtonGameMenunBoarGameHelpText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            
            GameObject[,,] buttonToHide_v1 = CreateButtonGameMenunButtonToHide(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
           // GameObject[,,] buttonToHide_v2 = CreateButtonGameMenunButtonToHide(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);

            //buttonsMenu.Insert(0, tableConfigurationButtonBoarGameHelpText);
            //buttonsMenu.Insert(1, tableConfigurationHelpButtons);
            //buttonsMenu.Insert(2, buttonToHide_v1);
            //buttonsMenu.Insert(3, tableConfigurationButtonNewGame);
            buttonsMenuMoreSpecificText.Insert(0, buttonBoarGameHelpText);
            buttonsMenuMoreSpecificText.Insert(1, buttonBoarGameHelpButtons);

            buttonsMenuMain.Insert(0, buttonHelpStaticText_v1);
            buttonsMenuMain.Insert(1, buttonHelpStaticText_v2);
            buttonsMenuMain.Insert(2, buttonToHide_v1);
            buttonsMenuMain.Insert(3, buttonNewGame);
            //buttonsMenuMain.Insert(4, buttonToHide_v2);
            buttonsMenuMain.Insert(4, buttonBackToGame);

            GameObject gameObjectBase = buttonHelpStaticText_v1[0, 0, 0];
            int numberOfButton = buttonsMenuMain.Count;

            float[] newYForButtons = GameConfigurationButtonsMethods.GetTableWithNewYForGameMenuButtons(gameObjectBase, numberOfButton);

            //GameConfigurationButtonsMethods.ChangeDataForGameMenuButtons(buttonsMenu, newYForButtons);
            //GameConfigurationButtonsMethods.ChangeDataForGameMenuButtons(buttonsMenuMoreSpecificText, newYForButtons);
            GameConfigurationButtonsMethods.ChangeDataForGameMenuButtons(buttonsMenuMain, newYForButtons);

            GameConfigurationButtonsMethods.ChangeDataForGameMenuMoreSpecificText(buttonsMenuMoreSpecificText, newYForButtons);

            GameConfigurationButtonsMethods.ChangeDataForGameMenuButtonToHide(buttonToHide_v1);
            //GameConfigurationButtonsMethods.ChangeDataForGameMenuButtonToHide(buttonToHide_v2);

            buttons.Insert(0, buttonHelpStaticText_v1);
            buttons.Insert(1, buttonBoarGameHelpButtons);
            buttons.Insert(2, buttonHelpStaticText_v2);
            buttons.Insert(3, buttonBoarGameHelpText);
            buttons.Insert(4, buttonToHide_v1);
            buttons.Insert(4, buttonNewGame);
            //buttons.Insert(6, buttonToHide_v2);
            buttons.Insert(5, buttonBackToGame);




            return buttons;
        }


        public static GameObject[,,] CreateButtonGameMenuStaticTextForHelpBoardText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForHelpStaticText();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagBoardGameHelpText();

           // GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonTopForTextInformationGameMenu(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "HelpBoardText_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;

        }

        public static GameObject[,,] CreateButtonGameMenuStaticTextForHelpButtons(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForHelpStaticText();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagHelpButtons();

            //GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonTopForTextInformationGameMenu(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "HelpButton_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;

        }

        public static GameObject[,,] CreateButtonGameMenuNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForNewGame();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagNewGame();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonNewGame_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }

        public static void CreateButtonNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //GameObject[,,] tableButtonNewGame;

            //string tagGameButtonNewGame = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagNewGame();
            //string buttonText = PlayGameCommonButtonsName.GetButtonNameForNewGame();

            //int numberOfDepths = 1;
            //int numberOfRows = 3;
            //int numberOfColumns = 14;

            //string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            //tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            GameObject[,,] button = CreateButtonGameMenuNewGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);

            float newCoordinateY = -4.75f;
            float newCoordinateX = -0.65f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

        }

        public static GameObject[,,] CreateButtonGameMenuHelpButtons(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForHelpButtons();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagHelpButtons();

            //GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateButtonGameMenuForMoreSpecificText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "HelpButtons_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }

        public static GameObject[,,] CreateButtoGameMenuBackToGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForGameMenuBack();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuBack();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "BackToGame_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }

        public static GameObject[,,] CreateButtonGameMenunBoarGameHelpText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {

            string buttonText = PlayGameCommonButtonsName.GetButtonNameForBoardText();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagBoardGameHelpText();

           // GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateButtonGameMenuForMoreSpecificText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "HelpText_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }

        public static GameObject[,,] CreateButtonGameMenunButtonToHide(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForButtonToHide();
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagButtonToHide();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonToHide_v1_or_v2";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }
    }
}
