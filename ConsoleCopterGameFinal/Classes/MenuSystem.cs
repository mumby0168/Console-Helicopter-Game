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

            Console.SetCursorPosition(Console.WindowWidth - 70, 3);
            Console.WriteLine("MENU");

            do
            {
                Console.WriteLine("\n\t\t\t\t\tPlease choose an option \n\t\t\t\t\t 1: Play Game \n\t\t\t\t\t 2: Highscores \n\t\t\t\t\t 3: Instructions \n\t\t\t\t\t 4: Exit");
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
                    DisplayInstructions();
                    break;
                case 4:
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
            Console.ReadLine();
        }

        static void DisplayInstructions()
        {
            Console.SetCursorPosition(Console.WindowWidth - 70, 3);
            Console.WriteLine("INSTRUCTIONS");


            Console.WriteLine(
                "\n\tThe aim of this game is to last as long as possible moving from one end of the screen to the other\n\twithout hitting any of the obsticles that are in the way.\n\tControls: Space bar to go up.\n\tYou will collect a point every time that you hit the space bar.");

            Console.WriteLine("\tPress Enter to Play");
            Console.ReadLine();
        }
    }
}
