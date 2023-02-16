using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameMethods
    {

        public static string GetPlayerSymbol(string[] playersSymbols, int currentPlayer)
        {
            string playerSymbol = playersSymbols[currentPlayer];
            return playerSymbol;
        }


        public static void ChangeCoordinateZForCubePlayAfterClickOnTheCubePlay(GameObject cubePlay)
        {
            float newCoordinateZ = 0;
            CommonMethods.SetUpNewZForGameObject(cubePlay, newCoordinateZ);
        }


       


    }


}
