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
            GameObject battonTimerForBoardGame = PlayGameTimerButtonsCreateSingleButtonCountdownSecondsForBoardGame(prefabTimer);           
            GameObject battonTimerForPlayers = PlayGameTimerButtonsCreateSingleButtonCountdownSecondsForChangePlayersSymbols(prefabTimer);           

            List<GameObject> buttonsAll = new List<GameObject>();
            buttonsAll.Insert(0, battonTimerForBoardGame);
            buttonsAll.Insert(1, battonTimerForPlayers);

            PlayGameMenuAndTimerButtonsActions.HideObjectPlayerSymbolPrevious();
            PlayGameMenuAndTimerButtonsActions.HideTimerForChangePlayersSymbols();
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

            float newCoordinateY = 3.25f;
            float newCoordinateX = 1.25f;
            float newCoordinateZ = 0f;
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

    }
}
