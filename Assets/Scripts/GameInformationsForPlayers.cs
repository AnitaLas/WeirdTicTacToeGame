using Assets.Scripts.GameDictionaries;
using Assets.Scripts.GameInformations.GameInformationsBase;
using Assets.Scripts.GameInformations.GameInformationsButtons;
using Assets.Scripts.GameInformations.GameInformationsText;
using Assets.Scripts.GameName;
using Assets.Scripts.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //private string _tagGameName;

        Dictionary<int, string> tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();
        Dictionary<int, string> tagGameInformations = GameDictionariesSceneInformations.DictionaryTagGameInformations();

        private GameObject[,,] _buttonBack;
        private List<GameObject[,,]> _buttonsAll;
        private List<string> _gameObjectsWithText;


        void Start()
        {
            _tagUntagged = tagCommonDictionary[1];
            _tagGameInformationsButtonBack = tagGameInformations[1];
            _tagGameInformationsButtonBackToMenu = tagGameInformations[4];
            _tagGameInformationsButtonContact = tagGameInformations[2];
            _tagGameInformationsButtonNextVersions = tagGameInformations[3];
            _tagGameInformationsTextContact = tagGameInformations[5];
            _tagGameInformationsTextNextVersions = tagGameInformations[6];
            _tagGameInformationsButtontSet = tagGameInformations[7];
            _tagGameInformationsTextSet = tagGameInformations[8];
            //_tagGameName = tagGameInformations[9];

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
                            // add mthod clean the list and add the new tag
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
