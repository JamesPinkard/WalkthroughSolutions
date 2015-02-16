using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Conversions *****\n");

            // Make a Rectangle.
            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r.ToString());
            r.Draw();

            Console.WriteLine();

            // Convert r into a Square, based on the height of the Rectangle.
            Square s = (Square)r;
            Console.WriteLine(s.ToString());
            s.Draw();
            Console.ReadLine();
        }
    }
}
