using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** A First Look at Structures *****\n");

            //  Create an initial Point.
            Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();

            //  Adjust the X and Y values.
            myPoint.Increment();
            myPoint.Display();
            myPoint.Decrement();

            //  Set all fields to default values
            //  using the default constructor.
            Point p1 = new Point();

            //  Prints X=0, Y=0
            p1.Display();

            // Call Custom Constructor
            Point p2 = new Point(50, 60);

            // Prints X=50, Y=60
            p2.Display();

            Console.ReadKey();
        }

        /* You must assign both values or receive a compile error
         * 
         * Error! Did not assign Y Value.
         * 
         * Point p1;
         * p1.X = 10;
         * p1.Display();
         */

        struct Point
        {
            //  Fields of the Structure
            public int X;
            public int Y;

            //  A Custom constructor.
            public Point(int XPos, int YPos)
            {
                X = XPos;
                Y = YPos;
            }

            // Add 1 to the (X, Y) position.
            public void Increment()
            {
                X++; Y++;
            }

            // Subtract 1 from the (X, Y) structure.
            public void Decrement()
            {
                X++; Y++;
            }

            // Display the current position.
            public void Display()
            {
                Console.WriteLine("X = {0}, Y = {1}", X, Y);
            }
        }
    }
}
