using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL3D
{
    public class TriangleSelector
    {
        public extern Vect3d getCollisionPointWithLine(Vect3d start, Vect3d end, bool IgnoreBackFaces, Triangle3d triangle);
        public extern Vect3d getCollisionPointWithLine(Vect3d start, Vect3d end, bool IgnoreBackFaces, Triangle3d triangle, bool ignoreInvisibleItems);
    }
}
