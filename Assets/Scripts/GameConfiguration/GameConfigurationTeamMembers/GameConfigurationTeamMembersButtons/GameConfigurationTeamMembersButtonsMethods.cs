using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsMethods
    {
        
        public static void ChangeDataForSingleGameConfigurationTeamMembersButtons(GameObject[,,] button, float newCoordinateY, float newCoordinateX)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            //float newCoordinateZ = 0.175f;
            float newCoordinateZ = 0.195f;
            float fontSize = 0.7f;
            float newScale = 0.3f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                        //GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagToSetUp);
                    }
                }
            }
        }


        public static void ChangeDataForSingleGameConfigurationTeamMembersButtonNumber(GameObject[,,] button, float newCoordinateY, float newCoordinateX)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            float newCoordinateZ = 0.35f;
            float fontSize = 0.7f;
            float newScale = 0.95f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsMain.TransformGameObjectToNewScale(cubePlay, newScale, newScale, newScale);
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);
                        GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                        GameCommonMethodsMain.ChangeTextFontSize(cubePlay, fontSize);
                    }
                }
            }
        }


        public static void ChangeDataForSingleGameConfigurationTeamMembersPlayersSymbols(GameObject[,,] button, float newCoordinateY, float newCoordinateZ)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            float newCoordinateX = -0.75f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                       GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                       GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                       GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                       GameCommonMethodsSetUpCoordinates.ChangeZForGameObject(cubePlay, newCoordinateZ);

                    }
                }
            }
        }

        public static void ChangeDataForSingleGameConfigurationTeamMembers(GameObject[,,] button, float newCoordinateY)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);

                    }
                }
            }
        }

        public static void ChangeNameForButtonsTeamNumbersPlayersSymbols(GameObject[,,] button, string frontTextToAdd, string secondTextToAdd)
        {
            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);
            //string symbolNo = "Symbol_No_";

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    { 
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        string cubePlayText = CommonMethods.GetCubePlayText(cubePlay);
                        string oldName = GameCommonMethodsMain.GetObjectName(cubePlay);
                        string newName = frontTextToAdd + secondTextToAdd + cubePlayText + "_" + oldName;
                        GameCommonMethodsMain.ChangeGameObjectName(cubePlay, newName);
                    }
                }
            }
        }

        public static List<string[]> CreateTablesWithDefaulSymbols(int teamNumbers)
        {
            List<string[]>  teamMembersSymbols = new List<string[]>();
            string[] symbols = CreateGameBoardCommonMethods.CreateTableWithDefaultPlayerSymbols();
            int index = 0;
            int defaulTeamMembers = 2;

            for (int i = 0; i < teamNumbers; i++)
            {
                string[] tableWithDefaulSymbols = new string[defaulTeamMembers];

                for (int j = 0; j < defaulTeamMembers; j++)
                {
                    string symbol = symbols[index];
                    tableWithDefaulSymbols[j] = symbol;
                    index++;                 
                }

                teamMembersSymbols.Insert(i, tableWithDefaulSymbols);
            }

            return teamMembersSymbols;
        }


        //public static int[] CreateTableWithNumbersToChange(string[] symbols)
        //{
        //    int symbolsLength = symbols.Length;
        //    int[] numbersToChange = new int[symbolsLength];

        //    // create method to create this table!
        //    for (int i = 0; i < symbolsLength; i++)
        //    {
        //        numbersToChange[i] = i;
        //    }

        //    return numbersToChange;
        //}

        public static void SetUpDefaulSymbolsForTeamMembers(GameObject[,,] buttons, string[] symbols)
        {
            string tagNameInactiveField = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();
            string tagNameTableWithSymbols = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersTableWithSymbols();

            string tagName;
            string symbol;
            string staticText = "-";

            int maxIndexDepth = buttons.GetLength(0);
            int maxIndexColumn = buttons.GetLength(2);
            int maxIndexRow = buttons.GetLength(1);

            int symbolsLength = symbols.Length;
            int index = 0;

            //int[] numbersToChange = new int[symbolsLength];

            //// create method to create this table!
            //for (int i = 0; i < symbolsLength; i++)
            //{
            //    numbersToChange[i] = i;
            //}

            //int[] numbersToChange = CreateTableWithNumbersToChange(symbols);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = buttons[indexDepth, indexRow, indexColumn];
                        string cubePlayText = CommonMethods.GetCubePlayText(cubePlay);
                        int cubePlayNumber = CommonMethods.ConvertStringToInt(cubePlayText);

                        for (int i = 0; i < symbolsLength; i++)
                        {
                            if (cubePlayNumber == i)
                            {
                                symbol = symbols[index];
                                index++;
                                tagName = tagNameTableWithSymbols;
                                GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagName);
                                CommonMethods.ChangeTextForFirstChild(cubePlay, symbol);
                                break;
                            }
                            else
                            {
                                symbol = staticText;
                                tagName = tagNameInactiveField;
                                GameCommonMethodsMain.ChangeTagForGameObject(cubePlay, tagName);
                                CommonMethods.ChangeTextForFirstChild(cubePlay, symbol);
                            }   
                        }
                    }
                }
            }          
        }

        // ----

        public static int GetTemaNumber(string gameObjectName)
        {
            int startIndex = 11;
            int length = 1;

            string number = gameObjectName.Substring(startIndex, length);

            int index = CommonMethods.ConvertStringToInt(number);
            int teamNo = index + 1;

            return teamNo;
        }


        public static void ChangeTagForDefaultNumber()
        {
            string tagNameNew = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersDefaultNumber();
            string tagNameOld = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersChange();
            GameObject cubePlay = CommonMethods.GetObjectByTagName(tagNameOld);
            CommonMethods.ChangeTagForGameObject(cubePlay, tagNameNew);
        }

        public static void ChangeTagForChangeNumber(string gameObjectName)
        {
            string tagNameNew = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersChange();
            GameObject cubePlay = CommonMethods.GetObjectByName(gameObjectName);
            CommonMethods.ChangeTagForGameObject(cubePlay, tagNameNew);
        }

        public static void SetUpNewPlayersNumberForTeam(string gameObjectName)
        {
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersChange();
            GameObject teamNumber = CommonMethods.GetObjectByTagName(tagName);

            GameObject choosenNumber = CommonMethods.GetObjectByName(gameObjectName);

            string newNumber = CommonMethods.GetCubePlayText(choosenNumber);
            CommonMethods.ChangeTextForFirstChild(teamNumber, newNumber);
        }

        public static List<List<GameObject[,,]>> CreateListButtonsByTeams(List<List<GameObject[,,]>> buttonsWithTeams,int teamNumbers)
        {
            List<List<GameObject[,,]>> buttonsGroupedByTeams = new List<List<GameObject[,,]>>();

            int buttonAllNumber = buttonsWithTeams.Count;

            for (int i = 0; i < teamNumbers; i++)
            {
                List<GameObject[,,]> TeamGroupList = new List<GameObject[,,]>();

                for (int j = 0; j < buttonAllNumber; j++)
                {
                    List<GameObject[,,]> gameObjects = buttonsWithTeams[j];

                    GameObject[,,] gameObject = gameObjects[i];

                    TeamGroupList.Insert(j, gameObject);
                }

                buttonsGroupedByTeams.Insert(i, TeamGroupList);



            }

            return buttonsGroupedByTeams;
        }

        //public static string[] CreateTablesWithTeamsPlayersChosenSymbols()
        //{

        //}

        public static string GetPlayersNumberForTeam(GameObject[,,] button)
        {
            string number = "hmm";

            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        number = GameCommonMethodsMain.GetCubePlayText(cubePlay);
                    }
                }
            }


            return number;
        }

        // ---
        public static int[] CreateTablesWithTeamNumberOfPlayers(List<List<GameObject[,,]>> buttonsWithTeams)
        {
            int teamNumbers = buttonsWithTeams.Count;
            int[] teamPlayersNumbers = new int[teamNumbers];
            int index = 0; // always for number

           

            for (int l = 0; l < buttonsWithTeams.Count; l++)
                {
                    List<GameObject[,,]> buttonsGroup = buttonsWithTeams[l];
                    GameObject[,,] button = buttonsGroup[index];
                    string numberOfPlayers = GetPlayersNumberForTeam(button);
                    int number = CommonMethods.ConvertStringToInt(numberOfPlayers);
                    teamPlayersNumbers[l] = number;
                    //Debug.Log($"numberOfPlayers: " + numberOfPlayers);
                }
  

                //for (int i = 0; i < teamPlayersNumbers.Length; i++)
                //{
                //    Debug.Log($"teamPlayersNumbers[{i}]: " + teamPlayersNumbers[i]);
                //}


                return teamPlayersNumbers;
        }

        // ---

        public static string[] GetPlayersSymbolsForTeam(GameObject[,,] button)
        {
            int playersNumber= button.Length;
            string[] palyersSymbols = new string[playersNumber];
            string inactiveField = "-";

            int countedInactiveFields = 0;

            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            int index = 0;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        string symbol = GameCommonMethodsMain.GetCubePlayText(cubePlay);

                        if (symbol.Equals(inactiveField))
                        {
                            countedInactiveFields++;
                        }

                        palyersSymbols[index] = symbol;
                        index++;
                    }
                }
            }

            //for (int i = 0; i < palyersSymbols.Length; i++)
            //{
            //    Debug.Log($"palyersSymbols[{i}]: " + palyersSymbols[i]);
            //}

            //--
            int playersSymbolsFinalNumber = playersNumber - countedInactiveFields;

            string[] palyersSymbolsFinal = new string[playersSymbolsFinalNumber];

            for (int i = 0; i < playersSymbolsFinalNumber; i++)
            {
                palyersSymbolsFinal[i] = palyersSymbols[i];
            }


            for (int i = 0; i < palyersSymbolsFinal.Length; i++)
            {
                Debug.Log($"palyersSymbolsFinal[{i}]: " + palyersSymbolsFinal[i]);
            }



            return palyersSymbols;
        }
        public static List<string[]> CreateTablesWithTeamsPlayersSymbols(List<List<GameObject[,,]>> buttonsWithTeams)
        {
            int teamNumbers = buttonsWithTeams.Count;
            string[] teamPlayersNumbers = new string[teamNumbers];
            int index = 1; // always for symbol

            List<string[]> playersSymbolsByTeam = new List<string[]>();

            for (int a = 0; a < buttonsWithTeams.Count; a++)
            {
                List<GameObject[,,]> buttonsGroup = buttonsWithTeams[a];
                GameObject[,,] button = buttonsGroup[index];
                string[] playersSymbols = GetPlayersSymbolsForTeam(button);
                //int number = CommonMethods.ConvertStringToInt(numberOfPlayers);
                playersSymbolsByTeam.Insert( a, playersSymbols);
            }


            //for (int i = 0; i < teamPlayersNumbers.Length; i++)
            //{
            //    Debug.Log($"teamPlayersNumbers[{i}]: " + teamPlayersNumbers[i]);
            //}


            return playersSymbolsByTeam;
        }






    }
}
