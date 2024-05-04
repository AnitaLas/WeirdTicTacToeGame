using System;
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
        public static List<string[]> GetSymoblsForSwitch(List<string[]> teamGameSymbols)
        {
            List<string[]> oldSymbolsForSwitch = new List<string[]>();

            // change for random, works = 2
            int maxSymbolsNumberForChange = PlayGameChangePlayersSymbolsMethods.GetMinPlayersNumberForTeam(teamGameSymbols);
            //int maxSymbolsNumberForChange = 1;

            int teamsNumbers = teamGameSymbols.Count;
            //Debug.Log(" teamsNumbers: " + teamsNumbers);
            //Debug.Log($" --------------------------------------- ");

            int[] indexesForSwitch;
            int numbersOfSymbolsToSwitch;

            for (int t = 0; t < teamsNumbers; t++)
            {
               
                string[] teamSymbols = teamGameSymbols[t];
                int playersSymbols = teamSymbols.Length;


                indexesForSwitch = GetIndexesForSwitch(playersSymbols, maxSymbolsNumberForChange);
                numbersOfSymbolsToSwitch = indexesForSwitch.Length;

                ////if (teamsNumbers == 2)
                ////{
                ////    indexesForSwitch = GetIndexesForSwitch();
                ////    numbersOfSymbolsToSwitch = indexesForSwitch.Length;
                ////    Debug.Log("numbersOfSymbolsToSwitch: " + numbersOfSymbolsToSwitch);
                ////}
                ////else
                ////{
                ////    indexesForSwitch = GetIndexesForSwitch(playersSymbols, maxSymbolsNumberForChange);
                ////    numbersOfSymbolsToSwitch = indexesForSwitch.Length;
                ////}



                string[] symbolsToSwitch = new string[maxSymbolsNumberForChange];

                for (int a = 0; a < numbersOfSymbolsToSwitch; a++)
                {

                    int indexToSwitch = indexesForSwitch[a];
                    string symbol = teamSymbols[indexToSwitch];
                    symbolsToSwitch[a] = symbol;

                }

                //for (int i = 0; i < symbolsToSwitch.Length; i++)
                //{
                //    Debug.Log($"symbolsToSwitch[{i}] :" + symbolsToSwitch[i]);
                //}
                //Debug.Log($" --------------------------------------- ");

                oldSymbolsForSwitch.Insert(0, symbolsToSwitch);
            }





            return oldSymbolsForSwitch;
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

        public static int[] GetIndexesForRightMove(int playersSymbols, int startIndex)
        {
            int[] indexes = new int[playersSymbols];
            int index = startIndex;


            if (playersSymbols == 2)
            {
                indexes[0] = 1;
                indexes[1] = 0;
            }
            else
            {
                for (int i = 0; i < playersSymbols; i++)
                {
                    indexes[i] = index;

                    if (index < playersSymbols - 1)
                    {

                        index++;

                    }
                    else
                    {
                        index = 0;
                        //indexes[i] = index;
                        //index++;
                    }
                }

            }
            

            return indexes;
        }

        public static int[] GetIndexesForLeftMove(int playersSymbols, int startIndex)
        {
            int[] indexes = new int[playersSymbols];
            int index = startIndex;


            if (playersSymbols == 2)
            {
                indexes[0] = 1;
                indexes[1] = 0;
            }
            else
            {
                for (int i = 0; i < playersSymbols; i++)
                {
                    indexes[i] = index;

                    if (index > 0)
                    {

                        index--;
                    }
                    else
                    {
                        index = playersSymbols - 1;

                    }
                }
            }
            

            return indexes;
        }

        public static List<string[]> SetUpSymbolsForSwitch(List<string[]> symbolsForSwitch)
        {
            List<string[]> switchedSymbols = new List<string[]>();
            int playersSymbols = symbolsForSwitch.Count;

            int[] indexes; // = new int[playersSymbols];
            //int minIndex = 0;
            //int maxIndex = playersSymbols - 1;

            //int startIndex = CommonMethods.ChooseRandomNumber(minIndex, maxIndex);
            //int startIndex = 3;
            int startIndex = 3;
            //Debug.Log("startIndex: " + startIndex);

            bool isStartIndexEven = CommonMethods.IsNumberEven(startIndex);
            //Debug.Log("isStartIndexEven: " + isStartIndexEven);

            //int index = startIndex;


            if (isStartIndexEven == true)
            {
                indexes = GetIndexesForRightMove(playersSymbols, startIndex);
            }
            else
            {
                indexes = GetIndexesForLeftMove(playersSymbols, startIndex);
            }

    
            //Debug.Log(" final ---------------");
            for (int i = 0; i < playersSymbols; i++)
            {
                int finalIndex = indexes[i];

                //Debug.Log("index: " + finalIndex);
                string[] team = symbolsForSwitch[finalIndex];

                switchedSymbols.Insert(i, team);

            }
            //Debug.Log(" end of set up ---------------");
            //Debug.Log(" end of set up ---------------");

            //Debug.Log(" SS to switch ----------------------------------------------- ");

            //for (int i = 0; i < symbolsForSwitch.Count; i++)
            //{
            //    string[] team = symbolsForSwitch[i];
            //    int lenght1 = team.Length;

            //    Debug.Log("team: " + i);

            //    for (int j = 0; j < lenght1; j++)
            //    {
            //        Debug.Log($"symbol team[{j}]: " + team[j]);
            //    }

            //}

            //Debug.Log("SS switchedSymbols: " + switchedSymbols);

            //for (int i = 0; i < switchedSymbols.Count; i++)
            //{
            //    string[] team = switchedSymbols[i];
            //    int lenght1 = team.Length;

            //    Debug.Log("team: " + i);

            //    for (int j = 0; j < lenght1; j++)
            //    {
            //        Debug.Log($"symbols team[{j}]: " + team[j]);
            //    }

            //}
            //Debug.Log(" ----------------------------------------------- ");

            return switchedSymbols;

        }

        public static List<List<string[]>> GetPlayersSymbolsForSwitch(List<string[]> teamGameSymbols)
        {
            List<List<string[]>> symbolsLists = new List<List<string[]>>();
            
            // "old symbols"
            List<string[]> symbolsForSwitch = GetSymoblsForSwitch(teamGameSymbols);

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
            //        Debug.Log($"symbol team[{j}]: " + team[j]);
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
            //        Debug.Log($"symbols team[{j}]: " + team[j]);
            //    }

            //}
            //Debug.Log(" ----------------------------------------------- ");
            symbolsLists.Insert(0, symbolsForSwitch);
            symbolsLists.Insert(1, switchedSymbols);

            return symbolsLists;

        }

        //--------------------------------------------------------------------------------------------------------
        public static void DoubleOldSymbolsForSwitch(GameObject[,,] gameBoard, string[] oldSymbols)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);
            int numbersOldSymbols = oldSymbols.Length;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                        string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

                        for (int i = 0; i < numbersOldSymbols; i++)
                        {
                            string oldSymbol = oldSymbols[i];

                            if (currentCubePlaySymbol == oldSymbol)
                            {
                                string doubleSymbols = currentCubePlaySymbol + currentCubePlaySymbol;
                                CommonMethods.ChangeTextForFirstChild(cubePlay, doubleSymbols);
                            }
                        }                       
                    }
                }
            }
        }

        public static void SwitchOldSymbolsForNew(GameObject[,,] gameBoard, string[] oldSymbols, string[] newSymbols)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);
            int numbersOldSymbols = oldSymbols.Length;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                        string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

                        for (int i = 0; i < numbersOldSymbols; i++)
                        {
                            string newSymbol = newSymbols[i];

                            if (currentCubePlaySymbol == newSymbol)
                            {
                                string oldSymbol = oldSymbols[i];
                                CommonMethods.ChangeTextForFirstChild(cubePlay, oldSymbol);
                            }
                        }
                    }
                }
            }
        }

        public static void SwitchDoubleOldSymbolsForNew(GameObject[,,] gameBoard, string[] oldSymbols, string[] newSymbols)
        {
            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);
            int numbersOldSymbols = oldSymbols.Length;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                        string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);
                         
                        int dobuleSymbol = currentCubePlaySymbol.Length;

                        if (dobuleSymbol == 2)
                        {
                            string singleSymbol = currentCubePlaySymbol.Substring(0, 1);

                            for (int i = 0; i < numbersOldSymbols; i++)
                            {
                                string oldSymbol = oldSymbols[i];

                                if (singleSymbol == oldSymbol)
                                {
                                    string newSymbol = newSymbols[i];
                                    CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                                }
                            }

                        }

                       
                    }
                }
            }
        }

        public static void SetUpSwitchedPlayersSymbolsForGameBoard(GameObject[,,] gameBoard, List<List<string[]>> newDataForPlayersSymbolsSwitch)
        {
            List<string[]> oldSymbolsForSwitch = newDataForPlayersSymbolsSwitch[0];
            List<string[]> newSymbolsForSwitch = newDataForPlayersSymbolsSwitch[1];
            int teamsNumbers = oldSymbolsForSwitch.Count - 1;
            Debug.Log("teamsNumbers: " + teamsNumbers);

            int maxIndexDepth = gameBoard.GetLength(0);
            int maxIndexColumn = gameBoard.GetLength(2);
            int maxIndexRow = gameBoard.GetLength(1);
           
            Debug.Log(" ------------------------------------------------- ");

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                        string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

                        Debug.Log($"indexDepth: {indexDepth}, indexColumn: {indexColumn}, indexRow: {indexRow} symbol: {currentCubePlaySymbol}");


                    }
                }
            }

            Debug.Log(" ------------------------------------------------- ");

            //int numbersToChange = oldSymbolsForSwitch[0].Length;

            //for (int i = 0; i < teamsNumbers; i++)
            for (int i = 0; i < teamsNumbers; i++)
            {
                //string[] oldSymbols = oldSymbolsForSwitch[i];
                //string[] newSymbols = newSymbolsForSwitch[i];

                string[] oldSymbols = oldSymbolsForSwitch[i];
                string[] newSymbols = newSymbolsForSwitch[i];



                DoubleOldSymbolsForSwitch(gameBoard, oldSymbols);
                SwitchOldSymbolsForNew(gameBoard, oldSymbols, newSymbols);
                SwitchDoubleOldSymbolsForNew(gameBoard, oldSymbols, newSymbols);



                //for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                //{
                //    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                //    {
                //        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                //        {
                //            GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                //            string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

                //            if (currentCubePlaySymbol == oldSymbol)
                //            {
                //                CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                //            }
                //        }
                //    }
                //}
            }

            //--------------------------------



            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = gameBoard[indexDepth, indexRow, indexColumn];
                        string currentCubePlaySymbol = CommonMethods.GetCubePlayText(cubePlay);

                        Debug.Log($"indexDepth: {indexDepth}, indexColumn: {indexColumn}, indexRow: {indexRow} symbol: {currentCubePlaySymbol}");


                    }
                }
            }

            Debug.Log(" ------------------------------------------------- ");
        }
    }
}
