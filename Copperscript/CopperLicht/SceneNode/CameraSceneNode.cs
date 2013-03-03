using System;
using System.Collections.Generic;
using System.Linq;

namespace CL3D
{
    public class CameraSceneNode : SceneNode
    {
        public extern Vect3d getTarget();
        public extern void setFov(double radians);
    }
}
