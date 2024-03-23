using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameHelpButtonsCreate : MonoBehaviour
    {
        public static void CreateHelpButtons(GameObject prefabHelpButtons)
        {
            Instantiate(prefabHelpButtons);
        }

        public static void CreateAtStartHelpButtons(GameObject prefabHelpButtons, int numberOfRows, int numberOfColumns, bool isCellphoneMode)
        {
            if (isCellphoneMode == true)
            {
                if (numberOfColumns > 5 || numberOfRows > 5)
                {
                    CreateHelpButtons(prefabHelpButtons);
                }
            }
        }
    }
}
