using Assets.Scripts.GameDictionaries;
using Assets.Scripts.GameInformations.GameInformationsBase;
using Assets.Scripts.GameInformationsButtons;
using Assets.Scripts.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameInformationsForPlayers : MonoBehaviour
    {

        public GameObject prefabCubePlay;
        public GameObject gameInformationsVersionsText;
        public GameObject gameInformationsTextContact;

        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsBackColour;

        private bool isGame2D = true;

        private string _tagUntagged;
        private string _tagGameInformationsButtonBack;
        private string _tagGameInformationsButtonBackToMenu;
        private string _tagGameInformationsButtonContact;
        private string _tagGameInformationsButtonNextVersions;
        private string _tagGameInformationsTextContact;
        private string _tagGameInformationsTextNextVersions;

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

            _buttonBack = GameInformationsButtonsCreate.GameInformationsCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
            _buttonsAll = GameInformationsButtonsCreate.GameInformationsCreateButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, isGame2D);

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
                        //string gameObjectName = CommonMethods.GetObjectName(touch);

                        if (gameObjectTag != _tagUntagged)
                        {
                            GameObject gameObject = CommonMethods.GetObjectByTagName(gameObjectTag);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonNextVersions)
                        {
                            GameInformationsButtonsAction.HideButtons(_buttonsAll);
                            GameInformationsButtonsAction.ChangeTagForButtonBackToSceneInformations();
                            GameInformationsTextCreate.CreateGameInformationsTextNextVersions(gameInformationsVersionsText);
                            _gameObjectsWithText.Insert(0, _tagGameInformationsTextNextVersions);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonContact)
                        {
                            GameInformationsButtonsAction.HideButtons(_buttonsAll);
                            GameInformationsButtonsAction.ChangeTagForButtonBackToSceneInformations();
                            GameInformationsTextCreate.CreateGameInformationsTextContact(gameInformationsTextContact);
                            _gameObjectsWithText.Insert(0, _tagGameInformationsTextContact);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonBackToMenu)
                        {
                            GameInformationsButtonsAction.UnhideButtons(_buttonsAll);
                            GameInformationsButtonsAction.ChangeTagForButtonBackToSceneStartGame();

                            //bool isGameObjectWithTagGameInformationsTextNextVersions = CommonMethods.IsGameObjectWithTagExsist(_tagGameInformationsTextNextVersions);
                            //bool isGameObjectWithTagGameInformationsTextContact = CommonMethods.IsGameObjectWithTagExsist(_tagGameInformationsTextContact);

                            //if (isGameObjectWithTagGameInformationsTextNextVersions == true)
                            //{
                            //    //Debug.Log(_tagGameInformationsTextNextVersions);
                            //    Debug.Log(1);
                            //    GameInformationsTextAction.DestroyText(_tagGameInformationsTextNextVersions);
                            //}

                            //if (isGameObjectWithTagGameInformationsTextContact == true)
                            //{
                            //   // Debug.Log(_tagGameInformationsTextContact);
                            //    Debug.Log(2);
                            //    GameInformationsTextAction.DestroyText(_tagGameInformationsTextContact);
                            //}

                            GameInformationsTextAction.DestroyGameObjectsWithText(_gameObjectsWithText);
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
