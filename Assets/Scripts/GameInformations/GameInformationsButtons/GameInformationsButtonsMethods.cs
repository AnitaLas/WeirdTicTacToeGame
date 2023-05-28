using Assets.Scripts.CommonMethods;
using UnityEngine;

namespace Assets.Scripts.GameInformations.GameInformationsButtons
{
    internal class GameInformationsButtonsMethods
    {
        public static void ChangeTagForButtonBack(string oldTag, string newTag)
        {
            GameObject[] gameObjects = CommonMethodsMain.GetObjectsListWithTagName(oldTag);

            foreach (GameObject gameObject in gameObjects) 
            {
                CommonMethodsMain.ChangeTagForGameObject(gameObject, newTag);
            }
        }
    }
}
