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
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using Assets.Scripts.GameFieldsVerification;
using Assets.Scripts.PlayGame;
using Assets.Scripts.GameDictionaries;
using System.Reflection;

internal class Game : MonoBehaviour
{
    // prefab "CybePlay"
    public GameObject prefabCubePlay;
    public GameObject prefabCubePlayFrame;

    // prefab "CubePlay" - colour 
    public Material[] prefabCubePlayDefaultColour;

    public Material[] cubePlayColourWin;






    public Touch touch;
    private Camera mainCamera;

    //public TextMeshProUGUI cubePlayChangeText;

    public int playersNumberGivenForConfiguration = 4;

    private int _minNumberOfRows = 3;
    private int _minNumberOfColumns = 3;
    private int _minNumbersCubesForDepthZ = 3;

    private static int numberOfRows = 9;// 3;
    private static int numberOfColumns = 6;// 6;

    // default = 1; this is needed for future version 3D WeirdTicTacToeGame
    // it is not possible to change from UI
    private static int numberOfDepths = 1;

    private static int lenghtToCheckMax;
    private static int lenghtToCheck;
    private static int lenghtToCheckGivenByUser = 3; 

    private static bool isGame2D = true;

    private int maxCubePlayNumber = numberOfRows * numberOfColumns * numberOfDepths;


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

    GameObject[] playerSymbolMove;

    void Start()
    {

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

        _index = 0;

        lenghtToCheckMax = GameFieldsVerificationCheckerLenght.SetUpMaxLenghtToCheck(numberOfRows, numberOfColumns);
        lenghtToCheck = GameFieldsVerificationCheckerLenght.SetUpLenghtToCheck(lenghtToCheckMax, lenghtToCheckGivenByUser);
       // Debug.Log("lenghtToCheck = " + lenghtToCheck);

       //int lenghtToCheck = GameFieldsVerificationCheckerLenght.CheckerLenght(numberOfRows-1, numberOfColumns-1);
      // Debug.Log("lenghtToCheck = " + lenghtToCheck);


        gameBoardVerification2D = GameConfiguration.CreateEmptyTable2D(numberOfRows, numberOfColumns);

        // does it need it?
        playerNumber = GameConfiguration.CreateTableWithPlayersNumber(playersNumberGivenForConfiguration);

        


        playersSymbols = GameConfiguration.CreateTableWithPlayersSymbols();
        currentPlayer = CommonMethods.CreateTableWithGivenLengthAndGivenValue(1, 0);

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

        cubePlayFrame = CreateGameBoard.CreateCubePlayFrame(prefabCubePlayFrame, cubePlayForFrame, isGame2D);




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

                            //Debug.Log(" 0 ");
                            _listCheckerForWinner = GameFieldsVerification.FieldsVerification(gameBoardVerification2D, lenghtToCheck);
                            //Debug.Log(" 1 ");
                            _winner = (bool)_listCheckerForWinner[0];

                            if (_winner == true)
                            {
                                _winnerCoordinateXYForCubePlay = (int[,])_listCheckerForWinner[1];
                                _winnerKindOfChecker = (string)_listCheckerForWinner[2];

                                PlayGameFrameMove.SetUpNewZForCubePlayFrame(cubePlayFrame);
                                PlayGameChangeCubePlaForWinner.ChangeAllCubePlayAfterWin(gameBoard, cubePlaySymbol, _winnerCoordinateXYForCubePlay, _winnerKindOfChecker, _tagCubePlayGameWin, _tagCubePlayGameOver, prefabCubePlayFrame, cubePlayColourWin);


                                GameFieldsVerificationMessages.WinMessage(cubePlaySymbol);


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

                           // Debug.Log(" 0 ");
                            _listCheckerForWinner = GameFieldsVerification.FieldsVerification(gameBoardVerification2D, lenghtToCheck);

                            //Debug.Log(" 1 ");
                            _winner = (bool)_listCheckerForWinner[0];


                            if (_winner == true)
                            {
                               // Debug.Log(" 2 ");
                                _winnerCoordinateXYForCubePlay = (int[,])_listCheckerForWinner[1];
                                _winnerKindOfChecker = (string)_listCheckerForWinner[2];

                                PlayGameFrameMove.SetUpNewZForCubePlayFrame(cubePlayFrame);
                                PlayGameChangeCubePlaForWinner.ChangeAllCubePlayAfterWin(gameBoard, cubePlaySymbol, _winnerCoordinateXYForCubePlay, _winnerKindOfChecker, _tagCubePlayGameWin, _tagCubePlayGameOver, prefabCubePlayFrame, cubePlayColourWin);

                                GameFieldsVerificationMessages.WinMessage(cubePlaySymbol);

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


                    




                }
            }

           
        }
        

        



    }


    // TO DO:
    // GameBoardCreateScale - > FindSmallestScaleXYZForPrefabCubePlay
    // to do: add the method checking the screen width and height, than add the method return the max rows and max rows for tablet
}
