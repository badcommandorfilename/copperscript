using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    public class Light
    {
        [PreserveCase]
        public double Color;
        [PreserveCase]
        public Vect3d Position;
        [PreserveCase]
        public Vect3d Attenuation;
        [PreserveCase]
        public Vect3d Radius;
    }
}
