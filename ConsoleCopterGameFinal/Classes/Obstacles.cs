﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{
    class Obstacles
    {
        public Point _point = new Point();
        public bool isTop;
        public Dimensions dimensions = new Dimensions();
        public Point CenterPos = new Point();

        private static string obstacleBlock = "|--|";

        public Obstacles(int y, bool top)
        {
            _point.y = y;
            isTop = top;
            dimensions.Width = obstacleBlock.Length;
            dimensions.Height = _point.y;
        }

        public void Draw(int x)
        {
            _point.x = x;
            if (isTop)
            {
                for (int i = 0; i < _point.y; i++)
                {
                    Console.SetCursorPosition(_point.x, i);
                    Console.WriteLine(obstacleBlock);
                }
            }
            else
            {
                for (int i = 30; i > _point.y; i--)
                {
                    Console.SetCursorPosition(_point.x, i);
                    Console.WriteLine(obstacleBlock);
                }
            }
        }
    }
}