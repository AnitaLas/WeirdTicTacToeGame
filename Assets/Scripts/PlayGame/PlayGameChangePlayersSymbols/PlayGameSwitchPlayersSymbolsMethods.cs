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

        public static List<string[]> GetNewDataForPlayersSymbols(string[] playersSymbols, List<float> gameChangeTimeConfiguration, List<string[]> teamGameSymbols)
        {

            List<string[]> symbolsLists = new List<string[]>();

            symbolsLists = GetNewPlayersSymbolsForSwitch(playersSymbols, teamGameSymbols);
   
            return symbolsLists;

        }

        public static string GetIndexesAsString(int playersSymbols)
        {
            string numbers = "";

            for (int i = 0; i < playersSymbols; i++)
            {
                numbers = numbers + i;
                //Debug.Log("numbers: " + numbers);
            }
            //Debug.Log(" -----------  ");
            return numbers;
        }

        public static int[] GetIndexesForSwitch()
        {
            int[] indexes = new int[2];
            indexes[0] = 1;
            indexes[1] = 0;
            return indexes;
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

                for (int i = 0; i < symbolsToSwitch.Length; i++)
                {
                    Debug.Log($"symbolsToSwitch[{i}] :" + symbolsToSwitch[i]);
                }
                Debug.Log($" --------------------------------------- ");

                oldSymbolsForSwitch.Insert(0, symbolsToSwitch);
            }





            return oldSymbolsForSwitch;
        }

        public static List<string[]> SetUpSymbolsForSwitch(List<string[]> symbolsForSwitch)
        {
            List<string[]> switchedSymbols = new List<string[]>();
            int teamsNumbers = symbolsForSwitch.Count;

            int[] indexes = new int[teamsNumbers];

            string allNumbers = GetIndexesAsString(teamsNumbers);

            string numbers = allNumbers;

            int minNumber = 0;
            int maxNumber = teamsNumbers;


            if (teamsNumbers == 2)
            {
                indexes[0] = 1;
                indexes[1] = 0;
            }
            else
            {
                for (int i = 0; i < teamsNumbers; i++)
                {
                    //Debug.Log("1 numbers: " + numbers);
                    //Debug.Log("i: " + i);
                    //Debug.Log("minNumber: " + minNumber);
                    //Debug.Log("maxNumber: " + maxNumber);
                    int randomIndexToChange = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
                    //Debug.Log("randomIndexToChange: " + randomIndexToChange);

                    string index = numbers.Substring(randomIndexToChange, 1);
                    int finaleIndex = CommonMethods.ConvertStringToInt(index);

                    indexes[i] = finaleIndex;

                    maxNumber--;
                    numbers = numbers.Remove(randomIndexToChange, 1);
                }
            }




            for (int i = 0; i < teamsNumbers; i++)
            {
                int index = indexes[i];

                Debug.Log("index: " + index);
                string[] team = symbolsForSwitch[index];

                switchedSymbols.Insert(i, team);

            }

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
        public static List<string[]> GetNewPlayersSymbolsForSwitch(string[] playersSymbols, List<string[]> teamGameSymbols)
        {
            List<string[]> symbolsLists = new List<string[]>();

            //Debug.Log(" 2 switch ------");
            int takenSymbolsLenght = playersSymbols.Length;

            //int maxSymbolsNumberForChange = GetMinPlayersNumberForTeam(teamGameSymbols);
            //Debug.Log("maxSymbolsNumberForChange: " + maxSymbolsNumberForChange);
           //Debug.Log(" -----------  ");
            //int[] maxandomIndexForChange = GetRandomNumbersForSwitch(numberSymbolsToChange);

            //List<string[]> symbolsForSwitch = GetSymoblsForSwitch(teamGameSymbols, maxSymbolsNumberForChange);
            
            // "old symbols"
            List<string[]> symbolsForSwitch = GetSymoblsForSwitch(teamGameSymbols);

            // "new symbols"
            List<string[]> switchedSymbols = SetUpSymbolsForSwitch(symbolsForSwitch); 



            //string[] newSymbolsForChange = new string[numberSymbolsToChange];
            //string[] oldSymbolsForChange = new string[numberSymbolsToChange];

            //string[] newSymbolsForChange = GetNewSymbols(playersSymbols, numberSymbolsToChange);
            //string[] oldSymbolsForChange = GetOldSymbols(playersSymbols, numberSymbolsToChange, isChangeForAll);

            //playersSymbols = GetNewPlayersSymbols(playersSymbols, oldSymbolsForChange, newSymbolsForChange, numberSymbolsToChange);

            //symbolsLists.Insert(0, oldSymbolsForChange);
            //symbolsLists.Insert(1, newSymbolsForChange);
            //symbolsLists.Insert(2, playersSymbols);

            return symbolsLists;

        }
    }
}
