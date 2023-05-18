using Assets.Scripts.Buttons;
using Assets.Scripts.CreateGameHelpButton;
using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.PlayGameFrame
{
    internal class PlayGameFrameActions : MonoBehaviour
    {

        public static void HideCubePlayFrame()
        {
            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            string tagCubePlayFrame = tagCubePlayDictionary[3];
            //Debug.Log(" tagCubePlayFrame = " + tagCubePlayFrame);

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
            //Debug.Log(" tagCubePlayFrame = " + tagCubePlayFrame);

            bool isCubePlayFrameExsist = CommonMethods.IsGameObjectWithTagExsist(tagCubePlayFrame);

            if (isCubePlayFrameExsist == true)
            {
                ButtonsCommonMethodsActions.GameObjectToUnhide(tagCubePlayFrame);
            }
            
        }

        public static void DestroyCubePlayFrame()
        {
            //Destroy(cubePlayFrame);

            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            string tagCubePlayFrame = tagCubePlayDictionary[3];
            //Debug.Log(" tagCubePlayFrame = " + tagCubePlayFrame);

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

        //public static bool GetCubePlayFrameVisibility(bool isCubePlayFrameVisible)
        //{
        //    if (isCubePlayFrameVisible == true)
        //    {
        //        Debug.Log(" 1 ");
        //        //UnhideCubePlayFrame();
        //        HideCubePlayFrame();
        //        return false;
        //    } 
        //    else
        //    {
        //        Debug.Log(" 2 ");
        //        UnhideCubePlayFrame();
        //        return true;
        //    }
  
        //}

        //public static void CubePlayFrameVisibilityActions(bool isCubePlayFrameVisible)
        //{
        //    if (isCubePlayFrameVisible == true)
        //    {
        //        Debug.Log(" 1 ");
        //        HideCubePlayFrame();
        //        //return false;
        //    }
        //    else
        //    {
        //        Debug.Log(" 2 ");
        //        UnhideCubePlayFrame();
        //        //return true;
        //    }

        //}


        public static bool IsCubePlayFrameExsist(GameObject cubePlayFrame)
        {
            Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
            string tagCubePlayFrame = tagCubePlayDictionary[3];

            bool isCubePlayFrameExsist = CommonMethods.IsGameObjectWithTagExsist(tagCubePlayFrame);

            return isCubePlayFrameExsist;
        }

        //public static void CubePlayFrameDestroy(GameObject cubePlayFrame)
        //{
        //    Dictionary<int, string> tagCubePlayDictionary = GameDictionariesSceneGame.DictionaryTagCubePlay();
        //    string tagCubePlayFrame = tagCubePlayDictionary[3];

        //    Debug.Log(" 2 ");
        //    ButtonsCommonMethodsActionsDestroy.DestroySingleGameObjectWithTag(tagCubePlayFrame);

        //}

    }
}
