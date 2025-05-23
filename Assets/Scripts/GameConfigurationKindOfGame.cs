﻿using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

// scene name: SceneStartGame

namespace Assets.Scripts
{
    internal class GameConfigurationKindOfGame : MonoBehaviour
    {
        public static bool ConfigurationBoardGameDeviceModeKind { get; set; }
        public static bool ConfigurationTeamGame { get; set; }
        //public static bool ConfigurationTraditionalGame { get; set; }

        private static bool isCellphoneModeScene1;

        public GameObject prefabCubePlay;
        public GameObject gameName;

        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsInformationColour;
        public Material[] prefabCubePlayButtonsNumberColour;
        public Material[] prefabCubePlayButtonsBackColour;

        private bool _isGame2D = true;

        private string _tagUntagged;
        private string _tagStartGameButtonStartGame;
        private string _tagStartGameButtonStarTeamGame;
        private string _tagStartGameButtonInformations;

        public static bool boolTrue = true;
        public static bool boolFalse = false;
        //private Dictionary<int, string> _tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();
        //private Dictionary<int, string> _tagStartGameButtonsDictionary = GameDictionariesSceneStartGame.DictionaryTagsStartGame();

        void Start()
        {
            //ConfigurationTeamGame = boolTrue;
            //ConfigurationTraditionalGame = boolFalse;

            isCellphoneModeScene1 = ScreenVerificationMethods.IsCellphoneMode();
            //Debug.Log("1 kind of game -> isCellphoneMode: " + isCellphoneModeScene1);
            //_tagUntagged = _tagCommonDictionary[1];
            _tagUntagged = GameConfigurationButtonsCommonButtonsTagName.GetTagNameUntagged();


            _tagStartGameButtonStartGame = GameStartCommonButtonsTagName.GetTagForButtonNameByTagStartGame();
            _tagStartGameButtonStarTeamGame = GameStartCommonButtonsTagName.GetTagForButtonNameByTagStartTeamGame();
            _tagStartGameButtonInformations = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInformation();

            GameStartButtonsCreate.CreateButtonsStartGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D);
            //GameNameTextCreate.CreateGameNameForStart(gameName);
        }

        void Update()
        {
            //isCellphoneModeScene1 = ScreenVerificationMethods.IsCellphoneMode();
            //Debug.Log("3 isCellphoneMode: " + isCellphoneModeScene1);

            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

                RaycastHit touch;

                if (Physics.Raycast(ray, out touch))
                {
                    if (touch.collider != null)
                    {
                        string gameObjectTag = GameCommonMethodsMain.GetObjectTag(touch);

                        if (gameObjectTag != _tagUntagged)
                        {
                            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(gameObjectTag);
                        }

                        if (gameObjectTag == _tagStartGameButtonStartGame)
                        {
                            ConfigurationBoardGameDeviceModeKind = isCellphoneModeScene1;
                            //ConfigurationTeamGame = true;
                            //ConfigurationTraditionalGame = false;
                            ConfigurationTeamGame = boolFalse;
                            //ConfigurationTraditionalGame = boolTrue;
                            //Debug.Log("BASE 1 - ConfigurationTeamGame : " + ConfigurationTeamGame);
                            //Debug.Log("BASE 1 - ConfigurationTraditionalGame : " + ConfigurationTraditionalGame);

                            ScenesChangeMainMethods.GoToSceneConfigurationBoardGame();

                        }


                        if (gameObjectTag == _tagStartGameButtonStarTeamGame)
                        {
                            //Debug.Log("isCellphoneMode: " + isCellphoneMode);
                            ConfigurationBoardGameDeviceModeKind = isCellphoneModeScene1;
                            ConfigurationTeamGame = boolTrue;
                            //ConfigurationTraditionalGame = boolFalse;

                            //Debug.Log("BASE 2 - ConfigurationTeamGame : " + ConfigurationTeamGame);
                            //Debug.Log("BASE 2 - ConfigurationTraditionalGame : " + ConfigurationTraditionalGame);


                            if (isCellphoneModeScene1 == true)
                                ScenesChangeMainMethods.GoToSceneConfigurationGameTeamMembers();
                           else
                                ScenesChangeMainMethods.GoToSceneConfigurationGameTeamNumbers();
                        }


                        if (gameObjectTag == _tagStartGameButtonInformations)
                        {
                            ScenesChangeMainMethods.GoToSceneInformations();
                        }
                    }
                }
            }
        }
    }                
}
