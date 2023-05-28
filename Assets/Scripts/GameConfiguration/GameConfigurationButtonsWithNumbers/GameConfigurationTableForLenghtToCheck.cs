using UnityEngine;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfigurationTableForLenghtToCheck : MonoBehaviour
    {
        //public static int GetNumberFromConfiguration(string tagName)
        //{
        //    GameObject objectNumber = CommonMethods.GetObjectByTagName(tagName);
        //    string numberString = CommonMethods.GetCubePlayText(objectNumber);
        //    int numberInt = CommonMethods.ConvertStringToInt(numberString);
        //    return numberInt;
        //}

        //public static int[] CreateTableWithNumberFromConfiguration(string tagNameRows, string tagNameColumns)
        //{
        //    string[] tagsName = { tagNameRows, tagNameColumns };
        //    int tagsNameLenght = tagsName.Length;

        //    string tagName;
        //    int[] numbers = new int[tagsNameLenght];

        //    for (int i = 0; i < tagsNameLenght; i++)
        //    {
        //        tagName = tagsName[i];
        //        int number = GetNumberFromConfiguration(tagName);
        //        numbers[i] = number;
        //    }

        //    return numbers;
        //}

        //public static int GetLenghtToCheckMax(string tagNameRows, string tagNameColumns)
        //{
        //    int[] numbers = CreateTableWithNumberFromConfiguration(tagNameRows, tagNameColumns);
        //    int rows = numbers[0];
        //    int columns = numbers[1];

        //    int maxNumberInt = CommonMethods.CheckAndReturnLowerNumber(rows, columns);

        //    return maxNumberInt;
        //}

        //public static GameObject[,,] CreateTableForMaxLenghtToCheck(GameObject[,,] tableWtithNumber, string tagConfigurationBoardGameTableNumberForAll, string tagConfigurationBoardGameInactiveField, int end)
        //{
        //    GameObject[,,] table;
        //    int start = 2;
        //    int end2 = end + 1;
        //    float newCoordinateY = 100f;
        //    string inactiveText = "-";

        //    table = GameConfigurationTableForSetUp.ChangeDataForTableWithNumbers(tableWtithNumber, tagConfigurationBoardGameTableNumberForAll, tagConfigurationBoardGameInactiveField, start, end2, newCoordinateY, inactiveText);
        //    return table;
        //}

        //public static void DestroyTable(GameObject[,,] table)
        //{
        //    for (int i = 0; i < table.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < table.GetLength(1); j++)
        //        {
        //            for (int z = 0; z < table.GetLength(2); z++)
        //            {
        //                GameObject toRemove = table[i, j, z];
        //                Destroy(toRemove);

        //            }
        //        }
        //    }
        //}

        //public static int GetNumberGivenByUser(string tagName)
        //{
        //    GameObject gameObject = CommonMethods.GetObjectByTagName(tagName);
        //    string gameObjectText = CommonMethods.GetCubePlayText(gameObject);

        //    int number = CommonMethods.ConvertStringToInt(gameObjectText);
        //    return number;
        //}

        //public static void VerifyAndSetUpNewMaxLength(string[] tableWithChangedNumber)
        //{
        //    string tagConfigurationBoardGameChangeNumberRows = tableWithChangedNumber[0];
        //    string tagConfigurationBoardGameChangeNumberColumns = tableWithChangedNumber[1];
        //    string tagConfigurationBoardGameChangeNumberLenghtToCheck = tableWithChangedNumber[2];

        //    GameObject gameObject = CommonMethods.GetObjectByTagName(tagConfigurationBoardGameChangeNumberLenghtToCheck);

        //    int rowsNumber = GetNumberGivenByUser(tagConfigurationBoardGameChangeNumberRows);
        //    int columnsNumber = GetNumberGivenByUser(tagConfigurationBoardGameChangeNumberColumns);
        //    int currentLenghtToCheck = GetNumberGivenByUser(tagConfigurationBoardGameChangeNumberLenghtToCheck);

        //    int lowerNumber = CommonMethods.CheckAndReturnLowerNumber(rowsNumber, columnsNumber);

        //    string defaulNumber = "3";

        //    if (lowerNumber < currentLenghtToCheck)
        //    {
        //        CommonMethods.ChangeTextForFirstChild(gameObject, defaulNumber);
        //    }
        //}
    }
}
