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
            buttons.Insert(1, buttonSet);

            return buttons;
        }

        public static GameObject[,,] GameInformationsCreateButtonContact(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] tableButtonContact;

            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneInformation.DictionaryTagsGameInformation();
            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneInformation.DictionaryButtonsGameInformation();

            //string tagButtonContact = tagCubePlayDictionary[2];
            string tagButtonContact = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonContact();
            //string buttonText = buttonsGameNameDictionary[1];
            string buttonText = GameInformationCommonButtonsName.GetButtonNameForContcat();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 17;

            string[] tableWithTextForButtonContact = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonContact = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonContact);

            float newCoordinateY = 2f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonContact, newCoordinateY, tagButtonContact);

            return tableButtonContact;
        }

        public static GameObject[,,] GameInformationsCreateButtonGameVersions(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] tableButtonNextVersions;

            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneInformation.DictionaryTagsGameInformation();
            //Dictionary<int, string> buttonsNextVersionsNameDictionary = GameDictionariesSceneInformation.DictionaryButtonsGameInformation();

            //string tagGameButtonHelpButtons = tagCubePlayDictionary[3];
            string tagGameButtonHelpButtons = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonNextVersions();
            //string buttonText = buttonsNextVersionsNameDictionary[2];
            string buttonText = GameInformationCommonButtonsName.GetButtonNameForGameVersions();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 17;

            string[] tableWithTextForButtonNextVersions = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonNextVersions = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonNextVersions);

            float newCoordinateY = 0.5f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNextVersions, newCoordinateY, tagGameButtonHelpButtons);

            return tableButtonNextVersions;
        }


        public static GameObject[,,] GameInformationsCreateButtonSet(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] tableButtonContact;

            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneInformation.DictionaryTagsGameInformation();
            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneInformation.DictionaryButtonsGameInformation();

            //string tagButtonContact = tagCubePlayDictionary[7];
            string tagButtonContact = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtontSet();
            //string buttonText = buttonsGameNameDictionary[3];
            string buttonText = GameInformationCommonButtonsName.GetButtonNameForDefaultSet();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 17;

            string[] tableWithTextForButtonContact = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonContact = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonContact);

            float newCoordinateY = -1f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonContact, newCoordinateY, tagButtonContact);

            return tableButtonContact;
        }

        // ---
        public static GameObject[,,] GameInformationsCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] tableButtonBack;

            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneInformation.DictionaryTagsGameInformation();
            //Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesScenesCommon.DictionaryButtonsCommonName();

            //string tagGameButtonHelpButtons = tagCubePlayDictionary[1];
            string tagGameButtonHelpButtons = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBack();
            //string buttonText = buttonsGameNameDictionary[2];
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
