using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncDelegate
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("***** Async Delegate Invocation *****");

            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            // Invoke Add() on a secondary thread.
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

            // Do other work on primary thread...
            Console.WriteLine("Doing more work in Main()!");

            // Obtain the result of the Add()
            // method when ready.
            int answer = b.EndInvoke(iftAR);
                        
            Console.WriteLine("10 + 10 is {0}.", answer);

            IAsyncResult ift2 = b.BeginInvoke(20, 20, null, null);

            // This message will keep printing until
            // the Add() method is finished.
            while (!ift2.IsCompleted)
            {
                Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(500);
            }

            // Now we know the Add() method is complete.

            int answer2 = b.EndInvoke(ift2);
            Console.WriteLine("20 + 20 is {0}.", answer2);
            Console.ReadLine();
        }

        private static int Add(int x, int y)
        {
            // Print out the ID of the executing thread
            Console.WriteLine("Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            // Pause to simulate lengthy operation.
            Thread.Sleep(2000);
            return x + y;
        }
    }
}
