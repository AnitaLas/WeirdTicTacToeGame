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




        GameObject[,,] tableWithNumberForRowsBase;
        GameObject[,,] tableWithNumberForRows;
        GameObject[,,] tableWithNumberForColumnsBase;
        GameObject[,,] tableWithNumberForColumns;
        GameObject[,,] tableWithNumberForPlayersBase;
        GameObject[,,] tableWithNumberForPlayers;
        GameObject[,,] tableWithNumberForLenghtToCheckBase;
        GameObject[,,] tableWithNumberForLenghtToCheck;
        GameObject[,,] tableWithNumberForLenghtToCheck2;


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
        // private string numberOfRows2;

        Dictionary<int, string> scenceDictionary = GameDictionariesCommon.DictionaryScence();

        private string _sceneConfigurationPlayersSymbols;

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

            _sceneConfigurationPlayersSymbols = scenceDictionary[2];

            // configuration player
            tableWithNumberForPlayersBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberForPlayers = GameConfigurationTableForPlayers.CreateTableForPlayers(tableWithNumberForPlayersBase, _tagConfigurationBoardGameTableNumberPlayers, _tagConfigurationBoardGameInactiveField);

            // configuration rows
            tableWithNumberForRowsBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumberForRowsBase, _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
            
            // configuration columns
            tableWithNumberForColumnsBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberForColumns = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumberForColumnsBase, _tagConfigurationBoardGameTableNumberColumns, _tagConfigurationBoardGameInactiveField);

            // configuration lenght
           // tableWithNumberForPlayers = GameConfigurationTableForPlayers.CreateTableForPlayers(tableWithNumber);
            //tableWithNumberForLenghtToCheckBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            //tableWithNumberForLenghtToCheck = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumberForLenghtToCheckBase, _tagConfigurationBoardGameTableNumberLenghtToCheck, _tagConfigurationBoardGameInactiveField);
            //tableWithNumberForLenghtToCheck = GameConfigurationTableForLenghtToCheck.CreateTableForMaxLenghtToCheck(tableWithNumberForLenghtToCheckBase, _tagConfigurationBoardGameTableNumberLenghtToCheck, _tagConfigurationBoardGameInactiveField, 10);

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
                            GameConfigurationCommonMethods.UnhideTableWithNumber(tableWithNumberForPlayers);
                            GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberPlayers)
                        {
                            //Debug.Log(" test 2a  ");
                            numberOfPlayers = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(tableWithNumberForPlayers, gameObjectName, _tagConfigurationBoardGameChangeNumberPlayers);

                            GameConfigurationCommonMethods.HideTableWithNumber(tableWithNumberForPlayers);
                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                        }

                        // rows
                        if (gameObjectTag == _tagConfigurationBoardGameRows || gameObjectTag == _tagConfigurationBoardGameChangeNumberRows)
                        {
                           // Debug.Log(" test 1  ");
                           // tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumber, _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
                            GameConfigurationCommonMethods.UnhideTableWithNumber(tableWithNumberForRows);
                            GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                        }
  
                       

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberRows)
                        {
                            numberOfRows = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(tableWithNumberForRows, gameObjectName, _tagConfigurationBoardGameChangeNumberRows);

                           

                            GameConfigurationCommonMethods.HideTableWithNumber(tableWithNumberForRows);
                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                            Debug.Log("test 1");
                            GameObject[] GameObjectsRowsNumber = CommonMethods.GetObjectByTagName(_tagConfigurationBoardGameChangeNumberRows);
                            GameObject GameObjectRowsNumber = GameObjectsRowsNumber[0];
                            string rowsNumberString = CommonMethods.GetCubePlayText(GameObjectRowsNumber);

                            int rowsNumber = CommonMethods.ConvertStringToInt(rowsNumberString);



                            GameObject[] GameObjectsColumnsNumber = CommonMethods.GetObjectByTagName(_tagConfigurationBoardGameChangeNumberColumns);
                            GameObject GameObjectColumnsNumber = GameObjectsColumnsNumber[0];
                            string columnsNumberString = CommonMethods.GetCubePlayText(GameObjectColumnsNumber);

                            int columnsNumber = CommonMethods.ConvertStringToInt(columnsNumberString);


                            GameObject[] GameObjectsLenghtToCheck = CommonMethods.GetObjectByTagName(_tagConfigurationBoardGameChangeNumberLenghtToCheck);
                            GameObject GameObjectLenghtToCheck = GameObjectsLenghtToCheck[0];
                            string lenghtToCheckString = CommonMethods.GetCubePlayText(GameObjectLenghtToCheck);
                            int currentLenghtToCheck = CommonMethods.ConvertStringToInt(lenghtToCheckString);


                            GameConfigurationTableForLenghtToCheck.VerifyAndSetUpNewMaxLength(rowsNumber, columnsNumber, currentLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                        }

                        
                        // columns
                        if (gameObjectTag == _tagConfigurationBoardGameColumns || gameObjectTag == _tagConfigurationBoardGameChangeNumberColumns)
                        {
                            //Debug.Log(" test 1  ");
                            
                            GameConfigurationCommonMethods.UnhideTableWithNumber(tableWithNumberForColumns);
                            GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberColumns)
                        {
                            numberOfColumns = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(tableWithNumberForColumns, gameObjectName, _tagConfigurationBoardGameChangeNumberColumns);

                            GameConfigurationCommonMethods.HideTableWithNumber(tableWithNumberForColumns);
                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                        }







                        // lenght

                        if (gameObjectTag == _tagConfigurationBoardGameLenghtToCheck || gameObjectTag == _tagConfigurationBoardGameChangeNumberLenghtToCheck)
                        {
                            //Debug.Log(" test 1  ")

                            //for (int i = 0; i < tableWithNumberForLenghtToCheck.GetLength(0); i++)
                            //{
                            //    for (int j = 0; j < tableWithNumberForLenghtToCheck.GetLength(1); j++)
                            //    {
                            //        for (int z = 0; z < tableWithNumberForLenghtToCheck.GetLength(2); z++)
                            //        {


                            //            GameObject toRemove = tableWithNumberForLenghtToCheck[i,j,z];
                            //            Destroy(toRemove);

                            //        }
                            //    }
                            //}
                            if (tableWithNumberForLenghtToCheckBase != null)
                            {
                                GameConfigurationTableForLenghtToCheck.DestroyTable(tableWithNumberForLenghtToCheckBase);
                                GameConfigurationTableForLenghtToCheck.DestroyTable(tableWithNumberForLenghtToCheck);
                            }
                            

                            tableWithNumberForLenghtToCheckBase = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);

                            lenghtToCheckMax = GameConfigurationTableForLenghtToCheck.GetLenghtToCheckMax(_tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameChangeNumberColumns);
                            Debug.Log("lenghtToCheckMax = " + lenghtToCheckMax);
                            tableWithNumberForLenghtToCheck = GameConfigurationTableForLenghtToCheck.CreateTableForMaxLenghtToCheck(tableWithNumberForLenghtToCheckBase, _tagConfigurationBoardGameTableNumberLenghtToCheck, _tagConfigurationBoardGameInactiveField, lenghtToCheckMax);
                            
                            
                           GameConfigurationCommonMethods.UnhideTableWithNumber(tableWithNumberForLenghtToCheck);
                           GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                        
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberLenghtToCheck)
                        {
                            lenghtToCheck = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(tableWithNumberForLenghtToCheck, gameObjectName, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                            GameConfigurationCommonMethods.HideTableWithNumber(tableWithNumberForLenghtToCheck);
                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameColumns, _tagConfigurationBoardGameChangeNumberColumns, _tagConfigurationBoardGamePlayers, _tagConfigurationBoardGameChangeNumberPlayers, _tagConfigurationBoardGameLenghtToCheck, _tagConfigurationBoardGameChangeNumberLenghtToCheck);

                        }

                        

                        // ---

                        if (gameObjectTag == _tagConfigurationBoardGameButtonSave)
                        {
                            //Debug.Log(" test 1 ");
                            ConfigurationBoardGameNumberOfRows = numberOfRows;
                            ConfigurationBoardGameNumberOfColumns = numberOfColumns;
                            ConfigurationBoardGameNumberOfPlayers = numberOfPlayers;
                            ConfigurationBoardGameLenghtToCheck = lenghtToCheck;
                            //ConfigurationBoardGameLenghtToCheckMax = lenghtToCheckMax;
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
