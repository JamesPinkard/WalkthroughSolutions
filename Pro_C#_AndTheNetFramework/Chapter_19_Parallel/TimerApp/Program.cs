using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerApp
{
    class Program
    {
        static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}, Param is: {1}",DateTime.Now.ToLongTimeString(), state.ToString());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");

            // Create the delegate for the Timer type.
            TimerCallback timeCB = new TimerCallback(PrintTime);

            // Establish timer settings 
            Timer t = new Timer(
                timeCB,
                "Hello from Main",
                0,
                100);

            Console.WriteLine("Hit key to terminate...");
            Console.ReadLine();
        }
    }
}
