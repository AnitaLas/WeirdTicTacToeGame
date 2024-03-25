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

            // buttons with number
            GameObject[,,]  battonRandomlyNumber = GameConfigurationCreateButtonPlayerNumber(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);





           
            buttonsText.Insert(0, buttonRandomlyText);

            
            buttonsNumber.Insert(0, battonRandomlyNumber);


            GameObject gameObjectBase = buttonRandomlyText[0, 0, 0];
            int numberOfButton = buttonsText.Count;

            float[] newYForButtons = GameConfigurationButtonsMethods.GetTableWithNewYForGameConfigurationButtons(gameObjectBase, numberOfButton);

            GameConfigurationButtonsMethods.ChangeDataForGameConfigurationButtons(buttonsText, buttonsNumber, newYForButtons);


            if (isTeamGame == false)
            {
                Debug.Log("Upsss xD");

            }
            else
            {
            }


            buttonsAll.Insert(0, buttonSave);
            buttonsAll.Insert(1, buttonBack);
            buttonsAll.Insert(2, buttonToPlayerSymbol);
            buttonsAll.Insert(3, buttonTopChange);
            buttonsAll.Insert(4, buttonRandomlyText);
            buttonsAll.Insert(5, battonRandomlyNumber);

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

        public static GameObject[,,] GameConfigurationCreateButtonPlayerNumber(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameConfigurationButtonsCommonButtonsTagName.GetTagButtonNumberByTagChangeNumberPlayers();

            string buttonText = GameConfigurationButtonsCommonButtonsDefaultNumber.GetDefaultButtonTimeForChange();

            GameObject[,,] button = GameConfigurationButtonsCommonCreate.CreateCommonButtonForNumber(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            return button;
        }

    }
}
