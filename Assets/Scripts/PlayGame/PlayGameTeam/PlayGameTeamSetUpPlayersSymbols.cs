using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;
using static UnityEngine.ParticleSystem;


namespace Assets.Scripts
{
    internal class PlayGameTeamSetUpPlayersSymbols
    {

        public static int[] GetPlayersNumbersForEachTeam(List<string[]> teamsSymbols)
        {
            int teamsNumbers = teamsSymbols.Count;
            int[] playersNumberInTeams = new int[teamsNumbers];

            for (int a = 0; a < teamsNumbers; a++)
            {
                string[] symbols = teamsSymbols[a];
                int number = symbols.Length;
                playersNumberInTeams[a] = number;
            }

            return playersNumberInTeams;
        }

        public static int GetPlayersNumber(List<string[]> teamsSymbols)
        {
            int[] playersNumberInTeams = GetPlayersNumbersForEachTeam(teamsSymbols);
            int teamsNumbers = playersNumberInTeams.Length;

            int allPlayersNumber = 0;

            for (int i = 0; i < teamsNumbers; i++)
            {
                int number = playersNumberInTeams[i];
                allPlayersNumber = allPlayersNumber + number;
            }

            return allPlayersNumber;
        }

        public static int GetPlayersNumber(string[] playersSymbols)
        {
            int playersNumbers = playersSymbols.Length;
            return playersNumbers;
        }

        public static int GetBiggestPlayerNumbersInTeam(List<string[]> teamsSymbols)
        {
            int[] playersNumberInTeams = GetPlayersNumbersForEachTeam(teamsSymbols);
            int teamsNumbers = playersNumberInTeams.Length;
            int maxNumber = 0;

            for (int i = 0; i < teamsNumbers; i++)
            {
                int numberToCompare = playersNumberInTeams[i];
                int result = GameCommonMethodsMain.GetBiggerNumber(maxNumber, numberToCompare);

                if (result > maxNumber)
                {
                    maxNumber = result;
                }
            }

            return maxNumber;
        }

        public static string[] CreateTableWithAllSymbols(List<string[]> teamsSymbols, int maxPlayerNumbersInTeam)
        {
            int teamsNumbers = teamsSymbols.Count;
            int maxLength = teamsNumbers * maxPlayerNumbersInTeam;

            string[] allSymbols = new string[maxLength];

            int index = 0;

            string symbolToRemove = "*";

            for (int l = 0; l < teamsNumbers; l++)
            {
                string[] teamSymbols = teamsSymbols[l];
                int playersNumberInTeam = teamSymbols.Length;

                for (int w = 0; w < maxPlayerNumbersInTeam; w++)
                {
                    if (w < playersNumberInTeam)
                    {
                        string symbol = teamSymbols[w];
                        allSymbols[index] = symbol;

                    }
                    else
                    {
                        allSymbols[index] = symbolToRemove;

                    }
                    index++;
                }
            }

            return allSymbols;
        }

        public static string[] CreateTableWithAllSymbolsForCorrectPlayersMove(string[] allSymbols, int maxPlayerNumbersInTeam)
        {
            int allSymbolsLength = allSymbols.Length - 1;
            string[] finalSymbols = new string[allSymbolsLength + 1];

            int index = 0;
            int nextIndex = 1;

            for (int a = 0; a < allSymbolsLength + 1; a++)
            {
                if (index <= allSymbolsLength)
                {
                    string symbol = allSymbols[index];
                    finalSymbols[a] = symbol;

                    index = index + maxPlayerNumbersInTeam;
                }
                else
                {
                    index = nextIndex;
                    string symbol2 = allSymbols[index];
                    finalSymbols[a] = symbol2;
                    index = index + maxPlayerNumbersInTeam;

                    nextIndex++;
                }
            }

            return finalSymbols;
        }

        public static string[] CreateTableWithFinalSymbols(string[] allSymbols, int allPlayersNumber)
        {
            string[] finalSymbols = new string[allPlayersNumber];
            string symbolToRemove = "*";

            int allSymbolsLength = allSymbols.Length;
            int index = 0;

            for (int i = 0; i < allSymbolsLength; i++)
            {
                string symbol = allSymbols[i];

                if (symbol.Equals(symbolToRemove))
                {
                }
                else
                {
                    finalSymbols[index] = allSymbols[i];
                    index++;
                }
            }
            return finalSymbols;
        }

