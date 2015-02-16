﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRetValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ Transformations *****\n");
            IEnumerable<string> subset = GetStringSubset();

            foreach (var item in subset)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        // Deferred Execution
        private static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };

            // Note subset is an IEnumerable<string>-compatible object.
            IEnumerable<string> theRedColors = from c in colors
                                               where c.Contains("Red")
                                               select c;

            return theRedColors;
        }

        // Immediate Execution
        private static string[] GetStringSubsetAsArray()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };

            var theRedColors = from c in colors where c.Contains("Red") select c;

            // Map results into an array.
            return theRedColors.ToArray<string>();
        }
    }
}
