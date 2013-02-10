// MySceneNode.cs
//

using CL3D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Tutorial3
{
    public class MySceneNode : SceneNode
    {
        public MySceneNode(CopperLicht engine)
        {
            init();  // init scene node specific members
		
		    // create a 3d mesh with one mesh buffer
		
		    this.Mesh = new Mesh();
		    MeshBuffer buf = new MeshBuffer();
		    this.Mesh.AddMeshBuffer(buf);

		    // set indices and vertices

            buf.Indices = new int[] { 0, 2, 3, 2, 1, 3, 1, 0, 3, 2, 0, 1 };

            buf.Vertices.Add(createvertex(0, 0, 10, 0, 0));
            buf.Vertices.Add(createvertex(10, 0, -10, 1, 0));
            buf.Vertices.Add(createvertex(0, 20, 0, 0, 1));
            buf.Vertices.Add(createvertex(-10, 20, -10, 1, 1));

            buf.Mat.Tex1 = engine.getTextureManager().getTexture("assets/test.jpg", true);

            this.OnRegisterSceneNode = delegate(Scene s)
            {
                s.registerNodeForRendering(this, Scene.RENDER_MODE_DEFAULT);
                //base.OnRegisterSceneNode(s);
            };

            this.render = delegate(Renderer r)
            {
                Matrix4 t = this.getAbsoluteTransformation();
                if (t != null)
                {
                    r.setWorld(t);
                }

                Mesh m = this.Mesh;
                r.drawMesh(m);
            };
        }

        private Vertex3D createvertex(double x, double y, double z, int s, int t)
        {
            Vertex3D vtx = new Vertex3D(true);
            vtx.Pos.X = x;
            vtx.Pos.Y = y;
            vtx.Pos.Z = z;
            vtx.TCoords.X = s;
            vtx.TCoords.Y = t;
            return vtx;
        }
    }
}
