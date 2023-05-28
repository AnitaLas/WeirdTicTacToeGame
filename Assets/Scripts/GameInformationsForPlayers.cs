using Assets.Scripts.GameDictionaries;
using Assets.Scripts.GameInformations.GameInformationsButtons;
using Assets.Scripts.GameInformations.GameInformationsText;
using Assets.Scripts.Scenes;
using System.Collections.Generic;
using UnityEngine;

// scene name: SceneInformations

namespace Assets.Scripts
{
    internal class GameInformationsForPlayers : MonoBehaviour
    {
        public GameObject prefabCubePlay;
        public GameObject gameInformationsTextNextVersions;
        public GameObject gameInformationsTextContact;
        public GameObject gameInformationsTextSet;
        public GameObject gameName;

        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsBackColour;

        private bool _isGame2D = true;

        private string _tagUntagged;
        private string _tagGameInformationsButtonBack;
        private string _tagGameInformationsButtonBackToMenu;
        private string _tagGameInformationsButtonContact;
        private string _tagGameInformationsButtonNextVersions;
        private string _tagGameInformationsButtontSet;
        private string _tagGameInformationsTextContact;
        private string _tagGameInformationsTextNextVersions;
        private string _tagGameInformationsTextSet;

        private Dictionary<int, string> _tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();
        private Dictionary<int, string> _tagGameInformations = GameDictionariesSceneInformations.DictionaryTagGameInformations();

        private GameObject[,,] _buttonBack;
        private List<GameObject[,,]> _buttonsAll;
        private List<string> _gameObjectsWithText;

        void Start()
        {
            _tagUntagged = _tagCommonDictionary[1];
            _tagGameInformationsButtonBack = _tagGameInformations[1];
            _tagGameInformationsButtonBackToMenu = _tagGameInformations[4];
            _tagGameInformationsButtonContact = _tagGameInformations[2];
            _tagGameInformationsButtonNextVersions = _tagGameInformations[3];
            _tagGameInformationsTextContact = _tagGameInformations[5];
            _tagGameInformationsTextNextVersions = _tagGameInformations[6];
            _tagGameInformationsButtontSet = _tagGameInformations[7];
            _tagGameInformationsTextSet = _tagGameInformations[8];

            _buttonBack = GameInformationsButtonsCreate.GameInformationsCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, _isGame2D);
            _buttonsAll = GameInformationsButtonsCreate.GameInformationsCreateButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, _isGame2D);

            GameInformationsTextCreate.CreateGameName(gameName);
           
            _gameObjectsWithText = new List<string>();
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

                        if (gameObjectTag == _tagGameInformationsButtonContact)
                        {
                            GameInformationsButtonsAction.HideButtons(_buttonsAll);
                            GameInformationsTextCreate.CreateGameInformationsTextContact(gameInformationsTextContact);
                            _gameObjectsWithText.Insert(0, _tagGameInformationsTextContact);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonNextVersions)
                        {
                            GameInformationsButtonsAction.HideButtons(_buttonsAll);
                            GameInformationsTextCreate.CreateGameInformationsTextNextVersions(gameInformationsTextNextVersions);
                            _gameObjectsWithText.Insert(0, _tagGameInformationsTextNextVersions);
                        }

                        if (gameObjectTag == _tagGameInformationsButtontSet)
                        {
                            GameInformationsButtonsAction.HideButtons(_buttonsAll);
                            GameInformationsTextCreate.CreateGameInformationsTextSet(gameInformationsTextSet);
                            _gameObjectsWithText.Insert(0, _tagGameInformationsTextSet);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonBackToMenu)
                        {
                            GameInformationsButtonsAction.UnhideButtons(_buttonsAll);
                            GameInformationsTextActions.DestroyGameObjectsWithText(_gameObjectsWithText);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonBack)
                        {
                            ScenesChange.GoToSceneStartGame();
                        }
                    }
                }
            }
        }
    }
}