        public static string[] CreateTableWithDifferentQuantitiesForPlayersMoves(List<string[]> teamsSymbols)
        {

            int teamsNumbers = teamsSymbols.Count;

            int maxPlayerNumbersInTeam = GetBiggestPlayerNumbersInTeam(teamsSymbols);

            int allPlayersNumber = GetPlayersNumber(teamsSymbols);
            int maxLength = teamsNumbers * maxPlayerNumbersInTeam;

            string[] allSymbols = CreateTableWithAllSymbols(teamsSymbols, maxPlayerNumbersInTeam);

            string[] allSymbolsForCorrectPlayersMove = CreateTableWithAllSymbolsForCorrectPlayersMove(allSymbols, maxPlayerNumbersInTeam);

            string[] finalSymbols = CreateTableWithFinalSymbols(allSymbolsForCorrectPlayersMove, allPlayersNumber);

            return finalSymbols;

        }

        // -- the same

        public static string[] GetFirstPlayersSymbolFromTeams(List<string[]> teamsSymbols)
        {
            int teamsNumbers = teamsSymbols.Count;
            string[] symbols = new string[teamsNumbers];

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamsSymbols[i];
                string symbol = teamSymbols[0];
                symbols[i] = symbol;
            }


            //Debug.Log(" ----------- GetFirstPlayersSymbolFromTeams --------------------");

            //for (int i = 0; i < symbols.Length; i++)
            //{
            //    Debug.Log($">>> symbols: {symbols[i]}");
            //}

            //Debug.Log(" ----------- GetFirstPlayersSymbolFromTeams --------------------");


            return symbols;

        }

        public static string GetSymbolsAsOneString(string[] firstTeamsSymbols)
        {
            string symbols = "";
            int numberOfSymbols = firstTeamsSymbols.Length;

            for (int i = 0; i < numberOfSymbols; i++)
            {
                string symbol = firstTeamsSymbols[i];
                symbols = symbols + symbol;
            }

            return symbols;
        }

        public static bool IsFisrtSymbolsAsTheSameAsLastOne(string firstSymbols, string symbolsToCompare)
        {
            bool isStringTheSame;

            if (firstSymbols.Equals(symbolsToCompare))
                isStringTheSame = true;
            else
                isStringTheSame = false;

            return isStringTheSame;
        }


        public static List<string[]> CreateTeablesWithTheSameLenght(List<string[]> teamsSymbols)
        {
            int maxPlayerNumbersInTeam = GetBiggestPlayerNumbersInTeam(teamsSymbols);
            //Debug.Log("maxPlayerNumbersInTeam: " + maxPlayerNumbersInTeam);
            int teamsNumbers = teamsSymbols.Count;

            string staticSymbol = "*";

            List<string[]> newTeamsSymbols = new List<string[]>();

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamsSymbols[i];
                int symbolsNumbers = teamSymbols.Length;

                string[] newTable = new string[maxPlayerNumbersInTeam];

                for (int j = 0; j < maxPlayerNumbersInTeam; j++)
                {
                    if (j < symbolsNumbers)
                    {
                        newTable[j] = teamSymbols[j];
                    }
                    else
                    {
                        newTable[j] = staticSymbol;
                    }
                }

                newTeamsSymbols.Insert(i, newTable);
            }

            //for (int i = 0; i < newTeamsSymbols.Count; i++)
            //{
            //    string[] teamSymbols = newTeamsSymbols[i];
            //    int symbolsNumbers = teamSymbols.Length;
            

            //    for (int j = 0; j < symbolsNumbers; j++)
            //    {
            //        Debug.Log($"team {i} : " + teamSymbols[j]);
            //    }
            //    Debug.Log(" ---------------  ");
            //}



