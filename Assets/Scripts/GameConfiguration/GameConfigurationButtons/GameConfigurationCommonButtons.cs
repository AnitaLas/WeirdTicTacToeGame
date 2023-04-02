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
        public static GameObject[,,] CreateButtonGameMenuNewGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableButtonNewGame;

            Dictionary<int, string> tagNameDictionary = GameDictionariesCommon.DictionaryTagConfigurationBoardGame();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesCommon.DictionaryButtonsGameConfigurationCommonButtons();

            string tagGameButtonNewGame = tagNameDictionary[1];
            string buttonText = buttonsGameNameDictionary[1];

            int numberOfDepths = 1;
            int numberOfRows = 1;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithGivenString(numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -3.7f;
            ButtonsCommonMethods.ChangeDataForSingleCommonButtonsXxx2(tableButtonNewGame, newCoordinateY, tagGameButtonNewGame);

            return tableButtonNewGame;

        }
    }
}
