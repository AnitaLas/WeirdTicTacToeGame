using Assets.Scripts.GameFieldsVerification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfigurationTableForLenghtToCheck : MonoBehaviour
    {
        public static int GetNumberFromConfiguration(string tagName)
        {
            GameObject[] objectsNumber = CommonMethods.GetObjectByTagName(tagName);
            GameObject objectNumber = objectsNumber[0];
            string numberString = CommonMethods.GetCubePlayText(objectNumber);
            int numberInt = CommonMethods.ConvertStringToInt(numberString);
            return numberInt;
        }

        public static int[] CreateTableWithNumberFromConfiguration(string tagNameRows, string tagNameColumns)
        {
            string[] tagsName = { tagNameRows, tagNameColumns };
            int tagsNameLenght = tagsName.Length;

            string tagName;
            int[] numbers = new int[tagsNameLenght];

            for (int i = 0; i < tagsNameLenght; i++)
            {
                tagName = tagsName[i];
                int number = GetNumberFromConfiguration(tagName);
                numbers[i] = number;
            }

            return numbers;
        }

        public static int GetLenghtToCheckMax(string tagNameRows, string tagNameColumns)
        {
            int[] numbers = CreateTableWithNumberFromConfiguration(tagNameRows, tagNameColumns);
            int rows = numbers[0];
            int columns = numbers[1];

            int maxNumberInt = CommonMethods.CheckAndReturnLowerNumber(rows, columns);
            string numberString = CommonMethods.ConverIntToString(maxNumberInt);

            var numberKind = Tuple.Create(maxNumberInt, numberString);

            Debug.Log("maxNumberInt = " + maxNumberInt);

            return maxNumberInt;

        }

        public static GameObject[,,] CreateTableForMaxLenghtToCheck(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField, int end)
        {
            GameObject[,,] table;
            int start = 2;
            int end2 = end + 1;
            float newCoordinateY = 100f;
            string inactiveText = "-";

            table = GameConfigurationTableForSetUp.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end2, newCoordinateY, inactiveText);
            return table;

        }

        public static void DestroyTable(GameObject[,,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    for (int z = 0; z < table.GetLength(2); z++)
                    {
                        GameObject toRemove = table[i, j, z];

                       // if (toRemove != null) 
                       // {
                            Destroy(toRemove);
                        //}

                    }
                }
            }
        }

        public static void VerifyAndSetUpNewMaxLength(int rowsNumber, int columnsNumber, int currentLenghtToCheck, string tagConfigurationBoardGameLenghtToCheck)
        {
            //Debug.Log("test 2");
            GameObject[] gameObjects = CommonMethods.GetObjectByTagName(tagConfigurationBoardGameLenghtToCheck);
            GameObject gameObject = gameObjects[0];

            Debug.Log("rowsNumber = " + rowsNumber);
            Debug.Log("columnsNumber = " + columnsNumber);
            Debug.Log("currentLenghtToCheck = " + currentLenghtToCheck);

            int lowerNumber = CommonMethods.CheckAndReturnLowerNumber(rowsNumber, columnsNumber);
            Debug.Log("lowerNumber = " + lowerNumber);
           

            string defaulNumber = "3";



            if (lowerNumber < currentLenghtToCheck)
            {
               // Debug.Log("test 3");
               CommonMethods.ChangeTextForFirstChild(gameObject, defaulNumber);
               //CommonMethods.ChangeTextForFirstChild(gameObject, lowerNumberString);

            }

        }

    }
}
