using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets
{
    internal class GameConfigurationTeamMembers : MonoBehaviour
    {
        //public static int ConfigurationBoardGameTeamNumber { get; set; }

        public GameObject prefabCubePlay;
        public GameObject buttonArrowLeft;
        public GameObject buttonArrowRight;

        public Material[] prefabCubePlayDefaultColour;
        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsNumberColour;
        public Material[] prefabCubePlayButtonsBackColour;

        public static bool _configurationBoardGameDeviceModeKind;
        private static int _configurationBoardGameTeamNumber;
        public static bool _isCellphoneMode;

        private int _teamNumbers;
        private int _playersNumbersForTeamGameMax;
        private int _playersNumbersForTeamGameCounted;
        private int _indexForOneTeamGameButtonsVisible;

        private bool _isGame2D = true;
        private string _tagUntagged;



        private string _tagConfigurationTeamMembersButtonSave;
        private string _tagConfigurationTeamNMembersButtonBack;
        private string _tagConfigurationTeamMembers;
        private string _tagConfigurationTeamMembersChangeNumber;
        private string _tagConfigurationTeamMembersDefaultNumber;
        private string _tagConfigurationTeamMembersTableWithNumbers;
        private string _configurationTeamMembersTableWithTeamSymbols;
        private string _configurationTeamMembersTableWithAllSymbols;
        private string _configurationTeamMembersArrowLeft;
        private string _configurationTeamMembersArrowRight;
        //private string _configurationTeamMembersDefaultSymbols;
        private string _configurationTeamMembersButtonBackToConfigurationFromChangePlayersNumber;
        private string _configurationTeamMembersButtonBackToConfigurationFromChangePlayersSymbol;

        //private string _tagConfigurationTeamMembersInactiveField;

        private List<List<GameObject[,,]>> _buttonsWithTeams;
        private List<List<GameObject[,,]>> _buttonsGroupByTeams;

        private List<GameObject[,,]> _buttonsStatic;
        private List<GameObject[,,]> _buttonsMoreSpecificConfiguration;

        private List<GameObject> _buttonsArrows;
        private List<string[]> _tablesWitPlayersChosenSymbols;
        private int[] _tablesWitPlayersNumbersForTeams;


        void Start()
        {
           
            //_configurationBoardGameDeviceModeKind = GameConfigurationKindOfGame.ConfigurationBoardGameDeviceModeKind;
            //_isCellphoneMode = _configurationBoardGameDeviceModeKind;
            _isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();
            //Debug.Log("MMMMMM isCellphoneMode: " + _isCellphoneMode);

            if (_isCellphoneMode == false)
            {
                _configurationBoardGameTeamNumber = GameConfigurationTeamNumbers.ConfigurationBoardGameTeamNumber;
                _teamNumbers = _configurationBoardGameTeamNumber;
               // Debug.Log("teamNumbers: " + _teamNumbers);
                _buttonsArrows = GameConfigurationTeamMembersButtonsCreate.GameConfigurationTeamMembersCreateButtonsArrows(buttonArrowLeft, buttonArrowRight);
                _indexForOneTeamGameButtonsVisible = 0;

                _playersNumbersForTeamGameMax = GameConfigurationTeamMembersButtonsMethods.SetUpMaxPlayersNumbersForTeamGameAtStart();
                _playersNumbersForTeamGameCounted = GameConfigurationTeamMembersButtonsMethods.SetUpPlayersNumbersForTeamGameAtStart(_teamNumbers);

            }
            else
            {
                _teamNumbers = GameConfigurationButtonsTeamMembersButtonsStaticData.GetDefaultTeamGameNumber();
            }
           
            //_isCellphoneMode = ScreenVerificationMethods.IsCellphoneMode();
            //Debug.Log("3 isCellphoneMode: " + _isCellphoneMode);

           

            _tagUntagged = GameConfigurationButtonsCommonButtonsTagName.GetTagNameUntagged();


            _tagConfigurationTeamMembersButtonSave = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonSave();
            _tagConfigurationTeamNMembersButtonBack = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonBack();

            _tagConfigurationTeamMembersDefaultNumber = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersDefaultNumber();
            _configurationTeamMembersButtonBackToConfigurationFromChangePlayersNumber = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonButtonBackToConfigurationFromChangePlayersNumber();
            _tagConfigurationTeamMembersTableWithNumbers = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersTableWithNumbers();

            _configurationTeamMembersTableWithTeamSymbols = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersTableWithTeamSymbols();
            _configurationTeamMembersButtonBackToConfigurationFromChangePlayersSymbol = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonButtonBackToConfigurationFromChangePlayersSymbol();
            _configurationTeamMembersTableWithAllSymbols = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersTableWithAllSymbols();

            _configurationTeamMembersArrowLeft = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonArrowLeft();
            _configurationTeamMembersArrowRight = GameConfigurationButtonsTeamMembersTagName.GetTagNameForButtonByTagTeamMembersButtonArrowRight();

            //GameStartButtonsCreate.CreateButtonsStartGame(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D);

            _buttonsStatic = GameConfigurationTeamMembersButtonsCreate.GameConfigurationTeamMembersButtonsStatic(prefabCubePlay, buttonArrowLeft, buttonArrowRight, prefabCubePlayDefaultColour, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D);
            _buttonsWithTeams = GameConfigurationTeamMembersButtonsCreate.GameConfigurationTeamMembersButtons(prefabCubePlay, prefabCubePlayDefaultColour, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D, _isCellphoneMode, _teamNumbers);
            //_buttonsWithNumbers = GameConfigurationTeamNumbersButtonsCreate.CreateTableForTeamGameWithNumbers(prefabCubePlay, prefabCubePlayDefaultColour, _isGame2D);
            _buttonsGroupByTeams = GameConfigurationTeamMembersButtonsMethods.CreateListButtonsByTeams(_buttonsWithTeams, _teamNumbers);
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

                        //Debug.Log("gameObjectTag: " + gameObjectTag);

                        if (gameObjectTag != _tagUntagged)
                        {
                            GameObject gameObject = GameCommonMethodsMain.GetObjectByTagName(gameObjectTag);
                        }

                        // team - players numbers
                        if (gameObjectTag == _tagConfigurationTeamMembersDefaultNumber)
                        {
                            GameConfigurationTeamMembersButtonsActions.HideTeamMembersElementsPlayersNumbers(_buttonsStatic, _buttonsWithTeams, gameObjectName);
                            _buttonsMoreSpecificConfiguration = GameConfigurationTeamMembersButtonsCreate.GameConfigurationTeamMembersButtonBackAndTableWithNumbers(prefabCubePlay, prefabCubePlayDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsDefaultColour, _isGame2D, gameObjectName);

                            if (_isCellphoneMode == false)
                                GameConfigurationTeamMembersButtonsActions.HideArrows(_buttonsArrows);
                        }

                        if (gameObjectTag == _tagConfigurationTeamMembersTableWithNumbers)
                        {
                            //GameConfigurationTeamMembersButtonsActions.UnhideTeamMembersElementsWhenBackFromViewTableNumbers(_buttonsStatic, _buttonsWithTeams, gameObjectName);
                            GameConfigurationTeamMembersButtonsActions.UnhideTeamMembersElementsAfterChangePlayersNumber(_buttonsStatic, _buttonsWithTeams, gameObjectName);
                            GameConfigurationTeamMembersButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration);

                            _tablesWitPlayersNumbersForTeams = GameConfigurationTeamMembersButtonsMethods.CreateTablesWithTeamNumberOfPlayers(_buttonsGroupByTeams);
                            _tablesWitPlayersChosenSymbols = GameConfigurationTeamMembersButtonsMethods.CreateTablesWithTeamsPlayersSymbols(_buttonsGroupByTeams);

                            GameConfigurationTeamMembersButtonsMethods.SetUpRightSymbolsForTeam(_buttonsGroupByTeams, _tablesWitPlayersNumbersForTeams, _tablesWitPlayersChosenSymbols);

                            if (_isCellphoneMode == false)
                                GameConfigurationTeamMembersButtonsActions.UnhideArrows(_buttonsArrows);

                        }

                        if (gameObjectTag == _configurationTeamMembersButtonBackToConfigurationFromChangePlayersNumber)
                        {
                            GameConfigurationTeamMembersButtonsActions.UnhideTeamMembersElementsWhenBackFromViewTableNumbers(_buttonsStatic, _buttonsWithTeams, gameObjectName);
                            //GameConfigurationTeamMembersButtonsActions.DestroyButtonsForTeamNumbers(_buttonsMoreSpecificConfiguration);
                            GameConfigurationTeamMembersButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration);

                            if (_isCellphoneMode == false)
                                GameConfigurationTeamMembersButtonsActions.UnhideArrows(_buttonsArrows);
                        }


                        // team - palyers symbol

                        if (gameObjectTag == _configurationTeamMembersTableWithTeamSymbols)
                        {
                            GameConfigurationTeamMembersButtonsActions.HideTeamMembersElementsPlayersSymbols(_buttonsStatic, _buttonsWithTeams, gameObjectName);
                            _tablesWitPlayersChosenSymbols = GameConfigurationTeamMembersButtonsMethods.CreateTablesWithTeamsPlayersSymbols(_buttonsGroupByTeams);

                            _buttonsMoreSpecificConfiguration = GameConfigurationTeamMembersButtonsCreate.GameConfigurationTeamMembersButtonBackAndTableWithSymbols(prefabCubePlay, prefabCubePlayDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsDefaultColour, _isGame2D, gameObjectName, _tablesWitPlayersChosenSymbols);


                            if (_isCellphoneMode == false)
                                GameConfigurationTeamMembersButtonsActions.HideArrows(_buttonsArrows);

                        }     

                        if (gameObjectTag == _configurationTeamMembersTableWithAllSymbols)
                        {
                            GameConfigurationTeamMembersButtonsActions.UnhideTeamMembersElementsAfterChangePlayerSymbol(_buttonsStatic, _buttonsWithTeams, gameObjectName);
                            //GameConfigurationTeamMembersButtonsActions.DestroyButtonsForTeamNumbers(_buttonsMoreSpecificConfiguration);
                            GameConfigurationTeamMembersButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration);

                            if (_isCellphoneMode == false)
                                GameConfigurationTeamMembersButtonsActions.UnhideArrows(_buttonsArrows);
                        }

                        if (gameObjectTag == _configurationTeamMembersButtonBackToConfigurationFromChangePlayersSymbol)
                        {
                            GameConfigurationTeamMembersButtonsActions.UnhideTeamMembersElementsWhenBackFromViewTableSymbols(_buttonsStatic, _buttonsWithTeams, gameObjectName);
                            GameConfigurationTeamMembersButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration);

                            if (_isCellphoneMode == false)
                                GameConfigurationTeamMembersButtonsActions.HideArrows(_buttonsArrows);
                        }


                        // buttons: arrow left & right - tablet mode: switch teams for set up 


                        if (gameObjectTag == _configurationTeamMembersArrowLeft)
                        {
                            //GameConfigurationTeamMembersButtonsActions.UnhideTeamMembersElementsWhenBackFromViewTableSymbols(_buttonsStatic, _buttonsWithTeams, gameObjectName);


                            _indexForOneTeamGameButtonsVisible = GameConfigurationTeamMembersButtonsActions.SetUpNewIndexForOneTeamGameButtonsVisible(_buttonsGroupByTeams, _indexForOneTeamGameButtonsVisible, _configurationTeamMembersArrowLeft);








                        }

                        if (gameObjectTag == _configurationTeamMembersArrowRight)
                        {
                            _indexForOneTeamGameButtonsVisible = GameConfigurationTeamMembersButtonsActions.SetUpNewIndexForOneTeamGameButtonsVisible(_buttonsGroupByTeams, _indexForOneTeamGameButtonsVisible, _configurationTeamMembersArrowLeft);

                        }



                        // buttons: save & back (to previous scene)

                        if (gameObjectTag == _tagConfigurationTeamMembersButtonSave)
                        {
                            //ConfigurationBoardGameTeamNumber = _teamNumbers;

                            ScenesChangeMainMethods.GoToSceneConfigurationBoardGame();
                        }


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
