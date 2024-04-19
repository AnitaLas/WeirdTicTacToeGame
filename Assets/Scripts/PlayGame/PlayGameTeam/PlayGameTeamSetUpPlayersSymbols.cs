using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameTeamSetUpPlayersSymbols
    {

        //public static Tuple<List<string[]>, List<int[]>> GetDataForGameTeam(List<string[]> teamsSymbols)
        //{
            


        //}

        public static string[] CreateTableWithDifferentQuantitiesForPlayersMoves(List<string[]> teamsSymbols)
        {
            int teamsNumbers = teamsSymbols.Count;

            //Debug.Log($"teamsNumbers: " + teamsNumbers);

            int[] playersNumberInTeams = new int[teamsNumbers];

            // get players number in each teams
            for (int a = 0; a < teamsNumbers; a++)
            {
                string[] symbols = teamsSymbols[a];
                int number = symbols.Length;
                playersNumberInTeams[a] = number;
            }

            // get length for allSymbol

            int allPlayersNumber = 0;

            for (int i = 0; i < teamsNumbers; i++)
            {
                int number = playersNumberInTeams[i];
                allPlayersNumber = allPlayersNumber + number;
            }

            string[] allSymbols = new string[allPlayersNumber];

            int index = 0;
            for (int l = 0; l < teamsNumbers; l++)
            {
                string[] teamSymbols = teamsSymbols[l];
                int playersNumberInTeam = teamSymbols.Length;

                for (int w = 0; w < playersNumberInTeam; w++)
                {
                    string symbol = teamSymbols[w];
                    allSymbols[index] = symbol;
                    index++;
                }


            }


            return allSymbols;

        }




    }
}
