using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameConfiguration.GameConfigurationChangePlayersSymbolsButtons
{
    internal class GameConfigurationChangePlayersSymbolsMethods
    {

        public static bool IsSamePlayersNumberInEachTeam(List<string[]>  teamGameSymbols)
        {
            int teamsNumbers = teamGameSymbols.Count;
            //int[] numbers = { 0, 0};
            int number = 0;
            bool isSamePlayersNumberInEachTeam = true;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] team = teamGameSymbols[i];
                int playersNumbers = team.Length;
                
                if (i == 0)
                {
                    number = 0;
                }
                else
                {
                    if (playersNumbers != 0)
                    {
                        number = 1;
                    }
                    else
                    {
                        number = 0;
                    }
                }
            }

            if (number == 0)
            {
                isSamePlayersNumberInEachTeam = true;
            }
            else
            {
                isSamePlayersNumberInEachTeam = false;
            }

            return isSamePlayersNumberInEachTeam;

        }


    }
}
