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

        public static string[] GetFirstSymbolsToCompare(List<string[]> teamsSymbols, string[] previousSymbols, int[] playersNumberInTeams, int indexForSymbols)
        {
           // Debug.Log($" ------------------------ GetSymbolsToCompare ------------------------------------ " );
            int teamsNumbers = teamsSymbols.Count;


            for (int i = 0; i < previousSymbols.Length; i++)
            {
                //string[] teamSymbols = teamsSymbols[i];
               // Debug.Log($"previousSymbols {i} : " + previousSymbols[i]);
            }

            //Debug.Log($" --------------------------------------- ");
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
                    //Debug.Log($"1 newSymbols: " + symbol);
                }
                else
                {
                    newSymbols[i] = previousSymbols[i];
                    //Debug.Log($"2 newSymbols {i} : " + previousSymbols[i]);
                    //int index = i + 1;
                    //newSymbols[i] = previousSymbols[index];
                    //Debug.Log($"newSymbols {i} : " + previousSymbols[index]);

                }
            }

            //Debug.Log(" -------- GetSymbolsToCompare -------  ");

            //for (int j = 0; j < newSymbols.Length; j++)
            //{
            //    Debug.Log($"newSymbols {j} : " + newSymbols[j]);
            //}

            //Debug.Log(" ---------------  ");

            //Debug.Log($" ------------------------ GetSymbolsToCompare ------------------------------------ ");
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
            //Dictionary<string[]> teamsOldOrder = new Dictionary<int, string[]>();
            //Dictionary< string[]> teamsOldOrder222 = new Dictionary<int, string[]>();

            //Dictionary<int, int> teamsOldOrder = new Dictionary<int, int>();

            List<string[]> teamsNewOrder = new List<string[]>();


            //Debug.Log(" ----------------------- 1111 NEW ORDER FOR TEAMS -----------------------------------------");
            int teamsNumber = teamsSymbols.Count;
            //int[] numbers = new int[teamsNumber];
            //Debug.Log("teamsNumber: " + teamsNumber);

            //for (int i = 0; i < teamsNumber; i++)
            //{

            //    string[] team = teamsSymbols[i];
            //    int playersNumber = team.Length;
            //    numbers[i] = playersNumber;
            //    string number = CommonMethods.ConverIntToString(playersNumber);
            //    teamsOldOrder.Add(playersNumber, team);
            //}


            //var newOrder = numbers.OrderBy(x => x);
            //var newOrder = teamsOldOrder.OrderByDescending(x => x);

            // teamsOldOrder.OrderByDescending(x => x).ToDictionary(a => a.Key, b => b.Value);
            //teamsOldOrder.OrderByDescending(keySelector: x => x.Key).ToDictionary(keySelector: a => a.Key, elementSelector: b => b.Value);
            //teamsOldOrder = teamsOldOrder.OrderByDescending(keySelector: x => x.Value).ToDictionary(keySelector: a => a.Key, elementSelector: b => b.Value);
            //var teamsOldOrder123 = teamsOldOrder.OrderByDescending(x => x.Value.Length);

            //var teamsOldOrder123 = teamsSymbols.OrderByDescending(x => x.Length);
            //var teamsOldOrder123 = teamsSymbols.OrderByDescending(x => x.Length);
            var teamsOldOrder123 = teamsSymbols.OrderBy(x => x.Length);

            //for (int i = 0; i < teamsNumber; i++)
            //{
            //    string[] team = teamsOldOrder123[i];
            //    Debug.Log("team: " + team);
            //    teamsNewOrder.Insert(i, team);
            //}

            //Debug.Log(" ----------------------- 1111 NEW ORDER FOR TEAMS -----------------------------------------");

            int index = 0;
            foreach (string[] value in teamsOldOrder123)
            {
                teamsNewOrder.Insert(index, value);
                index++;
            }

            //Debug.Log("------------------------ NEW ORDER -----------------------------------");
            //for (int i = 0; i < teamsNewOrder.Count; i++)
            //{
            //    Debug.Log("TEAM " + i);

            //    string[] team = teamsNewOrder[i];

            //    for (int j = 0; j < team.Length; j++)
            //    {
            //        string symbol = team[j];
            //        Debug.Log("symbol: " + symbol);
            //    }

            //    Debug.Log("-----------------------------------------------------------");
            //}
            //Debug.Log("--------------------------- NEW ORDER --------------------------------");
            //foreach (int value in newOrder)
            //{
            //for (int a = 0; a < teamsNumber; a++)
            //{
            //Debug.Log("a: " + a);
            //int number = numbers[a];
            //Debug.Log("number: " + numbers[a]);
            //Debug.Log("value: " + value);
            //Debug.Log("--------");

            //if (number == value)
            //{
            //    //Debug.Log("number: " + number);
            //    //Debug.Log("value: " + value);
            //    Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>  a v2: " + a);
            //    Debug.Log("number: " + number);
            //    Debug.Log("value: " + value);
            // string[] teamSymbols = teamsSymbols[a];
            //teams.Add(index, teamSymbols);
            //}
            // Debug.Log("-----------------------------------------------------------");
            // }


            // }

            //foreach (int value in newOrder)
            //{
            //    for (int a = 0; a < teamsNumber; a++)
            //    {
            //        Debug.Log("a: " + a);
            //        int number = numbers[a];
            //        Debug.Log("number: " + numbers[a]);
            //        Debug.Log("value: " + value);
            //        Debug.Log("--------");

            //        if (number == value)
            //        {
            //            //Debug.Log("number: " + number);
            //            //Debug.Log("value: " + value);
            //            Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>  a v2: " + a);
            //            Debug.Log("number: " + number);
            //            Debug.Log("value: " + value);
            //            string[] teamSymbols = teamsSymbols[a];
            //            teams.Insert(index, teamSymbols);
            //        }
            //        Debug.Log("-----------------------------------------------------------");
            //    }


            //}





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

            return teamsNewOrder;

        }


         public static int[] GetMaxIndexesForSetUpNextSymobls(int[] playersNumberInTeams)
         {
            int teamsNumbers = playersNumberInTeams.Length;
            int[] maxIndexes = new int[teamsNumbers];
            int maxIndexForTeam;

            for (int i = 0; i < teamsNumbers; i++)
            {
                //Debug.Log($"1  playersNumberInTeams[{i}]: " + playersNumberInTeams[i]);

                //int maxIndexForTeam = playersNumberInTeams[i] - 2;
                //int index = maxIndexForTeam - 1;

                if (playersNumberInTeams[i] > 2)
                {
                    maxIndexForTeam = playersNumberInTeams[i] - 2;
                }
                else
                {
                    maxIndexForTeam = 0;
                }

                //// for team = 1 player
                //if (maxIndexForTeam < 0)
                //    maxIndexForTeam = 0;

                //Debug.Log($"1 A table maxIndexes: " + maxIndexForTeam);

                maxIndexes[i] = maxIndexForTeam;
            }

            //for (int z = 0; z < maxIndexes.Length; z++)
            //{

            //    Debug.Log($"INDEX FOR LIST {z} : " + maxIndexes[z]);

            //}

            //maxIndexes = new int[]{ 0, 0, 2 };

            return maxIndexes;

         }


        public static string[] CreateTableWithTheSameQuantitiesForPlayersMoves(List<string[]> teamsSymbols)
        {
            int teamsNumbers = teamsSymbols.Count;
            //Debug.Log("teamsNumbers :" + teamsNumbers);




            List<string[]> teamsOrderByAscendingPlayerNumberInTeam = GetTeamsOrderByAscendingPlayerNumberInTeam(teamsSymbols);

            List<string[]> symbols = CreateTeablesWithTheSameLenght(teamsOrderByAscendingPlayerNumberInTeam);





            //----
            bool isFisrtSymbolsAsSameAsLastOne = false;

            int indexForSymbols = 1;
            //int indexToCompare = 1;

            string[] previousSymbols = GetFirstPlayersSymbolFromTeams(teamsOrderByAscendingPlayerNumberInTeam);

            string firstSymbols = GetSymbolsAsOneString(previousSymbols);

            string firstSymbolsToCompare = firstSymbols;

            string finalListWithSymbols = firstSymbols;

           // Debug.Log("11111111111 finalListWithSymbols: " + finalListWithSymbols);
            string[] currentsymbolsToCompare;

            // ----
            List<List<string[]>> symbolsToCompare = new List<List<string[]>>();


            int[] playersNumberInTeams = GetPlayersNumbersForEachTeam(teamsOrderByAscendingPlayerNumberInTeam);


            //for (int i = 0; i < playersNumberInTeams.Length; i++)
            //{

            //    Debug.Log($"team: {i}, plyers No: " + playersNumberInTeams[i]);
            //}


            int maxPlayersNumberInTeam = GetBiggestPlayerNumbersInTeam(teamsOrderByAscendingPlayerNumberInTeam);
            Debug.Log("START maxPlayersNumberInTeam: " + maxPlayersNumberInTeam);
            // GET STATIC INDEX FOR id FORM LIST
            int[] maxIndexsNextSymobls = GetMaxIndexesForSetUpNextSymobls(playersNumberInTeams);
            

            string[] nextSymbolsToCompare = GetFirstSymbolsToCompare(symbols, previousSymbols, playersNumberInTeams, indexForSymbols);

            //string[] previousSymbolsToGetSymbols = previousSymbols;
            //string[] waitSymbolsToGetSymbols = previousSymbols;
            //string[] newSymbolsToGetSymbols = nextSymbolsToCompare;


            string[] previousSymbolsToGetSymbols = previousSymbols;
            string[] waitSymbolsToGetSymbols = previousSymbols;
            string[] newSymbolsToGetSymbols = previousSymbols;

            //Debug.Log(" ---------------- START previousSymbolsToGetSymbols");
            
            //for (int z = 0; z < previousSymbolsToGetSymbols.Length; z++)
            //{

            //    Debug.Log($"previousSymbolsToGetSymbols {z} : " + previousSymbolsToGetSymbols[z]);

            //}

            //Debug.Log(" ---------------- START waitSymbolsToGetSymbols");

            //for (int z = 0; z < waitSymbolsToGetSymbols.Length; z++)
            //{

            //    Debug.Log($"waitSymbolsToGetSymbols {z} : " + waitSymbolsToGetSymbols[z]);

            //}

            //Debug.Log(" ---------------- START newSymbolsToGetSymbols");

            //for (int z = 0; z < waitSymbolsToGetSymbols.Length; z++)
            //{

            //    Debug.Log($"newSymbolsToGetSymbols {z} : " + newSymbolsToGetSymbols[z]);

            //}

            //Debug.Log(" ---------------- END start list");
            int indexForListWithPartialSymbols = 1;

            List<string[]> startListWithPartialSymbols = new List<string[]>();

            startListWithPartialSymbols.Insert(0, previousSymbolsToGetSymbols);
            startListWithPartialSymbols.Insert(1, waitSymbolsToGetSymbols);
            startListWithPartialSymbols.Insert(2, newSymbolsToGetSymbols);


            symbolsToCompare.Insert(0, startListWithPartialSymbols);

            currentsymbolsToCompare = nextSymbolsToCompare;





            int[] maxIndexesForTeamSymbols = GetMaxIndexesForTeamSymbols(teamsOrderByAscendingPlayerNumberInTeam);

            //for (int i = 0; i < maxIndexesForTeamSymbols.Length; i++)
            //{

            //    Debug.Log($"team: {i}, plyers No: " + maxIndexesForTeamSymbols[i]);
            //}

            int teamNumber = 0;
            int maxIndexForTeamSymbols = maxIndexesForTeamSymbols[teamNumber];


            int aAaaa = 1;
            while (isFisrtSymbolsAsSameAsLastOne == false)
            //while (aAaaa < 20)
            {


                symbolsToCompare = GetNextSymbolsToCompare(symbolsToCompare, symbols, indexForListWithPartialSymbols, indexForSymbols, maxIndexsNextSymobls, playersNumberInTeams);



               List<string[]> lastList = symbolsToCompare[indexForListWithPartialSymbols];
                //currentsymbolsToCompare = lastList[2];
                //if (indexForListWithPartialSymbols < 2)
                if (indexForListWithPartialSymbols < 1)
                {
                    
                    currentsymbolsToCompare = lastList[1]; //2
                    //Debug.Log("1 currentsymbolsToCompare" + currentsymbolsToCompare);

                    //Debug.Log(" ---------------- currentsymbolsToCompare");

                    for (int z = 0; z < currentsymbolsToCompare.Length; z++)
                    {

                        //Debug.Log($"1 currentsymbolsToCompare {z} : " + currentsymbolsToCompare[z]);

                    }

                    //Debug.Log(" ---------------- SWITCH NEXT waitNEW");

                }
                //else if (indexForListWithPartialSymbols == 2)
                //{
                //    currentsymbolsToCompare = lastList[1];
                //    Debug.Log("111111 B currentsymbolsToCompare");
                //}
                else
                {
                    currentsymbolsToCompare = lastList[2]; //1
                   // Debug.Log("2 currentsymbolsToCompare" + currentsymbolsToCompare);
                    //Debug.Log(" ---------------- currentsymbolsToCompare");

                    for (int z = 0; z < currentsymbolsToCompare.Length; z++)
                    {

                        //Debug.Log($"2 scurrentsymbolsToCompare {z} : " + currentsymbolsToCompare[z]);

                    }

                    //Debug.Log(" ---------------- SWITCH NEXT waitNEW");

                }



                indexForListWithPartialSymbols++;

                //string symbolsToCompareOneString = GetSymbolsAsOneString(symbolsToCompare);
                string symbolsToCompareOneString = GetSymbolsAsOneString(currentsymbolsToCompare);
                Debug.Log("3 symbolsToCompareOneString: " + symbolsToCompareOneString);

                isFisrtSymbolsAsSameAsLastOne = IsFisrtSymbolsAsTheSameAsLastOne(firstSymbolsToCompare, symbolsToCompareOneString);

                if (isFisrtSymbolsAsSameAsLastOne == false)
                {
                    finalListWithSymbols = finalListWithSymbols + symbolsToCompareOneString;
                    Debug.Log("2111111111 finalListWithSymbols: " + finalListWithSymbols);
                }
                //Debug.Log(" indexForSymbols: " + indexForSymbols);

                //if (indexForSymbols > 2)
                //{
                //previousSymbols = symbolsToCompare;
                //}

                // works
                /*
                indexForSymbols++;


                if (indexForSymbols > teamsNumbers + 1)
                {
                    indexForSymbols = 0;
                    int zzzzz = teamsNumbers + 1;
                    Debug.Log("B teamsNumbers: " + zzzzz);
                }
                */
                /*
                indexForSymbols++;

                //Debug.Log("A indexForSymbols: " + indexForSymbols);
                //Debug.Log("A maxIndexForTeamSymbols: " + maxIndexForTeamSymbols);

                if (indexForSymbols > maxIndexForTeamSymbols + 1)
                {
                    indexForSymbols = 0;
                    teamNumber++;
                    maxIndexForTeamSymbols = maxIndexesForTeamSymbols[teamNumber];

                    Debug.Log(">>>>>>>>> B indexForSymbols: " + indexForSymbols);
                    Debug.Log(">>>>>>>>> B teamNumber: " + teamNumber);

                }
                */

                indexForSymbols++;

                Debug.Log("A indexForSymbols: " + indexForSymbols);
                Debug.Log("A maxPlayersNumberInTeam: " + maxPlayersNumberInTeam);

                if (indexForSymbols > maxPlayersNumberInTeam)
                {
                    //Debug.Log("A indexForSymbols: " + indexForSymbols);
                    //Debug.Log("A maxIndexForTeamSymbols: " + maxIndexForTeamSymbols);
                    //indexForSymbols = 0;
                    //teamNumber++;
                    //maxIndexForTeamSymbols = maxIndexesForTeamSymbols[teamNumber];

                    //Debug.Log(">>>>>>>>> B indexForSymbols: " + indexForSymbols);
                    //Debug.Log(">>>>>>>>> B teamNumber: " + teamNumber);

                }




                Debug.Log(" ---------------- END WHILE -----------------------------------------------------------------");
                /// ???? 
                //if (teamNumber == teamsNumbers)
                //{
                //    teamNumber = 0;
                //}

                aAaaa++;



            }

           // Debug.Log("3 finalListWithSymbols: " + finalListWithSymbols);

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










        //public static string[] CreateTableWithTheSameQuantitiesForPlayersMoves_v1(List<string[]> teamsSymbols)
        //{
        //    int teamsNumbers = teamsSymbols.Count;
        //    //Debug.Log("teamsNumbers :" + teamsNumbers);

        //    int[] playersNumberInTeams = GetPlayersNumbersForEachTeam(teamsSymbols);

        //    //Debug.Log(" ----------- 1 CreateTableWithTheSameQuantitiesForPlayersMoves playersNumberInTeams --------------------");

        //    //for (int i = 0; i < playersNumberInTeams.Length; i++)
        //    //{
        //    //    Debug.Log($">>> playersNumberInTeams: {playersNumberInTeams[i]}");
        //    //}

        //    //Debug.Log(" ----------- 1 CreateTableWithTheSameQuantitiesForPlayersMoves playersNumberInTeams --------------------");

        //    List<string[]> teamsOrderByAscendingPlayerNumberInTeam = GetTeamsOrderByAscendingPlayerNumberInTeam(teamsSymbols);

        //    //List<string[]> symbols = CreateTeablesWithTheSameLenght(teamsSymbols);
        //    List<string[]> symbols = CreateTeablesWithTheSameLenght(teamsOrderByAscendingPlayerNumberInTeam);

        //    bool isFisrtSymbolsAsSameAsLastOne = false;

        //    int indexForSymbols = 1;
        //    int indexToCompare = 1;
        //    //int index = 0;

        //    //int maxPlayersNumberInTeam = 4;

        //    // string[] previousSymbols = GetFirstPlayersSymbolFromTeams(teamsSymbols);
        //    string[] previousSymbols = GetFirstPlayersSymbolFromTeams(teamsOrderByAscendingPlayerNumberInTeam);

        //    string firstSymbols = GetSymbolsAsOneString(previousSymbols);

        //    string firstSymbolsToCompare = firstSymbols;

        //    string finalListWithSymbols = firstSymbols;

        //    Debug.Log("1 finalListWithSymbols: " + finalListWithSymbols);
        //    string[] currentsymbolsToCompare;

        //    List<string[]> lastSymbolsToCompare = new List<string[]>();


        //    string[] nextSymbolsToCompare = GetSymbolsToCompare(symbols, previousSymbols, playersNumberInTeams, indexForSymbols);

        //    lastSymbolsToCompare.Insert(0, previousSymbols); // OW
        //    lastSymbolsToCompare.Insert(1, nextSymbolsToCompare); // XT

        //    currentsymbolsToCompare = lastSymbolsToCompare[1];


        //    int aAaaa = 1;
        //    //while (isFisrtSymbolsAsSameAsLastOne == false)
        //    while (aAaaa < 20)
        //    {
        //        //index++;
        //        //Debug.Log("1 IIIIII indexForSymbols: " + indexForSymbols);

        //        // new added
        //        //previousSymbols = symbolsToCompare;
        //        //symbolsToCompare = GetSymbolsToCompare(symbols, previousSymbols, playersNumberInTeams, indexForSymbols);

        //        //string[] nextSymbolsToCompare = GetSymbolsToCompare(symbols, previousSymbols, playersNumberInTeams, indexForSymbols);


        //        ////if (indexForSymbols == 1)
        //        if (indexToCompare == 1)
        //        {
        //            //Debug.Log("(\"------------------------------------------------ 1 indexToCompare: " + indexToCompare);
        //            lastSymbolsToCompare.Insert(0, previousSymbols); // OW
        //            lastSymbolsToCompare.Insert(1, nextSymbolsToCompare); // XT

        //            currentsymbolsToCompare = lastSymbolsToCompare[1];
        //        }
        //        //else if (indexForSymbols == 2)
        //        else
        //        if (indexToCompare == 2)
        //        {
        //            //Debug.Log("(\"------------------------------------------------ 2 indexToCompare: " + indexToCompare);

        //            nextSymbolsToCompare = GetSymbolsToCompare(symbols, previousSymbols, playersNumberInTeams, indexForSymbols);
        //            //lastSymbolsToCompare.Insert(0, previousSymbols); // OW
        //            //lastSymbolsToCompare.Insert(1, nextSymbolsToCompare); // OA
        //            lastSymbolsToCompare.Insert(0, nextSymbolsToCompare); // OW
        //            lastSymbolsToCompare.Insert(1, previousSymbols); // OA

        //            currentsymbolsToCompare = lastSymbolsToCompare[1];

        //        }
        //        else
        //        {
        //            // Debug.Log("(\"------------------------------------------------ 3 indexToCompare: " + indexToCompare);

        //            nextSymbolsToCompare = GetSymbolsToCompare(symbols, previousSymbols, playersNumberInTeams, indexForSymbols);
        //            previousSymbols = nextSymbolsToCompare;
        //            string[] symbolsToCompare = lastSymbolsToCompare[0];

        //            lastSymbolsToCompare.Insert(0, previousSymbols);
        //            lastSymbolsToCompare.Insert(1, symbolsToCompare);

        //            currentsymbolsToCompare = lastSymbolsToCompare[1];

        //        }

        //        indexToCompare++;




        //        //string symbolsToCompareOneString = GetSymbolsAsOneString(symbolsToCompare);
        //        string symbolsToCompareOneString = GetSymbolsAsOneString(currentsymbolsToCompare);
        //        Debug.Log("symbolsToCompareOneString: " + symbolsToCompareOneString);

        //        isFisrtSymbolsAsSameAsLastOne = IsFisrtSymbolsAsTheSameAsLastOne(firstSymbolsToCompare, symbolsToCompareOneString);

        //        if (isFisrtSymbolsAsSameAsLastOne == false)
        //        {
        //            finalListWithSymbols = finalListWithSymbols + symbolsToCompareOneString;
        //            Debug.Log("2 finalListWithSymbols: " + finalListWithSymbols);
        //        }
        //        //Debug.Log(" indexForSymbols: " + indexForSymbols);

        //        //if (indexForSymbols > 2)
        //        //{
        //        //previousSymbols = symbolsToCompare;
        //        //}

        //        indexForSymbols++;
        //        //Debug.Log("3 IIIIII indexForSymbols: " + indexForSymbols);


        //        if (indexForSymbols > teamsNumbers + 1)
        //        {
        //            indexForSymbols = 0;


        //        }
        //        aAaaa++;
        //        // new added

        //    }

        //    Debug.Log("3 finalListWithSymbols: " + finalListWithSymbols);

        //    int newSymbolLength = finalListWithSymbols.Length;

        //    string[] finalSymbols = new string[newSymbolLength];

        //    for (int i = 0; i < newSymbolLength; i++)
        //    {
        //        string character = finalListWithSymbols.Substring(i, 1);
        //        finalSymbols[i] = character;
        //    }

        //    //Debug.Log(" ----------- CreateTableWithTheSameQuantitiesForPlayersMoves --------------------");

        //    //for (int i = 0; i < finalSymbols.Length; i++)
        //    //{
        //    //    Debug.Log($">>> finalSymbols: {finalSymbols[i]}");
        //    //}

        //    //Debug.Log(" ----------- CreateTableWithTheSameQuantitiesForPlayersMoves --------------------");

        //    return finalSymbols;

        //}


        public static List<List<string[]>> GetNextSymbolsToCompare_v2(List<List<string[]>> symbolsToCompare, List<string[]> teamsSymbols, int indexForListWithPartialSymbols, int indexForSymbols, int[] maxIndexsNextSymobls, int[] playersNumberInTeams)
        {
           // Debug.Log($" ------------------------ GetNextSymbolsToCompare ------------------------------------ ");
            //Debug.Log($"indexForListWithPartialSymbols: " + indexForListWithPartialSymbols);
            //Debug.Log($"indexForSymbols: " + indexForSymbols);

            List<string[]> nextListWithPartialSymbols = new List<string[]>();
            int currentListMaxIndexSymbolsToCompare = symbolsToCompare.Count - 1;
            int teamsNumbers = teamsSymbols.Count;


            //Debug.Log($"teamsNumbers: " + teamsNumbers);

            //Debug.Log($" --------------------------------------- ");
            string[] newSymbols = new string[teamsNumbers];
            
            
            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamsSymbols[i];
                //int teamNumbers = teamSymbols.Length - 1;
                int teamNumbers = teamSymbols.Length;

                int playersNumberInTeam = playersNumberInTeams[i];
                //Debug.Log($"ELSE i: " + i);
                Debug.Log($"33_ indexForSymbols: " + indexForSymbols);
                Debug.Log($"33_ playersNumberInTeam: " + playersNumberInTeam);


                //Debug.Log($" --------------------------------------- ");

                

                //if (indexForSymbols < playersNumberInTeam)
                //{
                //    string symbol = teamSymbols[indexForSymbols];
                //    newSymbols[i] = symbol;
                //    Debug.Log($"34 newSymbols: " + symbol);
                //}

                if (indexForSymbols < playersNumberInTeam)
                {
                    string symbol = teamSymbols[indexForSymbols];
                    newSymbols[i] = symbol;
                    Debug.Log($"34 newSymbols: " + symbol);
                }
                else
                {
                    //-- index for list
                    int indexForTeamSymbolsList = maxIndexsNextSymobls[i];

                    int indexForPreviousSymbols = 0;

                    if (currentListMaxIndexSymbolsToCompare < 2)
                    {
                        indexForPreviousSymbols = 0;

                    }
                    //if (currentListMaxIndexSymbolsToCompare < 2)
                    //if (currentListMaxIndexSymbolsToCompare < indexForTeamSymbolsList)
                    //{
                    //    indexForPreviousSymbols = indexForTeamSymbolsList - 1;

                    //}
                    else
                    {

                        indexForPreviousSymbols = currentListMaxIndexSymbolsToCompare - indexForTeamSymbolsList;

                        Debug.Log($"1 currentListMaxIndexSymbolsToCompare: " + currentListMaxIndexSymbolsToCompare);
                        Debug.Log($"1 indexForTeamSymbolsList: " + indexForTeamSymbolsList);
                        Debug.Log($"1 indexForPreviousSymbols: " + indexForPreviousSymbols);

                        //if (currentListIndexSymbolsToCompare == indexForPreviousSymbols)
                        //{
                        //    indexForPreviousSymbols = currentListIndexSymbolsToCompare - indexForTeamSymbolsList - 1;
                        //}
                        //Debug.Log($"2 indexForPreviousSymbols: " + indexForPreviousSymbols);

                    }


                    //Debug.Log($"1 indexForPreviousSymbols: " + indexForPreviousSymbols);

                    List<string[]> listPreviousSymbols = symbolsToCompare[indexForPreviousSymbols];






                    //List<string[]> listPreviousSymbols = symbolsToCompare[indexForTeamSymbol];

                    string[] previousSymbols;


                    //if (currentListIndexSymbolsToCompare < 1)
                    //{

                    //    previousSymbols = listPreviousSymbols[1];

                    //}
                    //else
                    //{

                    //    previousSymbols = listPreviousSymbols[0];



                    //}

                    previousSymbols = listPreviousSymbols[1];


                    for (int z = 0; z < previousSymbols.Length; z++)
                    {
                        Debug.Log($"AND WHAT NOW? table previousSymbols {z} : " + previousSymbols[z]);
                    }

                    int indexForSymbol = i; //team number


                    newSymbols[i] = previousSymbols[indexForSymbol];

                    Debug.Log($"34 ELSE newSymbols[{1}] : " + newSymbols[i]);









                    Debug.Log($" --------------------------------------- ");
                    //int index = i + 1;
                    //newSymbols[i] = previousSymbols[index];
                    //Debug.Log($"newSymbols {i} : " + previousSymbols[index]);

                }
            }

            Debug.Log($" --------------------------------------- ");

            List<string[]> lastList = symbolsToCompare[currentListMaxIndexSymbolsToCompare];
            string[] oldPreviousSymbolsToGetSymbols = lastList[0];
            string[] oldWaitSymbolsToGetSymbols = lastList[1];
            string[] oldNewSymbolsToGetSymbols = lastList[2];


            //Debug.Log(" ---------------- NEXT oldPreviousSymbolsToGetSymbols");

            //for (int z = 0; z < oldPreviousSymbolsToGetSymbols.Length; z++)
            //{

            //    Debug.Log($"oldPreviousSymbolsToGetSymbols {z} : " + oldPreviousSymbolsToGetSymbols[z]);

            //}

            //Debug.Log(" ---------------- NEXT oldWaitSymbolsToGetSymbols");

            //for (int z = 0; z < oldWaitSymbolsToGetSymbols.Length; z++)
            //{

            //    Debug.Log($"oldWaitSymbolsToGetSymbols {z} : " + oldWaitSymbolsToGetSymbols[z]);

            //}


            //Debug.Log(" ---------------- NEXT oldNewSymbolsToGetSymbols");

            //for (int z = 0; z < oldNewSymbolsToGetSymbols.Length; z++)
            //{

            //    Debug.Log($"oldNewSymbolsToGetSymbols {z} : " + oldNewSymbolsToGetSymbols[z]);

            //}

            //Debug.Log(" ---------------- END start list");


            //Debug.Log(" ------------------------------------------------------------- NEW NEXT newSymbols 1");

            //for (int z = 0; z < newSymbols.Length; z++)
            //{

            //    Debug.Log($"newSymbols {z} : " + newSymbols[z]);

            //}

            //Debug.Log(" ------------------------------------------------------------- NEW NEXT newSymbols 2");


            //List<string[]> nextListWithPartialSymbols = new List<string[]>();




            // nextListWithPartialSymbols.Insert(0, waitSymbolsToGetSymbols2);
            nextListWithPartialSymbols.Insert(0, oldWaitSymbolsToGetSymbols);
            //nextListWithPartialSymbols.Insert(1, newSymbolsToGetSymbols);
            //Debug.Log("indexForListWithPartialSymbols: " + indexForListWithPartialSymbols);
            if (indexForListWithPartialSymbols == 1)
            {
                //Debug.Log(" Tuuuuuu -----------------------");
                
                //for (int z = 0; z < oldWaitSymbolsToGetSymbols.Length; z++)
                //{

                //    Debug.Log($"oldWaitSymbolsToGetSymbols {z} : " + oldWaitSymbolsToGetSymbols[z]);

                //}

                nextListWithPartialSymbols.Insert(1, oldWaitSymbolsToGetSymbols);
            }
            else
            {
                nextListWithPartialSymbols.Insert(1, oldNewSymbolsToGetSymbols);
            }


            //Debug.Log(" ------------------------------------------------------------- NEW NEXT newSymbols 2 ");

            //for (int z = 0; z < newSymbols.Length; z++)
            //{

            //    Debug.Log($"newSymbols {z} : " + newSymbols[z]);

            //}

            //Debug.Log(" ------------------------------------------------------------- NEW NEXT newSymbols 2");

            nextListWithPartialSymbols.Insert(2, newSymbols);

            //Debug.Log(" ---------------- SWITCH NEXT ----------------------------------------");



            string[] previousNEW = nextListWithPartialSymbols[0];
            string[] waitNEW = nextListWithPartialSymbols[1];
            string[] newNEW = nextListWithPartialSymbols[2];




            //Debug.Log(" ---------------- SWITCH NEXT previousNEW");

            //for (int z = 0; z < previousNEW.Length; z++)
            //{

            //    Debug.Log($"previousNEW {z} : " + previousNEW[z]);

            //}

            //Debug.Log(" ---------------- SWITCH NEXT waitNEW");

            //for (int z = 0; z < waitNEW.Length; z++)
            //{

            //    Debug.Log($"waitNEW {z} : " + waitNEW[z]);

            //}


            //Debug.Log(" ---------------- SWITCH NEXT newNEW");

            //for (int z = 0; z < newNEW.Length; z++)
            //{

            //    Debug.Log($"newNEW {z} : " + newNEW[z]);

            //}

            //Debug.Log(" ---------------- END start list");


//            Debug.Log(" ---------------- NEXT newSymbols");

            //for (int z = 0; z < newSymbols.Length; z++)
            //{

            //    Debug.Log($"newSymbols {z} : " + newSymbols[z]);

            //}

            //Debug.Log(" ---------------- END newSymbols");


            //nextListWithPartialSymbols.Insert(0, previousSymbolsToGetSymbols);
            //nextListWithPartialSymbols.Insert(1, waitSymbolsToGetSymbols);
            //nextListWithPartialSymbols.Insert(2, newSymbolsToGetSymbols);


            //List<List<string[]>> nextSymbolsToCompare = new List<List<string[]>>();
            //nextSymbolsToCompare = symbolsToCompare;
            symbolsToCompare.Insert(indexForListWithPartialSymbols, nextListWithPartialSymbols);


            //Debug.Log(" -------- GetSymbolsToCompare -------  ");

            //for (int j = 0; j < newSymbols.Length; j++)
            //{
            //    Debug.Log($"newSymbols {j} : " + newSymbols[j]);
            //}

            //Debug.Log(" ---------------  ");

           // Debug.Log($" ------------------------ GetNextSymbolsToCompare ------------------------------------ ");
            //return nextSymbolsToCompare;
            return symbolsToCompare;
        }



        public static List<List<string[]>> GetNextSymbolsToCompare(List<List<string[]>> symbolsToCompare, List<string[]> teamsSymbols, int indexForListWithPartialSymbols, int indexForSymbols, int[] maxIndexsNextSymobls, int[] playersNumberInTeams)
        {
            // Debug.Log($" ------------------------ GetNextSymbolsToCompare ------------------------------------ ");
            //Debug.Log($"indexForListWithPartialSymbols: " + indexForListWithPartialSymbols);
            //Debug.Log($"indexForSymbols: " + indexForSymbols);

            List<string[]> nextListWithPartialSymbols = new List<string[]>();
            int currentListMaxIndexSymbolsToCompare = symbolsToCompare.Count - 1;
            int teamsNumbers = teamsSymbols.Count;


            //Debug.Log($"teamsNumbers: " + teamsNumbers);

            //Debug.Log($" --------------------------------------- ");
            string[] newSymbols = new string[teamsNumbers];


            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamsSymbols[i];
                //int teamNumbers = teamSymbols.Length - 1;
                int teamNumbers = teamSymbols.Length;

                int playersNumberInTeam = playersNumberInTeams[i];
                //Debug.Log($"ELSE i: " + i);
                Debug.Log($"33_ indexForSymbols: " + indexForSymbols);
                Debug.Log($"33_ playersNumberInTeam: " + playersNumberInTeam);


                //Debug.Log($" --------------------------------------- ");



                //if (indexForSymbols < playersNumberInTeam)
                //{
                //    string symbol = teamSymbols[indexForSymbols];
                //    newSymbols[i] = symbol;
                //    Debug.Log($"34 newSymbols: " + symbol);
                //}

                if (indexForSymbols < playersNumberInTeam)
                {
                    string symbol = teamSymbols[indexForSymbols];
                    newSymbols[i] = symbol;
                    Debug.Log($"34 newSymbols: " + symbol);
                }
                else
                {
                    //-- index for list
                    int indexForTeamSymbolsList = maxIndexsNextSymobls[i];

                    int indexForPreviousSymbols = 0;

                    if (currentListMaxIndexSymbolsToCompare < 2)
                    {
                        indexForPreviousSymbols = 0;

                    }
                    //if (currentListMaxIndexSymbolsToCompare < 2)
                    //if (currentListMaxIndexSymbolsToCompare < indexForTeamSymbolsList)
                    //{
                    //    indexForPreviousSymbols = indexForTeamSymbolsList - 1;

                    //}
                    else
                    {

                        indexForPreviousSymbols = currentListMaxIndexSymbolsToCompare - indexForTeamSymbolsList;

                        Debug.Log($"1 currentListMaxIndexSymbolsToCompare: " + currentListMaxIndexSymbolsToCompare);
                        Debug.Log($"1 indexForTeamSymbolsList: " + indexForTeamSymbolsList);
                        Debug.Log($"1 indexForPreviousSymbols: " + indexForPreviousSymbols);

                        //if (currentListIndexSymbolsToCompare == indexForPreviousSymbols)
                        //{
                        //    indexForPreviousSymbols = currentListIndexSymbolsToCompare - indexForTeamSymbolsList - 1;
                        //}
                        //Debug.Log($"2 indexForPreviousSymbols: " + indexForPreviousSymbols);

                    }


                    //Debug.Log($"1 indexForPreviousSymbols: " + indexForPreviousSymbols);

                    List<string[]> listPreviousSymbols = symbolsToCompare[indexForPreviousSymbols];






                    //List<string[]> listPreviousSymbols = symbolsToCompare[indexForTeamSymbol];

                    string[] previousSymbols;


                    //if (currentListIndexSymbolsToCompare < 1)
                    //{

                    //    previousSymbols = listPreviousSymbols[1];

                    //}
                    //else
                    //{

                    //    previousSymbols = listPreviousSymbols[0];



                    //}

                    previousSymbols = listPreviousSymbols[1];


                    for (int z = 0; z < previousSymbols.Length; z++)
                    {
                        Debug.Log($"AND WHAT NOW? table previousSymbols {z} : " + previousSymbols[z]);
                    }

                    int indexForSymbol = i; //team number


                    newSymbols[i] = previousSymbols[indexForSymbol];

                    Debug.Log($"34 ELSE newSymbols[{1}] : " + newSymbols[i]);









                    Debug.Log($" --------------------------------------- ");
                    //int index = i + 1;
                    //newSymbols[i] = previousSymbols[index];
                    //Debug.Log($"newSymbols {i} : " + previousSymbols[index]);

                }
            }

            Debug.Log($" --------------------------------------- ");

            List<string[]> lastList = symbolsToCompare[currentListMaxIndexSymbolsToCompare];
            string[] oldPreviousSymbolsToGetSymbols = lastList[0];
            string[] oldWaitSymbolsToGetSymbols = lastList[1];
            string[] oldNewSymbolsToGetSymbols = lastList[2];


            //Debug.Log(" ---------------- NEXT oldPreviousSymbolsToGetSymbols");

            //for (int z = 0; z < oldPreviousSymbolsToGetSymbols.Length; z++)
            //{

            //    Debug.Log($"oldPreviousSymbolsToGetSymbols {z} : " + oldPreviousSymbolsToGetSymbols[z]);

            //}

            //Debug.Log(" ---------------- NEXT oldWaitSymbolsToGetSymbols");

            //for (int z = 0; z < oldWaitSymbolsToGetSymbols.Length; z++)
            //{

            //    Debug.Log($"oldWaitSymbolsToGetSymbols {z} : " + oldWaitSymbolsToGetSymbols[z]);

            //}


            //Debug.Log(" ---------------- NEXT oldNewSymbolsToGetSymbols");

            //for (int z = 0; z < oldNewSymbolsToGetSymbols.Length; z++)
            //{

            //    Debug.Log($"oldNewSymbolsToGetSymbols {z} : " + oldNewSymbolsToGetSymbols[z]);

            //}

            //Debug.Log(" ---------------- END start list");


            //Debug.Log(" ------------------------------------------------------------- NEW NEXT newSymbols 1");

            //for (int z = 0; z < newSymbols.Length; z++)
            //{

            //    Debug.Log($"newSymbols {z} : " + newSymbols[z]);

            //}

            //Debug.Log(" ------------------------------------------------------------- NEW NEXT newSymbols 2");


            //List<string[]> nextListWithPartialSymbols = new List<string[]>();




            // nextListWithPartialSymbols.Insert(0, waitSymbolsToGetSymbols2);
            nextListWithPartialSymbols.Insert(0, oldWaitSymbolsToGetSymbols);
            //nextListWithPartialSymbols.Insert(1, newSymbolsToGetSymbols);
            //Debug.Log("indexForListWithPartialSymbols: " + indexForListWithPartialSymbols);
            if (indexForListWithPartialSymbols == 1)
            {
                //Debug.Log(" Tuuuuuu -----------------------");

                //for (int z = 0; z < oldWaitSymbolsToGetSymbols.Length; z++)
                //{

                //    Debug.Log($"oldWaitSymbolsToGetSymbols {z} : " + oldWaitSymbolsToGetSymbols[z]);

                //}

                nextListWithPartialSymbols.Insert(1, oldWaitSymbolsToGetSymbols);
            }
            else
            {
                nextListWithPartialSymbols.Insert(1, oldNewSymbolsToGetSymbols);
            }


            //Debug.Log(" ------------------------------------------------------------- NEW NEXT newSymbols 2 ");

            //for (int z = 0; z < newSymbols.Length; z++)
            //{

            //    Debug.Log($"newSymbols {z} : " + newSymbols[z]);

            //}

            //Debug.Log(" ------------------------------------------------------------- NEW NEXT newSymbols 2");

            nextListWithPartialSymbols.Insert(2, newSymbols);

            //Debug.Log(" ---------------- SWITCH NEXT ----------------------------------------");



            string[] previousNEW = nextListWithPartialSymbols[0];
            string[] waitNEW = nextListWithPartialSymbols[1];
            string[] newNEW = nextListWithPartialSymbols[2];




            //Debug.Log(" ---------------- SWITCH NEXT previousNEW");

            //for (int z = 0; z < previousNEW.Length; z++)
            //{

            //    Debug.Log($"previousNEW {z} : " + previousNEW[z]);

            //}

            //Debug.Log(" ---------------- SWITCH NEXT waitNEW");

            //for (int z = 0; z < waitNEW.Length; z++)
            //{

            //    Debug.Log($"waitNEW {z} : " + waitNEW[z]);

            //}


            //Debug.Log(" ---------------- SWITCH NEXT newNEW");

            //for (int z = 0; z < newNEW.Length; z++)
            //{

            //    Debug.Log($"newNEW {z} : " + newNEW[z]);

            //}

            //Debug.Log(" ---------------- END start list");


            //            Debug.Log(" ---------------- NEXT newSymbols");

            //for (int z = 0; z < newSymbols.Length; z++)
            //{

            //    Debug.Log($"newSymbols {z} : " + newSymbols[z]);

            //}

            //Debug.Log(" ---------------- END newSymbols");


            //nextListWithPartialSymbols.Insert(0, previousSymbolsToGetSymbols);
            //nextListWithPartialSymbols.Insert(1, waitSymbolsToGetSymbols);
            //nextListWithPartialSymbols.Insert(2, newSymbolsToGetSymbols);


            //List<List<string[]>> nextSymbolsToCompare = new List<List<string[]>>();
            //nextSymbolsToCompare = symbolsToCompare;
            symbolsToCompare.Insert(indexForListWithPartialSymbols, nextListWithPartialSymbols);


            //Debug.Log(" -------- GetSymbolsToCompare -------  ");

            //for (int j = 0; j < newSymbols.Length; j++)
            //{
            //    Debug.Log($"newSymbols {j} : " + newSymbols[j]);
            //}

            //Debug.Log(" ---------------  ");

            // Debug.Log($" ------------------------ GetNextSymbolsToCompare ------------------------------------ ");
            //return nextSymbolsToCompare;
            return symbolsToCompare;
        }


    }
}
