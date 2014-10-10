using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThinkLikeAProgrammer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            HashImages.PrintHalfFiveHashSquare();
            HashImages.PrintHashTriangle();
            */
            

            Console.WriteLine( Directory.GetCurrentDirectory());
            
            int[] myNums = new int[] { 1, 2, 3, 4, 5,7,3,7,8,7, 6, 7, 8, 9, 10 };

            var uniqueInt = myNums.Distinct();

            Dictionary<int, int> numCount = new Dictionary<int, int>();

            foreach (var num in uniqueInt)
            {
                numCount.Add(num, myNums.Where(x=>x==num).Count());
            }

            int modeCount = 0;
            int mode=0;

            foreach (var pair in numCount)
            {
                if (modeCount <= pair.Value)
                {
                    modeCount = pair.Value;
                    mode = pair.Key;
                }
            }

            Console.WriteLine(mode.ToString());



            Console.ReadKey();
        }

        public void SixDigitTest()
        {
            int num = LuhnCheckSumValidation.convertCharToInt('5');
            Console.WriteLine(num);
            LuhnCheckSumValidation.ReadSixDigitID();
        }
    }
}



