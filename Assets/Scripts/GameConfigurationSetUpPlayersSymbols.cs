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
        //public static int ConfigurationBoardGameNumberOfPlayers { get; set; }
        //public static int ConfigurationBoardGameNumberOfRows { get; set; }
        //public static int ConfigurationBoardGameNumberOfColumns { get; set; }
        //public static int ConfigurationBoardGameLenghtToCheck { get; set; }

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

        //Dictionary<int, string> scenceDictionary = GameDictionariesCommon.DictionaryScence();

        //private string _sceneGame;
        //private string _sceneConfigurationPlayersSymbols;

        Dictionary<int, string> tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();

        private string _tagUntagged;


        private int numberOfDepths = 1;
        private int numberOfColumns = 1;
        private int numberOfPlayers;

        private int numberOfDepthsForTableWithSymbols = 1;
        private int numberOfColumnsForTableSymbols = 4;
        private int numberOfRowsForTableWithSymbols = 7;

        //GameObject[,,] tableWithPlayersAndSymbolsBase;
        List<GameObject[,,]> tableWithPlayersAndSymbols;
        GameObject[,,] tableWithSymbolsBase;
        GameObject[,,] tableWitSymbols;

        string[] tableWitPlayersChosenSymbols;

        private string _gameObjectParentNameChanged;

        //private string[] _tagConfigurationDefaultButton = new string[2];
        //private string[] _tagConfigurationButtonBackTableWithSymbolsToChoose = new string[1];

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
            //_sceneGame = scenceDictionary[1];
            //_sceneConfigurationPlayersSymbols = scenceDictionary[3];

            // ---
            _tagUntagged = tagCommonDictionary[1];
            // ---
            //_tagConfigurationDefaultButton[0] = _tagConfigurationPlayerSymbolButtonSave;
            //_tagConfigurationDefaultButton[1] = _tagConfigurationPlayerSymbolButtonBack;

            // ---
            //_tagConfigurationButtonBackTableWithSymbolsToChoose[0] = _tagConfigurationPlayerSymbolButtonBackToConfiguration;

            // ---
            numberOfPlayers = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfPlayers;

            // configuration table with players and defaul symbol
            //tableWithPlayersAndSymbolsBase = GameConfigurationPlayerSymbolTableWithPlayerNumber.CreateTableWithPlayers(prefabSymbolPlayer, numberOfDepths, numberOfPlayers, numberOfColumns, prefabSymbolPlayerMaterial, isGame2D);
            //tableWithPlayersAndSymbols = GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayersAndSymbols(tableWithPlayersAndSymbolsBase);

            //tableWithPlayersAndSymbols = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonsPlayer( prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D, numberOfPlayers);
            //GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationButtonBackTableWithSymbolsToChoose);

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
                        //Debug.Log("gameObjectTag = " + gameObjectTag);

                        //if (gameObjectTag != "Untagged")
                        if (gameObjectTag != _tagUntagged)
                        {
                            GameObject gameObject = CommonMethods.GetObjectByTagName(gameObjectTag);
                        }
                        

                        if (gameObjectTag == _tagConfiguratioPlayerSymbolDefaultNumber || gameObjectTag == _tagConfigurationPlayerSymbolDefaultSymbol)
                        {
                            /* bad idea to put it here
                            if (tableWithSymbolsBase != null || tableWitSymbols != null)
                            {
                                GameConfigurationTableForLenghtToCheck.DestroyTable(tableWithSymbolsBase);
                                GameConfigurationTableForLenghtToCheck.DestroyTable(tableWitSymbols);
                            }
                            */

                            //string gameObjectParentName = CommonMethods.GetParentObjectName(touch);
                            //_gameObjectParentNameChanged = gameObjectParentName;

                            //GameObject gameObjectParent = CommonMethods.GetObjectByName(gameObjectParentName);
                            GameConfigurationPlayerSymbolCommonMethods.ChangeTagForDefaultPlayerSymbol(gameObjectName, _tagConfigurationPlayerSymbolChange, _tagConfigurationPlayerSymbolDefaultSymbol);



                            //GameConfigurationPlayerSymbolButtonsAction.HideConfiguration(tableWithPlayersAndSymbols);
                            GameConfigurationButtonsAction.HideConfiguration(_buttonsWithPlayers);
                            GameConfigurationButtonsAction.HideConfiguration(_buttonsWithSymbols);
                            GameConfigurationButtonsAction.HideConfiguration(_buttonsBackAndSave);
                            GameConfigurationButtonsAction.UnhideButtonBackToConfiguration(_buttonBackToConfiguration);

                            // ---
                            // tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(tableWithPlayersAndSymbols);
                            //tableWithPlayersAndSymbols = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonsPlayer(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D, numberOfPlayers);
                            tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(_buttonsWithSymbols);


                            // configuration table with the symbol which may be chosen by users
                            tableWithSymbolsBase = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithSymbols(prefabCubePlay, numberOfDepthsForTableWithSymbols, numberOfRowsForTableWithSymbols, numberOfColumnsForTableSymbols, prefabSymbolPlayerMaterial, isGame2D);
                            tableWitSymbols = GameConfigurationPlayerSymbolTableWithSymbols.ChangeDataForTableWithSymbols(tableWithSymbolsBase, tableWitPlayersChosenSymbols, prefabSymbolPlayerMaterialInactiveField, _tagConfigurationPlayerSymbolChooseSymbol, _tagConfigurationPlayerSymbolInactiveField);

                            GameConfigurationButtonsAction.UnhideTableWithNumber(tableWitSymbols);

                            //GameConfigurationPlayerSymbolButtonsAction.HideConfiguration(_buttonsBackAndSave);
                            //GameConfigurationPlayerSymbolButtonsAction.UnhideButtonBackToConfiguration(_buttonBackToConfiguration);
                        
                        }



                        if (gameObjectTag == _tagConfigurationPlayerSymbolChooseSymbol)
                        {
                            string gameObjectNameForChosenSymbol = CommonMethods.GetObjectName(touch);
                            GameObject gameObjectForChosenSymbol = CommonMethods.GetObjectByName(gameObjectNameForChosenSymbol);
                           
                            string newSymbol = CommonMethods.GetCubePlayText(gameObjectForChosenSymbol);
                            GameConfigurationPlayerSymbolCommonMethods.ChangeSymbolForPlayer(newSymbol, _tagConfigurationPlayerSymbolChange);

                            GameObject gameObject = CommonMethods.GetObjectByTagName(_tagConfigurationPlayerSymbolChange);
                            CommonMethods.ChangeTagForGameObject(gameObject, _tagConfigurationPlayerSymbolDefaultSymbol);

                            // _tagConfigurationPlayerSymbolChooseSymbol
                            //GameObject gameObjectParent = CommonMethods.GetObjectByName(_gameObjectParentNameChanged);
                            // GameConfigurationPlayerSymbolCommonMethods.ChangeTagForDefaultPlayerSymbol(gameObjectParent, _tagConfigurationPlayerSymbolDefaultSymbol);

                            ////GameConfigurationPlayerSymbolButtonsAction.UnhideConfiguration(tableWithPlayersAndSymbols);
                            //GameConfigurationButtonsAction.UnhideConfiguration(tableWithPlayersAndSymbols);

                            GameConfigurationTableForLenghtToCheck.DestroyTable(tableWithSymbolsBase);
                            GameConfigurationTableForLenghtToCheck.DestroyTable(tableWitSymbols);

                            ////GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationDefaultButton);
                            ////GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationButtonBackTableWithSymbolsToChoose);

                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsWithPlayers);
                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsWithSymbols);


                            ////GameConfigurationPlayerSymbolButtonsAction.UnhideConfiguration(_buttonsBackAndSave);
                            ////GameConfigurationPlayerSymbolButtonsAction.HideButtonBackToConfiguration(_buttonBackToConfiguration);

                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsBackAndSave);
                            GameConfigurationButtonsAction.HideButtonBackToConfiguration(_buttonBackToConfiguration);

                        }

                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonBackToConfiguration)
                        {

                            //GameConfigurationPlayerSymbolButtonsAction.UnhideConfiguration(tableWithPlayersAndSymbols);
                            //GameConfigurationPlayerSymbolButtonsAction.UnhideConfiguration(tableWithPlayersAndSymbols);
                            //GameConfigurationPlayerSymbolCommonMethods.HideTableWithNumber(tableWitSymbols);

                            ////GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationDefaultButton);
                            ////GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationButtonBackTableWithSymbolsToChoose);
                            ////GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationPlayerSymbolButtonBackToConfiguration);

                            //GameConfigurationPlayerSymbolButtonsAction.UnhideConfiguration(_buttonsBackAndSave);
                            //GameConfigurationPlayerSymbolButtonsAction.HideButtonBackToConfiguration(_buttonBackToConfiguration);
                            GameConfigurationTableForLenghtToCheck.DestroyTable(tableWithSymbolsBase);
                            GameConfigurationTableForLenghtToCheck.DestroyTable(tableWitSymbols);

                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsWithPlayers);
                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsWithSymbols);
                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsBackAndSave);

                            GameConfigurationButtonsAction.HideButtonBackToConfiguration(_buttonBackToConfiguration);
                           
                        }



                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonSave)
                        {
                            //tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(tableWithPlayersAndSymbols);
                            tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(_buttonsWithSymbols);
                            ConfigurationPlayerSymbolTableWitPlayersChosenSymbols = tableWitPlayersChosenSymbols;

                            ScenesChange.GoToSceneGame();
                            //CommonMethods.ChangeScene(_sceneGame);

                        }

                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonBack)
                        {
                            //ConfigurationBoardGameNumberOfRows = 3;
                            //ConfigurationBoardGameNumberOfColumns = 3;
                           // ConfigurationBoardGameNumberOfPlayers = 2;
                            //ConfigurationBoardGameLenghtToCheck = 3;

                            ScenesChange.GoToSceneConfigurationBoardGame();
                           // CommonMethods.ChangeScene(_sceneConfigurationPlayersSymbols);

                        }

                    }
                }
            }


        }

        }
}
