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
            //Console.WriteLine($"{playerSymbol} - You win!");
        }



        //public static bool WinOrGameOn(string[,] boardToCheck)
        //{
        //    string[,] board = boardToCheck;

        //    bool winner = GameFieldsVerification.FieldsVerification(board);

        //    /*
        //    if (winer == true)
        //    {
        //        Console.WriteLine("You win!");
        //    } 
        //    */
        //    /*
        //    else if (winer == false)
        //    {
        //        Console.WriteLine("You will win next time!");
        //    }
        //    */
        //    return winner;
        //}

 


    }
}
