using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace AsyncCallbackDelegate
{
    public delegate int BinaryOp(int x, int y);
    
    class Program
    {
        static bool isDone = false;
        static void Main(string[] args)
        {
            Console.WriteLine("***** AsyncCallbackDelegate Example *****");

            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            // Invoke Add() on a secondary thread.
            BinaryOp b = new BinaryOp(Add);
 
            IAsyncResult ift2 = b.BeginInvoke(20, 20, new AsyncCallback(AddComplete), "Main() thanks you for adding these numbers.");

            // This message will keep printing until
            // the Add() method is finished.
            while (!isDone)
            {
                Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(500);
            }

            // Now we know the Add() method is complete.                        
            Console.ReadLine();
        }

        // Don't forget to import System.Runtime.Remoting.Messaging!
        private static void AddComplete(IAsyncResult itfAR)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            
            // Now get the result
            AsyncResult ar = (AsyncResult)itfAR;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}.", b.EndInvoke(itfAR));
            
            // Retrieve the informational object and cast it to string.
            string msg = (string)itfAR.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
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
