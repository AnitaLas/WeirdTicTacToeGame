using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameChangePlayersSymbolsButtonsCreate
    {
        // buttons: top: player symbols & change

        public static List<GameObject[,,]> GameChangePlayersSymbolsButtonsTopCreate(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, List<float> gameChangeTimeConfiguration, string[] newSymbolsForChande)
        {
            int randomNumberForChange = newSymbolsForChande.Length;
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            float timeForChandeForAll = gameChangeTimeConfiguration[1];

            List<GameObject[,,]> buttons = new List<GameObject[,,]>();

            GameObject[,,] buttonTopPlayerSymbol;
            GameObject[,,] buttonTopPlayersSymbols;
            GameObject[,,] buttonTopChange;

            if (timeForChandeRandomly != 0)
            {
                if (randomNumberForChange == 1)
                {
                    buttonTopPlayerSymbol = PlayGameChangePlayersSymbolsButtonsCreateTopPlayerSymbol(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
                    buttons.Insert(0, buttonTopPlayerSymbol);
                }
                else
                {
                    buttonTopPlayersSymbols = PlayGameChangePlayersSymbolsButtonsCreateTopPlayersSymbols(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
                    buttons.Insert(0, buttonTopPlayersSymbols);
                }
            }

            if (timeForChandeForAll != 0)
            {
                buttonTopPlayersSymbols = PlayGameChangePlayersSymbolsButtonsCreateTopPlayersSymbols(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
                buttons.Insert(0, buttonTopPlayersSymbols);
            }

            buttonTopChange = PlayGameChangePlayersSymbolsButtonCreateTopChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
            buttons.Insert(1, buttonTopChange);

            return buttons;
        }
        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateTopPlayerSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForPlayerSymbol();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 4.35f;
            float newCoordinateX = -0.8f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateTopPlayersSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForPlayersSymbols();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 4.35f;
            float newCoordinateX = -0.8f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonCreateTopChange(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForChange();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 3.9f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateTopSwitchBetweenTeams(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForSwitch();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 3.9f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        //--------------------------------------------------------------------------------------------
        // button - main - information about old symbol and new symbol


        public static List<GameObject[,,]> GameChangePlayersSymbolsButtonsCreate(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, Material[] prefabCubePlayButtonsBackColour, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            int playersNumberForChangeSymbols = newSymbolsForChande.Length;

            List<GameObject[,,]> buttons = new List<GameObject[,,]>();

            if (playersNumberForChangeSymbols <= 6)
                buttons = PlayGameChangePlayersSymbolsButtonsMethods.PlayGameChangePlayersSymbolsCreateFinalButtonsForModeCellphone(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, isGame2D, oldSymbolsForChande, newSymbolsForChande);

            else
                buttons = PlayGameChangePlayersSymbolsButtonsMethods.PlayGameChangePlayersSymbolsCreateFinalButtonsForModeTablet(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, isGame2D, oldSymbolsForChande, newSymbolsForChande);

            return buttons;
        }

        // button: background - mode: cellphone 
        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldAndNewBackground(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForOldAndNew();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsButtonForOldAndNewBackground(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = -1.25f;
            float newCoordinateX = 0.3f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        // button: background - mode: tablet 
        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldAndNewBackgroundForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = "  >";

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsButtonForOldAndNewBackgroundForModeTablet(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = -0.9f;
            float newCoordinateX = 0.2f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = "O";

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsOldAndNewSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            float newCoordinateY = -1.6f;
            float newCoordinateX = -2.35f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForNewSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = "N";

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsOldAndNewSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            float newCoordinateY = -1.6f;
            float newCoordinateX = 0.15f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }
    }
}