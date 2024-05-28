using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    internal class GameConfigurationTeamNumbers : MonoBehaviour
    {

        public static int ConfigurationBoardGameTeamNumber { get; set; }    

        public GameObject prefabCubePlay;

        public Material[] prefabCubePlayDefaultColour;
        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsNumberColour;
        public Material[] prefabCubePlayButtonsBackColour;

        public static bool _configurationBoardGameDeviceModeKind;
        public static bool isCellphoneModeScene2;

        private int _teamNumbers;
        private bool _isGame2D = true;


        private GameObject[,,] _buttonsWithNumbers;

        private string _tagUntagged;

        private string _tagConfigurationTeamNumbersButtonSave;
        private string _tagConfigurationTeamNumbersButtonBack;
        //private string _tagConfigurationTeamNumbers;
        //private string _tagConfigurationTeamNumbersChangeNumber;
        private string _tagConfigurationTeamNumbersTableWithNumbers;

        //private string _tagConfigurationTeamNumbersInactiveField;



        void Start()
        {

            _configurationBoardGameDeviceModeKind = GameConfigurationKindOfGame.ConfigurationBoardGameDeviceModeKind;
            isCellphoneModeScene2 = _configurationBoardGameDeviceModeKind;

            //isCellphoneModeScene2 = ScreenVerificationMethods.IsCellphoneMode();

            //Debug.Log("2 team number -> isCellphoneMode: " + isCellphoneModeScene2);
            _teamNumbers = 2;

            _tagUntagged = GameConfigurationButtonsCommonButtonsTagName.GetTagNameUntagged();


            _tagConfigurationTeamNumbersButtonSave = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersButtonSave();
            _tagConfigurationTeamNumbersButtonBack = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersButtonBack();
            
            //_tagConfigurationTeamNumbers = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersDefaultNumber();
            //_tagConfigurationTeamNumbersChangeNumber = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersChange();
            _tagConfigurationTeamNumbersTableWithNumbers = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersTableWithNumbers();

            //GameStartButtonsCreate.CreateButtonsStartGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D);

            GameConfigurationTeamNumbersButtonsCreate.GameConfigurationTeamNumbersButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D);
            _buttonsWithNumbers = GameConfigurationTeamNumbersButtonsCreate.CreateTableForTeamGameWithNumbers(prefabCubePlay, prefabCubePlayDefaultColour, _isGame2D);

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
                        string gameObjectName = GameCommonMethodsMain.GetObjectName(touch);

                        if (gameObjectTag != _tagUntagged)
                        {
                            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(gameObjectTag);
                        }

                        if (gameObjectTag == _tagConfigurationTeamNumbersTableWithNumbers)
                        {

                            _teamNumbers = GameConfigurationTeamNumbersButtonsAction.SetUpChosenNumberForConfigurationTeamNumbers(_buttonsWithNumbers, gameObjectName);

                        }


                        if (gameObjectTag == _tagConfigurationTeamNumbersButtonSave)
                        {
                            ConfigurationBoardGameTeamNumber = _teamNumbers;

                            ScenesChangeMainMethods.GoToSceneConfigurationGameTeamMembers();
                        }

                        // back
                        if (gameObjectTag == _tagConfigurationTeamNumbersButtonBack)
                        {
                            ScenesChangeMainMethods.GoToSceneStartGame();
                        }


                    }
                }
            }
        }



    }
}
