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


  


   
    public Touch touch;
    private Camera mainCamera;

    //public TextMeshProUGUI cubePlayChangeText;

    private int playersNumberGivenForConfiguration = 3;

    private int _minNumberOfRows = 3;
    private int _minNumberOfColumns = 3;
    private int _minNumbersCubesForDepthZ = 3;

    private static int numberOfRows = 5;
    private static int  numberOfColumns = 3;

    // default = 1; this is needed for future version 3D WeirdTicTacToeGame
    // it is not possible to change from UI
    private static int numberOfDepths = 1;
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

    bool winner = false;

    GameObject[,,] gameBoard;
    string[,] gameBoardVerification2D;

    GameObject cubePlayFrame;
    int[] moveIndexForFrame;

    void Start()
    {

        _tagCubePlayFree = tagCubePlayDictionary[1];
        _tagCubePlayTaken = tagCubePlayDictionary[2];
        _tagCubePlayFrame = tagCubePlayDictionary[3];

        _tagArrowRight = tagArrowDictionary[1];
        _tagArrowLeft = tagArrowDictionary[3];
        _tagArrowUp = tagArrowDictionary[4];
        _tagArrowDown = tagArrowDictionary[2];
        _tagButtonConfirm = tagArrowDictionary[5];

        _index = 0;

         //Debug.Log("_tagArrowDown = " + _tagArrowDown);

         gameBoardVerification2D = GameConfiguration.CreateEmptyTable2D(numberOfRows, numberOfColumns);

        // does it need it?
        playerNumber = GameConfiguration.CreateTableWithPlayersNumber(playersNumberGivenForConfiguration);

        


        playersSymbols = GameConfiguration.CreatetableWithPlayersSymbols();
        currentPlayer = CommonMethods.CreateTableWithGivenLengthAndGivenValue(1, 0);

        currentCountedTagCubePlayTaken = CommonMethods.CreateTableWithGivenLengthAndGivenValue(1, 1);



        // [gameBoard] - creating the board game with game object "CubePlay"
        gameBoard = CreateGameBoard.CreateBoardGame(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);

        GameObject cubePlayForFrame = gameBoard[0, numberOfRows - 1, 0];
        // scale for cubePlayFrame taken from cubePlay, it is cube so one cooridinate is enought
        _cubePlayForFrameScale = cubePlayForFrame.transform.localScale.x;

        moveIndexForFrame = PlayGameMethods.CreateTableForMoveIndexForFrame(numberOfRows);
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

                    string gameObjectTag = touch.collider.transform.tag;
                    string gameObjectName = touch.collider.transform.name;
                    int currentPlayerNumber = currentPlayer[0];
                    GameObject cubePlay = CommonMethods.GetCubePlay(gameBoard, gameObjectName);

                    
                    /*
                    if (gameObjectTag == _tagArrowRight)
                    {
                        cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);

                        if (moveIndexForFrame[0] < numberOfColumns - 1)
                        {
                            moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, numberOfRows, numberOfColumns);
                            CommonMethods.SetUpNewXForPrefabCubePlay(cubePlayFrame, _cubePlayForFrameScale);

                        }
                    }
                    */

                    // move by arrows 
                    if (gameObjectTag == _tagArrowRight || gameObjectTag == _tagArrowLeft || gameObjectTag == _tagArrowDown || gameObjectTag == _tagArrowUp)
                    {
                        cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);
                        moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, cubePlayFrame, _cubePlayForFrameScale, numberOfRows, numberOfColumns);
                        
                        
                        
                        
                        //if (gameObjectTag == _tagArrowRight)
                        // {
                        // cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);

                        // if (moveIndexForFrame[0] < numberOfColumns - 1)
                        //{
                       // moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, cubePlayFrame, _cubePlayForFrameScale, numberOfRows, numberOfColumns);
                                //moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexByAddition(moveIndexForFrame, 0, moveIndexForFrame[0]);
                                //CommonMethods.SetUpNewXForGameObject(cubePlayFrame, _cubePlayForFrameScale);

                          //  }
                       // }

                       // if (gameObjectTag == _tagArrowLeft)
                       // {
                           // cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);

                           // if (moveIndexForFrame[0] > 0)
                           // {
                              //  moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, cubePlayFrame, _cubePlayForFrameScale, numberOfRows);
                                //float newCoordinateX = _cubePlayForFrameScale * (-1);
                               // CommonMethods.SetUpNewXForGameObject(cubePlayFrame, newCoordinateX);

                           // }
                        //}

                       // if (gameObjectTag == _tagArrowDown)
                       // {
                           // cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);

                          //  if (moveIndexForFrame[1] > 0)
                           // {
                               // moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, cubePlayFrame, _cubePlayForFrameScale, numberOfRows);
                                //float newCoordinateY = _cubePlayForFrameScale * (-1);
                                //CommonMethods.SetUpNewYForGameObject(cubePlayFrame, newCoordinateY);

                           // }
                      //  }


                        //if (gameObjectTag == _tagArrowUp)
                      //  {
                            //cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);

                          //  if (moveIndexForFrame[1] < numberOfRows - 1)
                           // {
                              //  moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, cubePlayFrame, _cubePlayForFrameScale, numberOfRows);
                                //CommonMethods.SetUpNewYForGameObject(cubePlayFrame, _cubePlayForFrameScale);

                            //}
                       // }

                    }



                    /*
                    if (gameObjectTag == _tagArrowRight)
                    {
                        cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);

                        if (moveIndexForFrame[0] < numberOfColumns - 1)
                        {
                            moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, numberOfRows, numberOfColumns);
                            CommonMethods.SetUpNewXForGameObject(cubePlayFrame, _cubePlayForFrameScale);

                        }
                    }
                    */

                    /*
                    if (gameObjectTag == _tagArrowLeft)
                    {
                        cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);

                        if (moveIndexForFrame[0] > 0)
                        {
                            moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, numberOfRows, numberOfColumns);
                            float newCoordinateX = _cubePlayForFrameScale * (-1);
                            CommonMethods.SetUpNewXForGameObject(cubePlayFrame, newCoordinateX);

                        }
                    }
                    */

                    /*
                    if (gameObjectTag == _tagArrowDown)
                    {
                        cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);

                        if (moveIndexForFrame[1] > 0)
                        {
                            moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, numberOfRows, numberOfColumns);
                            float newCoordinateY = _cubePlayForFrameScale * (-1);
                            CommonMethods.SetUpNewYForGameObject(cubePlayFrame, newCoordinateY);

                        }
                    }
                    */

                    /*
                    if (gameObjectTag == _tagArrowUp)
                    {
                        cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);

                        if (moveIndexForFrame[1] < numberOfRows - 1)
                        {
                            moveIndexForFrame = PlayGameFrameMove.SetUpNewMoveIndexXYForCubePlayFrame(moveIndexForFrame, gameObjectTag, numberOfRows, numberOfColumns);
                            CommonMethods.SetUpNewYForGameObject(cubePlayFrame, _cubePlayForFrameScale);

                        }
                    }
                    */
                    /*
                    if (gameObjectTag == _tagButtonConfirm)
                    {

                       // Debug.Log("gameObjectTag = " + gameObjectTag);
                        int indexX = moveIndexForFrame[0];
                        int indexY = moveIndexForFrame[1];
                        //Debug.Log("moveIndexForFrame[0] = " + moveIndexForFrame[0]);
                       // Debug.Log("moveIndexForFrame[1] " + moveIndexForFrame[1]);

                        GameObject cubePlayMarkByFrame = CommonMethods.GetCubePlay(gameBoard, indexY, indexX);
                        string cubePlayMarkByFrameName = cubePlayMarkByFrame.name;
                        string cubePlayMarkByFrameTag = cubePlayMarkByFrame.tag;
                        //Debug.Log("cubePlay name = " + cubePlay.transform.name);

                        if (cubePlayMarkByFrameTag == _tagCubePlayFree)
                        {
                            var cubePlayDataZYXSymbol = PlayGameChangeText.SetUpPlayerSymbolForCubePlay(gameBoard, cubePlayMarkByFrameName, playersSymbols, currentPlayerNumber);

                            //GameObject cubePlay = CommonMethods.GetCubePlay(gameBoard, gameObjectName);
                            PlayGameMethods.ChangeCoordinateZForCubePlayAfterClickOnTheCubePlay(cubePlayMarkByFrame);

                            int cubePlayIndexY = cubePlayDataZYXSymbol.Item1.Item2;
                            int cubePlayIndexX = cubePlayDataZYXSymbol.Item1.Item3;
                            string cubePlaySymbol = cubePlayDataZYXSymbol.Item2;

                            gameBoardVerification2D[cubePlayIndexY, cubePlayIndexX] = cubePlaySymbol;

                            winner = GameFieldsVerification.FieldsVerification(gameBoardVerification2D);


                            if (winner == true)
                            {

                                GameFieldsVerificationMessages.WinMessage(cubePlaySymbol);
                            }
                            else
                            {

                                currentPlayer = PlayGameChangeText.SetUpCurrentPlayer(currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                                cubePlayMarkByFrame.transform.tag = _tagCubePlayTaken;
                                //Debug.Log("cubePlay new name = " + cubePlayMarkByFrame.transform.name);
                                //Debug.Log("cubePlay new tag = " + cubePlayMarkByFrame.transform.tag);
                                //Debug.Log("currentCountedTagCubePlayTaken[0] = " + currentCountedTagCubePlayTaken[0]);
                                Debug.Log(" ------------------------------------------------------- ");
                                currentCountedTagCubePlayTaken = CommonMethods.SetUpNewCurrentNumberByAddition(currentCountedTagCubePlayTaken, _index);

                                int countedTagCubePlayTaken = currentCountedTagCubePlayTaken[0];

                                if (countedTagCubePlayTaken >= maxCubePlayNumber)
                                {
                                    float newCoordinateZ = 1;
                                    CommonMethods.SetUpNewZForGameObject(cubePlayFrame, newCoordinateZ);
                                    Debug.Log("Game Over :) Would you like to start new game? Yes No");
                                }
                            }

                        }
                        else // (gameObjectTag1 == _tagCubePlayTaken)
                        {
                            Debug.Log("CubePlay has already been taken by another player.");
                        }
                    }
                    */

                    // to fix currentCountedTagCubePlayTaken[0]

                    if (gameObjectTag == _tagCubePlayFree || gameObjectTag == _tagCubePlayTaken)
                    {
                        if (gameObjectTag == _tagCubePlayFree)
                        {
                            //int currentPlayerNumber = currentPlayer[0];
                            Debug.Log("BEFORE currentCountedTagCubePlayTaken[0] = " + currentCountedTagCubePlayTaken[0]);

                            var cubePlayDataZYXSymbol = PlayGameChangeText.SetUpPlayerSymbolForCubePlay(gameBoard, gameObjectName, playersSymbols, currentPlayerNumber);

                            //GameObject cubePlay = CommonMethods.GetCubePlay(gameBoard, gameObjectName);
                            PlayGameMethods.ChangeCoordinateZForCubePlayAfterClickOnTheCubePlay(cubePlay);

                            int cubePlayIndexY = cubePlayDataZYXSymbol.Item1.Item2;
                            int cubePlayIndexX = cubePlayDataZYXSymbol.Item1.Item3;
                            string cubePlaySymbol = cubePlayDataZYXSymbol.Item2;

                            gameBoardVerification2D[cubePlayIndexY, cubePlayIndexX] = cubePlaySymbol;

                            cubePlayFrame = GameObject.FindWithTag(_tagCubePlayFrame);
                            PlayGameFrameMove.SetUpNewXYForCubePlayFrame(cubePlayFrame, cubePlay);
                            moveIndexForFrame[0] = cubePlayIndexX;
                            moveIndexForFrame[1] = cubePlayIndexY;

                            //Debug.Log("moveIndexForFrame[0] = " + cubePlayIndexX);

                            winner = GameFieldsVerification.FieldsVerification(gameBoardVerification2D);


                            if (winner == true)
                            {
                                float newCoordinateZ = 1;
                                CommonMethods.SetUpNewZForGameObject(cubePlayFrame, newCoordinateZ);
                                GameFieldsVerificationMessages.WinMessage(cubePlaySymbol);

                            }

                            else
                            {


                                currentPlayer = PlayGameChangeText.SetUpCurrentPlayer(currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                                touch.collider.transform.tag = _tagCubePlayTaken;
                                currentCountedTagCubePlayTaken = CommonMethods.SetUpNewCurrentNumberByAddition(currentCountedTagCubePlayTaken, _index);

                                //currentCountedTagCubePlayTaken[0] = currentCountedTagCubePlayTaken[0] + 1;


                                int countedTagCubePlayTaken = currentCountedTagCubePlayTaken[0];

                                Debug.Log("AFTER currentCountedTagCubePlayTaken[0] = " + currentCountedTagCubePlayTaken[0]);
                                Debug.Log(" ---------------------------------- ");


                                if (countedTagCubePlayTaken >= maxCubePlayNumber)
                                {
                                    float newCoordinateZ = 1;
                                    CommonMethods.SetUpNewZForGameObject(cubePlayFrame, newCoordinateZ);
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
