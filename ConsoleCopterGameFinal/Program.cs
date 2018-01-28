using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleCopterGameFinal.Classes;


namespace ConsoleCopterGameFinal
{
    class Program : Globals // this inherits the properties from globals class
    {
        //object declarations
        private static Random
            Rand = new Random(DateTime.Today.Millisecond); // delcares a random object with a seed of todays millsecond

        private static ScoreSheet scoreTable = new ScoreSheet(); // this creates a static instance of the scoresheet class
        private static Copter copter = new Copter(); // creates a static instance of the copter class
        private static List<Obstacles> _obstacles = new List<Obstacles>(); // creates a private static 
        private static MenuSystem Menu = new MenuSystem(); // this creats a static instance of the menuSystem class
        private static ScoreSheet FileLog = new ScoreSheet(); // this creates a static instance of the scoresheet class

        //thread declarations
        static Thread _updateCopter; // declaring a variable for the update copter loop

        static void Main(string[] args)
        {
            Menu.Show(FileLog.GetList()); // this will show the menu and get the list from the file log object and pass it the list is retreives
            DrawObstacles(15); // this calls the draw obstacles method
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            GameRunning = true; // sets the game running boolean to true
            _updateCopter = new Thread(copter.Update); //instanciates and calls update method on the copter
            _updateCopter.Start(); // starts the copter update loop

            if (copter.CheckCollison(_obstacles, copter)) //if the copter check collision returns true then do in the block
            {
                GameRunning = false; //this will set the game loop to false
                Console.Beep(1000, 1000);//this will make the console beep for 1 second
                FileLog.Write(Name,GameScore);//this will tell the file log object to write the name and score to the file
                DialogResult result =  MessageBox.Show("Play Again?","GAME OVER", MessageBoxButtons.YesNo); //this will show a message box with a yes and no button and record the result in the dialog result object
                if (result == DialogResult.Yes) //this will check to see if they selected option is yes
                {
                    Application.Restart();//this will restart the application
                }
                else if(result == DialogResult.No) //this will check to see if the option chose is no
                {
                    Environment.Exit(1); //this will close the application
                }
            }
        }

        //delcares a static method with no return a integer as a paramater
        static void DrawObstacles(int a)
        {
            for (int i = 0; i < a; i++) //this loop until the pass variable a is met
            {
                if (i < a / 2) // if i is less than half of a do below
                {
                    _obstacles.Add(new Obstacles(NumberGenerator(14, 10),
                        true)); // adds a obstacle to the list and generates the y point randomly
                }
                else // if not true do this
                {
                    _obstacles.Add(new Obstacles(NumberGenerator(22, 18),
                        false)); // adds a obstacle to the list and generates the y point randomly
                }
            }

            //delcares to integers to be used as counts
            int topCount = 15;
            int bottomCount = 0;

            foreach (var t in _obstacles) //loops for every item in the obstacles list
            {
                if (t.isTop) // if istop is true
                {
                    t.Draw(topCount); // draws the obstacles and passes the top count
                    topCount += 15; // adds 15 to the variable
                }
                else
                {
                    t.Draw(bottomCount); // draws the obstacles and passes the top count
                    bottomCount += 15; // adds 15 to the variable
                }
            }
        }

        static int NumberGenerator(int max, int min) //delcares a static method which will return a int given two ints
        {
            return Rand.Next(min, max); //returns random number between the given inputs
        }
    }
}
