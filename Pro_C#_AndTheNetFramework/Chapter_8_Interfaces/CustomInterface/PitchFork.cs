﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class PitchFork : IPointy
    {
        public byte GetNumberOfPoints()
        {
            return Points;
        }

        public byte Points
        {
            get { return 3; }
        }
    }
}
