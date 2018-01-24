﻿using System;
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
        static Direction _dir = new Direction();
        public Point _point = new Point();
        public Point topLeft = new Point();
        private static Thread checkInput;
        private static List<string> copterString = new List<string>() {@"---..---", @"C0000--/"};
        public Dimensions dimensions = new Dimensions();
        public Point CenterPoint = new Point();

        public List<Point> Directions =
            new List<Point>() {new Point(-2, -1), new Point(-1, 1), new Point(1, 0), new Point(-1, 0)};

        public Copter()
        {
            _point.x = 50;
            _point.y = 5;
            _dir = Direction.Down;

            dimensions.Width = copterString[0].Length;
            dimensions.Height = copterString.Count;
        }

        private void Draw()
        {
            topLeft.x = _point.x;
            topLeft.y = _point.y;

            Console.SetCursorPosition(_point.x, _point.y);
            Console.WriteLine(copterString[0]);
            Console.SetCursorPosition(_point.x, _point.y + 1);
            Console.WriteLine(copterString[1]);
        }

        private void Clear()
        {
            Console.SetCursorPosition(_point.x, _point.y);
            Console.WriteLine("        ");
            Console.SetCursorPosition(_point.x, _point.y + 1);
            Console.WriteLine("        ");
        }

        private void CheckInput()
        {
            while (GameRunning)
            {
                var keyInput = Console.ReadKey(true).Key;
                switch (keyInput)
                {
                    case ConsoleKey.UpArrow:
                        _dir = Direction.Up;
                        Clear();
                        GameScore++;
                        break;
                    case ConsoleKey.DownArrow:
                        _dir = Direction.Down;
                        Clear();
                        break;
                    case ConsoleKey.LeftArrow:
                        Clear();
                        _dir = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        Clear();
                        _dir = Direction.Right; 
                        break;
                }
            }
        }

        public void Update()
        {
            checkInput = new Thread(CheckInput);
            checkInput.Start();

            while (GameRunning)
            {
                Clear();

                int i = 0;

                if (_dir == Direction.Up)
                    i = 0;
                if (_dir == Direction.Down)
                    i = 1;
                if (_dir == Direction.Right)
                    i = 2;
                if (_dir == Direction.Left)
                    i = 3;

                _point.x += Directions[i].x;
                _point.y += Directions[i].y;

                _dir = Direction.Down;


                Draw();

                Thread.Sleep(200);
            }
        }

        public bool CheckCollison(List<Obstacles> obsts, Copter cop)
        {
            Dimensions dim = new Dimensions();
            while (GameRunning)
            {
                foreach (var obs in obsts)
                {
                    int xMaxobs = obs._point.x + (obs.dimensions.Width);
                    int xMinObs = obs._point.x;
                    int i = 0;
                    for (i = xMinObs; i < xMaxobs; i++)
                    {
                        int xMaxCop = cop._point.x + cop.dimensions.Width;
                        int xMinCop = cop._point.x;
                        int j = 0;
                        for (j = xMinCop; j < xMaxCop; j++)
                        {
                            if (i == j)
                            {
                                int yMaxObs = obs._point.y;
                                int yMinObs = obs._point.y - obs.dimensions.Height;
                                if (!obs.isTop)
                                {
                                    yMinObs = obs._point.y;
                                    yMaxObs = 30;
                                }
                                int q = 0;
                                for (q = yMinObs; q < yMaxObs; q++)
                                {
                                    int yMaxCop = cop._point.y + cop.dimensions.Height;
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

        int absoValue(int x)
        {
            if (x < 0)
                return -x;

            return x;
        }

}
}
