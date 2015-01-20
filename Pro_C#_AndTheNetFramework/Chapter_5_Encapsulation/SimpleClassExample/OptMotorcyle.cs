using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class OptMotorcyle
    {
        public int driverIntensity;
        public string driverName;

        public OptMotorcyle()
            :this(0,string.Empty)
        {

        }

        // Only needed for generic classes that implement the new() constraint.
        public OptMotorcyle(int intensity = 0, string name = "" )
        {
            driverIntensity = intensity;
            driverName = name;
        }

        public void PopAWheely()
        {
            for (int i = 0; i < driverIntensity; i++)
            {
                Console.WriteLine("Yeeeeeee Haaaaaeewww");
            }
        }

        public void SetDriverName(string name)
        {
            driverName = name;
        }
    }
}
