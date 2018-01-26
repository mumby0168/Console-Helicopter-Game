using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{
    //this will be the class that draws the scoreboard
    class ScoreBoard : Globals
    {
        private static Point _point = new Point(); // this creates a new static instance of the point class
        

        public ScoreBoard() // this is the constructor for the scoreboard class
        {
            //these variables will be set when a score board object is intialised
            _point.x = 1;
            _point.y = 4;
        }

        //this is a method with a loop which calls the two private methods with a small delay
        //this is public so it can be called from anywhere inside of the program
        public void Update()
        {
            while (true)
            {
                Draw();
                Thread.Sleep(2000); // this will add a 2 second delay to the current thread
                Clear();
            }
        }

        //this will draw the scoreboard and is static private so it can only be accessed from within this class
        private static void Draw()
        {
            Console.SetCursorPosition(_point.x, _point.y); // this will set the consoles cursor position to the x and y point defined in the constructor
            Console.WriteLine("|----------|"); // this will print the text in the quotes to the console
            Console.SetCursorPosition(_point.x, _point.y + 1);
            Console.WriteLine("|-Score:" + GameScore +  "-|" );
            Console.SetCursorPosition(_point.x, _point.y + 2);
            Console.WriteLine("|----------|");
        }

        //this will clear the score board ready for it to be redrawn this can also only be accessed inside of this class
        private static void Clear()
        {
            Console.SetCursorPosition(_point.x, _point.y);// this will set the consoles cursor position to the x and y point defined in the constructor
            Console.WriteLine("            ");// this will print the text in the quotes to the console
            Console.SetCursorPosition(_point.x, _point.y + 1);
            Console.WriteLine("            ");
            Console.SetCursorPosition(_point.x, _point.y + 2);
            Console.WriteLine("            ");
        }
    }
}
