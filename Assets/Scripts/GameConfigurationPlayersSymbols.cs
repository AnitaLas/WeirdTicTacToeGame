using Assets.Scripts.GameConfiguration;
using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationPlayersSymbols : MonoBehaviour
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

        //private Dictionary<int, string> _configurationPlayersSymbolsDictionaryTag = GameDictionariesSceneConfigurationPlayerSymbols.DictionaryTagsNameConfigurationPlayersSymbols();

        private string _tagConfiguratioPlayerSymbolDefaultNumber;
        private string _tagConfigurationPlayerSymbolDefaultSymbol;
        private string _tagConfigurationPlayerSymbolChooseSymbol;

        private string _tagConfigurationPlayerSymbolButtonSave;
        private string _tagConfigurationPlayerSymbolButtonBack;
        private string _tagConfigurationPlayerSymbolButtonBackToConfiguration;

        //private Dictionary<int, string> _tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();

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
            _tagConfiguratioPlayerSymbolDefaultNumber = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolDefaultNumber();
            _tagConfigurationPlayerSymbolDefaultSymbol = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolDefaultSymbol();
            _tagConfigurationPlayerSymbolChooseSymbol = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolChooseSymbol();

            _tagConfigurationPlayerSymbolButtonSave = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolButtonSave();
            _tagConfigurationPlayerSymbolButtonBack = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolButtonBack();
            _tagConfigurationPlayerSymbolButtonBackToConfiguration = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonPlayerSymbolButtonBackToConfiguration();
            // ---
            _tagUntagged = GameConfigurationButtonsCommonButtonsTagName.GetTagNameUntagged();

            // ---
            _numberOfPlayers = GameConfigurationBoardGame.ConfigurationBoardGameNumberOfPlayers;




            // to fix one method not if
            if (_numberOfPlayers == 0)
            {
                _numberOfPlayers = 2;
            }



            //_numberOfPlayers = 2;
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
                        string gameObjectTag = GameCommonMethodsMain.GetObjectTag(touch);
                        string gameObjectName = GameCommonMethodsMain.GetObjectName(touch);

                        if (gameObjectTag != _tagUntagged)
                        {
                            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(gameObjectTag);
                        }
                        

                        if (gameObjectTag == _tagConfiguratioPlayerSymbolDefaultNumber || gameObjectTag == _tagConfigurationPlayerSymbolDefaultSymbol)
                        {
                            GameConfigurationPlayerSymbolButtonsActions.HideConfigurationBaseButtons(_configurationBaseButtons, gameObjectName);
                            
                            _buttonsMoreSpecificConfiguration = GameConfigurationPlayerSymbolButtonsCreate.GameConfigurationCreateButtonsBackAndPlayer( prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, _isGame2D);
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

                           // ScenesChangeMainMethods.GoToSceneGame();
                            ScenesChangeMainMethods.GoToSceneConfigurationChangePlayersSymbols();
                        }

                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonBack)
                        {
                            ScenesChangeMainMethods.GoToSceneConfigurationBoardGame();
                        }
                    }
                }
            }
        }
    }
}
