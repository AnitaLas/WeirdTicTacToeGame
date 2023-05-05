//using Assets.Scripts.Buttons;
//using Assets.Scripts.GameConfiguration.GameConfigurationBase;
//using Assets.Scripts.GameConfiguration;
//using Assets.Scripts.GameConfiguration.GameConfigurationBase1;
//using Assets.Scripts.GameConfigurationBase;
//using Assets.Scripts.GameConfiguration;
using Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers;
using Assets.Scripts.GameConfiguration.GameConfigurationButtons;
using Assets.Scripts.GameConfiguration.GameConfigurationButtonsCommon;
//using Assets.Scripts.GameConfiguration.GameConfigurationButtonsBase22;
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

        public static int lenghtToCheckMax;

        public static int numberOfPlayers;
        public static int numberOfRows;
        public static int numberOfColumns;
        public static int lenghtToCheck;


        // ---

        //private GameObject[,,] _tableWithNumberForRowsBase;
        //private GameObject[,,] _buttonsNumberForRows;
        //private GameObject[,,] _tableWithNumberForColumnsBase;
       // private GameObject[,,] _buttonsNumberForColumns;
        private GameObject[,,] _buttonsWithNumbers;
        //private GameObject[,,] _tableWithNumberForPlayersBase;
        //private GameObject[,,] _buttonsNumberForPlayers;
        //private GameObject[,,] _tableWithNumberForLenghtToCheckBase;
        //private GameObject[,,] _tableWithNumberForLenghtToCheck;
        //private GameObject[,,] _tableWithNumberForLenghtToCheck2;


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


        private static bool isGame2D = true;

        //private static int _numberOfRowsForTableNumber = 3;
       // private static int _numberOfColumnsForTableNumber = 3;
        //private static int _numberOfDepths = 1;

        public Touch touch;
        private Camera mainCamera;

        private List<GameObject[,,]> _buttonsAll;
        private List<GameObject[,,]> _buttonsMoreSpecificConfiguration;



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
            
            
            _buttonsAll = GameConfigurationButtonsCreate.GameConfigurationCreateButtons(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, isGame2D);

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
                            _buttonsWithNumbers = GameConfigurationButtonsWithNumbersForPlayers.CreateTableForPlayers(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, isGame2D);
                            _buttonsMoreSpecificConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonsBackAndPlayer(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, isGame2D);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberPlayers)
                        {
                            numberOfPlayers = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, _tagConfigurationBoardGameChangeNumberPlayers);
                            
                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);

                        }


                        // rows
                        if (gameObjectTag == _tagConfigurationBoardGameRows || gameObjectTag == _tagConfigurationBoardGameChangeNumberRows)
                        {
                            _buttonsWithNumbers = GameConfigurationButtonsWithNumbersForRows.CreateTableForRows(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, isGame2D);
                            _buttonsMoreSpecificConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonsBackAndRow(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, isGame2D);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        } 

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberRows)
                        {
                            numberOfRows = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, _tagConfigurationBoardGameChangeNumberRows);

                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);

                            GameConfigurationButtonsWithNumbersForLenghtToCheck.VerifyAndSetUpNewMaxLength(_tableWithChangedNumber);                               
                        }
                        

                        // columns
                        if (gameObjectTag == _tagConfigurationBoardGameColumns || gameObjectTag == _tagConfigurationBoardGameChangeNumberColumns)
                        {
                            _buttonsWithNumbers = GameConfigurationButtonsWithNumbersForColumns.CreateTableForColumns(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, isGame2D);
                            _buttonsMoreSpecificConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonsBackAndColumn(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, isGame2D);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        }

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberColumns)
                        {
                            numberOfColumns = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, _tagConfigurationBoardGameChangeNumberColumns);
                            
                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);

                            GameConfigurationButtonsWithNumbersForLenghtToCheck.VerifyAndSetUpNewMaxLength(_tableWithChangedNumber);
                        }


                        // lenght to check
                        if (gameObjectTag == _tagConfigurationBoardGameLenghtToCheck || gameObjectTag == _tagConfigurationBoardGameChangeNumberLenghtToCheck)
                        {
                            //if (_tableWithNumberForLenghtToCheckBase != null)
                            //{
                            //    GameConfigurationButtonsActions.DestroyTableWithLenghtToCheckBase(_tableWithNumberForLenghtToCheckBase);
                            //    GameConfigurationButtonsActions.DestroyTableWithLenghtToCheckBase(_tableWithNumberForLenghtToCheck);
                            //}
                            
                           // _tableWithNumberForLenghtToCheckBase = GameConfigurationButtonsWithNumbersCommonMethods.CreateTableWithNumbers(prefabCubePlayForTableNumber, _numberOfDepths, _numberOfRowsForTableNumber, _numberOfColumnsForTableNumber, prefabCubePlayDefaultColour, isGame2D);
                           
                            lenghtToCheckMax = GameConfigurationButtonsWithNumbersForLenghtToCheck.GetLenghtToCheckMax(_tagConfigurationBoardGameChangeNumberRows, _tagConfigurationBoardGameChangeNumberColumns);



                            //_tableWithNumberForLenghtToCheck = GameConfigurationButtonsWithNumbersForLenghtToCheck.CreateTableForMaxLenghtToCheck(_tableWithNumberForLenghtToCheckBase, _tagConfigurationBoardGameTableNumberLenghtToCheck, _tagConfigurationBoardGameInactiveField, lenghtToCheckMax);
                            //_buttonsWithNumbers = GameConfigurationButtonsWithNumbersForLenghtToCheck.CreateTableForLenghtToCheck(_tableWithNumberForLenghtToCheckBase, _tagConfigurationBoardGameTableNumberLenghtToCheck, _tagConfigurationBoardGameInactiveField, lenghtToCheckMax);
                            _buttonsWithNumbers = GameConfigurationButtonsWithNumbersForLenghtToCheck.CreateTableForLenghtToCheck(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, lenghtToCheckMax, isGame2D);
                            
                            _buttonsMoreSpecificConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonsBackAndLenghtToCheck(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, isGame2D);

                            //GameConfigurationButtonsActions.UnhideTableWithNumber(_tableWithNumberForLenghtToCheck);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        
                        }

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberLenghtToCheck)
                        {
                            lenghtToCheck = GameConfigurationCommonMethods.SetUpChosenNumberForConfiguration(_buttonsWithNumbers, gameObjectName, _tagConfigurationBoardGameChangeNumberLenghtToCheck);
                            
                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            //GameConfigurationButtonsActions.HideTableWithNumber(_tableWithNumberForLenghtToCheck);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);

                        }
          

                        // ---

                        if (gameObjectTag == _tagConfigurationBoardGameButtonSave)
                        {
                            ConfigurationBoardGameNumberOfRows = numberOfRows;
                            ConfigurationBoardGameNumberOfColumns = numberOfColumns;
                            ConfigurationBoardGameNumberOfPlayers = numberOfPlayers;
                            ConfigurationBoardGameLenghtToCheck = lenghtToCheck;
                            ScenesChange.GoToSceneConfigurationPlayersSymbols();
                        }

                        if (gameObjectTag == _tagConfigurationBoardGameButtonBack)
                        {
                            ScenesChange.GoToSceneStartGame();
                        }

                        if (gameObjectTag == _tagConfigurationBoardGameButtonBackToConfiguration)
                        {
                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);
                           
                        }
                    }
                }
            }

        }
    }
}
