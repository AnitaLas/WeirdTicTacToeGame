using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CommonMethods
{
    internal class CommonMethodsSetUpCoordinates
    {
        public static float RoundCoordinateXYZ(float coordinate)
        {
            double roundedCoordinate = coordinate;
            double test = Math.Round(roundedCoordinate, 2);
            float test2 = CommonMethodsMain.ConvertDoubleToFloat(test);

            return test2;
        }

        public static void SetUpNewXForGameObject(GameObject gameObject, float newCoordinateX)
        {
            bool isGame2D = true;

            if (isGame2D == true)
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;
                float z = gameObject.transform.position.z;

                gameObject.transform.position = new Vector3(x + newCoordinateX, y, z);
            }
        }

        public static void SetUpNewYForGameObject(GameObject gameObject, float newCoordinateY)
        {
            bool isGame2D = true;

            if (isGame2D == true)
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;
                float z = gameObject.transform.position.z;

                float newY = RoundCoordinateXYZ(y + newCoordinateY);

                gameObject.transform.position = new Vector3(x, newY, z);
            }
        }

        public static void ChangeZForGameObject(GameObject gameObject, float newCoordinateZ)
        {
            bool isGame2D = true;

            if (isGame2D == true)
            {
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;

                gameObject.transform.position = new Vector3(x, y, newCoordinateZ);
            }
        }

        public static void ChangeYForGameObject(GameObject gameObject, float newCoordinateY)
        {
            bool isGame2D = true;

            if (isGame2D == true)
            {
                float x = gameObject.transform.position.x;
                float z = gameObject.transform.position.z;

                gameObject.transform.position = new Vector3(x, newCoordinateY, z);
            }
        }

        public static void ChangeXForGameObject(GameObject gameObject, float newCoordinateX)
        {
            bool isGame2D = true;

            if (isGame2D == true)
            {
                float y = gameObject.transform.position.y;
                float z = gameObject.transform.position.z;

                gameObject.transform.position = new Vector3(newCoordinateX, y, z);
            }
        }
    }
}
