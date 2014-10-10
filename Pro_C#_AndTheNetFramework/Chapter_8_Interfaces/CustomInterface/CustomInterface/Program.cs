using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        // I'll draw anyone supporting IDraw3D.
        static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interfaces *****\n");

            // Call Points property defined by I Pointy.
            Hexagon hex = new Hexagon();
            Console.WriteLine("Points: {0}", hex.Points);
            Console.ReadLine();

            //Catch a possible invalid interface cast exception.
            Circle c = new Circle("Lisa");
            IPointy itfPt = null;
            
            try
            {
                itfPt = (IPointy)c;
                Console.WriteLine(itfPt.Points);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle(), new Circle("Jojo") };

            for (int i = 0; i < myShapes.Length; i++)
            {
                // Recall the Shape base clas defines an abstract Draw()
                // member, so all shapes know how to draw themselves.
                myShapes[i].Draw();

                // Who's pointy?
                if (myShapes[i] is IPointy)
                    Console.WriteLine("-> Points: {0}", ((IPointy) myShapes[i]).Points);
                else
                    Console.WriteLine("-> {0}\'s not pointy!", myShapes[i].PetName);

                //Can I draw you in 3D?
                if (myShapes[i] is IDraw3D)
                    DrawIn3D(myShapes[i] as IDraw3D);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
