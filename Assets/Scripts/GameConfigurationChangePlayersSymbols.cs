using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{ 

    internal class GameConfigurationChangePlayersSymbols : MonoBehaviour
    {
        public static int ConfigurationBoardGameChangeRandomlyPlayersSymbolsTime { get; set; }
        public static int ConfigurationBoardGameChangeForAllPlayersSymbolsTime { get; set; }
        public static int ConfigurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime { get; set; }
        public static bool ConfigurationBoardGameEqualMoveQuantityForBothTeams { get; set; }

        // ---
        //public GameObject prefabSymbolPlayer;
        public GameObject prefabCubePlay;
        public GameObject prefabCubePlayForTableNumber;

        //public Material[] prefabSymbolPlayerMaterial;
        //public Material[] prefabSymbolPlayerMaterialInactiveField;

        // --- new
        public Material[] prefabCubePlayDefaultColour;
        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsBackColour;
        public Material[] prefabCubePlayButtonsNumberColour;

        private bool _isGame2D = true;
        private static bool isTeamGame = false;
        private bool isCellphoneMode = true;

        public static int timeButtonRandomly;
        public static int timeButtonForAll;
        public static int timeButtonSwitchSymbolsBetweenTeams;

        public static int timeForSwitchPlayersSymbolsBetweenTeams;
        public static bool isEqualMoveQuantityForBothTeams;

        private string _tagConfigurationChangePlayerSymbolButtonSave;
        private string _tagConfigurationChangePlayerSymbolButtonBack;

        private string _tagConfigurationChangePlayersSymbolsRandomly;
        private string _tagConfigurationChangePlayersSymbolsChangeNumberRandomly;
        private string _tagConfigurationChangePlayersSymbolsTableNumberRandomly;

        private string _tagConfigurationChangePlayersSymbolsForAll;
        private string _tagConfigurationChangePlayersSymbolsChangeNumberForAll;
        private string _tagConfigurationChangePlayersSymbolsTableNumberForAll;

        private string _tagConfigurationChangePlayersSymbolsBackToConfiguration;

        private List<GameObject[,,]> _buttonsAll;
        private List<GameObject[,,]> _buttonsMoreSpecificConfiguration;
        private GameObject[,,] _buttonsWithNumbers;

        void Start()
        {
            timeButtonRandomly = 0;
            timeButtonForAll = 0;
            timeButtonSwitchSymbolsBetweenTeams = 0;
            isEqualMoveQuantityForBothTeams = true;

            _tagConfigurationChangePlayerSymbolButtonSave = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonChangePlayersSymbolsButtonSave();
            _tagConfigurationChangePlayerSymbolButtonBack = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonChangePlayersSymbolsButtonBack();

            _tagConfigurationChangePlayersSymbolsRandomly = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonChangeRandomly();
            _tagConfigurationChangePlayersSymbolsChangeNumberRandomly = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberRandomly();
            _tagConfigurationChangePlayersSymbolsTableNumberRandomly = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberRandomly();

            _tagConfigurationChangePlayersSymbolsForAll = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonChangForAll();
            _tagConfigurationChangePlayersSymbolsChangeNumberForAll = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonNumberByTagChangeNumberForAll();
            _tagConfigurationChangePlayersSymbolsTableNumberForAll = GameConfigurationButtonsCommonButtonsTagName.GetTagForTableWithNumbersByTagTableNumberForAll();

            _tagConfigurationChangePlayersSymbolsBackToConfiguration = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonBackByTagButtonBackToConfigurationChangePlayersSymbols();

            _buttonsAll = GameConfigurationChangePlayerSymbolButtonsCreate.GameConfigurationChangePlayerSymbolCreateButtons(prefabCubePlay, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsNumberColour, prefabCubePlayButtonsBackColour, _isGame2D, isTeamGame);

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
                        string gameObjectName = CommonMethods.GetObjectName(touch);

                        // change radomly
                        if (gameObjectTag == _tagConfigurationChangePlayersSymbolsRandomly || gameObjectTag == _tagConfigurationChangePlayersSymbolsChangeNumberRandomly)
                        {
                            _buttonsWithNumbers = GameConfigurationChangePlayerSymbolButtonsCreate.CreateTableForRandomlyWithTime(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, _isGame2D);
                            _buttonsMoreSpecificConfiguration = GameConfigurationChangePlayerSymbolButtonsCreate.GameConfigurationCreateButtonsBackAndRandomly(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, _isGame2D);

                            GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                        }


                        if (gameObjectTag == _tagConfigurationChangePlayersSymbolsTableNumberRandomly)
                        {
                            //timeButtonRandomly = GameConfigurationButtonsCommonMethods.SetUpChosenNumberForConfigurationRandomly(_buttonsWithNumbers, gameObjectName);
                            timeButtonRandomly = GameConfigurationButtonsWithNumbersForChangeRandomlyAndForAll.SetUpChosenTimeForConfigurationRandomly(_buttonsWithNumbers, gameObjectName);

                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);
                        }

                        //change for all
                        if (gameObjectTag == _tagConfigurationChangePlayersSymbolsForAll || gameObjectTag == _tagConfigurationChangePlayersSymbolsChangeNumberForAll)
                            {
                                _buttonsWithNumbers = GameConfigurationChangePlayerSymbolButtonsCreate.CreateTableForForAllWithTime(prefabCubePlayForTableNumber, prefabCubePlayDefaultColour, _isGame2D);
                                _buttonsMoreSpecificConfiguration = GameConfigurationChangePlayerSymbolButtonsCreate.GameConfigurationCreateButtonsBackAndForAll(prefabCubePlayForTableNumber, prefabCubePlayButtonsDefaultColour, prefabCubePlayButtonsBackColour, prefabCubePlayButtonsNumberColour, _isGame2D);

                                GameConfigurationButtonsActions.HideConfiguration(_buttonsAll);
                            }


                        if (gameObjectTag == _tagConfigurationChangePlayersSymbolsTableNumberForAll)
                        {
                            //timeButtonForAll = GameConfigurationButtonsCommonMethods.SetUpChosenNumberForConfigurationForAll(_buttonsWithNumbers, gameObjectName);
                            timeButtonForAll = GameConfigurationButtonsWithNumbersForChangeRandomlyAndForAll.SetUpChosenTimeForConfigurationForAll(_buttonsWithNumbers, gameObjectName);

                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);
                        }






                        // button save
                        if (gameObjectTag == _tagConfigurationChangePlayerSymbolButtonSave)
                        {
                            ConfigurationBoardGameChangeRandomlyPlayersSymbolsTime = timeButtonRandomly;
                            ConfigurationBoardGameChangeForAllPlayersSymbolsTime = timeButtonForAll;
                            ConfigurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime = timeForSwitchPlayersSymbolsBetweenTeams;
                            ConfigurationBoardGameEqualMoveQuantityForBothTeams = isEqualMoveQuantityForBothTeams;
;
                            ScenesChangeMainMethods.GoToSceneGame();
                        }

                        // button back
                        if (gameObjectTag == _tagConfigurationChangePlayerSymbolButtonBack)
                        {
                            ScenesChangeMainMethods.GoToSceneConfigurationPlayersSymbols();
                            //ScenesChangeMainMethods.GoToSceneConfigurationBoardGame();
                        }

                        // button back to configuration
                        if (gameObjectTag == _tagConfigurationChangePlayersSymbolsBackToConfiguration)
                        {
                            GameConfigurationButtonsActions.DestroyButtons(_buttonsMoreSpecificConfiguration, _buttonsWithNumbers);
                            GameConfigurationButtonsActions.UnhideConfiguration(_buttonsAll);
                        }








                    }






                }
            }
        }
    }
                
}
