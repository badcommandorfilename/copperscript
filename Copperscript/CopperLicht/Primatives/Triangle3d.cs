using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CL3D
{
    [Imported]
    public class Triangle3d
    {
        public Vect3d pointA;
        public Vect3d pointB;
        public Vect3d pointC;

        public extern Triangle3d(Vect3d vect3d1, Vect3d vect3d2, Vect3d vect3d3);
        public extern Vect3d getIntersectionWithLine(Vect3d linePoint, Vect3d lineVect);
    }
}
