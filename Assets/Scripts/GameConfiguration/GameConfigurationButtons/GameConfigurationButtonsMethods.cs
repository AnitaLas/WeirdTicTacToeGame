using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


    namespace Assets.Scripts
    {
    internal class GameConfigurationButtonsMethods
    {

        public static void ChangeDataForGameConfigurationButtons(List<GameObject[,,]> buttons, List<GameObject[,,]> buttonsNumber, float[] newYForButtons)
        {
            float newCoordinateXForButtonWithText = -0.85f; // columns -> 14
            float newCoordinateZForButtonWithText = 0.175f;
            float newCoordinateXForButtonWithNumber = 0f; // columns -> 14
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
                            CommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                            CommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            CommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        }
                    }
                }
            }
        }

        public static float[] GetTableWithNewYForGameConfigurationButtons(GameObject prefabPlayerSymbol, int playersNumber)
        {
            float result;
            float previousResult;
            float[] table = new float[playersNumber];
            float scale = GameCommonMethodsMain.GetObjectScaleX(prefabPlayerSymbol);

            float halfScale = scale * 4.45f; // 6 for boardGameConfiguration without button gaps
            float firstY = GetFirstPositionForPrefabCubePlay(scale, playersNumber) - 0.5f;
            table[0] = firstY;
           
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
            bool isPlayersNumberEven = GameCommonMethodsMain.IsNumberEven(playersNumber);

            if (isPlayersNumberEven == false)
            {
                decimal playersNumberDecimal = GameCommonMethodsMain.ConvertDecimalToInt(playersNumberDevidedByTwo);
                decimal playersNumberRoundUp = GameCommonMethodsMain.RoundUp(playersNumberDecimal);
                float playersNumberFloat = GameCommonMethodsMain.ConvertDecimalToFloat(playersNumberRoundUp);

                yForFirstPrefabPlayerSymbol = -playersNumberFloat;
                return yForFirstPrefabPlayerSymbol;

            }
            else
            {
                decimal playersNumberDecimal = GameCommonMethodsMain.ConvertDecimalToInt(playersNumberDevidedByTwo);
                decimal playersNumberRoundUp = GameCommonMethodsMain.RoundUp(playersNumberDecimal);
                float playersNumberFloat = GameCommonMethodsMain.ConvertDecimalToFloat(playersNumberRoundUp);

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

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = oneButton[indexDepth, indexRow, indexColumn];
                            GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                            CommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                            CommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            CommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                            GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        }
                    }
                }
            }
        }     
    }
}
