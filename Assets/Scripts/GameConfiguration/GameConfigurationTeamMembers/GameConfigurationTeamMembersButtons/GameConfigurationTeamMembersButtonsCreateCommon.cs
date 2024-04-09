using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsCreateCommon
    {

        public static GameObject[,,] CreateCommonButtonForTeamMembersFourRows(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
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

        public static GameObject[,,] CreateCommonButtonForTeamMembersPlayers(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, string tagNameDictionary, string buttonText)
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

        public static GameObject[,,] GameConfigurationTeamMembersCreateSingleTableWithButtonsSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, Tuple<int, int> tableSize)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            int numberOfDepths = 1;
            int numberOfRows = tableSize.Item1; 
            int numberOfColumns = tableSize.Item2; 

            tableWithNumbers = GameConfigurationButtonsWithNumbersForTeamMembers.CreateTableWithTeamMembersSymbols(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = GameConfigurationButtonsWithNumbersForTeamMembers.ChangeDataForTableWithTeamMembers(tableWithNumbers);

            return tableWithNumberFinal;
        }

    }
}
