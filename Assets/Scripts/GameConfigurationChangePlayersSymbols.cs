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
        public static int ConfigurationBoardGameChangePlayersSymbolsTime{ get; set; }
        public static int ConfigurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime { get; set; }
        public static bool ConfigurationBoardGameEqualMoveQuantityForBothTeams { get; set; }

        // ---
        //public GameObject prefabSymbolPlayer;
        public GameObject prefabCubePlay;
        public GameObject prefabCubePlayForTableNumber;

        //public Material[] prefabSymbolPlayerMaterial;
        //public Material[] prefabSymbolPlayerMaterialInactiveField;

        // --- new
        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsBackColour;
        public Material[] prefabCubePlayButtonsNumberColour;

        private bool _isGame2D = true;
        private static bool isTeamGame = false;

        public static int timeForChangePlayersSymbols;
        public static int timeForSwitchPlayersSymbolsBetweenTeams;
        public static bool isEqualMoveQuantityForBothTeams;



        private string _tagConfigurationChangePlayerSymbolButtonSave;
        private string _tagConfigurationChangePlayerSymbolButtonBack;

        //private List<GameObject[,,]> _buttonsBackAndSave;
        private List<GameObject[,,]> _buttonsAll;

        void Start()
        {
            timeForChangePlayersSymbols = 0;
            timeForSwitchPlayersSymbolsBetweenTeams= 0;
            isEqualMoveQuantityForBothTeams = true;

            _tagConfigurationChangePlayerSymbolButtonSave = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonChangePlayersSymbolsButtonSave();
            _tagConfigurationChangePlayerSymbolButtonBack = GameConfigurationButtonsCommonButtonsTagName.GetTagForButtonChangePlayersSymbolsButtonBack();

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
                        //Debug.Log("gameObjectTag = " + gameObjectTag);


                        if (gameObjectTag == _tagConfigurationChangePlayerSymbolButtonSave)
                        {
                            ConfigurationBoardGameChangePlayersSymbolsTime = timeForChangePlayersSymbols;
                            ConfigurationBoardGameSwitchPlayersSymbolsBetweenTeamsTime = timeForSwitchPlayersSymbolsBetweenTeams;
                            ConfigurationBoardGameEqualMoveQuantityForBothTeams = isEqualMoveQuantityForBothTeams;
;
                            ScenesChangeMainMethods.GoToSceneGame();
                        }

                        if (gameObjectTag == _tagConfigurationChangePlayerSymbolButtonBack)
                        {
                            ScenesChangeMainMethods.GoToSceneConfigurationPlayersSymbols();
                        }









                    }






                }
            }
        }
    }
                
}
