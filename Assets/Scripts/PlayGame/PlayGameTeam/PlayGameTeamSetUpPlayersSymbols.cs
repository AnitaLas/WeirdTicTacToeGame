using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
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


            //for (int i = 0; i < playersNumberInTeams.Length; i++)
            //{
            //    Debug.Log($"playersNumberInTeams[{i}]: " + playersNumberInTeams[i]);
            //}

            //Debug.Log($" ------------------- 1 ----------------------- ");

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
            //Debug.Log($"allSymbolsLength: " + allSymbolsLength);
            //Debug.Log($"maxPlayerNumbersInTeam: " + maxPlayerNumbersInTeam);

            //Debug.Log($" ------------------- 1 ----------------------- ");
            string[] finalSymbols = new string[allSymbolsLength + 1];


            //for (int i = 0; i < allSymbols.Length; i++)
            //{
            //    Debug.Log($"allSymbols[{i}]: " + allSymbols[i]);
            //}

            //Debug.Log($" ------------------- 2 ----------------------- ");

            //int index = 0;
            int index = 0;
            int nextIndex = 1;

            for (int a = 0; a < allSymbolsLength + 1; a++)
            {
                //Debug.Log($"for index: " + index);

                if (index <= allSymbolsLength)
                {
                    //Debug.Log($"if 1 index: " + index);
                    //Debug.Log($"index: " + index);
                    string symbol = allSymbols[index];

                    //nextIndex = nextIndex + maxPlayerNumbersInTeam;
                    finalSymbols[a] = symbol;

                    index = index + maxPlayerNumbersInTeam;
                    //Debug.Log($"if 2 index: " + index);
                    //if (index >= allSymbolsLength)
                    //{
                    //    index = nextIndex;

                    //    string symbol2 = allSymbols[index];
                    //    index = index + maxPlayerNumbersInTeam;
                    //    //nextIndex = nextIndex + maxPlayerNumbersInTeam;
                    //    finalSymbols[a] = symbol2;

                    //    index = index + maxPlayerNumbersInTeam;
                    //    nextIndex++;
                    //}

                    //Debug.Log($"symbol: " + symbol);

                    //Debug.Log($"index: " + index);
                }
                else
                {


                    //Debug.Log($"else 1 index: " + index);
                    index = nextIndex;
                    //Debug.Log($"else 2 index: " + index);


                    string symbol2 = allSymbols[index];
                    //index = index + maxPlayerNumbersInTeam;
                    //nextIndex = nextIndex + maxPlayerNumbersInTeam;
                    finalSymbols[a] = symbol2;
                    //Debug.Log($"symbol2: " + symbol2);
                    //index = index + maxPlayerNumbersInTeam;

                    //Debug.Log($"else 3 index: " + index);
                    index = index + maxPlayerNumbersInTeam;

                    nextIndex++;
                    // Debug.Log($"nextIndex x: " + nextIndex);




                }


                //Debug.Log($" ------------------- ----------------------- ");




            }



            //Debug.Log($" ------------------------- 3 ------------------------- ");

            //for (int i = 0; i < finalSymbols.Length; i++)
            //{
            //    Debug.Log($"finalSymbols[{i}]: " + finalSymbols[i]);
            //}

            //Debug.Log($" ------------------- 2 ----------------------- ");


            return finalSymbols;
        }

        public static string[] CreateTableWithFinalSymbols(string[] allSymbols, int allPlayersNumber)
        {
            string[] finalSymbols = new string[allPlayersNumber];
            string symbolToRemove = "*";

            int allSymbolsLength = allSymbols.Length;
            int index = 0;

            //for (int i = 0; i < allSymbols.Length; i++)
            //{
            //    Debug.Log($"allSymbols[{i}]: " + allSymbols[i]);
            //}

            //Debug.Log($" ------------------- 1 ----------------------- ");

            for (int i = 0; i < allSymbolsLength; i++)
            {
                string symbol = allSymbols[i];
                //Debug.Log($"symbol: " + symbol);

                if (symbol.Equals(symbolToRemove))
                {

                }
                else
                {
                    finalSymbols[index] = allSymbols[i];
                    index++;
                }
            }
            //Debug.Log($" ------------------- 1 ----------------------- ");
            return finalSymbols;
        }

        public static string[] CreateTableWithDifferentQuantitiesForPlayersMoves(List<string[]> teamsSymbols)
        {

            int teamsNumbers = teamsSymbols.Count;

            int maxPlayerNumbersInTeam = GetBiggestPlayerNumbersInTeam(teamsSymbols);

            int allPlayersNumber = GetPlayersNumber(teamsSymbols);
            int maxLength = teamsNumbers * maxPlayerNumbersInTeam;

            //string[] allSymbols = new string[maxLength];
            string[] allSymbols = CreateTableWithAllSymbols(teamsSymbols, maxPlayerNumbersInTeam);
            //Debug.Log(" -- 1 -- ");
            string[] allSymbolsForCorrectPlayersMove = CreateTableWithAllSymbolsForCorrectPlayersMove(allSymbols, maxPlayerNumbersInTeam);


            //for (int i = 0; i < allSymbolsForCorrectPlayersMove.Length; i++)
            //{
            //    Debug.Log($"allSymbolsForCorrectPlayersMove[{i}]: " + allSymbolsForCorrectPlayersMove[i]);
            //}





            //Debug.Log(" -- 2 -- ");
            string[] finalSymbols = CreateTableWithFinalSymbols(allSymbolsForCorrectPlayersMove, allPlayersNumber);

            //int index = 0;

            //string symbolToRemove = "-- * --";

            //for (int l = 0; l < teamsNumbers; l++)
            //{
            //    string[] teamSymbols = teamsSymbols[l];
            //    int playersNumberInTeam = teamSymbols.Length;

            //    for (int w = 0; w < maxPlayerNumbersInTeam; w++)
            //    {
            //        if (w < playersNumberInTeam)
            //        {
            //            string symbol = teamSymbols[w];
            //            allSymbols[index] = symbol;

            //        }
            //        else
            //        {
            //            allSymbols[index] = symbolToRemove;

            //        }
            //        index++;
            //    }


            //}


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
                    {
                        newTable[j] = teamSymbols[j];
                    }
                    else
                    {
                        newTable[j] = staticSymbol;
                    }
                }

                //for (int z = 0; z < newTable.Length; z++)
                //{
                //    Debug.Log($"newTable[{z}]: " + newTable[z]);
                //}

                //Debug.Log("----------------------------------------------------");

                newTeamsSymbols.Insert(i, newTable);

            }






            return newTeamsSymbols;


        }

        // to do 

        public static string[] GetSymbolsToCompare(List<string[]> teamsSymbols, string[] previousSymbols, int[] playersNumberInTeams, int indexForSymbols)
        {
            string staticSymbol = "*";
            //string symbolsToCompare = "";
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




            for (int z = 0; z < newSymbols.Length; z++)
            {
                Debug.Log($"newSymbols[{z}]: " + newSymbols[z]);
            }

            Debug.Log("----------------------------------------------------");








            //string[] previousSymbols = new string[teamsNumbers];    
            //// table with prevoius
            //for (int i = 0; i < teamsNumbers; i++)
            //{
            //    string[] teamSymbols = teamsSymbols[i];
            //    int symbolsNumbers = teamSymbols.Length;

            //    for (int x = 0; x < teamsNumbers; x++)
            //    {
            //        //if (x < indexForSymbols)
            //        //{
            //        //    string symbol = teamSymbols[x];

            //        //    if (symbol != staticSymbol)
            //        //    {
            //        //        previousSymbols[i] = symbol;
            //        //    }
            //        //}

            //        if (x < symbolsNumbers)
            //        {


            //            if (x < indexForSymbols)
            //            {

            //                string symbol = teamSymbols[x];

            //                if (symbol != staticSymbol)
            //                {
            //                    previousSymbols[i] = symbol;
            //                }
            //            }

            //        }







            //    }

            //}



            //for (int z = 0; z < previousSymbols.Length; z++)
            //{
            //    Debug.Log($"previousSymbols[{z}]: " + previousSymbols[z]);
            //}

            //Debug.Log("----------------------------------------------------");


            // table for new string to compare 




            //string symbolsToCompare = "";


            // Debug.Log("symbolsToCompare: " + symbolsToCompare);

            return newSymbols;
        }


        public static string[] CreateTableWithTheSameQuantitiesForPlayersMoves(List<string[]> teamsSymbols)
        {
            int teamsNumbers = teamsSymbols.Count;

            //string[] firstTeamsSymbols = GetFirstPlayersSymbolFromTeams(teamsSymbols);

            //string firstSymbols = GetSymbolsAsOneString(firstTeamsSymbols);


            int[] playersNumberInTeams = GetPlayersNumbersForEachTeam(teamsSymbols);

            List<string[]> symbols = CreateTeablesWithTheSameLenght(teamsSymbols);

            bool isFisrtSymbolsAsSameAsLastOne = false;

            int index = 1;
            int index33 = 0;

            

            string[] previousSymbols = GetFirstPlayersSymbolFromTeams(teamsSymbols);

            string firstSymbols = GetSymbolsAsOneString(previousSymbols);

            string playersSymbols = firstSymbols;

            string finalListWithSymbols = firstSymbols;
            while (isFisrtSymbolsAsSameAsLastOne == false)
            //while (index33 < 3)
            {





                string[] symbolsToCompare = GetSymbolsToCompare(symbols, previousSymbols, playersNumberInTeams, index);

                string symbolsToCompareOneString = GetSymbolsAsOneString(symbolsToCompare);

                isFisrtSymbolsAsSameAsLastOne = IsFisrtSymbolsAsTheSameAsLastOne(playersSymbols, symbolsToCompareOneString);

                //playersSymbols = symbolsToCompareOneString;

                if (isFisrtSymbolsAsSameAsLastOne == false)
                {
                    finalListWithSymbols = finalListWithSymbols + symbolsToCompareOneString;
                    Debug.Log(" finalListWithSymbols: " + finalListWithSymbols);
                }

                index33++;
                index++;

                if (index > teamsNumbers)
                {
                    index = 0;
                }
            }




            //int maxPlayerNumbersInTeam = GetBiggestPlayerNumbersInTeam(teamsSymbols);

            //int allPlayersNumber = GetPlayersNumber(teamsSymbols);

            //int maxLength = teamsNumbers * maxPlayerNumbersInTeam;

            //string[] allSymbols = CreateTableWithAllSymbols(teamsSymbols, maxPlayerNumbersInTeam);

            //string[] allSymbolsForCorrectPlayersMove = CreateTableWithAllSymbolsForCorrectPlayersMove(allSymbols, maxPlayerNumbersInTeam);

            //string[] finalSymbols = CreateTableWithFinalSymbols(allSymbolsForCorrectPlayersMove, allPlayersNumber);

            int newSymbolLength = finalListWithSymbols.Length;

            string[] finalSymbols = new string[newSymbolLength];

            for (int i = 0; i < newSymbolLength; i++)
            {
                string character = finalListWithSymbols.Substring(i, 1);
                finalSymbols[i] = character;
            }

            return finalSymbols;

        }

    }
}
