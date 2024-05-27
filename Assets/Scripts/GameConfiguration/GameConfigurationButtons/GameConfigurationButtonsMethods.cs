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


        public static void ChangeDataForGameConfigurationButtonsOldGame(List<GameObject[,,]> buttonsText, List<GameObject[,,]> buttonsNumber)
        {
            float newCoordinateYForText = -1.25f;
            float newCoordinateYForNumber = -1.1f;

            ChangeCoordinateYForTeamGameButtons(buttonsText, newCoordinateYForText);
            ChangeCoordinateYForTeamGameButtons(buttonsNumber, newCoordinateYForNumber);
        }

        public static void ChangeDataForGameConfigurationButtonsTeamGame(List<GameObject[,,]> buttons, List<GameObject[,,]> buttonsNumber)
        {
            float newCoordinateY = -0.6f;

            ChangeCoordinateYForTeamGameButtons(buttons, newCoordinateY);
            ChangeCoordinateYForTeamGameButtons(buttonsNumber, newCoordinateY);
        }

        public static void ChangeDataForGameConfigurationChangePlayersSymbolsButtonsTeamGame(List<GameObject[,,]> buttons, List<GameObject[,,]> buttonsNumber)
        {
            float newCoordinateY = -0.6f;

            ChangeCoordinateYForTeamGameButtons(buttons, newCoordinateY);
            ChangeCoordinateYForTeamGameButtons(buttonsNumber, newCoordinateY);
        }

        public static void ChangeDataForGameConfigurationChangePlayersSymbolsButtonsOldGame(List<GameObject[,,]> buttons, List<GameObject[,,]> buttonsNumber)
        {
            float newCoordinateY = 0.1f;

            ChangeCoordinateYForTeamGameButtons(buttons, newCoordinateY);
            ChangeCoordinateYForTeamGameButtons(buttonsNumber, newCoordinateY);
        }

        public static void ChangeDataForGameMenuButtons(List<GameObject[,,]> buttons, float[] newYForButtons)
        {
            float newCoordinateX=  -0.65f;
            float newCoordinateZ = 0.175f;
            float newCoordinateY = -2.05f;

            ChangeCoordinatesXYZForGameConfigurationButtons(buttons, newYForButtons, newCoordinateX, newCoordinateZ);
            ChangeCoordinateYForTeamGameButtons(buttons, newCoordinateY);

        }

        public static void ChangeDataForGameMenuMoreSpecificText(List<GameObject[,,]> buttons, float[] newYForButtons)
        {
            float newCoordinateX = 0f;
            float newCoordinateZ = 0.175f;
            float newCoordinateY = 3.35f;

            ChangeCoordinatesXYZForGameConfigurationButtons(buttons, newYForButtons, newCoordinateX, newCoordinateZ);
            ChangeCoordinateYForTeamGameButtons(buttons, newCoordinateY);
        }

        public static void ChangeDataForGameInformationButtons(List<GameObject[,,]> buttons, float[] newYForButtons)
        {
            float newCoordinateX = -0.65f; // columns -> 14
            float newCoordinateZ = 0f;
            float newCoordinateY = -1.2f;
            ChangeCoordinatesXYZForGameConfigurationButtons(buttons, newYForButtons, newCoordinateX, newCoordinateZ);
            ChangeCoordinateYForTeamGameButtons(buttons, newCoordinateY);
        }

        public static void ChangeDataForGameMenuButtonToHide(GameObject[,,] buttonToHide)
        {
            string tagName = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagButtonToHide();
            float newCoordinateY = 100f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationButtons(buttonToHide, newCoordinateY, tagName);
        }


        public static void ChangeCoordinateYForTeamGameButtons(List<GameObject[,,]> buttons, float newCoordinateY)
        {
            int maxIndexDepth = 1;
            int maxIndexColumn;
            int maxIndexRow;
            int buttonsNumber = buttons.Count;
            int maxButtonNumber = buttonsNumber - 1;

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
                            GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);

                        }
                    }
                }
            }
        }
        //public static void ChangeDataForGameConfigurationChangePlayerSymbolButtons(List<GameObject[,,]> buttons, List<GameObject[,,]> buttonsNumber, float[] newYForButtons)
        //{
        //    float newCoordinateXForButtonWithText = -0.5f; // columns -> 14
        //    float newCoordinateZForButtonWithText = 0.175f;
        //    float newCoordinateXForButtonWithNumber = 0f; // columns -> 14
        //    float newCoordinateZForButtonWithNumber = 0f;

        //    ChangeCoordinatesXYZForGameConfigurationButtons(buttons, newYForButtons, newCoordinateXForButtonWithText, newCoordinateZForButtonWithText);
        //    ChangeCoordinatesXYZForGameConfigurationButtons(buttonsNumber, newYForButtons, newCoordinateXForButtonWithNumber, newCoordinateZForButtonWithNumber);
        //    ChangeDataForGameConfigurationButtonsWithChosenText(buttonsNumber);
        //}

        //public static void ChangeDataForGameConfigurationButtonsChangePlayersSymbols(List<GameObject[,,]> buttons, List<GameObject[,,]> buttonsNumber, float[] newYForButtons)
        //{
        //    float newCoordinateXForButtonWithText = -0.85f; // columns -> 14
        //    //float newCoordinateXForButtonWithText = -0.0f; // columns -> 14
        //    float newCoordinateZForButtonWithText = 0.175f;
        //    float newCoordinateXForButtonWithNumber = 0.25f; // columns -> 14
        //    float newCoordinateZForButtonWithNumber = 0f;

        //    ChangeCoordinatesXYZForGameConfigurationButtons(buttons, newYForButtons, newCoordinateXForButtonWithText, newCoordinateZForButtonWithText);
        //    ChangeCoordinatesXYZForGameConfigurationButtons(buttonsNumber, newYForButtons, newCoordinateXForButtonWithNumber, newCoordinateZForButtonWithNumber);
        //    ChangeDataForGameConfigurationButtonsWithChosenText(buttonsNumber);
        //    ChangeCoordinatesYForGameConfigurationButtons(buttonsNumber);
        //}

        //public static void ChangeCoordinatesYForGameConfigurationButtons(List<GameObject[,,]> buttons)
        //{
        //    int maxIndexDepth = 1;
        //    int maxIndexColumn;
        //    int maxIndexRow;
        //    int buttonsNumber = buttons.Count;
        //    int maxButtonNumber = buttonsNumber - 1;

        //    float newCoordinateY = -0.2f;

        //    for (int i = 0; i < buttonsNumber; i++)
        //    {
        //        GameObject[,,] oneButton = buttons[i];

        //        maxIndexColumn = oneButton.GetLength(2);
        //        maxIndexRow = oneButton.GetLength(1);

        //        for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
        //        {
        //            for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
        //            {
        //                for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
        //                {
        //                    GameObject cubePlay = oneButton[indexDepth, indexRow, indexColumn];
        //                    GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
        //                }
        //            }
        //        }
        //    }
        //}

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
                            GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                            GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        }
                    }
                }
            }
        }

        // for:
        // team game - base setups
        // players symbols change

        public static float[] GetTableWithNewYForGameConfigurationButtons(GameObject prefabPlayerSymbol, int playersNumber)
        {
            float result;
            float previousResult;
            float[] table = new float[playersNumber];
            float scale = GameCommonMethodsMain.GetObjectScaleX(prefabPlayerSymbol);

            //float halfScale = scale * 4.45f; // 6 for boardGameConfiguration without button gaps
            float halfScale = scale * 3.851f; // 6 for boardGameConfiguration without button gaps
            float firstY = GetFirstPositionForPrefabCubePlay(scale, playersNumber);// - 0.5f;
            //float firstY = GetFirstPositionForPrefabCubePlay(scale, playersNumber) - 1.3f; // one digit after coma, two makes some gaps between prefab CubePlay
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

        public static float[] GetTableWithNewYForTeamGameConfigurationButtons(GameObject prefabPlayerSymbol, int playersNumber)
        {
            float result;
            float previousResult;
            float[] table = new float[playersNumber];
            float scale = GameCommonMethodsMain.GetObjectScaleX(prefabPlayerSymbol);

            float halfScale = scale * 4.451f; // 6 for boardGameConfiguration without button gaps
            float firstY = GetFirstPositionForPrefabCubePlay(scale, playersNumber);// - 1.251f; 
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

        public static float[] GetTableWithNewYForGameMenuButtons(GameObject prefabPlayerSymbol, int playersNumber)
        {
            float result;
            float previousResult;
            float[] table = new float[playersNumber];
            float scale = GameCommonMethodsMain.GetObjectScaleX(prefabPlayerSymbol);

            float halfScale = scale * 5.451f; 
            float firstY = GetFirstPositionForPrefabCubePlay(scale, playersNumber);
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
                            GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                            GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                            GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                            GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        }
                    }
                }
            }
        }     
    }
}
