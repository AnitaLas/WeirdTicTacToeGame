using Assets.Scripts.CommonMethods;
using UnityEngine;

namespace Assets.Scripts.Buttons
{
    internal class ButtonsGameConfigurationMethods
    {
        // --- information buttons

        public static void ChangeDataForGameConfigurationButtonsInformation(GameObject[,,] button)
        {
            int maxIndexDepth = button.GetLength(0); 
            int maxIndexColumn  = button.GetLength(2);
            int maxIndexRow = button.GetLength(1); 

            float newCoordinateY = 4.5f;
            float newCoordinateX = -0.65f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        CommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        CommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                    }
                }
            }           
        }
    }
}
