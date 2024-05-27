using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchPhase = UnityEngine.TouchPhase;
using Assets.Scripts.GameConfiguration;
using TMPro;
using UnityEditor;
using Assets;
using System;


internal class Game : MonoBehaviour
{
    // prefab "CybePlay"
    public GameObject prefabCubePlay;

    // prefub "Timer"
    public GameObject prefabTimer;

    // prefab "CybePlayFrame"
    public GameObject prefabCubePlayFrame;

    // prefab "prefabHelpButtons"
    public GameObject prefabHelpButtons;

    // prefab "CubePlay" - colour 
    public Material[] prefabCubePlayDefaultColour;
    //public Material[] prefabCubePlayButtonsTimerColour;

    public Material[] prefabCubePlayButtonsBackColour; 
    public Material[] prefabCubePlayButtonsDefaultColour; 
    public Material[] prefabCubePlayButtonsNumberColour; 
    public Material[] cubePlayColourWin;


    private static int _configurationBoardGameNumberOfRows;
    private static int _configurationBoardGameNumberOfColumns;
    private static int _configurationBoardGameNumberOfPlayers;
    private static int _configurationBoardGameNumberForLenghtToCheck;
    private static int _configurationBoardGameNumberOfGaps;
    private static float _configurationBoardGameChangeRandomlyPlayersSymbolsTime;
    private static float _configurationBoardGameChangeForAllPlayersSymbolsTime;
    private static float _configurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime;
    private static bool _configurationBoardGameDeviceModeKind;
    private static List<string[]> _configurationTeamGameSymbols; // = 3;// 6;

    public Touch touch;
    private Camera mainCamera;

    //public int playersNumberGivenForConfiguration; // = 4;
    private static int _playersNumberGivenForConfiguration; // = 4;

    private static int _numberOfRows;// = 4; //3;// 3;
    private static int _numberOfColumns; // = 3;// 6;
    private static bool _isCellphoneMode; // = 3;// 6;
    private static int _numberOfGaps; // = 3;// 6;
    private static List<string[]> _teamGameSymbols; // = 3;// 6;
    
    
    private static float _timeForChangeRandomly; 
    private static float _timeForChangeForAll; 
    private static float _timeForSwitchBetweenTeams; 
    //private static bool _isBoarGameHelpTextVisible; // = 3;// 6;
    private static bool _isBoarGameHelpTextVisible; // = 3;// 6;

    // default = 1; this is needed for future version 3D WeirdTicTacToeGame
    // it is not possible to change from UI
    private static int _numberOfDepths = 1;

   // private static int lenghtToCheckMax;
    private static int _lenghtToCheck;

    private static bool _isGame2D = true;

    private int _maxCubePlayNumber; // = numberOfRows * numberOfColumns * numberOfDepths;


    private float _cubePlayForFrameScale;


    //private Dictionary<int, string> _tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();

    private string _tagCubePlayFree;
    private string _tagCubePlayTaken;

    //private Dictionary<int, string> _tagArrowDictionary = GameDictionariesSceneGame.DictionaryTagHelpButtons();

    private string _tagArrowRight; 
    private string _tagArrowLeft; 
    private string _tagArrowUp; 
    private string _tagArrowDown; 
    private string _tagButtonConfirm; 

    //private Dictionary<int, string> _tagGameDictionary = GameDictionariesSceneGame.DictionaryTagsGame();

    private string _tagGameButtonMenuConfigurationLeft;
    private string _tagGameButtonMenuConfigurationRight;
    private string _tagGameButtonNewGame;
    private string _tagGameButtonHelpButtons;
    private string _tagGameButtonMenuBack;
    private string _tagGameButtonBoardGameHelpText;

    public static bool _configurationTraditionalGame1;
    public static bool _configurationTraditionalGame2;
    public static bool _configurationTeamGame1;
    public static bool _configurationTeamGame2;
    public static bool isTeamGame;
    public static bool isSameQuantityForMovePerTeam;

    private int _index;
   
    private string[] _playersSymbols;
    private int[] _currentPlayer;
    private int[] _currentCountedTagCubePlayTaken;

    private ArrayList _listCheckerForWinner = new ArrayList();
    private bool _isWinnerExists = false;

    private GameObject[,,] _gameBoard;
    private string[,] _gameBoardVerification2D;

    private GameObject _cubePlayFrame;
    private int[] _moveIndexForFrame;
    private int _moveIndexForFrameX = 0;
    private int _moveIndexForFrameY = 1;

    private string[] _playerSymbolMove;

    private List<GameObject[,,]> _gameButtonsMenu;
    private List<GameObject> _gameButtonsTimer;
    private List<GameObject[,,]> _gameButtonsChangePlayersSymbolsTop;
    private List<GameObject[,,]> _gameButtonsChangePlayersSymbols;
    private List<float> _gameChangeTimeConfiguration;

    private GameObject _cubePlayForFrame;


    private float[] _timeForHidePlayGameElements;
    private float[] _timeForTimers;
    //private float _timeForHideDefault = 3f;
    //private float _timeForHidePlayGameElementsDefault = 3f;
    private float _timeForHidePlayGameElementsDefault = 5f;
    //private float _timeForHidePlayGameElementsDefault = 15f;
    private float _timeForUnhidePlayGameElements;
    private float _timeForHide;
    private bool _isTimeToHidePlayGameElements;
    private bool _isTimerActivate;
    private bool _switchTimer;
    private int[] _startDataForTimer;
    private int indexTimeForHide;

    private string[] _newPlayersSymbols;  
    private List<string[]> _newDataForPlayersSymbols;
    //private List<List<string[]>> _newDataForPlayersSymbolsSwitch;
    private ArrayList _newDataForPlayersSymbolsSwitch;
    private ArrayList _dataForBoardGame;
    private float[] _coordinatesForCubePlayFrame;
    private bool _isDoubleRandomChange;
    private int _switchChange; // 0 single, 1 double
    private string[] _oldSymbolsForChange; 
    private string[] _newSymbolsForChange; 



