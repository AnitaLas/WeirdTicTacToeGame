using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfigurationBoardGame : MonoBehaviour
    {
        public static int ConfigurationBoardGameNumberOfPlayers { get; set; }
        public static int ConfigurationBoardGameNumberOfRows { get; set; }
        public static int ConfigurationBoardGameNumberOfColumns { get; set; }
        public static int ConfigurationBoardGameLenghtToCheck { get; set; }
        public static int ConfigurationBoardGameNumberOfGaps { get; set; }
        //public static bool ConfigurationBoardGameDeviceModeKind { get; set; }

        private static int _lenghtToCheckMax;
        private static int _gapsNumber;

        public static int numberOfPlayers;
        public static int numberOfRows;
        public static int numberOfColumns;
        public static int lenghtToCheck;
        public static int numberOfGaps;
        public static bool isCellphoneMode;
        public static bool isTeamGame;
        // ---

        private GameObject[,,] _buttonsWithNumbers;

        public GameObject prefabCubePlayForTableNumber;

        public Material[] prefabCubePlayDefaultColour;

        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsBackColour;

        public Material[] prefabCubePlayButtonsNumberColour;

        //private Dictionary<int, string> _configurationBoardGameDictionaryTag = GameDictionariesSceneConfigurationBoardGame.DictionaryTagsNameConfigurationBoardGame();

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
        private static bool _configurationBoardGameDeviceModeKind;
        public static bool _configurationTraditionalGame1;
        public static bool _configurationTraditionalGame2;
        public static bool _configurationTeamGame1;
        public static bool _configurationTeamGame2;



        private static bool _isGame2D = true;

        public Touch touch;
        private Camera _mainCamera;

        private List<GameObject[,,]> _buttonsAll;
        private List<GameObject[,,]> _buttonsMoreSpecificConfiguration;



        void Start()
        {
            _configurationBoardGameDeviceModeKind = GameConfigurationKindOfGame.ConfigurationBoardGameDeviceModeKind;
            //isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();
            isCellphoneMode = _configurationBoardGameDeviceModeKind;

            _configurationTraditionalGame1 = GameConfigurationKindOfGame.ConfigurationTraditionalGame;
            _configurationTeamGame1 = GameConfigurationKindOfGame.ConfigurationTeamGame;

            Debug.Log("GameConfigurationBoardGame _configurationTraditionalGame1 : " + _configurationTraditionalGame1);
            Debug.Log("GameConfigurationBoardGame _configurationTeamGame1 : " + _configurationTeamGame1);

            //_configurationTraditionalGame2 = GameConfigurationTeamMembers.ConfigurationTraditionalGame;
            //_configurationTeamGame2 = GameConfigurationTeamMembers.ConfigurationTeamGame;


            _configurationTraditionalGame2 = GameConfigurationKindOfGame.ConfigurationTraditionalGame;
            _configurationTeamGame2 = GameConfigurationKindOfGame.ConfigurationTeamGame;

            Debug.Log("GameConfigurationBoardGame _configurationTraditionalGame2 : " + _configurationTraditionalGame2);
            Debug.Log("GameConfigurationBoardGame _configurationTeamGame2 : " + _configurationTeamGame2);

            //isTeamGame = GameConfigurationButtonsCommonMethods.IsTeamGame(_configurationTraditionalGame1, _configurationTeamGame1, _configurationTraditionalGame2, _configurationTeamGame2);
            isTeamGame = GameConfigurationButtonsCommonMethods.IsTeamGame(_configurationTraditionalGame1, _configurationTeamGame1, _configurationTraditionalGame2, _configurationTeamGame2);

            Debug.Log("GameConfigurationBoardGame isTeamGame : " + isTeamGame);
            Debug.Log(" --------------------------------------------------------------------------------- ");
            //if (_configurationTraditionalGame1 == true && _configurationTeamGame1 == false)
            //{
            //    isTeamGame = false;
            //}

            //if (_configurationTraditionalGame2 == false && _configurationTeamGame2 == true)
            //{
            //    isTeamGame = true;
            //}


            //Debug.Log("_configurationTraditionalGame : " + _configurationTraditionalGame);
            //Debug.Log("_configurationTeamGame : " + _configurationTeamGame);

            numberOfPlayers = 2;
            numberOfRows = 3;
            numberOfColumns = 3;
            lenghtToCheck = 3;
            numberOfGaps = 0;

            _tagConfigurationBoardGameButtonSave = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonSaveByTagButtonSave();
            _tagConfigurationBoardGameButtonBack = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonSaveByTagButtonBack();
            _tagConfigurationBoardGameTableNumberRows = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberRows();
            _tagConfigurationBoardGameTableNumberColumns = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberColumns();
            _tagConfigurationBoardGameRows = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNameByTagRows();
            _tagConfigurationBoardGameColumns = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNameByTagColumns();
            _tagConfigurationBoardGameChangeNumberRows = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberRows();
            _tagConfigurationBoardGameChangeNumberColumns = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberColumns();
            // players
            _tagConfigurationBoardGamePlayers = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNameByTagPlayers();
            _tagConfigurationBoardGameChangeNumberPlayers = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberPlayers();
            _tagConfigurationBoardGameTableNumberPlayers = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberPlayers();
            // lenght to check
            _tagConfigurationBoardGameLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNameByTagLenghtToCheck();
            _tagConfigurationBoardGameChangeNumberLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberLenghtToCheck();
            _tagConfigurationBoardGameTableNumberLenghtToCheck = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableLenghtToCheck();
            // gaps
            _tagConfigurationBoardGameGaps = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNameByTagGaps();
            _tagConfigurationBoardGameChangeNumberGaps = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberGaps();
            _tagConfigurationBoardGameTableNumberGaps = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberGaps();

            _tagConfigurationBoardGameButtonBackToConfiguration = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonBackByTagButtonBackToConfiguration();
    

            _buttonsAll = GameConfigurationButtonsCreate.GameConfigurationCreateButtons(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, _isGame2D, isTeamGame);
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
                            numberOfPlayers = GameConfigurationButtonsCommonMethods.SetUpChosenNumberForConfigurationPlayers(_buttonsWithNumbers, gameObjectName);
                            
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
                            numberOfRows = GameConfigurationButtonsCommonMethods.SetUpChosenNumberForConfigurationRows(_buttonsWithNumbers, gameObjectName);

                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);

                            //GameConfigurationButtonsWithNumbersForLenghtToCheck.VerifyAndSetUpNewMaxLength(_tableWithChangedNumber);                               
                            //GameCommonMethodsSetUpButtonWithNumber.VerifyAndSetUpLenghtToCheckAndGapsForButtonWithNumbers();
                            GameConfigurationButtonsActions.VerifyButtonsWithNumberForLenghtToCheckAndGaps();
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
                            numberOfColumns = GameConfigurationButtonsCommonMethods.SetUpChosenNumberForConfigurationColumns(_buttonsWithNumbers, gameObjectName);
                            
                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);

                            //GameConfigurationButtonsWithNumbersForLenghtToCheck.VerifyAndSetUpNewMaxLength(_tableWithChangedNumber);
                            //GameCommonMethodsSetUpButtonWithNumber.VerifyAndSetUpLenghtToCheckAndGapsForButtonWithNumbers();
                            GameConfigurationButtonsActions.VerifyButtonsWithNumberForLenghtToCheckAndGaps();
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
                            lenghtToCheck = GameConfigurationButtonsCommonMethods.SetUpChosenNumberForConfigurationLenghtToCheck(_buttonsWithNumbers, gameObjectName);                           
                           
                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);
                        }

                        // gaps
                        if (gameObjectTag == _tagConfigurationBoardGameGaps || gameObjectTag == _tagConfigurationBoardGameChangeNumberGaps)
                        {
                            //GameConfigurationButtonsWithNumbersForGaps.SetUpGapsNumber();

                            _buttonsWithNumbers = GameConfigurationButtonsWithNumbersForGaps.CreateTableForGapsNumber(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, _lenghtToCheckMax, _isGame2D, isCellphoneMode);
                            _buttonsMoreSpecificConfiguration = GameConfigurationButtonsCreate.GameConfigurationCreateButtonsBackAndGaps(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, _isGame2D);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        }

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberGaps)
                        {
                            numberOfGaps = GameConfigurationButtonsCommonMethods.SetUpChosenNumberForConfigurationGaps(_buttonsWithNumbers, gameObjectName);

                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);
                        }

                        // save
                        if (gameObjectTag == _tagConfigurationBoardGameButtonSave)
                        {
                            ConfigurationBoardGameNumberOfRows = numberOfRows;
                            ConfigurationBoardGameNumberOfColumns = numberOfColumns;
                            //ConfigurationBoardGameNumberOfPlayers = numberOfPlayers;
                            ConfigurationBoardGameLenghtToCheck = lenghtToCheck;
                            ConfigurationBoardGameNumberOfGaps = numberOfGaps;
                            //ConfigurationBoardGameDeviceModeKind = isCellphoneMode;

                            if (isTeamGame == false)
                            {
                                ConfigurationBoardGameNumberOfPlayers = numberOfPlayers;
                                ScenesChangeMainMethods.GoToSceneConfigurationPlayersSymbols();
                            }
                            else
                            {
                                ScenesChangeMainMethods.GoToSceneConfigurationChangePlayersSymbols();
                            }

                            
                        }

                        // back
                        if (gameObjectTag == _tagConfigurationBoardGameButtonBack)
                        {
                            ScenesChangeMainMethods.GoToSceneStartGame();
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
