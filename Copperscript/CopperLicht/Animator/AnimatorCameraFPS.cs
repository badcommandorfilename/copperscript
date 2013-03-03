using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    public class AnimatorCameraFPS : Animator
    {
        public double MoveSpeed;
        public double RotateSpeed;
        public extern AnimatorCameraFPS(CameraSceneNode cam, CopperLicht engine);
        [PreserveCase]
        public bool MayZoom;

        public extern void lookAt(Vect3d vect3d);

        public extern void setLookByMouseDown(bool p);
    }
}
