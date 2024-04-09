using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsMethods
    {
        public static Tuple<int, int> GetSizeForTableWithDefaulSymbols(bool isCellphoneMode)
        {
            Tuple<int, int> tableSize;

            //bool isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();

            //Debug.Log("TUPLE isCellphoneMode: " + isCellphoneMode);

            if (isCellphoneMode == true)
            {
                tableSize = Tuple.Create(1, 3); // rows, columns
            } 
            else
            {
                tableSize = Tuple.Create(4, 3);
            }

            return tableSize;
        }

        public static int GetDefaultTeamGameNumber()
        {
            int number = 2;
            return number;
        }

        public static float GetCoordinateYForTableWithSymbols(int teamNumebr)
        {
            float teamOneY = 1f;
            float teamTwoY = -2f;
            float moreThanTwoTeams = 2f;

            float[] coordinateYData = new float[3];
            coordinateYData[0] = teamOneY;
            coordinateYData[1] = teamTwoY;
            coordinateYData[2] = moreThanTwoTeams;

            float coordinateY = coordinateYData[teamNumebr];
            return coordinateY;
        }

        public static float GetCoordinateYForButtonsTextWithTeamNumbers(int teamNumebr)
        {
            float teamOneY = 1.5f;
            float teamTwoY = -1.5f;
            float moreThanTwoTeams = 2f;

            float[] coordinateYData = new float[3];
            coordinateYData[0] = teamOneY;
            coordinateYData[1] = teamTwoY;
            coordinateYData[2] = moreThanTwoTeams;

            float coordinateY = coordinateYData[teamNumebr];
            return coordinateY;
        }

        public static float GetCoordinateYForButtonsWithTeamNumbers(int teamNumebr)
        {
            float teamOneY = 1.5f;
            float teamTwoY = -1.5f;
            float moreThanTwoTeams = 2f;

            float[] coordinateYData = new float[3];
            coordinateYData[0] = teamOneY;
            coordinateYData[1] = teamTwoY;
            coordinateYData[2] = moreThanTwoTeams;

            float coordinateY = coordinateYData[teamNumebr];
            return coordinateY;
        }


        public static void ChangeDataForSingleGameConfigurationTeamMembersButtons(GameObject[,,] button, float newCoordinateY, float newCoordinateX)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            //float newCoordinateZ = 0.175f;
            float newCoordinateZ = 0.195f;
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


        public static void ChangeDataForSingleGameConfigurationTeamMembersButtonNumber(GameObject[,,] button, float newCoordinateY, float newCoordinateX)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            float newCoordinateZ = 0.35f;
            float fontSize = 0.7f;
            float newScale = 0.95f;

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


        public static void ChangeDataForSingleGameConfigurationTeamMembersPlayersSymbols(GameObject[,,] button, float newCoordinateY, string tagName)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            float newCoordinateZ = 0.35f;
            float fontSize = 0.7f;
            float newScale = 0.95f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                       // GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        CommonMethods.ChangeTagForGameObject(cubePlay, tagName);
                        //GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        //GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        //GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagToSetUp);
                    }
                }
            }
        }

        public static void ChangeDataForSingleGameConfigurationTeamMembersPlayersSymbols(GameObject[,,] button, float newCoordinateY)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            float newCoordinateZ = 0.35f;
            float fontSize = 0.7f;
            float newScale = 0.95f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        // GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);

                        //GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        //GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        //GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagToSetUp);
                    }
                }
            }
        }

    }
}
