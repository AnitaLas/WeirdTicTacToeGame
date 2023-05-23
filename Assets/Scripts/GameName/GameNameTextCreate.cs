using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameName
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
            Dictionary<int, string> tagGameInformations = GameDictionariesSceneInformations.DictionaryTagGameInformations();
            string tagGameName = tagGameInformations[9];
            GameObject text = CommonMethods.GetObjectByTagName(tagGameName);
            CommonMethods.ChangeYForGameObject(text, newCoordinateY);
        }


    }
}
