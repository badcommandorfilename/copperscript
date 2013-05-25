using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptNamespace("CL3D")]
    public class Material
    {
        [PreserveCase]
        public static readonly int EMT_TRANSPARENT_ADD_COLOR;
        [PreserveCase]
        public static readonly int EMT_TRANSPARENT_ALPHA_CHANNEL;
        [PreserveCase]
        public static readonly int EMT_SOLID;

        [PreserveCase]
        public int Type;

        [PreserveCase]
        public Texture Tex1;
        [PreserveCase]
        public Texture Tex2;
        [PreserveCase]
        public bool Lighting;
        
    }
}
