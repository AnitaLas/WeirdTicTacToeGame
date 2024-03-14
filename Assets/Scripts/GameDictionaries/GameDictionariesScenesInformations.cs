using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GameDictionariesScenesInformations
    {

        public static Dictionary<int, string> DictionaryTagGameInformations()
        {
            Dictionary<int, string> tagGameInformationsDictionary = new Dictionary<int, string>();

            tagGameInformationsDictionary.Add(1, "GameInformationButtonBack");
            //tagGameInformationsDictionary.Add(2, "StartGameButtonStartTeamGame");


            return tagGameInformationsDictionary;
        }



    }
}
