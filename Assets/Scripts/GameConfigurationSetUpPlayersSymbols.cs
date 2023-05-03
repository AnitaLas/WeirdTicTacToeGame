using Assets.Scripts.GameConfiguration;
using Assets.Scripts.GameConfigurationPlayerSymbol;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.GameConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Assets.Scripts.GameConfiguration.GameConfigurationBase;
using Assets.Scripts.GameConfiguration.GameConfigurationPlayerSymbolButtons;
using Assets.Scripts.Scenes;

namespace Assets.Scripts
{
    internal class GameConfigurationSetUpPlayersSymbols : MonoBehaviour
    {
        public static string[] ConfigurationPlayerSymbolTableWitPlayersChosenSymbols { get; set; }

        // ---

        public GameObject prefabSymbolPlayer;
        public GameObject prefabCubePlay;

        public Material[] prefabSymbolPlayerMaterial;
        public Material[] prefabSymbolPlayerMaterialInactiveField;

        // --- new
        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsBackColour;
        public Material[] prefabCubePlayButtonsNumberColour;

        private bool isGame2D = true;

        Dictionary<int, string> configurationPlayersSymbolsDictionaryTag = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();

        private string _tagConfiguratioPlayerSymbolDefaultNumber;
        private string _tagConfigurationPlayerSymbolDefaultSymbol;
        private string _tagConfigurationPlayerSymbolChange;
        private string _tagConfigurationPlayerSymbolChooseSymbol;
        private string _tagConfigurationPlayerSymbolInactiveField;
        private string _tagConfigurationPlayerSymbolButtonSave;
        private string _tagConfigurationPlayerSymbolButtonBack;
        private string _tagConfigurationPlayerSymbolButtonBackToConfiguration;

        Dictionary<int, string> tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();

        private string _tagUntagged;


        private int numberOfDepths = 1;
        private int numberOfColumns = 1;
        private int numberOfPlayers;

        private int numberOfDepthsForTableWithSymbols = 1;
        private int numberOfColumnsForTableSymbols = 4;
        private int numberOfRowsForTableWithSymbols = 7;

        List<GameObject[,,]> tableWithPlayersAndSymbols;
        GameObject[,,] tableWithSymbolsBase;
        GameObject[,,] tableWitSymbols;

        string[] tableWitPlayersChosenSymbols;

        private string _gameObjectParentNameChanged;

        private List<GameObject[,,]> _buttonsBackAndSave;
        private List<GameObject[,,]> _buttonsWithPlayers;
        private List<GameObject[,,]> _buttonsWithSymbols;
        private GameObject[,,] _buttonBackToConfiguration;

        void Start()
        {

            _tagConfiguratioPlayerSymbolDefaultNumber = configurationPlayersSymbolsDictionaryTag[1];
            _tagConfigurationPlayerSymbolDefaultSymbol = configurationPlayersSymbolsDictionaryTag[2];
            _tagConfigurationPlayerSymbolChange = configurationPlayersSymbolsDictionaryTag[3];
            _tagConfigurationPlayerSymbolChooseSymbol = configurationPlayersSymbolsDictionaryTag[4];
            _tagConfigurationPlayerSymbolInactiveField = configurationPlayersSymbolsDictionaryTag[5];

            _tagConfigurationPlayerSymbolButtonSave = configurationPlayersSymbolsDictionaryTag[6];
            _tagConfigurationPlayerSymbolButtonBack = configurationPlayersSymbolsDictionaryTag[7];
            _tagConfigurationPlayerSymbolButtonBackToConfiguration = configurationPlayersSymbolsDictionaryTag[8];

            // ---
            _tagUntagged = tagCommonDictionary[1];

            // ---
            numberOfPlayers = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfPlayers;        

            _buttonsWithPlayers = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonsForPlayerNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D, numberOfPlayers);
            _buttonsWithSymbols = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonsForPlayerSymbol(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, numberOfPlayers);

