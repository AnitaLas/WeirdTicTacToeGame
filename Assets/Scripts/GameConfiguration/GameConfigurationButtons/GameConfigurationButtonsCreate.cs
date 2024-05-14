using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    internal class GameConfigurationButtonsCreate
    {

        public static int[] GetNextIndex(int startIndex)
        {
            int[] result = new int[4];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i + startIndex;
            }

            return result;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtons(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsDefaultColour, Material[] prefabCubePlayButtonsBackColour, Material[] prefabCubePlayButtonsNumberColour, bool isGame2D, bool isTeamGame)
        {
            List<GameObject[,,]> buttonsText = new List<GameObject[,,]>();
            List<GameObject[,,]> buttonsNumber = new List<GameObject[,,]>();
            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();


            // buttons with text
            //GameObject[,,] battonPlayerText = GameConfigurationCreateButtonPlayerText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonPlayerText; //= GameConfigurationCreateButtonPlayerText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonRowText = GameConfigurationCreateButtonRowText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonColumnText = GameConfigurationCreateButtonColumnText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonLenghtToCheckText = GameConfigurationCreateButtonLenghtToCheckText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonGapText = GameConfigurationCreateButtonGapText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);

            // buttons with number
            //GameObject[,,] battonPlayerNumber = GameConfigurationCreateButtonPlayerNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonPlayerNumber; // = GameConfigurationCreateButtonPlayerNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonRowNumber = GameConfigurationCreateButtonRowNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonColumnNumber = GameConfigurationCreateButtonColumnNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonLenghtToCheckNumber = GameConfigurationCreateButtonLenghtToCheckNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] battonGapNumber = GameConfigurationCreateButtonGapNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);


            int index = 0;

            Debug.Log("BUTTON isTeamGame : " + isTeamGame);
            if (isTeamGame == false)
            {
                battonPlayerText = GameConfigurationCreateButtonPlayerText(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
                buttonsText.Insert(index, battonPlayerText);

                battonPlayerNumber = GameConfigurationCreateButtonPlayerNumber(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
                buttonsNumber.Insert(index, battonPlayerNumber);

                index = index + 1;

            }

            int[] nextIndex = GetNextIndex(index);
            int indexRow = nextIndex[0];
            int indexColumn = nextIndex[1];
            int indexLenghtToCheck = nextIndex[2];
            int indexGap = nextIndex[3];


            
            //buttonsText.Insert(0, battonPlayerText);
            buttonsText.Insert(indexRow, battonRowText);
            buttonsText.Insert(indexColumn, battonColumnText);
            buttonsText.Insert(indexLenghtToCheck, battonLenghtToCheckText);
            buttonsText.Insert(indexGap, battonGapText);

           

            // buttons with number

            
            //buttonsNumber.Insert(0, battonPlayerNumber);
            buttonsNumber.Insert(indexRow, battonRowNumber);
            buttonsNumber.Insert(indexColumn, battonColumnNumber);
            buttonsNumber.Insert(indexLenghtToCheck, battonLenghtToCheckNumber);
            buttonsNumber.Insert(indexGap, battonGapNumber);






            ButtonsCommonMethods.ChangeColourForButtonsWithNumbers(buttonsNumber, prefabCubePlayButtonsNumberColour);

            //GameObject gameObjectBase = battonPlayerText[0, 0, 0];
            GameObject gameObjectBase = battonRowNumber[0, 0, 0];
            int numberOfButton = buttonsText.Count;

            float[] newYForButtons = GameConfigurationButtonsMethods.GetTableWithNewYForGameConfigurationButtons(gameObjectBase, numberOfButton);

            GameConfigurationButtonsMethods.ChangeDataForGameConfigurationButtons(buttonsText, buttonsNumber, newYForButtons);


            if (isTeamGame == true)
            {

                GameConfigurationButtonsMethods.ChangeCoordinateYForTeamGameButtons(buttonsText, buttonsNumber);

            }
            
            
            // button save and back
            GameObject[,,] buttonSave = GameConfigurationCreateButtonSave(prefabCubePlay, prefabCubePlayButtonsDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            ////List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            ////buttonsAll.Insert(0, battonPlayerText);
            //buttonsAll.Insert(0, battonRowText);
            //buttonsAll.Insert(1, battonColumnText);
            //buttonsAll.Insert(2, battonLenghtToCheckText);
            ////buttonsAll.Insert(4, battonPlayerNumber);
            //buttonsAll.Insert(3, battonRowNumber);
            //buttonsAll.Insert(4, battonColumnNumber);
            //buttonsAll.Insert(5, battonLenghtToCheckNumber);
            //buttonsAll.Insert(6, buttonSave);
            //buttonsAll.Insert(7, buttonBack);
            //buttonsAll.Insert(8, battonGapText);
            //buttonsAll.Insert(9, battonGapNumber);

            //if (isTeamGame == false)
            //{
            //    buttonsAll.Insert(10, battonPlayerText);
            //    buttonsAll.Insert(11, battonPlayerNumber);
            //}

            buttonsAll.Insert(0, buttonSave);
            buttonsAll.Insert(1, buttonBack);

            List<List<GameObject[,,]>> configurationButtons = new List<List<GameObject[,,]>>();

            configurationButtons.Insert(0, buttonsText);
            configurationButtons.Insert(1, buttonsNumber);

            int startIndex = 2; // because buttons save & back

            for (int a = 0; a < configurationButtons.Count; a++)
            {
                List<GameObject[,,]> buttonsType = configurationButtons[a];

                for (int l = 0; l < buttonsType.Count; l++)
                {
                    GameObject[,,] button = buttonsType[l];
                    buttonsAll.Insert(startIndex, button);
                    startIndex++;
                }

                


            }

            return buttonsAll;
        }

        // ---

        public static GameObject[,,] GameConfigurationCreateButtonSave(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //int dictionatyId = 1;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonSaveByTagButtonSave();

            GameObject[,,] buttonSave = GameConfigurationButtonsCommonCreate.CreateCommonButtonSave(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName);
            return buttonSave;
        }

        public static GameObject[,,] GameConfigurationCreateButtonBack(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            //int dictionatyId = 2;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonSaveByTagButtonBack();

            GameObject[,,] buttonBack = GameConfigurationButtonsCommonCreate.CreateCommonButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D, tagName);
            return buttonBack;
        }

        public static GameObject[,,] GameConfigurationCreateButtonBackToConfiguration(GameObject prefabCubePlay, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] tableButtonBack;

            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForButtonBack();

            //int dictionatyId = 21;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonSaveByTagButtonBackToConfiguration();
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonBackByTagButtonBackToConfiguration();

            int numberOfDepths = 1;
            int numberOfRows = 3;
            int numberOfColumns = 14;

            string[] tableWithTextForButtonNewGame = ButtonsText.CreateTableWithButtonNameForGame(numberOfRows, numberOfColumns, buttonText);

            tableButtonBack = ButtonsCommonMethods.CreateSingleConfigurationButton(prefabCubePlay, numberOfDepths, numberOfRows, numberOfColumns, prefabCubePlayButtonsBackColour, isGame2D, tableWithTextForButtonNewGame);

            float newCoordinateY = -4.75f;
            ButtonsCommonMethods.ChangeDataForSingleGameButtons(tableButtonBack, newCoordinateY, tagName);

            return tableButtonBack;
        }
        // --- buttons with text 

        public static GameObject[,,] GameConfigurationCreateButtonPlayerText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForPlayers();

            //int dictionatyId = 9;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNameByTagPlayers();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonPlayer_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);
            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonRowText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //int dictionatyId = 5;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNameByTagRows();

            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForRows();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonRow_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonColumnText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //int dictionatyId = 6;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNameByTagColumns();

            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForColumns();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonColumn_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonLenghtToCheckText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //int dictionatyId = 12;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNameByTagLenghtToCheck();

            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForLenghtToCheck();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonLenghtToCheck_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonGapText(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //int dictionatyId = 15;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNameByTagGaps();

            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForGaps();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "ButtonGaps_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            return button;
        }

        // --- buttons with number
        public static GameObject[,,] GameConfigurationCreateButtonPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //int dictionatyId = 10;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberPlayers();

            string buttonText = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonNumberForPlayers();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonRowNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //int dictionatyId = 7;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberRows();

            string buttonText = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonNumberForRowsAndColumns();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button; ;
        }

        public static GameObject[,,] GameConfigurationCreateButtonColumnNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //int dictionatyId = 8;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberColumns();

            string buttonText = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonNumberForRowsAndColumns();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button; ;
        }

        public static GameObject[,,] GameConfigurationCreateButtonLenghtToCheckNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //int dictionatyId = 13;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberLenghtToCheck();

            string buttonText = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonNumberForLenghtToCheck();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }

        public static GameObject[,,] GameConfigurationCreateButtonGapNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            //int dictionatyId = 16;
            //string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameFromDictionaryTagConfigurationBoardGame(dictionatyId);
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberGaps();

            string buttonText = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonNumberForGaps();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }

        // --- information buttons

        public static GameObject[,,] GameConfigurationCreateInformationButtonPlayer(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForPlayers();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonPlayer_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button; 
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndPlayer(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] buttonInformation = GameConfigurationCreateInformationButtonPlayer(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBack =  GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonInformation);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;
        }


        public static GameObject[,,] GameConfigurationCreateInformationButtonRow(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForRows();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonRow_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndRow(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] buttonInformation = GameConfigurationCreateInformationButtonRow(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonInformation);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;
        }

        public static GameObject[,,] GameConfigurationCreateInformationButtonColumns(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForColumns();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonColumn_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndColumn(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] buttonInformation = GameConfigurationCreateInformationButtonColumns(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonInformation);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;
        }


        public static GameObject[,,] GameConfigurationCreateInformationButtonlenghtToCheck(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInformation();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForLenghtToCheck();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonLenghtToCheck_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndLenghtToCheck(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] buttonInformation = GameConfigurationCreateInformationButtonlenghtToCheck(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonInformation);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;
        }

        public static GameObject[,,] GameConfigurationCreateInformationButtonGaps(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagNameForInactiveField();
            string buttonText = GameConfigurationButtonsCommonButtonsName.GetButtonNameForGaps();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForText(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            string frontTextToAdd = "InformationButtonGaps_";
            ButtonsCommonMethods.ChangeNameForGameConfigurationButtons(button, frontTextToAdd);

            ButtonsGameConfigurationMethods.ChangeDataForGameConfigurationButtonsInformation(button);

            return button;
        }

        public static List<GameObject[,,]> GameConfigurationCreateButtonsBackAndGaps(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            GameObject[,,] buttonInformation = GameConfigurationCreateInformationButtonGaps(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            GameObject[,,] buttonBack = GameConfigurationCreateButtonBackToConfiguration(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);

            List<GameObject[,,]> buttonsAll = new List<GameObject[,,]>();
            buttonsAll.Insert(0, buttonInformation);
            buttonsAll.Insert(1, buttonBack);

            return buttonsAll;
        }
    }
}
