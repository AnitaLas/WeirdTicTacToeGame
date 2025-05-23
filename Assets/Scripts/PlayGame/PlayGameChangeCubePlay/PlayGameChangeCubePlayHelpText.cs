﻿using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameChangeCubePlayHelpText
    {
        public static bool ChangeBoarGameHelpTextVisibility(GameObject[,,] boardGame, string[] playersSymbols, bool isBoarGameHelpTextVisible)
        {
            if (isBoarGameHelpTextVisible == true)
            {
                ChangeBoarGameHelpTextToInvisible(boardGame, playersSymbols);
                return false;
            }
            else
            {
                ChangeBoarGameHelpTextToVisible(boardGame, playersSymbols);
                return true;
            }
        }

        public static void ChangeBoarGameHelpTextToInvisible(GameObject[,,] boardGame, string[] playersSymbols)
        {
            int dictionaryColorId = 4;
            Color textColour = GameCommonMethodsMain.GetNewColor(dictionaryColorId);
            ChangeCubePlayTextVisibility(boardGame, playersSymbols, textColour);
        }

        public static void ChangeBoarGameHelpTextToVisible(GameObject[,,] boardGame, string[] playersSymbols)
        {
            int dictionaryColorId = 3;
            Color textColour = GameCommonMethodsMain.GetNewColor(dictionaryColorId);
            ChangeCubePlayTextVisibility(boardGame, playersSymbols, textColour);
        }

        public static void ChangeCubePlayTextVisibility(GameObject[,,] boardGame, string[] playersSymbols, Color textColour)
        {
            int dictionaryColorId = 2;
            Color defaultColour = GameCommonMethodsMain.GetNewColor(dictionaryColorId);

            int maxIndexDepth = boardGame.GetLength(0);
            int maxIndexColumn = boardGame.GetLength(2);
            int maxIndexRow = boardGame.GetLength(1);
            int playersNumber = playersSymbols.Length;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = boardGame[indexDepth, indexRow, indexColumn];
                        string cubePlayText = GameCommonMethodsMain.GetCubePlayText(cubePlay);

                        GameCommonMethodsMain.ChangeTextColourForCubePlay(cubePlay, textColour);

                        for (int player = 0; player < playersNumber; player++)
                        {
                            string playerSymbol = playersSymbols[player];

                            if (cubePlayText == playerSymbol)
                            {
                                GameCommonMethodsMain.ChangeTextColourForCubePlay(cubePlay, defaultColour);
                            }
                        }
                    }
                }
            }
        }
    }
}
