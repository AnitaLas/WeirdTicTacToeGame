using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameFrameMove : MonoBehaviour
    {
        public static int[] CreateTableForMoveIndexForFrame(int numberOfRows)
        {
            int[] table = GameCommonMethodsMain.CreateTableWithGivenLengthAndGivenValue(2, 0);
            table[1] = numberOfRows - 1;
            return table;
        }

        public static int[] SetUpNewMoveIndexXForRight(int[] moveIndexForFrame, GameObject cubePlayFrame, float cubePlayForFrameScale, int moveIndexForYorX)
        {
            moveIndexForFrame = GameCommonMethodsMain.SetUpNewCurrentNumberByAddition(moveIndexForFrame, moveIndexForYorX);
            float newCoordinate = cubePlayForFrameScale * (1);
            CommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlayFrame, newCoordinate);
            return moveIndexForFrame;
        }

        public static int[] SetUpNewMoveIndexYForUp(int[] moveIndexForFrame, GameObject cubePlayFrame, float cubePlayForFrameScale, int moveIndexForYorX)
        {
            moveIndexForFrame = GameCommonMethodsMain.SetUpNewCurrentNumberByAddition(moveIndexForFrame, moveIndexForYorX);
            float newCoordinate = cubePlayForFrameScale * (1);
            CommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlayFrame, newCoordinate);
            return moveIndexForFrame;
        }

        public static int[] SetUpNewMoveIndexXForLeft(int[] moveIndexForFrame, GameObject cubePlayFrame, float cubePlayForFrameScale, int moveIndexForX)
        {
            moveIndexForFrame = GameCommonMethodsMain.SetUpNewCurrentNumberBySubtraction(moveIndexForFrame, moveIndexForX);
            float newCoordinate = cubePlayForFrameScale * (-1);
            CommonMethodsSetUpCoordinates.SetUpNewXForGameObject(cubePlayFrame, newCoordinate);
            return moveIndexForFrame;
        }

        public static int[] SetUpNewMoveIndexYForDown(int[] moveIndexForFrame, GameObject cubePlayFrame, float cubePlayForFrameScale, int moveIndexForY)
        {
            moveIndexForFrame = GameCommonMethodsMain.SetUpNewCurrentNumberBySubtraction(moveIndexForFrame, moveIndexForY);
            float newCoordinate = cubePlayForFrameScale * (-1);
            CommonMethodsSetUpCoordinates.SetUpNewYForGameObject(cubePlayFrame, newCoordinate);
            return moveIndexForFrame;
        }

        public static int[] SetUpNewMoveIndexXYForCubePlayFrame(int[] moveIndexForFrame, string tagArrow, GameObject cubePlayFrame, float cubePlayForFrameScale, int numberOfRows, int numberOfColumns)
        {
            Dictionary<int, string> tagArrowDictionary = GameDictionariesSceneGame.DictionaryTagHelpButtons();

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

        public static GameObject GetCubePlayFrame()
        {
            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            string tagCubePlayFrame = tagCubePlayDictionary[3];
            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(tagCubePlayFrame);
            return gameObject;
        }
    }
}
