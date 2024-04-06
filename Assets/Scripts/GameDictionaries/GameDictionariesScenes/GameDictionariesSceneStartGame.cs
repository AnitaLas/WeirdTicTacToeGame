using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class GameDictionariesSceneStartGame
    {
        public static Dictionary<int, string> DictionaryTagsStartGame()
        {
            Dictionary<int, string> tagStartGameDictionary = new Dictionary<int, string>
            {
                { 1, "StartGameButtonStartGame" },
                { 2, "StartGameButtonStartTeamGame" },
                { 3, "StartGameButtonInformations" }, // should be without s xD
                { 4, "StartGameButtonInactiveField" } 
            };

            return tagStartGameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsStartGameName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                //{ 1, "START GAME" },
                //{ 1, "PAST PLAY" },
                { 1, "OLD VERSION" },
               // { 2, "TEAM GAME" },
                { 2, "TEAM GAME" },
                { 3, "?" },
                { 4, "GAME" }
            };

            return buttonsNameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsGameName()
        {
            Dictionary<int, string> buttonsGameNameDictionary = new Dictionary<int, string>
            {
                { 1, "     WEIRD" },
                { 2, " TIC" },
                { 3, " TAC" },
                { 4, " TOE" }
            };

            return buttonsGameNameDictionary;
        }
    }
}
