using CL3D;
using jQueryApi;
using System;
using System.Collections.Generic;
using System.Html;
using System.Linq;

namespace WebGLExample
{
    /// <summary>
    /// A Billboard node which has an animated texture
    /// </summary>
    class AnimatedTextureNode : BillboardSceneNode
    {
        CopperLicht cl;
        List<String> framelist;
        public AnimatedTextureNode(CopperLicht engine)
        {
            cl = engine;
            init();  // init scene node specific members

            this.OnRegisterSceneNode = delegate(Scene s)
            {
                s.registerNodeForRendering(this, Scene.RENDER_MODE_DEFAULT);

                if (framelist == null)
                {
                    //Generate the set of frames from a single image
                    FrameImage("assets/bat.png", 465, 64, 5,
                        delegate(IEnumerable<String> frames)
                        {
                            framelist = frames as List<String>;
                            SetFrame(0);
                        }
                    );
                }
            };
        }

        uint n = 0;
        public void SetNextFrame()
        {
            if(n >= framelist.Count)
            {
                n = 0;
            }
            SetFrame(n++);
        }

        private void SetFrame(uint frame)
        {
            if (framelist != null)
            {
                this.getMaterial(0).Tex1 = cl.getTextureManager().getTexture(framelist[(int)frame], true);
                this.getMaterial(0).Type = Material.EMT_TRANSPARENT_ALPHA_CHANNEL;
            }
        }

        /// <summary>
        /// Loads an image and breaks it into frames for animation
        /// </summary>
        /// <param name="imgsrc">URL of image to load</param>
        /// <param name="w">Width in pixels</param>
        /// <param name="h">Height in pixels</param>
        /// <param name="nframes">Number of frames</param>
        /// <param name="callback">Delegate to handle result once loading is complete</param>
        private void FrameImage(String imgsrc, uint w, uint h, uint nframes, Action<IEnumerable<string>> callback)
        {
            uint framew = (w / nframes);

            ImageElement tempimage = (ImageElement)jQuery.FromHtml(
                "<img id=\"tempimage\" " +
                "src=\"" + imgsrc + "\" " +
                "width = " + w + " " +
                "height = " + h + " " +
                "/>").GetElements()[0];

            CanvasElement imagecanvas = (CanvasElement)jQuery.FromHtml("<canvas id=\"tempcanvas\"/>").GetElements()[0];
            //Dirty hack alert! This is just here to shut the compiler up since CanvasContext isn't properly implemented in Script#
            JSDrawingContext ctx = (JSDrawingContext)imagecanvas.GetContext("2d");

            imagecanvas.Width = tempimage.Width;
            imagecanvas.Height = tempimage.Height;
            ctx.drawImage(tempimage, 0, 0, (int)w, (int)h);

            jQueryObject o = jQuery.Document.Add(tempimage);

            o.Bind("load", new jQueryEventHandler(
                delegate
                {
                    List<string> framelist = new List<string>();
                    for (uint f = 0; f < nframes; f++)
                    {
                        uint x1 = f * framew;
                        uint x2 = x1 + framew;
                        CanvasElement tempcanvas = (CanvasElement)jQuery.FromHtml("<canvas id=\"tempcanvas" + f + "\"/>").GetElements()[0];

                        tempcanvas.Width = (int)framew;
                        tempcanvas.Height = (int)h;
                        JSDrawingContext tempctx = (JSDrawingContext)tempcanvas.GetContext("2d");

                        for (int y = 0; y < tempcanvas.Height; y++)
                        {
                            for (int x = (int)x1; x < (int)x2; x++)
                            {
                                JSPixelData pix = (JSPixelData)ctx.getImageData(x, y, 1, 1);
                                tempctx.putImageData(pix, x - (int)x1, y);
                            }
                        }
                                                    
                        String newsrc = tempcanvas.GetDataUrl("image/png");
                        framelist.Add(newsrc);
                    }

                    if (callback != null)
                    {
                        callback(framelist);
                    }
                }
                ));
        }
    }
}
