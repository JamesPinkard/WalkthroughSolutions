using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** fun with LINQ to Objects *****\n");
            QueryOverStrings();

            QueryOverInts();
            Console.ReadLine();
        }

        static void QueryOverStrings()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            // Print out the reseults.
            foreach (var s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
        }

        // Deferred execution
        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // Print only items less than 10.
            IEnumerable<int> subset = from i in numbers
                                      where i < 10
                                      select i;

            foreach (var i in subset)
            {
                Console.WriteLine("{0} < 10", i);
            }

            Console.WriteLine();

            // Change some data in the array.
            numbers[0] = 4;

            // Evaluated again!
            foreach (var j in subset)
            {
                Console.WriteLine("{0} < 10", j);
            }

            Console.WriteLine();
        }

        static void ImmediateExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // Get data RIGHT NOW as int[].
            int[] subsetAsIntArray = (from i in numbers where i < 10 select i).ToArray<int>();

            // Get data RIGHT NOW as List<int>.
            List<int> subsetAsListOfInts = (from i in numbers where i < 10 select i).ToList<int>();
        }
    }
}
