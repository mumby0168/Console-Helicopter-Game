using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{
    class Point
    {
        public Point()
        {
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // these are the value that will be set through the get and set methods to store the x and y coordinates of the obstacles and the copter
        protected int X { get; set; }
        protected int Y { get; set; }

        //this will set the protected property and also allow me to access it
        public int x
        {
            get => X;
            set
            {
                if (X < 10)
                {
                    X = Console.WindowWidth - 3;
                }

                X = value;
            }
        }

        //this will set the protected property and also allow me to access it
        public int y
        {
            get => Y;
            set => Y = value;
        }
    }
}
