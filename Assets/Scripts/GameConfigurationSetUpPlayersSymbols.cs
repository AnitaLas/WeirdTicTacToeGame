using Assets.Scripts.GameConfiguration;
using Assets.Scripts.GameConfigurationPlayerSymbol;
using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers;
using Assets.Scripts.GameConfiguration.GameConfigurationPlayerSymbolButtons;
using Assets.Scripts.Scenes;

namespace Assets.Scripts
{
    internal class GameConfigurationSetUpPlayersSymbols : MonoBehaviour
    {
        public static string[] ConfigurationPlayerSymbolTableWitPlayersChosenSymbols { get; set; }

        // ---

        //public GameObject prefabSymbolPlayer;
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
       // private string _tagConfigurationPlayerSymbolChange;
        private string _tagConfigurationPlayerSymbolChooseSymbol;
        //private string _tagConfigurationPlayerSymbolInactiveField;
        private string _tagConfigurationPlayerSymbolButtonSave;
        private string _tagConfigurationPlayerSymbolButtonBack;
        private string _tagConfigurationPlayerSymbolButtonBackToConfiguration;

        Dictionary<int, string> tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();

        private string _tagUntagged;


        //private int numberOfDepths = 1;
       // private int numberOfColumns = 1;
        private int _numberOfPlayers;

        //private int numberOfDepthsForTableWithSymbols = 1;
        //private int numberOfColumnsForTableSymbols = 4;
        //private int numberOfRowsForTableWithSymbols = 7;

        //List<GameObject[,,]> tableWithPlayersAndSymbols;
        //private GameObject[,,] _tableWithSymbolsBase;
        private GameObject[,,] _tableWitSymbols;

        private string[] _tableWitPlayersChosenSymbols;

        //private string _gameObjectParentNameChanged;

        private List<GameObject[,,]> _buttonsBackAndSave;
        private List<GameObject[,,]> _buttonsWithPlayers;
        private List<GameObject[,,]> _buttonsWithSymbols;
        private List<List<GameObject[,,]>> _configurationBaseButtons;
        private List<GameObject[,,]> _buttonsMoreSpecificConfiguration;

        //private GameObject[,,] _buttonBackToConfiguration;

        void Start()
        {

            _tagConfiguratioPlayerSymbolDefaultNumber = configurationPlayersSymbolsDictionaryTag[1];
            _tagConfigurationPlayerSymbolDefaultSymbol = configurationPlayersSymbolsDictionaryTag[2];
            //_tagConfigurationPlayerSymbolChange = configurationPlayersSymbolsDictionaryTag[3];
            _tagConfigurationPlayerSymbolChooseSymbol = configurationPlayersSymbolsDictionaryTag[4];
            //_tagConfigurationPlayerSymbolInactiveField = configurationPlayersSymbolsDictionaryTag[5];

            _tagConfigurationPlayerSymbolButtonSave = configurationPlayersSymbolsDictionaryTag[6];
            _tagConfigurationPlayerSymbolButtonBack = configurationPlayersSymbolsDictionaryTag[7];
            _tagConfigurationPlayerSymbolButtonBackToConfiguration = configurationPlayersSymbolsDictionaryTag[8];

            // ---
            _tagUntagged = tagCommonDictionary[1];

            // ---
            _numberOfPlayers = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfPlayers;        

            _buttonsWithPlayers = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonsForPlayerNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D, _numberOfPlayers);
            _buttonsWithSymbols = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonsForPlayerSymbol(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, _numberOfPlayers);
            _buttonsBackAndSave = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, isGame2D, _numberOfPlayers);

            _configurationBaseButtons = new List<List<GameObject[,,]>>();

            _configurationBaseButtons.Insert(0, _buttonsWithPlayers);
            _configurationBaseButtons.Insert(1, _buttonsWithSymbols);
            _configurationBaseButtons.Insert(2, _buttonsBackAndSave);

            
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
                            //GameConfigurationPlayerSymbolCommonMethods.ChangeTagForDefaultPlayerSymbol(gameObjectName, _tagConfigurationPlayerSymbolChange, _tagConfigurationPlayerSymbolDefaultSymbol);

                            //GameConfigurationPlayerSymbolButtonsActions.ChangeTagForPlayerDefaultSymbol(gameObjectName);
                            //GameConfigurationPlayerSymbolButtonsActions.HideConfiguration(_buttonsWithPlayers);
                            //GameConfigurationPlayerSymbolButtonsActions.HideConfiguration(_buttonsWithSymbols);
                            //GameConfigurationPlayerSymbolButtonsActions.HideConfiguration(_buttonsBackAndSave);

                            GameConfigurationPlayerSymbolButtonsActions.HideConfigurationBaseButtons(_configurationBaseButtons, gameObjectName);

                            //GameConfigurationPlayerSymbolButtonsActions.HideConfigurationBaseButtons(_configurationBaseButtons, gameObjectName);


                            //GameConfigurationPlayerSymbolButtonsActions.UnhideButtonBackToConfiguration(_buttonBackToConfiguration);
                            //_buttonBackToConfiguration = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
                            //gameObjectName
                            _buttonsMoreSpecificConfiguration = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationCreateButtonsBackAndPlayer( prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, isGame2D, gameObjectName);

