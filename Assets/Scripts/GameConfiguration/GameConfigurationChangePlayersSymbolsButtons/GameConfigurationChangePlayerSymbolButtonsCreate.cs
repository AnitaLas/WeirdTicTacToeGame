using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationChangePlayerSymbolButtonsCreate
    {
        public static List<GameObject[,,]> GameConfigurationChangePlayerSymbolCreateButtons(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D, bool isTeamGame)
        {
            List<GameObject[,,]> buttonsText = new List<GameObject[,,]>();
            List<GameObject[,,]> buttonsNumber = new List<GameObject[,,]>();
            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();

            // button save and back
            GameObject[,,] buttonSave = GameConfigurationChangePlayerSymbolCreateButtonSave(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationChangePlayerSymbolCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
            GameObject[,,] buttonToPlayerSymbol = GameConfigurationChangePlayerSymbolCreateButtonTopPlayerSymbol(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonTopChange = GameConfigurationChangePlayerSymbolCreateButtonTopChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);

            // buttons with text
            GameObject[,,] buttonRandomlyText = GameConfigurationChangePlayerSymbolCreateButtonChangeRandomlyText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonForAllText = GameConfigurationChangePlayerSymbolCreateButtonChangeForAllText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);

            // buttons with number
            GameObject[,,]  battonRandomlyNumber = GameConfigurationCreateButtonChangeRandomlyNumber(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
            GameObject[,,]  battonForAllNumber = GameConfigurationCreateButtonChangeForAllNumber(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);





           
            buttonsText.Insert(0, buttonRandomlyText);
            buttonsText.Insert(1, buttonForAllText);

            
            buttonsNumber.Insert(0, battonRandomlyNumber);
            buttonsNumber.Insert(1, battonForAllNumber);


            GameObject gameObjectBase = buttonRandomlyText[0, 0, 0];
            int numberOfButton = buttonsText.Count;

            float[] newYForButtons = GameConfigurationButtonsMethods.GetTableWithNewYForGameConfigurationButtons(gameObjectBase, numberOfButton);

            GameConfigurationButtonsMethods.ChangeDataForGameConfigurationButtons(buttonsText, buttonsNumber, newYForButtons);

            buttonsAll.Insert(0, buttonSave);
            buttonsAll.Insert(1, buttonBack);
            buttonsAll.Insert(2, buttonToPlayerSymbol);
            buttonsAll.Insert(3, buttonTopChange);
            buttonsAll.Insert(4, buttonRandomlyText);
            buttonsAll.Insert(5, battonRandomlyNumber);
            buttonsAll.Insert(5, buttonForAllText);
            buttonsAll.Insert(6, battonForAllNumber);


            if (isTeamGame == false)
            {
                Debug.Log("Upsss xD");

            }
            else
            {
            }




            return buttonsAll;
        }

        // -------------------------------------------------------------------------------------------
        // buttons: save & back
        public static GameObject[,,] GameConfigurationChangePlayerSymbolCreateButtonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonChangePlayersSymbolsButtonSave();
            GameObject[,,] buttonSave = GameConfigurationButtonsCommonCreate.CreateCommonButtonSave(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName);
            return buttonSave;
        }

        public static GameObject[,,] GameConfigurationChangePlayerSymbolCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonChangePlayersSymbolsButtonBack();
            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);
            return buttonBack;
        }

        // -------------------------------------------------------------------------------------------
        // buttons: top: player symbols & change
        public static GameObject[,,] GameConfigurationChangePlayerSymbolCreateButtonTopPlayerSymbol(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameToPlayersSymbols();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopPlayersSymbols_";
            float newCoordinateY = 4f;
            float newCoordinateX = -0.8f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static GameObject[,,] GameConfigurationChangePlayerSymbolCreateButtonTopChange(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameTopChange();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = 3.55f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        // button: common: more information

        public static GameObject[,,] GameConfigurationChangePlayerSymbolCreateButtonTopCommonInformation(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameTimeInSeconds();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopPlayersSymbols_";
            float newCoordinateY = 4f;
            float newCoordinateX = -0.8f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }


        // button back to configuration 
        public static GameObject[,,] GameConfigurationCreateButtonBackToConfiguration(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] tableButtonBack;

            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForButtonBack();
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonBackByTagButtonBackToConfigurationChangePlayersSymbols();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonBack = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.75f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonBack, newCoordinateY, tagName);

            return tableButtonBack;
        }

        // button ramdomly
        public static GameObject[,,] GameConfigurationChangePlayerSymbolCreateButtonChangeRandomlyText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameChangeRandomly();
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonChangeRandomly();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ChangeRandomly_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonChangeRandomlyNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberRandomly();
            string buttonText = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonTimeForChange();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }

        public static GameObject[,,] CreateTableForRandomlyWithTime(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberRandomly();

            int numberOfDepths = 1;
            int numberOfRows = 4;
            int numberOfColumns = 4;

            tableWithNumbers = GameConfigurationButtonsWithNumbersForChangeRandomly.CreateTableWithTime(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = GameConfigurationButtonsWithNumbersForChangeRandomly.ChangeDataForTableWithTime(tableWithNumbers, tagName);

            return tableWithNumberFinal;
        }

        public static GameObject[,,] GameConfigurationChangePlayerSymbolCreateButtonTopRandomly(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameChangeRandomlyForInformation();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = 3.55f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndRandomly(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            GameObject[,,] buttonTopInformation = GameConfigurationChangePlayerSymbolCreateButtonTopCommonInformation(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonTopRandomly = GameConfigurationChangePlayerSymbolCreateButtonTopRandomly(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonTopInformation);
            buttonsAll.Insert(1, buttonTopRandomly);
            buttonsAll.Insert(2, buttonBack);

            return buttonsAll;
        }

        // button for all
        public static GameObject[,,] GameConfigurationChangePlayerSymbolCreateButtonChangeForAllText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameChangeAll();
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonChangForAll();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ChangeForAll_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonChangeForAllNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberForAll();
            string buttonText = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonTimeForChange();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }

        public static GameObject[,,] CreateTableForForAllWithTime(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            GameObject[,,] tableWithNumbers;
            GameObject[,,] tableWithNumberFinal;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberForAll();

            int numberOfDepths = 1;
            int numberOfRows = 4;
            int numberOfColumns = 4;

            tableWithNumbers = GameConfigurationButtonsWithNumbersForChangeRandomly.CreateTableWithTime(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberFinal = GameConfigurationButtonsWithNumbersForChangeRandomly.ChangeDataForTableWithTime(tableWithNumbers, tagName);

            return tableWithNumberFinal;
        }

        public static GameObject[,,] GameConfigurationChangePlayerSymbolCreateButtonTopForAll(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            //GameObject[,,] buttons;

            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameChangeForAllForInformation();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForChangePlayersSymbolsChange(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D, tagName, buttonText);

            //string frontTextToAdd = "InformationButtonTopChange_";
            float newCoordinateY = 3.55f;
            float newCoordinateX = -0.4f;
            ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY, newCoordinateX);

            //ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndForAll(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D)
        {
            GameObject[,,] buttonTopInformation = GameConfigurationChangePlayerSymbolCreateButtonTopCommonInformation(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonTopRandomly = GameConfigurationChangePlayerSymbolCreateButtonTopForAll(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonTopInformation);
            buttonsAll.Insert(1, buttonTopRandomly);
            buttonsAll.Insert(2, buttonBack);

            return buttonsAll;
        }






    }
}
