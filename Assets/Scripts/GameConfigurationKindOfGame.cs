using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

// scene name: SceneStartGame

namespace Assets.Scripts
{
    internal class GameConfigurationKindOfGame : MonoBehaviour
    {
        public static bool ConfigurationBoardGameDeviceModeKind { get; set; }
        public static bool ConfigurationTeamGame { get; set; }

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

        void Start()
        {
            isCellphoneModeScene1 = ScreenVerificationMethods.IsCellphoneMode();

            _tagUntagged = GameConfigurationButtonsCommonButtonsTagName.GetTagNameUntagged();

            _tagStartGameButtonStartGame = GameStartCommonButtonsTagName.GetTagForButtonNameByTagStartGame();
            _tagStartGameButtonStarTeamGame = GameStartCommonButtonsTagName.GetTagForButtonNameByTagStartTeamGame();

            _tagStartGameButtonInformations = GameStartCommonButtonsTagName.GetTagForButtonNameByTagInformation();

            GameStartButtonsCreate.CreateButtonsStartGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D);
        }

        void Update()
        {
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
                            ConfigurationTeamGame = boolFalse;
                            ScenesChangeMainMethods.GoToSceneConfigurationBoardGame();
                        }

                        if (gameObjectTag == _tagStartGameButtonStarTeamGame)
                        {
                            ConfigurationBoardGameDeviceModeKind = isCellphoneModeScene1;
                            ConfigurationTeamGame = boolTrue;

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