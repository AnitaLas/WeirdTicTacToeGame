using Assets.Scripts;
using Assets.Scripts.CreateTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

namespace Assets.Scripts
{
    internal class CreateGameBoard : MonoBehaviour
    {
        public static GameObject[,,] CreateBoardGame(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] tableWithNumber;
            string[,,] defaultTextForPrefabCubePlay = CreateGameBoardMethods.CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);     
            tableWithNumber = CreateTableMainMethodsForGame.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode, defaultTextForPrefabCubePlay);

            CreateGameBoardMethods.ChangeDataForBoardGameAtStart(tableWithNumber);

            return tableWithNumber;
        }

        //public static GameObject[,,] CreateBoardGame(GameObject prefabCubePlay, int numberOfDepths, int numberOfRows, int numberOfColumns, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        //{
        //    GameObject[,,] tableWithNumber;
        //    string[,,] defaultTextForPrefabCubePlay = CreateGameBoardMethods.CreateTableWithTextForPrefabCubePlay(numberOfDepths, numberOfRows, numberOfColumns);
        //    tableWithNumber = CreateTableMainMethodsForButtons.CreateTableWithNumbers(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D, defaultTextForPrefabCubePlay);

        //    CreateGameBoardMethods.ChangeDataForBoardGameAtStart(tableWithNumber);

        //    return tableWithNumber;
        //}

    }

}
