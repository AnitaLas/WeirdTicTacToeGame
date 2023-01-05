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

    private int _minNumbersCubesForWidthX = 3;
    private int _minNumbersCubesForHeightY = 3;
    private int _minNumbersCubesForDepthZ = 3;

    void Start()
    {
        int minNumbersCubesForWidthX = 3;
        int minNumbersCubesForHeightY = 3;
        int minNumbersCubesForDepthZ = 3;

        int numbersCubesForWidthX = 10;
        int numbersCubesForHeightY = 7;
        int numbersCubesForDepthZ = 1;


        // [createGameBoard] - creating the board game 
        GameBoardCreate.CreateBoardGame(prefabCubePlay, numbersCubesForWidthX, numbersCubesForHeightY, numbersCubesForDepthZ, cubePlayColour);



        GameBoardCreateMethods.CreateTableWithTextForPrefabCubePlay(numbersCubesForWidthX, numbersCubesForHeightY);
        
        
        //GameBoardCreateMethods.CreateNewTableWithCharactersBasedOntheExistingTableWithCharacters(numbersCubesForWidthX, numbersCubesForHeightY);







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
}
