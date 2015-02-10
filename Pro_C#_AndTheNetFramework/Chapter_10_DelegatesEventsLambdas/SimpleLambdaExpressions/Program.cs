using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lambdas *****\n");
            TraditionalDelegateSyntax();
            Console.WriteLine();
            AnonymousMethodSyntax();
            Console.WriteLine();
            LambdaMultilineExpressionSyntax();
            Console.ReadLine();
        }

        private static void LambdaExpressionSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now, use a C# lambda expression.
            List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);

            Console.WriteLine("here are your even numbers:");
            foreach (var evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }

        private static void LambdaMultilineExpressionSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now, use a C# lambda expression.
            List<int> evenNumbers = list.FindAll(i =>
            {
                Console.WriteLine("value of i is currently: {0}", i);
                bool isEven = ((i % 2) == 0);
                return isEven;
            });

            Console.WriteLine("here are your even numbers:");
            foreach (var evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }

        private static void AnonymousMethodSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now, use an anonymous method.
            List<int> evenNumbers = list.FindAll(delegate(int i)
            { return (i % 2) == 0; });

            Console.WriteLine("here are your even numbers:");
            foreach (var evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }

        private static void TraditionalDelegateSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Call FindAll() using traditional delegate syntax.
            Predicate<int> callback = new Predicate<int>(IsEventNumber);
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("Here are your even numbers:");
            foreach (var evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        // Target for the Predicate<> delegate.
        private static bool IsEventNumber(int i)
        {
            // Is it an even number?
            return (i % 2) == 0;
        }
    }
}
