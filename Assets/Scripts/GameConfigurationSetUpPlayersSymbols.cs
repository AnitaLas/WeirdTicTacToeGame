using Assets.Scripts.GameConfiguration;
using Assets.Scripts.GameConfigurationPlayerSymbol;
using Assets.Scripts.GameDictionaries;
using System.Collections.Generic;
using UnityEngine;
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

        private bool _isGame2D = true;

        private Dictionary<int, string> _configurationPlayersSymbolsDictionaryTag = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagConfigurationPlayersSymbols();

        private string _tagConfiguratioPlayerSymbolDefaultNumber;
        private string _tagConfigurationPlayerSymbolDefaultSymbol;
        private string _tagConfigurationPlayerSymbolChooseSymbol;

        private string _tagConfigurationPlayerSymbolButtonSave;
        private string _tagConfigurationPlayerSymbolButtonBack;
        private string _tagConfigurationPlayerSymbolButtonBackToConfiguration;

        private Dictionary<int, string> _tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();

        private string _tagUntagged;

        private int _numberOfPlayers;

        private GameObject[,,] _tableWitSymbols;

        private string[] _tableWitPlayersChosenSymbols;

        private List<GameObject[,,]> _buttonsBackAndSave;
        private List<GameObject[,,]> _buttonsWithPlayers;
        private List<GameObject[,,]> _buttonsWithSymbols;
        private List<GameObject[,,]> _buttonBasePlayers;
        private List<List<GameObject[,,]>> _configurationBaseButtons;

        private List<GameObject[,,]> _buttonsMoreSpecificConfiguration;

        void Start()
        {
            _tagConfiguratioPlayerSymbolDefaultNumber = _configurationPlayersSymbolsDictionaryTag[1];
            _tagConfigurationPlayerSymbolDefaultSymbol = _configurationPlayersSymbolsDictionaryTag[2];
            _tagConfigurationPlayerSymbolChooseSymbol = _configurationPlayersSymbolsDictionaryTag[4];

            _tagConfigurationPlayerSymbolButtonSave = _configurationPlayersSymbolsDictionaryTag[6];
            _tagConfigurationPlayerSymbolButtonBack = _configurationPlayersSymbolsDictionaryTag[7];
            _tagConfigurationPlayerSymbolButtonBackToConfiguration = _configurationPlayersSymbolsDictionaryTag[8];

            // ---
            _tagUntagged = _tagCommonDictionary[1];

            // ---
            _numberOfPlayers = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfPlayers;        

            _buttonsWithPlayers = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonsWithPlayerNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D, _numberOfPlayers);
            _buttonsWithSymbols = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonsForPlayerSymbol(prefabCubePlay, prefabCubePlayButtonsNumberColour, _isGame2D, _numberOfPlayers);
            _buttonsBackAndSave = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, _isGame2D, _numberOfPlayers);
            _buttonBasePlayers = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationCreateInformationBaseButtonPlayers(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

            _configurationBaseButtons = new List<List<GameObject[,,]>>();

            _configurationBaseButtons.Insert(0, _buttonsWithPlayers);
            _configurationBaseButtons.Insert(1, _buttonsWithSymbols);
            _configurationBaseButtons.Insert(2, _buttonsBackAndSave);
            _configurationBaseButtons.Insert(3, _buttonBasePlayers); 
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
                            GameConfigurationPlayerSymbolButtonsActions.HideConfigurationBaseButtons(_configurationBaseButtons, gameObjectName);
                            
                            _buttonsMoreSpecificConfiguration = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationCreateButtonsBackAndPlayer( prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, _isGame2D, gameObjectName);
                            _tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(_buttonsWithSymbols);
                            _tableWitSymbols = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationPlayerSymbolCreateButtonsWithSymbolsToChose(prefabCubePlay, prefabSymbolPlayerMaterial, prefabSymbolPlayerMaterialInactiveField, _tableWitPlayersChosenSymbols, _isGame2D);
                        }

                        if (gameObjectTag == _tagConfigurationPlayerSymbolChooseSymbol)
                        {
                            GameConfigurationPlayerSymbolButtonsActions.DestroyButtons(_tableWitSymbols, _buttonsMoreSpecificConfiguration);
                            GameConfigurationPlayerSymbolButtonsActions.UnhideConfigurationBaseButtons(_configurationBaseButtons, touch);
                        }


                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonBackToConfiguration)
                        {
                            GameConfigurationPlayerSymbolButtonsActions.DestroyButtons(_tableWitSymbols, _buttonsMoreSpecificConfiguration);
                            GameConfigurationPlayerSymbolButtonsActions.UnhideConfigurationBaseButtons(_configurationBaseButtons);
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
