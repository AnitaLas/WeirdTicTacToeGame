using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameMenuButtonsActions : MonoBehaviour
    {
        public static void ChangeCoordinateYForTable(GameObject[,,] tableWtithNumber, float newCoordinateZ)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn = tableWtithNumber.GetLength(2);
            int maxIndexRow = tableWtithNumber.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = tableWtithNumber[indexDepth, indexRow, indexColumn];
                        CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateZ);
                    }

                }
            }
        }

        // ---

        public static void HideBoardGame(GameObject[,,] gameBoard)
        {
            float newCoordinateY = -100f;
            ChangeCoordinateYForTable(gameBoard, newCoordinateY);

        }

        public static void UnhideBoardGame(GameObject[,,] gameBoard)
        {
            float newCoordinateY = 100f;
            ChangeCoordinateYForTable(gameBoard, newCoordinateY);

        }

        // ---

        public static void HideGameObjectWithTag(string tagCubePlayFrame)
        {
            float newCoordinateY = -100f;
            GameObject cubePlayFrame = CommonMethods.GetObjectByTagName(tagCubePlayFrame);
            CommonMethods.SetUpNewYForGameObject(cubePlayFrame, newCoordinateY);

        }

        public static void UnhideGameObjectWithTag(string tagCubePlayFrame)
        {
            float newCoordinateY = 100f;
            GameObject cubePlayFrame = CommonMethods.GetObjectByTagName(tagCubePlayFrame);
            CommonMethods.SetUpNewYForGameObject(cubePlayFrame, newCoordinateY);

        }

        // ---

        public static void ChengeCoordinateYForGameObject(string[] helpButtons, float newCoordinateY)
        {
            string tagName;
            int helpButtonsLength = helpButtons.Length;
            GameObject topObject;

            for (int i = 0; i < helpButtonsLength; i++)
            {
                tagName = helpButtons[i];
                topObject = CommonMethods.GetObjectByTagName(tagName);

                CommonMethods.SetUpNewYForGameObject(topObject, newCoordinateY);
            }
        }

        public static void HideTopObject(string[] helpButtons)
        {
            float newCoordinateY = -100f;
            ChengeCoordinateYForGameObject(helpButtons, newCoordinateY);
        }

        public static void UnhideTopObject(string[] helpButtons)
        {
            float newCoordinateY = 100f;
            ChengeCoordinateYForGameObject(helpButtons, newCoordinateY);
        }

        // ---

        public static void DisactivateConfigurationMenu(string[] tagConfigurationMenu)
        {
            Debug.Log(" 1 ");
            string tagNameOld;
            string tagNameNew = tagConfigurationMenu[0];
            //Debug.Log("tagNameNew = " + tagNameNew);

            int tagConfigurationMenuLength = tagConfigurationMenu.Length;

            //Debug.Log("tagConfigurationMenuLength = " + tagConfigurationMenuLength);

            for (int i = 1; i < tagConfigurationMenuLength; i++)
            {
                tagNameOld = tagConfigurationMenu[i];
                //Debug.Log("tagNameOld = " + tagNameOld);

                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tagNameOld);
                //GameObject gameObject;
                //GameObject gameObjectByName;

                //int gameObjectsNumber = gameObjects.Length;

                //Debug.Log("gameObjectsNumber = " + gameObjectsNumber);

                //for (int j = 0; j < gameObjectsNumber; j++)
                //{
                //    GameObject gameObject = gameObjects[i];
                //    string gameObjectName = CommonMethods.GetObjectName(gameObject);
                //    Debug.Log("gameObjectName = " + gameObjectName);

                //    gameObjectByName = CommonMethods.GetObjectByName(gameObjectName);

                //   CommonMethods.ChangeTagForGameObject(gameObject, tagNameNew);
                //}

                foreach (var gameObject in gameObjects)
                {
                    CommonMethods.ChangeTagForGameObject(gameObject, tagNameNew);
                }

            }



        }


        // ---

        public static void HideHelpButtons(string[] helpButtons)
        {
            float newCoordinateY = 100f;
            ChengeCoordinateYForGameObject(helpButtons, newCoordinateY);
        }

        public static void DestroyGameConfigurationMenuButtons(List<GameObject[,,]> helpButtons, string[] buttonsMenuConfiguration)
        {
            int helpButtonsNumber = helpButtons.Count;
            GameObject helpButton;

            int maxIndexDepth;
            int maxIndexColumn;
            int maxIndexRow;

            for (int i = 0; i < helpButtonsNumber; i++)
            {
                GameObject[,,] buttonToRemove = helpButtons[i];

                maxIndexDepth = buttonToRemove.GetLength(0); ;
                maxIndexColumn = buttonToRemove.GetLength(2);
                maxIndexRow = buttonToRemove.GetLength(1);

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            helpButton = buttonToRemove[indexDepth, indexRow, indexColumn];
                            Destroy(helpButton);
                        }

                    }
                }
            }
        }


        // it does not work for case -> sceneGame, do not clik on the bord game, click the menu configuration, cubePlayFrame does not move, if clik on field A1 then configuration it works
        //public static void HideCubePlayFrame2(GameObject cubePlayFrame)
        //{
        //    Debug.Log(" cubePlayFrame.name =  " + cubePlayFrame.name);
        //    float newCoordinateY = -100f;

        //    CommonMethods.SetUpNewYForGameObject(cubePlayFrame, newCoordinateY);

        //    float x = cubePlayFrame.transform.position.x;
        //    float y = cubePlayFrame.transform.position.y;
        //    float z = cubePlayFrame.transform.position.z;

        //    Debug.Log(" y =  " + y);
        //    Debug.Log(" y + newCoordinateY =  " + (y + newCoordinateY));
        //    float newY = y + newCoordinateY;

        //    cubePlayFrame.transform.position = new Vector3(x, newY, z);

        //}

    }
}
