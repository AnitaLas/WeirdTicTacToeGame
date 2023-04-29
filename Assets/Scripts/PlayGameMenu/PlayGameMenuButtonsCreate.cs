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
    internal class PlayGameMenuButtonsCreate : MonoBehaviour
    {

        public static List<GameObject[,,]> CreateButtonsMenu(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            List<GameObject[,,]> buttons = new List<GameObject[,,]>();

            GameObject[,,] tableConfigurationHelpButtons;
            GameObject[,,] tableConfigurationButtonNewGame;
            GameObject[,,] tableConfigurationButtonBackToGame;

            tableConfigurationHelpButtons = CreateButtonGameMenuHelpButtons(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            tableConfigurationButtonNewGame = CreateButtonGameMenuNewGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            tableConfigurationButtonBackToGame = CreateButtoGameMenuBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            buttons.Insert(0, tableConfigurationHelpButtons);
            buttons.Insert(1, tableConfigurationButtonNewGame);
            buttons.Insert(2, tableConfigurationButtonBackToGame);

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

            //string buttonText = "NEW GAME";

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);
            //ButtonsCommonMethods.ChangeDataForSingleCommonButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

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

            //string buttonText = "NEW GAME";

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);
            //ButtonsCommonMethods.ChangeDataForSingleCommonButtons(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

            //return tableButtonNewGame;


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

            //string buttonText = "HELP BUTTONS";

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonHelpButtons = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);
       
            float newCoordinateY = 2;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonHelpButtons, newCoordinateY, tagGameButtonHelpButtons);
            //ButtonsCommonMethods.ChangeDataForSingleCommonButtons(tableButtonHelpButtons, newCoordinateY, tagGameButtonHelpButtons);

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

            //float newCoordinateY = -2;
            float newCoordinateY = -4.75f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonBack, newCoordinateY, tagGameButtonHelpButtons);

            return tableButtonBack;
        }











    }
}
