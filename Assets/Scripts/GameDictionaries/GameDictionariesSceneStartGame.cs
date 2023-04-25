using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameDictionaries
{
    internal class GameDictionariesSceneStartGame
    {

        public static Dictionary<int, string> DictionaryTagStartGame()
        {
            Dictionary<int, string> tagStartGameDictionary = new Dictionary<int, string>();

            tagStartGameDictionary.Add(1, "StartGameButtonStartGame");
            tagStartGameDictionary.Add(2, "StartGameButtonStartTeamGame");
            tagStartGameDictionary.Add(3, "StartGameButtonInformations");

            return tagStartGameDictionary;
        }

        public static Dictionary<int, string> DictionaryButtonsStartGameName()
        {
            Dictionary<int, string> buttonsNameDictionary = new Dictionary<int, string>();

            buttonsNameDictionary.Add(1, "START GAME");
            //buttonsNameDictionary.Add(1, "GAME");
            buttonsNameDictionary.Add(2, "TEAM GAME");
            buttonsNameDictionary.Add(3, "i");

            return buttonsNameDictionary;
        }

    }
}
