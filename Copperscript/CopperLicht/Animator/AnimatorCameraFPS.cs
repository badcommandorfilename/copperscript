using System;
using System.Collections.Generic;
using System.Linq;

namespace CL3D
{
    public class AnimatorCameraFPS : Animator
    {
        public extern AnimatorCameraFPS(CameraSceneNode cam, CopperLicht engine);

        public extern void lookAt(Vect3d vect3d);
    }
}
