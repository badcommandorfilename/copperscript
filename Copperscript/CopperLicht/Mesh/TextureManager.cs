﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptNamespace("CL3D")]
    public class TextureManager
    {
        [ScriptName("getTexture")]
        public extern Texture getTexture(string url, bool load);
    }
}
