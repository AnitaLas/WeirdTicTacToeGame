using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationChangePlayersSymbolsMethods
    {
        public static bool IsSamePlayersNumberInEachTeam(List<string[]> teamGameSymbols)
        {
            int teamsNumbers = teamGameSymbols.Count;
            int[] numbers = { 0, 0 };
            int currentPlayersNumbers = 0;

            bool isSamePlayersNumberInEachTeam = true;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] team = teamGameSymbols[i];
                int playersNumbers = team.Length;

                if (i == 0)
                {
                    currentPlayersNumbers = playersNumbers;
                    numbers[0] = 0;
                }
                else
                {
                    if (currentPlayersNumbers == playersNumbers)
                    {
                        currentPlayersNumbers = playersNumbers;
                        numbers[0] = 0;
                    }
                    else
                    {
                        currentPlayersNumbers = playersNumbers;
                        numbers[1] = 1;
                    }
                }
            }

            int numberEqual = numbers[0];
            int numberNotEqual = numbers[1];
            int result = numberEqual + numberNotEqual;

            if (result == 0)
                isSamePlayersNumberInEachTeam = true;

            else
                isSamePlayersNumberInEachTeam = false;

            return isSamePlayersNumberInEachTeam;
        }

        public static bool SetUpMoveQuantityForTeamsChosenByUser()
        {
            bool isEqualMoveQuantityForBothTeamsSetUpBeUser = true;

            string tagNameForSymbol = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeSymbolEqualMoveQuantity();
            GameObject gameObject = CommonMethods.GetObjectByTagName(tagNameForSymbol);
            string currentSymbol = CommonMethods.GetCubePlayText(gameObject);

            string symbolEqualMoves = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonSymbolForEqualMoveQuantity();
            string symbolNotEqualMoves = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonSymbolForNotEqualMoveQuantity();

            if (currentSymbol == symbolEqualMoves)
            {
                CommonMethods.ChangeTextForCubePlay(gameObject, symbolNotEqualMoves);
                isEqualMoveQuantityForBothTeamsSetUpBeUser = false;
            }
            else
            {
                CommonMethods.ChangeTextForCubePlay(gameObject, symbolEqualMoves);
                isEqualMoveQuantityForBothTeamsSetUpBeUser = true;
            }

            return isEqualMoveQuantityForBothTeamsSetUpBeUser;
        }
    }
}