using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    internal class GameConfigurationTeamMembers : MonoBehaviour
    {
        public static int ConfigurationBoardGameTeamNumber { get; set; }

        public GameObject prefabCubePlay;

        public Material[] prefabCubePlayDefaultColour;
        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsNumberColour;
        public Material[] prefabCubePlayButtonsBackColour;

        private static bool _configurationBoardGameDeviceModeKind;
        private static bool _isCellphoneMode;

        private int _teamNumbers;
        private bool _isGame2D = true;
        private string _tagUntagged;

        List<List<GameObject[,,]>> _buttonsWithTeams;

        private string _tagConfigurationTeamMembersButtonSave;
        private string _tagConfigurationTeamNMembersButtonBack;
        private string _tagConfigurationTeamMembers;
        private string _tagConfigurationTeamMembersChangeNumber;
        private string _tagConfigurationTeamMembersTableWithNumbers;

        private string _tagConfigurationTeamMembersInactiveField;

        void Start()
        {

            //_configurationBoardGameDeviceModeKind = GameConfigurationKindOfGame.ConfigurationBoardGameDeviceModeKind;
            //_isCellphoneMode = _configurationBoardGameDeviceModeKind;
            //_isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();
            //Debug.Log("3 isCellphoneMode: " + _isCellphoneMode);

            _teamNumbers = GameConfigurationButtonsTeamMembersButtonsStaticData.GetDefaultTeamGameNumber();

            _tagUntagged = GameConfigurationButtonsCommonButtonsTagName.GetTagNameUntagged();


            _tagConfigurationTeamMembersButtonSave = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonSave();
            _tagConfigurationTeamNMembersButtonBack = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonBack();

            //_tagConfigurationTeamMembers = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersDefaultNumber();
            //_tagConfigurationTeamMembersChangeNumber = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersChange();
            //_tagConfigurationTeamMembersTableWithNumbers = GameConfigurationButtonsTeamNumbersTagName.GetTagNameForButtonByTagTeamNumbersTableWithNumbers();

            //GameStartButtonsCreate.CreateButtonsStartGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D);
            
            GameConfigurationTeamMembersButtonsCreate.GameConfigurationTeamMembersButtonsStatic(prefabCubePlay, prefabCubePlayDefaultColour, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D);
            _buttonsWithTeams = GameConfigurationTeamMembersButtonsCreate.GameConfigurationTeamMembersButtons(prefabCubePlay, prefabCubePlayDefaultColour, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D, _isCellphoneMode, _teamNumbers);
            //_buttonsWithNumbers = GameConfigurationTeamNumbersButtonsCreate.CreateTableForTeamGameWithNumbers(prefabCubePlay, prefabCubePlayDefaultColour, _isGame2D);

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




                        if (gameObjectTag == _tagConfigurationTeamMembersButtonSave)
                        {
                            //ConfigurationBoardGameTeamNumber = _teamNumbers;

                            ScenesChangeMainMethods.GoToSceneConfigurationBoardGame();
                        }

                        // back
                        if (gameObjectTag == _tagConfigurationTeamNMembersButtonBack)
                        {
                            if (_isCellphoneMode == true)
                                ScenesChangeMainMethods.GoToSceneStartGame();
                            else
                                ScenesChangeMainMethods.GoToSceneConfigurationGameTeamNumbers();
                        }


                    }
                }
            }
        }




    }
}