                            _tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(_buttonsWithSymbols);

                            // configuration table with the symbol which may be chosen by users
                            //_tableWithSymbolsBase = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithSymbols(prefabCubePlay, numberOfDepthsForTableWithSymbols, numberOfRowsForTableWithSymbols, numberOfColumnsForTableSymbols, prefabSymbolPlayerMaterial, isGame2D);
                            //_tableWitSymbols = GameConfigurationPlayerSymbolTableWithSymbols.ChangeDataForTableWithSymbols(_tableWithSymbolsBase, _tableWitPlayersChosenSymbols, prefabSymbolPlayerMaterialInactiveField, _tagConfigurationPlayerSymbolChooseSymbol, _tagConfigurationPlayerSymbolInactiveField);
                            _tableWitSymbols = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonsWithSymbolsToChose(prefabCubePlay, prefabSymbolPlayerMaterial, prefabSymbolPlayerMaterialInactiveField, _tableWitPlayersChosenSymbols, isGame2D);

                            //GameConfigurationPlayerSymbolButtonsActions.UnhideTableWithNumber(_tableWitSymbols);

                        }

                        if (gameObjectTag == _tagConfigurationPlayerSymbolChooseSymbol)
                        {
                            //string gameObjectNameForChosenSymbol = CommonMethods.GetObjectName(touch);
                            //GameObject gameObjectForChosenSymbol = CommonMethods.GetObjectByName(gameObjectNameForChosenSymbol);

                            //string newSymbol = CommonMethods.GetCubePlayText(gameObjectForChosenSymbol);

                            //GameConfigurationPlayerSymbolCommonMethods.ChangeSymbolForPlayer(newSymbol, _tagConfigurationPlayerSymbolChange);

                            //GameObject gameObject = CommonMethods.GetObjectByTagName(_tagConfigurationPlayerSymbolChange);
                            //CommonMethods.ChangeTagForGameObject(gameObject, _tagConfigurationPlayerSymbolDefaultSymbol);

                            //GameConfigurationPlayerSymbolCommonMethods.ChangeChosenSymbolForPlayer(touch, _tagConfigurationPlayerSymbolChange, _tagConfigurationPlayerSymbolDefaultSymbol);

                            //GameConfigurationPlayerSymbolButtonsActions.ChangeChosenSymbolForPlayer(touch);


                            //GameConfigurationPlayerSymbolButtonsActions.DestroyButton(_tableWithSymbolsBase);
                            // GameConfigurationPlayerSymbolButtonsActions.DestroyButtons(_tableWitSymbols);
                            ////GameConfigurationPlayerSymbolButtonsActions.DestroyTable3D(_buttonBackToConfiguration);
                            // GameConfigurationPlayerSymbolButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration);
                            GameConfigurationPlayerSymbolButtonsActions.DestroyButtons(_tableWitSymbols, _buttonsMoreSpecificConfiguration);


                            //GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsWithPlayers);
                            //GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsWithSymbols);
                            //GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsBackAndSave);

                           //GameConfigurationPlayerSymbolButtonsActions.UnhideConfigurationBaseButtons(_configurationBaseButtons, touch);
                            GameConfigurationPlayerSymbolButtonsActions.UnhideConfigurationBaseButtons(_configurationBaseButtons, touch);

                            //GameConfigurationPlayerSymbolButtonsActions.HideButtonBackToConfiguration(_buttonBackToConfiguration);

                        }


                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonBackToConfiguration)
                        {
                            //GameObject gameObject = CommonMethods.GetObjectByTagName(_tagConfigurationPlayerSymbolChange);
                            //CommonMethods.ChangeTagForGameObject(gameObject, _tagConfigurationPlayerSymbolDefaultSymbol);
                            
                            //GameConfigurationPlayerSymbolCommonMethods.ChangeGameObjectTag(_tagConfigurationPlayerSymbolChange, _tagConfigurationPlayerSymbolDefaultSymbol);
                            //GameConfigurationPlayerSymbolButtonsActions.ChangeTagForPlayerDefaultSymbol();

                            //GameConfigurationPlayerSymbolButtonsActions.DestroyButtons(_tableWithSymbolsBase);
                            //GameConfigurationPlayerSymbolButtonsActions.DestroyButtons(_tableWitSymbols);
                            //GameConfigurationPlayerSymbolButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration);
                            GameConfigurationPlayerSymbolButtonsActions.DestroyButtons(_tableWitSymbols, _buttonsMoreSpecificConfiguration);

                            //GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsWithPlayers);
                            //GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsWithSymbols);
                            //GameConfigurationPlayerSymbolButtonsActions.UnhideConfiguration(_buttonsBackAndSave);

                            GameConfigurationPlayerSymbolButtonsActions.UnhideConfigurationBaseButtons(_configurationBaseButtons);

                            //GameConfigurationPlayerSymbolButtonsActions.HideButtonBackToConfiguration(_buttonBackToConfiguration);

                        }


                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonSave)
                        {
                            _tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(_buttonsWithSymbols);
                            ConfigurationPlayerSymbolTableWitPlayersChosenSymbols = _tableWitPlayersChosenSymbols;

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
