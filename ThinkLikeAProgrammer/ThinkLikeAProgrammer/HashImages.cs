using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkLikeAProgrammer
{
    class HashImages
    {
        public static void PrintHalfFiveHashSquare()
        {
            PrintDecreasingHashes(5);

        }

        public static void PrintHashTriangle()
        {
            // int maxHash = 4;
            // PrintIncreasingHashes(maxHash);
            // PrintDecreasingHashes(maxHash - 1);

            PrintHillOfHashes(4);
        }

        private static void PrintDecreasingHashes(int numOfLines)
        {
            for (int i = numOfLines - 1; i >= 0; i--)
            {
                for (int num = 0; num < i + 1; num++)
                {
                    Console.Write('#');
                }
                Console.Write('\n');
            }
        }
        private static void PrintHillOfHashes(int maxHashNum)
        {
            int numOflines = (maxHashNum * 2) - 1;
            for (int i = 0; i < numOflines; i++)
            {
                for (int num = 0; num < 4 - Math.Abs(4 - (i + 1)); num++)
                {
                    Console.Write('#');
                }
                Console.Write('\n');
            }
        }
        private static void PrintIncreasingHashes(int numOfLines)
        {
            for (int i = 0; i < numOfLines; i++)
            {
                for (int num = 0; num < i + 1; num++)
                {
                    Console.Write('#');
                }
                Console.Write('\n');
            }
        }

    }
}
