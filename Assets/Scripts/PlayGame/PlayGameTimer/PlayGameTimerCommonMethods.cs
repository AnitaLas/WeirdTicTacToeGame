using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayGame.PlayGameTimer
{
    internal class PlayGameTimerCommonMethods
    {
        //List<float> gameChangeTime;
        //gameChangeTime.Insert(0, );

        public static bool IsTimerActivate(float _timeForChandeRandomly, float _timeForChandeForAll, float _timeForSwitchBetweenTeams)
        {
            bool isActive;

            if (_timeForChandeRandomly != 0 || _timeForChandeForAll != 0 || _timeForSwitchBetweenTeams != 0)
                isActive = true;  
            else
                isActive = false;

            return isActive;
        }

        public static bool TurnOffTimer()
        {
            Debug.Log("test 11");
            return false;
        }


        public static bool TurnOnTimer()
        {
            Debug.Log("test 222");
            return true;
        }

        public static float[] SetupTimer(List<float> gameChangeTimeConfiguration)
        {
            float timeForChandeRandomly = gameChangeTimeConfiguration[0];
            float timeForChandeForAll = gameChangeTimeConfiguration[1];
            float timeForSwitchBetweenTeams = gameChangeTimeConfiguration[2];
            float timeForUnhidePlayGameElements = gameChangeTimeConfiguration[3];

            float[] timeForHidePlayGameElements = new float[3]; // 3 = _timeForChandeRandomly or _timeForChandeForAll + _timeForSwitchBetweenTeams + timeForHidePlayGameElements

            if (timeForChandeRandomly != 0)
                timeForHidePlayGameElements[0] = timeForChandeRandomly;
            else
                timeForHidePlayGameElements[0] = timeForChandeForAll;

            timeForHidePlayGameElements[1] = timeForSwitchBetweenTeams;
            timeForHidePlayGameElements[2] = timeForUnhidePlayGameElements;

            return timeForHidePlayGameElements;
        }


        public static void CountdownSeconds(float _timeForUnhidePlayGameElements, string tagName)
        {
           
            GameObject timer = CommonMethods.GetObjectByTagName(tagName);

            _timeForUnhidePlayGameElements -= 1 * Time.deltaTime;

            if (_timeForUnhidePlayGameElements > 0)
            {
                //CommonMethods.ChangeTextForCubePlay(timer, _timeForUnhidePlayGameElements.ToString("0"));
                GameCommonMethodsMain.ChangeTextForFirstChild(timer, _timeForUnhidePlayGameElements.ToString("0"));
            }
        }

        public static void CountdownSecondsForChangePlayersSymbols(float timeCountdown)
        {
            string objectTagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForPlayers();
            //Debug.Log("test");
            CountdownSeconds(timeCountdown, objectTagName);
        }

        public static void CountdownSecondsForBoarGame(float timeCountdown)
        {
            string objectTagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForBoardGame();
            CountdownSeconds(timeCountdown, objectTagName);
        }

        public static void SetUpDefaultSymbolForTimerAferWin()
        {
            string defaultSymbol = "-";
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagInformationTimerForBoardGame();
            GameObject timer = CommonMethods.GetObjectByTagName(tagName);
            GameCommonMethodsMain.ChangeTextForFirstChild(timer, defaultSymbol);
        }

    }
}
