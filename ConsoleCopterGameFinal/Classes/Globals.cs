using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{
    //these will be global variables that will be available to all of the classes
    public class Globals
    {
        public static bool GameRunning { get; set; } // this will allow us to check if the game is running as well as setting its value
        public static int GameScore { get; set; } // this will allow us to set the gamescore and also retrieve it

        public static string Name { get; set; }

    }
}
