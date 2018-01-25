using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{
    class ScoreBoard : Globals
    {
        private static Point _point = new Point();
        

        public ScoreBoard()
        {
            _point.x = 1;
            _point.y = 4;
        }

        public void Update()
        {
            while (true)
            {
                Draw();
                Thread.Sleep(2000);
                Clear();
            }
        }

        private static void Draw()
        {
            Console.SetCursorPosition(_point.x, _point.y);
            Console.WriteLine("|----------|");
            Console.SetCursorPosition(_point.x, _point.y + 1);
            Console.WriteLine("|-Score:" + GameScore +  "--|" );
            Console.SetCursorPosition(_point.x, _point.y + 2);
            Console.WriteLine("|----------|");
        }

        private static void Clear()
        {
            Console.SetCursorPosition(_point.x, _point.y);
            Console.WriteLine("            ");
            Console.SetCursorPosition(_point.x, _point.y + 1);
            Console.WriteLine("            ");
            Console.SetCursorPosition(_point.x, _point.y + 2);
            Console.WriteLine("            ");
        }
    }
}
