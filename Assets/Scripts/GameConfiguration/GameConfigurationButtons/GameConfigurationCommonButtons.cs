using Assets.Scripts.Buttons;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationBase
{
    internal class GameConfigurationCommonButtons
    {
        public static GameObject[,,] CreateCommonBattonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesCommon.DictionaryButtonsGameConfigurationCommonButtons();

            string buttonText = buttonsGameNameDictionary[1];
            //string buttonText = "X";

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithGivenString(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            //float newCoordinateY = -4.5f;
            float newCoordinateY = -4.5f;
            float newCoordinateX = 1.75f;

            ButtonsCommonMethods.ChangeDataForSingleCommonButton(tableButtonNewGame, newCoordinateY, newCoordinateX, tagNameDictionary);

            return tableButtonNewGame;

        }

        public static GameObject[,,] CreateCommonBattonBack(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesCommon.DictionaryButtonsGameConfigurationCommonButtons();

            string buttonText = buttonsGameNameDictionary[2];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithGivenString(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.5f;
            float newCoordinateX = -1f;

            ButtonsCommonMethods.ChangeDataForSingleCommonButton(tableButtonNewGame, newCoordinateY, newCoordinateX, tagNameDictionary);

            return tableButtonNewGame;

        }
    }
}
