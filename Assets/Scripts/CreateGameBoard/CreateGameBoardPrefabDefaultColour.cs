using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    internal class CreateGameBoardPrefabDefaultColour : MonoBehaviour
    {
        // [prefabCubePlayColorDefaul]

        /// <summary>
        /// <para> returns the index one by one from the array colour assigned to the object "GameBoard" by name "Cube Play Colour" </para>
        /// </summary>
        /// <param name="cubePlayColourLenght"></param>
        /// <param name="indexForPreviousColour"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="currentCountedNumberForCubeRows"></param>
        /// <param name="isNumberOfRowsEven"></param>
        /// <returns></returns>
        public static Tuple <int, int> NewIndexColourForPrefabCubePlay(int cubePlayColourLenght, int indexForPreviousColour, int numberOfRows, int currentCountedNumberForCubeRows, bool isNumberOfRowsEven)
        {
            int maxIndexForCubePlayColour = cubePlayColourLenght - 1;
            int newIndexForCubePlayColour;

            int currentCountedNumberForHeightY;

            if (indexForPreviousColour == 0)
            {

                if (currentCountedNumberForCubeRows == numberOfRows)
                {
                    currentCountedNumberForHeightY = 1;

                    if (isNumberOfRowsEven == true)
                    {
                        newIndexForCubePlayColour = indexForPreviousColour;
                    }
                    else
                    {
                        newIndexForCubePlayColour = indexForPreviousColour + 1;
                    }

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;

                }
                else
                {
                    currentCountedNumberForHeightY = currentCountedNumberForCubeRows + 1;
                    newIndexForCubePlayColour = indexForPreviousColour + 1;

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;
                }
            }       
            
            else if (indexForPreviousColour == maxIndexForCubePlayColour)
            {
                
                if (currentCountedNumberForCubeRows == numberOfRows)
                {
                    currentCountedNumberForHeightY = 1;                   
                    
                    if (isNumberOfRowsEven == true)
                    {
                        newIndexForCubePlayColour = indexForPreviousColour;
                    }
                    else
                    {
                        newIndexForCubePlayColour = 0;
                    }

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;

                }
                else
                {
                    currentCountedNumberForHeightY = currentCountedNumberForCubeRows + 1;
                    newIndexForCubePlayColour = 0;

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;
                }

            }
            else if (indexForPreviousColour < maxIndexForCubePlayColour)
            {

                if (currentCountedNumberForCubeRows == numberOfRows)
                {
                    currentCountedNumberForHeightY = 0;

                    if (isNumberOfRowsEven == true)
                    {
                        newIndexForCubePlayColour = indexForPreviousColour;
                    }
                    else
                    {
                        newIndexForCubePlayColour = indexForPreviousColour + 1;
                    }

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;
                }
                else
                {
                    currentCountedNumberForHeightY = currentCountedNumberForCubeRows + 1;
                    newIndexForCubePlayColour = indexForPreviousColour + 1;
                   
                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;
                }
            }
            else
            {
                currentCountedNumberForHeightY = 0;
                newIndexForCubePlayColour = 0;

                var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                return newDataForCubePlayColour;
            }
        }

        /// <summary>
        /// <para> it returns colour for the new prefab "CubePlay" </para>
        /// <para> indexForNewColour come from method NewIndexColourForPrefabCubePlay() </para>
        /// </summary>
        /// <param name="cubePlayColour"></param>
        /// <param name="indexForNewColour"></param>
        /// <returns></returns>
        public static Material NewColourForPrefabCubePlay(Material[] cubePlayColour, int indexForNewColour)
        {
            Material cubeColour = cubePlayColour[indexForNewColour];
            return cubeColour;         
        }

        /// <summary>
        /// <para> it changes the colour for prefab "CubePlay" </para> 
        /// <para> indexForNewColour come from method NewIndexColourForPrefabCubePlay() </para>
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="cubePlayColour"></param>
        /// <param name="indexForNewColour"></param>
        public static void ChangeColourForPrefabCubePlay(GameObject prefab, Material[] cubePlayColour, int indexForNewColour)
        {
            Material cubeColour = NewColourForPrefabCubePlay(cubePlayColour, indexForNewColour);
            prefab.GetComponent<Renderer>().material = cubeColour;
        }


    }
}
