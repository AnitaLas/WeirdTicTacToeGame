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

        public static List<GameObject[,,]> GameChangePlayersSymbolsButtonsTopCreate(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, List<float> gameChangeTimeConfiguration, string[] newPlayersSymbols)
        {
            int playersNumber = newPlayersSymbols.Length;
            //int randomNumberForChange = PlayGameChangePlayersSymbolsComnonMethods.GetRandomNumberPlayersToChangeSymbols(playerSymbolMove);
            int randomNumberForChange = 2;
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            float timeForChandeForAll = gameChangeTimeConfiguration[1];
            //float timeForSwitchBetweenTeams = gameChangeTimeConfiguration[2];

            //PlayGameChangePlayersSymbolsComnonMethods.GetNewPlayersSymbols(playersSymbols);


            //-------------------------------------------------------
            List<GameObject[,,]> buttons = new List<GameObject[,,]>();

            GameObject[,,] buttonTopPlayerSymbol;
            GameObject[,,] buttonTopPlayersSymbols;
            GameObject[,,] buttonTopChange;
            //GameObject[,,] buttonTopSwitchBetweenTeams;

            
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
                //button
                buttonTopPlayersSymbols = PlayGameChangePlayersSymbolsButtonsCreateTopPlayersSymbols(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
                buttons.Insert(0, buttonTopPlayersSymbols);



            }


            buttonTopChange = PlayGameChangePlayersSymbolsButtonCreateTopChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
            //buttonTopSwitchBetweenTeams = PlayGameTimerButtonsCreateButtonTopSwitchBetweenTeams(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);


            buttons.Insert(1, buttonTopChange);


            //buttons.Insert(3, buttonTopSwitchBetweenTeams);

            return buttons;
        }
        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateTopPlayerSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForPlayerSymbol();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopPlayersSymbols_";
            float newCoordinateY = 4f;
            float newCoordinateX = -0.8f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateTopPlayersSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForPlayersSymbols();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopPlayersSymbols_";
            float newCoordinateY = 4f;
            float newCoordinateX = -0.8f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonCreateTopChange(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForChange();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = 3.55f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateTopSwitchBetweenTeams(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForSwitch();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = 3.55f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }


        //--------------------------------------------------------------------------------------------
        // button - main - information about old symbol and new symbol


        public static List<GameObject[,,]> GameChangePlayersSymbolsButtonsCreate(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, List<float> gameChangeTimeConfiguration, string[] playersSymbols, string[] newPlayersSymbols)
        {
            int playersNumberForChangeSymbols = newPlayersSymbols.Length;
            //Debug.Log("playersNumberForChangeSymbols: " + playersNumberForChangeSymbols);
            List<GameObject[,,]> buttons = new List<GameObject[,,]>();


            if (playersNumberForChangeSymbols <= 6)             
            {
                //Debug.Log(" test ");

                buttons = PlayGameChangePlayersSymbolsButtonsMethods.PlayGameChangePlayersSymbolsCreateFinalButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, isGame2D, playersSymbols, newPlayersSymbols);
            
            
            
            
            }
            else
            {


            }

            


            return buttons;
        }


        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldAndNewBackground(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForOldAndNew();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsButtonForOldAndNewBackground(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = -1.25f;
            float newCoordinateX = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, string[] playersSymbols)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = "O";

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsOldAndNewSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = -1.6f;
            float newCoordinateX = -2.45f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForNewSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = "N";

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsOldAndNewSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = -1.6f;
            float newCoordinateX = -0.25f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

    }
}
