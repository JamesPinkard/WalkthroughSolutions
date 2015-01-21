using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Polymorphism *****\n");

            Hexagon hex = new Hexagon("Beth");
            hex.Draw();

            Circle cir = new Circle("Cindy");
            // Calls base class implementation!
            cir.Draw();
            Console.WriteLine();

            // Make an array of Shap-compatible objects.
            Shape[] myShapes = {new Hexagon(), new Circle(), new Hexagon("Mick"), new Circle("Beth"), new Hexagon("Linda")};

            // Loop over each item and interact with 
            // Polymorphic interface.
            foreach (Shape s in myShapes)
            {
                s.Draw();
            }

            Console.WriteLine();

            // This calls the Draw() method of the ThreeDCircle.
            ThreeDCircle o = new ThreeDCircle();
            o.Draw();

            DrawCircle(o);
            Console.WriteLine();

            // This calls the Draw() method of the parent!
            ((Circle)o).Draw();

            Circle oCopy = o as Circle;
            oCopy.Draw();
            Console.WriteLine();


            Console.ReadKey();
        }

        public static void DrawCircle(Circle shape)
        {
            Console.WriteLine("Using DrawCircle()");
            shape.Draw();
        }
    }
}
