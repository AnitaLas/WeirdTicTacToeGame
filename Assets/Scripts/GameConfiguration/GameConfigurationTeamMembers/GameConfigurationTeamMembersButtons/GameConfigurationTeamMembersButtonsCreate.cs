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

        public static List<GameObject[,,]> GameConfigurationTeamMembersButtonsConstant(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
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

            List < List<GameObject[,,]>> buttonsAll = new List<List<GameObject[,,]>>();

            //int teamNumber = 3;
            //GameObject[,,] buttonTextTeamNumber = GameConfigurationTeamMembersCreateSingleButtonTextWithTeamNumbers(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, teamNumbers);

            //GameObject[,,] buttonNumberTeamMembers = GameConfigurationTeamMembersCreateSingleButtonNumbertWithTeamMembers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);

            List<GameObject[,,]> tablesWithSymbols = new List<GameObject[,,]>();



            List<GameObject[,,]> buttonsTeamSymbols = GameConfigurationTeamMembersCreateFinalTablesWithButtonsSymbols(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, isCellphoneMode, teamNumbers);
            List<GameObject[,,]> buttonsTeamBackgroudTeamNumbers = GameConfigurationTeamMembersCreateFinalButtonsTextWithTeamNumbers(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, isCellphoneMode, teamNumbers);
            List<GameObject[,,]> buttonsTeamNumbers = GameConfigurationTeamMembersCreateFinalButtonsWithTeamNumbers(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, isCellphoneMode, teamNumbers);




            //buttonsAll.Insert(0, buttonsTeamSymbols);








            //buttons: table with numbers to change
            List<GameObject[,,]> tableWithButtonsNumber = new List<GameObject[,,]>();





            buttonsAll.Insert(0, buttonsTeamSymbols);
            buttonsAll.Insert(1, buttonsTeamBackgroudTeamNumbers);
            buttonsAll.Insert(2, buttonsTeamNumbers);



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

            float newCoordinateY = 1f;
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

            float newCoordinateY = 1.3f;
            float newCoordinateX = 1.6f;
            GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtonNumber(button, newCoordinateY, newCoordinateX);

            return button;
        }


        public static List<GameObject[,,]> GameConfigurationTeamMembersCreateFinalTablesWithButtonsSymbols(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D, bool isCellphoneMode ,int teamNumbers)
        {
            //bool isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            Tuple<int, int> tableSize = GameConfigurationTeamMembersButtonsMethods.GetSizeForTableWithDefaulSymbols(isCellphoneMode);

            //string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersTableWithSymbols();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetDefaultButtonNumberForTeamMembers();

            float coordinateY;

            

            for (int i = 0; i < teamNumbers; i++)
            {
                GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.GameConfigurationTeamMembersCreateSingleTableWithButtonsSymbols(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tableSize);

                //coordinateY = 1f;

                if (isCellphoneMode == true)
                {
                   // Debug.Log("isCellphoneMode: " + isCellphoneMode);
                    coordinateY = GameConfigurationTeamMembersButtonsMethods.GetCoordinateYForTableWithSymbols(i);
                }
                else
                {
                    int staticCoordinateY = 2;
                    coordinateY = GameConfigurationTeamMembersButtonsMethods.GetCoordinateYForTableWithSymbols(staticCoordinateY);
                }

                GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersPlayersSymbols(button, coordinateY);

                //int index = i + 1;
                buttonsAll.Insert(i, button);
            }


            //GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.GameConfigurationTeamMembersCreateSingleTableWithButtonsSymbols(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tableSize);

            //float newCoordinateY = 1.3f;
            //float newCoordinateX = 1.6f;
            //GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtonNumber(button, newCoordinateY, newCoordinateX);

            return buttonsAll;

        }


        public static List<GameObject[,,]> GameConfigurationTeamMembersCreateFinalButtonsTextWithTeamNumbers(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D, bool isCellphoneMode, int teamNumbers)
        {
            //bool isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            //Tuple<int, int> tableSize = GameConfigurationTeamMembersButtonsMethods.GetSizeForTableWithDefaulSymbols(isCellphoneMode);

            //string tagName = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersInactiveField();
            string buttonText = GameConfigurationButtonsTeamMembersButtonsName.GetButtonNameForTeam();

            float coordinateY;



            for (int i = 0; i < teamNumbers; i++)
            {
                int numberForTeam = i + 1;
                string buttonTextFinal = $"{buttonText} {numberForTeam}";
                GameObject[,,] button = GameConfigurationTeamMembersCreateSingleButtonTextWithTeamNumbers(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, buttonTextFinal);

                //coordinateY = 1f;

                if (isCellphoneMode == true)
                {
                    // Debug.Log("isCellphoneMode: " + isCellphoneMode);
                    coordinateY = GameConfigurationTeamMembersButtonsMethods.GetCoordinateYForButtonsTextWithTeamNumbers(i);
                }
                else
                {
                    int staticCoordinateY = 2;
                    coordinateY = GameConfigurationTeamMembersButtonsMethods.GetCoordinateYForButtonsTextWithTeamNumbers(staticCoordinateY);
                }

                GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersPlayersSymbols(button, coordinateY);

                //int index = i + 1;
                buttonsAll.Insert(i, button);
            }


            //GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.GameConfigurationTeamMembersCreateSingleTableWithButtonsSymbols(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tableSize);

            //float newCoordinateY = 1.3f;
            //float newCoordinateX = 1.6f;
            //GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtonNumber(button, newCoordinateY, newCoordinateX);

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

                //coordinateY = 1f;

                if (isCellphoneMode == true)
                {
                    // Debug.Log("isCellphoneMode: " + isCellphoneMode);
                    coordinateY = GameConfigurationTeamMembersButtonsMethods.GetCoordinateYForButtonsWithTeamNumbers(i);
                }
                else
                {
                    int staticCoordinateY = 2;
                    coordinateY = GameConfigurationTeamMembersButtonsMethods.GetCoordinateYForButtonsWithTeamNumbers(staticCoordinateY);
                }

                GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersPlayersSymbols(button, coordinateY);

                //int index = i + 1;
                buttonsAll.Insert(i, button);
            }


            //GameObject[,,] button = GameConfigurationTeamMembersButtonsCreateCommon.GameConfigurationTeamMembersCreateSingleTableWithButtonsSymbols(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tableSize);

            //float newCoordinateY = 1.3f;
            //float newCoordinateX = 1.6f;
            //GameConfigurationTeamMembersButtonsMethods.ChangeDataForSingleGameConfigurationTeamMembersButtonNumber(button, newCoordinateY, newCoordinateX);

            return buttonsAll;

        }
    }
}
