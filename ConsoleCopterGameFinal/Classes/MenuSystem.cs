using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleCopterGameFinal.Classes;

namespace ConsoleCopterGameFinal.Classes
{

   
    class MenuSystem : Globals
    {
        static List<string> NamesandScores = new List<string>();

        public void Show(List<string> highscoredata)
        {
            NamesandScores = highscoredata;
            do
            {
                Console.WriteLine("Please enter your name");
                Name = Console.ReadLine();
            } while (Name.Length < 3);

            Console.Clear();
            int input = 0;
            do
            {
                Console.WriteLine("Please choose an option \n 1: play game \n 2: highscores \n 3: exit");
                input = int.Parse(Console.ReadLine());
            } while (input != 1 && input != 2 && input != 3);

            Console.Clear();

            switch (input)
            {
                case 1:
                    Console.Clear();
                    break;
                case 2:
                    DisplayHighScores();
                    break;
                case 3:
                    Environment.Exit(1);
                    break;
            }
        }

        static void DisplayHighScores()
        {
            GameRunning = false;
            foreach (var t in NamesandScores)
            {
                Console.WriteLine(t.ToString());
            }


            Console.WriteLine("Press enter to play Game");
            string input = Console.ReadLine();
        }
    }
}
