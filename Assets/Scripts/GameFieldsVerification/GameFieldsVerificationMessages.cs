using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

namespace Assets.Scripts.GameFieldsVerification
{
    internal class GameFieldsVerificationMessages
    {
        public static void MessageWin(string playerSymbol)
        {
            Debug.Log($"{playerSymbol} - You win!");
            Debug.Log(" --------------------  ");


        }

        public static void MessageGameOver()
        {
            Debug.Log("Game Over :) Would you like to start new game? Yes No");
        }

        public static void MessageCubePlayTaken()
        {
            Debug.Log("CubePlay has already been taken by another player.");
        }
    

    }
}
