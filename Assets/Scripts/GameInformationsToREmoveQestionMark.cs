using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameInformationsToREmoveQestionMark : MonoBehaviour /// should we remove this class?
    {

        public GameObject prefabCubePlay;

        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsBackColour;

        private bool isGame2D = true;

        private string _tagUntagged;
        private string _tagGameInformationsButtonBack;
        private string _tagGameInformationsButtonBackToMenu;
        private string _tagGameInformationsButtonContact;
        private string _tagGameInformationsButtonNextVersions;

        //Dictionary<int, string> tagCommonDictionary = GameDictionariesScenesCommon.DictionaryTagCommon();
        Dictionary<int, string> tagGameInformations = GameDictionariesSceneInformation.DictionaryTagsGameInformation();

        private GameObject[,,] _buttonBack;
        private List<GameObject[,,]> _buttonsAll;


        void Start()
        {
            //_tagUntagged = tagCommonDictionary[1];
            _tagUntagged = GameConfigurationButtonsCommonButtonsTagName.GetTagNameUntagged();
            _tagGameInformationsButtonBack = tagGameInformations[1];
            _tagGameInformationsButtonBackToMenu = tagGameInformations[4];
            _tagGameInformationsButtonContact = tagGameInformations[2];
            _tagGameInformationsButtonNextVersions = tagGameInformations[3];

            _buttonBack = GameInformationButtonsCreate.GameInformationsCreateButtonBack(prefabCubePlay, prefabCubePlayButtonsBackColour, isGame2D);
            _buttonsAll = GameInformationButtonsCreate.GameInformationsCreateButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, isGame2D);

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
                            GameInformationButtonsAction.HideButtons(_buttonsAll);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonContact)
                        {
                            GameInformationButtonsAction.HideButtons(_buttonsAll);
                        }

                        if (gameObjectTag == _tagGameInformationsButtonBackToMenu)
                        {
                            //ScenesChange.GoToSceneStartGame();
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
