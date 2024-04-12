using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationTeamMembersButtonsCreate
    {

        public static List<GameObject[,,]> GameConfigurationTeamMembersButtonsStatic(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();

            // buttons: save and back
            GameObject[,,] buttonSave = GameConfigurationTeamMembersCreateButtonSave(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationTeamMembersCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            // buttons: top team game/ players
            GameObject[,,] buttonTopTextTeamGame = GameConfigurationTeammMembersCreateButtonTopTeamGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonTopTextNumber = GameConfigurationTeaMembersCreateButtonTopPlayers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);

            buttonsAll.Insert(0, buttonSave);
            buttonsAll.Insert(1, buttonBack);
            buttonsAll.Insert(2, buttonTopTextTeamGame);
            buttonsAll.Insert(3, buttonTopTextNumber);






            return buttonsAll;
        }

        public static List<List<GameObject[,,]>> GameConfigurationTeamMembersButtons(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D, bool isCellphoneMode34, int teamNumbers)
        {
            bool isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();
            //Debug.Log("2 isCellphoneMode: " + isCellphoneMode); 

            List<List<GameObject[,,]>> buttonsAll = new List<List<GameObject[,,]>>();
            


            List<GameObject[,,]> buttonsTeamBackgroudTeamNumbers = GameConfigurationTeamMembersCreateFinalButtonsTextWithTeamNumbers(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, isCellphoneMode, teamNumbers);
            List<GameObject[,,]> buttonsTeamSymbols = GameConfigurationTeamMembersCreateFinalTablesWithButtonsSymbols(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode, teamNumbers);
            List<GameObject[,,]> buttonsTeamNumbers = GameConfigurationTeamMembersCreateFinalButtonsWithTeamNumbers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, isCellphoneMode, teamNumbers);


            buttonsAll.Insert(0, buttonsTeamNumbers);
            buttonsAll.Insert(1, buttonsTeamSymbols);
            buttonsAll.Insert(2, buttonsTeamBackgroudTeamNumbers);


            








            //buttons: table with numbers to change
            //List<GameObject[,,]> tableWithButtonsNumber = new List<GameObject[,,]>();









            return buttonsAll;
           
        }

        // -------------------------------------------------------------------------------------------
        // buttons: save & back
        public static GameObject[,,] GameConfigurationTeamMembersCreateButtonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonSave();
            GameObject[,,] buttonSave = GameConfigurationButtonsCommonCreate.CreateCommonButtonSave(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName);
            return buttonSave;
        }

        public static GameObject[,,] GameConfigurationTeamMembersCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonBack();
            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);
            return buttonBack;
        }

        // -------------------------------------------------------------------------------------------
        // buttons: top: team game, players

        public static GameObject[,,] GameConfigurationTeammMembersCreateButtonTopTeamGame(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetButtonNameForTeamGame();

            GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.CreateCommonButtonForTeamMembersFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 4.35f;
            float newCoordinateX = -0.8f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] GameConfigurationTeaMembersCreateButtonTopPlayers(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {

            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetButtonNameForPlayers();

            GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.CreateCommonButtonForTeamMembersPlayers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 3.9f;
            float newCoordinateX = -0.4f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        // -------------------------------------------------------------------------------------------
        // single buttons : team 1, team 2 , ...

        public static GameObject[,,] GameConfigurationTeamMembersCreateSingleButtonTextWithTeamNumbers(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, string buttonTextFinal)
        {

            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersDefaultNumber();
            //string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetButtonNameForTeam();
            //string buttonTextFinal = $"{buttonText} {teamNumber}";

            GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.CreateCommonButtonForTeamMembersFourRows(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonTextFinal);

            float newCoordinateY = 0f;
            float newCoordinateX = -0.8f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        // single buttons: 2 players, 3 players, ...
        public static GameObject[,,] GameConfigurationTeamMembersCreateSingleButtonNumbertWithTeamMembers(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {

            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersDefaultNumber();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetDefaultButtonNumberForTeamMembers();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 0f;
            float newCoordinateX = 1.6f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtonNumber(button, newCoordinateY, newCoordinateX);

            return button;
        }


        public static List<GameObject[,,]> GameConfigurationTeamMembersCreateFinalTablesWithButtonsSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode ,int teamNumbers)
        {
            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            Tuple<int, int> tableSize = ScreenVerificationMethods.GetSizeForTableWithSymbolsForTeamMembers(isCellphoneMode);

            List<string[]> teamMembersSymbols = GameConfigurationTeamMembersButtonsMethods.CreateTablesWithDefaulSymbols(teamNumbers);



            float coordinateY;
            float coordinateZ;
 
            for (int i = 0; i < teamNumbers; i++)
            {
                GameObject[,,] buttons = GameConfigurationTeamMembersButtonsCreateCommon.GameConfigurationTeamMembersCreateSingleTableWithButtonsSymbols(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tableSize);

                string frontTextToAdd = $"TeamNumber_{i}_";
                string secondTextToAdd = "Symbol_No_";
                GameConfigurationTeamMembersButtonsMethods.ChangeNameForButtonsTeamNumbersPlayersSymbols(buttons, frontTextToAdd, secondTextToAdd);


                string[] symbols = teamMembersSymbols[i];

                GameConfigurationTeamMembersButtonsMethods.SetUpDefaulSymbolsForTeamMembers(buttons, symbols);

                if (isCellphoneMode == true)
                {
                    coordinateY = GameConfigurationButtonsTeamMembersButtonsStaticData.GetCoordinateYForTableWithSymbols(i);
                    coordinateZ = GameConfigurationButtonsTeamMembersButtonsStaticData.GetCoordinateZForTableWithSymbols(i);
                }
                else
                {
                    int staticCoordinateYZ = 2;
                    coordinateY = GameConfigurationButtonsTeamMembersButtonsStaticData.GetCoordinateYForTableWithSymbols(staticCoordinateYZ);
                    coordinateZ = GameConfigurationButtonsTeamMembersButtonsStaticData.GetCoordinateZForTableWithSymbols(staticCoordinateYZ);
                }

                GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembers(buttons, coordinateY);
                GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersPlayersSymbols(buttons, coordinateY, coordinateZ);

                buttonsAll.Insert(i, buttons);
            }

           
            
            return buttonsAll;

        }


        public static List<GameObject[,,]> GameConfigurationTeamMembersCreateFinalButtonsTextWithTeamNumbers(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D, bool isCellphoneMode, int teamNumbers)
        {
            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetButtonNameForTeam();

            float coordinateY;

            for (int i = 0; i < teamNumbers; i++)
            {
                int numberForTeam = i + 1;
                string buttonTextFinal = $"{buttonText} {numberForTeam}";

                GameObject[,,] button = GameConfigurationTeamMembersCreateSingleButtonTextWithTeamNumbers(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, buttonTextFinal);

                if (isCellphoneMode == true)
                {
                    coordinateY = GameConfigurationButtonsTeamMembersButtonsStaticData.GetCoordinateYForButtonsTextWithTeamNumbers(i);
                }
                else
                {
                    int staticCoordinateY = 2;
                    coordinateY = GameConfigurationButtonsTeamMembersButtonsStaticData.GetCoordinateYForButtonsTextWithTeamNumbers(staticCoordinateY);
                }

                GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembers(button, coordinateY);

                buttonsAll.Insert(i, button);
            }

            return buttonsAll;

        }

        public static List<GameObject[,,]> GameConfigurationTeamMembersCreateFinalButtonsWithTeamNumbers(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, bool isCellphoneMode, int teamNumbers)
        {
            //bool isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            //Tuple<int, int> tableSize = GameConfigurationTeamMembersButtonsMethods.GetSizeForTableWithDefaulSymbols(isCellphoneMode);

            //string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersChange();
            //string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetDefaultButtonNumberForTeamMembers();

            float coordinateY;



            for (int i = 0; i < teamNumbers; i++)
            {
                GameObject[,,] button = GameConfigurationTeamMembersCreateSingleButtonNumbertWithTeamMembers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);


                string frontTextToAdd = $"TeamNumber_{i}_";
                string secondTextToAdd = $"NumberOfPlayers_";
                GameConfigurationTeamMembersButtonsMethods.ChangeNameForButtonsTeamNumbersPlayersSymbols(button, frontTextToAdd, secondTextToAdd);


                if (isCellphoneMode == true)
                {
                    // Debug.Log("isCellphoneMode: " + isCellphoneMode);
                    coordinateY = GameConfigurationButtonsTeamMembersButtonsStaticData.GetCoordinateYForButtonsWithTeamNumbers(i);
                }
                else
                {
                    int staticCoordinateY = 2;
                    coordinateY = GameConfigurationButtonsTeamMembersButtonsStaticData.GetCoordinateYForButtonsWithTeamNumbers(staticCoordinateY);
                }

                GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembers(button, coordinateY);

                //int index = i + 1;
                buttonsAll.Insert(i, button);
            }


            //GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.GameConfigurationTeamMembersCreateSingleTableWithButtonsSymbols(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tableSize);

            //float newCoordinateY = 1.3f;
            //float newCoordinateX = 1.6f;
            //GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtonNumber(button, newCoordinateY, newCoordinateX);

            return buttonsAll;

        }

        // -------------------------------------------------------------------------------------------
        // button: back to configuration

        public static GameObject[,,] GameConfigurationTeamMembersButtonBackToConfiguration(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] tableButtonBack;
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonButtonBackToConfiguration();

            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForButtonBack();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonBack = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.75f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonBack, newCoordinateY, tagName);

            string frontTextToAdd = "InformationButtonBackToConfiguration_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(tableButtonBack, frontTextToAdd);

            return tableButtonBack;
        }

        public static GameObject[,,] GameConfigurationTeamMembersButtonsWithNumbers(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode)
        {
            GameObject[,,] buttons = GameConfigurationButtonsWithNumbersForTeamMembers.CreateTableWithNumberForTeamMembers(prefabCubePlay, prefabCubePlayDefaultColour,  isGame2D, isCellphoneMode);
            return buttons;
        }

        public static GameObject[,,] GameConfigurationTeammMembersCreateButtonTopTeamNo(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, int teamNo)
        {
            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetButtonNameForTeam();
            string buttonTextFinal = $"{buttonText} {teamNo}";

            GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.CreateCommonButtonForTeamMembersFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonTextFinal);

            float newCoordinateY = 4.35f;
            float newCoordinateX = -0.8f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static GameObject[,,] GameConfigurationTeaMembersCreateButtonTopPlayersNo(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {

            string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetButtonNameForPlayersNo();

            GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.CreateCommonButtonForTeamMembersPlayers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 3.9f;
            float newCoordinateX = -0.4f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtons(button, newCoordinateY, newCoordinateX);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationTeamMembersButtonBackAndTableWithNumbers(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsDefaultColour, bool isGame2D, string gameObjectName)
        {
            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            bool isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();
            //string teamNo = "3";
            int teamNo = GameConfigurationTeamMembersButtonsMethods.GetTemaNumber(gameObjectName);

            GameObject[,,] buttonBackToConfiguration = GameConfigurationTeamMembersButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
            GameObject[,,] buttonsNumbers = GameConfigurationTeamMembersButtonsWithNumbers(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode);
            GameObject[,,] buttonTopTextTeamNo = GameConfigurationTeammMembersCreateButtonTopTeamNo(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D, teamNo);
            GameObject[,,] buttonTopTextPlayers = GameConfigurationTeaMembersCreateButtonTopPlayersNo(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);


            buttonsAll.Insert(0, buttonBackToConfiguration);
            buttonsAll.Insert(1, buttonsNumbers);
            buttonsAll.Insert(2, buttonTopTextTeamNo);
            buttonsAll.Insert(3, buttonTopTextPlayers);

            return buttonsAll;


        }

    }
}
