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

        public static int[] CreateTableForMoveIndexForFrame(int numberOfRows)
        {
            int[] table = CommonMethods.CreateTableWithGivenLengthAndGivenValue(2, 0);
            table[1] = numberOfRows - 1;
            return table;
        }

        public static int[] SetUpNewMoveIndexXForRight(int[] moveIndexForFrame, GameObject cubePlayFrame, float cubePlayForFrameScale, int moveIndexForYorX)
        {
            moveIndexForFrame = CommonMethods.SetUpNewCurrentNumberByAddition(moveIndexForFrame, moveIndexForYorX);
            float newCoordinate = cubePlayForFrameScale * (1);
            CommonMethods.SetUpNewXForGameObject(cubePlayFrame, newCoordinate);
            return moveIndexForFrame;
        }

        public static int[] SetUpNewMoveIndexYForUp(int[] moveIndexForFrame, GameObject cubePlayFrame, float cubePlayForFrameScale, int moveIndexForYorX)
        {
            moveIndexForFrame = CommonMethods.SetUpNewCurrentNumberByAddition(moveIndexForFrame, moveIndexForYorX);
            float newCoordinate = cubePlayForFrameScale * (1);
            CommonMethods.SetUpNewYForGameObject(cubePlayFrame, newCoordinate);
            return moveIndexForFrame;
        }

        public static int[] SetUpNewMoveIndexXForLeft(int[] moveIndexForFrame, GameObject cubePlayFrame, float cubePlayForFrameScale, int moveIndexForX)
        {
            moveIndexForFrame = CommonMethods.SetUpNewCurrentNumberBySubtraction(moveIndexForFrame, moveIndexForX);
            float newCoordinate = cubePlayForFrameScale * (-1);
            CommonMethods.SetUpNewXForGameObject(cubePlayFrame, newCoordinate);
            return moveIndexForFrame;
        }


        public static int[] SetUpNewMoveIndexYForDown(int[] moveIndexForFrame, GameObject cubePlayFrame, float cubePlayForFrameScale, int moveIndexForY)
        {
            moveIndexForFrame = CommonMethods.SetUpNewCurrentNumberBySubtraction(moveIndexForFrame, moveIndexForY);
            float newCoordinate = cubePlayForFrameScale * (-1);
            CommonMethods.SetUpNewYForGameObject(cubePlayFrame, newCoordinate);
            return moveIndexForFrame;
        }
        



        public static int[] SetUpNewMoveIndexXYForCubePlayFrame(int[] moveIndexForFrame, string tagArrow, GameObject cubePlayFrame, float cubePlayForFrameScale, int numberOfRows, int numberOfColumns)
        {

            Dictionary<int, string> tagArrowDictionary = GameDictionaries.GameDictionariesCommon.DictionaryTagHelpButtons();

            string tagArrowRight = tagArrowDictionary[1];
            string tagArrowLeft = tagArrowDictionary[3];
            string tagArrowUp = tagArrowDictionary[4];
            string tagArrowDown = tagArrowDictionary[2];

            int moveIndexForX = 0;
            int moveIndexForY = 1;

            // move to the right + x
            if (tagArrow == tagArrowRight)
            {
                if (moveIndexForFrame[0] < numberOfColumns - 1)
                {
                    moveIndexForFrame = SetUpNewMoveIndexXForRight(moveIndexForFrame, cubePlayFrame, cubePlayForFrameScale, moveIndexForX);
                    return moveIndexForFrame;
                }
            }

            // move to the left - x
            if (tagArrow == tagArrowLeft)
            {
                if (moveIndexForFrame[0] > 0)
                {
                    moveIndexForFrame = SetUpNewMoveIndexXForLeft(moveIndexForFrame, cubePlayFrame, cubePlayForFrameScale, moveIndexForX);
                    return moveIndexForFrame;
                }
            }

            // move to down - y
            if (tagArrow == tagArrowDown)
            {
                if (moveIndexForFrame[1] > 0)
                {
                    moveIndexForFrame = SetUpNewMoveIndexYForDown(moveIndexForFrame, cubePlayFrame, cubePlayForFrameScale, moveIndexForY);
                    return moveIndexForFrame;
                }
            }

            // move up + y
            if (tagArrow == tagArrowUp)
            {
                if (moveIndexForFrame[1] < numberOfRows - 1)
                {
                    moveIndexForFrame = SetUpNewMoveIndexYForUp(moveIndexForFrame, cubePlayFrame, cubePlayForFrameScale, moveIndexForY);
                    return moveIndexForFrame;
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

                cubePlayFrame.transform.position = new Vector3(x, y, z);
            }
        }

        public static void SetUpNewZForCubePlayFrame(GameObject cubePlayFrame)
        {
            float newCoordinateZ = 1;
            CommonMethods.SetUpNewZForGameObject(cubePlayFrame, newCoordinateZ);
        }

    }
}
