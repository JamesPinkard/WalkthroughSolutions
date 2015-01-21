using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Inhheritance *****\n");
            // Make a Car object and set max speed.
            Car myCar = new Car(80);

            // Set the current speed, and print it.
            myCar.Speed = 50;
            Console.WriteLine("My car is going {0} MPH", myCar.Speed);

            // Now make a MiniVan object.
            MiniVan myVan = new MiniVan();
            myVan.Speed = 10;
            Console.WriteLine("My van is going {0} MPH", myVan.Speed);
            
            // Error! Can't access private members!
            // myVan.currSpeed = 55;
            Console.ReadKey();
        }
    }
}
