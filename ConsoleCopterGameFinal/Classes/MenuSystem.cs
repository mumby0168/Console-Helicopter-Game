using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleCopterGameFinal.Classes;

namespace ConsoleCopterGameFinal.Classes
{

   
    class MenuSystem : Globals
    {
        static List<string> NamesandScores = new List<string>(); // this declares a list which will hold the names and the scores
        //this is a method which will show the highscore and takes a list as a argument
        public void Show(List<string> highscoredata)
        {
            NamesandScores = highscoredata; // this sets the list declared earlier to the one that is passed in the method call
            //this will do this while the condition below is not met
            do
            {
                Console.WriteLine("Please enter your name"); // this will print the string to the console
                Name = Console.ReadLine(); // this will store the input to the global Name variable
            } while (Name.Length < 3); // while the name.length is less than 3

            Console.Clear(); // this will clear the console
            int input = 0; // this declatea variable used to store the input later

            Console.SetCursorPosition(Console.WindowWidth - 70, 3); // this sets the console cursor position to roughly center
            Console.WriteLine("MENU"); // this will print the string to the screen

            do // this will do inside the block while the condition is not met
            {
                Console.WriteLine("\n\t\t\t\t\tPlease choose an option \n\t\t\t\t\t 1: Play Game \n\t\t\t\t\t 2: Highscores \n\t\t\t\t\t 3: Instructions \n\t\t\t\t\t 4: Exit"); // this will print the meny and format it
                try
                {
                    input = int.Parse(Console.ReadLine()); // this conversion will be tried if it is succseful it will store teh variable and move on
                }
                catch
                {
                    Console.WriteLine("Please enter a number not a string :)"); // this will be shown if the incorrect data type is entered
                }
            } while (input != 1 && input != 2 && input != 3 && input != 4); // this will make sure that the code cannot move past this point untul the input is 1,2,3 or 4

            Console.Clear(); // this will clear the console

            switch (input) // this will check to see what the input variable is
            {
                case 1:
                    Console.Clear(); // if it is 1 it will clear the console
                    break;
                case 2:
                    DisplayHighScores(); // if it is 2 is will display the highscores
                    break;
                case 3:
                    DisplayInstructions(); // if it is 3 it will display the instructoions
                    break;
                case 4:
                    Environment.Exit(1); // if it is 4 it will exit the application
                    break;

                    // the break keyword will jump out of this statement and exexcute the next line
            }
        }

        static void DisplayHighScores() // this will display the highscore
        {
            GameRunning = false; // this sets the game running to false
            foreach (var t in NamesandScores) // this will loop over for every item in the list
            {
                Console.WriteLine(t); // this will pring the value of the item in the list
            }


            Console.WriteLine("Press enter to play Game"); // this prints the text to the console
            Console.ReadLine();// this waits for the user to continue
            Console.Clear();
        }

        static void DisplayInstructions() // this wil display the instructions
        {
            Console.SetCursorPosition(Console.WindowWidth - 70, 3); // this sets the console cursor to be roughtly center
            Console.WriteLine("INSTRUCTIONS");


            Console.WriteLine(
                "\n\tThe aim of this game is to last as long as possible moving from one end of the screen to the other\n\twithout hitting any of the obsticles that are in the way.\n\tControls: Space bar to go up.\n\tYou will collect a point every time that you hit the space bar."); // this wil print the text on new lines defined by \n and tab defined by \t

            Console.WriteLine("\tPress Enter to Play"); // this will print the text to the console
            Console.ReadLine(); // this waits for the users input
        }
    }
}
