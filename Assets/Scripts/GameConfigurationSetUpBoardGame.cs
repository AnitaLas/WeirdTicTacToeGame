using Assets.Scripts.GameDictionaries;
using System.Collections.Generic;
using UnityEditor.SearchService;
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
       // public static int ConfigurationBoardGameLenghtToCheckMax { get; set; }

        public static int numberOfPlayers = 2;
        public static int numberOfRows = 3;
        public static int numberOfColumns = 3;
        public static int lenghtToCheck = 3;
        public static int lenghtToCheckMax;// = 3;




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

        Dictionary<int, string> configurationBoardGameDictionaryTag = GameDictionariesCommon.DictionaryTagConfigurationBoardGame();

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
        private string[] _tagConfigurationBoardGameHideOrUnhide = new string[10];
        private string[] _tableWithChangedNumber = new string[3];

        Dictionary<int, string> scenceDictionary = GameDictionariesCommon.DictionaryScence();

        private string _sceneConfigurationPlayersSymbols;

        private static bool isGame2D = true;

        private static int _numberOfRowsForTableNumber = 3;
        private static int _numberOfColumnsForTableNumber = 3;
        private static int _numberOfDepths = 1;

        public Touch touch;
        private Camera mainCamera;


        //private void Awake()
        //{
        //    DontDestroyOnLoad(gameObject);
        //}


        void Start()
        {
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
            
            

            _sceneConfigurationPlayersSymbols = scenceDictionary[2];

            // configuration player
            _tableWithNumberForPlayersBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, _numberOfDepths, _numberOfRowsForTableNumber, _numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            _tableWithNumberForPlayers = GameConfigurationTableForPlayers.CreateTableForPlayers(_tableWithNumberForPlayersBase, _tagConfigurationBoardGameTableNumberPlayers, _tagConfigurationBoardGameInactiveField);

            // configuration rows
            _tableWithNumberForRowsBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, _numberOfDepths, _numberOfRowsForTableNumber, _numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            _tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(_tableWithNumberForRowsBase, _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
            
            // configuration columns
            _tableWithNumberForColumnsBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, _numberOfDepths, _numberOfRowsForTableNumber, _numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            _tableWithNumberForColumns = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(_tableWithNumberForColumnsBase, _tagConfigurationBoardGameTableNumberColumns, _tagConfigurationBoardGameInactiveField);


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
                            GameConfigurationCommonMethods.UnhideTableWithNumber(_tableWithNumberForPlayers);
                           // GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                            GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameHideOrUnhide);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberPlayers)
                        {
                            numberOfPlayers = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_tableWithNumberForPlayers, gameObjectName, _tagConfigurationBoardGameChangeNumberPlayers);

                            GameConfigurationCommonMethods.HideTableWithNumber(_tableWithNumberForPlayers);
                           // GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameHideOrUnhide);

                        }

                        // rows
                        if (gameObjectTag == _tagConfigurationBoardGameRows || gameObjectTag == _tagConfigurationBoardGameChangeNumberRows)
                        {                        
                            GameConfigurationCommonMethods.UnhideTableWithNumber(_tableWithNumberForRows);
                            //GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameHideOrUnhide);
                            GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameHideOrUnhide);
                        }
  
                       

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberRows)
                        {
                            numberOfRows = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_tableWithNumberForRows, gameObjectName, _tagConfigurationBoardGameChangeNumberRows);

                            GameConfigurationCommonMethods.HideTableWithNumber(_tableWithNumberForRows);
                            // GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameHideOrUnhide);

                            GameConfigurationTableForLenghtToCheck.VerifyAndSetUpNewMaxLength(_tableWithChangedNumber);
                                
                        }
                        
                        // columns
                        if (gameObjectTag == _tagConfigurationBoardGameColumns || gameObjectTag == _tagConfigurationBoardGameChangeNumberColumns)
                        {
                            GameConfigurationCommonMethods.UnhideTableWithNumber(_tableWithNumberForColumns);
                            //GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                            GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameHideOrUnhide);
                        
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberColumns)
                        {
                            numberOfColumns = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_tableWithNumberForColumns, gameObjectName, _tagConfigurationBoardGameChangeNumberColumns);

                            GameConfigurationCommonMethods.HideTableWithNumber(_tableWithNumberForColumns);
                            //GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameHideOrUnhide);

                            GameConfigurationTableForLenghtToCheck.VerifyAndSetUpNewMaxLength(_tableWithChangedNumber);
                        }


                        // lenght to check
                        if (gameObjectTag == _tagConfigurationBoardGameLenghtToCheck || gameObjectTag == _tagConfigurationBoardGameChangeNumberLenghtToCheck)
                        {

                            if (_tableWithNumberForLenghtToCheckBase != null)
                            {
                                GameConfigurationTableForLenghtToCheck.DestroyTable(_tableWithNumberForLenghtToCheckBase);
                                GameConfigurationTableForLenghtToCheck.DestroyTable(_tableWithNumberForLenghtToCheck);
                            }
                            

                            _tableWithNumberForLenghtToCheckBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, _numberOfDepths, _numberOfRowsForTableNumber, _numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);

                            lenghtToCheckMax = GameConfigurationTableForLenghtToCheck.GetLenghtToCheckMax(_tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameChangeNumberColumns);
                            _tableWithNumberForLenghtToCheck = GameConfigurationTableForLenghtToCheck.CreateTableForMaxLenghtToCheck(_tableWithNumberForLenghtToCheckBase, _tagConfigurationBoardGameTableNumberLenghtToCheck, _tagConfigurationBoardGameInactiveField, lenghtToCheckMax);
                            
                            
                           GameConfigurationCommonMethods.UnhideTableWithNumber(_tableWithNumberForLenghtToCheck);
                          // GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                           GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameHideOrUnhide);
                        
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberLenghtToCheck)
                        {
                            lenghtToCheck = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_tableWithNumberForLenghtToCheck, gameObjectName, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                            GameConfigurationCommonMethods.HideTableWithNumber(_tableWithNumberForLenghtToCheck);
                            //GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameHideOrUnhide);

                        }

                        

                        // ---

                        if (gameObjectTag == _tagConfigurationBoardGameButtonSave)
                        {
                            ConfigurationBoardGameNumberOfRows = numberOfRows;
                            ConfigurationBoardGameNumberOfColumns = numberOfColumns;
                            ConfigurationBoardGameNumberOfPlayers = numberOfPlayers;
                            ConfigurationBoardGameLenghtToCheck = lenghtToCheck;

                            SceneManager.LoadScene(_sceneConfigurationPlayersSymbols);

                           

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
