using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptNamespace("CL3D")]
    public class AnimatorRotation : Animator
    {
        public extern AnimatorRotation(Vect3d axis);
    }
}
