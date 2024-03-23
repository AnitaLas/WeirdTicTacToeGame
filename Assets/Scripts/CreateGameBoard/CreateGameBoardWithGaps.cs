using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class CreateGameBoardWithGaps
    {

        public static int[] GetRandomCubePlayNumbersToDestroy(int numbersCubePlayMax, int numberOfGaps)
        {
            int[] randomNumbers = new int[numberOfGaps];
            int halfNumberMax = numbersCubePlayMax / 2;
            int randomNumber = CommonMethods.ChooseRandomNumber(numbersCubePlayMax);
            randomNumbers[0] = randomNumber;

            for (int i = 0; i < numberOfGaps; i++)
            {
               //int randomNumber = CommonMethods.ChooseRandomNumber(numbersCubePlayMax);
               randomNumber = CommonMethods.ChooseRandomNumber(numbersCubePlayMax);

                for (int j = 0; j < numberOfGaps; j++)
                {
                    int numberToCheck = randomNumbers[j];
                    if (numberToCheck != randomNumber)
                        randomNumbers[i] = numberToCheck;
                    else
                    {
                        if(numberToCheck <= halfNumberMax)
                            randomNumbers[i] = CommonMethods.ChooseRandomNumber(numbersCubePlayMax, numberToCheck);
                        else
                            randomNumbers[i] = CommonMethods.ChooseRandomNumber(numberToCheck, 1);
                    }
                        
                }
            }
            return randomNumbers;
        }

        public static string[] SetUpRightCurrentNumberForCubePlayToDestroy(int numbersCubePlayMax, int numberOfGaps)
        {
            int[] randomNumbers = GetRandomCubePlayNumbersToDestroy(numbersCubePlayMax, numberOfGaps);
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

    }
}
