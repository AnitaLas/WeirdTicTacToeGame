using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

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
            string tagNameTableWithSymbols = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersTableWithTeamSymbols();

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

        public static int GetTeamNumber(string gameObjectName)
        {
            int startIndex = 11; // part of cubePlay name - Unity
            int length = 1;

            string number = gameObjectName.Substring(startIndex, length);

            int index = CommonMethods.ConvertStringToInt(number);
            int teamNo = index + 1;

            return teamNo;
        }

        public static int GetPlayerNumber(string gameObjectName)
        {
            int startIndex = 23; // part of cubePlay name - Unity
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

        public static void ChangeTagForDefaultTeamSymbol()
        {
            string tagNameNew = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersTableWithTeamSymbols();
            string tagNameOld = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersChange();
            GameObject cubePlay = CommonMethods.GetObjectByTagName(tagNameOld);
            CommonMethods.ChangeTagForGameObject(cubePlay, tagNameNew);
        }

        public static void ChangeTagForChangeSymbol(string gameObjectName)
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
                for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
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
           
            string inactiveField = "-";

            int countedInactiveFields = 0;

            int maxIndexDepth = button.GetLength(0);
            int maxIndexColumn = button.GetLength(2);
            int maxIndexRow = button.GetLength(1);

            int playersNumber = maxIndexDepth * maxIndexColumn * maxIndexRow;
            string[] palyersSymbols = new string[playersNumber];

            int index = 0;

            //for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            //{
            //    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
            //    {
            //        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
            //        {
            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexRow = maxIndexRow - 1; indexRow >= 0; indexRow--)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        string symbol = GameCommonMethodsMain.GetCubePlayText(cubePlay);

                        if (symbol.Equals(inactiveField))
                        {
                            countedInactiveFields++;
                        }
                        else
                        {                           
                            palyersSymbols[index] = symbol;
                            index++;
                        }

                        //palyersSymbols[index] = symbol;
                        //index++;
                    }
                }
            }

           // for (int i = 0; i < palyersSymbols.Length; i++)
           // {
            //    Debug.Log($"palyersSymbols[{i}]: " + palyersSymbols[i]);
            //}


            //Debug.Log(" -------------------------------------- ");
            //s--
            int playersSymbolsFinalNumber = playersNumber - countedInactiveFields;

            string[] palyersSymbolsFinal = new string[playersSymbolsFinalNumber];

            for (int i = 0; i < playersSymbolsFinalNumber; i++)
            {
                palyersSymbolsFinal[i] = palyersSymbols[i];
            }


            //for (int i = 0; i < palyersSymbolsFinal.Length; i++)
            //{
            //    Debug.Log($"palyersSymbolsFinal[{i}]: " + palyersSymbolsFinal[i]);
            //}

            //Debug.Log(" -------------------------------------- ");

            return palyersSymbolsFinal;
            //return palyersSymbols;
        }

        // fix string[,,] not string[] !!!!!!!!!!
        //public static List<string[]> CreateTablesWithTeamsPlayersSymbols(List<List<GameObject[,,]>> buttonsGroupByTeams)
        //{
        //    int teamNumbers = buttonsGroupByTeams.Count;
        //    //string[] teamPlayersNumbers = new string[teamNumbers];
        //    int index = 1; // always for symbol

        //    List<string[]> playersSymbolsByTeam = new List<string[]>();

        //    for (int a = 0; a < teamNumbers; a++)
        //    {
        //        List<GameObject[,,]> buttonsGroup = buttonsGroupByTeams[a];


        //        //for (int l = 0; l < buttonsGroupByTeams.Count; l++)
        //        //{




        //            GameObject[,,] button = buttonsGroup[index];


        //            string[] playersSymbols = GetPlayersSymbolsForTeam(button);
        //        //int number = CommonMethods.ConvertStringToInt(numberOfPlayers);


        //        //for (int i = 0; i < playersSymbols.Length; i++)
        //        //{
        //        //    Debug.Log($"palyersSymbolsFinal[{i}]: " + playersSymbols[i]);
        //        //}

        //        //Debug.Log(" -------------------------------------- ");

        //        playersSymbolsByTeam.Insert(a, playersSymbols);
        //        //}










        //    }

        //    //int dddd = playersSymbolsByTeam.Count;
        //    //Debug.Log(" dddd: " + dddd);


        //    //for (int i = 0; i < dddd; i++)
        //    //{
        //    //    string[] table = playersSymbolsByTeam[i];

        //    //    for (int j = 0; j < table.Length; j++)
        //    //    {
        //    //        Debug.Log($"table[{j}]: " + table[j]);

        //    //    }
        //    //    Debug.Log(" ------ ");

        //    //}
        //    //Debug.Log(" -------------------------------------- ");


        //    return playersSymbolsByTeam;
        //}

        // ---


        public static List<string[]> CreateTablesWithTeamsPlayersSymbols(List<List<GameObject[,,]>> buttonsGroupByTeams)
        {
            int teamNumbers = buttonsGroupByTeams.Count;
            
            int indexForListWithSymbols = 1; // always for symbol
            //int indexForSymbol = 0; // always for symbol

            List<string[]> playersSymbolsByTeam = new List<string[]>();

            for (int a = 0; a < teamNumbers; a++)
            {
                List<GameObject[,,]> buttonsGroup = buttonsGroupByTeams[a];

                //GameObject[,,] button = buttonsGroup[index];
                //string[] playersSymbols = GetPlayersSymbolsForTeam(button);
                //playersSymbolsByTeam.Insert(a, playersSymbols);
                GameObject[,,] buttons = buttonsGroup[indexForListWithSymbols];

                int maxIndexDepth = buttons.GetLength(0);
                int maxIndexColumn = buttons.GetLength(2);
                int maxIndexRow = buttons.GetLength(1);

                string[] playersSymbols = GetPlayersSymbolsForTeam(buttons);

                //for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
                //{
                //    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                //    {
                //        for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                //        {
                //            GameObject cubePlay = buttons[indexDepth, indexRow, indexColumn];
                //            string symbol = GameCommonMethodsMain.GetCubePlayText(cubePlay);

                //            playersSymbols[indexForSymbol] = symbol;
                //            indexForSymbol++;

                            
                //        }
                //    }
                //}

                playersSymbolsByTeam.Insert(a, playersSymbols);






            }


            return playersSymbolsByTeam;
        }
        public static void RemoveSymbolsForTeam(GameObject[,,] buttons, int symbolsCounted, int playersNumbers)
        {
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();
            //int numberToChange = symbolsCounted - playersNumbers;
            int index = 0;

            int maxIndexDepth = buttons.GetLength(0);
            int maxIndexRow = buttons.GetLength(1);
            int maxIndexColumn = buttons.GetLength(2);
            

            string inactiveField = "-";
            //Debug.Log("numberToChange:" + numberToChange);

            //for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            //{                  
            //    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
            //    {
            //        for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
            //        {

            //            //Debug.Log("index: " + index);
            //            //Debug.Log("numberToChange: " + numberToChange);
            //            //Debug.Log("playersNumbers : " + (playersNumbers - 0));
            //            //Debug.Log("-----------------------: ");
            //            GameObject cubePlay = buttons[indexDepth, indexRow, indexColumn];

            //            if (index > playersNumbers - 1)
            //            {
            //                //GameObject cubePlay = buttons[indexDepth, indexRow, indexColumn];
            //                CommonMethods.ChangeTextForFirstChild(cubePlay, inactiveField);
            //                CommonMethods.ChangeTagForGameObject(cubePlay, tagName);
            //            }
                       



            //            index++;
            //        }
            //    }
            //}


            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexRow = maxIndexRow - 1; indexRow >= 0; indexRow--)
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {
                        GameObject cubePlay = buttons[indexDepth, indexRow, indexColumn];

                        if (index > playersNumbers - 1)
                        {
                            //GameObject cubePlay = buttons[indexDepth, indexRow, indexColumn];
                            CommonMethods.ChangeTextForFirstChild(cubePlay, inactiveField);
                            CommonMethods.ChangeTagForGameObject(cubePlay, tagName);
                        }




                        index++;
                    }
                }
            }

        }

        // ---


        //public static string[] GetAllTakenSymbols2(string[] tablesWitPlayersChosenSymbols)
        //{
        //    int tablesNumber = tablesWitPlayersChosenSymbols.Count;

        //    --
        //   int allSymbolsLength = 0;

        //    for (int a = 0; a < tablesNumber; a++)
        //    {
        //        int lenght = tablesWitPlayersChosenSymbols[a].Length;
        //        allSymbolsLength = allSymbolsLength + lenght;
        //    }


        //    --
        //    string[] allSymbols = new string[allSymbolsLength];
        //    int index = 0;
        //    for (int a = 0; a < tablesNumber; a++)
        //    {
        //        string[] tableWithSymbols = tablesWitPlayersChosenSymbols[a];
        //        int tableWithSymbolsLength = tableWithSymbols.Length;

        //        for (int l = 0; l < tableWithSymbolsLength; l++)
        //        {
        //            string symbol = tableWithSymbols[l];
        //            allSymbols[index] = symbol;
        //            index++;
        //        }

        //    }

        //    for (int i = 0; i < allSymbols.Length; i++)
        //    {
        //        Debug.Log($"allSymbols[{i}]: " + allSymbols[i]);
        //    }
        //    Debug.Log(" -------------------------------------- ");



        //    return allSymbols;
        //}

        public static string[] GetAllTakenSymbols(List<string[]> tablesWitPlayersChosenSymbols)
        {
            int tablesNumber = tablesWitPlayersChosenSymbols.Count;

            // --
            int allSymbolsLength = 0;

            for (int a = 0; a < tablesNumber; a++)
            {
                int lenght = tablesWitPlayersChosenSymbols[a].Length;
                allSymbolsLength = allSymbolsLength + lenght;
            }


            //--
            string[] allSymbols = new string[allSymbolsLength];
            int index = 0;
            for (int a = 0; a < tablesNumber; a++)
            {
                string[] tableWithSymbols = tablesWitPlayersChosenSymbols[a];
                int tableWithSymbolsLength = tableWithSymbols.Length;

                for (int l = 0; l < tableWithSymbolsLength; l++)
                {
                    string symbol = tableWithSymbols[l];
                    allSymbols[index] = symbol;
                    index++;
                }

            }

            //for (int i = 0; i < allSymbols.Length; i++)
            //{
            //    Debug.Log($"allSymbols[{i}]: " + allSymbols[i]);
            //}
            //Debug.Log(" -------------------------------------- ");



            return allSymbols;
        }

        //public static string GetUntakenSymbols(string[] takenSymbols)
        //{
        //    int takenSymbolsLength = takenSymbols.Length;
        //    string untakenSymbols = PlayGameCommonPlayersSymbols.GetStringWithAllSymbols();

        //    for (int i = 0; i < takenSymbolsLength; i++)
        //    {
        //        string takenSymbol = takenSymbols[i];
        //        int index = untakenSymbols.IndexOf(takenSymbol);
        //        string newString = untakenSymbols.Remove(index, 1);
        //        untakenSymbols = newString;
        //    }

        //    return untakenSymbols;
        //}


        public static string GetUntakenSymbols(string[] takenSymbols)
        {
            int takenSymbolsLength = takenSymbols.Length;
            string untakenSymbols = PlayGameCommonPlayersSymbols.GetStringWithAllSymbols();

            for (int i = 0; i < takenSymbolsLength; i++)
            {
                string takenSymbol = takenSymbols[i];
                int index = untakenSymbols.IndexOf(takenSymbol);
                string newString = untakenSymbols.Remove(index, 1);
                untakenSymbols = newString;
            }

            return untakenSymbols;
        }

        public static int GetRandomStartIndexForSymbol(int maxNumber)
        {
            int minNumber = 0;
            int randomNumber = CommonMethods.ChooseRandomNumber(minNumber, maxNumber);
            return randomNumber;
        }

        public static string[] GetSymbolsForChange(string symbols, int numberSymbolsToChange)
        {
            int symbolsLength = symbols.Length;
            string[] symbolsForChange = new string[numberSymbolsToChange];
            int randomIndex = symbolsLength;
            //Debug.Log("randomIndex: " + randomIndex);

            for (int i = 0; i < numberSymbolsToChange; i++)
            {
                int startIndex = GetRandomStartIndexForSymbol(randomIndex);
                //Debug.Log("startIndex: " + startIndex);
                randomIndex--;

                string symbol = symbols.Substring(startIndex, 1);

                symbolsForChange[i] = symbol;

                symbols = symbols.Remove(startIndex, 1);

            }
            return symbolsForChange;
        }



        // PlayGameChangePlayersSymbolsComnonMethods - add one class for that method
        public static string[] GetNewDefaultSymbols(string[] takenSymbolsAll, int symbolsCounted, int playersNumbers)
        {
            int newSymbolsNumber = playersNumbers - symbolsCounted;
            

            //string[] allSymbols = CreateGameBoardCommonMethods.CreateTableWithCharactersByGivenString();

            string untakenSymbools = GetUntakenSymbols(takenSymbolsAll);
            string[] newDefaulSymbol = GetSymbolsForChange(untakenSymbools, newSymbolsNumber);



            return newDefaulSymbol;
        }

        public static string[,,] CreateTableForDefaultTextWithCharacters(string[] tableWithCharacters, int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];
            string stringAlphabet;

            int tableLenght = tableWithCharacters.Length;
            int[] index = new int[1];
            index[0] = 0;
            int currentIndex;

            for (int indexDepth = 0; indexDepth < numberOfDepths; indexDepth++)
            {
                for (int indexRow = numberOfRows - 1; indexRow >= 0; indexRow--)
                {
                    for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                    {
                        currentIndex = index[0];

                        if (currentIndex >= tableLenght)
                        {
                            stringAlphabet = "-";
                           // stringAlphabet = "11";
                        }
                        else
                        {
                            stringAlphabet = tableWithCharacters[currentIndex];
                        }
                        newTable[indexDepth, indexRow, indexColumn] = stringAlphabet;

                        index[0] = index[0] + 1;
                    }
                }
            }




            return newTable;
        }

        public static string[,,] CreateTableWithTextForPrefabCubePlay(string[] symbols,int numberOfDepths, int numberOfRows, int numberOfColumns)
        {
            string[,,] newTable = new string[numberOfDepths, numberOfRows, numberOfColumns];

            //string[] alphabet = CreateGameBoardCommonMethods.CreateTableWithCharactersByGivenString();
            //string[] alphabet = CreateGameBoardCommonMethods.CreateTableWithCharactersByGivenString();

            string[,,] alphabet3D = CreateTableForDefaultTextWithCharacters(symbols, numberOfDepths, numberOfRows, numberOfColumns);

            for (int indexDepth = 0; indexDepth < numberOfDepths; indexDepth++)
            {
                for (int indexRow = 0; indexRow < numberOfRows; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < numberOfColumns; indexColumn++)
                    {
                        string stringNumber = alphabet3D[indexDepth, indexRow, indexColumn];
                        newTable[indexDepth, indexRow, indexColumn] = stringNumber;
                    }
                }
            }

            //for (int i = 0; i < newTable.GetLength(0); i++)
            //{
            //    for (int j = 0; j < newTable.GetLength(1); j++)
            //    {
            //        for (int z = 0; z < newTable.GetLength(2); z++)
            //        {

            //            Debug.Log($"newTable[{i}, {j}, {z}] : " + newTable[i, j, z]);

            //        }
            //    }
            //}

            return newTable;
        }

       public static void AddDefaultSymbolsForTeam(GameObject[,,] buttons, int symbolsCounted, int playersNumbers, string[] takenSymbols, List<string[]> tablesWitPlayersChosenSymbols)      
       {
            string tagName= GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersTableWithTeamSymbols();
            //int numberToChange = playersNumbers - symbolsCounted;
            //int index = 0 + numberToChange;
            int index = 0;
            int indexNewSymbols = 0;
            //int indexSymbolsCounted = symbolsCounted - 1;
            //int ddddd = playersNumbers - 1;


            //Debug.Log("index: " + index);
            //Debug.Log("indexSymbolsCounted: " + indexSymbolsCounted);
            //Debug.Log("ddddd: " + ddddd);

            string inactiveField = "AL";


            string[] takenSymbolsAll = GetAllTakenSymbols(tablesWitPlayersChosenSymbols);


            string[] untakenSymobls = GetNewDefaultSymbols(takenSymbolsAll, symbolsCounted, playersNumbers);
            //string[] untakenSymobl = { "z", "z2", "z3"};
            int untakenSymoblsLength = untakenSymobls.Length;
            int untakenSymoblsIndex = 0;

            int takenSymbolsLength = takenSymbols.Length;
            int takenSymbolsIndex = 0;

            int newSymbolsLength = untakenSymoblsLength + takenSymbolsLength;
            string[] newSymbols = new string[newSymbolsLength];

            //Debug.Log($"takenSymbolsLength: " + takenSymbolsLength);
            //Debug.Log($"untakenSymoblsLength: " + untakenSymoblsLength);
            //Debug.Log($"newSymbolsLength: " + newSymbolsLength);
            //Debug.Log($" ---------------------------------- ");

            for (int i = 0; i < newSymbolsLength; i++)
            {
                //Debug.Log($"indexNewSymbols: " + indexNewSymbols);
                //Debug.Log($"i: " + i);

                if (takenSymbolsIndex < takenSymbolsLength)
                {
                    //Debug.Log($"untakenSymoblsIndex: " + untakenSymoblsIndex);
                    newSymbols[i] = takenSymbols[takenSymbolsIndex];
                    takenSymbolsIndex++;
                }
                else
                {
                    newSymbols[i] = untakenSymobls[untakenSymoblsIndex];
                    untakenSymoblsIndex++;
                }


                //indexNewSymbols++;
            }


            //Debug.Log($" ---------------------------------- ");
            //for (int i = 0; i < newSymbols.Length; i++)
            //{
            //    Debug.Log($"newSymbols[{i}] : " + newSymbols[i]);
            //}

            int maxIndexDepth = buttons.GetLength(0);
            int maxIndexColumn = buttons.GetLength(2);
            int maxIndexRow = buttons.GetLength(1);

            //Debug.Log("maxIndexDepth: " + maxIndexDepth);
            //Debug.Log("maxIndexColumn: " + maxIndexColumn);
            //Debug.Log("maxIndexRow: " + maxIndexRow);

            //string[] untakenSymobl2 = { "z", "z2", "z3", "z4"};

            //string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(untakenSymobl, maxIndexDepth, maxIndexRow, maxIndexColumn);
            string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(newSymbols, maxIndexDepth, maxIndexRow, maxIndexColumn);
            //string[,,] defaultTextForPrefabCubePlay = CreateTableWithTextForPrefabCubePlay(untakenSymobl2, 1, 3, 3);

           

            //int maxIndexDepth = buttons.GetLength(0);
            //int maxIndexColumn = buttons.GetLength(2);
            //int maxIndexRow = buttons.GetLength(1);



            
            //Debug.Log("numberToChange:" + numberToChange);

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)             
                {
                    for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                    {

                        //Debug.Log("index: " + index);
                        //Debug.Log("symbolsCounted - 1: " + (symbolsCounted - 1));
                        //Debug.Log("playersNumbers - 1: " + (playersNumbers - 1));
                        //Debug.Log("-----------------------: ");

                        //if (index > symbolsCounted - 1 && index  < playersNumbers)
                        //{ 
                        //    //string newSymbol = untakenSymobl[indexNewSymbol];
                        //    //GameObject cubePlay = buttons[indexDepth, indexRow, indexColumn];
                        //    ////CommonMethods.ChangeTextForFirstChild(cubePlay, inactiveField);
                        //    //CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                        //    //CommonMethods.ChangeTagForGameObject(cubePlay, tagName);
                        //    //indexNewSymbol++;



                        //    string newSymbol = defaultTextForPrefabCubePlay[indexDepth, indexRow, indexColumn];
                        //    GameObject cubePlay = buttons[indexDepth, indexRow, indexColumn];
                        //    //CommonMethods.ChangeTextForFirstChild(cubePlay, inactiveField);
                        //    CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                        //    CommonMethods.ChangeTagForGameObject(cubePlay, tagName);
                        //    indexNewSymbol++;
                        //}




                        //index++;





                        string newSymbol = defaultTextForPrefabCubePlay[indexDepth, indexRow, indexColumn];
                        GameObject cubePlay = buttons[indexDepth, indexRow, indexColumn];
                        //CommonMethods.ChangeTextForFirstChild(cubePlay, inactiveField);
                        CommonMethods.ChangeTextForFirstChild(cubePlay, newSymbol);
                        CommonMethods.ChangeTagForGameObject(cubePlay, tagName);
                    }
                }
            }


        }

        public static void SetUpRightSymbolsForTeam(List<List<GameObject[,,]>> buttonsGroupByTeams, int[] tablesWitPlayersNumbersForTeams, List<string[]> tablesWitPlayersChosenSymbols)
        {
            int listIndex = 1; // symbols
            
            int teamsNumbers = tablesWitPlayersNumbersForTeams.Length;
            int teamsNumbersBySymbols = tablesWitPlayersChosenSymbols.Count;

            for (int teamNumber = 0; teamNumber < teamsNumbers; teamNumber++)
            {
                List<GameObject[,,]> buttonsGroups = buttonsGroupByTeams[teamNumber];

                GameObject[,,] buttons = buttonsGroups[listIndex];

                int playersNumbers = tablesWitPlayersNumbersForTeams[teamNumber];
                // Debug.Log($"playersNumbers: " + playersNumbers);
                //Debug.Log($" ---------------------------------- ");

                string[] symbols = tablesWitPlayersChosenSymbols[teamNumber];
                int symbolsCounted = symbols.Length;

                //Debug.Log($"symbolsCounted: " + symbolsCounted);
                //Debug.Log($" ---------------------------------- ");

                if (playersNumbers != symbolsCounted)
                {
                    if(playersNumbers < symbolsCounted)
                    {
                        RemoveSymbolsForTeam(buttons, symbolsCounted, playersNumbers);    
                    }

                    else
                    {

                        AddDefaultSymbolsForTeam(buttons, symbolsCounted, playersNumbers, symbols, tablesWitPlayersChosenSymbols);

                    }
                }
            }
        }







    }
}