    void Start()
    {
        _isBoarGameHelpTextVisible = true;

        _tagCubePlayFree = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagFree();
        _tagCubePlayTaken = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagTaken();

        _tagArrowRight = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagArrowRight();
        _tagArrowDown = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagArrowDown();
        _tagArrowLeft = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagArrowLeft();
        _tagArrowUp = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagArrowUp();
        _tagButtonConfirm = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagButtonConfirm();

        _tagGameButtonMenuConfigurationLeft = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuConfigurationLeft();
        _tagGameButtonMenuConfigurationRight = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuConfigurationRight();
        _tagGameButtonNewGame = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagNewGame();
        _tagGameButtonHelpButtons = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagHelpButtons();
        _tagGameButtonMenuBack = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuBack();
        _tagGameButtonBoardGameHelpText = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagBoardGameHelpText();

        _index = 0;


        // set up: device mode kind
        _configurationBoardGameDeviceModeKind = GameConfigurationKindOfGame.ConfigurationBoardGameDeviceModeKind;
        _isCellphoneMode = _configurationBoardGameDeviceModeKind;

        // set up: common
        _configurationBoardGameNumberOfRows = GameConfigurationBoardGame.ConfigurationBoardGameNumberOfRows;
        _numberOfRows = _configurationBoardGameNumberOfRows;
        //_numberOfRows = 10;

        _configurationBoardGameNumberOfColumns = GameConfigurationBoardGame.ConfigurationBoardGameNumberOfColumns;
        _numberOfColumns = _configurationBoardGameNumberOfColumns;
        //_numberOfColumns = 9;

        _maxCubePlayNumber = _numberOfRows * _numberOfColumns * _numberOfDepths;

        _configurationBoardGameNumberForLenghtToCheck = GameConfigurationBoardGame.ConfigurationBoardGameLenghtToCheck;
        _lenghtToCheck = _configurationBoardGameNumberForLenghtToCheck - 1;
        //_lenghtToCheck =  2;

        _configurationBoardGameNumberOfGaps = GameConfigurationBoardGame.ConfigurationBoardGameNumberOfGaps;
        _numberOfGaps = _configurationBoardGameNumberOfGaps;

        // set up: timer
        _configurationBoardGameChangeRandomlyPlayersSymbolsTime = GameConfigurationChangePlayersSymbolsByTime.ConfigurationBoardGameChangeRandomlyPlayersSymbolsTime;
        _timeForChangeRandomly = _configurationBoardGameChangeRandomlyPlayersSymbolsTime;

        _configurationBoardGameChangeForAllPlayersSymbolsTime = GameConfigurationChangePlayersSymbolsByTime.ConfigurationBoardGameChangeForAllPlayersSymbolsTime;
        _timeForChangeForAll = _configurationBoardGameChangeForAllPlayersSymbolsTime;

        _configurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime = GameConfigurationChangePlayersSymbolsByTime.ConfigurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime;
        _timeForSwitchBetweenTeams = _configurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime;

        //------------------------------------


        // team game parameters
        //_configurationTraditionalGame1 = GameConfigurationKindOfGame.ConfigurationTraditionalGame;
        _configurationTeamGame1 = GameConfigurationKindOfGame.ConfigurationTeamGame;
        isTeamGame = _configurationTeamGame1;
        //_configurationTraditionalGame2 = GameConfigurationTeamMembers.ConfigurationTraditionalGame;
        //_configurationTeamGame2 = GameConfigurationTeamMembers.ConfigurationTeamGame;

        //_configurationTraditionalGame2 = GameConfigurationKindOfGame.ConfigurationTraditionalGame;
        //_configurationTeamGame2 = GameConfigurationKindOfGame.ConfigurationTeamGame;

        //isTeamGame = GameConfigurationButtonsCommonMethods.IsTeamGame(_configurationTraditionalGame1, _configurationTeamGame1, _configurationTraditionalGame2, _configurationTeamGame2);

        //_configurationBoardGameNumberOfPlayers = GameConfigurationBoardGame.ConfigurationBoardGameNumberOfPlayers;
        //playersNumberGivenForConfiguration = _configurationBoardGameNumberOfPlayers;

        //Debug.Log("isTeamGame 1: " + isTeamGame);



        _configurationTeamGameSymbols = GameConfigurationTeamMembers.ConfigurationTeamGameSymbol;
        _teamGameSymbols = _configurationTeamGameSymbols;


       
        //isSameQuantityForMovePerTeam = false;
        isSameQuantityForMovePerTeam = GameConfigurationChangePlayersSymbolsByTime.ConfigurationBoardGameEqualMoveQuantityForBothTeams;
        //Debug.Log("isSameQuantityForMovePerTeam: " + isSameQuantityForMovePerTeam);

        if (isTeamGame == false)
        {
            _playersSymbols = GameConfigurationPlayersSymbols.ConfigurationPlayerSymbolTableWitPlayersChosenSymbols;
            _configurationBoardGameNumberOfPlayers = GameConfigurationBoardGame.ConfigurationBoardGameNumberOfPlayers;
            _playersNumberGivenForConfiguration = _configurationBoardGameNumberOfPlayers;

        }
        else
        {
            _playersNumberGivenForConfiguration = PlayGameTeamSetUpPlayersSymbols.GetPlayersNumber(_teamGameSymbols);


            // mode 1

            if (isSameQuantityForMovePerTeam == true)
            {
                _playersSymbols = PlayGameTeamSetUpPlayersSymbols.CreateTableWithTheSameQuantitiesForPlayersMoves(_teamGameSymbols);
                _playersNumberGivenForConfiguration = PlayGameTeamSetUpPlayersSymbols.GetPlayersNumber(_playersSymbols);

                //_playersNumberGivenForConfiguration = PlayGameTeamSetUpPlayersSymbols.GetPlayersNumber(_teamGameSymbols);
                //_playersSymbols = PlayGameTeamSetUpPlayersSymbols.CreateTableWithDifferentQuantitiesForPlayersMoves(_teamGameSymbols);
            }

            // mode 2

            else
            {
                //_playersSymbols = PlayGameTeamSetUpPlayersSymbols.CreateTableWithTheSameQuantitiesForPlayersMoves(_teamGameSymbols);
                //_playersNumberGivenForConfiguration = PlayGameTeamSetUpPlayersSymbols.GetPlayersNumber(_playersSymbols);

                _playersNumberGivenForConfiguration = PlayGameTeamSetUpPlayersSymbols.GetPlayersNumber(_teamGameSymbols);
                _playersSymbols = PlayGameTeamSetUpPlayersSymbols.CreateTableWithDifferentQuantitiesForPlayersMoves(_teamGameSymbols);

                //for (int i = 0; i < _playersSymbols.Length; i++)
                //{
                //    Debug.Log($"_playersSymbols[{i}]: " + _playersSymbols[i]);
                //}



            }

        }


        _gameBoardVerification2D = GameConfigurationButtonsCommonMethods.CreateEmptyTable2D(_numberOfRows, _numberOfColumns);

        PlayGameChangePlayerSymbol.SetUpPlayerSymbolForMoveAtStart(_playersSymbols);
        _playerSymbolMove = PlayGameChangePlayerSymbol.CreateTableWithPlayersSymbolsMove(_playersSymbols);

        _currentPlayer = GameCommonMethodsMain.CreateTableWithGivenLengthAndGivenValue(1, 0);

        _currentCountedTagCubePlayTaken = GameCommonMethodsMain.CreateTableWithGivenLengthAndGivenValue(1, 0);


        // [gameBoard] - creating the board game with game object "CubePlay"
        //_gameBoard = CreateGameBoard.CreateBoardGame(prefabCubePlay, _numberOfDepths, _numberOfRows, _numberOfColumns, prefabCubePlayDefaultColour, _isGame2D, _isCellphoneMode, _numberOfGaps);
        _dataForBoardGame = CreateGameBoard.CreateBoardGame(prefabCubePlay, _numberOfDepths, _numberOfRows, _numberOfColumns, prefabCubePlayDefaultColour, _isGame2D, _isCellphoneMode, _numberOfGaps);

        _gameBoard = (GameObject[,,])_dataForBoardGame[0];


        // because gap
        //_cubePlayForFrame = _gameBoard[0, _numberOfRows - 1, 0];

        PlayGameHelpButtonsCreate.CreateAtStartHelpButtons(prefabHelpButtons, _numberOfRows, _numberOfColumns, _isCellphoneMode);


        // [mode]
        if (_isCellphoneMode == true)
        {
          
            if (_numberOfColumns > 5 || _numberOfRows > 5)
            {
                _isBoarGameHelpTextVisible = false;
                _cubePlayForFrame = _gameBoard[0, _numberOfRows - 1, 0];
                // scale for cubePlayFrame taken from cubePlay, it is cube so one cooridinate is enought
                _cubePlayForFrameScale = _cubePlayForFrame.transform.localScale.x;

                _coordinatesForCubePlayFrame = (float[])_dataForBoardGame[1];

                //_cubePlayFrame = PlayGameFrameCreate.CreateCubePlayFrameForPlayerMove(prefabCubePlayFrame, _cubePlayForFrame, _isGame2D);
                _cubePlayFrame = PlayGameFrameCreate.CreateCubePlayFrameForPlayerMove(prefabCubePlayFrame, _cubePlayForFrame, _coordinatesForCubePlayFrame, _isGame2D);

                _moveIndexForFrame = PlayGameFrameMove.CreateTableForMoveIndexForFrame(_numberOfRows);
                _isBoarGameHelpTextVisible = PlayGameChangeCubePlayHelpText.ChangeBoarGameHelpTextVisibility(_gameBoard, _playersSymbols, _isBoarGameHelpTextVisible);
            } 
            else
            {
                _isBoarGameHelpTextVisible = PlayGameChangeCubePlayHelpText.ChangeBoarGameHelpTextVisibility(_gameBoard, _playersSymbols, _isBoarGameHelpTextVisible);
            }
        }
        //else
        //{
        //    //_isBoarGameHelpTextVisible = PlayGameChangeCubePlayHelpText.ChangeBoarGameHelpTextVisibility(_gameBoard, _playersSymbols, _isBoarGameHelpTextVisible);
        //}


        //---------------------------------------------------------------------------
        // TIMER ACTION - start

        _isTimerActivate = PlayGameTimerCommonMethods.IsTimerActivate(_timeForChangeRandomly, _timeForChangeForAll, _timeForSwitchBetweenTeams);
        
        if (_isTimerActivate == true)
        {
            _switchTimer = PlayGameTimerCommonMethods.TurnOnTimer();

            if (_switchTimer == true)
            {
                _gameChangeTimeConfiguration = new List<float>();
                _gameChangeTimeConfiguration.Insert(0, _timeForChangeRandomly);
                _gameChangeTimeConfiguration.Insert(1, _timeForChangeForAll);
                _gameChangeTimeConfiguration.Insert(2, _timeForSwitchBetweenTeams);
                _gameChangeTimeConfiguration.Insert(3, _timeForHidePlayGameElementsDefault);

                _gameButtonsTimer = PlayGameTimerButtonsCreate.GameTimerButtonsCreate(prefabTimer);
                _timeForTimers = PlayGameTimerCommonMethods.SetupTimer(_gameChangeTimeConfiguration);

                _startDataForTimer = PlayGameChangePlayersSymbolsMethods.SetUpStartSwitchChange(_gameChangeTimeConfiguration);
                _switchChange = _startDataForTimer[0];
                indexTimeForHide = _startDataForTimer[1];

                //Debug.Log("indexTimeForHide: " + indexTimeForHide);


                //Debug.Log("isDoubleRandomChange: " + isDoubleRandomChange);

                //_timeForHide = _timeForTimers[0];;
                //_timeForHide = _timeForTimers[2];
                _timeForHide = _timeForTimers[indexTimeForHide];
                //Debug.Log("_timeForHide: " + _timeForHide);


                _timeForUnhidePlayGameElements = _timeForTimers[2]; // must to be change
                //_timeForUnhidePlayGameElements = _timeForTimers[indexTimeForHide]; // must to be change
                //Debug.Log("_timeForUnhidePlayGameElements: " + _timeForUnhidePlayGameElements);

                //_isTimeToHidePlayGameElements = true;
                _isTimeToHidePlayGameElements = true;

                _isDoubleRandomChange = PlayGameChangePlayersSymbolsMethods.IsDoubleRandomChange(_gameChangeTimeConfiguration);
                //Debug.Log("1 _isDoubleRandomChange: " + _isDoubleRandomChange);
                // if (_isDoubleRandomChange == true)


               // Debug.Log("1 _switchChange: " + _switchChange);


            }
        }

        // TIMER ACTION - end


    }


