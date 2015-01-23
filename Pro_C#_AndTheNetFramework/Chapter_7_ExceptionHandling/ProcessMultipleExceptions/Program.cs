using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProcessMultipleExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Handling Multiple Exceptions *****\n");
            Car myCar = new Car("Rusty", 90);
            try
            {
                // Trip Arg out of range exception.
                myCar.Accelerate(-10);
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    FileStream fs = File.Open(@"C:\carErrors.txt", FileMode.Open);
                }
                catch (Exception e2)
                {
                    // Throw an exception that records the new exception,
                    // as well as the message of the firest excepton.
                    throw new CarIsDeadException(e.Message, e2);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // This will always occur. Exception or not.
                myCar.CrankTunes(false);
            }
            
            Console.ReadKey();            
        }
    }
}
