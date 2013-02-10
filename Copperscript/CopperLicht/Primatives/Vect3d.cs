using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptNamespace("CL3D")]
    public class Vect3d : Vect2d
    {
        [PreserveCase]
        public double Z;

        public extern Vect3d(double x, double y, double z);
    }
}
