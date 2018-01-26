using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{

    //this is the class that we will use in order to store the dimensions of the objects
    class Dimensions
    {
        protected int width { get; set; } // this is a property that can be set or retrieved and is of type int

        protected int height { get; set; }// this is a property that can be set or retrieved and is of type int

        //this will allow us to access the private property in this class
        public int Width 
        {
            get => width; //this will get the data from the width property

            set => width = value; //this will set the value of the width property
        }

        public int Height
        {
            get => height; //this will get the value of the height property

            set => height = value; // this will set the value of the height property
        }
    }
}
