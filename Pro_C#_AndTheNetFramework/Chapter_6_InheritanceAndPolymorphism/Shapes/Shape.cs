using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    abstract class Shape
    {
        public Shape(string name = "NoName")
        {
            PetName = name;
        }

        public string PetName { get; set; }

        // Force all child classes to define how to be rendered.
        public virtual void Draw()
        {
            Console.WriteLine("Inside Shape.Draw()");
        }
    }
}
