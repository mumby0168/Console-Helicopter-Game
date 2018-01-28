using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{

    //this is the class which will hold the obstacle
    class Obstacle
    {
        public Point _point = new Point(); // this creats a instance of the point class
        public bool IsTop; // this is a boolean that will say if the obstacle will be at the top or not
        public Dimensions Dimensions = new Dimensions(); // this creates a new instance of the dimensions class
        
        private static string obstacleBlock = "|--|"; // this is a string that will be used to draw one part of the obstacle

        //this is the constructor which takes two values when called
        public Obstacle(int y, bool top)
        {
            _point.y = y; //this sets the value y passed to be equal to point.y
            IsTop = top; // this sets the top value that is passed equal to the IsTop Variable
            Dimensions.Width = obstacleBlock.Length; // this sets the width by checking the length of the obstacleblock string
            Dimensions.Height = _point.y; // this sets the height which is the same as the y position
        }

        //this will draw the obstacle and takes a x point as a paramater
        public void Draw(int x)
        {
            _point.x = x; // this sets the x point which is passed to x posistion
            if (IsTop) // this checks to see if IsTop is equal to true
            {
                for (int i = 0; i < _point.y; i++) // this will loop over until the y point is met
                {
                    Console.SetCursorPosition(_point.x, i); // this will set the cursor posistion to the x point and incremenet counter i
                    Console.WriteLine(obstacleBlock); // this will write the obstacle block string to the console
                }
            }
            else // if it is not true then it will do below
            {
                for (int i = Console.WindowHeight; i > _point.y; i--) // this will loop round until the y point is no longer greater than window height
                {
                    Console.SetCursorPosition(_point.x, i); // this will set the cursor posistion to the x point and incremenet counter i
                    Console.WriteLine(obstacleBlock);// this will write the obstacle block string to the console
                }
            }
        }
    }
}
