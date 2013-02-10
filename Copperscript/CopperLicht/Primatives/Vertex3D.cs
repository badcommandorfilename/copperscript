using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    public class Vertex3D
    {
        [PreserveCase]
        public Vect3d Pos;
        [PreserveCase]
        public Vect3d TCoords;

        public extern Vertex3D(bool empty = true);
    }
}
