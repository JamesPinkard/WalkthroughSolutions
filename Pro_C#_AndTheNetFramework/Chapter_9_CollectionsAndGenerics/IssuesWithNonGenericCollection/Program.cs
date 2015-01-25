using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace IssuesWithNonGenericCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList strArray = new ArrayList();
            strArray.AddRange(new string[] {"First", "Second", "Third"});

            // Show number of items in ArrayList.
            Console.WriteLine("This collection has {0} items.",strArray.Count);
            Console.WriteLine();

            // Add a new item adn display current count.
            strArray.Add("Fourth");
            Console.WriteLine("This collection has {0} items.", strArray.Count);

            // Display contents.
            foreach (string s in strArray)
	        {   
                Console.WriteLine("Entry: {0}", s);
	        }
            Console.WriteLine();
        }

        // Issue of Performance
        static void SimpleBoxUnBoxOperation()
        { 
            // Make a ValueType (int) variable.
            int myInt = 25;

            // Box the int into an object reference.
            object boxedInt = myInt;

            // Unbox the reference back into a corresponding in.
            int unboxedInt = (int)boxedInt;
        }

        // A first look at generics
        static void UseGenericList()
        {
            Console.WriteLine("***** Fun with Generics *****\n");
            
            // This List<> can hold only Person objects.
            List<Person> morePeople = new List<Person>();
            morePeople.Add(new Person("Frank", "Black", 50));
            Console.WriteLine(morePeople[0]);

            // This List<> can only hold integers.
            List<int> moreInts = new List<int>();
            moreInts.Add(10);
            moreInts.Add(2);
            int sum = moreInts[0] + moreInts[1];
        }
    }
}
