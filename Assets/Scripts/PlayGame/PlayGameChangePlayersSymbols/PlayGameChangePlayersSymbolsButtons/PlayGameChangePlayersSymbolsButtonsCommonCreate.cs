﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameChangePlayersSymbolsButtonsCommonCreate
    {
        public static GameObject[,,] CreateCommonButtonForChangePlayersSymbolsFourRows(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] button;

            int numberOfDepths = 1;
            int numberOfRows = 4;
            int numberOfColumns = 17;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagNameDictionary);

            float newScale = 0.3f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(button, newScale);

            return button;
        }

        public static GameObject[,,] CreateCommonButtonForChangePlayersSymbolsChange(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] button;

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 16;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagNameDictionary);

            float newScale = 0.25f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(button, newScale);

            return button;
        }

        // button: background - mode: cellphone 
        public static GameObject[,,] CreateCommonButtonForChangePlayersSymbolsButtonForOldAndNewBackground(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] button;

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 17;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagNameDictionary);

            float newScale = 0.25f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(button, newScale);

            return button;
        }

        // button: background - mode: tablet 

        public static GameObject[,,] CreateCommonButtonForChangePlayersSymbolsButtonForOldAndNewBackgroundForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] button;

            int numberOfDepths = 1;
            int numberOfRows = 1;
            int numberOfColumns = 6;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagNameDictionary);

            float newScale = 0.3f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(button, newScale);

            return button;
        }


        public static GameObject[,,] CreateCommonButtonForChangePlayersSymbolsOldAndNewSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] button;

            int numberOfDepths = 1;
            int numberOfRows = 1;
            int numberOfColumns = 1;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            button = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsNumberColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0.25f; // 0 without button gaps

            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(button, newCoordinateY, tagNameDictionary);

            return button;
        }

        public static GameObject[,,] CreateCommonButtonForText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
        {
            GameObject[,,] tableButtonNewGame;

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGameConfiguration(numberOfRows, numberOfColumns, buttonText);

            tableButtonNewGame = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = 0f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(tableButtonNewGame, newCoordinateY, tagNameDictionary);

            float newScale = 0.3f;
            ButtonsCommonMethods.CreatingOneButtonByChangingCoordinatesXYForPrefabCubePlay(tableButtonNewGame, newScale);

            return tableButtonNewGame;
        }
    }
}
