using Assets.Scripts.Buttons;
using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PlayGameFrame
{
    internal class PlayGameFrameActions : MonoBehaviour
    {
        public static void HideCubePlayFrame()
        {
            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            string tagCubePlayFrame = tagCubePlayDictionary[3];

            bool isCubePlayFrameExsist = CommonMethods.IsGameObjectWithTagExsist(tagCubePlayFrame);

            if (isCubePlayFrameExsist == true)
            {
                ButtonsCommonMethodsActions.GameObjectToHide(tagCubePlayFrame);
            }
        }

        public static void UnhideCubePlayFrame()
        {
            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            string tagCubePlayFrame = tagCubePlayDictionary[3];

            bool isCubePlayFrameExsist = CommonMethods.IsGameObjectWithTagExsist(tagCubePlayFrame);

            if (isCubePlayFrameExsist == true)
            {
                ButtonsCommonMethodsActions.GameObjectToUnhide(tagCubePlayFrame);
            }         
        }

        public static void DestroyCubePlayFrame()
        {
            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            string tagCubePlayFrame = tagCubePlayDictionary[3];

            bool isCubePlayFrameExsist = CommonMethods.IsGameObjectWithTagExsist(tagCubePlayFrame);

            if (isCubePlayFrameExsist == true)
            {
                GameObject cubePlayFrame = CommonMethods.GetObjectByTagName(tagCubePlayFrame);
                Destroy(cubePlayFrame);          
            }
        }

        public static void DestroyMoveIndexForFrame(int[] moveIndexForFrame)
        {
            Array.Clear(moveIndexForFrame, 0, moveIndexForFrame.Length);
        }

        public static bool IsCubePlayFrameExsist(GameObject cubePlayFrame)
        {
            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            string tagCubePlayFrame = tagCubePlayDictionary[3];

            bool isCubePlayFrameExsist = CommonMethods.IsGameObjectWithTagExsist(tagCubePlayFrame);

            return isCubePlayFrameExsist;
        }
    }
}
