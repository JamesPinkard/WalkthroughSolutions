using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPrimAndProperCarEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Prim and Proper Events *****\n");

            // Make a car as usual.
            Car c1 = new Car("SlugBug", 100, 10);

            // Register event handlers.
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;

            c1.Exploded += CarExploded;


            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);

            }

            Console.WriteLine("\n****** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();

        }
        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            Console.WriteLine("{0} says: {1}", sender, e.msg);
        }

        public static void CarExploded(object sender, CarEventArgs e)
        {
            Console.WriteLine("{0} says: {1}", sender, e.msg);
        }

        private static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        {
            Console.WriteLine("=> Critical Message from Car: {0}", e.msg);
        }
    }
}
