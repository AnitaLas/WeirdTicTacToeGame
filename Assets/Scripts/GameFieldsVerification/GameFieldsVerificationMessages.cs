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
        public static void WinMessage(string playerSymbol)
        {
            Debug.Log($"{playerSymbol} - You win!");

        }

    }
}
