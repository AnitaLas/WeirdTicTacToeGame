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
        public static int ConfigurationBoardGameLenghtToCheckMax { get; set; }

        public static int numberOfPlayers = 2;
        public static int numberOfRows = 3;
        public static int numberOfColumns = 3;
        public static int lenghtToCheck = 3;
        public static int lenghtToCheckMax = 3;




        GameObject[,,] tableWithNumberForRowsBase;
        GameObject[,,] tableWithNumberForRows;
        GameObject[,,] tableWithNumberForColumnsBase;
        GameObject[,,] tableWithNumberForColumns;
        GameObject[,,] tableWithNumberForPlayersBase;
        GameObject[,,] tableWithNumberForPlayers;
        GameObject[,,] tableWithNumberForLenghtToCheckBase;
        GameObject[,,] tableWithNumberForLenghtToCheck;


        public GameObject prefabCubePlayForTableNumber;

        public Material[] prefabCubePlayDefaultColour;

        Dictionary<int, string> configurationDictionaryTag = GameDictionariesCommon.DictionaryConfiguration();

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
        // private string numberOfRows2;


        private static bool isGame2D = true;

        private static int numberOfRowsForTableNumber = 3;
        private static int numberOfColumnsForTableNumber = 3;
        private static int numberOfDepths = 1;

        public Touch touch;
        private Camera mainCamera;

        //string[] tagConfigurationBoardGame;

        //private void Awake()
        //{
        //    DontDestroyOnLoad(gameObject);
        //}


        void Start()
        {
            _tagConfigurationBoardGameButtonSave = configurationDictionaryTag[1];
            _tagConfigurationBoardGameButtonBack = configurationDictionaryTag[2];
            _tagConfigurationBoardGameTableNumberRows = configurationDictionaryTag[3];
            _tagConfigurationBoardGameTableNumberColumns = configurationDictionaryTag[4];
            _tagConfigurationBoardGameRows = configurationDictionaryTag[5];
            _tagConfigurationBoardGameColumns = configurationDictionaryTag[6];
            _tagConfigurationBoardGameChangeNumberRows = configurationDictionaryTag[7];
            _tagConfigurationBoardGameChangeNumberColumns = configurationDictionaryTag[8];

            _tagConfigurationBoardGamePlayers = configurationDictionaryTag[9];
            _tagConfigurationBoardGameChangeNumberPlayers = configurationDictionaryTag[10];
            _tagConfigurationBoardGameTableNumberPlayers = configurationDictionaryTag[11];

            _tagConfigurationBoardGameLenghtToCheck = configurationDictionaryTag[12];
            _tagConfigurationBoardGameChangeNumberLenghtToCheck = configurationDictionaryTag[13];
            _tagConfigurationBoardGameTableNumberLenghtToCheck = configurationDictionaryTag[14];

            _tagConfigurationBoardGameInactiveField = configurationDictionaryTag[20];

            
            //tagConfigurationBoardGame[0] = _tagConfigurationBoardGameButtonSave;
            //tagConfigurationBoardGame[1] = _tagConfigurationBoardGameButtonBack;
            //tagConfigurationBoardGame[2] = _tagConfigurationBoardGameTableNumberRows;

            // configuration player
            tableWithNumberForPlayersBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberForPlayers = GameConfigurationTableForPlayers.CreateTableForPlayers(tableWithNumberForPlayersBase, _tagConfigurationBoardGameTableNumberPlayers, _tagConfigurationBoardGameInactiveField);

            // configuration rows
            tableWithNumberForRowsBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumberForRowsBase, _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
            
            // configuration columns
            tableWithNumberForColumnsBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberForColumns = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumberForColumnsBase, _tagConfigurationBoardGameTableNumberColumns, _tagConfigurationBoardGameInactiveField);

            // configuration players
            //tableWithNumberForPlayers = GameConfigurationTableForPlayers.CreateTableForPlayers(tableWithNumber);
            tableWithNumberForLenghtToCheckBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberForLenghtToCheck = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumberForLenghtToCheckBase, _tagConfigurationBoardGameTableNumberLenghtToCheck, _tagConfigurationBoardGameInactiveField);

            //tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRows(prefabCubePlayForTableNumber, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour,  isGame2D,  _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
            //tableWithNumberForRows = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
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
                        //Debug.Log(" gameObjectName = " + gameObjectName);

                        //GameObject cubePlay = CommonMethods.GetObjectByTagName(gameObjectTag);
                        //Debug.Log(" test 0 ");

                        // players
                        if (gameObjectTag == _tagConfigurationBoardGamePlayers || gameObjectTag == _tagConfigurationBoardGameChangeNumberPlayers)
                        {
                           // Debug.Log(" test 1  ");
                            // tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumber, _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
                            GameConfiguration.UnhideTableWithNumber(tableWithNumberForPlayers);
                            GameConfiguration.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberPlayers)
                        {

                            numberOfPlayers = GameConfiguration.SetUpChosenNumberForConfiguration(tableWithNumberForPlayers, gameObjectName, _tagConfigurationBoardGameChangeNumberPlayers);

                            GameConfiguration.HideTableWithNumber(tableWithNumberForPlayers);
                            GameConfiguration.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                        }

                        // rows
                        if (gameObjectTag == _tagConfigurationBoardGameRows || gameObjectTag == _tagConfigurationBoardGameChangeNumberRows)
                        {
                           // Debug.Log(" test 1  ");
                           // tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumber, _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
                            GameConfiguration.UnhideTableWithNumber(tableWithNumberForRows);
                            GameConfiguration.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberRows)
                        {
                            numberOfRows = GameConfiguration.SetUpChosenNumberForConfiguration(tableWithNumberForRows, gameObjectName, _tagConfigurationBoardGameChangeNumberRows);

                            //lenghtToCheckMax = GameConfigurationTableForSetUp.SetUpLenghtToCheckMax(_tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                            GameConfiguration.HideTableWithNumber(tableWithNumberForRows);
                            GameConfiguration.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                        }

                        
                        // columns
                        if (gameObjectTag == _tagConfigurationBoardGameColumns || gameObjectTag == _tagConfigurationBoardGameChangeNumberColumns)
                        {
                            //Debug.Log(" test 1  ");
                            
                            GameConfiguration.UnhideTableWithNumber(tableWithNumberForColumns);
                            GameConfiguration.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberColumns)
                        {
                            numberOfColumns = GameConfiguration.SetUpChosenNumberForConfiguration(tableWithNumberForColumns, gameObjectName, _tagConfigurationBoardGameChangeNumberColumns);

                            GameConfiguration.HideTableWithNumber(tableWithNumberForColumns);
                            GameConfiguration.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                        }

                        // lenght
                        if (gameObjectTag == _tagConfigurationBoardGameLenghtToCheck || gameObjectTag == _tagConfigurationBoardGameChangeNumberLenghtToCheck)
                        {
                            //Debug.Log(" test 1  ");

                            GameConfiguration.UnhideTableWithNumber(tableWithNumberForLenghtToCheck);
                            GameConfiguration.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberLenghtToCheck)
                        {
                            lenghtToCheck = GameConfiguration.SetUpChosenNumberForConfiguration(tableWithNumberForLenghtToCheck, gameObjectName, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                            GameConfiguration.HideTableWithNumber(tableWithNumberForLenghtToCheck);
                            GameConfiguration.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                        }




                        // ---

                        if (gameObjectTag == _tagConfigurationBoardGameButtonSave)
                        {
                            //Debug.Log(" test 1 ");
                            ConfigurationBoardGameNumberOfRows = numberOfRows;
                            ConfigurationBoardGameNumberOfColumns = numberOfColumns;
                            ConfigurationBoardGameNumberOfPlayers = numberOfPlayers;
                            ConfigurationBoardGameLenghtToCheck = lenghtToCheck;
                            ConfigurationBoardGameLenghtToCheckMax = lenghtToCheckMax;
                            SceneManager.LoadScene("SceneGame");

                           

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
