using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.UI;
using TMPro;

internal class Game : MonoBehaviour
{
    public GameObject prefabCubePlay;

    // prefab "CubePlay" - colour 
    public Material[] cubePlayColour;

    private int _minNumberOfRows = 3;
    private int _minNumberOfColumns = 3;
    private int _minNumbersCubesForDepthZ = 3;

    private static int numberOfRows = 5;
    private static int  numberOfColumns = 5;
    // default = 1; this is needed for future version 3D WeirdTicTacToeGame
    // it is not possible to change from UI
    static int numberOfDepths = 1;

    // [prefabCubePlay] table wiht number for prefab "CubePlay", number added to prefab as are created in UI (in the same direction),
    int[,] prefabCubePlayNumbers = CreateGameBoardMethods.CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI(numberOfRows, numberOfColumns);


    void Start()
    {
        //int minNumbersCubesForWidthX = 3;
        //int minNumbersCubesForHeightY = 3;
        //int minNumbersCubesForDepthZ = 3;

        //int numberOfRows = 5;
        //int numberOfColumns = 5;
        //// default = 1; this is needed for future version 3D WeirdTicTacToeGame
        //// it is not possible to change from UI
        //int numberOfDepths = 1;


        // [createGameBoard] - creating the board game 
        CreateGameBoard.CreateBoardGame(prefabCubePlay, numberOfRows, numberOfColumns, numberOfDepths, cubePlayColour);



        
        
       







        //--------------------------------------------------------------------

        /*
        int cubePlaySize = 100;

        // float screenHeight = Screen.width;
        //Debug.Log("screenWidth: " + Screen.width);
        //int screenHeight1 = 1;

        //int screenWidth = Screen.height;


        // iPhone XR
        double screenWidth = 828;
        double screenHeight = 1792;

        // to chceck on device i it work
        double cubePlayMaxNumbersForscreenWidth = screenWidth / cubePlaySize;
        Debug.Log("cubePlayMaxNumbersForscreenWidth: " + cubePlayMaxNumbersForscreenWidth);

        Tuple<double, double> MaxNumberOfFields = GameBoardCalculateMaxNumberOfFields.MaxNumberOfFields(screenWidth, screenHeight);
        double MaxNumberOfFieldsWidth = MaxNumberOfFields.Item1;
        double MaxNumberOfFieldsHeight = MaxNumberOfFields.Item2;


        */
        //---------------------------------------------------
        // it is not needed, but keep it for futre


        //RectTransform rectTransform = myPrefab.GetComponent<RectTransform>();

        //float heightCube = rectTransform.rect.height;
        //Debug.Log("heightCube: " + heightCube);

        /*
        
        GameObject mynewball = (GameObject)Instantiate(myPrefab);
        RectTransform rt = (RectTransform)mynewball.transform;

        float widthCube = rt.rect.width;
        Debug.Log("widthCube: " + widthCube);
        float heightCube = rt.rect.height;
        Debug.Log("heightCube: " + heightCube);
        */
        //---------------------------------------------------




    }





    // Update is called once per frame
    void Update()
    {
        



    }


    // TO DO:
    // GameBoardCreateScale - > FindSmallestScaleXYZForPrefabCubePlay
    // to do: add the method checking the screen width and height, than add the method return the max rows and max rows for tablet
}
