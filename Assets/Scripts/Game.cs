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

    public Material[] cubePlayColourWin;


    private static int _configurationBoardGameNumberOfRows;
    private static int _configurationBoardGameNumberOfColumns;
    private static int _configurationBoardGameNumberOfPlayers;
    private static int _configurationBoardGameNumberForLenghtToCheck;

    public void Awake()
    {
        //dataFromScenece1 = GameConfigurationSetUpBoardGame.scence1.test;
        //int teeeee = Int32.Parse(dataFromScenece1);
        //numberOfRows = teeeee;
    }
   
    //private static int teeeee = Int32.Parse(dataFromScenece1);
    public Touch touch;
    private Camera mainCamera;

    //public TextMeshProUGUI cubePlayChangeText;

    //public int playersNumberGivenForConfiguration1 = 2;

    public int playersNumberGivenForConfiguration; // = 4;



    private int _minNumberOfRows = 3;
    private int _minNumberOfColumns = 3;
    private int _minNumbersCubesForDepthZ = 3;

    private static int numberOfRows;// = 4; //3;// 3;
    private static int numberOfColumns; // = 3;// 6;

    // default = 1; this is needed for future version 3D WeirdTicTacToeGame
    // it is not possible to change from UI
    private static int numberOfDepths = 1;

    private static int lenghtToCheckMax;
    private static int lenghtToCheck;
    //private static int lenghtToCheckGivenByUser = 3; 

    private static bool isGame2D = true;

    private int maxCubePlayNumber; // = numberOfRows * numberOfColumns * numberOfDepths;


    private float _cubePlayForFrameScale;
    //public string tagCubePlayFree = "CubePlayFree";
    //public string tagCubePlayFree2 = "CubePlayFree";
    //public string tagCubePlayTaken = "CubePlayTaken";

    Dictionary<int, string> tagCubePlayDictionary = GameDictionariesCommon.DictionaryTagCubePlay();

    private string _tagCubePlayFree;
    private string _tagCubePlayTaken;
    private string _tagCubePlayFrame;
    private string _tagCubePlayGameOver;
    private string _tagCubePlayGameWin;

    Dictionary<int, string> tagArrowDictionary = GameDictionariesCommon.DictionaryTagHelpButtons();

    private string _tagArrowRight;
    private string _tagArrowLeft;
    private string _tagArrowUp;
    private string _tagArrowDown;
    private string _tagButtonConfirm;

    Dictionary<int, string> tagPlayerSymbolDictionary = GameDictionariesCommon.DictionaryTagPlayerSymbol();

    private string _tagPlayerSymbolCurrent;
    private string _tagPlayerSymbolPrevious;
    private string _tagPlayerSymbolNext;



    Dictionary<int, string> tagGameDictionary = GameDictionariesCommon.DictionaryTagGame();

    private string _tagGameButtonMenuConfigurationLeft;
    private string _tagGameButtonMenuConfigurationRight;
    private string _tagGameButtonNewGame;
    private string _tagGameButtonHelpButtons;
    private string _tagGameButtonMenuBack;
    private string _tagGameButtonParentObjectHelpButtons;
    private string _tagGameButtonMenuConfigurationDisactivate;


    Dictionary<int, string> scenceDictionary = GameDictionariesCommon.DictionaryScence();

    private string _sceneSceneConfigurationBoardGame;

    private int _index;
   

    int[] playerNumber;
    string[] playersSymbols;
    int[] currentPlayer;
    int[] currentCountedTagCubePlayTaken;

    private ArrayList _listCheckerForWinner = new ArrayList();
    private int[,] _winnerCoordinateXYForCubePlay;
    private bool _winner = false;
    private string _winnerKindOfChecker;

    GameObject[,,] gameBoard;
    string[,] gameBoardVerification2D;

    GameObject cubePlayFrame;
    int[] moveIndexForFrame;
    private int _moveIndexForFrameX = 0;
    private int _moveIndexForFrameY = 1;

    string[] playerSymbolMove;

    string[] helpButtonsTag = new string[6];
    string[] buttonsMenuConfiguration = new string[3];
    string[] topObject = new string[5];
    string[] tagDisactivateConfigurationMenu = new string[3];

    private List<GameObject[,,]> gameButtonsMenu;



    void Start()
    {
        //Debug.Log("playersNumberGivenForConfiguration1 = " + playersNumberGivenForConfiguration1);

        _tagCubePlayFree = tagCubePlayDictionary[1];
        _tagCubePlayTaken = tagCubePlayDictionary[2];
        _tagCubePlayFrame = tagCubePlayDictionary[3];
        _tagCubePlayGameOver = tagCubePlayDictionary[4];
        _tagCubePlayGameWin = tagCubePlayDictionary[5];


        _tagArrowRight = tagArrowDictionary[1];
        _tagArrowLeft = tagArrowDictionary[3];
        _tagArrowUp = tagArrowDictionary[4];
        _tagArrowDown = tagArrowDictionary[2];
        _tagButtonConfirm = tagArrowDictionary[5];


        _tagPlayerSymbolCurrent = tagPlayerSymbolDictionary[1];
        _tagPlayerSymbolPrevious = tagPlayerSymbolDictionary[2];
        _tagPlayerSymbolNext = tagPlayerSymbolDictionary[3];


        _tagGameButtonMenuConfigurationLeft = tagGameDictionary[1]; ;
        _tagGameButtonMenuConfigurationRight = tagGameDictionary[2]; ;
        _tagGameButtonNewGame = tagGameDictionary[3];
        _tagGameButtonHelpButtons = tagGameDictionary[4];
        _tagGameButtonMenuBack = tagGameDictionary[5];
        _tagGameButtonParentObjectHelpButtons = tagGameDictionary[6];
        _tagGameButtonMenuConfigurationDisactivate = tagGameDictionary[7];


        helpButtonsTag[0] = _tagArrowRight;
        helpButtonsTag[1] = _tagArrowLeft;
        helpButtonsTag[2] = _tagArrowUp;
        helpButtonsTag[3] = _tagArrowDown;
        helpButtonsTag[4] = _tagButtonConfirm;
        helpButtonsTag[5] = _tagGameButtonParentObjectHelpButtons;

        buttonsMenuConfiguration[0] = _tagGameButtonHelpButtons;
        buttonsMenuConfiguration[1] = _tagGameButtonNewGame;
        buttonsMenuConfiguration[2] = _tagGameButtonMenuBack;

        topObject[0] = _tagPlayerSymbolCurrent;
        topObject[1] = _tagPlayerSymbolPrevious;
        topObject[2] = _tagPlayerSymbolNext;
        topObject[3] = _tagGameButtonMenuConfigurationLeft;  
        topObject[4] = _tagGameButtonMenuConfigurationRight;

        tagDisactivateConfigurationMenu[0] = _tagGameButtonMenuConfigurationDisactivate;
        tagDisactivateConfigurationMenu[1] = _tagGameButtonMenuConfigurationRight;
        tagDisactivateConfigurationMenu[2] = _tagGameButtonMenuConfigurationLeft;  


        _sceneSceneConfigurationBoardGame = scenceDictionary[3];

        _index = 0;


        _configurationBoardGameNumberOfPlayers = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfPlayers;
        playersNumberGivenForConfiguration = _configurationBoardGameNumberOfPlayers;

        _configurationBoardGameNumberOfRows = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfRows;
        //Debug.Log("dataFromScenece1 = " + dataFromScenece1);
       // numberOfRows = CommonMethods.ConvertStringToInt(_configurationBoardGameNumberOfRows);
        numberOfRows = _configurationBoardGameNumberOfRows;

        _configurationBoardGameNumberOfColumns = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfColumns;
        numberOfColumns = _configurationBoardGameNumberOfColumns;

        maxCubePlayNumber = numberOfRows * numberOfColumns * numberOfDepths;

        // lenghtToCheckMax = GameFieldsVerificationCheckerLenght.SetUpMaxLenghtToCheck(numberOfRows, numberOfColumns);
        //lenghtToCheck = GameFieldsVerificationCheckerLenght.SetUpLenghtToCheck(lenghtToCheckMax, lenghtToCheckGivenByUser);

        _configurationBoardGameNumberForLenghtToCheck = GameConfigurationSetUpBoardGame.ConfigurationBoardGameLenghtToCheck;
        lenghtToCheck = _configurationBoardGameNumberForLenghtToCheck - 1;


        gameBoardVerification2D = GameConfigurationCommonMethods.CreateEmptyTable2D(numberOfRows, numberOfColumns);

        // does it need it?
        playerNumber = GameConfigurationTableForPlayers.CreateTableWithPlayersNumber(playersNumberGivenForConfiguration);

        

        // static
        //playersSymbols = GameConfigurationCommonMethods.CreateTableWithPlayersSymbols();

        playersSymbols = GameConfigurationSetUpPlayersSymbols.ConfigurationPlayerSymbolTableWitPlayersChosenSymbols;


        currentPlayer = CommonMethods.CreateTableWithGivenLengthAndGivenValue(1, 0);

        PlayGameChangePlayerSymbol.SetUpPlayerSymbolForMove(playersSymbols, _tagPlayerSymbolCurrent, _tagPlayerSymbolPrevious, _tagPlayerSymbolNext);

        playerSymbolMove = PlayGameChangePlayerSymbol.CreateTableWithPlayersSymbolsMove(playersSymbols);








        currentCountedTagCubePlayTaken = CommonMethods.CreateTableWithGivenLengthAndGivenValue(1, 0);



        // [gameBoard] - creating the board game with game object "CubePlay"
        gameBoard = CreateGameBoard.CreateBoardGame(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);

        GameObject cubePlayForFrame = gameBoard[0, numberOfRows - 1, 0];
        // scale for cubePlayFrame taken from cubePlay, it is cube so one cooridinate is enought
        _cubePlayForFrameScale = cubePlayForFrame.transform.localScale.x;

        moveIndexForFrame = PlayGameFrameMove.CreateTableForMoveIndexForFrame(numberOfRows);
        //moveIndexForFrame[1] = numberOfRows - 1;
        //Debug.Log("moveIndexForFrame[0] = " + moveIndexForFrame[0]);
        //Debug.Log("moveIndexForFrame[1] = " + moveIndexForFrame[1]);
        //Debug.Log(" --------------------------------- " );

        cubePlayFrame = CreateFrameForMove.CreateCubePlayFrame(prefabCubePlayFrame, cubePlayForFrame, isGame2D);

        //float x = cubePlayFrame.transform.position.x;
        //float y = cubePlayFrame.transform.position.y;
        //float z = cubePlayFrame.transform.position.z;

        //Debug.Log("set up y =  " + y);
        // Debug.Log(" y + newCoordinateY =  " + (y + newCoordinateY));

    }


    // Update is called once per frame
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


                    int currentPlayerNumber = currentPlayer[0];
                    GameObject cubePlay = CommonMethods.GetCubePlay(gameBoard, gameObjectName);
                    
                    // move by arrows 
                    if (gameObjectTag == _tagArrowRight || gameObjectTag == _tagArrowLeft || gameObjectTag == _tagArrowDown || gameObjectTag == _tagArrowUp)
                    {
                        cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);
                        moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, cubePlayFrame, _cubePlayForFrameScale, numberOfRows, numberOfColumns);
                   
                    }
                    

                    if (gameObjectTag == _tagButtonConfirm)
                    {
                        int indexX = moveIndexForFrame[_moveIndexForFrameX];
                        int indexY = moveIndexForFrame[_moveIndexForFrameY];

                        GameObject cubePlayMarkByFrame = CommonMethods.GetCubePlay(gameBoard, indexY, indexX);
                        string cubePlayMarkByFrameName = CommonMethods.GetObjectName(cubePlayMarkByFrame);
                        string cubePlayMarkByFrameTag = CommonMethods.GetObjectTag(cubePlayMarkByFrame);

                        if (cubePlayMarkByFrameTag == _tagCubePlayFree)
                        {
                            var cubePlayDataZYXSymbol = PlayGameChangeCubePlaySymbol.SetUpPlayerSymbolForCubePlay(gameBoard, cubePlayMarkByFrameName, playersSymbols, currentPlayerNumber);
                            PlayGameMethods.ChangeCoordinateZForCubePlayAfterClickOnTheCubePlay(cubePlayMarkByFrame);

                            int cubePlayIndexY = cubePlayDataZYXSymbol.Item1.Item2;
                            int cubePlayIndexX = cubePlayDataZYXSymbol.Item1.Item3;
                            string cubePlaySymbol = cubePlayDataZYXSymbol.Item2;

                            gameBoardVerification2D[cubePlayIndexY, cubePlayIndexX] = cubePlaySymbol;

                            playerSymbolMove = PlayGameChangePlayerSymbol.ChangeCurrentPlayersSymbolsMove(playerSymbolMove, playersSymbols, playersNumberGivenForConfiguration, currentPlayer, _tagPlayerSymbolCurrent, _tagPlayerSymbolPrevious, _tagPlayerSymbolNext);

                            _listCheckerForWinner = GameFieldsVerification.FieldsVerification(gameBoardVerification2D, lenghtToCheck);

                            _winner = (bool)_listCheckerForWinner[0];

                            if (_winner == true)
                            {
                                _winnerCoordinateXYForCubePlay = (int[,])_listCheckerForWinner[1];
                                _winnerKindOfChecker = (string)_listCheckerForWinner[2];

                                PlayGameFrameMove.SetUpNewZForCubePlayFrame(cubePlayFrame);
                                PlayGameChangeCubePlaForWinner.ChangeAllCubePlayAfterWin(gameBoard, cubePlaySymbol, _winnerCoordinateXYForCubePlay, _winnerKindOfChecker, _tagCubePlayGameWin, _tagCubePlayGameOver, prefabCubePlayFrame, cubePlayColourWin);
                                PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(cubePlaySymbol, _tagPlayerSymbolCurrent, _tagPlayerSymbolPrevious, _tagPlayerSymbolNext);

                                GameFieldsVerificationMessages.WinMessage(cubePlaySymbol);

                                bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(_tagGameButtonParentObjectHelpButtons);

                                if (isGameObjectWithTagExsist == true)
                                {
                                    PlayGameHelpButtons.DestroyHelpButtons(helpButtonsTag);
                                }

                                PlayGameMenuButtonsActions.DisactivateConfigurationMenu(tagDisactivateConfigurationMenu);
                                PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, cubePlayColourWin, isGame2D);

                            }
                            else
                            {

                                currentPlayer = PlayGameChangeCubePlaySymbol.SetUpCurrentPlayer(currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                                //cubePlayMarkByFrame.transform.tag = _tagCubePlayTaken;
                                CommonMethods.ChangeTagForGameObject(cubePlayMarkByFrame, _tagCubePlayTaken);
                                currentCountedTagCubePlayTaken = CommonMethods.SetUpNewCurrentNumberByAddition(currentCountedTagCubePlayTaken, _index);

                                countedTagCubePlayTaken = currentCountedTagCubePlayTaken[_index];

                                if (countedTagCubePlayTaken >= maxCubePlayNumber)
                                { 
                                    PlayGameFrameMove.SetUpNewZForCubePlayFrame(cubePlayFrame);
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
                            
                            var cubePlayDataZYXSymbol = PlayGameChangeCubePlaySymbol.SetUpPlayerSymbolForCubePlay(gameBoard, gameObjectName, playersSymbols, currentPlayerNumber);

                            PlayGameMethods.ChangeCoordinateZForCubePlayAfterClickOnTheCubePlay(cubePlay);

                            int cubePlayIndexY = cubePlayDataZYXSymbol.Item1.Item2;
                            int cubePlayIndexX = cubePlayDataZYXSymbol.Item1.Item3;
                            string cubePlaySymbol = cubePlayDataZYXSymbol.Item2;

                            gameBoardVerification2D[cubePlayIndexY, cubePlayIndexX] = cubePlaySymbol;

                            cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);
                            PlayGameFrameMove.SetUpNewXYForCubePlayFrame(cubePlayFrame, cubePlay);
                            moveIndexForFrame[_moveIndexForFrameX] = cubePlayIndexX;
                            moveIndexForFrame[_moveIndexForFrameY] = cubePlayIndexY;

                            playerSymbolMove = PlayGameChangePlayerSymbol.ChangeCurrentPlayersSymbolsMove(playerSymbolMove, playersSymbols, playersNumberGivenForConfiguration, currentPlayer, _tagPlayerSymbolCurrent, _tagPlayerSymbolPrevious, _tagPlayerSymbolNext);

                            _listCheckerForWinner = GameFieldsVerification.FieldsVerification(gameBoardVerification2D, lenghtToCheck);

                            _winner = (bool)_listCheckerForWinner[0];


                            if (_winner == true)
                            {

                                _winnerCoordinateXYForCubePlay = (int[,])_listCheckerForWinner[1];
                                _winnerKindOfChecker = (string)_listCheckerForWinner[2];

                                PlayGameFrameMove.SetUpNewZForCubePlayFrame(cubePlayFrame);
                                PlayGameChangeCubePlaForWinner.ChangeAllCubePlayAfterWin(gameBoard, cubePlaySymbol, _winnerCoordinateXYForCubePlay, _winnerKindOfChecker, _tagCubePlayGameWin, _tagCubePlayGameOver, prefabCubePlayFrame, cubePlayColourWin);

                                PlayGameChangePlayerSymbol.SetUpPlayerSymbolForWinner(cubePlaySymbol, _tagPlayerSymbolCurrent, _tagPlayerSymbolPrevious, _tagPlayerSymbolNext);

                                GameFieldsVerificationMessages.WinMessage(cubePlaySymbol);

                                bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(_tagGameButtonParentObjectHelpButtons);

                                if (isGameObjectWithTagExsist == true)
                                {
                                    PlayGameHelpButtons.DestroyHelpButtons(helpButtonsTag);
                                }

                                PlayGameMenuButtonsActions.DisactivateConfigurationMenu(tagDisactivateConfigurationMenu);
                                PlayGameMenuButtonsCreate.CreateButtonNewGame(prefabCubePlay, cubePlayColourWin, isGame2D);
                            }

                            else
                            {


                                currentPlayer = PlayGameChangeCubePlaySymbol.SetUpCurrentPlayer(currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                                CommonMethods.ChangeTagForGameObject(touch, _tagCubePlayTaken);
                                currentCountedTagCubePlayTaken = CommonMethods.SetUpNewCurrentNumberByAddition(currentCountedTagCubePlayTaken, _index);

                                countedTagCubePlayTaken = currentCountedTagCubePlayTaken[_index];



                                if (countedTagCubePlayTaken >= maxCubePlayNumber)
                                {
                                    PlayGameFrameMove.SetUpNewZForCubePlayFrame(cubePlayFrame);
                                    Debug.Log("Game Over :) Would you like to start new game? Yes No");
                                }

                            }



                        }
                        else
                        {
                            Debug.Log("CubePlay has already been taken by another player.");
                        }
                    }


                    if (gameObjectTag == _tagGameButtonMenuConfigurationLeft |gameObjectTag == _tagGameButtonMenuConfigurationRight)
                    {
                        // Debug.Log("  1  ");
                        //CreateGameConfigurationMenu.HideBoardGame(gameBoard);
                        PlayGameMenuButtonsActions.HideBoardGame(gameBoard);

                        //float x = cubePlayFrame.transform.position.x;
                        //float y = cubePlayFrame.transform.position.y;
                        //float z = cubePlayFrame.transform.position.z;
                        //Debug.Log("tag y =  " + y);

                        //CreateGameConfigurationMenu.HideCubePlayFrame2(cubePlayFrame);
                        PlayGameMenuButtonsActions.HideGameObjectWithTag(_tagCubePlayFrame);

                        bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(_tagGameButtonParentObjectHelpButtons);

                        if (isGameObjectWithTagExsist == true)
                        {
                            PlayGameMenuButtonsActions.HideGameObjectWithTag(_tagGameButtonParentObjectHelpButtons);
                        }

                        PlayGameMenuButtonsActions.HideTopObject(topObject);
                        //CreateGameConfigurationMenu.HideHelpButtons(helpButtonsTag);

                        //CreateGameConfigurationMenu.HideTopObject(topObject);

                        // CreateGameConfigurationMenu.HideCubePlayFrame2(cubePlayFrame);




                        //CreateGameConfigurationMenu.CreateConfigurationButtonHide(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
                        //CreateGameConfigurationMenu.CreateConfigurationButtonShow(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
                        //CreateGameConfigurationMenu.CreateConfigurationButtonNewGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
                        //CreateGameConfigurationMenu.CreateConfigurationButtonBackToGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);

                        gameButtonsMenu = PlayGameMenuButtonsCreate.CreateButtonsMenu(prefabCubePlay, cubePlayColourWin, isGame2D);

                    }


                    if (gameObjectTag == _tagGameButtonHelpButtons)
                    {
                        //GameObject[] numberOfTags = GameObject.FindGameObjectsWithTag(_tagGameButtonParentObjectHelpButtons);
                        //int numberOfTagsLength = numberOfTags.Length;
                        bool isGameButtonParentObjectHelpButtons = CommonMethods.IsGameObjectWithTagExsist(_tagGameButtonParentObjectHelpButtons);

                        if (isGameButtonParentObjectHelpButtons == true)
                        {
                            PlayGameHelpButtons.DestroyHelpButtons(helpButtonsTag);
                        }
                        else
                        {
                            PlayGameHelpButtons.CreateHelpButtons(prefabHelpButtons);
                        }

                        //if (isGameObjectWithTagExsist == true)
                        //{
                        //    CreateGameConfigurationMenu.UnhideGameObjectWithTag(_tagGameButtonParentObjectHelpButtons);
                        //}

                        PlayGameMenuButtonsActions.DestroyGameConfigurationMenuButtons(gameButtonsMenu, buttonsMenuConfiguration);

                        PlayGameMenuButtonsActions.UnhideTopObject(topObject);
                        PlayGameMenuButtonsActions.UnhideBoardGame(gameBoard);
                        PlayGameMenuButtonsActions.UnhideGameObjectWithTag(_tagCubePlayFrame);
                    }


                    if (gameObjectTag == _tagGameButtonMenuBack)
                    {
                        PlayGameMenuButtonsActions.UnhideTopObject(topObject);
                        PlayGameMenuButtonsActions.UnhideBoardGame(gameBoard);
                        PlayGameMenuButtonsActions.UnhideGameObjectWithTag(_tagCubePlayFrame);

                        bool isGameObjectWithTagExsist = CommonMethods.IsGameObjectWithTagExsist(_tagGameButtonParentObjectHelpButtons);

                        if (isGameObjectWithTagExsist == true)
                        {
                            PlayGameMenuButtonsActions.UnhideGameObjectWithTag(_tagGameButtonParentObjectHelpButtons);
                        }

                        PlayGameMenuButtonsActions.DestroyGameConfigurationMenuButtons(gameButtonsMenu, buttonsMenuConfiguration);

                        // --- test
                        //ButtonsText.CreateTableWithGivenStringFor3Rows(14, "");


                    }


                    if (gameObjectTag ==  _tagGameButtonNewGame)
                    {

                        CommonMethods.ChangeScene(_sceneSceneConfigurationBoardGame);
                    }




                    // --------------------------------------------
                    // --- test

                    //CreateGameConfigurationMenu.CreateConfigurationButton(prefabCubePlay, cubePlayColourWin, isGame2D);










                }
            }

           
        }


       



    }


    // TO DO:
    // GameBoardCreateScale - > FindSmallestScaleXYZForPrefabCubePlay
    // to do: add the method checking the screen width and height, than add the method return the max rows and max rows for tablet
}
