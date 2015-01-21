using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with System.Object *****\n");
            Person p4 = new Person();

            // Use inherited members of System.Object.
            Console.WriteLine("ToString: {0}", p4.ToString());
            Console.WriteLine("Hash Code: {0}", p4.GetHashCode());
            Console.WriteLine("type: {0}", p4.GetType());

            // Make some other references to p1.
            Person p3 = p4;
            object o = p3;

            // Are the references pointing to the same object in memory?
            if (o.Equals(p4) && p3.Equals(o))
            {
                Console.WriteLine("Same instance!");
            }
            Console.WriteLine();

            // NOTE: We want these to be identical to test
            // the Equals() and GetHashCode() methods.
            Person p1 = new Person("Homer", "Simpson", 50);
            Person p2 = new Person("Homer", "Simpson", 50);

            // Get stringified version of objects.
            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());

            // Test overridden Equals().
            Console.WriteLine("p1 = p2?: {0}", p1.Equals(p2));

            // Test overridden Equals()
            Console.WriteLine("p1 = p2: {0}", p1.Equals(p2));

            // Test hash codes.
            Console.WriteLine("Same hash codes?: {0}", p1.GetHashCode() == p2.GetHashCode());
            Console.WriteLine();

            // Change age of p2 and test again.
            p2.Age = 45;
            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());
            Console.WriteLine("p1 = p2?: {0}", p1.Equals(p2));
            Console.WriteLine("Same hash codes? {0}", p1.GetHashCode() == p2.GetHashCode());

            Console.WriteLine();
            StaticMembersOfObject();

            Console.ReadKey();
        }

        static void StaticMembersOfObject()
        {
            // Static members of System.Object.
            Person pt = new Person("Sally", "Jones", 4);
            Person ps = new Person("Sally", "Jones", 4);
            Console.WriteLine("Pt and Ps have the same state: {0}", object.Equals(pt, ps));
            Console.WriteLine("Pt and Ps are pointing to same object: {0}", object.ReferenceEquals(pt, ps));
        }
    }
}
