using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameSwitchPlayersSymbolsButtonsCreate
    {
        // buttons: top: player symbols & change

        public static List<GameObject[,,]> GameSwitchPlayersSymbolsButtonsTopCreate(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            List<GameObject[,,]> buttons = new List<GameObject[,,]>();

            GameObject[,,] buttonTopPlayersSymbols = PlayGameSwitchPlayersSymbolsButtonsCreateTopPlayersSymbols(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonTopSwitch = PlayGameSwitchlayersSymbolsButtonCreateTopChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);

            buttons.Insert(0, buttonTopPlayersSymbols);
            buttons.Insert(1, buttonTopSwitch);

            return buttons;
        }


        public static GameObject[,,] PlayGameSwitchPlayersSymbolsButtonsCreateTopPlayersSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForPlayersSymbols();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopPlayersSymbols_";
            float newCoordinateY = 4.35f;
            float newCoordinateX = -0.8f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] PlayGameSwitchlayersSymbolsButtonCreateTopChange(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameSwitchBetweenTeamsForInformation();

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = 3.9f;
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
            float newCoordinateY = 3.9f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }


        //--------------------------------------------------------------------------------------------
        // button - main - information about old symbol and new symbol
        public static int GetNumbersForCountedSymbolsToChange(List<string[]> teams)
        {
            int playersNumbers = 0;
            int teamsNumbers = teams.Count;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teams[i];
                int symbolsNumbers = teamSymbols.Length;
                playersNumbers = playersNumbers + symbolsNumbers;
            }
            
            return playersNumbers;
        }


        public static List<GameObject[,,]> GameSwitchPlayersSymbolsButtonsCreate(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, Material[] prefabCubePlayButtonsBackColour, ArrayList newDataForPlayersSymbolsSwitch)
        {
            List<string[]> teamsSymbolsForSwitch = (List<string[]>)newDataForPlayersSymbolsSwitch[1];
            //string[] team1 = teams[0];
            //int teamsNumbers = teams.Count;
            //int playersNumbers = team1.Length;
            //int playersNumberForChangeSymbols = teamsNumbers * playersNumbers;
            int playersNumberForChangeSymbols = GetNumbersForCountedSymbolsToChange(teamsSymbolsForSwitch);
            //Debug.Log("playersNumberForChangeSymbols: " + playersNumberForChangeSymbols);
            List<GameObject[,,]> buttons = new List<GameObject[,,]>();


            if (playersNumberForChangeSymbols <= 6)             
            {
                //Debug.Log(" test ");

                //buttons = PlayGameChangePlayersSymbolsButtonsMethods.PlayGameChangePlayersSymbolsCreateFinalButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, isGame2D, oldSymbolsForChande, newSymbolsForChande);
                buttons = PlayGameSwitchPlayersSymbolsButtonsMethods.PlayGameSwitchPlayersSymbolsCreateFinalButtonsForModeCellphone(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, isGame2D, newDataForPlayersSymbolsSwitch, playersNumberForChangeSymbols);




            }
            else
            {
                //Debug.Log("Upss it does not implemented yet, sorry :( ");

                buttons = PlayGameSwitchPlayersSymbolsButtonsMethods.PlayGameSwitchPlayersSymbolsCreateFinalButtonsForModeTablet(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, isGame2D, newDataForPlayersSymbolsSwitch, playersNumberForChangeSymbols);


            }




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
            //string buttonText = PlayGameCommonButtonsName.GetButtonNameForOldAndNew();
            string buttonText = "  >";

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsButtonForOldAndNewBackgroundForModeTablet(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = -0.9f;
            float newCoordinateX = 0.2f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = "O";

            GameObject[,,] button = PlayGameChangePlayersSymbolsButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsOldAndNewSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = -1.6f;
            float newCoordinateX = -2.35f;
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
            float newCoordinateX = 0.15f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }




    }
}
