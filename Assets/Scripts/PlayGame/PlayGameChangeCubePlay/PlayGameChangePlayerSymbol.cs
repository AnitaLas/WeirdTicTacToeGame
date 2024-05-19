using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



namespace Assets.Scripts
{
    internal class PlayGameChangePlayerSymbol : MonoBehaviour
    {
        public static void SetUpPlayerSymbol(string playerSymbol, string tagPlayerSymbol)
        {
            GameObject playerSymbolMove = GameCommonMethodsMain.GetObjectByTagName(tagPlayerSymbol);
            GameCommonMethodsMain.ChangeTextForFirstChild(playerSymbolMove, playerSymbol);
        }

        public static void SetUpPlayerSymbolForMoveAtStart(string[] playersSymbols)
        {
            //Dictionary<int, string> tagPlayerSymbolMoveDictionary = GameDictionariesSceneGame.DictionaryTagPlayerSymbolMove();
            //string tagPlayerSymbolCurrent = tagPlayerSymbolMoveDictionary[1];
            //string tagPlayerSymbolPrevious = tagPlayerSymbolMoveDictionary[2];
            //string tagPlayerSymbolNext = tagPlayerSymbolMoveDictionary[3];

            string tagPlayerSymbolCurrent = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolCurrent();
            string tagPlayerSymbolPrevious = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolPrevious();
            string tagPlayerSymbolNext = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolNext();

            // use only when number players = 2
            string defaultSymbol = "-";

            int playersNumber = playersSymbols.Length;
            int indexForPlayerSymbolPrevious = playersSymbols.Length - 1;

            // when players number >= 3 
            string firstPlayerSymbol = playersSymbols[0];
            string secondPlayerSymbol = playersSymbols[1];
            string lastPlayerSymbol = playersSymbols[indexForPlayerSymbolPrevious];

            // SetUpPlayerSymbolCurrent
            SetUpPlayerSymbol(firstPlayerSymbol, tagPlayerSymbolCurrent);

            if (playersNumber >= 3)
            {
                // SetUpPlayerSymbolPrevious
                SetUpPlayerSymbol(lastPlayerSymbol, tagPlayerSymbolPrevious);
                // SetUpPlayerSymbolNext
                SetUpPlayerSymbol(secondPlayerSymbol, tagPlayerSymbolNext);

            } 
            else
            {
                // SetUpPlayerSymbolPrevious
                SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolPrevious);
                // SetUpPlayerSymbolNext
                SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolNext);
            }
        }

        public static string[] CreateTableWithPlayersSymbolsMove(string[] playersSymbols)
        {
            int playersNumber = playersSymbols.Length;

            // 3x cube 
            int playerSymbolMoveLenght = 3;
            string[] playerSymbolMove = new string[playerSymbolMoveLenght];

            // PlayerSymbolCurrent
            playerSymbolMove[1] = playersSymbols[0];

            if (playersNumber >= 3)
            {
                // PlayerSymbolPrevious
                playerSymbolMove[0] = playersSymbols[playersNumber-1];
                // PlayerSymbolNext
                playerSymbolMove[2] = playersSymbols[1];

            }

            return playerSymbolMove;
        }


        public static void ChangePlayerSymbol(string playerSymbol, string tagPlayerSymbolDictionary)
        {
            GameObject playerSymbolMove = GameCommonMethodsMain.GetObjectByTagName(tagPlayerSymbolDictionary);
            GameCommonMethodsMain.ChangeTextForFirstChild(playerSymbolMove, playerSymbol);
        }   

        public static string[] ChangeCurrentPlayersSymbolsMove(string[] playerSymbolMove, string[] playersSymbols, int playersNumberGivenForConfiguration, int[] currentPlayer)
        {
            //Dictionary<int, string> tagPlayerSymbolMoveDictionary = GameDictionariesSceneGame.DictionaryTagPlayerSymbolMove();

            //string tagPlayerSymbolCurrent = tagPlayerSymbolMoveDictionary[1];
            //string tagPlayerSymbolPrevious = tagPlayerSymbolMoveDictionary[2];
            //string tagPlayerSymbolNext = tagPlayerSymbolMoveDictionary[3];

            string tagPlayerSymbolCurrent = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolCurrent();
            string tagPlayerSymbolPrevious = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolPrevious();
            string tagPlayerSymbolNext = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolNext();

            int playerSymbolMoveLenght = 3;
            int currentPlayerNumber = currentPlayer[0];

            string[] newPlayerSymbolMove = new string[playerSymbolMoveLenght];
            string newPlayerSymbolCurrent;
            string newPlayerSymbolPrevious;
            string newPlayerSymbolNext;

            if (playersNumberGivenForConfiguration == 2)
            {            
                if (playersSymbols[0] == playerSymbolMove[1])
                {
                    newPlayerSymbolCurrent = playersSymbols[1];
                    newPlayerSymbolMove[1] = newPlayerSymbolCurrent;
                }
                else
                {
                    newPlayerSymbolCurrent = playersSymbols[0];
                    newPlayerSymbolMove[1] = newPlayerSymbolCurrent;
                }

                ChangePlayerSymbol(newPlayerSymbolCurrent, tagPlayerSymbolCurrent);
            }
            else
            {
                newPlayerSymbolCurrent = playerSymbolMove[2];
                newPlayerSymbolPrevious = playerSymbolMove[1];

                newPlayerSymbolMove[0] = newPlayerSymbolPrevious;
                newPlayerSymbolMove[1] = newPlayerSymbolCurrent;

                ChangePlayerSymbol(newPlayerSymbolCurrent, tagPlayerSymbolCurrent);
                ChangePlayerSymbol(newPlayerSymbolPrevious, tagPlayerSymbolPrevious);

                int nextPlayersSymbolsIndex = currentPlayerNumber + 2;

                if (currentPlayerNumber > 0 && currentPlayerNumber < playersSymbols.Length - 1)
                {
                    if (nextPlayersSymbolsIndex > playersSymbols.Length - 1)
                    {
                        newPlayerSymbolNext = playersSymbols[0];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }
                    else
                    {
                        newPlayerSymbolNext = playersSymbols[currentPlayerNumber + 2];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }
                }
                else
                {
                    if (currentPlayerNumber == playersSymbols.Length - 1)
                    {
                        newPlayerSymbolNext = playersSymbols[1];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }
                    else
                    {
                        newPlayerSymbolNext = playersSymbols[2];
                        newPlayerSymbolMove[2] = newPlayerSymbolNext;
                        ChangePlayerSymbol(newPlayerSymbolNext, tagPlayerSymbolNext);
                    }
                }

                return newPlayerSymbolMove;
            }

            return newPlayerSymbolMove;
        }

        public static void SetUpPlayerSymbolForWinner(bool isWinner, string winnerPlayerSymbol)
        {
            //Dictionary<int, string> tagPlayerSymbolMoveDictionary = GameDictionariesSceneGame.DictionaryTagPlayerSymbolMove();

            //string tagPlayerSymbolCurrent = tagPlayerSymbolMoveDictionary[1];
            //string tagPlayerSymbolPrevious = tagPlayerSymbolMoveDictionary[2];
            //string tagPlayerSymbolNext = tagPlayerSymbolMoveDictionary[3];

            string tagPlayerSymbolCurrent = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolCurrent();
            string tagPlayerSymbolPrevious = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolPrevious();
            string tagPlayerSymbolNext = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolNext();

            string defaultSymbol = "-";

            if (isWinner == true)
            {
                // SetUpPlayerSymbolCurrent
                SetUpPlayerSymbol(winnerPlayerSymbol, tagPlayerSymbolCurrent);
            }
            else
            {
                SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolCurrent);
            }

            // SetUpPlayerSymbolPrevious
            SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolPrevious);
            // SetUpPlayerSymbolNext
            SetUpPlayerSymbol(defaultSymbol, tagPlayerSymbolNext);
        }

        public static void DestroyPlayerMoveCube(string tagName)
        {
            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(tagName);
            Destroy(gameObject);

        }

        public static void DestroyPlayerMoveCubes()
        {
            //string tagPlayerSymbolCurrent = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolCurrent();
            //string tagPlayerSymbolPrevious = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolPrevious();
            //string tagPlayerSymbolNext = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolNext();
            Dictionary<int, string> tagsName = GameDictionariesSceneGame.DictionaryTagsPlayerSymbolMove();
            int numberOfTags = tagsName.Count;

            for (int i = 1; i <= numberOfTags; i++)
            {
                string tagName = tagsName[i];
                DestroyPlayerMoveCube(tagName);
            }


            //DestroyPlayerMoveCube(tagPlayerSymbolCurrent);
            //DestroyPlayerMoveCube(tagPlayerSymbolPrevious);
            //DestroyPlayerMoveCube(tagPlayerSymbolNext);
        }

        public static void CreateButtonsForWinnerTeam(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsNumberColour, string teamNumber, bool isGame2D)
        {
            PlayGameTeamButtonsForEndedGameCreate.CreateButtonGameTeamForTextTeam(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            PlayGameTeamButtonsForEndedGameCreate.CreateButtonGameTeamForTextTeamNumber(prefabCubePlay, prefabCubePlayButtonsNumberColour, teamNumber, isGame2D);

        }

        public static void CreateButtonsForGameOver(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            PlayGameTeamButtonsForEndedGameCreate.CreateButtonGameTeamForTextGame(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            PlayGameTeamButtonsForEndedGameCreate.CreateButtonGameTeamForTextOver(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
        }

        public static string GetTeamWinnerNumber(List<string[]> teamGameSymbols)
        {
            string winnerTeamNumber = "Upss";
            string tagPlayerSymbolPrevious = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagPlayerSymbolPrevious();
            GameObject gameObject = CommonMethods.GetObjectByTagName(tagPlayerSymbolPrevious);
            string previousSymbol = CommonMethods.GetCubePlayText(gameObject);
            Debug.Log("previousSymbol: " + previousSymbol);

            int teamsNumbers = teamGameSymbols.Count;

            for (int i = 0; i < teamsNumbers; i++)
            {
                string[] team = teamGameSymbols[i];
                int playersNumber = team.Length;

                for (int j = 0; j < playersNumber; j++)
                {
                    string symbol = team[j];
                    if (symbol == previousSymbol)
                    {
                        int number = i + 1;
                        winnerTeamNumber = CommonMethods.ConverIntToString(number);
                    }

                }
            }

            Debug.Log("winnerTeamNumber: " + winnerTeamNumber);
            //string teamNumber = gameObjectName.Substring(5,1);
            return winnerTeamNumber;
        }

        public static void CreateButtonsGameTeamForWinner(bool isWinner, GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, List<string[]> teamGameSymbols)
        {
            string teamNumber = GetTeamWinnerNumber(teamGameSymbols);
            
            DestroyPlayerMoveCubes();
            

            if (isWinner == true)
            {
                CreateButtonsForWinnerTeam(prefabCubePlay, prefabCubePlayDefaultColour, prefabCubePlayButtonsNumberColour, teamNumber, isGame2D);
            }
            else
            {
                CreateButtonsForGameOver(prefabCubePlay, prefabCubePlayDefaultColour, prefabCubePlayButtonsNumberColour, isGame2D);
            }

        }
    }
}
