using Assets.Scripts;
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

        //private Dictionary<int, string> _tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();
        //private Dictionary<int, string> _tagGameInformations = GameDictionariesSceneInformation.DictionaryTagsGameInformation();

        private GameObject[,,] _buttonBack;
        private List<GameObject[,,]> _buttonsAll;
        private List<string> _gameObjectsWithText;

        void Start()
        {
            //_tagUntagged = _tagCommonDictionary[1];
            _tagUntagged = GameConfigurationButtonsCommonButtonsTagName.GetTagNameUntagged();
            //_tagGameInformationsButtonBack = _tagGameInformations[1];
            //_tagGameInformationsButtonBackToMenu = _tagGameInformations[4];
            //_tagGameInformationsButtonContact = _tagGameInformations[2];
            //_tagGameInformationsButtonNextVersions = _tagGameInformations[3];
            //_tagGameInformationsTextContact = _tagGameInformations[5];
            //_tagGameInformationsTextNextVersions = _tagGameInformations[6];
            //_tagGameInformationsButtontSet = _tagGameInformations[7];
            //_tagGameInformationsTextSet = _tagGameInformations[8];

            _tagGameInformationsButtonBack = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBack();
            _tagGameInformationsButtonBackToMenu = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonBackToMenu();
            _tagGameInformationsButtonContact = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonContact();
            _tagGameInformationsButtonNextVersions = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtonNextVersions();
            _tagGameInformationsTextContact = GameInformationCommonButtonsTagName.GetTagTextByTagInformationTextContact();
            _tagGameInformationsTextNextVersions = GameInformationCommonButtonsTagName.GetTagTextByTagInformationTextNextVersions();
            _tagGameInformationsButtontSet = GameInformationCommonButtonsTagName.GetTagForButtonNameByTagInformationButtontSet();
            _tagGameInformationsTextSet = GameInformationCommonButtonsTagName.GetTagTextByTagInformationTextSet();

            _buttonBack = GameInformationButtonsCreate.GameInformationsCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, _isGame2D);
            _buttonsAll = GameInformationButtonsCreate.GameInformationsCreateButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, _isGame2D);

            GameInformationTextCreate.CreateGameName(gameName);
           
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
                        string gameObjectTag = GameCommonMethodsMain.GetObjectTag(touch);

                        if (gameObjectTag != _tagUntagged)
                        {
                            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(gameObjectTag);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonContact)
                        {
                            GameInformationButtonsAction.HideButtons(_buttonsAll);
                            GameInformationTextCreate.CreateGameInformationsTextContact(gameInformationsTextContact);
                            _gameObjectsWithText.Insert(0, _tagGameInformationsTextContact);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonNextVersions)
                        {
                            GameInformationButtonsAction.HideButtons(_buttonsAll);
                            GameInformationTextCreate.CreateGameInformationsTextNextVersions(gameInformationsTextNextVersions);
                            _gameObjectsWithText.Insert(0, _tagGameInformationsTextNextVersions);
                        }

                        if (gameObjectTag == _tagGameInformationsButtontSet)
                        {
                            GameInformationButtonsAction.HideButtons(_buttonsAll);
                            GameInformationTextCreate.CreateGameInformationsTextSet(gameInformationsTextSet);
                            _gameObjectsWithText.Insert(0, _tagGameInformationsTextSet);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonBackToMenu)
                        {
                            GameInformationButtonsAction.UnhideButtons(_buttonsAll);
                            GameInformationTextActions.DestroyGameObjectsWithText(_gameObjectsWithText);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonBack)
                        {
                            ScenesChangeMainMethods.GoToSceneStartGame();
                        }
                    }
                }
            }
        }
    }
}
