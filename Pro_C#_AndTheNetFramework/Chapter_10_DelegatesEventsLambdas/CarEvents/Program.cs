using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");
            Car c1 = new Car("SlugBug", 100, 10);

            // Register event handleres.
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;

            
            c1.Exploded += CarExpleded;

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);

                // Remove Car Exploded method
                // from invocation list.
                c1.Exploded -= CarExpleded;
            }

            Console.WriteLine("\n****** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);                    
            }

            Console.ReadLine();
        }

        private static void CarExpleded(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void CarAboutToBlow(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine("=> Critical Message from Car: {0}", msg);
        }


    }
}
