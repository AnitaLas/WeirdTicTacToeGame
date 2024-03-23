using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchPhase = UnityEngine.TouchPhase;
using Assets.Scripts.GameConfiguration;


internal class Game : MonoBehaviour
{
    // prefab "CybePlay"
    public GameObject prefabCubePlay;

    // prefab "CybePlayFrame"
    public GameObject prefabCubePlayFrame;

    // prefab "prefabHelpButtons"
    public GameObject prefabHelpButtons;

    // prefab "CubePlay" - colour 
    public Material[] prefabCubePlayDefaultColour;

    public Material[] prefabCubePlayButtonsBackColour; 
    public Material[] prefabCubePlayButtonsDefaultColour; 
    public Material[] cubePlayColourWin;


    private static int _configurationBoardGameNumberOfRows;
    private static int _configurationBoardGameNumberOfColumns;
    private static int _configurationBoardGameNumberOfPlayers;
    private static int _configurationBoardGameNumberForLenghtToCheck;
    private static int _configurationBoardGameNumberOfGaps;
    private static bool _configurationBoardGameDeviceModeKind;

    public Touch touch;
    private Camera mainCamera;

    public int playersNumberGivenForConfiguration; // = 4;

    private static int _numberOfRows;// = 4; //3;// 3;
    private static int _numberOfColumns; // = 3;// 6;
    private static bool _isCellphoneMode; // = 3;// 6;
    private static int _numberOfGaps; // = 3;// 6;
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

    private GameObject _cubePlayForFrame;


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

        _configurationBoardGameDeviceModeKind = GameConfigurationSetUpBoardGame.ConfigurationBoardGameDeviceModeKind;
        _isCellphoneMode = _configurationBoardGameDeviceModeKind;

        _configurationBoardGameNumberOfPlayers = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfPlayers;
        playersNumberGivenForConfiguration = _configurationBoardGameNumberOfPlayers;

        _configurationBoardGameNumberOfRows = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfRows;    
        _numberOfRows = _configurationBoardGameNumberOfRows;

        _configurationBoardGameNumberOfColumns = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfColumns;
        _numberOfColumns = _configurationBoardGameNumberOfColumns;

        _maxCubePlayNumber = _numberOfRows * _numberOfColumns * _numberOfDepths;

        _configurationBoardGameNumberForLenghtToCheck = GameConfigurationSetUpBoardGame.ConfigurationBoardGameLenghtToCheck;
        _lenghtToCheck = _configurationBoardGameNumberForLenghtToCheck - 1;

        _configurationBoardGameNumberOfGaps = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfGaps;
        _numberOfGaps = _configurationBoardGameNumberOfGaps;

        _gameBoardVerification2D = GameConfigurationButtonsCommonMethods.CreateEmptyTable2D(_numberOfRows, _numberOfColumns);

        _playersSymbols = GameConfigurationSetUpPlayersSymbols.ConfigurationPlayerSymbolTableWitPlayersChosenSymbols;

        _currentPlayer = GameCommonMethodsMain.CreateTableWithGivenLengthAndGivenValue(1, 0);

        PlayGameChangePlayerSymbol.SetUpPlayerSymbolForMoveAtStart(_playersSymbols);

        _playerSymbolMove = PlayGameChangePlayerSymbol.CreateTableWithPlayersSymbolsMove(_playersSymbols);

        _currentCountedTagCubePlayTaken = GameCommonMethodsMain.CreateTableWithGivenLengthAndGivenValue(1, 0);

        // [gameBoard] - creating the board game with game object "CubePlay"
        _gameBoard = CreateGameBoard.CreateBoardGame(prefabCubePlay, _numberOfDepths, _numberOfRows, _numberOfColumns, prefabCubePlayDefaultColour, _isGame2D, _isCellphoneMode);

        PlayGameHelpButtonsCreate.CreateAtStartHelpButtons(prefabHelpButtons, _numberOfRows, _numberOfColumns, _isCellphoneMode);


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
                                PlayGameMenuButtonsActions.DestroyElements();

