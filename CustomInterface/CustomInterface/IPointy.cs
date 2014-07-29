using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    interface IPointy
    {
        // Implicitly public and abstract
        // Read-only property
        byte Points { get; }
    }
}
