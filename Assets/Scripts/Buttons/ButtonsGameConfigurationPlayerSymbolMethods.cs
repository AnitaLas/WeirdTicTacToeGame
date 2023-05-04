using Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers;
using Assets.Scripts.GameConfiguration.GameConfigurationButtonsCommon;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Buttons
{
    internal class ButtonsGameConfigurationPlayerSymbolMethods
    {
        // --- button name "PLAYER 1"
        public static GameObject[,,] GameConfigurationPlayerSymbolCreateOneButtonForPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, string buttonText)
        {

            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return buttonBack;
        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolAllCreateButtonsForPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, int playersNumber, string[] defaultTextForButtons)
        {
            string finalTextForButton;

            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            for (int i = 0; i < playersNumber; i++)
            {
                finalTextForButton = defaultTextForButtons[i];
                GameObject[,,] buttonBack = GameConfigurationPlayerSymbolCreateOneButtonForPlayerNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, finalTextForButton);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }

        // --- button with symbol "X"
        public static GameObject[,,] GameConfigurationPlayerSymbolCreateOneButtonForPlayerSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, string buttonText)
        {

            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonForSymbol(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return buttonBack;
        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolAllCreateButtonsForPlayerSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagName, int playersNumber, string[] defaultTextForButtons)
        {
            string finalTextForButton;

            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            for (int i = 0; i < playersNumber; i++)
            {
                finalTextForButton = defaultTextForButtons[i];
                GameObject[,,] buttonBack = GameConfigurationPlayerSymbolCreateOneButtonForPlayerSymbol(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, finalTextForButton);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }
    }
}
