using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{
    //this declares a enun so we can store the copter current direction
    enum Direction { Up, Down, Left, Right} 

    class Copter : Globals
    {
        public Point _point = new Point(); // this creates a new instance of the point class
        public Dimensions Dimensions = new Dimensions(); // this creates a new instance of the dimensions class
        public List<Point> Directions = new List<Point>() { new Point(-2, -1), new Point(-1, 1), new Point(1, 0), new Point(-1, 0) }; // this declares a list of points and stores 4 istnaces of the point class within it

        private static Direction _dir; // this declares a instance of the direction enum
        private static Thread checkInput; // this declares a new thread to intialised later
        private static List<string> copterString = new List<string>() {@"---..---", @"C0000--/"}; // this declares a list of strings that will draw the copter
        private static ScoreBoard scoreBoard = new ScoreBoard(); // this creates a new instance of the scoreboard class
        private static Thread scoreUpdate; // this delcares a thread to be delcared later
        
        // this is the constructor
        public Copter() 
        {
            _point.x = Console.WindowWidth - 5; // this sets the copter c position 
            _point.y = 14;// this sets the copters y point
            _dir = Direction.Down; // this sets the direction of the copter to be down

            Dimensions.Width = copterString[0].Length; // this gets the width of the copter
            Dimensions.Height = copterString.Count; // this gets the hieght of the copter
            
        }

        public void Update()
        {
            // this intialises the score update thread and starts it
            scoreUpdate = new Thread(scoreBoard.Update);
            scoreUpdate.Start();
            // this intilaises the checkinput thread and starts it
            checkInput = new Thread(CheckInput);
            checkInput.Start();
            // this will run as long as GameRunning is set to true
            while (GameRunning)
            {
                Clear(); // this will clear the copter
                int i = 0; // this declares a integer
                if (_dir == Direction.Up) i = 0; // this will set i to 0 if the direction is set to up
                if (_dir == Direction.Down) i = 1;// this will set i to 1 if the direction is set to down
                if (_dir == Direction.Right) i = 2;// this will set i to 2 if the direction is set to right
                if (_dir == Direction.Left) i = 3; // this will set i to 3 if the direction is set to up left
                _point.x += Directions[i].x; // this will add the x point which will change the direction
                _point.y += Directions[i].y;// this will add the y point which will change the direction
                _dir = Direction.Down; // this sets the direction to be down
                if (_point.x < 3)
                    _point.x = Console.WindowWidth - 1; // this will make sure that the copter cannot go off the edge of the screen
                Draw(); // this will call the draw method
                Thread.Sleep(200); // this will sleep the thread for 0.2 of a second
            }
        }
        /// <summary>
        /// this will check a collison by the copter into any of the obstacles to do this it wil draw a box a box around the obstacle by mapping some minumum and maximum points of both the copter and the obstacle and then loop through to check each point it will then check if the X points mean then it will do the same for the y and then check if they meet then it will return true which means a collision has been detected.
        /// </summary>
        /// <param name="obsts"></param>
        /// <param name="cop"></param>
        /// <returns></returns>
        public bool CheckCollison(List<Obstacle> obsts, Copter cop)
        {
            Dimensions dim = new Dimensions();
            while (GameRunning)
            {
                foreach (var obs in obsts)
                {
                    int xMaxobs = obs._point.x + (obs.Dimensions.Width);
                    int xMinObs = obs._point.x;
                    int i = 0;
                    for (i = xMinObs; i < xMaxobs; i++)
                    {
                        int xMaxCop = cop._point.x + cop.Dimensions.Width;
                        int xMinCop = cop._point.x;
                        int j = 0;
                        for (j = xMinCop; j < xMaxCop; j++)
                        {
                            if (i == j)
                            {
                                int yMaxObs = obs._point.y;
                                int yMinObs = obs._point.y - obs.Dimensions.Height;
                                if (!obs.IsTop)
                                {
                                    yMinObs = obs._point.y;
                                    yMaxObs = 30;
                                }

                                int q = 0;
                                for (q = yMinObs; q < yMaxObs; q++)
                                {
                                    int yMaxCop = cop._point.y + cop.Dimensions.Height;
                                    int yMinCop = cop._point.y;
                                    int t = 0;
                                    for (t = yMinCop; t < yMaxCop; t++)
                                    {
                                        if (t == q)
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
        /// <summary>
        /// this will draw the copter by setting the positions and then writing to the console 
        /// </summary>
        private void Draw()
        {
            Console.SetCursorPosition(_point.x, _point.y);
            Console.WriteLine(copterString[0]);
            Console.SetCursorPosition(_point.x, _point.y + 1);
            Console.WriteLine(copterString[1]);
        }

        /// <summary>
        /// this will clear the copters position once it has moved
        /// </summary>
        private void Clear()
        {
            Console.SetCursorPosition(_point.x, _point.y);
            Console.WriteLine("        ");
            Console.SetCursorPosition(_point.x, _point.y + 1);
            Console.WriteLine("        ");
        }

        /// <summary>
        /// this will check the input in a while loop and using a switch statement to check for the space bar being pressed
        /// </summary>
        private void CheckInput()
        {
            while (GameRunning)
            {
                var keyInput = Console.ReadKey(true).Key;
                switch (keyInput)
                {
                    case ConsoleKey.Spacebar:
                        _dir = Direction.Up; // this will set the direction to be up
                        GameScore += 1; // this will add 1 to the game score
                        break;                 
                }
            }
        }
    }
}