            _buttonsBackAndSave = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, isGame2D, numberOfPlayers);
            _buttonBackToConfiguration = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);


        }




        void Update()
        {

            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

                RaycastHit touch;

                if (Physics.Raycast(ray, out touch))
                {
                    if (touch.collider != null)
                    {
                        string gameObjectTag = CommonMethods.GetObjectTag(touch);
                        string gameObjectName = CommonMethods.GetObjectName(touch);


                        if (gameObjectTag != _tagUntagged)
                        {
                            GameObject gameObject = CommonMethods.GetObjectByTagName(gameObjectTag);
                        }
                        

                        if (gameObjectTag == _tagConfiguratioPlayerSymbolDefaultNumber || gameObjectTag == _tagConfigurationPlayerSymbolDefaultSymbol)
                        {
                            GameConfigurationPlayerSymbolCommonMethods.ChangeTagForDefaultPlayerSymbol(gameObjectName, _tagConfigurationPlayerSymbolChange, _tagConfigurationPlayerSymbolDefaultSymbol);

                            GameConfigurationPlayerSymbolButtonsActions.HideConfiguration(_buttonsWithPlayers);
                            GameConfigurationPlayerSymbolButtonsActions.HideConfiguration(_buttonsWithSymbols);
                            GameConfigurationPlayerSymbolButtonsActions.HideConfiguration(_buttonsBackAndSave);
                            GameConfigurationPlayerSymbolButtonsActions.UnhideButtonBackToConfiguration(_buttonBackToConfiguration);

                            tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(_buttonsWithSymbols);

                            // configuration table with the symbol which may be chosen by users
                            tableWithSymbolsBase = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithSymbols(prefabCubePlay, numberOfDepthsForTableWithSymbols, numberOfRowsForTableWithSymbols, numberOfColumnsForTableSymbols, prefabSymbolPlayerMaterial, isGame2D);
                            tableWitSymbols = GameConfigurationPlayerSymbolTableWithSymbols.ChangeDataForTableWithSymbols(tableWithSymbolsBase, tableWitPlayersChosenSymbols, prefabSymbolPlayerMaterialInactiveField, _tagConfigurationPlayerSymbolChooseSymbol, _tagConfigurationPlayerSymbolInactiveField);

                            GameConfigurationPlayerSymbolButtonsActions.UnhideTableWithNumber(tableWitSymbols);

                        }

                        // to fix, does not work for Q U Y, cube play no 1, 2, 3 - changed name for cubePlay solved the problem
                        if (gameObjectTag == _tagConfigurationPlayerSymbolChooseSymbol)
                        {
                            string gameObjectNameForChosenSymbol = CommonMethods.GetObjectName(touch);
                            //Debug.Log("gameObjectNameForChosenSymbol = " + gameObjectNameForChosenSymbol);
                            GameObject gameObjectForChosenSymbol = CommonMethods.GetObjectByName(gameObjectNameForChosenSymbol);
                            //Debug.Log("gameObjectForChosenSymbol = " + gameObjectForChosenSymbol);

                            //foreach (var obj in tableWitSymbols)
                            //{
                            //    string tag = CommonMethods.GetObjectTag(obj);
                            //    Debug.Log("tag = " + tag);
                            //}

                            string newSymbol = CommonMethods.GetCubePlayText(gameObjectForChosenSymbol);
                            //string newSymbol = CommonMethods.GetCubePlayText2(gameObjectForChosenSymbol);
                            //string newSymbol = "?";
                            //Debug.Log("newSymbol = " + newSymbol);

                            GameConfigurationPlayerSymbolCommonMethods.ChangeSymbolForPlayer(newSymbol, _tagConfigurationPlayerSymbolChange);

                            GameObject gameObject = CommonMethods.GetObjectByTagName(_tagConfigurationPlayerSymbolChange);
                            CommonMethods.ChangeTagForGameObject(gameObject, _tagConfigurationPlayerSymbolDefaultSymbol);

                            GameConfigurationPlayerSymbolButtonsActions.DestroyTableWithPlayerSymbol(tableWithSymbolsBase);
                            GameConfigurationPlayerSymbolButtonsActions.DestroyTableWithPlayerSymbol(tableWitSymbols);

                            GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsWithPlayers);
                            GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsWithSymbols);

                            GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsBackAndSave);
                            GameConfigurationPlayerSymbolButtonsActions.HideButtonBackToConfiguration(_buttonBackToConfiguration);


                            // Debug.Log(" ------------------------  ");
                        }


                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonBackToConfiguration)
                        {
                            GameConfigurationPlayerSymbolButtonsActions.DestroyTableWithPlayerSymbol(tableWithSymbolsBase);
                            GameConfigurationPlayerSymbolButtonsActions.DestroyTableWithPlayerSymbol(tableWitSymbols);

                            GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsWithPlayers);
                            GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsWithSymbols);
                            GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsBackAndSave);

                            GameConfigurationPlayerSymbolButtonsActions.HideButtonBackToConfiguration(_buttonBackToConfiguration);
                           
                        }


                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonSave)
                        {
                            tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(_buttonsWithSymbols);
                            ConfigurationPlayerSymbolTableWitPlayersChosenSymbols = tableWitPlayersChosenSymbols;

                            ScenesChange.GoToSceneGame();

                        }

                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonBack)
                        {
                            ScenesChange.GoToSceneConfigurationBoardGame();

                        }

                    }
                }
            }


        }

        }
}
