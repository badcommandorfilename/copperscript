using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptNamespace("CL3D")]
    public class Renderer
    {
        [ScriptName("setWorld")]
        public extern void setWorld(Matrix m);
        [ScriptName("drawMesh")]
        public extern void drawMesh(Mesh m);

        [ScriptName("getWidth")]
        public extern int getWidth();
        [ScriptName("getHeight")]
        public extern int getHeight();

        public extern int createMaterialType(string vertex_shader_source, string fragment_shader_source);
    }
}
