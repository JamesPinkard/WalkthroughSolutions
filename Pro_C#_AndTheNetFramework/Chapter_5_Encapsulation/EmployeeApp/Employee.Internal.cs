using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    partial class Employee
    {
        // Field data.
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;
        private string empSSN;

        // Constructors.
        public Employee() { }

        public Employee(string name, int id, float pay)
            : this(name, 0, id, pay, "NA") { }

        public Employee(string name, int age, int id, float pay, string ssn)
        {
            // Better! Use properties when setting class data.
            // This reduces the amount of duplicate error checks.
            Name = name;
            ID = id;
            Pay = pay;
            Age = age;
            empSSN = ssn;
        }
    }
}
