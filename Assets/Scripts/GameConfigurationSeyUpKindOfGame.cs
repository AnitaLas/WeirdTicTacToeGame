using Assets.Scripts.GameConfiguration.GameConfigurationPlayerSymbolButtons;
using Assets.Scripts.GameConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class GameConfigurationSeyUpKindOfGame : MonoBehaviour
    {
        public GameObject prefabCubePlay;

        public Material[] prefabCubePlayButtonsDefaultColour;
        public Material[] prefabCubePlayButtonsInformationColour;

        void Start()
        {


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

                    }






                }
            }
        }
    }
                
}