                                PlayGameMenuButtonsActions.DisactivateConfigurationMenu();
                                PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);

                                PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin, _playersSymbols);

                                PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                GameFieldsVerificationCommonMessages.MessageWin(cubePlaySymbol);
                            }
                            else
                            {
                                _currentPlayer = PlayGameChangeCubePlaySymbol.SetUpCurrentPlayer(_currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                                PlayGameMethods.DisactivateChosenCubePlay(cubePlayMarkByFrame);

                                _currentCountedTagCubePlayTaken = GameCommonMethodsMain.SetUpNewCurrentNumberByAddition(_currentCountedTagCubePlayTaken, _index);

                                countedTagCubePlayTaken = _currentCountedTagCubePlayTaken[_index];

                                if (countedTagCubePlayTaken >= _maxCubePlayNumber)
                                {
                                    PlayGameMenuButtonsActions.DestroyElements();

                                    PlayGameMenuButtonsActions.DisactivateConfigurationMenu();
                                    PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);

                                    PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                    GameFieldsVerificationCommonMessages.MessageGameOver();                           
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
                                PlayGameMenuButtonsActions.DestroyElements();

                                PlayGameMenuButtonsActions.DisactivateConfigurationMenu();
                                PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);

                                PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin, _playersSymbols);

                                PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                GameFieldsVerificationCommonMessages.MessageWin(cubePlaySymbol);
                            }
                            else
                            {
                                _currentPlayer = PlayGameChangeCubePlaySymbol.SetUpCurrentPlayer(_currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                                PlayGameMethods.DisactivateChosenCubePlay(touch);

                                _currentCountedTagCubePlayTaken = GameCommonMethodsMain.SetUpNewCurrentNumberByAddition(_currentCountedTagCubePlayTaken, _index);

                                countedTagCubePlayTaken = _currentCountedTagCubePlayTaken[_index];

                                if (countedTagCubePlayTaken >= _maxCubePlayNumber)
                                {;
                                    PlayGameMenuButtonsActions.DestroyElements();

                                    PlayGameMenuButtonsActions.DisactivateConfigurationMenu();
                                    PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_isWinnerExists, cubePlaySymbol);

                                    PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

                                    GameFieldsVerificationCommonMessages.MessageGameOver();
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
                        PlayGameMenuButtonsActions.HidePlayGameElements(_gameBoard);
                        _gameButtonsMenu = PlayGameMenuButtonsCreate.CreateButtonsMenu(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, _isGame2D);

                    }

                    if (gameObjectTag == _tagGameButtonHelpButtons)
                    {
                        PlayGameHelpButtonsActions.HelpButtonsActionsCreateOrDestroy(prefabHelpButtons);
                        PlayGameMenuButtonsActions.DestroyGameConfigurationMenuButtons(_gameButtonsMenu);
                        PlayGameMenuButtonsActions.UnhidePlayGameElementsHelpButtons(_gameBoard);

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
                    }

                    if (gameObjectTag == _tagGameButtonBoardGameHelpText)
                    {
                        PlayGameMenuButtonsActions.DestroyGameConfigurationMenuButtons(_gameButtonsMenu);
                        PlayGameMenuButtonsActions.UnhidePlayGameElements(_gameBoard);
                        _isBoarGameHelpTextVisible = PlayGameChangeCubePlayHelpText.ChangeBoarGameHelpTextVisibility(_gameBoard, _playersSymbols, _isBoarGameHelpTextVisible);

                    }

                    if (gameObjectTag == _tagGameButtonMenuBack)
                    {
                        PlayGameMenuButtonsActions.DestroyGameConfigurationMenuButtons(_gameButtonsMenu);
                        PlayGameMenuButtonsActions.UnhidePlayGameElements(_gameBoard);
                    }


                    if (gameObjectTag ==  _tagGameButtonNewGame)
                    {
                        //ScenesChange.GoToSceneConfigurationBoardGame(); 
                        ScenesChangeMainMethods.GoToSceneStartGame();
                    }
                }
            }   
        }
    }
}
