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

internal class Game : MonoBehaviour
{
    // prefab "CybePlay"
    public GameObject prefabCubePlay;

    // prefab "CubePlay" - colour 
    public Material[] prefabCubePlayDefaultColour;

   // public GameObject cubePlay;

    public Touch touch;
    private Camera mainCamera;

    //public TextMeshProUGUI cubePlayChangeText;

    private int playersNumberGivenForConfiguration = 3;

    private int _minNumberOfRows = 3;
    private int _minNumberOfColumns = 3;
    private int _minNumbersCubesForDepthZ = 3;

    private static int numberOfRows = 7;
    private static int  numberOfColumns = 4;
    // default = 1; this is needed for future version 3D WeirdTicTacToeGame
    // it is not possible to change from UI
    static int numberOfDepths = 1;

    int maxCubePlayNumber = numberOfRows * numberOfColumns * numberOfDepths;



    public string tagCubePlayFree = "CubePlayFree";
    //public string tagCubePlayFree2 = "CubePlayFree";
    public string tagCubePlayTaken = "CubePlayTaken";


    int[] playerNumber;
    string[] playersSymbols;
    int[] currentPlayer;
    int[] currentCountedTagCubePlayTaken;

    bool winner = false;

    GameObject[,,] gameBoard;
    string[,] gameBoardVerification2D;

    void Start()
    {

        gameBoardVerification2D = GameConfiguration.CreateEmptyTable2D(numberOfRows, numberOfColumns);

        // does it need it?
        playerNumber = GameConfiguration.CreateTableWithPlayersNumber(playersNumberGivenForConfiguration);

        


        playersSymbols = GameConfiguration.CreatetableWithPlayersSymbolsV2();
        currentPlayer = GameConfiguration.CreateTableWithLengthOneAndValueZero();

        currentCountedTagCubePlayTaken = GameConfiguration.CreateTableWithLengthOneAndValueZero();



        // [gameBoard] - creating the board game with game object "CubePlay"
        gameBoard = CreateGameBoard.CreateBoardGame(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour);

    }


