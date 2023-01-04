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
    internal class GameBoardCreateChangeColour : MonoBehaviour
    {

        /// <summary>
        /// <para> dodać opis, że to z obietu GameBoard </para>
        /// </summary>
        /// <param name="cubePlayColour"></param>
        /// <param name="indexForPreviousColour"></param>
        /// <returns></returns>
        public static Tuple <int, int> NewIndexColourForPrefabCubePlay(int cubePlayColourLenght, int indexForPreviousColour, int numbersCubesForHeightY, int currentCountedNumberForCubePlayHeightY)
        {
            //int numbersCubesForHeightY = numbersCubesForHeightY2 - 1;
            int maxIndexForCubePlayColour = cubePlayColourLenght - 1;
            int newIndexForCubePlayColour;

            int currentCountedNumberForHeightY;

            //int[] currentCountedNumberCubeForHeightY = new int[1];
            //currentCountedNumberCubeForHeightY[0] = 1;

            Debug.Log("numbersCubesForHeightY :" + numbersCubesForHeightY);
            Debug.Log("currentCountedNumberForCubePlayHeightY :" + currentCountedNumberForCubePlayHeightY);
 


            if (indexForPreviousColour == 0)
            {
                //currentCountedNumberForHeightY = currentCountedNumberForCubePlayHeightY + 1;
                //newIndexForCubePlayColour = indexForPreviousColour + 1;

                if (currentCountedNumberForCubePlayHeightY == numbersCubesForHeightY)
                {
                    //Debug.Log("Tu jestem?  V222222 IF currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);

                    currentCountedNumberForHeightY = 1;
                    newIndexForCubePlayColour = indexForPreviousColour;
                   // Debug.Log("Tu jestem?  V222222 IF currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;

                }
                else
                {
                    //Debug.Log("Tu jestem?  V222222 ELSE currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);
                    currentCountedNumberForHeightY = currentCountedNumberForCubePlayHeightY + 1;
                    newIndexForCubePlayColour = indexForPreviousColour + 1; ;
                    
                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;
                }
            }       
            
            else if (indexForPreviousColour == maxIndexForCubePlayColour)
            {
                Debug.Log("Tu jestem?  V222222 :");
                Debug.Log("Tu jestem?  V222222 indexForPreviousColour = maxIndexForCubePlayColour:" + indexForPreviousColour + " = " + maxIndexForCubePlayColour);


                
                if (currentCountedNumberForCubePlayHeightY == numbersCubesForHeightY)
                {
                    Debug.Log("Tu jestem?  V222222 IF currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);

                    currentCountedNumberForHeightY = 1;                   
                    newIndexForCubePlayColour = indexForPreviousColour;
                    Debug.Log("Tu jestem?  V222222 IF currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);

                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;

                }
                else
                {
                    Debug.Log("Tu jestem?  V222222 ELSE currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);
                    currentCountedNumberForHeightY = currentCountedNumberForCubePlayHeightY + 1;
                    newIndexForCubePlayColour = 0;
                    //newIndexForCubePlayColour = indexForPreviousColour;
                    Debug.Log("Tu jestem?  V222222 ELSE currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);
                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;
                }

            }
            else if (indexForPreviousColour < maxIndexForCubePlayColour)
            {

                if (currentCountedNumberForCubePlayHeightY == numbersCubesForHeightY)
                {
                    Debug.Log("Tu jestem?  V1111 IF currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);
                    currentCountedNumberForHeightY = 0;
                    //Log("1 ELSE IF IF currentCountedNumberForHeightY :" + currentCountedNumberForHeightY);

                    newIndexForCubePlayColour = indexForPreviousColour;
                    //Debug.Log("1 ELSE IF IF newIndexForCubePlayColour :" + newIndexForCubePlayColour);
                    Debug.Log("Tu jestem?  V1111 IF currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);
                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;
                }
                else
                {
                    Debug.Log("Tu jestem?  V1111 ELSE currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);

                    currentCountedNumberForHeightY = currentCountedNumberForCubePlayHeightY + 1;
                    newIndexForCubePlayColour = indexForPreviousColour + 1;
                    Debug.Log("Tu jestem?  V1111 ELSE currentCountedNumberForCubePlayHeightY = numbersCubesForHeightY:" + currentCountedNumberForCubePlayHeightY + " = " + numbersCubesForHeightY);


                    var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                    return newDataForCubePlayColour;
                }
            }
            else
            {
                Debug.Log("Tu jestem?  V33333 :");
                currentCountedNumberForHeightY = 0;
                newIndexForCubePlayColour = 0;
                var newDataForCubePlayColour = new Tuple<int, int>(newIndexForCubePlayColour, currentCountedNumberForHeightY);
                return newDataForCubePlayColour;
            }
        }

        public static Material NewColourForPrefabCubePlay(Material[] cubePlayColour, int indexForNewColour)
        {
            Material cubeColour = cubePlayColour[indexForNewColour];
            return cubeColour;         
        }

        public static void ChangeColourForPrefabCubePlay(GameObject prefab, Material[] cubePlayColour, int indexForNewColour)
        {
            Material cubeColour = NewColourForPrefabCubePlay(cubePlayColour, indexForNewColour);
            prefab.GetComponent<Renderer>().material = cubeColour;
        }


    }
}
