using Assets.Scripts.Buttons;
using Assets.Scripts.GameConfiguration.GameConfigurationBase;
using Assets.Scripts.GameConfigurationPlayerSymbol;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.PlayGameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration.GameConfigurationPlayerSymbolButtons
{
    internal class GameConfigurationPlayerSymbolButtonsCreate
    {
        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtons(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsBackColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, int playersNumber)
        {
            // button save and back
            GameObject[,,] buttonSave = GameConfigurationPlayerSymbolCreateButtonSave(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationPlayerSymbolCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonSave);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;

        }

        public static GameObject[,,] GameConfigurationPlayerSymbolCreateButtonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();

            string tagName = tagNameDictionary[6];

            GameObject[,,] buttonSave = GameConfigurationButtonsCommonCreate.CreateCommonButtonSave(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName);
            return buttonSave;
        }

        public static GameObject[,,] GameConfigurationPlayerSymbolCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();

            string tagName = tagNameDictionary[7];

            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);
            return buttonBack;
        }


        public static GameObject[,,] GameConfigurationPlayerSymbolCreateButtonBackToConfiguration(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();

            string tagName = tagNameDictionary[8];

            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);
            return buttonBack;
        }


        // ---

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtonsPlayer(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumber)
        {
            List<GameObject[,,]> buttonsWithPlayerTextList;

            buttonsWithPlayerTextList = GameConfigurationPlayerSymbolCreateButtonsForPlayerNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, playersNumber);

            return buttonsWithPlayerTextList;

        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtonsForPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumber)
        {
            List<GameObject[,,]> buttonsList;

            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();
            string tagName = tagNameDictionary[1];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryButtonsConfigurationPlayerSymbolDefaultText();
            string buttonText = buttonsGameNameDictionary[1];

            string[] defaultTextForButtons = ButtonsCommonMethods.CreateTableWithefaultTextForButtons(playersNumber, buttonText);

            buttonsList = GameConfigurationPlayerSymbolButtonsMethods.GameConfigurationPlayerSymbolAllCreateButtonsForPlayerNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, playersNumber, defaultTextForButtons);

            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerNumber(buttonsList);
            
            return buttonsList;

        }

        public static List<GameObject[,,]> GameConfigurationPlayerSymbolCreateButtonsForPlayerSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int playersNumber)
        {
            List<GameObject[,,]> buttonsList;

            Dictionary<int, string> tagNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();
            string tagName = tagNameDictionary[2];

            Dictionary<int, string> buttonsGameNameDictionary = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryButtonsConfigurationPlayerSymbolDefaultText();
            string buttonText = buttonsGameNameDictionary[1];

            string[] defaultPlayersSymbols = CreateGameBoardMethods.CreateTableWithCharactersByGivenString();

            buttonsList = GameConfigurationPlayerSymbolButtonsMethods.GameConfigurationPlayerSymbolAllCreateButtonsForPlayerSymbol(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, playersNumber, defaultPlayersSymbols);

            GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayerSymbols(buttonsList);

            return buttonsList;

        }


    }
}
