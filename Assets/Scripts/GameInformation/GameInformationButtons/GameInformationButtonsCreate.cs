using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameInformationButtonsCreate
    {
        public static List<GameObject[,,]> GameInformationsCreateButtons(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] buttonContact = GameInformationsCreateButtonContact(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonNextVersions = GameInformationsCreateButtonGameVersions(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonSet = GameInformationsCreateButtonSet(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);

            List<GameObject[,,]> buttons = new List<GameObject[,,]>();
            buttons.Insert(0, buttonContact);
            buttons.Insert(1, buttonNextVersions);
            buttons.Insert(2, buttonSet);

            GameObject gameObjectBase = buttonContact[0, 0, 0];
            int numberOfButton = buttons.Count;

            float[] newYForButtons = GameConfigurationButtonsMethods.GetTableWithNewYForTeamGameConfigurationButtons(gameObjectBase, numberOfButton);

            GameConfigurationButtonsMethods.ChangeDataForGameInformationButtons(buttons, newYForButtons);
            return buttons;
        }

        public static GameObject[,,] GameInformationsCreateButtonContact(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonContact();
            string buttonText = GameInformationCommonButtonsName.GetButtonNameForContcat();
            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }

        public static GameObject[,,] GameInformationsCreateButtonGameVersions(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonNextVersions();
            string buttonText = GameInformationCommonButtonsName.GetButtonNameForGameVersions();
            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }


        public static GameObject[,,] GameInformationsCreateButtonSet(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtontSet();
            string buttonText = GameInformationCommonButtonsName.GetButtonNameForDefaultSet();
            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }

        // ---
        public static GameObject[,,] GameInformationsCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] tableButtonBack;
            string tagGameButtonHelpButtons = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBack();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForButtonBack();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonBack = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.75f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonBack, newCoordinateY, tagGameButtonHelpButtons);

            return tableButtonBack;
        }
    }
}