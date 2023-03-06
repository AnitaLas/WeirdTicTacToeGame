using Assets.Scripts.GameConfiguration;
using Assets.Scripts.GameConfigurationPlayerSymbol;
using Assets.Scripts.GameDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    internal class GameConfigurationSetUpPlayersSymbols : MonoBehaviour
    {

        public  GameObject prefabSymbolPlayer;
        public Material[] prefabSymbolPlayerMaterial;

        private bool isGame2D = true;

        Dictionary<int, string> configurationPlayersSymbolsDictionaryTag = GameDictionariesCommon.DictionaryTagConfigurationPlayersSymbols();

        private string _tagConfiguratioPlayerSymbolDefaultNumber;
        private string _tagConfigurationPlayerSymbolDefaultSymbol;
        private string _tagConfigurationPlayerSymbolChange;

        private int numberOfDepths = 1;
        private int numberOfColumns = 1;
        private int numberOfRows = 7;

        GameObject[,,] tableWithPlayers;


        void Start()
        {

            _tagConfiguratioPlayerSymbolDefaultNumber = configurationPlayersSymbolsDictionaryTag[1];
            _tagConfigurationPlayerSymbolDefaultSymbol = configurationPlayersSymbolsDictionaryTag[2];
            _tagConfigurationPlayerSymbolChange = configurationPlayersSymbolsDictionaryTag[3];


        //tableWithPlayers =
        tableWithPlayers = GameConfigurationPlayerSymbolTableWithPlayerNumber.CreateTableWithPlayers(prefabSymbolPlayer, numberOfDepths, numberOfRows, numberOfColumns, prefabSymbolPlayerMaterial, isGame2D);
        GameConfigurationPlayerSymbolTableWithPlayerNumber.ChangeDataForTableWithPlayersSymbol(tableWithPlayers);

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
                        GameObject[] gameObjects = CommonMethods.GetObjectByTagName(gameObjectTag);
                        GameObject gameObject = gameObjects[0];


                        if (gameObjectTag == _tagConfiguratioPlayerSymbolDefaultNumber || gameObjectTag == _tagConfigurationPlayerSymbolDefaultSymbol)
                        {
                            Debug.Log(" 1 ");
                            GameConfigurationPlayerSymbolMainMethods.ChangeTagForDefaultPlayerSymbol(gameObject, gameObjectTag, _tagConfigurationPlayerSymbolChange);


                        }







                        if (gameObjectTag == "ConfigurationBoardGameButtonSave")
                        {
                            //Debug.Log(" test 1 ");

                            //ConfigurationBoardGameLenghtToCheckMax = lenghtToCheckMax;
                            SceneManager.LoadScene("SceneGame");



                        }

                    }
                }
            }


        }

        }
}
