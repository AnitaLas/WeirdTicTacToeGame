using Assets.Scripts.Buttons;
using Assets.Scripts.GameConfiguration.GameConfigurationBase;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.Scenes;
//using NUnit.Framework;
//using NUnit.Framework.Internal;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfigurationSetUpBoardGame : MonoBehaviour
    {
        public static int ConfigurationBoardGameNumberOfPlayers { get; set; }
        public static int ConfigurationBoardGameNumberOfRows { get; set; }
        public static int ConfigurationBoardGameNumberOfColumns { get; set; }
        public static int ConfigurationBoardGameLenghtToCheck { get; set; }


        //public static int numberOfPlayers = 2;
        //public static int numberOfRows = 3;
        //public static int numberOfColumns = 3;
        //public static int lenghtToCheck = 3;
        public static int lenghtToCheckMax;

        public static int numberOfPlayers;
        public static int numberOfRows;
        public static int numberOfColumns;
        public static int lenghtToCheck;


        // ---

        private GameObject[,,] _tableWithNumberForRowsBase;
        private GameObject[,,] _tableWithNumberForRows;
        private GameObject[,,] _tableWithNumberForColumnsBase;
        private GameObject[,,] _tableWithNumberForColumns;
        private GameObject[,,] _tableWithNumberForPlayersBase;
        private GameObject[,,] _tableWithNumberForPlayers;
        private GameObject[,,] _tableWithNumberForLenghtToCheckBase;
        private GameObject[,,] _tableWithNumberForLenghtToCheck;
        private GameObject[,,] _tableWithNumberForLenghtToCheck2;


        public GameObject prefabCubePlayForTableNumber;

        public Material[] prefabCubePlayDefaultColour;

        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsBackColour;

        public Material[] prefabCubePlayButtonsNumberColour;

        Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();

        private string _tagConfigurationBoardGameButtonSave;
        private string _tagConfigurationBoardGameButtonBack;
        private string _tagConfigurationBoardGameTableNumberRows;
        private string _tagConfigurationBoardGameTableNumberColumns;
        private string _tagConfigurationBoardGameRows;
        private string _tagConfigurationBoardGameColumns;
        private string _tagConfigurationBoardGameChangeNumberRows;
        private string _tagConfigurationBoardGameChangeNumberColumns;
        private string _tagConfigurationBoardGameInactiveField;
        private string _tagConfigurationBoardGamePlayers;
        private string _tagConfigurationBoardGameChangeNumberPlayers;
        private string _tagConfigurationBoardGameTableNumberPlayers;
        private string _tagConfigurationBoardGameLenghtToCheck;
        private string _tagConfigurationBoardGameChangeNumberLenghtToCheck;
        private string _tagConfigurationBoardGameTableNumberLenghtToCheck;
        private string _tagConfigurationBoardGameButtonBackToConfiguration;
        private string[] _tagConfigurationBoardGameHideOrUnhide = new string[10];
        private string[] _tableWithChangedNumber = new string[3];

        //Dictionary<int, string> scenceDictionary = GameDictionariesCommon.DictionaryScence();

        //private string _sceneConfigurationPlayersSymbols;

        private static bool isGame2D = true;

        private static int _numberOfRowsForTableNumber = 3;
        private static int _numberOfColumnsForTableNumber = 3;
        private static int _numberOfDepths = 1;

        public Touch touch;
        private Camera mainCamera;

        private List<GameObject[,,]> _buttonsAll;
        private List<GameObject[,,]> _tablesWithNumberAll;
        private GameObject[,,] _buttonBackToConfiguration;
        //private void Awake()
        //{
        //    DontDestroyOnLoad(gameObject);
        //}


        void Start()
        {
            numberOfPlayers = 2;
            numberOfRows = 3;
            numberOfColumns = 3;
            lenghtToCheck = 3;

            _tagConfigurationBoardGameButtonSave = configurationBoardGameDictionaryTag[1];
            _tagConfigurationBoardGameButtonBack = configurationBoardGameDictionaryTag[2];
            _tagConfigurationBoardGameTableNumberRows = configurationBoardGameDictionaryTag[3];
            _tagConfigurationBoardGameTableNumberColumns = configurationBoardGameDictionaryTag[4];
            _tagConfigurationBoardGameRows = configurationBoardGameDictionaryTag[5];
            _tagConfigurationBoardGameColumns = configurationBoardGameDictionaryTag[6];
            _tagConfigurationBoardGameChangeNumberRows = configurationBoardGameDictionaryTag[7];
            _tagConfigurationBoardGameChangeNumberColumns = configurationBoardGameDictionaryTag[8];

            _tagConfigurationBoardGamePlayers = configurationBoardGameDictionaryTag[9];
            _tagConfigurationBoardGameChangeNumberPlayers = configurationBoardGameDictionaryTag[10];
            _tagConfigurationBoardGameTableNumberPlayers = configurationBoardGameDictionaryTag[11];

            _tagConfigurationBoardGameLenghtToCheck = configurationBoardGameDictionaryTag[12];
            _tagConfigurationBoardGameChangeNumberLenghtToCheck = configurationBoardGameDictionaryTag[13];
            _tagConfigurationBoardGameTableNumberLenghtToCheck = configurationBoardGameDictionaryTag[14];

            _tagConfigurationBoardGameInactiveField = configurationBoardGameDictionaryTag[20];
            _tagConfigurationBoardGameButtonBackToConfiguration = configurationBoardGameDictionaryTag[21];
 
            // ---
            _tagConfigurationBoardGameHideOrUnhide[0] = _tagConfigurationBoardGameButtonSave;
            _tagConfigurationBoardGameHideOrUnhide[1] = _tagConfigurationBoardGameButtonBack;
            _tagConfigurationBoardGameHideOrUnhide[2] = _tagConfigurationBoardGameRows;
            _tagConfigurationBoardGameHideOrUnhide[3] = _tagConfigurationBoardGameChangeNumberRows;
            _tagConfigurationBoardGameHideOrUnhide[4] = _tagConfigurationBoardGameColumns;
            _tagConfigurationBoardGameHideOrUnhide[5] = _tagConfigurationBoardGameChangeNumberColumns;
            _tagConfigurationBoardGameHideOrUnhide[6] = _tagConfigurationBoardGamePlayers;
            _tagConfigurationBoardGameHideOrUnhide[7] = _tagConfigurationBoardGameChangeNumberPlayers;
            _tagConfigurationBoardGameHideOrUnhide[8] = _tagConfigurationBoardGameLenghtToCheck;
            _tagConfigurationBoardGameHideOrUnhide[9] = _tagConfigurationBoardGameChangeNumberLenghtToCheck;

            // ---
            _tableWithChangedNumber[0] = _tagConfigurationBoardGameChangeNumberRows;
            _tableWithChangedNumber[1] = _tagConfigurationBoardGameChangeNumberColumns;
            _tableWithChangedNumber[2] = _tagConfigurationBoardGameChangeNumberLenghtToCheck;
            
            

            //_sceneConfigurationPlayersSymbols = scenceDictionary[2];

            // configuration player
            _tableWithNumberForPlayersBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, _numberOfDepths, _numberOfRowsForTableNumber, _numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            _tableWithNumberForPlayers = GameConfigurationTableForPlayers.CreateTableForPlayers(_tableWithNumberForPlayersBase, _tagConfigurationBoardGameTableNumberPlayers, _tagConfigurationBoardGameInactiveField);

            // configuration rows
            _tableWithNumberForRowsBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, _numberOfDepths, _numberOfRowsForTableNumber, _numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            _tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(_tableWithNumberForRowsBase, _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
            
            // configuration columns
            _tableWithNumberForColumnsBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, _numberOfDepths, _numberOfRowsForTableNumber, _numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            _tableWithNumberForColumns = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(_tableWithNumberForColumnsBase, _tagConfigurationBoardGameTableNumberColumns, _tagConfigurationBoardGameInactiveField);

            //_buttonsText = new List<GameObject[,,]>();
            _buttonsAll = GameConfigurationButtonsCreate.GameConfigurationCreateButtons(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, isGame2D);
            _buttonBackToConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonBackToConfiguration(prefabCubePlayForTableNumber, prefabCubePlayButtonsBackColour, isGame2D);

            _tablesWithNumberAll = new List<GameObject[,,]>();
            _tablesWithNumberAll.Insert(0, _tableWithNumberForPlayers);
            _tablesWithNumberAll.Insert(1, _tableWithNumberForRows);
            _tablesWithNumberAll.Insert(2, _tableWithNumberForColumns);
            //_tablesWithNumberAll.Insert(3, _tableWithNumberForColumns);
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
                       
                        // players
                        if (gameObjectTag == _tagConfigurationBoardGamePlayers || gameObjectTag == _tagConfigurationBoardGameChangeNumberPlayers)
                        {
                            GameConfigurationButtonsAction.UnhideTableWithNumber(_tableWithNumberForPlayers);
                            GameConfigurationButtonsAction.UnhideButtonBackToConfiguration(_buttonBackToConfiguration);
                            GameConfigurationButtonsAction.HideConfiguration(_buttonsAll);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberPlayers)
                        {
                            numberOfPlayers = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_tableWithNumberForPlayers, gameObjectName, _tagConfigurationBoardGameChangeNumberPlayers);

                            GameConfigurationButtonsAction.HideTableWithNumber(_tableWithNumberForPlayers);
                            GameConfigurationButtonsAction.HideButtonBackToConfiguration(_buttonBackToConfiguration);
                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsAll);

                        }

                        // rows
                        if (gameObjectTag == _tagConfigurationBoardGameRows || gameObjectTag == _tagConfigurationBoardGameChangeNumberRows)
                        {
                            GameConfigurationButtonsAction.UnhideTableWithNumber(_tableWithNumberForRows);
                            GameConfigurationButtonsAction.UnhideButtonBackToConfiguration(_buttonBackToConfiguration);
                            GameConfigurationButtonsAction.HideConfiguration(_buttonsAll);
                        }
  
                       

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberRows)
                        {
                            numberOfRows = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_tableWithNumberForRows, gameObjectName, _tagConfigurationBoardGameChangeNumberRows);

                            GameConfigurationButtonsAction.HideTableWithNumber(_tableWithNumberForRows);
                            GameConfigurationButtonsAction.HideButtonBackToConfiguration(_buttonBackToConfiguration);
                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsAll);

                            GameConfigurationTableForLenghtToCheck.VerifyAndSetUpNewMaxLength(_tableWithChangedNumber);
                                
                        }
                        
                        // columns
                        if (gameObjectTag == _tagConfigurationBoardGameColumns || gameObjectTag == _tagConfigurationBoardGameChangeNumberColumns)
                        {
                            GameConfigurationButtonsAction.UnhideTableWithNumber(_tableWithNumberForColumns);
                            GameConfigurationButtonsAction.HideConfiguration(_buttonsAll);
                            GameConfigurationButtonsAction.UnhideButtonBackToConfiguration(_buttonBackToConfiguration);


                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberColumns)
                        {
                            numberOfColumns = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_tableWithNumberForColumns, gameObjectName, _tagConfigurationBoardGameChangeNumberColumns);

                            GameConfigurationButtonsAction.HideTableWithNumber(_tableWithNumberForColumns);
                            GameConfigurationButtonsAction.HideButtonBackToConfiguration(_buttonBackToConfiguration);
                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsAll);

                            GameConfigurationTableForLenghtToCheck.VerifyAndSetUpNewMaxLength(_tableWithChangedNumber);
                        }


                        // lenght to check
                        if (gameObjectTag == _tagConfigurationBoardGameLenghtToCheck || gameObjectTag == _tagConfigurationBoardGameChangeNumberLenghtToCheck)
                        {

                            if (_tableWithNumberForLenghtToCheckBase != null)
                            {
                                GameConfigurationTableForLenghtToCheck.DestroyTable(_tableWithNumberForLenghtToCheckBase);
                                GameConfigurationTableForLenghtToCheck.DestroyTable(_tableWithNumberForLenghtToCheck);
                                _tablesWithNumberAll.RemoveAt(3);
                            }
                            

                            _tableWithNumberForLenghtToCheckBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, _numberOfDepths, _numberOfRowsForTableNumber, _numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
                           

                            lenghtToCheckMax = GameConfigurationTableForLenghtToCheck.GetLenghtToCheckMax(_tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameChangeNumberColumns);
                            _tableWithNumberForLenghtToCheck = GameConfigurationTableForLenghtToCheck.CreateTableForMaxLenghtToCheck(_tableWithNumberForLenghtToCheckBase, _tagConfigurationBoardGameTableNumberLenghtToCheck, _tagConfigurationBoardGameInactiveField, lenghtToCheckMax);
                            _tablesWithNumberAll.Insert(3, _tableWithNumberForLenghtToCheck);

                            GameConfigurationButtonsAction.UnhideTableWithNumber(_tableWithNumberForLenghtToCheck);
                            GameConfigurationButtonsAction.UnhideButtonBackToConfiguration(_buttonBackToConfiguration);
                            GameConfigurationButtonsAction.HideConfiguration(_buttonsAll);
                        
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberLenghtToCheck)
                        {
                            lenghtToCheck = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_tableWithNumberForLenghtToCheck, gameObjectName, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                            GameConfigurationButtonsAction.HideTableWithNumber(_tableWithNumberForLenghtToCheck);
                            GameConfigurationButtonsAction.HideButtonBackToConfiguration(_buttonBackToConfiguration);
                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsAll);

                        }

                        

                        // ---

                        if (gameObjectTag == _tagConfigurationBoardGameButtonSave)
                        {
                            ConfigurationBoardGameNumberOfRows = numberOfRows;
                            ConfigurationBoardGameNumberOfColumns = numberOfColumns;
                            ConfigurationBoardGameNumberOfPlayers = numberOfPlayers;
                            ConfigurationBoardGameLenghtToCheck = lenghtToCheck;

                            //SceneManager.LoadScene(_sceneConfigurationPlayersSymbols);
                            //CommonMethods.ChangeScene(_sceneConfigurationPlayersSymbols);

                            ScenesChange.GoToSceneConfigurationPlayersSymbols();

                        }

                        if (gameObjectTag == _tagConfigurationBoardGameButtonBack)
                        {
 
                            ScenesChange.GoToSceneStartGame();

                        }

                        if (gameObjectTag == _tagConfigurationBoardGameButtonBackToConfiguration)
                        {
                            GameConfigurationButtonsAction.HideVisibleTablesWithNumber(_tablesWithNumberAll);
                            GameConfigurationButtonsAction.HideButtonBackToConfiguration(_buttonBackToConfiguration);
                            GameConfigurationButtonsAction.UnhideConfiguration(_buttonsAll);

                        }

                    }
                }
            }


           // Cursor.SetCursor();


        }
                        //    public static void GoToPlayersSymbolsSetUp()
                        //{
                        //    Debug.Log(" GameConfigurationChangeScence ");
                        //    SceneManager.LoadScene("SceneGame");
                        //}



    }
}
