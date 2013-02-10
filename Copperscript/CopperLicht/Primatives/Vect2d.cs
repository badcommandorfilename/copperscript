using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptNamespace("CL3D")]
    public class Vect2d
    {
        [PreserveCase]
        public double X;
        [PreserveCase]
        public double Y;

        public extern Vect2d(double x, double y);
    }
}
