using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleCopterGameFinal.Classes;


namespace ConsoleCopterGameFinal
{
    class Program : Globals
    {
        static Copter copter = new Copter();
        static Thread _updateCopter;
        private static List<Obstacles> _obstacles = new List<Obstacles>();
        private static Random Rand = new Random(DateTime.Today.Millisecond);

        static void Main(string[] args)
        {
            DrawObstacles(15);
            GameRunning = true;
            _updateCopter = new Thread(copter.Update);
            _updateCopter.Start();
            if (copter.CheckCollison(_obstacles, copter))
            {
                MessageBox.Show("GAME OVER");
                GameRunning = false;
            }
        }

        static void DrawObstacles(int a)
        {
            for (int i = 0; i < a; i++)
            {
                if (i < a / 2)
                {
                    _obstacles.Add(new Obstacles(NumberGenerator(12, 8), true));
                }
                else
                {
                    _obstacles.Add(new Obstacles(NumberGenerator(20, 18), false));
                }
            }

            int topCount = 15;
            int bottomCount = 0;
            foreach (var t in _obstacles)
            {
                if (t.isTop)
                {
                    t.Draw(topCount);
                    topCount += 15;
                }
                else
                {
                    t.Draw(bottomCount);
                    bottomCount += 15;
                }
            }
        }

        static int NumberGenerator(int max, int min)
        {
            return Rand.Next(min, max);
        }
    }
}
