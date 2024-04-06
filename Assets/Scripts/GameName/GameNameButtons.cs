using Assets.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameNameButtons
    {

        public static void CreateButtonGameName(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, Material[] prefabCubePlayButtonsNumberColour, Material[] prefabCubePlayButtonsBackColour, bool isGame2D)
        {
            CreateButtonGameNameWeird(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
            CreateButtonGameNameTic(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
            CreateButtonGameNameTac(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D);
            CreateButtonGameNameToe(prefabCubePlay, prefabCubePlayButtonsNumberColour, isGame2D);
            
        }

        public static GameObject[,,] CreateButtonGameNameWeird(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInactiveField(); ;
            string buttonText = GameStartCommonButtonsName.GetButtonNameForWeird();

            GameObject[,,] button = GameNameButtonsCommonCreate.CreateCommonButtonForStartGameFourRows(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 4.35f;
            float newCoordinateX = -0.8f;
            float newCoordinateZ = 0.175f;

            GameNameButtonsCommonMethods.ChangeDataForSingleStargGameButtons(button, newCoordinateY, newCoordinateX, newCoordinateZ);

            //float newCoordinateY2 = 0f;
            //float newCoordinateX2 = 0f;
            //ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY2, newCoordinateX2);


            return button;
        }

        public static GameObject[,,] CreateButtonGameNameTic(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInactiveField(); ;
            string buttonText = GameStartCommonButtonsName.GetButtonNameForTic();

            GameObject[,,] button = GameNameButtonsCommonCreate.CreateCommonButtonForStartGameForGameNameTTT(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 4.2f;
            float newCoordinateX = -0.6f;
            float newCoordinateZ = 0.145f;

            GameNameButtonsCommonMethods.ChangeDataForSingleStargGameButtons(button, newCoordinateY, newCoordinateX, newCoordinateZ);


            //float newCoordinateY2 = 0f;
            //float newCoordinateX2 = 0f;
            //ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY2, newCoordinateX2);

            return button;
        }

        public static GameObject[,,] CreateButtonGameNameTac(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInactiveField(); ;
            string buttonText = GameStartCommonButtonsName.GetButtonNameForTac();

            GameObject[,,] button = GameNameButtonsCommonCreate.CreateCommonButtonForStartGameForGameNameTTT(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);
            
            float newCoordinateY = 3.9f;
            float newCoordinateX = 0.7f;
            float newCoordinateZ = 0.155f;

            GameNameButtonsCommonMethods.ChangeDataForSingleStargGameButtons(button, newCoordinateY, newCoordinateX, newCoordinateZ);


            //float newCoordinateY2 = 0f;
            //float newCoordinateX2 = 0f;
            //ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY2, newCoordinateX2);

            return button;
        }

        public static GameObject[,,] CreateButtonGameNameToe(GameObject prefabCubePlay, Material[] prefabCubePlayDefaultColour, bool isGame2D)
        {
            string tagName = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInactiveField(); ;
            string buttonText = GameStartCommonButtonsName.GetButtonNameForToe();

            GameObject[,,] button = GameNameButtonsCommonCreate.CreateCommonButtonForStartGameForGameNameTTT(prefabCubePlay, prefabCubePlayDefaultColour, isGame2D, tagName, buttonText);

            float newCoordinateY = 4.2f;
            float newCoordinateX = 2.1f;
            float newCoordinateZ = 0.165f;

            GameNameButtonsCommonMethods.ChangeDataForSingleStargGameButtons(button, newCoordinateY, newCoordinateX, newCoordinateZ);


            //float newCoordinateY2 = 0f;
            //float newCoordinateX2 = 0f;
            //ButtonsCommonMethods.ChangeDataForSingleGameConfigurationChangePlayersSymbolsButtons(button, newCoordinateY2, newCoordinateX2);


            return button;
        }




    }
}
