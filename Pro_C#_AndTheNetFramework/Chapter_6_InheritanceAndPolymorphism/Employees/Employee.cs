using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    abstract partial class Employee
    {
        // USE PROPERTY DATA THROUGHOUT CLASS IMPLEMENTATION

        protected BenefitPackage empBenefits = new BenefitPackage();

        public string SSN 
        { 
            get { return empSSN; } 
        }

        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! Name must be less than 16 characters!");
                }
                else
                {
                    empName = value;
                }
            }
        }

        public int ID { get { return empID; } set { empID = value; } }
        public float Pay { get { return currPay; } set { currPay = value; } }

        public int Age
        {
            get { return empAge; }
            set { empAge = value; }
        }


        // Methods
        public double GetBenefitCost()
        {
            return empBenefits.ComputePayDeduction();
        }

        public BenefitPackage Benefits
        {
            get { return empBenefits; }
            set { empBenefits = value; }
        }

        public virtual void GiveBonus(float amount)
        {
            Pay += amount;
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Pay: {0}", Pay);
        }
    }
}
