using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkLikeAProgrammer
{
    class LuhnCheckSumValidation
    {
        public static int convertCharToInt(char digit)
        {
            int num = digit - '0';
            return num;
        }
        private static int doubleDigitSum(int num)
        {
            int doubledDigit = num * 2;
            int sum;
            if (doubledDigit >= 10)
            {
                sum = 1 + doubledDigit % 10;
            }
            else
            {
                sum = doubledDigit;
            }
            return sum;
        }

        // needs refactoring
        public static void ReadSixDigitID()
        {
            char digit;
            int evenChecksum = 0;
            int oddChecksum = 0;
            Console.WriteLine("Enter a six-digit number:");

            ConsoleKeyInfo key = Console.ReadKey();
            int position = 1;
            
            while(key.Key != ConsoleKey.Enter)
            {                
                digit = key.KeyChar;
                int num = convertCharToInt(digit);

                if (position % 2 == 0)
                {
                    evenChecksum += num;
                    oddChecksum += doubleDigitSum(num);
                }
                else
                {
                    evenChecksum += doubleDigitSum(num);
                    oddChecksum += num;
                }
                key = Console.ReadKey();
                position++;
            }

            int finalChecksum;
            if (position % 2 == 0)
            {
                finalChecksum = oddChecksum;
            }
            else
            {
                finalChecksum = evenChecksum;
            }

            Console.WriteLine("\nChecksum is {0}", finalChecksum);

            if (finalChecksum % 10 == 0)
            {
                Console.WriteLine("Checksum is divisible by 10. Valid. \n");
            }
            else
            {
                Console.WriteLine("Checksum is not divisible by 10. Invalid. \n");
            }
        }
    }
}
