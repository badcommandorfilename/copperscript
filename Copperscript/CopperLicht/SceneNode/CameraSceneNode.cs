using System;
using System.Collections.Generic;
using System.Linq;

namespace CL3D
{
    public class CameraSceneNode : SceneNode
    {
        public extern Vect3d getTarget();
        public extern void setTarget(Vect3d target);

        public extern void setFov(double radians);

        public extern void setUpVector(Vect3d upvector);
    }
}
