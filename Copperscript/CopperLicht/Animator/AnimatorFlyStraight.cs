using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL3D
{
    public class AnimatorFlyStraight : Animator
    {
        public extern AnimatorFlyStraight(
            Vect3d start,
            Vect3d end,
            uint timeForWay,
            bool loop,
            bool deleteMeAfterEndReached,
            bool animateCameraTargetInsteadOfPosition);
    }
}
