using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    internal class ButtonsGameConfigurationMethods
    {
        // --- information buttons

        public static void ChangeDataForGameConfigurationButtonsInformation(GameObject[,,] button)
        {
            int maxIndexDepth = button.GetLength(0); 
            int maxIndexColumn  = button.GetLength(2);
            int maxIndexRow = button.GetLength(1); 

            //float newCoordinateY = 4.5f;
            float newCoordinateY = 4.35f;
            //float newCoordinateX = -0.65f;
            float newCoordinateX = -0.8f;

            for (int indexDepth = 0; indexDepth < maxIndexDepth; indexDepth++)
            {
                for (int indexColumn = 0; indexColumn < maxIndexColumn; indexColumn++)
                {
                    for (int indexRow = 0; indexRow < maxIndexRow; indexRow++)
                    {
                        GameObject cubePlay = button[indexDepth, indexRow, indexColumn];
                        GameCommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlay, newCoordinateY);
                        GameCommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlay, newCoordinateX);
                    }
                }
            }           
        }
    }
}
