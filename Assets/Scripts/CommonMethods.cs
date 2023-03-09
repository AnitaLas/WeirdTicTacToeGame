using Assets.Scripts.GameDictionaries;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;
using Random = System.Random;

namespace Assets.Scripts
{
    internal class CommonMethods : MonoBehaviour
    {

        // double 14/15 digits after coma
        // float 6/7 digits after coma

        public static float ConvertDoubleToFloat(double number)
        {
            string doubleToString = number.ToString();
            float doubleToFloat = float.Parse(doubleToString);
            return doubleToFloat;
        }

        public static float ConvertIntToFloat(float number)
        {
            string intToString = number.ToString();
            float intToFloat = int.Parse(intToString);
            return intToFloat;
        }

        public static string ConverIntToString(int number)
        {
            string intToString = number.ToString();
            return intToString;
        }

        public static int ConvertStringToInt(string number)
        {
            int numberInt = Int32.Parse(number);
            return numberInt;
        }

        public static float RoundAndConvertDoubleToFloat(double number, int round)
        {
            double roundedNumber = Math.Round(number, round);
            float doubleToFloat = ConvertDoubleToFloat(roundedNumber);
            return doubleToFloat;
        }

        public static double RoundDownWithDecimal(double number, int numberAfterDecimal)
        {
            double newNumber = number * 10;
            double newNumberRounded = Math.Floor(newNumber);
            double resul = newNumberRounded / Math.Pow(10, numberAfterDecimal);

            return resul;
        }

        // even number - 2 4 6 
        // odd number - 3 5 7

        public static bool IsNumberEven(int number)
        {
            bool isNumberEven;

            if (number %2 == 0) 
            {
                isNumberEven = true;
                return isNumberEven;
            }
            else
            {
                isNumberEven = false;
                return isNumberEven;
            }
        }

