using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{
    class Dimensions
    {
        protected int width { get; set; }

        protected int height { get; set; }


        public int Width
        {
            get => width;

            set => width = value;
        }

        public int Height
        {
            get => height;

            set => height = value;
        }
    }
}
