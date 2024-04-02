using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchPhase = UnityEngine.TouchPhase;
using Assets.Scripts.GameConfiguration;
using TMPro;
using UnityEditor;


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

    public Touch touch;
    private Camera mainCamera;

    public int playersNumberGivenForConfiguration; // = 4;

    private static int _numberOfRows;// = 4; //3;// 3;
    private static int _numberOfColumns; // = 3;// 6;
    private static bool _isCellphoneMode; // = 3;// 6;
    private static int _numberOfGaps; // = 3;// 6;
    
    private static float _timeForChandeRandomly; 
    private static float _timeForChandeForAll; 
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

    private int _index;
   
    private string[] _playersSymbols;
    private string[] _newPlayersSymbols;
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
    private float _timeForUnhidePlayGameElements;
    private float _timeForHide;
    private bool _isTimeToHidePlayGameElements;
    private bool _isTimerActivate;
    private bool _switchTimer;


    void Start()
    {
        _isBoarGameHelpTextVisible = true;

        //_tagCubePlayFree = _tagCubePlayDictionary[1];
        //_tagCubePlayTaken = _tagCubePlayDictionary[2];

        _tagCubePlayFree = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagFree();
        _tagCubePlayTaken = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagTaken();

        //_tagArrowRight = _tagArrowDictionary[1];
        //_tagArrowLeft = _tagArrowDictionary[3];
        //_tagArrowUp = _tagArrowDictionary[4];
        //_tagArrowDown = _tagArrowDictionary[2];
        //_tagButtonConfirm = _tagArrowDictionary[5];

        _tagArrowRight = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagArrowRight();
        _tagArrowDown = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagArrowDown();
        _tagArrowLeft = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagArrowLeft();
        _tagArrowUp = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagArrowUp();
        _tagButtonConfirm = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagButtonConfirm();


        //_tagGameButtonMenuConfigurationLeft = _tagGameDictionary[1];
        //_tagGameButtonMenuConfigurationRight = _tagGameDictionary[2];
        //_tagGameButtonNewGame = _tagGameDictionary[3];
        //_tagGameButtonHelpButtons = _tagGameDictionary[4];
        //_tagGameButtonMenuBack = _tagGameDictionary[5];
        //_tagGameButtonBoardGameHelpText = _tagGameDictionary[8];

        _tagGameButtonMenuConfigurationLeft = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuConfigurationLeft();
        _tagGameButtonMenuConfigurationRight = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuConfigurationRight();
        _tagGameButtonNewGame = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagNewGame();
        _tagGameButtonHelpButtons = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagHelpButtons();
        _tagGameButtonMenuBack = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagMenuBack();
        _tagGameButtonBoardGameHelpText = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagBoardGameHelpText();

        _index = 0;

        _configurationBoardGameDeviceModeKind = GameConfigurationBoardGame.ConfigurationBoardGameDeviceModeKind;
        _isCellphoneMode = _configurationBoardGameDeviceModeKind;

        _configurationBoardGameNumberOfPlayers = GameConfigurationBoardGame.ConfigurationBoardGameNumberOfPlayers;
        playersNumberGivenForConfiguration = _configurationBoardGameNumberOfPlayers;

        _configurationBoardGameNumberOfRows = GameConfigurationBoardGame.ConfigurationBoardGameNumberOfRows;    
        _numberOfRows = _configurationBoardGameNumberOfRows;

        _configurationBoardGameNumberOfColumns = GameConfigurationBoardGame.ConfigurationBoardGameNumberOfColumns;
        _numberOfColumns = _configurationBoardGameNumberOfColumns;

        _maxCubePlayNumber = _numberOfRows * _numberOfColumns * _numberOfDepths;

        _configurationBoardGameNumberForLenghtToCheck = GameConfigurationBoardGame.ConfigurationBoardGameLenghtToCheck;
        _lenghtToCheck = _configurationBoardGameNumberForLenghtToCheck - 1;

        _configurationBoardGameNumberOfGaps = GameConfigurationBoardGame.ConfigurationBoardGameNumberOfGaps;
        _numberOfGaps = _configurationBoardGameNumberOfGaps;

        //------------------------------------
        _configurationBoardGameChangeRandomlyPlayersSymbolsTime = GameConfigurationChangePlayersSymbols.ConfigurationBoardGameChangeRandomlyPlayersSymbolsTime;
        _timeForChandeRandomly = _configurationBoardGameChangeRandomlyPlayersSymbolsTime;

        _configurationBoardGameChangeForAllPlayersSymbolsTime = GameConfigurationChangePlayersSymbols.ConfigurationBoardGameChangeForAllPlayersSymbolsTime;
        _timeForChandeForAll = _configurationBoardGameChangeForAllPlayersSymbolsTime;

        //_configurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime = GameConfigurationChangePlayersSymbols.ConfigurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime;
        //_timeForSwitchBetweenTeams = _configurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime;
        _timeForSwitchBetweenTeams = 0;

        //------------------------------------

        _gameBoardVerification2D = GameConfigurationButtonsCommonMethods.CreateEmptyTable2D(_numberOfRows, _numberOfColumns);

        _playersSymbols = GameConfigurationPlayersSymbols.ConfigurationPlayerSymbolTableWitPlayersChosenSymbols;

        _currentPlayer = GameCommonMethodsMain.CreateTableWithGivenLengthAndGivenValue(1, 0);

        PlayGameChangePlayerSymbol.SetUpPlayerSymbolForMoveAtStart(_playersSymbols);

        _playerSymbolMove = PlayGameChangePlayerSymbol.CreateTableWithPlayersSymbolsMove(_playersSymbols);

        _currentCountedTagCubePlayTaken = GameCommonMethodsMain.CreateTableWithGivenLengthAndGivenValue(1, 0);

        // [gameBoard] - creating the board game with game object "CubePlay"
        _gameBoard = CreateGameBoard.CreateBoardGame(prefabCubePlay, _numberOfDepths, _numberOfRows, _numberOfColumns, prefabCubePlayDefaultColour, _isGame2D, _isCellphoneMode, _numberOfGaps);

        PlayGameHelpButtonsCreate.CreateAtStartHelpButtons(prefabHelpButtons, _numberOfRows, _numberOfColumns, _isCellphoneMode);

        // [timer] 
        //_gameButtonsTimer = PlayGameTimerButtonsCreate.GameTimerButtonsCreate(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsTimerColour, _isGame2D);
        //s_gameButtonsTimer = PlayGameTimerButtonsCreate.GameTimerButtonsCreate(prefabTimer);


        // [mode]
        if (_isCellphoneMode == true)
        {
          
            if (_numberOfColumns > 5 || _numberOfRows > 5)
            {
                _isBoarGameHelpTextVisible = false;
                _cubePlayForFrame = _gameBoard[0, _numberOfRows - 1, 0];
                // scale for cubePlayFrame taken from cubePlay, it is cube so one cooridinate is enought
                _cubePlayForFrameScale = _cubePlayForFrame.transform.localScale.x;

                _cubePlayFrame = PlayGameFrameCreate.CreateCubePlayFrameForPlayerMove(prefabCubePlayFrame, _cubePlayForFrame, _isGame2D);

                _moveIndexForFrame = PlayGameFrameMove.CreateTableForMoveIndexForFrame(_numberOfRows);
                _isBoarGameHelpTextVisible = PlayGameChangeCubePlayHelpText.ChangeBoarGameHelpTextVisibility(_gameBoard, _playersSymbols, _isBoarGameHelpTextVisible);
            } 
            else
            {
                _isBoarGameHelpTextVisible = PlayGameChangeCubePlayHelpText.ChangeBoarGameHelpTextVisibility(_gameBoard, _playersSymbols, _isBoarGameHelpTextVisible);
            }
        }
        else
        {
            _isBoarGameHelpTextVisible = PlayGameChangeCubePlayHelpText.ChangeBoarGameHelpTextVisibility(_gameBoard, _playersSymbols, _isBoarGameHelpTextVisible);
        }


        //---------------------------------------------------------------------------
        // TIMER ACTION - start
        // 


        _isTimerActivate = PlayGameTimerCommonMethods.IsTimerActivate(_timeForChandeRandomly, _timeForChandeForAll, _timeForSwitchBetweenTeams);
        //if (_timeForChandeRandomly != 0 || _timeForChandeForAll != 0 || _timeForSwitchBetweenTeams != 0)
        if (_isTimerActivate == true)
        {
            _switchTimer = PlayGameTimerCommonMethods.TurnOnTimer();

            if (_switchTimer == true)
            {
                _gameChangeTimeConfiguration = new List<float>();
                _gameChangeTimeConfiguration.Insert(0, _timeForChandeRandomly);
                _gameChangeTimeConfiguration.Insert(1, _timeForChandeForAll);
                _gameChangeTimeConfiguration.Insert(2, _timeForSwitchBetweenTeams);
                _gameChangeTimeConfiguration.Insert(3, _timeForHidePlayGameElementsDefault);



                _gameButtonsTimer = PlayGameTimerButtonsCreate.GameTimerButtonsCreate(prefabTimer);


                //_timeForHidePlayGameElements = new float[2]; // 2 = _timeForChandeRandomly or _timeForChandeForAll + _timeForSwitchBetweenTeams

                //if(_timeForChandeRandomly != 0)
                //    _timeForHidePlayGameElements[0] = _timeForChandeRandomly;
                //else
                //    _timeForHidePlayGameElements[0] = _timeForChandeForAll;

                //_timeForHidePlayGameElements[1] = _timeForSwitchBetweenTeams;

                ////Debug.Log("_timeForHidePlayGameElements[0]: " + _timeForHidePlayGameElements[0]);
                ////Debug.Log("_timeForHidePlayGameElements[1]: " + _timeForHidePlayGameElements[1]);


                //_timeForHide = _timeForHidePlayGameElements[0];
                //_timeForUnhidePlayGameElements = _timeForHidePlayGameElementsDefault;
                //_isTimeToHidePlayGameElements = true;

                _timeForTimers = PlayGameTimerCommonMethods.SetupTimer(_gameChangeTimeConfiguration);

                _timeForHide = _timeForTimers[0];
                _timeForUnhidePlayGameElements = _timeForTimers[2];
                _isTimeToHidePlayGameElements = true;

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
                        _moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(_moveIndexForFrame, gameObjectTag,   _cubePlayFrame, _cubePlayForFrameScale, _numberOfRows, _numberOfColumns);                  
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

                            _playerSymbolMove = PlayGameChangePlayerSymbol.ChangeCurrentPlayersSymbolsMove(_playerSymbolMove, _playersSymbols, playersNumberGivenForConfiguration, _currentPlayer);

                            _listCheckerForWinner = GameFieldsVerificationCheckerMainMethod.FieldsVerification(_gameBoardVerification2D, _lenghtToCheck);

                            _isWinnerExists = (bool)_listCheckerForWinner[0];

                            if (_isWinnerExists == true)
                            {
                                PlayGameMenuAndTimerButtonsActions.DestroyElements();

                                PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);

                                PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin, _playersSymbols);

                                PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                GameFieldsVerificationCommonMessages.MessageWin(cubePlaySymbol);

                                _switchTimer = PlayGameTimerCommonMethods.TurnOffTimer();
                                PlayGameTimerCommonMethods.SetUpDefaultSymbolForTimerAferWin();
                            }
                            else
                            {
                                _currentPlayer = PlayGameChangeCubePlaySymbol.SetUpCurrentPlayer(_currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                                PlayGameMethods.DisactivateChosenCubePlay(cubePlayMarkByFrame);

                                _currentCountedTagCubePlayTaken = GameCommonMethodsMain.SetUpNewCurrentNumberByAddition(_currentCountedTagCubePlayTaken, _index);

                                countedTagCubePlayTaken = _currentCountedTagCubePlayTaken[_index];

                                if (countedTagCubePlayTaken >= _maxCubePlayNumber)
                                {
                                    PlayGameMenuAndTimerButtonsActions.DestroyElements();

                                    PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                    PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);

                                    PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                    GameFieldsVerificationCommonMessages.MessageGameOver();

                                    _switchTimer = PlayGameTimerCommonMethods.TurnOffTimer();
                                    PlayGameTimerCommonMethods.SetUpDefaultSymbolForTimerAferWin();
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

                            _playerSymbolMove = PlayGameChangePlayerSymbol.ChangeCurrentPlayersSymbolsMove(_playerSymbolMove, _playersSymbols, playersNumberGivenForConfiguration, _currentPlayer);

                            _listCheckerForWinner = GameFieldsVerificationCheckerMainMethod.FieldsVerification(_gameBoardVerification2D, _lenghtToCheck);

                            _isWinnerExists = (bool)_listCheckerForWinner[0];

                            if (_isWinnerExists == true)
                            {
                                PlayGameMenuAndTimerButtonsActions.DestroyElements();

                                PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);

                                PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin, _playersSymbols);

                                PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                GameFieldsVerificationCommonMessages.MessageWin(cubePlaySymbol);

                                _switchTimer = PlayGameTimerCommonMethods.TurnOffTimer();
                                PlayGameTimerCommonMethods.SetUpDefaultSymbolForTimerAferWin();
                            }
                            else
                            {
                                _currentPlayer = PlayGameChangeCubePlaySymbol.SetUpCurrentPlayer(_currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                                PlayGameMethods.DisactivateChosenCubePlay(touch);

                                _currentCountedTagCubePlayTaken = GameCommonMethodsMain.SetUpNewCurrentNumberByAddition(_currentCountedTagCubePlayTaken, _index);

                                countedTagCubePlayTaken = _currentCountedTagCubePlayTaken[_index];

                                if (countedTagCubePlayTaken >= _maxCubePlayNumber)
                                {;
                                    PlayGameMenuAndTimerButtonsActions.DestroyElements();

                                    PlayGameMenuAndTimerButtonsActions.DisactivateConfigurationMenu();
                                    PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);

                                    PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                    GameFieldsVerificationCommonMessages.MessageGameOver();

                                    _switchTimer = PlayGameTimerCommonMethods.TurnOffTimer();
                                    PlayGameTimerCommonMethods.SetUpDefaultSymbolForTimerAferWin();
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
                        _gameButtonsMenu = PlayGameMenuButtonsCreate.CreateButtonsMenu(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, _isGame2D);

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

                            _cubePlayFrame = PlayGameFrameCreate.CreateCubePlayFrameForPlayerMove(prefabCubePlayFrame, _cubePlayForFrame, _isGame2D);
                            
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

        //PlayGameTimerCommonMethods.CountdownSecondsForPlayers(_timeForUnhidePlayGameElements);


        if (_isTimerActivate == true)
        {
            if (_switchTimer == true)
            {
                int indexTimeForHide = 0;
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
                        _timeForHide = _timeForTimers[indexTimeForHide];

                        //-------------------------------------------------------
                        _newPlayersSymbols = PlayGameChangePlayersSymbolsComnonMethods.GetNewPlayersSymbols(_playersSymbols);
                                           
                        _playersSymbols = _newPlayersSymbols;

                        _gameButtonsChangePlayersSymbolsTop = PlayGameChangePlayersSymbolsButtonsCreate.GameChangePlayersSymbolsButtonsTopCreate(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, _gameChangeTimeConfiguration, _newPlayersSymbols);
                        _gameButtonsChangePlayersSymbols = PlayGameChangePlayersSymbolsButtonsCreate.GameChangePlayersSymbolsButtonsCreate(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, _isGame2D, _gameChangeTimeConfiguration, _playersSymbols, _newPlayersSymbols);












                    }
                }
                else
                {
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
                //true = stop time, in future, can set up the main configuration for time,
                //where the user can set up if this time will be stopped or counted from the beginning
            }







        }



        // TIMER ACTION - end
    }
}
