using System;
using System.Collections.Generic;
using System.Html;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptNamespace("CL3D")]
    public class Texture
    {
        [PreserveCase]
        public readonly ImageElement Image;
        public extern object getWebGLTexture();
    }
}
