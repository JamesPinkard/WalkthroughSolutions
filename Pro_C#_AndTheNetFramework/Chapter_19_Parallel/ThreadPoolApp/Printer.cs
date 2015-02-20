using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPoolApp
{
    class Printer
    {
        // Lock token.
        private object threadLock =new object();

        public void PrintNumbers()
        {
            lock(threadLock)
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

                // Print out numbers.
                Console.Write("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    // Put thread to sleep for a random amount of time.
                    Random r = new Random();
                    Thread.Sleep(100 * r.Next(5));
                    Console.Write("{0}, ", i);                
                }
                Console.WriteLine();
            }
        }
    }
}