    void Update()
    {
        // PLAYER ACTION - start
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            RaycastHit touch;

            if (Physics.Raycast(ray, out touch))
            {
                if (touch.collider != null)
                {
                    int countedTagCubePlayTaken;
                    string gameObjectTag = GameCommonMethodsMain.GetObjectTag(touch);
                    string gameObjectName = GameCommonMethodsMain.GetObjectName(touch);

                    bool isCubePlayFrameExsist = PlayGameFrameActions.IsCubePlayFrameExsist(_cubePlayFrame);

                    int currentPlayerNumber = _currentPlayer[0];
                    GameObject cubePlay = GameCommonMethodsMain.GetCubePlay(_gameBoard, gameObjectName);
                    
                    // move by arrows 
                    if (gameObjectTag == _tagArrowRight || gameObjectTag == _tagArrowLeft || gameObjectTag == _tagArrowDown || gameObjectTag == _tagArrowUp)
                    {
                        _cubePlayFrame = PlayGameFrameMove.GetCubePlayFrame();
                        _moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(_moveIndexForFrame, gameObjectTag, _cubePlayFrame, _cubePlayForFrameScale, _numberOfRows, _numberOfColumns);                  
                    }
                    
                    if (gameObjectTag == _tagButtonConfirm)
                    {
                        int indexX = _moveIndexForFrame[_moveIndexForFrameX];
                        int indexY = _moveIndexForFrame[_moveIndexForFrameY];

                        GameObject cubePlayMarkByFrame = GameCommonMethodsMain.GetCubePlay(_gameBoard, indexY, indexX);
                        string cubePlayMarkByFrameName = GameCommonMethodsMain.GetObjectName(cubePlayMarkByFrame);
                        string cubePlayMarkByFrameTag = GameCommonMethodsMain.GetObjectTag(cubePlayMarkByFrame);

                        if (cubePlayMarkByFrameTag == _tagCubePlayFree)
                        {
                            var cubePlayDataZYXSymbol = PlayGameChangeCubePlaySymbol.SetUpPlayerSymbolForCubePlay(_gameBoard, cubePlayMarkByFrameName, _playersSymbols, currentPlayerNumber);
                            PlayGameMethods.ChangeCoordinateZForCubePlayAfterClickOnTheCubePlay(cubePlayMarkByFrame);

                            int cubePlayIndexY = cubePlayDataZYXSymbol.Item1.Item2;
                            int cubePlayIndexX = cubePlayDataZYXSymbol.Item1.Item3;
                            string cubePlaySymbol = cubePlayDataZYXSymbol.Item2;

                            _gameBoardVerification2D[cubePlayIndexY, cubePlayIndexX] = cubePlaySymbol;

                            _playerSymbolMove = PlayGameChangePlayerSymbol.ChangeCurrentPlayersSymbolsMove(_playerSymbolMove, _playersSymbols, _playersNumberGivenForConfiguration, _currentPlayer);

                            //_listCheckerForWinner = GameFieldsVerificationCheckerMainMethod.FieldsVerification(_gameBoardVerification2D, _lenghtToCheck);
                           // Debug.Log("isTeamGame 2: " + isTeamGame);

                            if (isTeamGame == false)
                            {
                                //Debug.Log("isTeamGame 3: " + isTeamGame);
                                _listCheckerForWinner = GameFieldsVerificationCheckerMainMethod.FieldsVerification(_gameBoardVerification2D, _lenghtToCheck);
                            }
                            else
                            {
                                //Debug.Log("isTeamGame 4: " + isTeamGame);
                                _listCheckerForWinner = GameTeamFieldsVerificationCheckerMainMethod.FieldsVerificationGameTeam(_gameBoardVerification2D, _lenghtToCheck, _teamGameSymbols);
                            
                            
                            
                            
                            
                            
                            }



                            _isWinnerExists = (bool)_listCheckerForWinner[0];

                            if (_isWinnerExists == true)
                            {
                                PlayGameMenuAndTimerButtonsActions.DestroyElements();

                                //PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();

                                if (isTeamGame == false)
                                {
                                    PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                    PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);
                                    PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin, _playersSymbols);
                                
                                }
                                else
                                {
                                    PlayGameMenuAndTimerButtonsActions.DestroyConfigurationMenu();
                                    PlayGameMenuAndTimerButtonsActions.DestroyCubePlayForPlayersMove();
                                    PlayGameChangePlayerSymbol.CreateButtonsGameTeamForWinner(_isWinnerExists, prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, _teamGameSymbols);
                                    PlayGameChangeCubePlayForTeamWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin, _playersSymbols, _teamGameSymbols);



                                }




                                //PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin, _playersSymbols);

                                PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                GameFieldsVerificationCommonMessages.MessageWin(cubePlaySymbol);

                                if (_isTimerActivate == true)
                                {
                                    _switchTimer = PlayGameTimerCommonMethods.TurnOffTimer();
                                    if (isTeamGame == false)
                                        PlayGameTimerCommonMethods.SetUpDefaultSymbolForTimerAferWin();
                                    else
                                        PlayGameTimerCommonMethods.DestroyTimer();
                                }
                            }
                            else
                            {
                                _currentPlayer = PlayGameChangeCubePlaySymbol.SetUpCurrentPlayer(_currentPlayer, currentPlayerNumber, _playersNumberGivenForConfiguration);

                                PlayGameMethods.DisactivateChosenCubePlay(cubePlayMarkByFrame);

                                _currentCountedTagCubePlayTaken = GameCommonMethodsMain.SetUpNewCurrentNumberByAddition(_currentCountedTagCubePlayTaken, _index);

                                countedTagCubePlayTaken = _currentCountedTagCubePlayTaken[_index];

                                if (countedTagCubePlayTaken >= _maxCubePlayNumber)
                                {
                                    PlayGameMenuAndTimerButtonsActions.DestroyElements();

                                    //PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                    //PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);

                                    if (isTeamGame == false)
                                    {
                                        PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                        PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);
                                    }
                                    else
                                    {
                                        PlayGameMenuAndTimerButtonsActions.DestroyConfigurationMenu();
                                        PlayGameMenuAndTimerButtonsActions.DestroyCubePlayForPlayersMove();
                                        PlayGameChangePlayerSymbol.CreateButtonsGameTeamForWinner(_isWinnerExists, prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, _teamGameSymbols);
                                    }

                                    PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                    GameFieldsVerificationCommonMessages.MessageGameOver();

                                    if (_isTimerActivate == true)
                                    {
                                        _switchTimer = PlayGameTimerCommonMethods.TurnOffTimer();
                                        if (isTeamGame == false)
                                            PlayGameTimerCommonMethods.SetUpDefaultSymbolForTimerAferWin();
                                        else
                                            PlayGameTimerCommonMethods.DestroyTimer();
                                    }
                                }
                            }
                        }
                        else 
                        {
                            GameFieldsVerificationCommonMessages.MessageCubePlayTaken();
                        }
                    }
                    
                    if (gameObjectTag == _tagCubePlayFree || gameObjectTag == _tagCubePlayTaken)
                    {
                        if (gameObjectTag == _tagCubePlayFree)
                        {
                            var cubePlayDataZYXSymbol = PlayGameChangeCubePlaySymbol.SetUpPlayerSymbolForCubePlay(_gameBoard, gameObjectName, _playersSymbols, currentPlayerNumber);

                            PlayGameMethods.ChangeCoordinateZForCubePlayAfterClickOnTheCubePlay(cubePlay);

                            int cubePlayIndexY = cubePlayDataZYXSymbol.Item1.Item2;
                            int cubePlayIndexX = cubePlayDataZYXSymbol.Item1.Item3;
                            string cubePlaySymbol = cubePlayDataZYXSymbol.Item2;

                            _gameBoardVerification2D[cubePlayIndexY, cubePlayIndexX] = cubePlaySymbol;

                            if (isCubePlayFrameExsist == true)
                            {
                                _cubePlayFrame = PlayGameFrameMove.GetCubePlayFrame();

                                PlayGameFrameMove.SetUpNewXYForCubePlayFrame(_cubePlayFrame, cubePlay);

                                _moveIndexForFrame[_moveIndexForFrameX] = cubePlayIndexX;
                                _moveIndexForFrame[_moveIndexForFrameY] = cubePlayIndexY;
                            }

                            _playerSymbolMove = PlayGameChangePlayerSymbol.ChangeCurrentPlayersSymbolsMove(_playerSymbolMove, _playersSymbols, _playersNumberGivenForConfiguration, _currentPlayer);

                            //_listCheckerForWinner = GameFieldsVerificationCheckerMainMethod.FieldsVerification(_gameBoardVerification2D, _lenghtToCheck);













                            //Debug.Log("isTeamGame 2: " + isTeamGame);

                            if (isTeamGame == false)
                            {
                                //Debug.Log("isTeamGame 3: " + isTeamGame);
                                _listCheckerForWinner = GameFieldsVerificationCheckerMainMethod.FieldsVerification(_gameBoardVerification2D, _lenghtToCheck);
                            }
                            else
                            {
                                //_gameBoardVerification2D = 
                                // Debug.Log("isTeamGame 1: " + isTeamGame);




                                //_gameBoardVerification2D = new string[,]
                                //{
                                //    {"X","",""},
                                //    {"","O",""},
                                //    {"X","","X"}
                                //};

                                //_gameBoardVerification2D = new string[,]
                                //{
                                //    {"X","","X"},
                                //    {"","O",""},
                                //    {"X","",""}
                                //};

                                //_gameBoardVerification2D = new string[,]
                                //{
                                //    {"O","X",""},
                                //    {"W","T","W"},
                                //    {"0","",""}
                                //};

                                //_gameBoardVerification2D = new string[,]
                                //{
                                //    {"O","W","O"},
                                //    {"X","T",""},
                                //    {"","W",""}
                                //};

                                //_gameBoardVerification2D = new string[,]
                                //{
                                //    {"","",""},
                                //    {"W","T","W"},
                                //    {"","",""}
                                //};

                                // to do xxoo + win = 3 = return error! - to fix

                                //for (int i = 0; i < _gameBoardVerification2D.GetLength(0); i++)
                                //{
                                //    for (int j = 0; j < _gameBoardVerification2D.GetLength(1); j++)
                                //    {
                                //        Debug.Log($"_gameBoardVerification2D[{i}, {j}]" + _gameBoardVerification2D[i, j]);
                                //    }
                                //}

                                //Debug.Log(" --------------------------------------------------- ");

                                //Debug.Log(" ---------- TEAM SYMBOLS ------------ ");
                                //for (int i = 0; i < _teamGameSymbols.Count; i++)
                                //{

                                //    string[] teamSymbols = _teamGameSymbols[i];                                

                                //    for (int zz = 0; zz < teamSymbols.Length; zz++)
                                //    {
                                //        Debug.Log($"TEAM: {i}; symbol[{zz}]: " + teamSymbols[zz]);
                                //    }
                                //}

                                //Debug.Log(" ---------- TEAM SYMBOLS ------------ ");


                                _listCheckerForWinner = GameTeamFieldsVerificationCheckerMainMethod.FieldsVerificationGameTeam(_gameBoardVerification2D, _lenghtToCheck, _teamGameSymbols);






                            }










                            _isWinnerExists = (bool)_listCheckerForWinner[0];
                            //Debug.Log(" ----------- ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZz ");
                            //Debug.Log("_isWinnerExists: " + _isWinnerExists);

                            if (_isWinnerExists == true)
                            {
                                
                                
                                PlayGameMenuAndTimerButtonsActions.DestroyElements();

                                //PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                //PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);


                                if (isTeamGame == false)
                                {
                                    PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                    PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);
                                    PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin, _playersSymbols);

                                }
                                else
                                {
                                    PlayGameMenuAndTimerButtonsActions.DestroyConfigurationMenu();
                                    PlayGameMenuAndTimerButtonsActions.DestroyCubePlayForPlayersMove();
                                    PlayGameChangePlayerSymbol.CreateButtonsGameTeamForWinner(_isWinnerExists, prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, _teamGameSymbols);
                                    PlayGameChangeCubePlayForTeamWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin, _playersSymbols, _teamGameSymbols);

                                }

                                //PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin, _playersSymbols);

                                PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                GameFieldsVerificationCommonMessages.MessageWin(cubePlaySymbol);

                                if (_isTimerActivate == true)
                                {
                                    _switchTimer = PlayGameTimerCommonMethods.TurnOffTimer();
                                    if (isTeamGame == false)
                                        PlayGameTimerCommonMethods.SetUpDefaultSymbolForTimerAferWin();
                                    else
                                        PlayGameTimerCommonMethods.DestroyTimer();
                                }
                            }
                            else
                            {
                                _currentPlayer = PlayGameChangeCubePlaySymbol.SetUpCurrentPlayer(_currentPlayer, currentPlayerNumber, _playersNumberGivenForConfiguration);

                                PlayGameMethods.DisactivateChosenCubePlay(touch);

                                _currentCountedTagCubePlayTaken = GameCommonMethodsMain.SetUpNewCurrentNumberByAddition(_currentCountedTagCubePlayTaken, _index);

                                countedTagCubePlayTaken = _currentCountedTagCubePlayTaken[_index];

                                if (countedTagCubePlayTaken >= _maxCubePlayNumber)
                                {
                                    PlayGameMenuAndTimerButtonsActions.DestroyElements();

                                   // PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                    //PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);



                                    if (isTeamGame == false)
                                    {
                                        PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                        PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);
                                    }
                                    else
                                    {
                                        PlayGameMenuAndTimerButtonsActions.DestroyConfigurationMenu();
                                        PlayGameMenuAndTimerButtonsActions.DestroyCubePlayForPlayersMove();
                                        PlayGameChangePlayerSymbol.CreateButtonsGameTeamForWinner(_isWinnerExists, prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, _teamGameSymbols);
                                    }

                                    PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                    GameFieldsVerificationCommonMessages.MessageGameOver();

                                    if (_isTimerActivate == true)
                                    {
                                        _switchTimer = PlayGameTimerCommonMethods.TurnOffTimer();
                                        if (isTeamGame == false)
                                            PlayGameTimerCommonMethods.SetUpDefaultSymbolForTimerAferWin();
                                        else
                                            PlayGameTimerCommonMethods.DestroyTimer();
                                    }
                                }
                            }
                        }
                        else
                        {
                            GameFieldsVerificationCommonMessages.MessageCubePlayTaken();
                        }
                    }


                    if (gameObjectTag == _tagGameButtonMenuConfigurationLeft || gameObjectTag == _tagGameButtonMenuConfigurationRight)
                    {
                        PlayGameMenuAndTimerButtonsActions.HidePlayGameElements(_gameBoard);                   
                        _gameButtonsMenu = PlayGameMenuButtonsCreate.CreateButtonsMenu(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, _isGame2D);

                        if (_isTimerActivate == true)
                        {
                            _switchTimer = PlayGameTimerCommonMethods.TurnOffTimer();
                            PlayGameMenuAndTimerButtonsActions.HideTimerForGameBoard();
                        }                      
                    }

                    if (gameObjectTag == _tagGameButtonHelpButtons)
                    {
                        PlayGameHelpButtonsActions.HelpButtonsActionsCreateOrDestroy(prefabHelpButtons);
                        PlayGameMenuAndTimerButtonsActions.DestroyPlayGameButtons(_gameButtonsMenu);
                        PlayGameMenuAndTimerButtonsActions.UnhidePlayGameElementsHelpButtons(_gameBoard);

                        if (isCubePlayFrameExsist == false)
                        {
                            _cubePlayForFrame = _gameBoard[0, _numberOfRows - 1, 0];
                            // scale for cubePlayFrame taken from cubePlay, it is cube so one cooridinate is enought
                            _cubePlayForFrameScale = _cubePlayForFrame.transform.localScale.x;


                            _coordinatesForCubePlayFrame = (float[])_dataForBoardGame[1];

                            //_cubePlayFrame = PlayGameFrameCreate.CreateCubePlayFrameForPlayerMove(prefabCubePlayFrame, _cubePlayForFrame, _isGame2D);
                            _cubePlayFrame = PlayGameFrameCreate.CreateCubePlayFrameForPlayerMove(prefabCubePlayFrame, _cubePlayForFrame, _coordinatesForCubePlayFrame, _isGame2D);

                            _moveIndexForFrame = PlayGameFrameMove.CreateTableForMoveIndexForFrame(_numberOfRows);
                        }
                        else
                        {
                            PlayGameFrameActions.DestroyCubePlayFrame();
                            PlayGameFrameActions.DestroyMoveIndexForFrame(_moveIndexForFrame);
                        }

                        if (_isTimerActivate == true)
                        {
                            _switchTimer = PlayGameTimerCommonMethods.TurnOnTimer();
                            PlayGameMenuAndTimerButtonsActions.UnhideTimerForGameBoard();
                        }
                    }

                    if (gameObjectTag == _tagGameButtonBoardGameHelpText)
                    {
                        PlayGameMenuAndTimerButtonsActions.DestroyPlayGameButtons(_gameButtonsMenu);
                        PlayGameMenuAndTimerButtonsActions.UnhidePlayGameElements(_gameBoard);
                        _isBoarGameHelpTextVisible = PlayGameChangeCubePlayHelpText.ChangeBoarGameHelpTextVisibility(_gameBoard, _playersSymbols, _isBoarGameHelpTextVisible);

                        if (_isTimerActivate == true)
                        {
                            _switchTimer = PlayGameTimerCommonMethods.TurnOnTimer();
                            PlayGameMenuAndTimerButtonsActions.UnhideTimerForGameBoard();
                        }
                    }

                    if (gameObjectTag == _tagGameButtonMenuBack)
                    {
                        PlayGameMenuAndTimerButtonsActions.DestroyPlayGameButtons(_gameButtonsMenu);
                        PlayGameMenuAndTimerButtonsActions.UnhidePlayGameElements(_gameBoard);

                        if (_isTimerActivate == true)
                        {
                            _switchTimer = PlayGameTimerCommonMethods.TurnOnTimer();
                            PlayGameMenuAndTimerButtonsActions.UnhideTimerForGameBoard();
                        }
                    }


                    if (gameObjectTag ==  _tagGameButtonNewGame)
                    {
                        //ScenesChange.GoToSceneConfigurationBoardGame(); 
                        ScenesChangeMainMethods.GoToSceneStartGame();
                    }
                }
            }   
        }
        // PLAYER ACTION - end







        // TIMER ACTION - start

        if (_isTimerActivate == true)
        {
            

            if (_switchTimer == true)
            {
                //int indexTimeForHide = 0;
                //PlayGameTimerCommonMethods.CountdownSecondsForChangePlayersSymbols(_timeForUnhidePlayGameElements);
                //PlayGameTimerCommonMethods.CountdownSecondsForBoarGame(_timeForHide);

                PlayGameTimerCommonMethods.CountdownSecondsForChangePlayersSymbols(_timeForUnhidePlayGameElements);
                PlayGameTimerCommonMethods.CountdownSecondsForBoarGame(_timeForHide);

                if (_isTimeToHidePlayGameElements == true)
                {
                    _timeForHide -= 1 * Time.deltaTime;

                    if (_timeForHide < 0)
                    {
                        PlayGameMenuAndTimerButtonsActions.ShowTimerForChangePlayersSymbols();
                        PlayGameMenuAndTimerButtonsActions.HidePlayGameElements(_gameBoard);
                        _isTimeToHidePlayGameElements = false;
                        //_timeForHide = _timeForTimers[indexTimeForHide];
                        //Debug.Log("2 _switchChange: " + _switchChange);

                        if (_switchChange == 0)
                        {
                            //Debug.Log("2 == 0 - _switchChange: " + _switchChange);
                            //_timeForHide = _timeForTimers[0];
                            if (_isDoubleRandomChange == false)
                                _timeForHide = _timeForTimers[0];
                            else
                                _timeForHide = _timeForTimers[1];
                            //Debug.Log("2 == 1 - _timeForHide: " + _timeForHide);
                            _newDataForPlayersSymbols = PlayGameChangePlayersSymbolsMethods.GetNewDataForPlayersSymbols(_playersSymbols, _gameChangeTimeConfiguration);

                            _oldSymbolsForChange = _newDataForPlayersSymbols[0];
                            _newSymbolsForChange = _newDataForPlayersSymbols[1];
                            _newPlayersSymbols = _newDataForPlayersSymbols[2];
                            

                            if (isTeamGame == true)
                            {
                                _teamGameSymbols = PlayGameChangePlayersSymbolsMethods.SetUpNewTeamGameSymbols(_teamGameSymbols, _oldSymbolsForChange, _newSymbolsForChange);

                                // to do 
                                //_playersSymbols


                            }
                            else
                            {
                                _playersSymbols = _newPlayersSymbols;
                            }

                            PlayGameChangePlayersSymbolsMethods.SetUpNewPlayersSymbolsForGameBoard(_gameBoard, _oldSymbolsForChange, _newSymbolsForChange);

                            _gameButtonsChangePlayersSymbolsTop = PlayGameChangePlayersSymbolsButtonsCreate.GameChangePlayersSymbolsButtonsTopCreate(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, _gameChangeTimeConfiguration, _newSymbolsForChange);
                            _gameButtonsChangePlayersSymbols = PlayGameChangePlayersSymbolsButtonsCreate.GameChangePlayersSymbolsButtonsCreate(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, prefabCubePlayButtonsBackColour, _oldSymbolsForChange, _newSymbolsForChange);

                            _playerSymbolMove = PlayGameChangePlayersSymbolsMethods.SetUpNewPlayersSymbolsMove(_playerSymbolMove, _oldSymbolsForChange, _newSymbolsForChange);



                            _gameBoardVerification2D = PlayGameChangePlayersSymbolsMethods.SetUpNewGameBoardVerification2D(_gameBoardVerification2D, _oldSymbolsForChange, _newSymbolsForChange);

                        }

                        if (_switchChange == 1)
                        {
                            //Debug.Log("2 == 1 - _switchChange: " + _switchChange);
                            _timeForHide = _timeForTimers[1];
                            //_timeForHide = _timeForTimers[0];
                            //Debug.Log("2 == 1 - _timeForHide: " + _timeForHide);

                            _newDataForPlayersSymbolsSwitch = PlayGameSwitchPlayersSymbolsMethods.GetPlayersSymbolsForSwitch(_teamGameSymbols);


                             PlayGameSwitchPlayersSymbolsMethods.SetUpSwitchedPlayersSymbolsForGameBoard(_gameBoard, _newDataForPlayersSymbolsSwitch);

                             _teamGameSymbols = PlayGameSwitchPlayersSymbolsMethods.SetUpNewTeamGameSymbols(_newDataForPlayersSymbolsSwitch, _teamGameSymbols);


                            _gameButtonsChangePlayersSymbolsTop = PlayGameSwitchPlayersSymbolsButtonsCreate.GameSwitchPlayersSymbolsButtonsTopCreate(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D);
                            _gameButtonsChangePlayersSymbols = PlayGameSwitchPlayersSymbolsButtonsCreate.GameSwitchPlayersSymbolsButtonsCreate(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, prefabCubePlayButtonsBackColour, _newDataForPlayersSymbolsSwitch);


                            _playersSymbols = PlayGameSwitchPlayersSymbolsMethods.GetNewPlayersSymbols(_playersSymbols, _newDataForPlayersSymbolsSwitch);


                            _playerSymbolMove = PlayGameSwitchPlayersSymbolsMethods.SetUpNewPlayersSymbolsMove(_playerSymbolMove, _newDataForPlayersSymbolsSwitch);


                            _gameBoardVerification2D = PlayGameSwitchPlayersSymbolsMethods.SetUpNewGameBoardVerification2D(_gameBoardVerification2D, _newDataForPlayersSymbolsSwitch);


                            if (_isDoubleRandomChange == true)
                                _switchChange = PlayGameChangePlayersSymbolsMethods.SetUpNewSwitchChange(_switchChange);
                        }

                        //if (_isDoubleRandomChange == true)
                        //    _switchChange = PlayGameChangePlayersSymbolsComnonMethods.SetUpNewSwitchChange(_switchChange);


                        //_oldSymbolsForChande = _newDataForPlayersSymbols[0];
                        //_newSymbolsForChande = _newDataForPlayersSymbols[1];
                        //_newPlayersSymbols = _newDataForPlayersSymbols[2];

                        //for (int i = 0; i < _oldSymbolsForChande.Length; i++)
                        //{
                        //    Debug.Log($"_oldSymbolsForChande[{i}]" + _oldSymbolsForChande[i]);
                        //}
                        //Debug.Log(" ----------------------------------------------------------- ");

                        //for (int i = 0; i < _newSymbolsForChande.Length; i++)
                        //{
                        //    Debug.Log($"_newSymbolsForChande[{i}]" + _newSymbolsForChande[i]);
                        //}
                        //Debug.Log(" ----------------------------------------------------------- ");

                        //for (int i = 0; i < _newPlayersSymbols.Length; i++)
                        //{
                        //    Debug.Log($"_newPlayersSymbols[{i}]" + _newPlayersSymbols[i]);
                        //}
                        //Debug.Log(" ----------------------------------------------------------- ");
                        //Debug.Log(" ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZz ");


                        //PlayGameChangePlayersSymbolsMethods.SetUpNewPlayersSymbolsForGameBoard(_gameBoard, _oldSymbolsForChange, _newSymbolsForChange);

                        //_gameButtonsChangePlayersSymbolsTop = PlayGameChangePlayersSymbolsButtonsCreate.GameChangePlayersSymbolsButtonsTopCreate(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, _gameChangeTimeConfiguration, _newSymbolsForChange);
                        //_gameButtonsChangePlayersSymbols = PlayGameChangePlayersSymbolsButtonsCreate.GameChangePlayersSymbolsButtonsCreate(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, prefabCubePlayButtonsBackColour, _oldSymbolsForChange, _newSymbolsForChange);

                        //_playerSymbolMove = PlayGameChangePlayersSymbolsMethods.SetUpNewPlayersSymbolsMove(_playerSymbolMove, _oldSymbolsForChange, _newSymbolsForChange);



                        //_gameBoardVerification2D = PlayGameChangePlayersSymbolsMethods.SetUpNewGameBoardVerification2D(_gameBoardVerification2D, _oldSymbolsForChange, _newSymbolsForChange);

                        //if (_isDoubleRandomChange == true)
                        //{
                        //    _switchChange = PlayGameChangePlayersSymbolsComnonMethods.SetUpNewSwitchChange(_switchChange);
                        //}

                        //Debug.Log("_isDoubleRandomChange: " + _isDoubleRandomChange);
                        // if (_isDoubleRandomChange == true)
                        // _switchChange = PlayGameChangePlayersSymbolsComnonMethods.SetUpNewSwitchChange(_switchChange);

                    }
                }
                else
                {
                    //Debug.Log("_timeForUnhidePlayGameElements: " + _timeForUnhidePlayGameElements);
                    _timeForUnhidePlayGameElements -= 1 * Time.deltaTime;

                    if (_timeForUnhidePlayGameElements < 0)
                    {
                        PlayGameMenuAndTimerButtonsActions.ShowTimerFoGameBoard();
                        PlayGameMenuAndTimerButtonsActions.UnhidePlayGameElements(_gameBoard);
                        PlayGameMenuAndTimerButtonsActions.DestroyPlayGameButtons(_gameButtonsChangePlayersSymbolsTop);
                        PlayGameMenuAndTimerButtonsActions.DestroyPlayGameButtons(_gameButtonsChangePlayersSymbols);
                        _isTimeToHidePlayGameElements = true;
                        _timeForUnhidePlayGameElements = _timeForTimers[2];
                    }

                }
            }
            else
            {
                //true = stop time, in future, can set up the main configuration for time, false = stop
                //where the user can set up if this time will be stopped or counted from the beginning
            }







        }



        // TIMER ACTION - end
    }
}
