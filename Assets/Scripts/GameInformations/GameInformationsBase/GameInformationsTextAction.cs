using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameInformations.GameInformationsBase
{
    internal class GameInformationsTextAction : MonoBehaviour
    {
        public static void DestroyText(string gameObjectTag)
        {
            GameObject gameObject = CommonMethods.GetObjectByTagName(gameObjectTag);
            Destroy(gameObject);
        }
    }
}
