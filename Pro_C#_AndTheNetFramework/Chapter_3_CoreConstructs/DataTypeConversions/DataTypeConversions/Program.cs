using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with type conversions *****");

            short numb1 = 30000, numb2 = 30000;

            // Explicitly cast the int into a short (and allow loss of data).
            short answer = (short)Add(numb1, numb2);
            
            // Add two shorts and print the result.
            Console.WriteLine("{0} + {1} = {2}", numb1, numb2, answer);

            // Explicitly cast the int into a byte ( no loss of data).
            NarrowingAttempt();

            ProcessBytes();

            ProcessCheckedBytes();

            Console.ReadKey();
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static void NarrowingAttempt()
        {
            byte myByte = 0;
            int myint = 200;

            // Explicitly cast the int into a byte ( no loss of data).
            myByte = (byte)myint;
            Console.WriteLine("Value of myByte: {0}", myByte);
        }

        static void ProcessBytes()
        {
            byte b1 = 100;
            byte b2 = 250;
            byte sum = (byte)Add(b1, b2);

            // sum should hold the value 350. However, we find the value 94!
            Console.WriteLine("sum of 100 bytes + 250 bytes = {0}", sum);
        }

        static void ProcessCheckedBytes()
        {
            // raises an exeption when overflow occurs
            try
            {
                checked
                {
                    byte b1 = 100;
                    byte b2 = 250;
                    byte sum = (byte)Add(b1, b2);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
