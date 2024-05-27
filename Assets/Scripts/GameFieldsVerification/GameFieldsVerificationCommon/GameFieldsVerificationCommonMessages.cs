using UnityEngine;

namespace Assets.Scripts
{
    internal class GameFieldsVerificationCommonMessages
    {
        public static void MessageWin(string playerSymbol)
        {
            Debug.Log($"{playerSymbol} - You win!");
            //Debug.Log(" --------------------  ");
        }

        public static void MessageGameOver()
        {
            Debug.Log("Game Over :) Start new game");
        }

        public static void MessageCubePlayTaken()
        {
            Debug.Log("CubePlay has already been taken by another player.");
        }
    }
}
