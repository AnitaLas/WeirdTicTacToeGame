using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts
{
    internal class PlayGameSwitchPlayersSymbolsMethods
    {

        //public static List<string[]> GetNewDataForPlayersSymbols(string[] playersSymbols, List<float> gameChangeTimeConfiguration, List<string[]> teamGameSymbols)
        //{

        //    List<string[]> symbolsLists = new List<string[]>();

        //    symbolsLists = GetNewPlayersSymbolsForSwitch(playersSymbols, teamGameSymbols);

        //    return symbolsLists;

        //}

        public static string GetIndexesForSwitchAsString(int playersSymbols)
        {
            string numbers = "";

            //if (playersSymbols > 1)
            //{
            for (int i = 0; i < playersSymbols; i++)
            {
                numbers = numbers + i;
                //Debug.Log("numbers: " + numbers);
            }
            //Debug.Log(" -----------  ");

            //} else
            //{
            //    numbers = "1";
            //}


            return numbers;
        }

        public static string GetIndexesAsString(int playersSymbols)
        {
            string numbers = "";



            for (int i = 0; i < playersSymbols; i++)
            {
                numbers = numbers + i;
                //Debug.Log("numbers: " + numbers);
            }

            return numbers;
        }

        public static string GetStaicIndexesForSwitch()
        {
            string numbers = "10";
            return numbers;
        }

        public static int[] GetIndexesForSwitch(int playersSymbols, int maxSymbolsNumberForChange)
        {
            int[] indexes = new int[maxSymbolsNumberForChange];

            string allNumbers = GetIndexesAsString(playersSymbols);
            //Debug.Log("allNumbers: " + allNumbers);

            string numbers = allNumbers;
            //Debug.Log("numbers: " + numbers);

            int minNumber = 0;
            int maxNumber = playersSymbols;
            //Debug.Log("maxNumber: " + maxNumber);

            for (int i = 0; i < maxSymbolsNumberForChange; i++)
            {
                //Debug.Log("1 numbers: " + numbers);
                //Debug.Log("i: " + i);
                //Debug.Log("minNumber: " + minNumber);
                //Debug.Log("maxNumber: " + maxNumber);
                int randomIndexToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);

                //Debug.Log("randomIndexToChange: " + randomIndexToChange);

                string index = numbers.Substring(randomIndexToChange, 1);
                //Debug.Log($" index: " + index);
                int finaleIndex = CommonMethods.ConvertStringToInt(index);
                //Debug.Log($" finaleIndex: " + finaleIndex);
                indexes[i] = finaleIndex;


                maxNumber--;
                numbers = numbers.Remove(randomIndexToChange, 1);
                //Debug.Log("2 numbers: " + numbers);
                //Debug.Log("2 numbers: " + numbers.Remove(randomIndexToChange,1));
            }
            //Debug.Log(" -----------  ");

            //for (int i = 0; i < indexes.Length; i++)
            //{
            //    Debug.Log($" indexes[{i}]: " + indexes[i]);

            //}

            //Debug.Log(" -----------  ");

            //Debug.Log(" -----------  ");
            return indexes;
        }

        //public static List<string[]> GetSymoblsForSwitch(List<string[]> teamGameSymbols, int maxSymbolsNumberForChange)
        public static ArrayList GetSymoblsForSwitch(List<string[]> teamGameSymbols)
        {
            ArrayList dataForSwitch = new ArrayList();

            List<string[]> oldSymbolsForSwitch = new List<string[]>();
            List<int[]> randomIndexesForSwitch = new List<int[]>();

            // ?????????????????????????????????????????????????????
            // ADD change for random, works = 2
            int maxSymbolsNumberForSwitch = PlayGameChangePlayersSymbolsMethods.GetMinPlayersNumberForTeam(teamGameSymbols);
            Debug.Log("1 maxSymbolsNumberForSwitch: " + maxSymbolsNumberForSwitch);

            int minSymbolsNumberForSwitch = 1;

            if (maxSymbolsNumberForSwitch > minSymbolsNumberForSwitch)
            {
                maxSymbolsNumberForSwitch = CommonMethods.ChooseRandomNumber(minSymbolsNumberForSwitch, maxSymbolsNumberForSwitch);
            }
            else
            {
                maxSymbolsNumberForSwitch = minSymbolsNumberForSwitch;
            }

            //maxSymbolsNumberForSwitch = 2;
            Debug.Log("2 maxSymbolsNumberForSwitch: " + maxSymbolsNumberForSwitch);

            int teamsNumbers = teamGameSymbols.Count;
            //Debug.Log(" teamsNumbers: " + teamsNumbers);
            //Debug.Log($" --------------------------------------- ");

            int[] indexesForSwitch;
            int numbersOfSymbolsToSwitch;

            for (int t = 0; t < teamsNumbers; t++)
            {

                string[] teamSymbols = teamGameSymbols[t];
                int playersSymbols = teamSymbols.Length;


                indexesForSwitch = GetIndexesForSwitch(playersSymbols, maxSymbolsNumberForSwitch);
                randomIndexesForSwitch.Insert(t, indexesForSwitch);
                numbersOfSymbolsToSwitch = indexesForSwitch.Length;

                string[] symbolsToSwitch = new string[maxSymbolsNumberForSwitch];

                for (int a = 0; a < numbersOfSymbolsToSwitch; a++)
                {

                    int indexToSwitch = indexesForSwitch[a];
                    string symbol = teamSymbols[indexToSwitch];
                    symbolsToSwitch[a] = symbol;

                }

                for (int i = 0; i < indexesForSwitch.Length; i++)
                {
                    Debug.Log($"indexesForSwitch[{i}] :" + indexesForSwitch[i]);
                }
                Debug.Log($" --------------------------------------- ");

                oldSymbolsForSwitch.Insert(0, symbolsToSwitch);
            }


            dataForSwitch.Insert(0, randomIndexesForSwitch);
            dataForSwitch.Insert(1, oldSymbolsForSwitch);
            dataForSwitch.Insert(2, randomIndexesForSwitch);


            return dataForSwitch;
        }


        //// to fix, it is too risky that old team = new team
        //// do not remove xD - some configuration in future, far future xD
        //public static List<string[]> SetUpSymbolsForSwitchV1(List<string[]> symbolsForSwitch)
        //{
        //    List<string[]> switchedSymbols = new List<string[]>();
        //    int playersSymbols = symbolsForSwitch.Count;

        //    int[] indexes = new int[playersSymbols];

        //    //string allNumbers = GetIndexesForSwitchAsString(playersSymbols);
        //    //string numbers = GetIndexesForSwitchAsString(teamsNumbers);
        //    // Debug.Log(" allNumbers: " + allNumbers);
        //    //string numbers = allNumbers;

        //    int minIndex = 0;
        //    int maxIndex = playersSymbols - 1;

        //    int startIndex = CommonMethods.ChooseRandomNumber(minIndex, maxIndex);

        //    bool isStartIndexEven = CommonMethods.IsNumberEven(startIndex);


        //    version 1 to 3
        //    int minNumber = 1;
        //    int maxNumber = teamsNumbers - 1;
        //    int randomIndexToChange = 0;

        //    if (minNumber == maxNumber)
        //    {
        //        indexes[0] = 1; // string "1" -> length = 1;
        //    }
        //    else
        //    {
        //        //for (int i = 0; i < teamsNumbers; i++)
        //        for (int i = 1; i < teamsNumbers; i++)
        //        {
        //            //Debug.Log("1 numbers: " + numbers);
        //            //Debug.Log("i: " + i);
        //            //Debug.Log("minNumber: " + minNumber);
        //            //Debug.Log("maxNumber: " + maxNumber);

        //            if (i == teamsNumbers - 1)
        //            {
        //                randomIndexToChange = 0;
        //            }
        //            else
        //            {
        //                randomIndexToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
        //            }
        //            //int randomIndexToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
        //            //Debug.Log("randomIndexToChange: " + randomIndexToChange);

        //            string index = numbers.Substring(randomIndexToChange, 1);
        //            //Debug.Log("INDEX: " + index);


        //            int finaleIndex = CommonMethods.ConvertStringToInt(index);
        //            int newIndex = i - 1;
        //            indexes[newIndex] = finaleIndex;

        //            maxNumber--;
        //            numbers = numbers.Remove(randomIndexToChange, 1);
        //        }

        //    }




        //    Debug.Log(" final ---------------" );
        //    for (int i = 0; i < playersSymbols; i++)
        //    {
        //        int finalIndex = indexes[i];

        //        Debug.Log("index: " + finalIndex);
        //        string[] team = symbolsForSwitch[finalIndex];

        //        switchedSymbols.Insert(i, team);

        //    }

        //    //Debug.Log(" SS to switch ----------------------------------------------- ");

        //    //for (int i = 0; i < symbolsForSwitch.Count; i++)
        //    //{
        //    //    string[] team = symbolsForSwitch[i];
        //    //    int lenght1 = team.Length;

        //    //    Debug.Log("team: " + i);

        //    //    for (int j = 0; j < lenght1; j++)
        //    //    {
        //    //        Debug.Log($"symbol team[{j}]: " + team[j]);
        //    //    }

        //    //}

        //    //Debug.Log("SS switchedSymbols: " + switchedSymbols);

        //    //for (int i = 0; i < switchedSymbols.Count; i++)
        //    //{
        //    //    string[] team = switchedSymbols[i];
        //    //    int lenght1 = team.Length;

        //    //    Debug.Log("team: " + i);

        //    //    for (int j = 0; j < lenght1; j++)
        //    //    {
        //    //        Debug.Log($"symbols team[{j}]: " + team[j]);
        //    //    }

        //    //}
        //    //Debug.Log(" ----------------------------------------------- ");

        //    return switchedSymbols;

        //}

        //public static List<List<string[]>> SetUpSymbolsForSwitch(List<string[]> symbolsForSwitch)
        //{
        //    int teamsNumbers = symbolsForSwitch.Count;
        //    string[] teamSymbols = symbolsForSwitch[0];
        //    int numbersOfSymbols = teamSymbols.Length;
        //    int numberOfSymbolsToSwitch = teamsNumbers * numbersOfSymbols;

        //    string[] oldSymbolsForSwitch = new string[numberOfSymbolsToSwitch];

        //    int index = 0;

        //    for (int i = 0; i < teamsNumbers; i++)
        //    {
        //        string[] team = symbolsForSwitch[0];
        //        int playersNumbers = teamSymbols.Length;

        //        for (int a = 0; a < teamsNumbers; a++)
        //        {
        //            string symbols = teamSymbols[a];
        //            oldSymbolsForSwitch[index] = symbols;
        //            index++;
        //        }


        //    }

        //    return oldSymbolsForSwitch;

        //}
        //public static int[] CreateTableWithOldIndexes(int teamsNumbers)
        //{
        //    int[] oldIndexes = new int[teamsNumbers];

        //    for (int i = 0; i < teamsNumbers; i++)
        //    {
        //        oldIndexes[i] = i;
        //    }

        //    return oldIndexes;
        //}

        public static int[] GetIndexesForRightMove(int teamsNumbers)
        {
            //int[] oldIndexes = CreateTableWithOldIndexes(teamsNumbers);
            int[] newIndexes = new int[teamsNumbers];
            //int index = startIndex;
            newIndexes[0] = teamsNumbers - 1;

            for (int i = 1; i < teamsNumbers; i++)
            {
                int index = i - 1;
                newIndexes[i] = index;
                //int index = oldIndexes[i];
                //int indexForSwitch = index + 1;

                //if (indexForSwitch < teamsNumbers)
                //{

                //    newIndexes[i] = indexForSwitch;
                //}
                //else if (indexForSwitch == teamsNumbers)
                //{
                //    newIndexes[i] = 0;
                //}



            }




            //int[] indexes = new int[teamsNumbers];
            //int index = startIndex;


            //if (teamsNumbers == 2)
            //{
            //    indexes[0] = 1;
            //    indexes[1] = 0;
            //}
            //else
            //{
            //    for (int i = 0; i < teamsNumbers; i++)
            //    {
            //        indexes[i] = index;

            //        if (index < teamsNumbers - 1)
            //        {

            //            index++;

            //        }
            //        else
            //        {
            //            index = 0;
            //            //indexes[i] = index;
            //            //index++;
            //        }
            //    }

            //}
            for (int i = 0; i < newIndexes.Length; i++)
            {
                Debug.Log("444 indexes[i]: " + newIndexes[i]);
            }

            return newIndexes;
        }




        public static int[] GetIndexesForLeftMove(int teamsNumbers)
        {
            //int[] oldIndexes = CreateTableWithOldIndexes(teamsNumbers);
            int[] newIndexes = new int[teamsNumbers];
            //int index = startIndex;
            int lastIndex = teamsNumbers - 1;
            newIndexes[lastIndex] = 0;

            for (int i = 0; i < teamsNumbers - 1; i++)
            {
                int index = i + 1;
                newIndexes[i] = index;
            }


                //for (int i = 0; i < teamsNumbers; i++)
                //{
                //    int index = oldIndexes[i];
                //    int indexForSwitch = index + 1;

                //    if (indexForSwitch < teamsNumbers)
                //    {

                //        newIndexes[i] = indexForSwitch;
                //    }
                //    else if (indexForSwitch == teamsNumbers)
                //    {
                //        newIndexes[i] = 0;
                //    }



                //}






                //indexes[0] = startIndex;

                //if (teamsNumbers == 2)
                //{
                //    indexes[0] = 1;
                //    indexes[1] = 0;
                //}
                //else
                //{
                //    for (int i = 0; i < teamsNumbers; i++)
                //    {
                //        Debug.Log("333 A index: " + index);
                //        indexes[i] = index;
                //        Debug.Log("333 B index: " + index);


                //        index--;

                //        if (index > 0)
                //        {
                //            index--;
                //            indexes[i] = index;

                //            if (index == 1)
                //            {
                //                indexes[i] = index;
                //                index--;
                //            }
                //            else
                //            if (index == teamsNumbers - 1)
                //            {
                //                index = 0;
                //                indexes[i] = index;
                //            }
                //            else
                //            {
                //                index--;
                //                indexes[i] = index;
                //                index--;

                //            }

                //        }
                //        else if (index == 0)
                //        {
                //            index = teamsNumbers - 1;
                //            indexes[i] = index;
                //        }
                //        else
                //        {
                //            index = teamsNumbers - 1;
                //            index = teamsNumbers - 1;
                //            indexes[i] = index;
                //            index--;
                //        }
                //        //indexes[i] = index;
                //        //index--;
                //    }

                //    for (int i = 0; i < teamsNumbers; i++)
                //    {
                //        Debug.Log("333 A index: " + index);
                //        indexes[i] = index;
                //        Debug.Log("333 B index: " + index);
                //        if (index > 0)
                //        {

                //            index--;
                //        }
                //        else
                //        {
                //            index = teamsNumbers - 1;

                //        }
                //    }
                //}

                for (int i = 0; i < newIndexes.Length; i++)
            {
                Debug.Log("333 indexes[i]: " + newIndexes[i]);
            }

            return newIndexes;
        }

        public static List<string[]> SetUpSymbolsForSwitch(List<string[]> symbolsForSwitch)
        {
            List<string[]> switchedSymbols = new List<string[]>();
            int teamsNumbers = symbolsForSwitch.Count;

            int[] indexes; // = new int[playersSymbols];
            //int minIndex = 0;
            //int minIndex = 1;
            //int maxIndex = teamsNumbers - 1;


            // ???????????????????????????????????????? uncom
            //int startIndex = CommonMethods.ChooseRandomNumber(minIndex, maxIndex);
            //int startIndex = 3;
            int startIndex = 0;
            //Debug.Log("startIndex: " + startIndex);

            bool isStartIndexEven = CommonMethods.IsNumberEven(startIndex);
            Debug.Log("1234 isStartIndexEven: " + isStartIndexEven);

            //int index = startIndex;


            if (isStartIndexEven == true)
            {
                indexes = GetIndexesForRightMove(teamsNumbers);
            }
            else
            {
                indexes = GetIndexesForLeftMove(teamsNumbers);
            }


            //Debug.Log(" final ---------------");
            for (int i = 0; i < teamsNumbers; i++)
            {
                int finalIndex = indexes[i];

                Debug.Log("1234 index: " + finalIndex);
                string[] team = symbolsForSwitch[finalIndex];

                switchedSymbols.Insert(i, team);

            }
            //Debug.Log(" end of set up ---------------");
            //Debug.Log(" end of set up ---------------");

            Debug.Log(" SS to switch ----------------------------------------------- ");

            for (int i = 0; i < symbolsForSwitch.Count; i++)
            {
                string[] team = symbolsForSwitch[i];
                int lenght1 = team.Length;

                Debug.Log("team: " + i);

                for (int j = 0; j < lenght1; j++)
                {
                    Debug.Log($"symbol team[{j}]: " + team[j]);
                }

            }

            Debug.Log("SS switchedSymbols: " + switchedSymbols);

            for (int i = 0; i < switchedSymbols.Count; i++)
            {
                string[] team = switchedSymbols[i];
                int lenght1 = team.Length;

                Debug.Log("team: " + i);

                for (int j = 0; j < lenght1; j++)
                {
                    Debug.Log($"symbols team[{j}]: " + team[j]);
                }

            }
            Debug.Log(" ----------------------------------------------- ");

            return switchedSymbols;

        }

        public static ArrayList GetPlayersSymbolsForSwitch(List<string[]> teamGameSymbols)
        {
            //List<List<string[]>> symbolsLists = new List<List<string[]>>();
            ArrayList allDataForSwitch = new ArrayList();
            // "old symbols"
            //List<string[]> symbolsForSwitch = GetSymoblsForSwitch(teamGameSymbols);
            ArrayList dataForSwitch = GetSymoblsForSwitch(teamGameSymbols);
            List<string[]> symbolsForSwitch = (List<string[]>)dataForSwitch[1];
            List<int[]> randomIndexesForSwitch = (List<int[]>)dataForSwitch[0];

            // "new symbols"
            List<string[]> switchedSymbols = SetUpSymbolsForSwitch(symbolsForSwitch);


            //Debug.Log(" SYMBOLS to switch ----------------------------------------------- ");

            //for (int i = 0; i < symbolsForSwitch.Count; i++)
            //{
            //    string[] team = symbolsForSwitch[i];
            //    int lenght1 = team.Length;

            //    Debug.Log("team: " + i);

            //    for (int j = 0; j < lenght1; j++)
            //    {
            //        Debug.Log($"switchedSymbols, symbol team[{j}]: " + team[j]);
            //    }

            //}

            //Debug.Log("SYMBOLS switchedSymbols ------------------------------------------------- ");

            //for (int i = 0; i < switchedSymbols.Count; i++)
            //{
            //    string[] team = switchedSymbols[i];
            //    int lenght1 = team.Length;

            //    Debug.Log("team: " + i);

            //    for (int j = 0; j < lenght1; j++)
            //    {
            //        Debug.Log($"switchedSymbols, symbols team[{j}]: " + team[j]);
            //    }

            //}
            //Debug.Log(" ----------------------------------------------- ");
            allDataForSwitch.Insert(0, symbolsForSwitch);
            allDataForSwitch.Insert(1, switchedSymbols);
            allDataForSwitch.Insert(2, randomIndexesForSwitch);

            return allDataForSwitch;

        }

        //--------------------------------------------------------------------------------------------------------

        public static GameObject[,,] ChangeDataForOldSymbolsForSwitch(GameObject[,,] gameBoard, List<string[]> oldSymbols)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);
            // int numbersOldSymbols = oldSymbols.Length;

            int teamsNumbers = oldSymbols.Count;

            string staticText = "old"; // old

            for (int a = 0; a < teamsNumbers; a++)
            {

                string[] team = oldSymbols[a];
                int playersNumners = team.Length;

                for (int l = 0; l < playersNumners; l++)
                {

                    string oldSymbol = team[l];

                    for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                    {
                        for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                        {
                            for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                            {
                                GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                                string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

                                // for (int i = 0; i < numbersOldSymbols; i++)
                                // {
                                //string oldSymbol = oldSymbols[i];

                                if (currentCubePlaySymbol == oldSymbol)
                                {
                                    string newSymbol = currentCubePlaySymbol + staticText;
                                    CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                                }
                            }
                        }
                    }
                }


            }

            
            //Debug.Log(" o start ------------------------------------------------- ");

            //for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            //{
            //    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
            //    {
            //        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
            //        {
            //            GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
            //            string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

            //            Debug.Log($"indexDepth: {indexDepth}, indexColumn: {indexColumn}, indexRow: {indexRow} symbol: {currentCubePlaySymbol}");


            //        }
            //    }
            //}

            //Debug.Log(" o end ------------------------------------------------- ");






            return gameBoard;

        }

        public static void SwitchOldSymbolsForNew(GameObject[,,] gameBoard, List<string[]> oldSymbols, List<string[]> symbolsForSwitch)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);
            int teamsNumbers = oldSymbols.Count;

            //Debug.Log(" SwitchOldSymbolsForNew start ------------------------------------------------- ");
            for (int i = 0; i < teamsNumbers; i++)
            {

                string[] teamOldSymbols = oldSymbols[i];
                string[] teamNewSymbols = symbolsForSwitch[i];

                int playersNumbers = teamOldSymbols.Length;

                //for (int p = 0; p < playersNumbers; p++)
                //{

                    


                for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                        {
                                GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                                string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);
                            //Debug.Log("currentCubePlaySymbol: " + currentCubePlaySymbol);

                            for (int p = 0; p < playersNumbers; p++)
                            {
                                string oldSymbol = teamOldSymbols[p];
                                //Debug.Log("oldSymbol: " + oldSymbol);
                                

                                if (currentCubePlaySymbol == oldSymbol)
                                {
                                    string newSymbol = teamNewSymbols[p];
                                    CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                                }
                                //Debug.Log("---: ");
                            }
                        }
                    }
                }

                //}
            }
            //Debug.Log(" SwitchOldSymbolsForNew end ------------------------------------------------- ");

            //Debug.Log(" n start ------------------------------------------------- ");

            //for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            //{
            //    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
            //    {
            //        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
            //        {
            //            GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
            //            string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

            //            Debug.Log($"indexDepth: {indexDepth}, indexColumn: {indexColumn}, indexRow: {indexRow} symbol: {currentCubePlaySymbol}");


            //        }
            //    }
            //}

            //Debug.Log(" n end ------------------------------------------------- ");
        }

        public static void SetUpFinalSymbolsForGameBoard(GameObject[,,] gameBoard)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);
            
            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                        string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);
                         
                        int currentCubePlaySymbolLength = currentCubePlaySymbol.Length;

                        if (currentCubePlaySymbolLength == 4) // symbol A + new = Anew -> 4
                        {
                            //string symbol = currentCubePlaySymbol.Substring(0, 1);
                            string newSymbol = RemoveExtraStaticTextFromStringToGetSymbol(currentCubePlaySymbol);
                            CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                        }                    
                    }
                }
            }
        }

        // ChangeDataForNewSymbolsForSwitch
        // ChangeDataForOldSymbolsForSwitch
        public static List<string[]> ChangeDataForSymbolsForSwitch(List<string[]> symbols, string staticText)
        {

            int teamsNumbers = symbols.Count;


            //Debug.Log(" BEFORE - START ------------------------------------------------- ");


            //for (int a = 0; a < teamsNumbers; a++)
            //{

            //    string[] team = oldSymbols[a];
            //    int playersNumners = team.Length;
            //    Debug.Log("team number: " + a);

            //    for (int l = 0; l < playersNumners; l++)
            //    {
            //        Debug.Log($"Symbol {l}: " + team[l]);
            //    }
            //}


            //Debug.Log(" BEFORE - END ------------------------------------------------- ");

            List<string[]> newOldSymbols = new List<string[]>();

            //string staticText = "n"; // new
            //Debug.Log(" ------------------------------------------------- ");
            for (int a = 0; a < teamsNumbers; a++)
            {

                string[] team = symbols[a];
                int playersNumners = team.Length;
                string[] newSymbols = new string[playersNumners];

                for (int l = 0; l < playersNumners; l++)
                {

                    string oldSymbol = team[l];
                    string newSymbol = oldSymbol + staticText;
                    newSymbols[l] = newSymbol;
                   
                }
                newOldSymbols.Insert(a, newSymbols);
            }


            //Debug.Log(" AFTER - START ------------------------------------------------- ");


            //for (int a = 0; a < teamsNumbers; a++)
            //{

            //    string[] team = newOldSymbols[a];
            //    int playersNumners = team.Length;
            //    Debug.Log("team number: " + a);

            //    for (int l = 0; l < playersNumners; l++)
            //    {
            //        Debug.Log($"Symbol {l}: " + team[l]);
            //    }
            //}
            

            //Debug.Log(" AFTER - END ------------------------------------------------- ");

            return newOldSymbols;

        }


        public static void SetUpSwitchedPlayersSymbolsForGameBoard(GameObject[,,] gameBoard, ArrayList newDataForPlayersSymbolsSwitch)
        {
            List<string[]> oldSymbolsForSwitch = (List<string[]>)newDataForPlayersSymbolsSwitch[1];
            List<string[]> newSymbolsForSwitch = (List<string[]>)newDataForPlayersSymbolsSwitch[0];
            int teamsNumbers = oldSymbolsForSwitch.Count - 1;

            GameObject[,,] gameBoardWithChangedData = ChangeDataForOldSymbolsForSwitch(gameBoard, oldSymbolsForSwitch);

            // adding to symbols from the list symbol "n", maybe add this symbol when we create the list ???
            //string staticTextForNew = "new";
            //List<string[]> symbolsForSwitchNew = ChangeDataForSymbolsForSwitch(newSymbolsForSwitch, staticTextForNew);
            //string staticTextForOld = "old";
            //List<string[]> symbolsForSwitchOld = ChangeDataForSymbolsForSwitch(oldSymbolsForSwitch, staticTextForOld);

            // adding to symbols from the list symbol "n", maybe add this symbol when we create the list ???
            List<string[]> symbolsForSwitchNew = ChangeDataForNewSymbolsForSwitch(newSymbolsForSwitch);
            List<string[]> symbolsForSwitchOld = ChangeDataForOldSymbolsForSwitch(oldSymbolsForSwitch);

            SwitchOldSymbolsForNew(gameBoard, symbolsForSwitchOld, symbolsForSwitchNew);
            SetUpFinalSymbolsForGameBoard(gameBoard);
         

            //for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            //{
            //    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
            //    {
            //        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
            //        {
            //            GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
            //            string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

            //            Debug.Log($"indexDepth: {indexDepth}, indexColumn: {indexColumn}, indexRow: {indexRow} symbol: {currentCubePlaySymbol}");


            //        }
            //    }
            //}

            //Debug.Log(" ------------------------------------------------- ");

           
        }

        public static List<string[]> ChangeDataForNewSymbolsForSwitch(List<string[]> newSymbolsForSwitch)
        {
            string staticTextForNew = "new";
            List<string[]> symbolsForSwitchNew = ChangeDataForSymbolsForSwitch(newSymbolsForSwitch, staticTextForNew);
            return symbolsForSwitchNew;
        }

        public static List<string[]> ChangeDataForOldSymbolsForSwitch(List<string[]> oldSymbolsForSwitch)
        {
            string staticTextForOld = "old";
            List<string[]> symbolsForSwitchOld = ChangeDataForSymbolsForSwitch(oldSymbolsForSwitch, staticTextForOld);
            return symbolsForSwitchOld;
        }

        public static List<string[]> SetUpNewTeamGameSymbols(ArrayList newDataForPlayersSymbolsSwitch, List<string[]> teamGameSymbols)
        {
            //List<string[]> oldSymbolsForSwitch = newDataForPlayersSymbolsSwitch[1];
            List<string[]> newSymbolsForSwitch = (List<string[]>)newDataForPlayersSymbolsSwitch[0];
            
            List<int[]> randomIndexesForSwitch = (List<int[]>)newDataForPlayersSymbolsSwitch[2];
            //List<int[]> randomIndexesForSwitch2 =  new List<int[]>();
            //List<string[]> newSymbolsForSwitch = new List<string[]>();

            int teamsNumbers = teamGameSymbols.Count;



            //int[] tab11 = { 2 };
            //int[] tab22 = { 1 };
            //int[] tab33 = { 1 };
            //int[] tab44 = { 0 };

            //randomIndexesForSwitch2.Insert(0, tab11);
            //randomIndexesForSwitch2.Insert(1, tab22);
            //randomIndexesForSwitch2.Insert(2, tab33);
            //randomIndexesForSwitch2.Insert(3, tab44);

            //Debug.Log("TEAM GAME SWITCHED SYMBOLS START ------------------------------------------------  ");
            //Debug.Log("INDEXES START ------------------------------------------------  ");

            //for (int team = 0; team < randomIndexesForSwitch.Count; team++)
            //{
            //    Debug.Log("TEAM:" + team);
            //    int[] test = randomIndexesForSwitch[team];
            //    for (int i = 0; i < test.Length; i++)
            //    {

            //        Debug.Log($"team {team}, symbol index[{i}] = " + test[i]);

            //    }

            //}

            //Debug.Log("INDEXES END ------------------------------------------------  ");
            //Debug.Log("OLD SYMBOLS START ------------------------------------------------  ");

            //for (int team = 0; team < teamGameSymbols.Count; team++)
            //{
            //    Debug.Log("TEAM:" + team);
            //    string[] test = teamGameSymbols[team];
            //    for (int i = 0; i < test.Length; i++)
            //    {

            //        Debug.Log($"team {team}, symbol test[{i}] = " + test[i]);

            //    }

            //}

            //Debug.Log("OLD SYMBOLS END ------------------------------------------------  ");

           




            // for test - bug
            //string[] tab1 = { "F" };
            //string[] tab2 = { "A" };
            //string[] tab3 = { "T" };
            //string[] tab4 = { "X" };

            //string[] tab1 = { "F" };
            //string[] tab2 = { "L" };
            //string[] tab3 = { "T" };
            //string[] tab4 = { "X" };

            //newSymbolsForSwitch1.Insert(0, tab1);
            //newSymbolsForSwitch1.Insert(1, tab2);
            //newSymbolsForSwitch1.Insert(2, tab3);
            //newSymbolsForSwitch1.Insert(3, tab4);

            //List<string[]> teamGameSymbolsForSwitch = ChangeDataForOldSymbolsForSwitch(teamGameSymbols);
            //List<string[]> symbolsForSwitchNew = ChangeDataForNewSymbolsForSwitch(newSymbolsForSwitch1);
            //List<string[]> symbolsForSwitchOld = ChangeDataForOldSymbolsForSwitch(oldSymbolsForSwitch);

            List<string[]> newTeamsSymbols = new List<string[]>();

            for (int i = 0; i < teamsNumbers; i++)
            {
                //Debug.Log("team : " + i);
                string[] oldTeamSymbols = teamGameSymbols[i];
                string[] newTeamSymbols = newSymbolsForSwitch[i];
                
                int[] indexesForSwitch = randomIndexesForSwitch[i];
                int oldSymbolsNumber = oldTeamSymbols.Length;
                //Debug.Log("oldSymbolsNumber: " + oldSymbolsNumber);
                int newSymbolsNumber = newTeamSymbols.Length;
                //Debug.Log("newSymbolsNumber: " + newSymbolsNumber);

                string[] switchedSymbols = new string[oldSymbolsNumber];

                int indexSymbol = 0;
                int indexesCounted = 0;
                int oldIndex = 0;

                for (int j = 0; j < oldSymbolsNumber; j++)
                {

                    if (indexesCounted < newSymbolsNumber)
                    {
                       oldIndex = indexesForSwitch[indexSymbol];
                       indexesCounted++;
                    }

           
                    if (oldIndex == j)
                    {
                        string newSymbol = newTeamSymbols[indexSymbol];
                        switchedSymbols[j] = newSymbol;
                        indexSymbol++;
                    }
                    else
                    {
                        string oldSymbol = oldTeamSymbols[j];
                        switchedSymbols[j] = oldSymbol;
                    }




                    

                    //string currentSymbol = 
                    ////Debug.Log("currentCubePlaySymbol: " + currentCubePlaySymbol);

                    //for (int p = 0; p < playersNumbers; p++)
                    //{
                    //    string oldSymbol = teamOldSymbols[p];
                    //    //Debug.Log("oldSymbol: " + oldSymbol);


                    //    if (currentCubePlaySymbol == oldSymbol)
                    //    {
                    //        string newSymbol = teamNewSymbols[p];
                    //        CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                    //    }
                    //    //Debug.Log("---: ");
                    //}


                }










                ////string[] oldTeamSymbols = teamGameSymbols[i];
                //////string[] newTeamSymbols = newSymbolsForSwitch[i];
                ////string[] newTeamSymbols = newSymbolsForSwitch1[i];
               


                //for (int j = 0; j < oldSymbolsNumber; j++)
                //{

                //    if (newSymbolsNumber == oldSymbolsNumber)
                //    {
                //        switchedSymbols[j] = newTeamSymbols[index];
                //    }
                //    //else if (newSymbolsNumber < oldSymbolsNumber)
                //    else if (newSymbolsNumber > index)
                //    {
                //        switchedSymbols[j] = newTeamSymbols[index];
                //    }
                //    else
                //    {
                //        switchedSymbols[j] = oldTeamSymbols[j];
                //    }



                //}

                newTeamsSymbols.Insert(i, switchedSymbols);

            }



            //Debug.Log("TEAM GAME SWITCHED SYMBOLS START ------------------------------------------------  ");
            //Debug.Log("NEW SYMBOLS START ------------------------------------------------  ");

            //for (int team = 0; team < newSymbolsForSwitch.Count; team++)
            //{
            //    Debug.Log("TEAM:" + team);
            //    string[] test = newSymbolsForSwitch[team];
            //    for (int i = 0; i < test.Length; i++)
            //    {

            //        Debug.Log($"team {team}, symbol test[{i}] = " + test[i]);

            //    }

            //}

            //Debug.Log("NEW SYMBOLS END ------------------------------------------------  ");

            //Debug.Log("SWITCHED SYMBOLS START ------------------------------------------------  ");

            //for (int team = 0; team < newTeamsSymbols.Count; team++)
            //{
            //    Debug.Log("TEAM:" + team);
            //    string[] test = newTeamsSymbols[team];
            //    for (int i = 0; i < test.Length; i++)
            //    {

            //        Debug.Log($"team {team}, symbol test[{i}] = " + test[i]);

            //    }

            //}

            //Debug.Log("SWITCHED SYMBOLS END ------------------------------------------------  ");


            return newTeamsSymbols;
        }

        // -----
        public static string[] GetNewPlayersSymbolsMove(string[] playerSymbolMove, string[] oldSymbolsForChande, string[] finalNewSymbolsForSwitch)
        {
            int playerSymbolMoveLength = playerSymbolMove.Length;
            //int newSymbolsToChangeLength = newSymbolsForChande.Length;
            int oldSymbolsToChangeLength = oldSymbolsForChande.Length;

            //string[] newPlayerSymbolMove = new string[playerSymbolMoveLength];

            for (int i = 0; i < playerSymbolMoveLength; i++)
            {
                string oldSymbol = playerSymbolMove[i];

                for (int j = 0; j < oldSymbolsToChangeLength; j++)
                {
                    string symbolToCompare = oldSymbolsForChande[j];

                    if (oldSymbol == symbolToCompare)
                    {
                        string symbol = finalNewSymbolsForSwitch[j];
                        string newSymbol = RemoveExtraStaticTextFromStringToGetSymbol(symbol);
                        playerSymbolMove[i] = newSymbol;

                    }

                }
            }


            //for (int i = 0; i < playerSymbolMove.Length; i++)
            //{
            //    string symbol = playerSymbolMove[i];
            //    int symbolLength = symbol.Length;

            //    if (symbolLength > 1)
            //    {
            //        string newSymbol = symbol.Substring(0, 1);
            //        playerSymbolMove[i] = newSymbol;
            //    }

            //}




            //for (int i = 0; i < oldSymbolsForChande.Length; i++)
            //{
            //    Debug.Log($"a: {i}, oldSymbolsForChande: {oldSymbolsForChande[i]}");
            //}
            //Debug.Log($" ----------------------- ");

            //for (int i = 0; i < newSymbolsForChande.Length; i++)
            //{
            //    Debug.Log($"b: {i}, newSymbolsForChande: {newSymbolsForChande[i]}");
            //}
            //Debug.Log($" ----------------------- ");

            //for (int i = 0; i < playerSymbolMove.Length; i++)
            //{
            //    Debug.Log($"OLD: {i}, playerSymbolMove: {playerSymbolMove[i]}");
            //}
            //Debug.Log($" ----------------------- ");


            //for (int i = 0; i < newPlayerSymbolMove.Length; i++)
            //{
            //    Debug.Log($"NEW: {i}, newPlayerSymbolMove: {newPlayerSymbolMove[i]}");
            //}
            //Debug.Log($" ----------------------- ");



            return playerSymbolMove;
        }

        public static string[] CreateTableWithTagsForPlayerSymbolMove()
        {
            string tagPlayerSymbolCurrent = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolCurrent();
            string tagPlayerSymbolPrevious = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolPrevious();
            string tagPlayerSymbolNext = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolNext();

            string[] table = new string[3];
            table[0] = tagPlayerSymbolPrevious;
            table[1] = tagPlayerSymbolCurrent;
            table[2] = tagPlayerSymbolNext;

            return table;
        }

        public static string RemoveExtraStaticTextFromStringToGetSymbol(string symbol)
        {
            string newSymbol = symbol.Substring(0, 1);
            return newSymbol;
        }

        public static void ChangeDataForPlayersSymbolsMoveGameObjects(string[] oldSymbolsForChande, string[] finalNewSymbolsForSwitch)
        {
            string[] table = CreateTableWithTagsForPlayerSymbolMove();
            int newSymbolsToChangeLength = finalNewSymbolsForSwitch.Length;

            for (int i = 0; i < table.Length; i++)
            {
                string tagName = table[i];
                GameObject cubePlay = GameCommonMethodsMain.GetObjectByTagName(tagName);
                string currentSymbol = CommonMethods.GetCubePlayText(cubePlay);

                for (int j = 0; j < newSymbolsToChangeLength; j++)
                {
                    string oldSymbol = oldSymbolsForChande[j];

                    if (currentSymbol == oldSymbol)
                    {
                        string symbol = finalNewSymbolsForSwitch[j];
                        string newSymbol = RemoveExtraStaticTextFromStringToGetSymbol(symbol);
                        GameCommonMethodsMain.ChangeTextForFirstChild(cubePlay, newSymbol);
                    }
                }
            }
        }

        public static string[] GetSymbolsAsOneTable(List<string[]> teamsSymbols, int playersNumberForChangeSymbols)
        {
            string[] symbols = new string[playersNumberForChangeSymbols];
            int teamsNumbers = teamsSymbols.Count;
            int index = 0;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teamsSymbols[i];
                int playersNumbers = teamSymbols.Length;

                for (int j = 0; j < playersNumbers; j++)
                {
                    string teamSymbol = teamSymbols[j];
                    symbols[index] = teamSymbol;
                    index++;
                }
            }


            return symbols;
        }

        public static int GetNumbersForCountedSymbolsToChange(List<string[]> teams)
        {
            int playersNumbers = 0;
            int teamsNumbers = teams.Count;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] teamSymbols = teams[i];
                int symbolsNumbers = teamSymbols.Length;
                playersNumbers = playersNumbers + symbolsNumbers;
            }

            return playersNumbers;
        }

        public static string[] SetUpNewPlayersSymbolsMove(string[] playerSymbolMove, ArrayList newDataForPlayersSymbolsSwitch)
        {

            List<string[]> oldTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[0];
            List<string[]> newTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[1];

            int playersNumberForChangeSymbols = GetNumbersForCountedSymbolsToChange(newTeamsSymbols);

            string[] oldSymbolsForSwitch = GetSymbolsAsOneTable(oldTeamsSymbols, playersNumberForChangeSymbols);
            string[] newSymbolsForSwitch = GetSymbolsAsOneTable(newTeamsSymbols, playersNumberForChangeSymbols);

            string[] finalNewSymbolsForSwitch = ChangeDataForNewSymbolsForSwitch(newSymbolsForSwitch);

            //Debug.Log($" -------------------- BEFORE -------------------------------------- ");

            //for (int i = 0; i < finalNewSymbolsForSwitch.Length; i++)
            //{
            //    Debug.Log($"finalNewSymbolsForSwitch[{i}]: " + finalNewSymbolsForSwitch[i]);
            //}

            //Debug.Log($" -------------------- BEFORE -------------------------------------- ");

            //for (int i = 0; i < playerSymbolMove.Length; i++)
            //{
            //    Debug.Log($"_playersSymbols[{i}]: " + playerSymbolMove[i]);
            //}

            // start 
            playerSymbolMove = GetNewPlayersSymbolsMove(playerSymbolMove, oldSymbolsForSwitch, finalNewSymbolsForSwitch);
            ChangeDataForPlayersSymbolsMoveGameObjects(oldSymbolsForSwitch, finalNewSymbolsForSwitch);


            //Debug.Log($" -------------------- AFTER -------------------------------------- ");

            //for (int i = 0; i < playerSymbolMove.Length; i++)
            //{
            //    Debug.Log($"_playersSymbols[{i}]: " + playerSymbolMove[i]);
            //}

            return playerSymbolMove;
        }

        // player symbol switch

        public static string[] ChangeDataForNewSymbolsForSwitch(string[] newSymbolsForSwitch)
        {
            string staticText = "new";
            int oldSymbolsForSwitchNumber = newSymbolsForSwitch.Length;

            for (int i = 0; i < oldSymbolsForSwitchNumber; i++)
            {
                string symbol = newSymbolsForSwitch[i];
                string textForSwitch = symbol + staticText;
                newSymbolsForSwitch[i] = textForSwitch;
            }

            return newSymbolsForSwitch;

        }

        public static string[] GetNewPlayersSymbols(string[] playersSymbols, ArrayList newDataForPlayersSymbolsSwitch)
        {
            int symbolsNumbers = playersSymbols.Length;
            //string[] newPlayersSymbols = new string[symbolsNumbers];
            
            List<string[]> oldTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[0];
            List<string[]> newTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[1];

            int playersNumberForChangeSymbols = GetNumbersForCountedSymbolsToChange(newTeamsSymbols);

            string[] oldSymbolsForSwitch = GetSymbolsAsOneTable(oldTeamsSymbols, playersNumberForChangeSymbols);
            string[] newSymbolsForSwitch = GetSymbolsAsOneTable(newTeamsSymbols, playersNumberForChangeSymbols);

            string[] finalNewSymbolsForSwitch = ChangeDataForNewSymbolsForSwitch(newSymbolsForSwitch);

            //Debug.Log($" ---------------------------------------------------------- ");
            //Debug.Log($" ---------------------------------------------------------- ");
            //for (int i = 0; i < playersSymbols.Length; i++)
            //{
            //    Debug.Log($"playersSymbols[{i}]: " + playersSymbols[i]);
            //}
            //Debug.Log($" --------------------------");

            int oldSymbolsNumbers = oldSymbolsForSwitch.Length;
            //int newSymbolsNumbers = finalNewSymbolsForSwitch.Length;

            // change symobls
            for (int i = 0; i < symbolsNumbers; i++)
            {
                string currentSymbol = playersSymbols[i];

                for (int a = 0; a < oldSymbolsNumbers; a++)
                {
                    string oldSymbol = oldSymbolsForSwitch[a];
                    
                    if (currentSymbol == oldSymbol)
                    {
                        //newPlayersSymbols[i] = finalNewSymbolsForSwitch[a];
                        playersSymbols[i] = finalNewSymbolsForSwitch[a];
                    }
                    //else
                    //{

                    //    //newPlayersSymbols[i] = currentSymbol;
                    //    playersSymbols[i] = currentSymbol;
                    //}


                }



            }

            // remove extra word


            //Debug.Log($" ---------------------------------------------------------- ");
            //Debug.Log($" ---------------------------------------------------------- ");
            //for (int i = 0; i < playersSymbols.Length; i++)
            //{
            //    Debug.Log($"playersSymbols[{i}]: " + playersSymbols[i]);
            //}

            for (int i = 0; i < symbolsNumbers; i++)
            {
                string symbol = playersSymbols[i];
                int symbolLength = symbol.Length;

                if (symbolLength > 1)
                {
                    //string newSymbol = symbol.Substring(0,1);
                    string newSymbol = RemoveExtraStaticTextFromStringToGetSymbol(symbol);
                    playersSymbols[i] = newSymbol;
                }

            }

            //Debug.Log($" ---------------------------------------------------------- ");
            //Debug.Log($" ---------------------------------------------------------- ");
            //for (int i = 0; i < playersSymbols.Length; i++)
            //{
            //    Debug.Log($"playersSymbols[{i}]: " + playersSymbols[i]);
            //}
            //Debug.Log($" --------------------------");

            //for (int i = 0; i < newPlayersSymbols.Length; i++)
            //{
            //    Debug.Log($"newPlayersSymbols[{i}]: " + newPlayersSymbols[i]);
            //}

            //Debug.Log($" ---------------------------------------------------------- ");
            //Debug.Log($" ---------------------------------------------------------- ");

            return playersSymbols;
        }


        public static string[,] SetUpNewGameBoardVerification2D(string[,] gameBoardVerification2D, ArrayList newDataForPlayersSymbolsSwitch)
        {
            List<string[]> oldTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[0];
            List<string[]> newTeamsSymbols = (List<string[]>)newDataForPlayersSymbolsSwitch[1];

            int playersNumberForChangeSymbols = GetNumbersForCountedSymbolsToChange(newTeamsSymbols);

            string[] oldSymbolsForSwitch = GetSymbolsAsOneTable(oldTeamsSymbols, playersNumberForChangeSymbols);
            string[] newSymbolsForSwitch = GetSymbolsAsOneTable(newTeamsSymbols, playersNumberForChangeSymbols);

            string[] finalNewSymbolsForSwitch = ChangeDataForNewSymbolsForSwitch(newSymbolsForSwitch);


            int cubePlayIndexY = gameBoardVerification2D.GetLength(0);
            int cubePlayIndexX = gameBoardVerification2D.GetLength(1);
            int newSymbolsToChange = newSymbolsForSwitch.Length;

            for (int z = 0; z < newSymbolsToChange; z++)
            {
                string newSymbol = finalNewSymbolsForSwitch[z];
                Debug.Log("8888 newSymbol: " + newSymbol);
                string oldSymbol = oldSymbolsForSwitch[z];

                //for (int i = 0; i < gameBoardVerification2D.GetLength(0); i++)
                for (int i = 0; i < cubePlayIndexY; i++)
                {
                    //for (int j = 0; j < gameBoardVerification2D.GetLength(1); j++)
                    for (int j = 0; j < cubePlayIndexX; j++)
                    {
                        string currentSymbol = gameBoardVerification2D[i, j];

                        if (currentSymbol == oldSymbol)
                        {
                            Debug.Log("8888 ---: " + newSymbol);
                            string symbol = RemoveExtraStaticTextFromStringToGetSymbol(newSymbol);
                            Debug.Log("8888 --- 2: " + symbol);
                            gameBoardVerification2D[i, j] = symbol;
                        }
                    }
                }
            }









            //for (int i = 0; i < cubePlayIndexY; i++)
            //{
            //    for (int j = 0; j < cubePlayIndexX; j++)
            //    {
            //        string currentSymbol = gameBoardVerification2D[i, j];

            //        Debug.Log($"gameBoardVerification2D[{i}, {j}]: " + gameBoardVerification2D[i, j]);
            //    }
            //}

            //Debug.Log($" ---------------------------------------------------------- ");
            //for (int z = 0; z < newSymbolsToChange; z++)
            //{
            //    string newSymbol = newSymbols[z];
            //    string oldSymbol = oldSymbols[z];

            //    for (int i = 0; i < gameBoardVerification2D.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < gameBoardVerification2D.GetLength(1); j++)
            //        {
            //            string currentSymbol = gameBoardVerification2D[i, j];

            //            if (currentSymbol == oldSymbol)
            //            {
            //                newGameBoardVerification2D[i, j] = newSymbol;
            //            }
            //            else
            //            {
            //                newGameBoardVerification2D[i, j] = newSymbol;
            //            }

            //        }
            //    }

            //}


            //for (int i = 0; i < cubePlayIndexY; i++)
            //{
            //    for (int j = 0; j < cubePlayIndexX; j++)
            //    {
            //        string currentSymbol = gameBoardVerification2D[i, j];

            //        Debug.Log($"newGameBoardVerification2D[{i}, {j}]: " + newGameBoardVerification2D[i, j]);
            //    }
            //}





            //return newGameBoardVerification2D;
            return gameBoardVerification2D;
        }


    }
}
