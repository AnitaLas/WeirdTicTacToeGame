﻿using UnityEngine;

namespace Assets.Scripts
{
    internal class GameInformationCreateText : MonoBehaviour
    {
        public static void CreateGameInformationsText(GameObject objectWithtext)
        {
            float newX = 0;
            float newY = 0.5f;
            float newZ = 0;

            var newObject= Instantiate(objectWithtext, new Vector3(newX, newY, newZ), Quaternion.identity);
        }

        public static void CreateGameInformationsTextNextVersions(GameObject objectWithtext)
        {
            CreateGameInformationsText(objectWithtext);
        }

        public static void CreateGameInformationsTextContact(GameObject objectWithtext)
        {
            CreateGameInformationsText(objectWithtext);
        }
    }
}