        public static int ChooseRandomNumber(int maxNumber)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, maxNumber);
            return randomNumber;
        }

        public static int ConvertIntToDecimal(decimal number)
        {
            int result = decimal.ToInt32(number);
            return result;
        }

        public static float ConvertDecimalToFloat(decimal number)
        {
            float result = decimal.ToSingle(number);
            return result;
        }

        public static decimal RoundDown(decimal number)
        {
            decimal result = Math.Floor(number);
            return result;
        }

        public static decimal RoundUp(decimal number)
        {
            decimal result = Math.Ceiling(number);
            return result;
        }

        public static float GetObjectScaleX(GameObject gameObject)
        {
            float gameObjectScale = gameObject.transform.localScale.x;
            return gameObjectScale;
        }

        // --------------------------------------------------------------------------------------------------------------------------------------------------------------
        // [CurrentNumber] - start

        /// <summary>
        /// <para> set the new number for current number, it's increase current number by one </para>
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <returns></returns>
        public static int SetUpNewCurrentNumber(int currentNumber)
        {
            int newCurrentNumber = currentNumber + 1;
            return newCurrentNumber;
        }

        /// <summary>
        /// <para> set the new number for current number, it's increase current number by one </para>
        /// </summary>
        /// <param name="currentCountedNumber"></param>
        /// <returns></returns>
        public static int[] SetUpNewCurrentNumberByAddition(int[] currentCountedNumber, int tableIndex)
        {
            currentCountedNumber[tableIndex] = currentCountedNumber[tableIndex] + 1;
            return currentCountedNumber;

        }

        /// <summary>
        /// <para> set the new number for current number, it's decrease current number by one </para>
        /// </summary>
        /// <param name="currentCountedNumber"></param>
        /// <returns></returns>
        public static int[] SetUpNewCurrentNumberBySubtraction(int[] currentCountedNumber, int tableIndex)
        {
            currentCountedNumber[tableIndex] = currentCountedNumber[tableIndex] - 1;
            return currentCountedNumber;

        }

        // [CurrentNumber] - end
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------

        // --------------------------------------------------------------------------------------------------------------------------------------------------------------
        // [TextChange] - start
        public static TextMeshProUGUI GetCubePlayTextMeshProUGUI(GameObject gameObject)
        {
            string gameObjectName = GetObjectName(gameObject);
            // game object: prefab CubePlay -> CubePlayCanvas ->
            var newPrefabCubePlayCanvas = gameObject.transform.GetChild(0);
            // game object: prefab CubePlay -> CubePlayCanvas -> CubePlayText
            var newPrefabCubePlayCanvasText = newPrefabCubePlayCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            return newPrefabCubePlayCanvasText;
        }

        public static TextMeshProUGUI GetTextMeshProUGUIForPlayerSymbolChild(GameObject gameObject, int childNumber)
        {
            string gameObjectName = GetObjectName(gameObject);
            // game object: prefab PlayerSymbol -> PlayerSymbolText -> PlayerSymbolCanvas ->
            var newPrefabCubePlayCanvas = gameObject.transform.GetChild(childNumber).transform.GetChild(0);
            // game object: prefab PlayerSymbol -> PlayerSymbolCanvas -> PlayerSymbolText
            var newPrefabCubePlayCanvasText = newPrefabCubePlayCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            return newPrefabCubePlayCanvasText;
        }
        /*
        public static TextMeshProUGUI GetTextMeshProUGUIForPlayerSymbolSecondChild(GameObject gameObject)
        {
            string gameObjectName = GetObjectName(gameObject);
            // 
            var newPrefabCubePlayCanvas = gameObject.transform.GetChild(1).transform.GetChild(0);
            //
            var newPrefabCubePlayCanvasText = newPrefabCubePlayCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            return newPrefabCubePlayCanvasText;
        }
        */












        public static void ChangeTextForFirstChild(GameObject gameObject, string gameObjectText)
        {
            TextMeshProUGUI newPrefabGameObjectText;
            newPrefabGameObjectText = GetCubePlayTextMeshProUGUI(gameObject);
            newPrefabGameObjectText.text = gameObjectText;
        }

        public static void ChangeTextForSecondChild(GameObject gameObject, string gameObjectText)
        {
            TextMeshProUGUI newPrefabGameObjectText;
            int childNumber = 0;
            newPrefabGameObjectText = GetTextMeshProUGUIForPlayerSymbolChild(gameObject, childNumber);
            newPrefabGameObjectText.text = gameObjectText;
        }
        // TO FIX ?????????????????????????????????????????????????
        public static void ChangeTextForCubePlay(GameObject gameObject, string gameObjectText)
        {
            string gameObjectFullName = GetObjectName(gameObject);
            //Debug.Log("gameObjectName = " + gameObjectName);

            string gameObjectName = gameObjectFullName.Substring(0, 8);

            //TextMeshProUGUI newPrefabGameObjectText;

            if (gameObjectName.Equals("CubePlay"))
            {
                //newPrefabGameObjectText = GetCubePlayTextMeshProUGUI(gameObject);
                //newPrefabGameObjectText.text = gameObjectText;


                ChangeTextForFirstChild(gameObject, gameObjectText);


            }


            if (gameObjectName.Equals("PlayerSymbol"))
            {
                //int childNumber = 0;
                //newPrefabGameObjectText = GetTextMeshProUGUIForPlayerSymbolChild(gameObject, childNumber);
                //newPrefabGameObjectText.text = gameObjectText;

                ChangeTextForSecondChild( gameObject, gameObjectText);
            }

            //var newPrefabCubePlayCanvasText = GetCubePlayTextMeshProUGUI(gameObject);
            //Debug.Log("newPrefabCubePlayCanvasText = " + newPrefabCubePlayCanvasText);
            //newPrefabCubePlayCanvasText.text = gameObjectText;
        }

        public static string GetCubePlayText(GameObject gameObject)
        {
            // game object: prefab CubePlay -> CubePlayCanvas ->
            var newPrefabCubePlayCanvas = gameObject.transform.GetChild(0);
            // game object: prefab CubePlay -> CubePlayCanvas -> CubePlayText
            var newPrefabCubePlayCanvasText = newPrefabCubePlayCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            string text = newPrefabCubePlayCanvasText.text;
            return text;
        }

        public static string GetTextForPlayerSymbolChild(GameObject gameObject, int childNumber)
        {
            //string gameObjectName = GetObjectName(gameObject);
            // game object: prefab PlayerSymbol -> PlayerSymbolText -> PlayerSymbolCanvas ->
            var newPrefabPlayerSymbolCanvas = gameObject.transform.GetChild(childNumber).transform.GetChild(0);
            // game object: prefab PlayerSymbol -> PlayerSymbolCanvas -> PlayerSymbolText
            string newPrefabCubePlayCanvasText = newPrefabPlayerSymbolCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            return newPrefabCubePlayCanvasText;
        }

        public static void ChangeTextColourForCubePlay(GameObject gameObject, Color textColor)
        {
            //// game object: prefab CubePlay -> CubePlayCanvas ->
            //var newPrefabCubePlayCanvas = gameObject.transform.GetChild(0);
            //// game object: prefab CubePlay -> CubePlayCanvas -> CubePlayText
            //var newPrefabCubePlayCanvasText = newPrefabCubePlayCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            var newPrefabCubePlayCanvasText = GetCubePlayTextMeshProUGUI(gameObject);

            //newPrefabCubePlayCanvasText.color = new Color(200, 33, 33, 0.7f);
            // newPrefabCubePlayCanvasText.color = new Color(12f, 0f, 0f, 0.6f);
            newPrefabCubePlayCanvasText.color = textColor;
            //newPrefabCubePlayCanvasText.fontSize = 0.7f;
        }

        public static void ChangeTextFontSize(GameObject gameObject, float fontSize)
        {
            var newPrefabCubePlayCanvasText = GetCubePlayTextMeshProUGUI(gameObject);
            newPrefabCubePlayCanvasText.fontSize = fontSize;
           // newPrefabCubePlayCanvasText.fontWeight = TMPro.FontWeight.Heavy;
        }

        public static Color GetNewColor(int dictionaryColorId)
        {
            Dictionary<int, Tuple<float, float, float, float>> colorDictionary = GameDictionaries.GameDictionariesCommon.DictionaryColor();
            var newColor = colorDictionary[dictionaryColorId];

            float r = newColor.Item1;
            float g = newColor.Item2;
            float b = newColor.Item3;
            float a = newColor.Item4;

            Color newTextColor = new Color(r, g, b, a);
            return newTextColor;
        }

        //[TextChange] - end
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------



        // --------------------------------------------------------------------------------------------------------------------------------------------------------------
        // [GetIndexZYXForGameObject] - start

        /// <summary>
        /// <para> currentNumberForPrefabCubePlay = number created for prefab "Cube Play" from the table created by CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI() </para>
        /// <para> table3D = CreateTableWithNumbersBasedOnMethodCreatingBoardGameforUI() </para>
        /// <para> it is returned the indexDepth, indexRow and indexColumn for the 3D array [Z, Y, X] / [indexDepth, indexRow, indexColumn] as it is in the regular 3D array</para>
        /// </summary>
        /// <param name="table"></param>
        /// <param name="currentNumberForPrefabCubePlay"></param>
        /// <returns></returns>
        public static Tuple<int, int, int> GetIndexZYXForGameObject(int[,,] table, int currentNumberForPrefabCubePlay)
        {
            int lenghtForDepths = table.GetLength(0);
            int lenghtForRows = table.GetLength(1);
            int lenghtForColumns = table.GetLength(2);

            for (int indexDepth = 0; indexDepth < lenghtForDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < lenghtForRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < lenghtForColumns; indexColumn++)
                    {
                        if (table[indexDepth, indexRow, indexColumn].Equals(currentNumberForPrefabCubePlay))
                        {

                            return Tuple.Create(indexDepth, indexRow, indexColumn);

                        }
                    }
                }
            }

            return Tuple.Create(0, 0, 0);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="cubePlayName"></param>
        /// <returns></returns>
        public static Tuple<int, int, int> GetIndexZYXForGameObject(GameObject[,,] table, string cubePlayName)
        {
            int lenghtForDepths = table.GetLength(0);
            int lenghtForRows = table.GetLength(1);
            int lenghtForColumns = table.GetLength(2);

            for (int indexDepth = 0; indexDepth < lenghtForDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < lenghtForRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < lenghtForColumns; indexColumn++)
                    {
                        GameObject cubePlay = table[indexDepth, indexRow, indexColumn];
                        string cubePlayNameFromTable = cubePlay.name;

                        if (cubePlayNameFromTable == cubePlayName)
                        {

                            return Tuple.Create(indexDepth, indexRow, indexColumn);

                        }
                    }
                }
            }

            return Tuple.Create(0, 0, 0);

        }

        //[GetIndexZYXForGameObject] - end
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static GameObject GetCubePlay(GameObject[,,] table, string cubePlayName)
        {
            GameObject cubePlay;
            int lenghtForDepths = table.GetLength(0);
            int lenghtForRows = table.GetLength(1);
            int lenghtForColumns = table.GetLength(2);

            for (int indexDepth = 0; indexDepth < lenghtForDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < lenghtForRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < lenghtForColumns; indexColumn++)
                    {
                        cubePlay = table[indexDepth, indexRow, indexColumn];
                        string cubePlayNameFromTable = cubePlay.name;

                        if (cubePlayNameFromTable == cubePlayName)
                        {

                            return cubePlay;

                        }

                    }             
                }  
            }

            return cubePlay = table[0, 0, 0];

        }


        public static GameObject GetCubePlay(GameObject[,,] table, int indexY, int indexX)
        {
            int indexZ = 0;
            GameObject cubePlay = table[indexZ, indexY, indexX];
            return cubePlay;
        }

        public static string GetCubePlayName(GameObject[,,] table, int indexY, int indexX)
        {
            int indexZ = 0;
            GameObject cubePlay = table[indexZ, indexY, indexX];
            string cubePlayName = cubePlay.name;
            return cubePlayName;
        }

        public static void SetUpNewZForGameObject(GameObject cubePlay, float newCoordinateZ)
        {
            //float transformSpeed = 1.0f;
            //float newZ = 0.05f;
            bool isGame2D = true;

            if (isGame2D == true)
            {
                float x = cubePlay.transform.position.x;
                float y = cubePlay.transform.position.y;
                float z = cubePlay.transform.position.z;

                // it works
                //cubePlay.transform.position = new Vector3(x, y, z + newCoordinateZ);
                cubePlay.transform.position = new Vector3(x, y, newCoordinateZ);

                //newPrefabCubePlay.transform.position = new Vector3(x, y, currentCoordinateZ * Time.deltaTime);

                //newPrefabCubePlay.transform.position =  Vector3.MoveTowards(newPrefabCubePlay.transform.position, (new Vector3(x, y, currentCoordinateZ)), transformSpeed * Time.deltaTime);

                //cubePlay.transform.Translate(Vector3.forward * Time.deltaTime);



                //Vector3 test = new Vector3(x, y, newCoordinateZ);
                //cubePlay.transform.position = Vector3.Lerp(cubePlay.transform.position, test, 0.1f);

                //cubePlay.transform.position += cubePlay.transform.forward * Time.deltaTime;


            }




        }



        public static void SetUpNewXForGameObject(GameObject gameObject, float newCoordinateX)
        {
            bool isGame2D = true;

            if (isGame2D == true)
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;
                float z = gameObject.transform.position.z;

                // it works
                gameObject.transform.position = new Vector3(x + newCoordinateX, y, z);
            }
        }


        public static void SetUpNewYForGameObject(GameObject gameObject, float newCoordinateY)
        {
            bool isGame2D = true;

            if (isGame2D == true)
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;
                float z = gameObject.transform.position.z;

                // it works
                gameObject.transform.position = new Vector3(x, y + newCoordinateY, z);
            }
        }
        
        public static void ChangeYForGameObject(GameObject gameObject, float newCoordinateY)
        {
            bool isGame2D = true;

            if (isGame2D == true)
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;
                float z = gameObject.transform.position.z;

                // it works
                gameObject.transform.position = new Vector3(x, newCoordinateY, z);
            }
        }
        
        public static int[] CreateTableWithGivenLengthAndGivenValue(int tableLenght, int value)
        {
            int[] table = new int[tableLenght];

            for (int i = 0; i < tableLenght; i++)
            {
                table[i] = value;
            }

            return table;
        }

        public static string GetObjectName(GameObject gameObject)
        {
            string gameObjectName = gameObject.name;
            return gameObjectName;
        }

        public static string GetObjectName(RaycastHit touchGameObject)
        {
            string gameObjectName = touchGameObject.collider.transform.name;
            return gameObjectName;
        }

        public static string GetObjectTag(GameObject gameObject)
        {
            string gameObjectTagName = gameObject.tag;
            return gameObjectTagName;
        }

        public static GameObject[] GetObjectByTagName(string tagName)
        {
            GameObject[] gameObject = GameObject.FindGameObjectsWithTag(tagName);
            return gameObject;
        }

        public static string GetObjectTag(RaycastHit touchGameObject)
        {
            string gameObjectTagName = touchGameObject.collider.transform.tag;
            return gameObjectTagName;
        }

        public static void ChangeTagForGameObject(GameObject gameObject, string gameObjectTagName)
        {
            gameObject.transform.tag = gameObjectTagName;
        }

        public static void ChangeTagForGameObject(RaycastHit touchGameObject, string gameObjectTagName)
        {
            touchGameObject.collider.transform.tag = gameObjectTagName;
        }

        public static int CheckAndReturnLowerNumber(int numberOne, int numberTwo)
        {

            if (numberTwo > numberOne)
            {
                return numberOne;
            }
            else if (numberTwo < numberOne)
            {
                return numberTwo;
            }
            else
            {
                // verticalLenght = horizontalLenght
                return numberTwo;
            }

        }

        public static int CheckAndReturnBiggerNumber(int numberOne, int numberTwo)
        {

            if (numberTwo > numberOne)
            {
                return numberTwo;
            }
            else if (numberTwo < numberOne)
            {
                return numberOne;
            }
            else
            {
                // verticalLenght = horizontalLenght
                return numberOne;
            }

        }

        public static string GetCubePlayPlayerSymbol(GameObject cubePlay)
        {
            var cubePlayText = cubePlay.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            string playerSymbol = cubePlayText.text;
            return playerSymbol;
        }


        public static void ChangeColourForGameObject(GameObject gameObject, Material newColour)
        {
            gameObject.GetComponent<Renderer>().material = newColour;
        }

        // do I need it?
        public static string ChangeToCapitalLetter(string symbol)
        {
            string text = symbol.ToUpper();
            return text;
        }


        //-------------------------------------------
        // create board/ table number











    }
}
