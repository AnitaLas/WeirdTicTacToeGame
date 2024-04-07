using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamNumbersButtonsMethods
    {

        public static void ChangeDataForSingleGameConfigurationTeamNumbersButtons(GameObject[,,] button, float newCoordinateY, float newCoordinateX)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            float newCoordinateZ = 0.175f;
            float fontSize = 0.7f;
            float newScale = 0.3f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        //GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagToSetUp);
                    }
                }
            }
        }

        public static void ChangeDataForSingleGameConfigurationTeamNumbersButtonNumber(GameObject[,,] button, float newCoordinateY, float newCoordinateX)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            float newCoordinateZ = 0.35f;
            float fontSize = 0.7f;
            float newScale = 1f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        //GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagToSetUp);
                    }
                }
            }
        }



    }
}
