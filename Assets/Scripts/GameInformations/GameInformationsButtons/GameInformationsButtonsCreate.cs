using Assets.Scripts.Buttons;
using Assets.Scripts.GameConfiguration.GameConfigurationBase;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameInformationsButtons
{
    internal class GameInformationsButtonsCreate
    {

        public static List<GameObject[,,]> GameInformationsCreateButtons(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            //GameObject[,,] buttonBack = GameInformationsCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
            GameObject[,,] buttonContact = GameInformationsCreateButtonContact(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonNextVersions = GameInformationsCreateButtonNextVersions(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);

            List<GameObject[,,]> buttons = new List<GameObject[,,]>();
            buttons.Insert(0, buttonContact);
            buttons.Insert(1, buttonNextVersions);


            //List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            //buttonsAll.Insert(0, buttonBack);
            //buttonsAll.Insert(1, buttonContact);
            //buttonsAll.Insert(2, buttonNextVersions);


            return buttons;

        }

        public static GameObject[,,] GameInformationsCreateButtonContact(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {

            GameObject[,,] tableButtonContact;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneInformations.DictionaryTagGameInformations();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneInformations.DictionaryButtonsGameInformations();

            string tagButtonContact = tagCubePlayDictionary[2];
            string buttonText = buttonsGameNameDictionary[1];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 17;

            string[] tableWithTextForButtonContact = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonContact = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonContact);

            float newCoordinateY = 1f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonContact, newCoordinateY, tagButtonContact);

            return tableButtonContact;
        }

        public static GameObject[,,] GameInformationsCreateButtonNextVersions(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {

            GameObject[,,] tableButtonNextVersions;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneInformations.DictionaryTagGameInformations();
            Dictionary<int, string> buttonsNextVersionsNameDictionary = GameDictionariesSceneInformations.DictionaryButtonsGameInformations();

            string tagGameButtonHelpButtons = tagCubePlayDictionary[3];
            string buttonText = buttonsNextVersionsNameDictionary[2];
            //string buttonText = buttonsGameNameDictionary[2];

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 17;

            string[] tableWithTextForButtonNextVersions = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonNextVersions = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonNextVersions);

            float newCoordinateY = -0.5f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonNextVersions, newCoordinateY, tagGameButtonHelpButtons);

            return tableButtonNextVersions;
        }

        // ---
        public static GameObject[,,] GameInformationsCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            //Dictionary<int, string> tagNameDictionary = GameDictionariesScenesInformations.DictionaryTagGameInformations();

            //string tagName = tagNameDictionary[1];

            //GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);
            //return buttonBack;

            GameObject[,,] tableButtonBack;

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneInformations.DictionaryTagGameInformations();
            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesScenesCommon.DictionaryButtonsCommonName();

            string tagGameButtonHelpButtons = tagCubePlayDictionary[1];
            string buttonText = buttonsGameNameDictionary[2];

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
