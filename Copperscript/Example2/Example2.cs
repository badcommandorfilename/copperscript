// Example2.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using jQueryApi;
using CL3D;

namespace WebGLExample
{
    public class Example2
    {

        public void main()
        {
            CopperLicht engine = new CopperLicht("3darea");

            engine.initRenderer();

            Scene s = new Scene();
            engine.addScene(s);

            double col = Global.createColor(1, 0, 0, 64);

            s.setBackgroundColor(col);

            AnimatedTextureNode billboard = new AnimatedTextureNode(engine);

            billboard.setSize(24, 12);
            billboard.Pos.Y = 10;
            s.getRootSceneNode().addChild(billboard);

            // add a user controlled camera with a first person shooter style camera controller
            CameraSceneNode cam = new CameraSceneNode();
            cam.Pos.X = 40;
            cam.Pos.Y = 10;

            AnimatorCameraFPS animator = new AnimatorCameraFPS(cam, engine);
            cam.addAnimator(animator);
            animator.lookAt(new CL3D.Vect3d(0, 30, 0));
            cam.removeAnimator(animator);

            s.getRootSceneNode().addChild(cam);
            s.setActiveCamera(cam);

            Window.SetInterval(delegate()
            {
                billboard.SetNextFrame();
            },
            250);
        }
    }
}