            return newTeamsSymbols;

        }

        public static string[] GetSymbolsToCompare(List<string[]> teamsSymbols, string[] previousSymbols, int[] playersNumberInTeams, int indexForSymbols)
        {
            //string staticSymbol = "*";
            int teamsNumbers = teamsSymbols.Count;

            string[] newSymbols = new string[teamsNumbers];

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamsSymbols[i];
                int symbolsNumbers = teamSymbols.Length;

                int playersNumberInTeam = playersNumberInTeams[i];

                if (indexForSymbols < playersNumberInTeam)
                {
                    string symbol = teamSymbols[indexForSymbols];
                    newSymbols[i] = symbol;
                }
                else
                {
                    newSymbols[i] = previousSymbols[i];
                    Debug.Log($" ZZZZZZZZZ              newSymbols {i} : " + previousSymbols[i]);

                }
            }

            Debug.Log(" -------- GetSymbolsToCompare -------  ");

            for (int j = 0; j < newSymbols.Length; j++)
            {
                Debug.Log($"newSymbols {j} : " + newSymbols[j]);
            }

            Debug.Log(" ---------------  ");


            return newSymbols;
        }


        //public static string[] CreateTableWithTheSameQuantitiesForPlayersMoves_v1(List<string[]> teamsSymbols)
        //{
        //    int teamsNumbers = teamsSymbols.Count;
        //    Debug.Log("teamsNumbers :" + teamsNumbers);

        //    int[] playersNumberInTeams = GetPlayersNumbersForEachTeam(teamsSymbols);

        //    //Debug.Log(" ----------- 1 CreateTableWithTheSameQuantitiesForPlayersMoves playersNumberInTeams --------------------");

        //    //for (int i = 0; i < playersNumberInTeams.Length; i++)
        //    //{
        //    //    Debug.Log($">>> playersNumberInTeams: {playersNumberInTeams[i]}");
        //    //}

        //    //Debug.Log(" ----------- 1 CreateTableWithTheSameQuantitiesForPlayersMoves playersNumberInTeams --------------------");


        //    List<string[]> symbols = CreateTeablesWithTheSameLenght(teamsSymbols);

        //    bool isFisrtSymbolsAsSameAsLastOne = false;

        //    int index = 1;
        //    //int index = 0;

        //    //int maxPlayersNumberInTeam = 4;
            
        //    string[] previousSymbols = GetFirstPlayersSymbolFromTeams(teamsSymbols);

        //    string firstSymbols = GetSymbolsAsOneString(previousSymbols);

        //    string playersSymbols = firstSymbols;

        //    string finalListWithSymbols = firstSymbols;

        //    Debug.Log("1 finalListWithSymbols: " + finalListWithSymbols);


        //    while (isFisrtSymbolsAsSameAsLastOne == false)
        //    {
        //        //index++;
        //        Debug.Log("1 IIIIII index: " + index);
        //        string[] symbolsToCompare = GetSymbolsToCompare(symbols, previousSymbols, playersNumberInTeams, index);

        //        string symbolsToCompareOneString = GetSymbolsAsOneString(symbolsToCompare);
        //        Debug.Log("symbolsToCompareOneString: " + symbolsToCompareOneString);

        //        isFisrtSymbolsAsSameAsLastOne = IsFisrtSymbolsAsTheSameAsLastOne(playersSymbols, symbolsToCompareOneString);

        //        if (isFisrtSymbolsAsSameAsLastOne == false)
        //        {
        //            finalListWithSymbols = finalListWithSymbols + symbolsToCompareOneString;
        //            Debug.Log("2 finalListWithSymbols: " + finalListWithSymbols);
        //        }
        //        Debug.Log("2 IIIIII index: " + index);
        //        index++;
        //        Debug.Log("3 IIIIII index: " + index);
        //        if (index > teamsNumbers + 1)               
        //        {
        //            index = 0;
        //        }
                
        //    }

        //    Debug.Log("3 finalListWithSymbols: " + finalListWithSymbols);

        //    int newSymbolLength = finalListWithSymbols.Length;

        //    string[] finalSymbols = new string[newSymbolLength];

        //    for (int i = 0; i < newSymbolLength; i++)
        //    {
        //        string character = finalListWithSymbols.Substring(i, 1);
        //        finalSymbols[i] = character;
        //    }

        //    Debug.Log(" ----------- CreateTableWithTheSameQuantitiesForPlayersMoves --------------------");

        //    for (int i = 0; i < finalSymbols.Length; i++)
        //    {
        //        Debug.Log($">>> finalSymbols: {finalSymbols[i]}");
        //    }

        //    Debug.Log(" ----------- CreateTableWithTheSameQuantitiesForPlayersMoves --------------------");

        //    return finalSymbols;

        //}
        public static List<string[]> GetTeamsOrderByAscendingPlayerNumberInTeam(List<string[]> teamsSymbols)
        {
            List<string[]> teams = new List<string[]>();

            int teamsNumber = teamsSymbols.Count;
            int[] numbers = new int[teamsNumber];

            for (int i = 0; i < teamsNumber; i++)
            {

                string[] team = teamsSymbols[i];
                int playersNumber = team.Length;
                numbers[i] = playersNumber;
            }


            var newOrder = numbers.OrderBy(x => x);
            int index = 0;

            foreach (int value in newOrder)
            {
                for (int a = 0; a < teamsNumber; a++)
                {
                    int number = numbers[a];

                    if (number == value)
                    {
                        string[] teamSymbols = teamsSymbols[a];
                        teams.Insert(index, teamSymbols);
                    }

                }


            }




            //int teamsNumber = teamsSymbols.Count;
            //string numbers = "";

            //for (int i = 0; i < teamsNumber; i++)
            //{

            //    string[] team = teamsSymbols[i];
            //    int playersNumber = team.Length;
            //    numbers = numbers + playersNumber;
            //}

            // ---
            //string orderedNumbers = "";
            //string numbers2 = numbers;
            //int number = 0;
            //for (int z = 0; z < teamsNumber; z++)
            //{

            //    string numberText = numbers2.Substring(0, 1);
            //    int nextNumber = CommonMethods.ConvertStringToInt(numberText);

            //    if (nextNumber > number)
            //    {
            //        orderedNumbers = orderedNumbers + numberText;
            //        number = nextNumber;
            //    }
            //    else
            //    {
            //        orderedNumbers = numberText + orderedNumbers;
            //        number = nextNumber;
            //    }

            //    numbers2.Remove(0,1);
            //}





            //int number = newOrder;

            return teams;

        }

        public static string[] CreateTableWithTheSameQuantitiesForPlayersMoves(List<string[]> teamsSymbols)
        {
            int teamsNumbers = teamsSymbols.Count;
            Debug.Log("teamsNumbers :" + teamsNumbers);

            int[] playersNumberInTeams = GetPlayersNumbersForEachTeam(teamsSymbols);

            //Debug.Log(" ----------- 1 CreateTableWithTheSameQuantitiesForPlayersMoves playersNumberInTeams --------------------");

            //for (int i = 0; i < playersNumberInTeams.Length; i++)
            //{
            //    Debug.Log($">>> playersNumberInTeams: {playersNumberInTeams[i]}");
            //}

            //Debug.Log(" ----------- 1 CreateTableWithTheSameQuantitiesForPlayersMoves playersNumberInTeams --------------------");

            List<string[]> teamsOrderByAscendingPlayerNumberInTeam = GetTeamsOrderByAscendingPlayerNumberInTeam(teamsSymbols);

            List<string[]> symbols = CreateTeablesWithTheSameLenght(teamsSymbols);

            bool isFisrtSymbolsAsSameAsLastOne = false;

            int indexForSymbols = 1;
            //int index = 0;

            //int maxPlayersNumberInTeam = 4;

            string[] previousSymbols = GetFirstPlayersSymbolFromTeams(teamsSymbols);

            string firstSymbols = GetSymbolsAsOneString(previousSymbols);

            string playersSymbols = firstSymbols;

            string finalListWithSymbols = firstSymbols;

            Debug.Log("1 finalListWithSymbols: " + finalListWithSymbols);


            while (isFisrtSymbolsAsSameAsLastOne == false)
            {
                //index++;
                Debug.Log("1 IIIIII indexForSymbols: " + indexForSymbols);
                string[] symbolsToCompare = GetSymbolsToCompare(symbols, previousSymbols, playersNumberInTeams, indexForSymbols);

                string symbolsToCompareOneString = GetSymbolsAsOneString(symbolsToCompare);
                Debug.Log("symbolsToCompareOneString: " + symbolsToCompareOneString);

                isFisrtSymbolsAsSameAsLastOne = IsFisrtSymbolsAsTheSameAsLastOne(playersSymbols, symbolsToCompareOneString);

                if (isFisrtSymbolsAsSameAsLastOne == false)
                {
                    finalListWithSymbols = finalListWithSymbols + symbolsToCompareOneString;
                    Debug.Log("2 finalListWithSymbols: " + finalListWithSymbols);
                }
                Debug.Log("2 IIIIII indexForSymbols: " + indexForSymbols);
                indexForSymbols++;
                Debug.Log("3 IIIIII indexForSymbols: " + indexForSymbols);

                if (indexForSymbols > teamsNumbers + 1)
                {
                    indexForSymbols = 0;
                }

            }

            Debug.Log("3 finalListWithSymbols: " + finalListWithSymbols);

            int newSymbolLength = finalListWithSymbols.Length;

            string[] finalSymbols = new string[newSymbolLength];

            for (int i = 0; i < newSymbolLength; i++)
            {
                string character = finalListWithSymbols.Substring(i, 1);
                finalSymbols[i] = character;
            }

            //Debug.Log(" ----------- CreateTableWithTheSameQuantitiesForPlayersMoves --------------------");

            //for (int i = 0; i < finalSymbols.Length; i++)
            //{
            //    Debug.Log($">>> finalSymbols: {finalSymbols[i]}");
            //}

            //Debug.Log(" ----------- CreateTableWithTheSameQuantitiesForPlayersMoves --------------------");

            return finalSymbols;

        }

    }
}
