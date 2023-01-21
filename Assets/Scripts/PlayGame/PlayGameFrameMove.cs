using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayGame
{
    internal class PlayGameFrameMove
    {

        /// <summary>
        /// move to the right or move up frame if we start with position 0,5 for CubePlayFrame
        /// </summary>
        /// <param name="moveIndexTable"></param>
        /// <returns></returns>
        public static int[] SetUpNewMoveIndexByAddition(int[] moveIndexTable, int moveIndexForXorY, int currentMoveIndexForXorY)
        {
            //  Debug.Log(" ++++++++++ moveIndexForXorY = " + moveIndexForXorY);
            int newMoveIndex = moveIndexTable[moveIndexForXorY] + 1;
            //Debug.Log($" ++++++++++ moveIndexTable[{moveIndexForXorY}] = " + moveIndexTable[moveIndexForXorY]);
            //Debug.Log(" ++++++++++ newMoveIndex = " + moveIndexForXorY);
            //Debug.Log(" +++ ");
            //int newMoveIndex = currentMoveIndexForXorY + 1;
            moveIndexTable[moveIndexForXorY] = newMoveIndex;
            //Debug.Log($" ++++++++++ moveIndexTable[{moveIndexForXorY}] = " + moveIndexTable[moveIndexForXorY]);
            //Debug.Log(" ++++++++++ newMoveIndex = " + newMoveIndex);
            return moveIndexTable;
        }


        /// <summary>
        /// move to the left or move down frame if we start with position 0,5 for CubePlayFrame
        /// </summary>
        /// <param name="moveIndexTable"></param>
        /// <returns></returns>
        public static int[] SetUpNewMoveIndexBySubtraction(int[] moveIndexTable, int moveIndexForXorY, int currentMoveIndexForXorY)
        {
            int newMoveIndex = moveIndexTable[moveIndexForXorY] - 1;
            moveIndexTable[moveIndexForXorY] = newMoveIndex;
            return moveIndexTable;
        }



        public static int[] SetUpNewMoveIndexXYForCubePlayFrame(int[] moveIndexForFrame, string tagArrow, int numberOfRows, int numberOfColumns)
        {
            Dictionary<int, string> tagArrowDictionary = GameDictionariesCommon.DictionaryTagArrow();
            
            string tagArrowRight = tagArrowDictionary[1];
            string tagArrowLeft = tagArrowDictionary[3];
            string tagArrowUp = tagArrowDictionary[4];
            string tagArrowDown = tagArrowDictionary[2];

            int moveIndexForX = 0;
            int moveIndexForY = 1;

            int moveIndexForFrameLenght = moveIndexForFrame.Length;
            int[] newMoveIndexForFrame = new int[moveIndexForFrameLenght];

            // y
            int currentMoveIndexForRows = moveIndexForFrame[1];

            // x
            int currentMoveIndexForColumns = moveIndexForFrame[0];

            // move to the right + x
            if (tagArrow == tagArrowRight)
            {
                if (currentMoveIndexForColumns < numberOfColumns)
                {
                    newMoveIndexForFrame = SetUpNewMoveIndexByAddition(moveIndexForFrame, moveIndexForX, currentMoveIndexForColumns);
                    return newMoveIndexForFrame;
                }
                else
                {
                    newMoveIndexForFrame = moveIndexForFrame;
                    return newMoveIndexForFrame;
                }
            }

            // move to the left - x
            if (tagArrow == tagArrowLeft)
            {
                if (currentMoveIndexForColumns > 0)
                {
                    newMoveIndexForFrame = SetUpNewMoveIndexBySubtraction(moveIndexForFrame, moveIndexForX, currentMoveIndexForColumns);
                    return newMoveIndexForFrame;
                }
                else
                {
                    newMoveIndexForFrame = moveIndexForFrame;
                    return newMoveIndexForFrame;
                }
            }

            // move to down - y
            if (tagArrow == tagArrowDown)
            {
                if (currentMoveIndexForRows > 0)
                {
                    newMoveIndexForFrame = SetUpNewMoveIndexBySubtraction(moveIndexForFrame, moveIndexForY, currentMoveIndexForColumns);
                    return newMoveIndexForFrame;
                }
                else
                {
                    newMoveIndexForFrame = moveIndexForFrame;
                    return newMoveIndexForFrame;
                }
            }


            // move to down + y
            if (tagArrow == tagArrowUp)
            {
                if (currentMoveIndexForRows < numberOfRows)
                {
                    newMoveIndexForFrame = SetUpNewMoveIndexByAddition(moveIndexForFrame, moveIndexForY, currentMoveIndexForColumns);
                    return newMoveIndexForFrame;
                }
                else
                {
                    newMoveIndexForFrame = moveIndexForFrame;
                    return newMoveIndexForFrame;
                }
            }

            return moveIndexForFrame;
        }


        public static void SetUpNewXYForCubePlayFrame(GameObject cubePlayFrame, GameObject cubePlay)
        {
            bool isGame2D = true;

            if (isGame2D == true)
            {
                float x = cubePlay.transform.position.x;
                float y = cubePlay.transform.position.y;
                float z = cubePlayFrame.transform.position.z;

                //float newCoordinateX = cubePlayIndexX * cubePlayForFrameScale;
                //Debug.Log("cubePlayIndexX = " + cubePlayIndexX);
                //Debug.Log("cubePlayForFrameScale = " + cubePlayForFrameScale);
                //Debug.Log("newCoordinateX = " + newCoordinateX);

                //float newCoordinateY = cubePlayIndexY * cubePlayForFrameScale;

                //float newCoordinateX = cubePlayIndexX * cubePlayForFrameScale - cubePlayForFrameScale;
                //float newCoordinateY = cubePlayIndexY * cubePlayForFrameScale - cubePlayForFrameScale;

                // it works
                //gameObject.transform.position = new Vector3(x + newCoordinateX, y + newCoordinateY, z);
                cubePlayFrame.transform.position = new Vector3(x, y, z);
            }
        }

    }
}
