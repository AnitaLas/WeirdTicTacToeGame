using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

// scene name: SceneStartGame

namespace Assets.Scripts
{
    internal class GameConfigurationSetUpKindOfGame : MonoBehaviour
    {
        public GameObject prefabCubePlay;
        public GameObject gameName;

        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsInformationColour;

        private bool _isGame2D = true;

        private string _tagUntagged;
        private string _tagStartGameButtonStartGame;
        private string _tagStartGameButtonStarTeamGame;
        private string _tagStartGameButtonInformations;

        //private Dictionary<int, string> _tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();
        private Dictionary<int, string> _tagStartGameButtonsDictionary = GameDictionariesSceneStartGame.DictionaryTagStartGame();

        void Start()
        {
            //_tagUntagged = _tagCommonDictionary[1];
            _tagUntagged = GameConfigurationButtonsCommonButtonsTagName.GetTagNameUntagged();
            _tagStartGameButtonStartGame = _tagStartGameButtonsDictionary[1];
            _tagStartGameButtonStarTeamGame = _tagStartGameButtonsDictionary[2];
            _tagStartGameButtonInformations = _tagStartGameButtonsDictionary[3];

            GameStartButtonsCreate.CreateButtonsStartGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);
            GameNameTextCreate.CreateGameNameForStart(gameName);
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
                            ScenesChangeMainMethods.GoToSceneConfigurationBoardGame();
                        }

                        // clik team button - add scene in unity!!!

                        //if (gameObjectTag == _tagStartGameButtonStarTeamGame)
                        //{
                        //    ScenesChange.GoToSceneConfigurationGameTeamsNumber();
                        //}

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
