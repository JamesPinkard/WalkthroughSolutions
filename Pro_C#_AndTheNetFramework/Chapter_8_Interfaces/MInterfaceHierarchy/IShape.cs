using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MInterfaceHierarchy
{
    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
}
