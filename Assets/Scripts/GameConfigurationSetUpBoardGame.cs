using Assets.Scripts.GameDictionaries;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameConfiguration
{
    internal class GameConfigurationSetUpBoardGame : MonoBehaviour
    {
        //?? how to pass variables between 2 scenes ??
        public static string numberOfRowsConfiguration;



        GameObject[,,] tableWithNumber;
        GameObject[,,] tableWithNumberForRows;
        GameObject[,,] tableWithNumberForPlayers;

        public GameObject prefabCubePlayForTableNumber;

        public Material[] prefabCubePlayDefaultColour;

        Dictionary<int, string> configurationDictionaryTag = GameDictionariesCommon.DictionaryConfiguration();

        private string _tagConfigurationBoardGameButtonSave;
        private string _tagConfigurationBoardGameTableNumberRows;
        private string _tagConfigurationBoardGameRows;
        private string _tagConfigurationBoardGameChangeNumberRows;
        private string _tagConfigurationBoardGameInactiveField;
        



        private static bool isGame2D = true;

        private static int numberOfRowsD = 3;
        private static int numberOfColumnsD = 3;

        // default = 1; this is needed for future version 3D WeirdTicTacToeGame
        // it is not possible to change from UI
        private static int numberOfDepths = 1;

        public Touch touch;
        private Camera mainCamera;

        void Start()
        {
            _tagConfigurationBoardGameButtonSave = configurationDictionaryTag[1];
            _tagConfigurationBoardGameTableNumberRows = configurationDictionaryTag[3];
            _tagConfigurationBoardGameChangeNumberRows = configurationDictionaryTag[7];
            _tagConfigurationBoardGameInactiveField = configurationDictionaryTag[20];
            

            tableWithNumber = GameConfigurationTableForSetUp.CreateTableWithNumbers(prefabCubePlayForTableNumber, numberOfDepths, numberOfRowsD, numberOfColumnsD, prefabCubePlayDefaultColour, isGame2D);
            tableWithNumberForRows = GameConfigurationTableForRowsAndColumns.CreateTableForRowsAndColumns(tableWithNumber, _tagConfigurationBoardGameTableNumberRows, _tagConfigurationBoardGameInactiveField);
            //tableWithNumberForPlayers = GameConfigurationTableForPlayers.CreateTableForPlayers(tableWithNumber);

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
                        Debug.Log(" gameObjectName = " + gameObjectName);

                        //GameObject cubePlay = CommonMethods.GetObjectByTagName(gameObjectTag);
                        //Debug.Log(" test 0 ");
                        if (gameObjectTag == _tagConfigurationBoardGameButtonSave)
                        {
                            //Debug.Log(" test 1 ");
                            // GameConfigurationChangeScence.GoToPlayersSymbolsSetUp();
                            SceneManager.LoadScene("SceneGame");

                        }

                        if (gameObjectTag == _tagConfigurationBoardGameTableNumberRows)
                        {
                            Debug.Log(" test 1 ");

                            GameObject cubePlay = CommonMethods.GetCubePlay(tableWithNumber, gameObjectName);
                            numberOfRowsConfiguration = CommonMethods.GetCubePlayText(cubePlay);
                            Debug.Log(" chosenNumber = " + numberOfRowsConfiguration);

                            GameObject[] cubePlayForChange = CommonMethods.GetObjectByTagName(_tagConfigurationBoardGameChangeNumberRows);
                            GameObject cubePlayToChange = cubePlayForChange[0];
                            CommonMethods.ChangeTextForCubePlay(cubePlayToChange, numberOfRowsConfiguration);



                        }


                    }
                }
            }


           // Cursor.SetCursor();


        }
                        //    public static void GoToPlayersSymbolsSetUp()
                        //{
                        //    Debug.Log(" GameConfigurationChangeScence ");
                        //    SceneManager.LoadScene("SceneGame");
                        //}



    }
}
