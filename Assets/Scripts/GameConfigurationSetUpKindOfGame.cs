using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.Scenes;
using Assets.Scripts.GameStart;
using Assets.Scripts.GameName;
using Assets.Scripts.CommonMethods;

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
        private string _tagStartGameButtonInformations;

        private Dictionary<int, string> _tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();
        private Dictionary<int, string> _tagStartGameButtonsDictionary = GameDictionariesSceneStartGame.DictionaryTagStartGame();

        void Start()
        {
            _tagUntagged = _tagCommonDictionary[1];
            _tagStartGameButtonStartGame = _tagStartGameButtonsDictionary[1];
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
                        string gameObjectTag = CommonMethodsMain.GetObjectTag(touch);

                        if (gameObjectTag != _tagUntagged)
                        {
                            GameObject gameObject = CommonMethodsMain.GetObjectByTagName(gameObjectTag);
                        }

                        if (gameObjectTag == _tagStartGameButtonStartGame)
                        {
                            ScenesChange.GoToSceneConfigurationBoardGame();
                        }

                        if (gameObjectTag == _tagStartGameButtonInformations)
                        {
                            ScenesChange.GoToSceneInformations();
                        }
                    }
                }
            }
        }
    }                
}
