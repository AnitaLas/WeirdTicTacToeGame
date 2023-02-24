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

   
        public static int numberOfRows;
        public static int numberOfColumns;



        GameObject[,,] tableWithNumber;
        GameObject[,,] tableWithNumberForRows;
        GameObject[,,] tableWithNumberForColumns;
        GameObject[,,] tableWithNumberForPlayers;

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
            _tagConfigurationBoardGameInactiveField = configurationDictionaryTag[20];

            //tagConfigurationBoardGame[0] = _tagConfigurationBoardGameButtonSave;
            //tagConfigurationBoardGame[1] = _tagConfigurationBoardGameButtonBack;
            //tagConfigurationBoardGame[2] = _tagConfigurationBoardGameTableNumberRows;

            tableWithNumber = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsForTableNumber, numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumber, _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
           // tableWithNumberForColumns = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumber, _tagConfigurationBoardGameTableNumberColumns, _tagConfigurationBoardGameInactiveField);
            //tableWithNumberForPlayers = GameConfigurationTableForPlayers.CreateTableForPlayers(tableWithNumber);

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

                        // rows
                        if (gameObjectTag == _tagConfigurationBoardGameRows || gameObjectTag == _tagConfigurationBoardGameChangeNumberRows)
                        {
                            Debug.Log(" test 1  ");
                            GameConfiguration.UnhideTableWithNumber(tableWithNumberForRows);
                            GameConfiguration.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberRows)
                        {
                            Debug.Log(" test 2 ");
                            ////GameConfiguration.ChangeCoordinateZForTable(tableWithNumberForRows);
                            //GameObject cubePlay = CommonMethods.GetCubePlay(tableWithNumberForRows, gameObjectName);
                            //numberOfRows2 = CommonMethods.GetCubePlayText(cubePlay);
                            ////Debug.Log(" chosenNumber = " + numberOfRows);

                            //GameObject[] cubePlayForChange = CommonMethods.GetObjectByTagName(_tagConfigurationBoardGameChangeNumberRows);
                            //GameObject cubePlayToChange = cubePlayForChange[0];
                            //CommonMethods.ChangeTextForCubePlay(cubePlayToChange, numberOfRows2);

                            numberOfRows = GameConfiguration.SetUpChosenNumberForConfiguration(tableWithNumberForRows, gameObjectName, _tagConfigurationBoardGameChangeNumberRows);

                            GameConfiguration.HideTableWithNumber(tableWithNumberForRows);
                            GameConfiguration.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows);

                        }
                        /*
                        // columns
                        if (gameObjectTag == _tagConfigurationBoardGameColumns || gameObjectTag == _tagConfigurationBoardGameChangeNumberColumns)
                        {
                            //Debug.Log(" test 1  ");
                            GameConfiguration.UnhideTableWithNumber(tableWithNumberForRows);
                            GameConfiguration.HideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberColumns)
                        {
                            Debug.Log(" test 2 ");
                            ////GameConfiguration.ChangeCoordinateZForTable(tableWithNumberForRows);
                            //GameObject cubePlay = CommonMethods.GetCubePlay(tableWithNumberForRows, gameObjectName);
                            //numberOfRows2 = CommonMethods.GetCubePlayText(cubePlay);
                            ////Debug.Log(" chosenNumber = " + numberOfRows);

                            //GameObject[] cubePlayForChange = CommonMethods.GetObjectByTagName(_tagConfigurationBoardGameChangeNumberRows);
                            //GameObject cubePlayToChange = cubePlayForChange[0];
                            //CommonMethods.ChangeTextForCubePlay(cubePlayToChange, numberOfRows2);

                            numberOfRows = GameConfiguration.SetUpChosenNumberForConfiguration(tableWithNumberForColumns, gameObjectName, _tagConfigurationBoardGameChangeNumberColumns);

                            GameConfiguration.HideTableWithNumber(tableWithNumberForRows);
                            GameConfiguration.UnhideConfiguration(_tagConfigurationBoardGameButtonSave, _tagConfigurationBoardGameButtonBack, _tagConfigurationBoardGameRows, _tagConfigurationBoardGameChangeNumberRows);

                        }
                        */







                        // ---

                        if (gameObjectTag == _tagConfigurationBoardGameButtonSave)
                        {
                            Debug.Log(" test 1 ");
                            ConfigurationBoardGameNumberOfRows = numberOfRows;
                            ConfigurationBoardGameNumberOfColumns = numberOfColumns;

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
