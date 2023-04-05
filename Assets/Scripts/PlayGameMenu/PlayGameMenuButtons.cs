using Assets.Scripts.Buttons;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PlayGame
{
    internal class PlayGameMenuButtons : MonoBehaviour
    {

        public static List<GameObject[,,]> CreateButtonsMenu(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {

            // CreateConfigurationButtonHide(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            // GameObject[,,] tableConfigurationButtonShow = CreateConfigurationButtonShow(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            // GameObject[,,] tableConfigurationButtonNewGame = CreateConfigurationButtonNewGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            //  GameObject[,,] tableConfigurationButtonBackToGame = CreateConfigurationButtonBackToGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            //GameObject[] menuButtons = new GameObject[3];

            List<GameObject[,,]> buttons = new List<GameObject[,,]>();

            GameObject[,,] tableConfigurationHelpButtons;
            GameObject[,,] tableConfigurationButtonNewGame;
            GameObject[,,] tableConfigurationButtonBackToGame;

            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesCommon.DictionaryTagGame();

            //string tagGameButtonNewGame = tagCubePlayDictionary[3];

            //string tagGameButtonHelpButtons = tagCubePlayDictionary[4];

            //string tagGameButtonMenuBack = tagCubePlayDictionary[5];

            //string[] tableWithTextConfigurationHelpButtons = new string[3];

            //int numberOfDepths = 1;
            //int numberOfRows = 3;
            //int numberOfColumns = 14;

            //string emptyValue = "";

            //tableWithTextConfigurationHelpButtons[0] = "              ";
            //tableWithTextConfigurationHelpButtons[1] = " HELP BUTTONS ";
            //tableWithTextConfigurationHelpButtons[2] = "              ";

            //string[] tableWithTextConfigurationHelpButtonsEmptyLine = CommonMethods.CreateTableWithGivenLengthAndGivenValue(numberOfColumns, emptyValue);
            //string[] tableWithTextConfigurationHelpButtonsText = ButtonsText.CreateTableWithGivenString(numberOfColumns, emptyValue);


            //string[] tableWithTextConfigurationButtonNewGame = new string[3];
            //tableWithTextConfigurationButtonNewGame[0] = "              ";
            //tableWithTextConfigurationButtonNewGame[1] = "   NEW GAME   ";
            //tableWithTextConfigurationButtonNewGame[2] = "              ";

            //string[] tableWithTextConfigurationButtonBackToGame = new string[3];
            //tableWithTextConfigurationButtonBackToGame[0] = "              ";
            //tableWithTextConfigurationButtonBackToGame[1] = "     BACK     ";
            //tableWithTextConfigurationButtonBackToGame[2] = "              ";


            tableConfigurationHelpButtons = CreateButtonGameMenuHelpButtons(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            tableConfigurationButtonNewGame = CreateButtonGameMenuNewGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            tableConfigurationButtonBackToGame = CreateButtoGamenMenuBack(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);

            //float newCoordinateYUp = 2;
            //ButtonsCommonMethods.ChangeDataForSingleConfigurationButton(tableConfigurationHelpButtons, newCoordinateYUp, tagGameButtonHelpButtons);

            //float newCoordinateYDown = -newCoordinateYUp;
            //ButtonsCommonMethods.ChangeDataForSingleConfigurationButton(tableConfigurationButtonBackToGame, newCoordinateYDown, tagGameButtonMenuBack);

            //float oldCoordinateY = 0;
            //ButtonsCommonMethods.ChangeDataForSingleConfigurationButton(tableConfigurationButtonNewGame, oldCoordinateY, tagGameButtonNewGame);


            //menuButtons[0] = tableConfigurationHelpButtons;
            //menuButtons[1] = tableConfigurationButtonNewGame;
            //menuButtons[2] = tableConfigurationButtonBackToGame;

            //var buttons = new Tuple<GameObject[,,], GameObject[,,], GameObject[,,]>(tableConfigurationHelpButtons, tableConfigurationButtonNewGame, tableConfigurationButtonBackToGame);

            buttons.Insert(0, tableConfigurationHelpButtons);
            buttons.Insert(1, tableConfigurationButtonNewGame);
            buttons.Insert(2, tableConfigurationButtonBackToGame);

            return buttons;
        }

        public static GameObject[,,] CreateButtonGameMenuNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesCommon.DictionaryTagGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesCommon.DictionaryButtonsGameName();

            string tagGameButtonNewGame = tagCubePlayDictionary[3];
            string buttonText = buttonsGameNameDictionary[1];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            //string buttonText = "NEW GAME";

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithGivenString(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);
            //ButtonsCommonMethods.ChangeDataForSingleCommonButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

            return tableButtonNewGame;

        }

        public static void CreateButtonNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesCommon.DictionaryTagGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesCommon.DictionaryButtonsGameName();

            string tagGameButtonNewGame = tagCubePlayDictionary[3];
            string buttonText = buttonsGameNameDictionary[1];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            //string buttonText = "NEW GAME";

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithGivenString(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);
            //ButtonsCommonMethods.ChangeDataForSingleCommonButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

            //return tableButtonNewGame;


        }

        public static GameObject[,,] CreateButtonGameMenuHelpButtons(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonHelpButtons;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesCommon.DictionaryTagGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesCommon.DictionaryButtonsGameName();

            string tagGameButtonHelpButtons = tagCubePlayDictionary[4];
            string buttonText = buttonsGameNameDictionary[3];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            //string buttonText = "HELP BUTTONS";

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithGivenString(numberOfRows, numberOfColumns, buttonText);

            tableButtonHelpButtons = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);
       
            float newCoordinateY = 2;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonHelpButtons, newCoordinateY, tagGameButtonHelpButtons);
            //ButtonsCommonMethods.ChangeDataForSingleCommonButtons(tableButtonHelpButtons, newCoordinateY, tagGameButtonHelpButtons);

            return tableButtonHelpButtons;
        }


        public static GameObject[,,] CreateButtoGamenMenuBack(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonHelpButtons;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesCommon.DictionaryTagGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesCommon.DictionaryButtonsGameName();

            string tagGameButtonHelpButtons = tagCubePlayDictionary[5];
            string buttonText = buttonsGameNameDictionary[2];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            //string buttonText = "BACK";

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithGivenString(numberOfRows, numberOfColumns, buttonText);

            tableButtonHelpButtons = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -2;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonHelpButtons, newCoordinateY, tagGameButtonHelpButtons);
            //ButtonsCommonMethods.ChangeDataForSingleCommonButtons(tableButtonHelpButtons, newCoordinateY, tagGameButtonHelpButtons);

            return tableButtonHelpButtons;
        }











    }
}
