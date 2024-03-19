using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameInformationButtonsMethods
    {
        public static void ChangeTagForButtonBack(string oldTag, string newTag)
        {
            GameObject[] gameObjects = GameCommonMethodsMain.GetObjectsListWithTagName(oldTag);

            foreach (GameObject gameObject in gameObjects) 
            {
                GameCommonMethodsMain.ChangeTagForGameObject(gameObject, newTag);
            }
        }
    }
}
