using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameNameTextCreate : MonoBehaviour
    {
        public static void CreateGameNameForStart(GameObject objectWithtext)
        {
            float newCoordinateY = 4;
            CreateGameNameText(objectWithtext);
            ChangeDataForGameName(newCoordinateY);
        }

        public static void CreateGameNameForGameInformations(GameObject objectWithtext)
        {
            float newCoordinateY = 4.25f;
            CreateGameNameText(objectWithtext);
            ChangeDataForGameName(newCoordinateY);
        }

        public static void CreateGameNameText(GameObject objectWithtext)
        {
                float newX = 0;
                float newY = 0.5f;
                float newZ = 0;

                var newObject = Instantiate(objectWithtext, new Vector3(newX, newY, newZ), Quaternion.identity);        
        }

        public static void ChangeDataForGameName(float newCoordinateY)
        {
            //Dictionary<int, string> tagGameInformations = GameDictionariesSceneInformation.DictionaryTagsGameInformation();
            //string tagGameName = tagGameInformations[9];
            string tagGameName = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagName();
            GameObject text = GameCommonMethodsMain.GetObjectByTagName(tagGameName);
            GameCommonMethodsSetUpCoordinates.ChangeYForGameObject(text, newCoordinateY);
        }
    }
}
