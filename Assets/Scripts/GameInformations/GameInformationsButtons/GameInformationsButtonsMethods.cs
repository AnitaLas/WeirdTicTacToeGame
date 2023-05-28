using UnityEngine;

namespace Assets.Scripts.GameInformations.GameInformationsButtons
{
    internal class GameInformationsButtonsMethods
    {
        public static void ChangeTagForButtonBack(string oldTag, string newTag)
        {
            GameObject[] gameObjects = CommonMethods.GetObjectsListWithTagName(oldTag);

            foreach (GameObject gameObject in gameObjects) 
            {
                CommonMethods.ChangeTagForGameObject(gameObject, newTag);
            }
        }
    }
}
