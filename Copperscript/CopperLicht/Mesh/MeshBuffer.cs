using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    public class MeshBuffer
    {
        [PreserveCase]
        public int[] Indices;
        [PreserveCase]
        public ArrayList Vertices;
        [PreserveCase]
        public Material Mat;
    }
}
