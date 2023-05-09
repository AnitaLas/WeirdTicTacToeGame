using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using TouchPhase = UnityEngine.TouchPhase;
using Assets.Scripts.GameConfiguration;
using System.Net.NetworkInformation;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using Assets.Scripts.GameFieldsVerification;
using Assets.Scripts.PlayGame;
using Assets.Scripts.GameDictionaries;
using System.Reflection;
using UnityEngine.SceneManagement;
using Assets.Scripts.CreateFrame;
using Assets.Scripts.CreateGameHelpButton;
using Assets.Scripts.Buttons;
using Assets.Scripts.Scenes;
using Assets.Scripts.PlayGameHelpButtons;

internal class Game : MonoBehaviour
{
    // prefab "CybePlay"
    public GameObject prefabCubePlay;

    // prefab "CybePlayFrame"
    public GameObject prefabCubePlayFrame;

    // prefab "CybePlayFrame"
    public GameObject prefabHelpButtons;

    // prefab "CubePlay" - colour 
    public Material[] prefabCubePlayDefaultColour;

    public Material[] prefabCubePlayButtonsBackColour; 
    public Material[] cubePlayColourWin;


    private static int _configurationBoardGameNumberOfRows;
    private static int _configurationBoardGameNumberOfColumns;
    private static int _configurationBoardGameNumberOfPlayers;
    private static int _configurationBoardGameNumberForLenghtToCheck;
    private static bool _configurationBoardGameDeviceModeKind;

    public Touch touch;
    private Camera mainCamera;

    public int playersNumberGivenForConfiguration; // = 4;

    private static int numberOfRows;// = 4; //3;// 3;
    private static int numberOfColumns; // = 3;// 6;
    private static bool isCellphoneMode; // = 3;// 6;

    // default = 1; this is needed for future version 3D WeirdTicTacToeGame
    // it is not possible to change from UI
    private static int numberOfDepths = 1;

   // private static int lenghtToCheckMax;
    private static int lenghtToCheck;

    private static bool _isGame2D = true;

    private int _maxCubePlayNumber; // = numberOfRows * numberOfColumns * numberOfDepths;


    private float _cubePlayForFrameScale;


    Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();

    private string _tagCubePlayFree;
    private string _tagCubePlayTaken;
    //private string _tagCubePlayFrame;
    //private string _tagCubePlayGameOver;
    //private string _tagCubePlayGameWin;

    Dictionary<int, string> tagArrowDictionary = GameDictionariesSceneGame.DictionaryTagHelpButtons();

    private string _tagArrowRight; 
    private string _tagArrowLeft; 
    private string _tagArrowUp; 
    private string _tagArrowDown; 
    private string _tagButtonConfirm; 

    //Dictionary<int, string> tagPlayerSymbolDictionary = GameDictionariesSceneGame.DictionaryTagPlayerSymbolMove();

    //private string _tagPlayerSymbolCurrent;
    //private string _tagPlayerSymbolPrevious;
    //private string _tagPlayerSymbolNext;



    Dictionary<int, string> tagGameDictionary = GameDictionariesSceneGame.DictionaryTagGame();

    private string _tagGameButtonMenuConfigurationLeft;
    private string _tagGameButtonMenuConfigurationRight;
    private string _tagGameButtonNewGame;
    private string _tagGameButtonHelpButtons;
    private string _tagGameButtonMenuBack;
    //private string _tagGameButtonParentObjectHelpButtons;
   // private string _tagGameButtonMenuConfigurationDisactivate;

    private int _index;
   
    private string[] _playersSymbols;
    private int[] _currentPlayer;
    private int[] _currentCountedTagCubePlayTaken;


    private ArrayList _listCheckerForWinner = new ArrayList();
    //private int[,] _winnerCoordinateXYForCubePlay;
    private bool _winner = false;
    //private string _winnerKindOfChecker;

    private GameObject[,,] _gameBoard;
    private string[,] _gameBoardVerification2D;

    private GameObject _cubePlayFrame;
    private int[] _moveIndexForFrame;
    private int _moveIndexForFrameX = 0;
    private int _moveIndexForFrameY = 1;

    private string[] _playerSymbolMove;

