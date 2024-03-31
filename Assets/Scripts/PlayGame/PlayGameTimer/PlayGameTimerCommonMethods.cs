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

    }
}
