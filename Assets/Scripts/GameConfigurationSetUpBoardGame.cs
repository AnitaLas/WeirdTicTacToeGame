using Assets.Scripts;
using Assets.Scripts.GameConfiguration.GameConfigurationButtonsWithNumbers;
using System.Collections.Generic;
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
        public static int ConfigurationBoardGameNumberOfGaps { get; set; }
        public static bool ConfigurationBoardGameDeviceModeKind { get; set; }

        private static int _lenghtToCheckMax;
        private static int _gapsNumber;

        public static int numberOfPlayers;
        public static int numberOfRows;
        public static int numberOfColumns;
        public static int lenghtToCheck;
        public static int numberOfGaps;
        public static bool isCellphoneMode;
        // ---

        private GameObject[,,] _buttonsWithNumbers;

        public GameObject prefabCubePlayForTableNumber;

        public Material[] prefabCubePlayDefaultColour;

        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsBackColour;

        public Material[] prefabCubePlayButtonsNumberColour;

        private Dictionary<int, string> _configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagConfigurationBoardGame();

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
        private string _tagConfigurationBoardGameGaps;
        private string _tagConfigurationBoardGameChangeNumberGaps;
        private string _tagConfigurationBoardGameTableNumberGaps;
        private string _tagConfigurationBoardGameButtonBackToConfiguration;
        private string[] _tagConfigurationBoardGameHideOrUnhide = new string[12];
        //private string[] _tableWithChangedNumber = new string[3];
        private string[] _tableWithChangedNumber = new string[4];


        private static bool _isGame2D = true;

        public Touch touch;
        private Camera _mainCamera;

        private List<GameObject[,,]> _buttonsAll;
        private List<GameObject[,,]> _buttonsMoreSpecificConfiguration;



        void Start()
        {
            isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();

            numberOfPlayers = 2;
            numberOfRows = 3;
            numberOfColumns = 3;
            lenghtToCheck = 3;
            numberOfGaps = 0;

            _tagConfigurationBoardGameButtonSave = _configurationBoardGameDictionaryTag[1];
            _tagConfigurationBoardGameButtonBack = _configurationBoardGameDictionaryTag[2];
            _tagConfigurationBoardGameTableNumberRows = _configurationBoardGameDictionaryTag[3];
            _tagConfigurationBoardGameTableNumberColumns = _configurationBoardGameDictionaryTag[4];
            _tagConfigurationBoardGameRows = _configurationBoardGameDictionaryTag[5];
            _tagConfigurationBoardGameColumns = _configurationBoardGameDictionaryTag[6];
            _tagConfigurationBoardGameChangeNumberRows = _configurationBoardGameDictionaryTag[7];
            _tagConfigurationBoardGameChangeNumberColumns = _configurationBoardGameDictionaryTag[8];
            // players
            _tagConfigurationBoardGamePlayers = _configurationBoardGameDictionaryTag[9];
            _tagConfigurationBoardGameChangeNumberPlayers = _configurationBoardGameDictionaryTag[10];
            _tagConfigurationBoardGameTableNumberPlayers = _configurationBoardGameDictionaryTag[11];
            // lenght to check
            _tagConfigurationBoardGameLenghtToCheck = _configurationBoardGameDictionaryTag[12];
            _tagConfigurationBoardGameChangeNumberLenghtToCheck = _configurationBoardGameDictionaryTag[13];
            _tagConfigurationBoardGameTableNumberLenghtToCheck = _configurationBoardGameDictionaryTag[14];
            // gaps
            _tagConfigurationBoardGameGaps = _configurationBoardGameDictionaryTag[15];
            _tagConfigurationBoardGameChangeNumberGaps = _configurationBoardGameDictionaryTag[16];
            _tagConfigurationBoardGameTableNumberGaps = _configurationBoardGameDictionaryTag[17];

            _tagConfigurationBoardGameButtonBackToConfiguration = _configurationBoardGameDictionaryTag[21];
 
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
            _tagConfigurationBoardGameHideOrUnhide[10] = _tagConfigurationBoardGameChangeNumberGaps;
            _tagConfigurationBoardGameHideOrUnhide[11] = _tagConfigurationBoardGameGaps;


            // ---
            _tableWithChangedNumber[0] = _tagConfigurationBoardGameChangeNumberRows;
            _tableWithChangedNumber[1] = _tagConfigurationBoardGameChangeNumberColumns;
            _tableWithChangedNumber[2] = _tagConfigurationBoardGameChangeNumberLenghtToCheck;
            _tableWithChangedNumber[3] = _tagConfigurationBoardGameChangeNumberGaps;

            _buttonsAll = GameConfigurationButtonsCreate.GameConfigurationCreateButtons(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, _isGame2D);
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
                       
                        // players
                        if (gameObjectTag == _tagConfigurationBoardGamePlayers || gameObjectTag == _tagConfigurationBoardGameChangeNumberPlayers)
                        {
                            _buttonsWithNumbers = GameConfigurationButtonsWithNumbersForPlayers.CreateTableForPlayers(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, _isGame2D, isCellphoneMode);
                            _buttonsMoreSpecificConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonsBackAndPlayer(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, _isGame2D);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        }


                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberPlayers)
                        {
                            numberOfPlayers = GameConfigurationCommonMethods.SetUpChosenNumberForConfigurationPlayers(_buttonsWithNumbers, gameObjectName);
                            
                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);
                        }


                        // rows
                        if (gameObjectTag == _tagConfigurationBoardGameRows || gameObjectTag == _tagConfigurationBoardGameChangeNumberRows)
                        {
                            _buttonsWithNumbers = GameConfigurationButtonsWithNumbersForRows.CreateTableForRows(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, _isGame2D, isCellphoneMode);
                            _buttonsMoreSpecificConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonsBackAndRow(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, _isGame2D);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        } 

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberRows)
                        {
                            numberOfRows = GameConfigurationCommonMethods.SetUpChosenNumberForConfigurationRows(_buttonsWithNumbers, gameObjectName);

                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);

                            GameConfigurationButtonsWithNumbersForLenghtToCheck.VerifyAndSetUpNewMaxLength(_tableWithChangedNumber);                               
                        }                    

                        // columns
                        if (gameObjectTag == _tagConfigurationBoardGameColumns || gameObjectTag == _tagConfigurationBoardGameChangeNumberColumns)
                        {
                            _buttonsWithNumbers = GameConfigurationButtonsWithNumbersForColumns.CreateTableForColumns(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, _isGame2D, isCellphoneMode);
                            _buttonsMoreSpecificConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonsBackAndColumn(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, _isGame2D);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        }

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberColumns)
                        {
                            numberOfColumns = GameConfigurationCommonMethods.SetUpChosenNumberForConfigurationColumns(_buttonsWithNumbers, gameObjectName);
                            
                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);

                            GameConfigurationButtonsWithNumbersForLenghtToCheck.VerifyAndSetUpNewMaxLength(_tableWithChangedNumber);
                        }


                        // lenght to check - button victory
                        if (gameObjectTag == _tagConfigurationBoardGameLenghtToCheck || gameObjectTag == _tagConfigurationBoardGameChangeNumberLenghtToCheck)
                        {
                            _lenghtToCheckMax = GameConfigurationButtonsWithNumbersForLenghtToCheck.GetLenghtToCheckMax();
                            _buttonsWithNumbers = GameConfigurationButtonsWithNumbersForLenghtToCheck.CreateTableForLenghtToCheck(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, _lenghtToCheckMax, _isGame2D, isCellphoneMode);
                            _buttonsMoreSpecificConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonsBackAndLenghtToCheck(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, _isGame2D);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        }

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberLenghtToCheck)
                        {
                            lenghtToCheck = GameConfigurationCommonMethods.SetUpChosenNumberForConfigurationLenghtToCheck(_buttonsWithNumbers, gameObjectName);                           
                           
                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);
                        }

                        // gaps
                        if (gameObjectTag == _tagConfigurationBoardGameGaps || gameObjectTag == _tagConfigurationBoardGameChangeNumberGaps)
                        {
                            //_lenghtToCheckMax = GameConfigurationButtonsWithNumbersForLenghtToCheck.GetLenghtToCheckMax();
                            _gapsNumber = GameConfigurationButtonsWithNumbersForGaps.GetGapsNumber();
                            _buttonsWithNumbers = GameConfigurationButtonsWithNumbersForGaps.CreateTableForGaps(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, _lenghtToCheckMax, _isGame2D, isCellphoneMode);
                            _buttonsMoreSpecificConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonsBackAndGaps(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, _isGame2D);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        }

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberGaps)
                        {
                            lenghtToCheck = GameConfigurationCommonMethods.SetUpChosenNumberForConfigurationGaps(_buttonsWithNumbers, gameObjectName);

                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);
                        }

                        // save
                        if (gameObjectTag == _tagConfigurationBoardGameButtonSave)
                        {
                            ConfigurationBoardGameNumberOfRows = numberOfRows;
                            ConfigurationBoardGameNumberOfColumns = numberOfColumns;
                            ConfigurationBoardGameNumberOfPlayers = numberOfPlayers;
                            ConfigurationBoardGameLenghtToCheck = lenghtToCheck;
                            ConfigurationBoardGameNumberOfGaps = numberOfGaps;
                            ConfigurationBoardGameDeviceModeKind = isCellphoneMode;

                            ScenesChange.GoToSceneConfigurationPlayersSymbols();
                        }

                        // back
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
