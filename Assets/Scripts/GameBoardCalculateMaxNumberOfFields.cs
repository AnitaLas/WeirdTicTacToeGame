using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.InputSystem;
using UnityEngine;
//using Debug = System.Diagnostics.Debug;
using System.Drawing;
using Debug = UnityEngine.Debug;
using Unity.VisualScripting;
using UnityEngine.UIElements;

namespace Assets.Scripts
{

    public class GameBoardCalculateMaxNumberOfFields
    {



        /*
        > setup cube size x = 1, y = 1, z = 1
        > 1 size = 1 meter = 3779,5275590551 px
        */

        static private double _px = 3779.5275590551;
        static private double _meter = 1;

        // temporary screen width
        //static private double _screenWidth = 828;
        //static private double _screenHeight = 828;

       // double scaleWidth = CountMaxNumberOfFields(_meter, _screenWidth, _px);
       // double scaleHeight = CountMaxNumberOfFields(_meter, _screenHeight, _px);

        public static Tuple <double,double > MaxNumberOfFields(double screenWidth, double screenHeight)
        {
            double maxNumberOfFieldForWidth = CountMaxNumberOfFields(_meter, screenWidth, _px);
            double maxNumberOfFieldsForHeight = CountMaxNumberOfFields(_meter, screenHeight, _px);
            var maxNumberOfFields = new Tuple<double,double>(maxNumberOfFieldForWidth, maxNumberOfFieldsForHeight);
            //Debug.Log("maxNumberOfFields: " + maxNumberOfFields);
            return maxNumberOfFields;
        }

        public static double CountMaxNumberOfFields(double meter, double screenSize, double px)
        {
            //Debug.Log("-------------------------------: ");
            //Debug.Log("meter: " + meter);
            //Debug.Log("screenSize: " + screenSize);
            // count scale
            double scale = ((meter * screenSize) / px) * 100;
            //Debug.Log("scale: " + scale);
            // count "new" size of screen in px
            double newSizeOfScreen = screenSize * scale;
           // Debug.Log("newSizeOfScreen: " + newSizeOfScreen);
            // count max number of fields (single cube, square) for width/ height
            double maxNumberOfFields = newSizeOfScreen / px;
           // Debug.Log("maxNumberOfFields: " + maxNumberOfFields);
            double maxNumberOfFieldsRound = Math.Floor(maxNumberOfFields);
            return maxNumberOfFieldsRound;
        }

        /*
        public static double CountScale(double meter, double screenSize, double px)
        {
            double scale = (meter * screenSize) / px;
            Debug.Log("scale: " + scale);
            return scale;
        }

        public static double CountNewSizeOfScreen(double meter, double screenSize, double px)
        {
            double scale = CountScale(meter, screenSize, px);
            double newSizeOfScreen = screenSize * scale;
            Debug.Log("newSizeOfScreen: " + newSizeOfScreen);
            return newSizeOfScreen;
        }

        public static double CountMaxNumberOfFields2(double meter, double screenSize, double px)
        {
            double newSizeOfScreen = CountNewSizeOfScreen(meter, screenSize, px);
            double maxNumberOfFields = newSizeOfScreen / px;
            Debug.Log("maxNumberOfFields: " + maxNumberOfFields);
            return maxNumberOfFields;
        }
        */
    }

}
