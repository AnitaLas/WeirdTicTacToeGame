using UnityEngine;

namespace Assets.Scripts
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
