using Assets.Scripts.GameConfiguration;
using Assets.Scripts.GameConfigurationPlayerSymbol;
using Assets.Scripts.GameDictionaries;
using Assets.Scripts.GameConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Assets.Scripts
{
    internal class GameConfigurationSetUpPlayersSymbols : MonoBehaviour
    {
        public static string[] ConfigurationPlayerSymbolTableWitPlayersChosenSymbols { get; set; }

        public  GameObject prefabSymbolPlayer;
        public GameObject prefabCubePlay;

        public Material[] prefabSymbolPlayerMaterial;
        public Material[] prefabSymbolPlayerMaterialInactiveField;

        private bool isGame2D = true;

        Dictionary<int, string> configurationPlayersSymbolsDictionaryTag = GameDictionariesCommon.DictionaryTagConfigurationPlayersSymbols();

        private string _tagConfiguratioPlayerSymbolDefaultNumber;
        private string _tagConfigurationPlayerSymbolDefaultSymbol;
        private string _tagConfigurationPlayerSymbolChange;
        private string _tagConfigurationPlayerSymbolChooseSymbol;
        private string _tagConfigurationPlayerSymbolInactiveField;
        private string _tagConfigurationPlayerSymbolButtonSave;
        private string _tagConfigurationPlayerSymbolButtonBack;
        private string _tagConfigurationPlayerSymbolButtonBackTableWithSymbolsToChoose;

        Dictionary<int, string> scenceDictionary = GameDictionariesCommon.DictionaryScence();

        private string _sceneGame;
        private string _sceneConfigurationPlayersSymbols;

        private int numberOfDepths = 1;
        private int numberOfColumns = 1;
        private int numberOfPlayers;

        private int numberOfDepthsForTableWithSymbols = 1;
        private int numberOfColumnsForTableSymbols = 4;
        private int numberOfRowsForTableWithSymbols = 7;

        GameObject[,,] tableWithPlayersAndSymbolsBase;
        GameObject[,,] tableWithPlayersAndSymbols;
        GameObject[,,] tableWithSymbolsBase;
        GameObject[,,] tableWitSymbols;
        string[] tableWitPlayersChosenSymbols;

        private string _gameObjectParentNameChanged;

        private string[] _tagConfigurationDefaultButton = new string[2];
        private string[] _tagConfigurationButtonBackTableWithSymbolsToChoose = new string[1];

        void Start()
        {

            _tagConfiguratioPlayerSymbolDefaultNumber = configurationPlayersSymbolsDictionaryTag[1];
            _tagConfigurationPlayerSymbolDefaultSymbol = configurationPlayersSymbolsDictionaryTag[2];
            _tagConfigurationPlayerSymbolChange = configurationPlayersSymbolsDictionaryTag[3];
            _tagConfigurationPlayerSymbolChooseSymbol = configurationPlayersSymbolsDictionaryTag[4];
            _tagConfigurationPlayerSymbolInactiveField = configurationPlayersSymbolsDictionaryTag[5];

            _tagConfigurationPlayerSymbolButtonSave = configurationPlayersSymbolsDictionaryTag[6];
            _tagConfigurationPlayerSymbolButtonBack = configurationPlayersSymbolsDictionaryTag[7];
            _tagConfigurationPlayerSymbolButtonBackTableWithSymbolsToChoose = configurationPlayersSymbolsDictionaryTag[8];

            // ---
            _sceneGame = scenceDictionary[1];
            _sceneConfigurationPlayersSymbols = scenceDictionary[3];
            
            // ---
            _tagConfigurationDefaultButton[0] = _tagConfigurationPlayerSymbolButtonSave;
            _tagConfigurationDefaultButton[1] = _tagConfigurationPlayerSymbolButtonBack;

            // ---
            _tagConfigurationButtonBackTableWithSymbolsToChoose[0] = _tagConfigurationPlayerSymbolButtonBackTableWithSymbolsToChoose;

            // ---
            numberOfPlayers = GameConfigurationSetUpBoardGame.ConfigurationBoardGameNumberOfPlayers;

            // configuration table with players and defaul symbol
            tableWithPlayersAndSymbolsBase = GameConfigurationPlayerSymbolTableWithPlayerNumber.CreateTableWithPlayers(prefabSymbolPlayer, numberOfDepths, numberOfPlayers, numberOfColumns, prefabSymbolPlayerMaterial, isGame2D);
            tableWithPlayersAndSymbols = GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayersAndSymbols(tableWithPlayersAndSymbolsBase);

            GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationButtonBackTableWithSymbolsToChoose);



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
                        //GameObject gameObject = CommonMethods.GetObjectByTagName(gameObjectTag);
                        //Debug.Log("gameObjectTag = " + gameObjectTag);

                        if (gameObjectTag != "Untagged")
                        {
                            GameObject gameObject = CommonMethods.GetObjectByTagName(gameObjectTag);
                        }
                        

                        if (gameObjectTag == _tagConfiguratioPlayerSymbolDefaultNumber || gameObjectTag == _tagConfigurationPlayerSymbolDefaultSymbol)
                        {
                            /* bad idea to put it here
                            if (tableWithSymbolsBase != null || tableWitSymbols != null)
                            {
                                GameConfigurationTableForLenghtToCheck.DestroyTable(tableWithSymbolsBase);
                                GameConfigurationTableForLenghtToCheck.DestroyTable(tableWitSymbols);
                            }
                            */

                            string gameObjectParentName = CommonMethods.GetParentObjectName(touch);
                            _gameObjectParentNameChanged = gameObjectParentName;

                            GameObject gameObjectParent = CommonMethods.GetObjectByName(gameObjectParentName);
                            GameConfigurationPlayerSymbolCommonMethods.ChangeTagForDefaultPlayerSymbol(gameObjectParent, _tagConfigurationPlayerSymbolChange);

                            GameConfigurationPlayerSymbolCommonMethods.HideTableWithNumber(tableWithPlayersAndSymbols);

                            // ---
                            tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(tableWithPlayersAndSymbols);

                            // configuration table with the symbol which may be chosen by users
                            tableWithSymbolsBase = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithSymbols(prefabCubePlay, numberOfDepthsForTableWithSymbols, numberOfRowsForTableWithSymbols, numberOfColumnsForTableSymbols, prefabSymbolPlayerMaterial, isGame2D);
                            tableWitSymbols = GameConfigurationPlayerSymbolTableWithSymbols.ChangeDataForTableWithSymbols(tableWithSymbolsBase, tableWitPlayersChosenSymbols, prefabSymbolPlayerMaterialInactiveField, _tagConfigurationPlayerSymbolChooseSymbol, _tagConfigurationPlayerSymbolInactiveField);

                            GameConfigurationPlayerSymbolCommonMethods.UnhideTableWithNumber(tableWitSymbols);

                            
                            GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationDefaultButton);
                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationButtonBackTableWithSymbolsToChoose);

                        }



                        if (gameObjectTag == _tagConfigurationPlayerSymbolChooseSymbol)
                        {
                            string gameObjectNameForChosenSymbol = CommonMethods.GetObjectName(touch);
                            GameObject gameObjectForChosenSymbol = CommonMethods.GetObjectByName(gameObjectNameForChosenSymbol);
                           
                            string newSymbol = CommonMethods.GetCubePlayText(gameObjectForChosenSymbol);
                            GameConfigurationPlayerSymbolCommonMethods.ChangeSymbolForPlayer(newSymbol, _tagConfigurationPlayerSymbolChange);

                            GameObject gameObjectParent = CommonMethods.GetObjectByName(_gameObjectParentNameChanged);
                            GameConfigurationPlayerSymbolCommonMethods.ChangeTagForDefaultPlayerSymbol(gameObjectParent, _tagConfigurationPlayerSymbolDefaultSymbol);

                            GameConfigurationPlayerSymbolCommonMethods.UnhideTableWithNumber(tableWithPlayersAndSymbols);

                            GameConfigurationTableForLenghtToCheck.DestroyTable(tableWithSymbolsBase);
                            GameConfigurationTableForLenghtToCheck.DestroyTable(tableWitSymbols);

                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationDefaultButton);
                            GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationButtonBackTableWithSymbolsToChoose);

                        }

                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonBackTableWithSymbolsToChoose)
                        {

                            GameConfigurationPlayerSymbolCommonMethods.UnhideTableWithNumber(tableWithPlayersAndSymbols);
                            GameConfigurationPlayerSymbolCommonMethods.HideTableWithNumber(tableWitSymbols);

                            GameConfigurationCommonMethods.UnhideConfiguration(_tagConfigurationDefaultButton);
                            GameConfigurationCommonMethods.HideConfiguration(_tagConfigurationButtonBackTableWithSymbolsToChoose);
                        }



                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonSave)
                        {

                            tableWitPlayersChosenSymbols = GameConfigurationPlayerSymbolTableWithSymbols.CreateTableWithPlayersChosenSymbols(tableWithPlayersAndSymbols);
                            ConfigurationPlayerSymbolTableWitPlayersChosenSymbols = tableWitPlayersChosenSymbols;


                           // SceneManager.LoadScene("SceneGame");
                           // CommonMethods.ChangeScene(_sceneGame);
                            CommonMethods.ChangeScene(_sceneGame);



                        }


                        if (gameObjectTag == _tagConfigurationPlayerSymbolButtonBack)
                        {
                            Debug.Log(" 1 ");
                            CommonMethods.ChangeScene(_sceneConfigurationPlayersSymbols);

                        }

                    }
                }
            }


        }

        }
}
