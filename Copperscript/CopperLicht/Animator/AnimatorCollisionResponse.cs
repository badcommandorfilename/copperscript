using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL3D
{
    public class AnimatorCollisionResponse : Animator
    {
        public extern AnimatorCollisionResponse(
            Vect3d radius, // size of the ellipsoid
            Vect3d force, // gravity direction
            Vect3d translation, // position of the eye in the ellipsoid
            TriangleSelector world);

        public extern AnimatorCollisionResponse(
            Vect3d radius, // size of the ellipsoid
            Vect3d force, // gravity direction
            Vect3d translation, // position of the eye in the ellipsoid
            TriangleSelector world,
            double friction);
    }
}
