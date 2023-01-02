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

public class Game : MonoBehaviour
{
    public GameObject prefabCubePlay;

    //public int width = 3;
    // public int height = 2;
    // Start is called before the first frame update


    void Start()
    {
        int minNumbersCubesForWidthX = 3;
        int minNumbersCubesForHeightY = 3;
        int minNumbersCubesForDepthZ = 3;

        int numbersCubesForWidthX = 10; // 1                            //2
        int numbersCubesForHeightY = 3;  // 1                          // 1
        int numbersCubesForDepthZ = 1; // 1 - generuje 3 na na 3       // 1 -> generuje 3h na 4w

        //transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);


        //ransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //Vector3 objectScale = transform.localScale;
        // transform.localScale = new Vector3(objectScale.x * 0.5f, objectScale.y * 0.5f, objectScale.z * 0.5f);
        //GameBoardCreateScale.ScaleForCubePlay();




        GameBoardCreate.CreateBoardGame(prefabCubePlay, numbersCubesForWidthX, numbersCubesForHeightY, numbersCubesForDepthZ);

       








        //--------------------------------------------------------------------

        /*
         // version 1
        for (float y = 0.5f; y < height; ++y)
        {
            for (float x = 0.5f; x < width; ++x)
            {
                for (float z = 0.5f; z < depth; ++z)
                {
                    Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
        */
        //------------------------------------------------------------
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
