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
        public static int[] SetUpNewMoveIndexByAdding(int[] moveIndexTable, int moveIndexForXorY, int currentMoveIndexForXorY)
        {
         //  Debug.Log(" ++++++++++ moveIndexForXorY = " + moveIndexForXorY);
         //   int newMoveIndex = moveIndexTable[moveIndexForXorY] + 1;
           // Debug.Log($" ++++++++++ moveIndexTable[{moveIndexForXorY}] = " + moveIndexTable[moveIndexForXorY]);
          // Debug.Log(" ++++++++++ newMoveIndex = " + newMoveIndex);

            int newMoveIndex = currentMoveIndexForXorY + 1;
            moveIndexTable[moveIndexForXorY] = newMoveIndex;
           // Debug.Log($" ++++++++++ moveIndexTable[{moveIndexForXorY}] = " + moveIndexTable[moveIndexForXorY]);
           // Debug.Log(" ++++++++++ newMoveIndex = " + newMoveIndex);
            return moveIndexTable;
        }


        /// <summary>
        /// move to the left or move down frame if we start with position 0,5 for CubePlayFrame
        /// </summary>
        /// <param name="moveIndexTable"></param>
        /// <returns></returns>
        public static int[] SetUpNewMoveIndexBySubtraction(int[] moveIndexTable, int moveIndexForXorY, int currentMoveIndexForXorY)
        {
            Debug.Log(" ------------ moveIndexForXorY = " + moveIndexForXorY);
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
           // Debug.Log(" moveIndexForFrameLenght = " + moveIndexForFrameLenght);
            int[] newMoveIndexForFrame = new int[moveIndexForFrameLenght];
           // Debug.Log(" newMoveIndexForFrame = " + newMoveIndexForFrame);

            // y
            int currentMoveIndexForRows = moveIndexForFrame[1];
            //Debug.Log(" currentMoveIndexForRows = " + currentMoveIndexForRows);

            // x
            int currentMoveIndexForColumns = moveIndexForFrame[0];
            //Debug.Log(" currentMoveIndexForColumns = " + currentMoveIndexForColumns);

            if (tagArrow == tagArrowRight)
            {
                //Debug.Log("numberOfColumns =  " + (numberOfColumns - 1));

                if (currentMoveIndexForColumns < numberOfColumns)
                {
                    //Debug.Log(" hmmmmm ");
                    newMoveIndexForFrame = SetUpNewMoveIndexByAdding(moveIndexForFrame, moveIndexForX, currentMoveIndexForColumns);
                    //Debug.Log("newMoveIndexForFrame[0] = X =" + newMoveIndexForFrame[0]);
                    //Debug.Log("newMoveIndexForFrame[1] = " + newMoveIndexForFrame[1]);
                    return newMoveIndexForFrame;
                }
                else
                {
                    //Debug.Log(" yyyyyyy ");
                    newMoveIndexForFrame = moveIndexForFrame;
                    //newMoveIndexForFrame = CommonMethods.CreateTableWithGivenLengthAndGivenValue(2, 1);
                    return newMoveIndexForFrame;
                }



            }

            if (tagArrow == tagArrowLeft)
            {
                Debug.Log(" *********************************************************** ");
                Debug.Log("numberOfColumns =  " + (numberOfColumns));
                Debug.Log("currentMoveIndexForColumns =  " + (currentMoveIndexForColumns));
                Debug.Log(" *********************************************************** ");
                if (currentMoveIndexForColumns > 0)
                {
                    //Debug.Log(" hmmmmm ");
                    newMoveIndexForFrame = SetUpNewMoveIndexBySubtraction(moveIndexForFrame, moveIndexForX, currentMoveIndexForColumns);
                    //Debug.Log("newMoveIndexForFrame[0] = X =" + newMoveIndexForFrame[0]);
                    //Debug.Log("newMoveIndexForFrame[1] = " + newMoveIndexForFrame[1]);
                    return newMoveIndexForFrame;
                }
                else
                {
                    //Debug.Log(" yyyyyyy ");
                    newMoveIndexForFrame = moveIndexForFrame;
                    //newMoveIndexForFrame = CommonMethods.CreateTableWithGivenLengthAndGivenValue(2, 1);
                    return newMoveIndexForFrame;
                }



            }


            return moveIndexForFrame;
        }

    }
}
