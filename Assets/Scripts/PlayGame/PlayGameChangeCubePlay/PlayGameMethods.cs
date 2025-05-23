﻿using Assets.Scripts;
using System.Collections.Generic;
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
            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
        }

        public static void DisactivateChosenCubePlay(GameObject cubePlayMarkByFrame)
        {
            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            //string tagCubePlayTaken = tagCubePlayDictionary[2];
            string tagCubePlayTaken = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagTaken();
            GameCommonMethodsMain.ChangeTagForGameObject(cubePlayMarkByFrame, tagCubePlayTaken);
        }

        public static void DisactivateChosenCubePlay(RaycastHit touch)
        {
            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            //string tagCubePlayTaken = tagCubePlayDictionary[2];
            string tagCubePlayTaken = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagTaken();
            GameCommonMethodsMain.ChangeTagForGameObject(touch, tagCubePlayTaken);
        }
    }
}
