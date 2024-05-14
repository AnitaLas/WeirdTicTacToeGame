using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameConfigurationButtonsTeamMembersButtonsStaticData
    {

        //public static Tuple<int, int> GetSizeForTableWithDefaulSymbols(bool isCellphoneMode)
        //{
        //    Tuple<int, int> tableSize;

        //    if (isCellphoneMode == true)
        //    {
        //        tableSize = Tuple.Create(1, 3); // rows, columns
        //    }
        //    else
        //    {
        //        tableSize = Tuple.Create(3, 3);
        //    }

        //    return tableSize;
        //}

        public static int GetDefaultTeamGameNumber()
        {
            int number = 2;
            return number;
        }

        public static float GetCoordinateYForTableWithSymbols(int teamNumebr)
        {
            float teamOneY = 0.5f;
            float teamTwoY = -1.1f;
            //float moreThanTwoTeams = -0.25f;
            float moreThanTwoTeams = -0f;

            float[] coordinateYData = new float[3];
            coordinateYData[0] = teamOneY;
            coordinateYData[1] = teamTwoY;
            coordinateYData[2] = moreThanTwoTeams;

            float coordinateY = coordinateYData[teamNumebr];
            return coordinateY;
        }

        public static float GetCoordinateZForTableWithSymbols(int teamNumebr)
        {
            float teamOneY = 0.25f;
            float teamTwoY = 0.45f;
            //float moreThanTwoTeams = 0f;
            float moreThanTwoTeams = 0.2f;

            float[] coordinateYData = new float[3];
            coordinateYData[0] = teamOneY;
            coordinateYData[1] = teamTwoY;
            coordinateYData[2] = moreThanTwoTeams;

            float coordinateY = coordinateYData[teamNumebr];
            return coordinateY;
        }

        public static float GetCoordinateYForButtonsTextWithTeamNumbers(int teamNumebr)
        {
            float teamOneY = 1.65f;
            float teamTwoY = -1.55f;
            //float moreThanTwoTeams = 1.7f;
            float moreThanTwoTeams = 1.1f;

            float[] coordinateYData = new float[3];
            coordinateYData[0] = teamOneY;
            coordinateYData[1] = teamTwoY;
            coordinateYData[2] = moreThanTwoTeams;

            float coordinateY = coordinateYData[teamNumebr];
            return coordinateY;
        }

        public static float GetCoordinateYForButtonsWithTeamNumbers(int teamNumebr)
        {
            float teamOneY = 1.95f;
            float teamTwoY = -1.15f;
            // moreThanTwoTeams = 2.1f;
            float moreThanTwoTeams = 1.5f;

            float[] coordinateYData = new float[3];
            coordinateYData[0] = teamOneY;
            coordinateYData[1] = teamTwoY;
            coordinateYData[2] = moreThanTwoTeams;

            float coordinateY = coordinateYData[teamNumebr];
            return coordinateY;
        }


    }
}
