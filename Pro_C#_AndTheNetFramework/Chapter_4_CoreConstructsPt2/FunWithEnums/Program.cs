using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnums
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with Enums ****");

            // Make a contractor type.
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            // Print storage for the enum.
            Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(emp.GetType()));

            // Prints storage for enum without needing a variable of the entity
            Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(typeof(EmpType)));

            // Prints out "emp is a Contractor"
            Console.WriteLine("emp is a {0}.", emp.ToString());

            // Prints out "Contractor = 2"
            Console.WriteLine("{0} = {1}", emp.ToString(), (int)emp);

            EmpType e2 = EmpType.Contractor;
            
            // These types are enums in the System namespace.
            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Gray;

            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);
            Console.ReadLine();
        }

        private static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);

            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));

            // Get all name/value pairs for incoming parameter.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);

            // Now show the string name and associated value, using the D format
            // flag (see Chapter 3).
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}", enumData.GetValue(i));
            }
            Console.WriteLine();
        }

        private static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have to be kidding...");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!");
                    break;
                default:
                    Console.WriteLine("Who are you?");
                    break;
            }
        }

        // A custom enumeration.
        enum EmpType
        {
            Manager,    // = 0
            Grunt, // = 1
            Contractor, // = 2
            VicePresident // = 3
        }

        enum Pokemon
        {
            Pikachu = 83,
            Blastoise, // = 84
            Venesaur // = 85
        }

        enum TMNT
        {
            Leonardo = 16,
            Donatello = 25,
            Michaelangelo = 13,
            Raphael = 14
        }
    }
}