    //private string[] helpButtonsTag = new string[6];
    //private string[] buttonsMenuConfiguration = new string[3];
    //private string[] topObjectsTag = new string[5];
    //private string[] tagDisactivateConfigurationMenu = new string[3];

    private List<GameObject[,,]> _gameButtonsMenu;



    void Start()
    {
        _tagCubePlayFree = tagCubePlayDictionary[1];
        _tagCubePlayTaken = tagCubePlayDictionary[2];
        //_tagCubePlayFrame = tagCubePlayDictionary[3];
        //_tagCubePlayGameOver = tagCubePlayDictionary[4];
        //_tagCubePlayGameWin = tagCubePlayDictionary[5];


        _tagArrowRight = tagArrowDictionary[1];
        _tagArrowLeft = tagArrowDictionary[3];
        _tagArrowUp = tagArrowDictionary[4];
        _tagArrowDown = tagArrowDictionary[2];
        _tagButtonConfirm = tagArrowDictionary[5];


        //_tagPlayerSymbolCurrent = tagPlayerSymbolDictionary[1];
        //_tagPlayerSymbolPrevious = tagPlayerSymbolDictionary[2];
        //_tagPlayerSymbolNext = tagPlayerSymbolDictionary[3];


        _tagGameButtonMenuConfigurationLeft = tagGameDictionary[1]; ;
        _tagGameButtonMenuConfigurationRight = tagGameDictionary[2]; ;
        _tagGameButtonNewGame = tagGameDictionary[3];
        _tagGameButtonHelpButtons = tagGameDictionary[4];
        _tagGameButtonMenuBack = tagGameDictionary[5];
        //_tagGameButtonParentObjectHelpButtons = tagGameDictionary[6];
       // _tagGameButtonMenuConfigurationDisactivate = tagGameDictionary[7];


        //helpButtonsTag[0] = _tagArrowRight;
        //helpButtonsTag[1] = _tagArrowLeft;
        //helpButtonsTag[2] = _tagArrowUp;
        //helpButtonsTag[3] = _tagArrowDown;
        //helpButtonsTag[4] = _tagButtonConfirm;
        //helpButtonsTag[5] = _tagGameButtonParentObjectHelpButtons;

        //buttonsMenuConfiguration[0] = _tagGameButtonHelpButtons;
        //buttonsMenuConfiguration[1] = _tagGameButtonNewGame;
        //buttonsMenuConfiguration[2] = _tagGameButtonMenuBack;

        //topObjectsTag[0] = _tagPlayerSymbolCurrent;
        //topObjectsTag[1] = _tagPlayerSymbolPrevious;
       // topObjectsTag[2] = _tagPlayerSymbolNext;
       // topObjectsTag[3] = _tagGameButtonMenuConfigurationLeft;  
       // topObjectsTag[4] = _tagGameButtonMenuConfigurationRight;

        //tagDisactivateConfigurationMenu[0] = _tagGameButtonMenuConfigurationDisactivate;
        //tagDisactivateConfigurationMenu[1] = _tagGameButtonMenuConfigurationRight;
        //tagDisactivateConfigurationMenu[2] = _tagGameButtonMenuConfigurationLeft;  

        _index = 0;


        _configurationBoardGameDeviceModeKind = GameConfigurationSetUpBoardGame.ConfigurationBoardGameDeviceModeKind;
        isCellphoneMode = _configurationBoardGameDeviceModeKind;

        _configurationBoardGameNumberOfPlayers = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfPlayers;
        playersNumberGivenForConfiguration = _configurationBoardGameNumberOfPlayers;

        _configurationBoardGameNumberOfRows = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfRows;
       
        numberOfRows = _configurationBoardGameNumberOfRows;

        _configurationBoardGameNumberOfColumns = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfColumns;
        numberOfColumns = _configurationBoardGameNumberOfColumns;

        _maxCubePlayNumber = numberOfRows * numberOfColumns * numberOfDepths;

        _configurationBoardGameNumberForLenghtToCheck = GameConfigurationSetUpBoardGame.ConfigurationBoardGameLenghtToCheck;
        lenghtToCheck = _configurationBoardGameNumberForLenghtToCheck - 1;


        _gameBoardVerification2D = GameConfigurationCommonMethods.CreateEmptyTable2D(numberOfRows, numberOfColumns);

        _playersSymbols = GameConfigurationSetUpPlayersSymbols.ConfigurationPlayerSymbolTableWitPlayersChosenSymbols;



        _currentPlayer = CommonMethods.CreateTableWithGivenLengthAndGivenValue(1, 0);

        // remove tag from method
        //PlayGameChangePlayerSymbol.SetUpPlayerSymbolForMove(_playersSymbols, _tagPlayerSymbolCurrent, _tagPlayerSymbolPrevious, _tagPlayerSymbolNext);
        PlayGameChangePlayerSymbol.SetUpPlayerSymbolForMoveAtStart(_playersSymbols);

        _playerSymbolMove = PlayGameChangePlayerSymbol.CreateTableWithPlayersSymbolsMove(_playersSymbols);

        _currentCountedTagCubePlayTaken = CommonMethods.CreateTableWithGivenLengthAndGivenValue(1, 0);


        // [gameBoard] - creating the board game with game object "CubePlay"
        //_gameBoard = CreateGameBoard.CreateBoardGame(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, _isGame2D);
        _gameBoard = CreateGameBoard.CreateBoardGame(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, _isGame2D, isCellphoneMode);

        GameObject cubePlayForFrame = _gameBoard[0, numberOfRows - 1, 0];
        // scale for cubePlayFrame taken from cubePlay, it is cube so one cooridinate is enought
        _cubePlayForFrameScale = cubePlayForFrame.transform.localScale.x;

        _moveIndexForFrame = PlayGameFrameMove.CreateTableForMoveIndexForFrame(numberOfRows);

        _cubePlayFrame = CreateFrameForMove.CreateCubePlayFrame(prefabCubePlayFrame, cubePlayForFrame, _isGame2D);

       // PlayGameHelpButtonsCreate.CreateHelpButtonsAtStart(prefabHelpButtons, numberOfRows, numberOfColumns);
        PlayGameHelpButtonsCreate.CreateHelpButtonsAtStart(prefabHelpButtons, numberOfRows, numberOfColumns, isCellphoneMode);
    
    
    
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
                    string gameObjectTag = CommonMethods.GetObjectTag(touch);
                    string gameObjectName = CommonMethods.GetObjectName(touch);


                    int currentPlayerNumber = _currentPlayer[0];
                    GameObject cubePlay = CommonMethods.GetCubePlay(_gameBoard, gameObjectName);
                    
                    // move by arrows 
                    if (gameObjectTag == _tagArrowRight || gameObjectTag == _tagArrowLeft || gameObjectTag == _tagArrowDown || gameObjectTag == _tagArrowUp)
                    {
                        // remove tag form method and create new method
                        //cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);
                        _cubePlayFrame = PlayGameFrameMove.GetCubePlayFrame();
                        _moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(_moveIndexForFrame, gameObjectTag,   _cubePlayFrame, _cubePlayForFrameScale, numberOfRows, numberOfColumns);
                   
                    }
                    

                    if (gameObjectTag == _tagButtonConfirm)
                    {
                        int indexX = _moveIndexForFrame[_moveIndexForFrameX];
                        int indexY = _moveIndexForFrame[_moveIndexForFrameY];

                        GameObject cubePlayMarkByFrame = CommonMethods.GetCubePlay(_gameBoard, indexY, indexX);
                        string cubePlayMarkByFrameName = CommonMethods.GetObjectName(cubePlayMarkByFrame);
                        string cubePlayMarkByFrameTag = CommonMethods.GetObjectTag(cubePlayMarkByFrame);

                        if (cubePlayMarkByFrameTag == _tagCubePlayFree)
                        {
                            var cubePlayDataZYXSymbol = PlayGameChangeCubePlaySymbol.SetUpPlayerSymbolForCubePlay(_gameBoard, cubePlayMarkByFrameName, _playersSymbols, currentPlayerNumber);
                            PlayGameMethods.ChangeCoordinateZForCubePlayAfterClickOnTheCubePlay(cubePlayMarkByFrame);

                            int cubePlayIndexY = cubePlayDataZYXSymbol.Item1.Item2;
                            int cubePlayIndexX = cubePlayDataZYXSymbol.Item1.Item3;
                            string cubePlaySymbol = cubePlayDataZYXSymbol.Item2;

                            _gameBoardVerification2D[cubePlayIndexY, cubePlayIndexX] = cubePlaySymbol;

                            _playerSymbolMove = PlayGameChangePlayerSymbol.ChangeCurrentPlayersSymbolsMove(_playerSymbolMove, _playersSymbols, playersNumberGivenForConfiguration, _currentPlayer);

                            _listCheckerForWinner = GameFieldsVerification.FieldsVerification(_gameBoardVerification2D, lenghtToCheck);

                            _winner = (bool)_listCheckerForWinner[0];

                            if (_winner == true)
                            {
                                // create one destoy method
                                //PlayGameFrameMove.DestroyCubePlayFrame(cubePlayFrame);
                                //PlayGameHelpButtonsActions.DestroyHelpButtons();
                                PlayGameMenuButtonsActions.DestroyElements(_cubePlayFrame);

                                PlayGameMenuButtonsActions.DisactivateConfigurationMenu();
                                PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_winner, cubePlaySymbol);

                                PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin);

                                PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, cubePlayColourWin, _isGame2D);

                                GameFieldsVerificationMessages.WinMessage(cubePlaySymbol);

                            }
                            else
                            {

                                _currentPlayer = PlayGameChangeCubePlaySymbol.SetUpCurrentPlayer(_currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                                // remove tag from method + create new method
                                //CommonMethods.ChangeTagForGameObject(cubePlayMarkByFrame, _tagCubePlayTaken);
                                PlayGameMethods.DisactivateChosenCubePlay(cubePlayMarkByFrame);


                                _currentCountedTagCubePlayTaken = CommonMethods.SetUpNewCurrentNumberByAddition(_currentCountedTagCubePlayTaken, _index);

                                countedTagCubePlayTaken = _currentCountedTagCubePlayTaken[_index];

                                if (countedTagCubePlayTaken >= _maxCubePlayNumber)
                                {
                                    /// create one destroy method
                                    //PlayGameFrameMove.DestroyCubePlayFrame(cubePlayFrame);
                                    //PlayGameHelpButtonsActions.DestroyHelpButtons();
                                    PlayGameMenuButtonsActions.DestroyElements(_cubePlayFrame);

                                    PlayGameMenuButtonsActions.DisactivateConfigurationMenu();
                                    PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_winner, cubePlaySymbol);

                                    PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, cubePlayColourWin, _isGame2D);

                                    Debug.Log("Game Over :) Would you like to start new game? Yes No");
                                }
                            }

                        }
                        else // (gameObjectTag1 == _tagCubePlayTaken)
                        {
                            Debug.Log("CubePlay has already been taken by another player.");
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

                            // remove tag from method + create method for playGameMethod
                            //cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);
                            _cubePlayFrame = PlayGameFrameMove.GetCubePlayFrame();

                            PlayGameFrameMove.SetUpNewXYForCubePlayFrame(_cubePlayFrame, cubePlay);


                            _moveIndexForFrame[_moveIndexForFrameX] = cubePlayIndexX;
                            _moveIndexForFrame[_moveIndexForFrameY] = cubePlayIndexY;

                            _playerSymbolMove = PlayGameChangePlayerSymbol.ChangeCurrentPlayersSymbolsMove(_playerSymbolMove, _playersSymbols, playersNumberGivenForConfiguration, _currentPlayer);

                            _listCheckerForWinner = GameFieldsVerification.FieldsVerification(_gameBoardVerification2D, lenghtToCheck);

                            _winner = (bool)_listCheckerForWinner[0];


                            if (_winner == true)
                            {
                                // create one method for destroy
                                //PlayGameFrameMove.DestroyCubePlayFrame(cubePlayFrame);


                                //PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin);

                                //PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_winner, cubePlaySymbol);


                                //GameFieldsVerificationMessages.WinMessage(cubePlaySymbol);

                                //PlayGameHelpButtonsActions.DestroyHelpButtons();


                                //PlayGameMenuButtonsActions.DisactivateConfigurationMenu();


                                //PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, cubePlayColourWin, isGame2D);

                                // create one destoy method
                                //PlayGameFrameMove.DestroyCubePlayFrame(cubePlayFrame);
                                //PlayGameHelpButtonsActions.DestroyHelpButtons();
                                PlayGameMenuButtonsActions.DestroyElements(_cubePlayFrame);

                                PlayGameMenuButtonsActions.DisactivateConfigurationMenu();
                                PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_winner, cubePlaySymbol);

                                PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin);

                                PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, cubePlayColourWin, _isGame2D);

                                GameFieldsVerificationMessages.WinMessage(cubePlaySymbol);

                            }
                            else
                            {


                                _currentPlayer = PlayGameChangeCubePlaySymbol.SetUpCurrentPlayer(_currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                                // add method to playGameMethod it looks bad + remove tag from method
                                //CommonMethods.ChangeTagForGameObject(touch, _tagCubePlayTaken);
                                PlayGameMethods.DisactivateChosenCubePlay(touch);

                                _currentCountedTagCubePlayTaken = CommonMethods.SetUpNewCurrentNumberByAddition(_currentCountedTagCubePlayTaken, _index);

                                countedTagCubePlayTaken = _currentCountedTagCubePlayTaken[_index];



                                if (countedTagCubePlayTaken >= _maxCubePlayNumber)
                                {
                                    // create one destroy method
                                    //PlayGameFrameMove.DestroyCubePlayFrame(cubePlayFrame);

                                    //PlayGameHelpButtonsActions.DestroyHelpButtons();

                                    //PlayGameHelpButtonsActions.DestroyHelpButtons();

                                    //PlayGameMenuButtonsActions.DisactivateConfigurationMenu();

                                    
                                    //PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, cubePlayColourWin, isGame2D);

                                
                                    //PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_winner, cubePlaySymbol);


                                    PlayGameMenuButtonsActions.DestroyElements(_cubePlayFrame);

                                    PlayGameMenuButtonsActions.DisactivateConfigurationMenu();
                                    PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(_winner, cubePlaySymbol);

                                    PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, cubePlayColourWin, _isGame2D);
                                    

                                    //PlayGameChangeCubePlayForWinner.ChangeAllCubePlayAfterWin(_gameBoard, cubePlaySymbol, _listCheckerForWinner, prefabCubePlayFrame, cubePlayColourWin);

                                    
  
                                    Debug.Log("Game Over :) Would you like to start new game? Yes No");
                                }

                            }



                        }
                        else
                        {
                            Debug.Log("CubePlay has already been taken by another player.");
                        }
                    }


                    if (gameObjectTag == _tagGameButtonMenuConfigurationLeft || gameObjectTag == _tagGameButtonMenuConfigurationRight)
                    {
                        PlayGameMenuButtonsActions.HidePlayGameElements(_gameBoard);
                        _gameButtonsMenu = PlayGameMenuButtonsCreate.CreateButtonsMenu(prefabCubePlay, cubePlayColourWin, prefabCubePlayButtonsBackColour, _isGame2D);

                    }


                    if (gameObjectTag == _tagGameButtonHelpButtons)
                    {
                        PlayGameHelpButtonsActions.HelpButtonsActionsCreateOrDestroy(prefabHelpButtons);
                        PlayGameMenuButtonsActions.DestroyGameConfigurationMenuButtons(_gameButtonsMenu);
                        PlayGameMenuButtonsActions.UnhidePlayGameElementsHelpButtons(_gameBoard);

                    }


                    if (gameObjectTag == _tagGameButtonMenuBack)
                    {
                        PlayGameMenuButtonsActions.DestroyGameConfigurationMenuButtons(_gameButtonsMenu);
                        PlayGameMenuButtonsActions.UnhidePlayGameElements(_gameBoard);
                        
                    }


                    if (gameObjectTag ==  _tagGameButtonNewGame)
                    {
                        ScenesChange.GoToSceneConfigurationBoardGame();
                        
                    }





                }
            }   
        }
    }


    // TO DO:
    // GameBoardCreateScale - > FindSmallestScaleXYZForPrefabCubePlay
    // to do: add the method checking the screen width and height, than add the method return the max rows and max rows for tablet
}
