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
        public extern void setWorld(Matrix m);
        public extern void drawMesh(Mesh m);

        public extern int getWidth();
        public extern int getHeight();

        public extern int createMaterialType(string vertex_shader_source, string fragment_shader_source);

        public extern object getWebGL();
    }
}
