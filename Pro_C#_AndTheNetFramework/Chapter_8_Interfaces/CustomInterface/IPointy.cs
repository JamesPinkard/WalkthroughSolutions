using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    // This interface defines the behavior of "having points."
    interface IPointy
    {
        // Implicitly public and abstract.
        byte GetNumberOfPoints();
        byte Points { get; }

        // Error! Interfaces cannot have data fields!
        // public int numbOfPoints

        // Error! Interfaces do not have constructors!
        // public IPointy() { numbOfPoints = 0 ;};

        // Error! Interfaces don't provide an implementation of members!
        // byte GetNumberOfPoints() { return numbOfPoints; }
    }
}
