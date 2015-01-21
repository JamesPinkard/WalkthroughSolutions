using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        // Create a subclass object and access base class functionality
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Class Hierarchy *****\n");
            SalesPerson fred = new SalesPerson();
            fred.Age = 31;
            fred.Name = "Fred";
            fred.SalesNumber = 50;

            // Assume Manager has a constructor matching this signature:
            // (string fullName, int age, int empID,
            // float currPay, string ssn, int numbofOpts)
            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            double cost = chucky.GetBenefitCost();
            chucky.GiveBonus(300);
            chucky.DisplayStats();
            Console.WriteLine();

            // Define my benefit level.
            BenefitPackage.BenefitPackageLevel myBenefitLevel = BenefitPackage.BenefitPackageLevel.Platinum;

            SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "932-32-3232", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();

            Console.ReadKey();            
        }
    }
}
