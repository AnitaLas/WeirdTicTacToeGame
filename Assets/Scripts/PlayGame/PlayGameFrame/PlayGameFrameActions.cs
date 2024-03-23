using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayGameFrameActions : MonoBehaviour
    {
        public static void HideCubePlayFrame()
        {
            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            //string tagCubePlayFrame = tagCubePlayDictionary[3];
            string tagCubePlayFrame = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagFrame();

            bool isCubePlayFrameExsist = GameCommonMethodsMain.IsGameObjectWithTagExsist(tagCubePlayFrame);

            if (isCubePlayFrameExsist == true)
            {
                ButtonsCommonMethodsActions.GameObjectToHide(tagCubePlayFrame);
            }
        }

        public static void UnhideCubePlayFrame()
        {
           //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            //string tagCubePlayFrame = tagCubePlayDictionary[3];
            string tagCubePlayFrame = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagFrame();

            bool isCubePlayFrameExsist = GameCommonMethodsMain.IsGameObjectWithTagExsist(tagCubePlayFrame);

            if (isCubePlayFrameExsist == true)
            {
                ButtonsCommonMethodsActions.GameObjectToUnhide(tagCubePlayFrame);
            }         
        }

        public static void DestroyCubePlayFrame()
        {
            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            //string tagCubePlayFrame = tagCubePlayDictionary[3];
            string tagCubePlayFrame = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagFrame();

            bool isCubePlayFrameExsist = GameCommonMethodsMain.IsGameObjectWithTagExsist(tagCubePlayFrame);

            if (isCubePlayFrameExsist == true)
            {
                GameObject cubePlayFrame = GameCommonMethodsMain.GetObjectByTagName(tagCubePlayFrame);
                Destroy(cubePlayFrame);          
            }
        }

        public static void DestroyMoveIndexForFrame(int[] moveIndexForFrame)
        {
            Array.Clear(moveIndexForFrame, 0, moveIndexForFrame.Length);
        }

        public static bool IsCubePlayFrameExsist(GameObject cubePlayFrame)
        {
            //Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            //string tagCubePlayFrame = tagCubePlayDictionary[3];
            string tagCubePlayFrame = PlayGameCommonButtonsTagName.GetTagForButtonNameByTagFrame();

            bool isCubePlayFrameExsist = GameCommonMethodsMain.IsGameObjectWithTagExsist(tagCubePlayFrame);

            return isCubePlayFrameExsist;
        }
    }
}
