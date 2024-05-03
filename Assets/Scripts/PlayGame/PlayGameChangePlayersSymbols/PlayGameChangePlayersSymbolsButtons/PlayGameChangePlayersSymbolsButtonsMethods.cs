using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    internal class PlayGameChangePlayersSymbolsButtonsMethods
    {

        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateFinalButtonsForModeCellphone(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            int playersNumberForChangeSymbols = newSymbolsForChande.Length;

            List<GameObject[,,]> buttonsBackground = PlayGameChangePlayersSymbolsCreateButtonsBackgroundFinal(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumberForChangeSymbols);
            List<GameObject[,,]> buttonsOldSymbols = PlayGameChangePlayersSymbolsCreateButtonsOldSymbolsFinal(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, playersNumberForChangeSymbols, oldSymbolsForChande);
            List<GameObject[,,]> buttonsNewSymbols = PlayGameChangePlayersSymbolsCreateButtonsNewSymbolsFinal(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols, newSymbolsForChande);

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
        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateButtonsBackground(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            for (int i = 0; i < playersNumberForChangeSymbols; i++)
            {
                GameObject[,,] buttonBack = PlayGameChangePlayersSymbolsButtonsCreate.PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldAndNewBackground(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateButtonsBackgroundFinal(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = PlayGameChangePlayersSymbolsCreateButtonsBackground(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumberForChangeSymbols);          
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

        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateButtonsOldSymbolsFinal(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols, string[] oldSymbolsForChande)
        {
            List<GameObject[,,]> buttonsList = PlayGameChangePlayersSymbolsCreateButtonsOldSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols);
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbols(buttonsList);
            PlayGameChangePlayersSymbolsMethods.SetUpPlayerSymbols(buttonsList, oldSymbolsForChande);
            return buttonsList;
        }

        // battons with new symbol
        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateButtonsNewSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();
            for (int i = 0; i < playersNumberForChangeSymbols; i++)
            {
                GameObject[,,] buttonBack = PlayGameChangePlayersSymbolsButtonsCreate.PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForNewSymbol(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateButtonsNewSymbolsFinal(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols, string[] newSymbolsForChande)
        {
            List<GameObject[,,]> buttonsList = PlayGameChangePlayersSymbolsCreateButtonsNewSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols);
            
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbols(buttonsList);
            PlayGameChangePlayersSymbolsMethods.SetUpPlayerSymbols(buttonsList, newSymbolsForChande);

            return buttonsList;
        }

        // --------------------------------------------------------------------------------------------


        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateFinalButtonsForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D, string[] oldSymbolsForChande, string[] newSymbolsForChande)
        {
            int playersNumberForChangeSymbols = newSymbolsForChande.Length;

            List<GameObject[,,]> buttonsBackground = PlayGameChangePlayersSymbolsCreateButtonsBackgroundFinalForModeTablet(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumberForChangeSymbols);
            List<GameObject[,,]> buttonsOldSymbols = PlayGameChangePlayersSymbolsCreateButtonsOldSymbolsFinalForModeTablet(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, playersNumberForChangeSymbols, oldSymbolsForChande);
            List<GameObject[,,]> buttonsNewSymbols = PlayGameChangePlayersSymbolsCreateButtonsNewSymbolsFinalForModeTablet(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols, newSymbolsForChande);

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


        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateButtonsBackgroundFinalForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = PlayGameChangePlayersSymbolsCreateButtonsBackgroundForModeTablet(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumberForChangeSymbols);
            //GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerNumber(buttonsList);
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbolBiggerThanSix(buttonsList);
            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateButtonsBackgroundForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumberForChangeSymbols)
        {
            List<GameObject[,,]> buttonsList = new List<GameObject[,,]>();

            for (int i = 0; i < playersNumberForChangeSymbols; i++)
            {
                GameObject[,,] buttonBack = PlayGameChangePlayersSymbolsButtonsCreate.PlayGameChangePlayersSymbolsButtonsCreateSingleButtonForOldAndNewBackgroundForModeTablet(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
                buttonsList.Insert(i, buttonBack);
            }

            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateButtonsOldSymbolsFinalForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols, string[] oldSymbolsForChande)
        {
            List<GameObject[,,]> buttonsList = PlayGameChangePlayersSymbolsCreateButtonsOldSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols);
            //GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbols(buttonsList);
            PlayGameChangePlayersSymbolsMethods.SetUpPlayerSymbols(buttonsList, oldSymbolsForChande);
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbolBiggerThanSix(buttonsList);
            //float newCoordinateY = 0.35f;
            float newCoordinateX = 1.15f;
            ChangeDataForChangePlayersSymbols(buttonsList, newCoordinateX);

            return buttonsList;
        }

        public static List<GameObject[,,]> PlayGameChangePlayersSymbolsCreateButtonsNewSymbolsFinalForModeTablet(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumberForChangeSymbols, string[] newSymbolsForChande)
        {
            List<GameObject[,,]> buttonsList = PlayGameChangePlayersSymbolsCreateButtonsNewSymbols(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, playersNumberForChangeSymbols);

            // GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbols(buttonsList);
            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbolBiggerThanSix(buttonsList);
            PlayGameChangePlayersSymbolsMethods.SetUpPlayerSymbols(buttonsList, newSymbolsForChande);

            //float newCoordinateY = 0.35f;
            float newCoordinateX = 0.2f;
            ChangeDataForChangePlayersSymbols(buttonsList, newCoordinateX);

            return buttonsList;
        }


        // ----
        public static void ChangeDataForChangePlayersSymbols(List<GameObject[,,]> buttons, float newCoordinateX)
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
