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

        public static List<GameObject[,,]> CreateConfigurationButtons(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
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

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesCommon.DictionaryTagGame();

            string tagGameButtonNewGame = tagCubePlayDictionary[3];

            string tagGameButtonHelpButtons = tagCubePlayDictionary[4];

            string tagGameButtonMenuBack = tagCubePlayDictionary[5];

            string[] tableWithTextConfigurationHelpButtons = new string[3];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string emptyValue = "";

            tableWithTextConfigurationHelpButtons[0] = "              ";
            tableWithTextConfigurationHelpButtons[1] = " HELP BUTTONS ";
            tableWithTextConfigurationHelpButtons[2] = "              ";

            //string[] tableWithTextConfigurationHelpButtonsEmptyLine = CommonMethods.CreateTableWithGivenLengthAndGivenValue(numberOfColumns, emptyValue);
            //string[] tableWithTextConfigurationHelpButtonsText = ButtonsText.CreateTableWithGivenString(numberOfColumns, emptyValue);


            string[] tableWithTextConfigurationButtonNewGame = new string[3];
            tableWithTextConfigurationButtonNewGame[0] = "              ";
            tableWithTextConfigurationButtonNewGame[1] = "   NEW GAME   ";
            tableWithTextConfigurationButtonNewGame[2] = "              ";

            string[] tableWithTextConfigurationButtonBackToGame = new string[3];
            tableWithTextConfigurationButtonBackToGame[0] = "              ";
            tableWithTextConfigurationButtonBackToGame[1] = "     BACK     ";
            tableWithTextConfigurationButtonBackToGame[2] = "              ";


            tableConfigurationHelpButtons = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextConfigurationHelpButtons);
            tableConfigurationButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextConfigurationButtonNewGame);
            tableConfigurationButtonBackToGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextConfigurationButtonBackToGame);

            float newCoordinateYUp = 2;
            ButtonsCommonMethods.ChangeDataForSingleConfigurationButton(tableConfigurationHelpButtons, newCoordinateYUp, tagGameButtonHelpButtons);

            float newCoordinateYDown = -newCoordinateYUp;
            ButtonsCommonMethods.ChangeDataForSingleConfigurationButton(tableConfigurationButtonBackToGame, newCoordinateYDown, tagGameButtonMenuBack);

            float oldCoordinateY = 0;
            ButtonsCommonMethods.ChangeDataForSingleConfigurationButton(tableConfigurationButtonNewGame, oldCoordinateY, tagGameButtonNewGame);


            //menuButtons[0] = tableConfigurationHelpButtons;
            //menuButtons[1] = tableConfigurationButtonNewGame;
            //menuButtons[2] = tableConfigurationButtonBackToGame;

            //var buttons = new Tuple<GameObject[,,], GameObject[,,], GameObject[,,]>(tableConfigurationHelpButtons, tableConfigurationButtonNewGame, tableConfigurationButtonBackToGame);

            buttons.Insert(0, tableConfigurationHelpButtons);
            buttons.Insert(1, tableConfigurationButtonNewGame);
            buttons.Insert(2, tableConfigurationButtonBackToGame);

            return buttons;
        }


        public static void CreateNewGameButton(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableConfigurationButtonNewGame;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesCommon.DictionaryTagGame();

            string tagGameButtonNewGame = tagCubePlayDictionary[3];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string emptyValue = "";
            string buttonText = "NEW GAME";
            //string[] tableWithTextConfigurationButtonNewGame = new string[3];
            //tableWithTextConfigurationButtonNewGame[0] = "              ";
            //tableWithTextConfigurationButtonNewGame[1] = "   NEW GAME   ";
            //tableWithTextConfigurationButtonNewGame[2] = "              ";

            string[] tableWithTextForButtonNewGameEmptyLine = CommonMethods.CreateTableWithGivenLengthAndGivenValue(numberOfColumns, emptyValue);
            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithGivenString(numberOfColumns, buttonText);

            List<string[]> listForButtonNewGame = new List<string[]>();

            listForButtonNewGame.Insert(0, tableWithTextForButtonNewGameEmptyLine);
            listForButtonNewGame.Insert(1, tableWithTextForButtonNewGame);

            tableConfigurationButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton2(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, listForButtonNewGame);
       
            float newCoordinateY = -4;
            ButtonsCommonMethods.ChangeDataForSingleConfigurationButton(tableConfigurationButtonNewGame, newCoordinateY, tagGameButtonNewGame);

        }





        /*
        public static GameObject[,,] CreateConfigurationButtonHide(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 12;

            string[] textForHelpButtonLines = new string[3];
            textForHelpButtonLines[0] = "    HIDE    ";
            textForHelpButtonLines[1] = "            ";
            textForHelpButtonLines[2] = "HELP BUTTONS";

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);

            return tableWithNumber;

        }
        +/

        /*
        public static GameObject[,,] CreateConfigurationButtonShow(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 12;

            string[] textForHelpButtonLines = new string[3];
            textForHelpButtonLines[0] = "    SHOW    ";
            textForHelpButtonLines[1] = "            ";
            textForHelpButtonLines[2] = "HELP BUTTONS";

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }
        */

        /*
        public static GameObject[,,] CreateConfigurationButtonNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 12;

            string[] textForHelpButtonLines = new string[3];
            textForHelpButtonLines[0] = "            ";
            textForHelpButtonLines[1] = "  NEW GAME  ";
            textForHelpButtonLines[2] = "            ";

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }
        */

        /*
        public static GameObject[,,] CreateConfigurationButtonBackToGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 12;

            string[] textForHelpButtonLines = new string[3];
            textForHelpButtonLines[0] = "    BACK    ";
            textForHelpButtonLines[1] = "            ";
            textForHelpButtonLines[2] = "   TO GAME  ";

            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns, textForHelpButtonLines);
            tableWithNumber = CreateTableMainMethods.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);


            return tableWithNumber;

        }
        */
     

    }
}