    // Update is called once per frame
    void Update()
    {
        



        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            RaycastHit cubePlayTouch;

            if (Physics.Raycast(ray, out cubePlayTouch))
            {
                if (cubePlayTouch.collider != null)
                {
                    string cubePlayTag = cubePlayTouch.collider.transform.tag;
                    //Debug.Log("cubePlayTag = " + cubePlayTag);
                   //Debug.Log("tagCubePlayFree = " + tagCubePlayFree);

                    // if (cubePlayTag.Equals(tagCubePlayFree))
                    if (cubePlayTag == tagCubePlayFree)
                    {
                        int currentPlayerNumber = currentPlayer[0];
                        string cubePlayName = cubePlayTouch.collider.transform.name;
                        //Debug.Log("cubePlayName = " + cubePlayName);

                        var cubePlayDataZYXSymbol = PlayGameChangeText.SetUpPlayerSymbolForCubePlay(gameBoard, cubePlayName, playersSymbols, currentPlayerNumber);

                        int cubePlayIndexY = cubePlayDataZYXSymbol.Item1.Item2;
                        int cubePlayIndexX = cubePlayDataZYXSymbol.Item1.Item3;
                        string cubePlaySymbol = cubePlayDataZYXSymbol.Item2;

                        gameBoardVerification2D[cubePlayIndexY, cubePlayIndexX] = cubePlaySymbol;

                        winner = GameFieldsVerification.FieldsVerification(gameBoardVerification2D);
                        Debug.Log("winner = " + winner);

                        if (winner == true)
                        {
                            Debug.Log("IF winner = ");
                            //string test = "payer SYMBOL";
                            GameFieldsVerificationMessages.WinMessage(cubePlaySymbol);
                        }
                        
                        else
                        {
                            Debug.Log("ELSE winner");

                            currentPlayer = PlayGameChangeText.SetUpCurrentPlayer(currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                            cubePlayTouch.collider.transform.tag = tagCubePlayTaken;
                            currentCountedTagCubePlayTaken = CommonMethods.SetUpNewCurrentNumber(currentCountedTagCubePlayTaken);
                            //Debug.Log("currentCountedTagCubePlayTaken = " + currentCountedTagCubePlayTaken[0]);


                            int countedTagCubePlayTaken = currentCountedTagCubePlayTaken[0];

                            if (countedTagCubePlayTaken >= maxCubePlayNumber)
                            {
                                Debug.Log("Game Over :) Would you like to start new game? Yes No");
                            }

                        }
                        

                        /*
                        currentPlayer = PlayGameChangeText.SetUpCurrentPlayer(currentPlayer, currentPlayerNumber, playersNumberGivenForConfiguration);

                        cubePlayTouch.collider.transform.tag = tagCubePlayTaken;
                        currentCountedTagCubePlayTaken = CommonMethods.SetUpNewNumberForCurrentNumber(currentCountedTagCubePlayTaken);
                        //Debug.Log("currentCountedTagCubePlayTaken = " + currentCountedTagCubePlayTaken[0]);


                        int countedTagCubePlayTaken = currentCountedTagCubePlayTaken[0];
                        if (countedTagCubePlayTaken >= maxCubePlayNumber)
                        {
                            Debug.Log("Game Over :) Would you like to start new game? Yes No");
                        }
                        */
                    }
                    else
                    {
                        Debug.Log("CubePlay has already been taken by another player.");
                    }
                    









                    //Debug.Log($"currentPlayer[0] = {currentPlayer[0]}");

                    //cubePlayTouch.collider.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerSympol;
                    
                    //Debug.Log($"CublePlayIndexZ = {cubePlayName}");


                   // int cubePlayNumber = 1;
                    //var CublePlayIndexXYZ = CommonMethods.GetIndexZYXForGameObject(gameBoard, cubePlayName);
                   // int CublePlayIndexZ = CublePlayIndexXYZ.Item1;
                   // int CublePlayIndexY = CublePlayIndexXYZ.Item2;
                   // int CublePlayIndexX = CublePlayIndexXYZ.Item3;
                    //Debug.Log($"CublePlayIndexZ = {CublePlayIndexZ}, CublePlayIndexY = {CublePlayIndexY}, CublePlayIndexX = {CublePlayIndexX}");

                   // GameObject ob = gameBoard[CublePlayIndexZ, CublePlayIndexY, CublePlayIndexX];
                    //string ttt = ob.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                    //Debug.Log($"ttt = " + ttt);

                }
            }

            /*
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    for (int z = 0; z < gameBoard.GetLength(2); z++)
                    {
                        GameObject ob = gameBoard[0, 0, 0];
                        string ttt = ob.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                        Debug.Log($"ttt = " + ttt);


                        //Debug.Log($"gameBoard[{i}, {j}, {z}] = " + gameBoard[i, j, z]);

                        //GameObject A1 = gameBoard[i, j, z];

                        //string teœcik = A1.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                        //Debug.Log("teœcik = " + teœcik);
                    }
                }
            }
            */
            /*
            GameObject A5 = gameBoard[0, 0, 0];
            string name = A5.name;
            Debug.Log("name = " + name);

            cubePlay = GameObject.Find(name);


            string text = "X";
            cubePlay.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
            */
            //  Touch touch = Input.GetTouch(0);

            // Debug.Log(" touch ");

            //Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            // Debug.Log(" touchPosition " + touchPosition);

            //Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            // Debug.Log(" worldPosition " + worldPosition);




            /*
            Vector3 objPos = Camera.main.ScreenToWorldPoint(touch.position);

            Debug.Log(" objPos " + objPos);

            //Vector3 worldPosition = mainCamera.ScreenToWorldPoint(objPos);
            //Debug.Log(" worldPosition " + worldPosition);

            GameObject A5 = gameBoard[0, 0, 0];
            string name = A5.name;
            Debug.Log("name = " + name);

            cubePlay = GameObject.Find(name);


            string text = "X";
            cubePlay.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
            */





            /*
            float x = worldPosition.x;
            float y = worldPosition.y;
            float z = worldPosition.z;
            Debug.Log($"z = {z}, x = {x}, y = {y}");
            */
        }
        

        /*
        if (Input.touchCount > 0)
        {
            Debug.Log("Yess");

            // Update the Text on the screen depending on current position of the touch each frame
            //m_Text.text = "Touch Position : " + touch.position;
        }
        else
        {
           // Debug.Log("Nooo");
        }
        */


/*

            if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject A5 = gameBoard[0 , 6, 3];
            string name = A5.name;
            Debug.Log("name = " + name);

             cubePlay = GameObject.Find(name);


            string text = "X";
            cubePlay.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        }
*/


        //GameObject A7 = gameBoardOld[0, 0, 0];
        /*
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                for (int z = 0; z < gameBoard.GetLength(2); z++)
                {
                    Debug.Log($"gameBoard[{i}, {j}, {z}] = " + gameBoard[i, j, z]);

                    //GameObject A1 = gameBoard[0, 0, 0];

                    //string teœcik2 = A1.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                    //Debug.Log("teœcik = " + teœcik2);
                }
            }
        }
        */

        // GameObject A2 = gameBoardOld[0, 0, 0];

        //string teœcik2 = A2.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        //Debug.Log("teœcik2 = " + teœcik2);



        //string teœcik = A5.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        //Debug.Log("teœcik: " + teœcik);
        //test

        //Debug.Log("text: " + text);
        //cubePlayChangeText.text = text;

        //var newPrefabCubePlayCanvas = A5.transform.GetChild(0);
        // game object: prefab CubePlay -> CubePlayCanvas -> CubePlayText
        //var newPrefabCubePlayCanvasText = newPrefabCubePlayCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //newPrefabCubePlayCanvasText.text = text;
        //cubePlayChangeText.text= text;
        //A5.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;



        //GameObject A3 = gameBoard[0, 0, 0];

        //string teœcik3 = A3.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        //Debug.Log("teœcik3 = " + teœcik3);

    }


    // TO DO:
    // GameBoardCreateScale - > FindSmallestScaleXYZForPrefabCubePlay
    // to do: add the method checking the screen width and height, than add the method return the max rows and max rows for tablet
}
