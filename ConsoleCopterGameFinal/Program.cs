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
        static Thread updateCopter;
        private static List<Obstacles> obstacles = new List<Obstacles>();
        static void Main(string[] args)
        {
            Globals Game = new Globals();
            Copter copter = new Copter();
            

            CreateObsts(10);

            GameRunning = true;

            updateCopter = new Thread(copter.Update);

            updateCopter.Start();

            if (copter.CheckCollison(obstacles, copter))
            {
                MessageBox.Show("GAME OVER");
                GameRunning = false;
            }
        }


        static void CreateObsts(int a)
        {
            
                obstacles.Add(new Obstacles(15, 12, true));
            obstacles[0].Draw();
            obstacles.Add(new Obstacles(15, 16, false));
            obstacles[1].Draw();

        }
    }
}
