using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CreateGameBoardWithGaps
    {
        public static int[] GetRandomCubePlayNumbers(int numbersCubePlayMax, int numberOfGaps)
        {
            int number = -1;
            int[] randomNumbers = CreateGameBoardCommonMethods.CreateTableWithOneNumber(number, numberOfGaps);
            int minNumber = 1;

            int randomNumber = CommonMethods.ChooseRandomNumber(minNumber, numbersCubePlayMax);
            randomNumbers[0] = randomNumber;
            int newRandomNumber = randomNumber;
            bool isExistDigitEqualToZeroInTable = true;

            do
            {
                for (int i = 1; i < numberOfGaps; i++)
                {
                    newRandomNumber = CommonMethods.ChooseRandomNumber(minNumber, numbersCubePlayMax);

                    for (int j = 0; j < numberOfGaps; j++)
                    {
                        int numberToCheck = randomNumbers[i];

                        if (numberToCheck != newRandomNumber)
                            randomNumbers[i] = newRandomNumber;
                    }
                }

                isExistDigitEqualToZeroInTable = CheckIsExistDigitEqualToZeroInTable(randomNumbers);

            } while (isExistDigitEqualToZeroInTable == true);

            return randomNumbers;
        }

        public static bool CheckIsExistDigitEqualToZeroInTable(int[] randomNumbers)
        {
            bool isExistDigit = false;
            int tableLenght = randomNumbers.Length;
            int number;

            for (int i = 0; i < tableLenght; i++)
            {
                number = randomNumbers[i];
                if (number == -1)
                    isExistDigit = false;
            }
            return isExistDigit;
        }

        public static string[] SetUpRightCurrentNumberForCubePlay(int numbersCubePlayMax, int numberOfRows, int numberOfGaps)
        {
            int[] randomNumbers = GetRandomCubePlayNumbers(numbersCubePlayMax, numberOfGaps);
            int randomNumbersLenght = randomNumbers.Length;
            string[] cubePlayNumbers = new string[randomNumbersLenght];
            int number;

            for (int i = 0; i < randomNumbersLenght; i++)
            {
                number = randomNumbers[i];
                cubePlayNumbers[i] = CreateTablePrefabName.SetUpRightCurrentNumber(number, numbersCubePlayMax);
            }

            return cubePlayNumbers;
        }

        public static string[] GetFullCubePlayNames(string[] cubePlayNumbers, GameObject[,,] boardGame)
        {
            int maxIndexDepth = boardGame.GetLength(0);
            int maxIndexColumn = boardGame.GetLength(2);
            int maxIndexRow = boardGame.GetLength(1);
            int cubePlayNumbersLenght = cubePlayNumbers.Length;
            string[] namesToDestroy = new string[cubePlayNumbersLenght];

            for (int i = 0; i < cubePlayNumbersLenght; i++)
            {
                string particalName = cubePlayNumbers[i];

                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                            GameObject cubePlay = boardGame[indexDepth, indexRow, indexColumn];
                            string fullName = cubePlay.name;

                            bool isParticalNameContained = fullName.Contains(particalName);
                            if (isParticalNameContained == true)
                                namesToDestroy[i] = fullName;
                        }
                    }
                }
            }

            return namesToDestroy;
        }


        public static void CubePlayToHide(string cubePlayName)
        {
            string tagCubePlayTaken = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagTaken();
            string[] defaulSymbolsForVerification = new string[3]; // future - add method which will generate that symbols
            defaulSymbolsForVerification[0] = "xD";
            defaulSymbolsForVerification[1] = ":P";
            defaulSymbolsForVerification[2] = "^^";

            float newCoordinateY = 200f;

            int minIndex = 0;
            int maxIndex = defaulSymbolsForVerification.Length - 1;
            int randomIndex = CommonMethods.ChooseRandomNumber(minIndex, maxIndex);

            string defaultSymbol = defaulSymbolsForVerification[randomIndex];

            GameObject cubePlay = CommonMethods.GetObjectByName(cubePlayName);
            CommonMethods.ChangeTextForCubePlay(cubePlay, defaultSymbol);
            CommonMethods.ChangeTagForGameObject(cubePlay, tagCubePlayTaken); // help buttons
            GameCommonMethodsSetUpCoordinates.ChangeYForGameObject(cubePlay, newCoordinateY);
        }

    }
}