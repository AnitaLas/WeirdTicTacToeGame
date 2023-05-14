using Assets.Scripts.GameConfigurationPlayerSymbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Buttons
{
    internal class ButtonsGameConfigurationMethods
    {


        public static void ChangeDataForGameConfigurationButtons(List<GameObject[,,]> buttons, List<GameObject[,,]> buttonsNumber, float[] newYForButtons)
        {
            float newCoordinateXForButtonWithText = -0.95f;
            float newCoordinateZForButtonWithText = 0.175f;
            float newCoordinateXForButtonWithNumber = 0f;
            float newCoordinateZForButtonWithNumber = 0f;

            ChangeCoordinatesXYZForGameConfigurationButtons(buttons, newYForButtons, newCoordinateXForButtonWithText, newCoordinateZForButtonWithText);
            ChangeCoordinatesXYZForGameConfigurationButtons(buttonsNumber, newYForButtons, newCoordinateXForButtonWithNumber, newCoordinateZForButtonWithNumber);
            ChangeDataForGameConfigurationButtonsWithChosenText(buttonsNumber);


        }

        public static void ChangeCoordinatesXYZForGameConfigurationButtons(List<GameObject[,,]> buttons, float[] newYForButtons, float newCoordinateX, float newCoordinateZ)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumber = buttons.Count;
            int maxButtonNumber = buttonsNumber - 1;
            float newCoordinateY; 

            for (int i = 0; i < buttonsNumber; i++)
            {
                GameObject[,,] oneButton = buttons[i];

                maxIndexColumn = oneButton.GetLength(2);
                maxIndexRow = oneButton.GetLength(1);

                newCoordinateY = newYForButtons[maxButtonNumber - i];

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = oneButton[indexDepth, indexRow, indexColumn];

                            CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                            CommonMethods.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            CommonMethods.ChangeZForGameObject(cubePlay, newCoordinateZ);


                        }
                    }
                }
            }
        }

        public static float[] GetTableWithNewYForGameConfigurationButtons(GameObject prefabPlayerSymbol, int playersNumber)
        {
            float[] table = new float[playersNumber];
            float scale = CommonMethods.GetObjectScaleX(prefabPlayerSymbol);
            //float scale = 1;
            float halfScale = scale * 6; // 6 for boardGameConfiguration
            float firstY = GetFirstPositionForPrefabCubePlay(scale, playersNumber) - 0.5f;
            table[0] = firstY;
            float result;
            float previousResult;
            int previousResultIndex; // = 0;

            for (int newY = 1; newY < playersNumber; newY++)
            {
                previousResultIndex = newY - 1;
                previousResult = table[previousResultIndex];
                result = previousResult + scale + halfScale;
                table[newY] = result;
            }



            return table;
        }

        public static float GetFirstPositionForPrefabCubePlay(float scale, int playersNumber)
        {

            float scaleDevidedByTwo = scale / 2;
            float scaleDevidedByFour = scale / 4;
            float yForFirstPrefabPlayerSymbol;
            int playersNumberDevidedByTwo = playersNumber / 2;

            bool isPlayersNumberEven = CommonMethods.IsNumberEven(playersNumber);

            if (isPlayersNumberEven == false)
            {
                decimal playersNumberDecimal = CommonMethods.ConvertDecimalToInt(playersNumberDevidedByTwo);
                decimal playersNumberRoundUp = CommonMethods.RoundUp(playersNumberDecimal);
                float playersNumberFloat = CommonMethods.ConvertDecimalToFloat(playersNumberRoundUp);

                yForFirstPrefabPlayerSymbol = -playersNumberFloat;
                return yForFirstPrefabPlayerSymbol;

            }
            else
            {
                //2468
                decimal playersNumberDecimal = CommonMethods.ConvertDecimalToInt(playersNumberDevidedByTwo);
                decimal playersNumberRoundUp = CommonMethods.RoundUp(playersNumberDecimal);
                float playersNumberFloat = CommonMethods.ConvertDecimalToFloat(playersNumberRoundUp);

                yForFirstPrefabPlayerSymbol = -playersNumberFloat;
                return yForFirstPrefabPlayerSymbol;

            }
        }

        public static void ChangeDataForGameConfigurationButtonsWithChosenText(List<GameObject[,,]> buttons)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumber = buttons.Count;
            //int maxButtonNumber = buttonsNumber - 1;
            float newCoordinateY = -0.6f;
            float newCoordinateX = 1.6f;
            float newCoordinateZ = 0.45f;
            float fontSize = 0.5f;
            float newScale = 1f;

            for (int i = 0; i < buttonsNumber; i++)
            {
                GameObject[,,] oneButton = buttons[i];

                maxIndexColumn = oneButton.GetLength(2);
                maxIndexRow = oneButton.GetLength(1);

                //newCoordinateY = newYForButtons[maxButtonNumber - i];

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {

                            GameObject cubePlay = oneButton[indexDepth, indexRow, indexColumn];

                            CommonMethods.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);

                            CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                            CommonMethods.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            CommonMethods.ChangeZForGameObject(cubePlay, newCoordinateZ);

                            CommonMethods.ChangeTextFontSize(cubePlay, fontSize);

                        }
                    }
                }
            }
        }

        // --- information buttons

        public static void ChangeDataForGameConfigurationButtonsInformation(GameObject[,,] button)
        {
            int maxIndexDepth = button.GetLength(0); 
            int maxIndexColumn  = button.GetLength(2);
            int maxIndexRow = button.GetLength(1); 

            //float newCoordinateY = 3.75f;
            //float newCoordinateY = 4.25f;
            float newCoordinateY = 4.5f;
            float newCoordinateX = -0.65f;

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = button[indexDepth, indexRow, indexColumn];

                            CommonMethods.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                            CommonMethods.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                           

                        }
                    }
                }           
        }

    }
}
