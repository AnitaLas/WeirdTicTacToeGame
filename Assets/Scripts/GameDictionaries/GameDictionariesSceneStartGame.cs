using System.Collections.Generic;

namespace Assets.Scripts.GameDictionaries
{
    internal class GameDictionariesSceneStartGame
    {
        public static Dictionary<int, string> DictionaryTagStartGame()
        {
            Dictionary<int, string> tagStartGameDictionary = new Dictionary<int, string>
            {
                { 1, "StartGameButtonStartGame" },
                { 2, "StartGameButtonStartTeamGame" },
                { 3, "StartGameButtonInformations" }
            };

            return tagStartGameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsStartGameName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>
            {
                { 1, "START GAME" },
                { 2, "TEAM GAME" },
                { 3, "?" }
            };

            return buttonsNameDictionary;
        }
    }
}
