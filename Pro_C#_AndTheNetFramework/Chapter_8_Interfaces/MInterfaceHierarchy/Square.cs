using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MInterfaceHierarchy
{
    class Square : IShape
    {
        int IShape.GetNumberOfSides()
        {
            return 4;
        }

        void IDrawable.Draw()
        {
            Console.WriteLine("Drawing to Screen...");
        }

        void IPrintable.Print()
        {
            Console.WriteLine("Printing...");
        }

        void IPrintable.Draw()
        {
            Console.WriteLine("Drawing to Printer...");
        }
    }
}
