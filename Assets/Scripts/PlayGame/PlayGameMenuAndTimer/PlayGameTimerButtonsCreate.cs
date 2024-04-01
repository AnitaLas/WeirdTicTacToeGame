using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameTimerButtonsCreate : MonoBehaviour
    {
        public static List<GameObject> GameTimerButtonsCreate(GameObject prefabTimer)
        {
            // buttons with text
            GameObject battonTimerForBoardGame = PlayGameTimerButtonsCreateSingleButtonCountdownSecondsForBoardGame(prefabTimer);           
            GameObject battonTimerForPlayers = PlayGameTimerButtonsCreateSingleButtonCountdownSecondsForChangePlayersSymbols(prefabTimer);           

            List<GameObject> buttonsAll = new List<GameObject>();
            buttonsAll.Insert(0, battonTimerForBoardGame);
            buttonsAll.Insert(1, battonTimerForPlayers);

            PlayGameMenuAndTimerButtonsActions.HideObjectPlayerSymbolPrevious();
            //PlayGameMenuAndTimerButtonsActions.HideTimerForGameBoard();
            PlayGameMenuAndTimerButtonsActions.HideTimerForChangePlayersSymbols();
            //PlayGameMenuAndTimerButtonsActions.UnhideTimerForChangePlayersSymbols();
            //PlayGameMenuAndTimerButtonsActions.ShowTimerFoGameBoard();
            return buttonsAll;
        }

        public static GameObject PlayGameTimerButtonsCreateSingleButtonCountdownSeconds(GameObject prefabTimer)
        {
            GameObject timer = Instantiate(prefabTimer);
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForPlayers();
            return timer;
        }

        public static GameObject PlayGameTimerButtonsCreateSingleButtonCountdownSecondsForBoardGame(GameObject prefabTimer)
        {
            GameObject timer = PlayGameTimerButtonsCreateSingleButtonCountdownSeconds(prefabTimer);

            float newCoordinateY = 4.75f;
            float newCoordinateX = -1f;
            float newCoordinateZ = 0.1f;
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForBoardGame();
            ChangeDataForTimer(timer, tagName, newCoordinateZ, newCoordinateY, newCoordinateX);
            return timer;

        }

        public static GameObject PlayGameTimerButtonsCreateSingleButtonCountdownSecondsForChangePlayersSymbols(GameObject prefabTimer)
        {
            GameObject timer = PlayGameTimerButtonsCreateSingleButtonCountdownSeconds(prefabTimer);

            float newCoordinateY = 3.75f;
            float newCoordinateX = 1f;
            float newCoordinateZ = 0.1f;
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForPlayers();
            ChangeDataForTimer(timer, tagName, newCoordinateZ, newCoordinateY, newCoordinateX);
            return timer;

        }

        public static void ChangeDataForTimer(GameObject timer, string tagName, float newCoordinateZ, float newCoordinateY, float newCoordinateX)
        {
            GameCommonMethodsSetUpCoordinates.ChangeXForGameObject(timer, newCoordinateX);
            GameCommonMethodsSetUpCoordinates.ChangeYForGameObject(timer, newCoordinateY);
            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(timer, newCoordinateZ);
            CommonMethods.ChangeTagForGameObject(timer, tagName);

        }
















        // new class for other buttons
        // -------------------------------------------------------------------------------------------
        // buttons: top: player symbols & change
        public static GameObject[,,] PlayGameTimerButtonsCreateButtonTopPlayerSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForPlayerSymbol();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopPlayersSymbols_";
            float newCoordinateY = 4f;
            float newCoordinateX = -0.8f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] PlayGameTimerButtonsCreateButtonTopPlayersSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForPlayersSymbols();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopPlayersSymbols_";
            float newCoordinateY = 4f;
            float newCoordinateX = -0.8f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] PlayGameTimerButtonsCreateButtonTopChange(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForChange();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = 3.55f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] PlayGameTimerButtonsCreateButtonTopSwitchBetweenTeams(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForSwitch();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = 3.55f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        // button - main - information about old symbol and new symbol

        public static GameObject[,,] PlayGameTimerButtonsCreateSingleButtonForOldAndNew(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = PlayGameCommonButtonsName.GetButtonNameForOldAndNew();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = 3.55f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }



    }
}
