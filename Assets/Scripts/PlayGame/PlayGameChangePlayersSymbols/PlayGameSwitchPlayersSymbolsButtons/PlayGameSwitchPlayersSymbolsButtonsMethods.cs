using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    internal class PlayGameSwitchPlayersSymbolsButtonsMethods
    {

        public static string[] GetSymbolsAsOneTable(List<string[]> teamsSymbols, int playersNumberForChangeSymbols)
        {
            string[] symbols = new string[playersNumberForChangeSymbols];
            int teamsNumbers = teamsSymbols.Count;
            int index = 0;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamsSymbols[i];
                int playersNumbers = teamSymbols.Length;

                for (int j = 0; j < playersNumbers; j++)
                {
                    string teamSymbol = teamSymbols[j];
                    symbols[index] = teamSymbol;
                    index++;
                }
            }


            return symbols;
        }

        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateFinalButtonsForModeCellphone(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D, ArrayList newDataForPlayersSymbolsSwitch, int playersNumberForChangeSymbols)
        {
            List<string[]> oldTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[0];
            List<string[]> newTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[1];

            string[] oldSymbolsForSwitch = GetSymbolsAsOneTable(oldTeamsSymbols, playersNumberForChangeSymbols);
            string[] newSymbolsForSwitch = GetSymbolsAsOneTable(newTeamsSymbols, playersNumberForChangeSymbols);

            List<GameObject[,,]> buttonsBackground = PlayGameSwitchPlayersSymbolsCreateButtonsBackgroundFinal(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumberForChangeSymbols);
            List<GameObject[,,]> buttonsOldSymbols = PlayGameSwitchPlayersSymbolsCreateButtonsOldSymbolsFinal(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, playersNumberForChangeSymbols, oldSymbolsForSwitch);
            List<GameObject[,,]> buttonsNewSymbols = PlayGameSwitchPlayersSymbolsCreateButtonsNewSymbolsFinal(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols, newSymbolsForSwitch);

            List<List<GameObject[,,]>> buttonsLists = new List<List<GameObject[,,]>>();

            buttonsLists.Insert(0, buttonsBackground);
            buttonsLists.Insert(1, buttonsOldSymbols);
            buttonsLists.Insert(2, buttonsNewSymbols);

            List<GameObject[,,]> buttonsFinalList = new List<GameObject[,,]>();

            int listNumber = buttonsLists.Count;
            int index = 0;

            for (int i = 0; i < listNumber; i++)
            {
                List<GameObject[,,]> list = buttonsLists[i];
                int number = list.Count;

                for (int j = 0; j < number; j++)
                {
                    buttonsFinalList.Insert(index, list[j]);
                    index++;
                }
            }

            return buttonsFinalList;
        }

        // battons background: with text old and new
        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateButtonsBackground(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            for (int i = 0; i < playersNumberForChangeSymbols; i++)
            {
                GameObject[,,] buttonBack = PlayGameChangePlayersSymbolsButtonsCreate.PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldAndNewBackground(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateButtonsBackgroundFinal(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = PlayGameSwitchPlayersSymbolsCreateButtonsBackground(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumberForChangeSymbols);          
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerNumber(buttonsList);
            return buttonsList;
        }

        // battons with old symbol
        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateButtonsOldSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            for (int i = 0; i < playersNumberForChangeSymbols; i++)
            {
                GameObject[,,] buttonBack = PlayGameChangePlayersSymbolsButtonsCreate.PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldSymbol(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateButtonsOldSymbolsFinal(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols, string[] oldSymbolsForChande)
        {
            List<GameObject[,,]> buttonsList = PlayGameChangePlayersSymbolsCreateButtonsOldSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols);
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbols(buttonsList);
            PlayGameChangePlayersSymbolsMethods.SetUpPlayerSymbols(buttonsList, oldSymbolsForChande);
            return buttonsList;
        }

        // battons with new symbol
        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateButtonsNewSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();
            for (int i = 0; i < playersNumberForChangeSymbols; i++)
            {
                GameObject[,,] buttonBack = PlayGameChangePlayersSymbolsButtonsCreate.PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForNewSymbol(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateButtonsNewSymbolsFinal(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols, string[] newSymbolsForChande)
        {
            List<GameObject[,,]> buttonsList = PlayGameSwitchPlayersSymbolsCreateButtonsNewSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols);
            
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbols(buttonsList);
            PlayGameChangePlayersSymbolsMethods.SetUpPlayerSymbols(buttonsList, newSymbolsForChande);

            return buttonsList;
        }

        // --------------------------------------------------------------------------------------------


        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateFinalButtonsForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            int playersNumberForChangeSymbols = newSymbolsForChande.Length;

            List<GameObject[,,]> buttonsBackground = PlayGameSwitchPlayersSymbolsCreateButtonsBackgroundFinalForModeTablet(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumberForChangeSymbols);
            List<GameObject[,,]> buttonsOldSymbols = PlayGameSwitchPlayersSymbolsCreateButtonsOldSymbolsFinalForModeTablet(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, playersNumberForChangeSymbols, oldSymbolsForChande);
            List<GameObject[,,]> buttonsNewSymbols = PlayGameSwitchPlayersSymbolsCreateButtonsNewSymbolsFinalForModeTablet(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols, newSymbolsForChande);

            List<List<GameObject[,,]>> buttonsLists = new List<List<GameObject[,,]>>();

            buttonsLists.Insert(0, buttonsBackground);
            buttonsLists.Insert(1, buttonsOldSymbols);
            buttonsLists.Insert(2, buttonsNewSymbols);

            List<GameObject[,,]> buttonsFinalList = new List<GameObject[,,]>();

            int listNumber = buttonsLists.Count;
            int index = 0;

            for (int i = 0; i < listNumber; i++)
            {
                List<GameObject[,,]> list = buttonsLists[i];
                int number = list.Count;

                for (int j = 0; j < number; j++)
                {
                    buttonsFinalList.Insert(index, list[j]);
                    index++;
                }
            }

            return buttonsFinalList;
        }


        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateButtonsBackgroundFinalForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = PlayGameSwitchPlayersSymbolsCreateButtonsBackgroundForModeTablet(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumberForChangeSymbols);
            //GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerNumber(buttonsList);
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbolBiggerThanSix(buttonsList);
            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateButtonsBackgroundForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            for (int i = 0; i < playersNumberForChangeSymbols; i++)
            {
                GameObject[,,] buttonBack = PlayGameChangePlayersSymbolsButtonsCreate.PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldAndNewBackgroundForModeTablet(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateButtonsOldSymbolsFinalForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols, string[] oldSymbolsForChande)
        {
            List<GameObject[,,]> buttonsList = PlayGameChangePlayersSymbolsCreateButtonsOldSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols);
            //GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbols(buttonsList);
            PlayGameChangePlayersSymbolsMethods.SetUpPlayerSymbols(buttonsList, oldSymbolsForChande);
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbolBiggerThanSix(buttonsList);
            //float newCoordinateY = 0.35f;
            float newCoordinateX = 1.15f;
            ChangeDataForSwitchPlayersSymbols(buttonsList, newCoordinateX);

            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameSwitchPlayersSymbolsCreateButtonsNewSymbolsFinalForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols, string[] newSymbolsForChande)
        {
            List<GameObject[,,]> buttonsList = PlayGameSwitchPlayersSymbolsCreateButtonsNewSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols);

            // GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbols(buttonsList);
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbolBiggerThanSix(buttonsList);
            PlayGameChangePlayersSymbolsMethods.SetUpPlayerSymbols(buttonsList, newSymbolsForChande);

            //float newCoordinateY = 0.35f;
            float newCoordinateX = 0.2f;
            ChangeDataForSwitchPlayersSymbols(buttonsList, newCoordinateX);

            return buttonsList;
        }


        // ----
        public static void ChangeDataForSwitchPlayersSymbols(List<GameObject[,,]> buttons, float newCoordinateX)
        {
            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumber = buttons.Count;

            GameObject[,,] table;

            float newCoordinateY = 0.3f;
            float newScale = 0.8f;
            float newScaleZ =1f;
            int start = buttonsNumber - 1;
            int playerNumber;

            for (int i = 0; i < buttonsNumber; i++)
            {
                table = buttons[i];
                playerNumber = i + 1;
                maxIndexDepth = table.GetLength(0);
                maxIndexColumn = table.GetLength(2);
                maxIndexRow = table.GetLength(1);

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = table[indexDepth, indexRow, indexColumn];

                            GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                            GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScaleZ);
                        }
                    }
                }
            }
        }
    }
}
