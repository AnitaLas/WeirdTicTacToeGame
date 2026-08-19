using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
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

        public static int[] GetMaxIndexesForTeamSymbols(List<string[]> teamsSymbols)
        {
            int teamsNumbers = teamsSymbols.Count;
            int[] playersNumberInTeams = new int[teamsNumbers];

            for (int a = 0; a < teamsNumbers; a++)
            {
                string[] symbols = teamsSymbols[a];
                int index = symbols.Length - 1;
                playersNumberInTeams[a] = index;
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
                    maxNumber = result;
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
                        newTable[j] = teamSymbols[j];
                    else
                        newTable[j] = staticSymbol;
                }

                newTeamsSymbols.Insert(i, newTable);
            }

            return newTeamsSymbols;
        }

        public static string[] GetFirstSymbolsToCompare(List<string[]> teamsSymbols, string[] previousSymbols, int[] playersNumberInTeams, int indexForSymbols)
        {
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
                }
            }

            return newSymbols;
        }

        public static List<string[]> GetTeamsOrderByAscendingPlayerNumberInTeam(List<string[]> teamsSymbols)
        {
            List<string[]> teamsNewOrder = new List<string[]>();

            int teamsNumber = teamsSymbols.Count;

            var teamsOldOrder123 = teamsSymbols.OrderBy(x => x.Length);

            int index = 0;
            foreach (string[] value in teamsOldOrder123)
            {
                teamsNewOrder.Insert(index, value);
                index++;
            }
            return teamsNewOrder;
        }

        public static int[] GetMaxIndexesForSetUpNextSymobls(int[] playersNumberInTeams)
        {
            int teamsNumbers = playersNumberInTeams.Length;
            int[] maxIndexes = new int[teamsNumbers];
            int maxIndexForTeam;

            for (int i = 0; i < teamsNumbers; i++)
            {
                if (playersNumberInTeams[i] > 2)
                    maxIndexForTeam = playersNumberInTeams[i] - 2;
                else
                    maxIndexForTeam = 0;

                maxIndexes[i] = maxIndexForTeam;
            }
            return maxIndexes;
        }

        public static string[] CreateTableWithTheSameQuantitiesForPlayersMoves(List<string[]> teamsSymbols)
        {
            int teamsNumbers = teamsSymbols.Count;

            List<string[]> teamsOrderByAscendingPlayerNumberInTeam = GetTeamsOrderByAscendingPlayerNumberInTeam(teamsSymbols);

            List<string[]> symbols = CreateTeablesWithTheSameLenght(teamsOrderByAscendingPlayerNumberInTeam);

            //----
            bool isFisrtSymbolsAsSameAsLastOne = false;

            int indexForSymbols = 1;

            string[] previousSymbols = GetFirstPlayersSymbolFromTeams(teamsOrderByAscendingPlayerNumberInTeam);

            string firstSymbols = GetSymbolsAsOneString(previousSymbols);

            string firstSymbolsToCompare = firstSymbols;
            string finalListWithSymbols = firstSymbols;

            string[] currentsymbolsToCompare;

            // ----
            List<List<string[]>> symbolsToCompare = new List<List<string[]>>();

            int[] playersNumberInTeams = GetPlayersNumbersForEachTeam(teamsOrderByAscendingPlayerNumberInTeam);

            int maxPlayersNumberInTeam = GetBiggestPlayerNumbersInTeam(teamsOrderByAscendingPlayerNumberInTeam);

            int[] maxIndexsNextSymobls = GetMaxIndexesForSetUpNextSymobls(playersNumberInTeams);

            string[] nextSymbolsToCompare = GetFirstSymbolsToCompare(symbols, previousSymbols, playersNumberInTeams, indexForSymbols);

            string[] previousSymbolsToGetSymbols = previousSymbols;
            string[] waitSymbolsToGetSymbols = previousSymbols;
            string[] newSymbolsToGetSymbols = previousSymbols;

            int indexForListWithPartialSymbols = 1;

            List<string[]> startListWithPartialSymbols = new List<string[]>();

            startListWithPartialSymbols.Insert(0, previousSymbolsToGetSymbols);
            startListWithPartialSymbols.Insert(1, waitSymbolsToGetSymbols);
            startListWithPartialSymbols.Insert(2, newSymbolsToGetSymbols);

            symbolsToCompare.Insert(0, startListWithPartialSymbols);

            currentsymbolsToCompare = nextSymbolsToCompare;

            int[] maxIndexesForTeamSymbols = GetMaxIndexesForTeamSymbols(teamsOrderByAscendingPlayerNumberInTeam);

            int teamNumber = 0;
            int maxIndexForTeamSymbols = maxIndexesForTeamSymbols[teamNumber];

            int aAaaa = 1;
            while (isFisrtSymbolsAsSameAsLastOne == false)
            {
                symbolsToCompare = GetNextSymbolsToCompare(symbolsToCompare, symbols, indexForListWithPartialSymbols, indexForSymbols, maxIndexsNextSymobls, playersNumberInTeams);

                List<string[]> lastList = symbolsToCompare[indexForListWithPartialSymbols];

                if (indexForListWithPartialSymbols < 1)
                    currentsymbolsToCompare = lastList[1]; //2
                else
                    currentsymbolsToCompare = lastList[2];

                indexForListWithPartialSymbols++;

                string symbolsToCompareOneString = GetSymbolsAsOneString(currentsymbolsToCompare);

                isFisrtSymbolsAsSameAsLastOne = IsFisrtSymbolsAsTheSameAsLastOne(firstSymbolsToCompare, symbolsToCompareOneString);

                if (isFisrtSymbolsAsSameAsLastOne == false)
                    finalListWithSymbols = finalListWithSymbols + symbolsToCompareOneString;

                indexForSymbols++;
                aAaaa++;
            }

            int newSymbolLength = finalListWithSymbols.Length;

            string[] finalSymbols = new string[newSymbolLength];

            for (int i = 0; i < newSymbolLength; i++)
            {
                string character = finalListWithSymbols.Substring(i, 1);
                finalSymbols[i] = character;
            }

            return finalSymbols;
        }

        public static List<List<string[]>> GetNextSymbolsToCompare_v2(List<List<string[]>> symbolsToCompare, List<string[]> teamsSymbols, int indexForListWithPartialSymbols, int indexForSymbols, int[] maxIndexsNextSymobls, int[] playersNumberInTeams)
        {

            List<string[]> nextListWithPartialSymbols = new List<string[]>();
            int currentListMaxIndexSymbolsToCompare = symbolsToCompare.Count - 1;
            int teamsNumbers = teamsSymbols.Count;

            string[] newSymbols = new string[teamsNumbers];

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamsSymbols[i];

                int teamNumbers = teamSymbols.Length;

                int playersNumberInTeam = playersNumberInTeams[i];

                if (indexForSymbols < playersNumberInTeam)
                {
                    string symbol = teamSymbols[indexForSymbols];
                    newSymbols[i] = symbol;
                }
                else
                {
                    //-- index for list
                    int indexForTeamSymbolsList = maxIndexsNextSymobls[i];

                    int indexForPreviousSymbols = 0;

                    if (currentListMaxIndexSymbolsToCompare < 2)
                        indexForPreviousSymbols = 0;
                    else
                        indexForPreviousSymbols = currentListMaxIndexSymbolsToCompare - indexForTeamSymbolsList;

                    List<string[]> listPreviousSymbols = symbolsToCompare[indexForPreviousSymbols];

                    string[] previousSymbols;

                    previousSymbols = listPreviousSymbols[1];

                    int indexForSymbol = i; //team number

                    newSymbols[i] = previousSymbols[indexForSymbol];
                }
            }

            List<string[]> lastList = symbolsToCompare[currentListMaxIndexSymbolsToCompare];
            string[] oldPreviousSymbolsToGetSymbols = lastList[0];
            string[] oldWaitSymbolsToGetSymbols = lastList[1];
            string[] oldNewSymbolsToGetSymbols = lastList[2];

            nextListWithPartialSymbols.Insert(0, oldWaitSymbolsToGetSymbols);

            if (indexForListWithPartialSymbols == 1)
                nextListWithPartialSymbols.Insert(1, oldWaitSymbolsToGetSymbols);
            else
                nextListWithPartialSymbols.Insert(1, oldNewSymbolsToGetSymbols);

            nextListWithPartialSymbols.Insert(2, newSymbols);

            string[] previousNEW = nextListWithPartialSymbols[0];
            string[] waitNEW = nextListWithPartialSymbols[1];
            string[] newNEW = nextListWithPartialSymbols[2];

            symbolsToCompare.Insert(indexForListWithPartialSymbols, nextListWithPartialSymbols);

            return symbolsToCompare;
        }

        public static List<List<string[]>> GetNextSymbolsToCompare(List<List<string[]>> symbolsToCompare, List<string[]> teamsSymbols, int indexForListWithPartialSymbols, int indexForSymbols, int[] maxIndexsNextSymobls, int[] playersNumberInTeams)
        {
            List<string[]> nextListWithPartialSymbols = new List<string[]>();
            int currentListMaxIndexSymbolsToCompare = symbolsToCompare.Count - 1;
            int teamsNumbers = teamsSymbols.Count;

            string[] newSymbols = new string[teamsNumbers];

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamsSymbols[i];

                int teamNumbers = teamSymbols.Length;

                int playersNumberInTeam = playersNumberInTeams[i];

                if (indexForSymbols < playersNumberInTeam)
                {
                    string symbol = teamSymbols[indexForSymbols];
                    newSymbols[i] = symbol;
                }
                else
                {
                    //-- index for list
                    int indexForTeamSymbolsList = maxIndexsNextSymobls[i];

                    int indexForPreviousSymbols = 0;

                    if (currentListMaxIndexSymbolsToCompare < 2)
                        indexForPreviousSymbols = 0;
                    else
                        indexForPreviousSymbols = currentListMaxIndexSymbolsToCompare - indexForTeamSymbolsList;

                    List<string[]> listPreviousSymbols = symbolsToCompare[indexForPreviousSymbols];

                    string[] previousSymbols;

                    previousSymbols = listPreviousSymbols[1];

                    int indexForSymbol = i; //team number

                    newSymbols[i] = previousSymbols[indexForSymbol];
                }
            }


            List<string[]> lastList = symbolsToCompare[currentListMaxIndexSymbolsToCompare];
            string[] oldPreviousSymbolsToGetSymbols = lastList[0];
            string[] oldWaitSymbolsToGetSymbols = lastList[1];
            string[] oldNewSymbolsToGetSymbols = lastList[2];

            nextListWithPartialSymbols.Insert(0, oldWaitSymbolsToGetSymbols);

            if (indexForListWithPartialSymbols == 1)
                nextListWithPartialSymbols.Insert(1, oldWaitSymbolsToGetSymbols);
            else
                nextListWithPartialSymbols.Insert(1, oldNewSymbolsToGetSymbols);

            nextListWithPartialSymbols.Insert(2, newSymbols);

            string[] previousNEW = nextListWithPartialSymbols[0];
            string[] waitNEW = nextListWithPartialSymbols[1];
            string[] newNEW = nextListWithPartialSymbols[2];

            symbolsToCompare.Insert(indexForListWithPartialSymbols, nextListWithPartialSymbols);

            return symbolsToCompare;
        }
    }
}