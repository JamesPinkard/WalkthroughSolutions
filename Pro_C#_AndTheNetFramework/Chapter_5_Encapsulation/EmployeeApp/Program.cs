using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Encapsulation ***** \n");
            Employee emp = new Employee("Marvin", 456, 3000);
            emp.GiveBonus(1000);
            emp.DisplayStats();

            // Set and get the Name property.
            emp.Name = "Marv";
            Console.WriteLine("Employee is named {0}", emp.Name);

            Employee joe = new Employee();
            joe.Age++;
            Console.WriteLine("Joe's age is {0}", joe.Age);
            
            Console.ReadKey();
        }
    }
}
