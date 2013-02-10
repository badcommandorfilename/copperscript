using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    public class Mesh
    {
        [PreserveCase]
        public extern MeshBuffer[] GetMeshBuffers();
        [PreserveCase]
        public extern void AddMeshBuffer(MeshBuffer buf);
    }
}
