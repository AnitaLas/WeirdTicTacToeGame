using Assets.Scripts.GameConfiguration.GameConfigurationPlayerSymbolButtons;
using Assets.Scripts.GameConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.Scenes;
using Assets.Scripts.GameStart;
using Assets.Scripts.ScreenVerification;

// scene name: SceneStartGame

namespace Assets.Scripts
{
    internal class GameConfigurationSetUpKindOfGame : MonoBehaviour
    {
        public GameObject prefabCubePlay;

        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsInformationColour;

        private bool _isGame2D = true;

        private string _tagUntagged;
        private string _tagStartGameButtonStartGame;
        private string _tagStartGameButtonInformations;

        Dictionary<int, string> tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();
        Dictionary<int, string> tagStartGameButtonsDictionary = GameDictionariesSceneStartGame.DictionaryTagStartGame();


        void Start()
        {
            _tagUntagged = tagCommonDictionary[1];
            _tagStartGameButtonStartGame = tagStartGameButtonsDictionary[1];
            _tagStartGameButtonInformations = tagStartGameButtonsDictionary[3];

            GameStartButtonsCreate.CreateButtonsStartGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, _isGame2D);

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
                        string gameObjectTag = CommonMethods.GetObjectTag(touch);

                        if (gameObjectTag != _tagUntagged)
                        {
                            GameObject gameObject = CommonMethods.GetObjectByTagName(gameObjectTag);
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
