// MySceneNode.cs
//

using CL3D;
using jQueryApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Html;

namespace WebGLExample
{
    public class MySceneNode : SceneNode
    {
        CopperLicht cl;
        public MySceneNode(CopperLicht engine)
        {
            cl = engine;
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

            buf.Mat.Tex1 = engine.getTextureManager().getTexture("assets/ground_brown.jpg", true);

            this.OnRegisterSceneNode = delegate(Scene s)
            {
                s.registerNodeForRendering(this, Scene.RENDER_MODE_DEFAULT);
            };

            this.render = delegate(Renderer r)
            {
                object gl = r.getWebGL();

                object gltex = buf.Mat.Tex1.getWebGLTexture();

                ImageElement img = buf.Mat.Tex1.Image;

                Matrix4 t = this.getAbsoluteTransformation();
                if (t != null)
                {
                    r.setWorld(t);
                }

                Mesh m = this.Mesh;
                r.drawMesh(m);
            };
        }

        public void RandomizeTexture()
        {
            RecolourImage("assets/ground_brown.jpg", 256, 256, delegate(ImageElement img)
            {
                this.Mesh.GetMeshBuffers()[0].Mat.Tex1 = cl.getTextureManager().getTexture(img.Src, true);
            });
        }

        private void RecolourImage(String imgsrc, uint w, uint h, Action<ImageElement> callback)
        {
            ImageElement tempimage = (ImageElement)jQuery.FromHtml(
                "<img id=\"tempimage\" " +
                "src=\"" + imgsrc + "\" " +
                "width = " + w + " " +
                "height = " + h + " " +
                "/>").GetElements()[0];
            CanvasElement tempcanvas = (CanvasElement)jQuery.FromHtml("<canvas id=\"tempcanvas\"/>").GetElements()[0];

            jQueryObject o = jQuery.Document.Add(tempimage);

            o.Bind("load", new jQueryEventHandler(
                delegate
                {
                    //Dirty hack alert! This is just here to shut the compiler up since CanvasContext isn't properly implemented in Script#
                    JSDrawingContext ctx = (JSDrawingContext)tempcanvas.GetContext("2d");

                    tempcanvas.Width = tempimage.Width;
                    tempcanvas.Height = tempimage.Height;
                    ctx.drawImage(tempimage, 0, 0, tempimage.Width, tempimage.Height);

                    double red = Math.Random() * 254 - 128;
                    double green = Math.Random() * 254 - 128;
                    double blue = Math.Random() * 254 - 128;

                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            JSPixelData pix = (JSPixelData)ctx.getImageData(x, y, 1, 1);
                            pix.data[0] += (Byte)red;
                            pix.data[1] += (Byte)green;
                            pix.data[2] += (Byte)blue;
                            ctx.putImageData(pix, x, y);
                        }
                    }

                    if (callback != null)
                    {
                        String newsrc = tempcanvas.GetDataUrl("image/jpg");
                        
                        ImageElement newimage = (ImageElement)jQuery.FromHtml(
                "<img id=\"newimage\" " +
                "src=\"" + newsrc + "\" " +
                "width = " + w + " " +
                "height = " + h + " " +
                "/>").GetElements()[0];

                        callback(newimage);
                    }
                }
                ));
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
