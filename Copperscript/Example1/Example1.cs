using CL3D;
using jQueryApi;
using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using WebGLExample;

namespace WebGLExample
{
    [ScriptNamespace("GLEngine")]
    public class Example1
    {
        public Example1()
        {

        }

        public void main()
        {
            CopperLicht engine = new CopperLicht("3darea");

            engine.initRenderer();

            Scene s = new Scene();
            engine.addScene(s);

            double col = Global.createColor(1, 0, 0, 64);

            s.setBackgroundColor(col);

            SceneNode n = new MySceneNode(engine);
            s.getRootSceneNode().addChild(n);

            n.addAnimator(new AnimatorRotation(new Vect3d(0, 0.6, 0.8)));

            BillboardSceneNode billboard = new BillboardSceneNode();

            billboard.setSize(20, 20);
            billboard.Pos.Y = 30;
            billboard.getMaterial(0).Tex1 = engine.getTextureManager().getTexture("assets/actionsign.jpg", true);
            billboard.getMaterial(0).Type = Material.EMT_TRANSPARENT_ADD_COLOR;
            s.getRootSceneNode().addChild(billboard);

            // add a user controlled camera with a first person shooter style camera controller
            CameraSceneNode cam = new CameraSceneNode();
            cam.Pos.X = 50;
            cam.Pos.Y = 20;

            AnimatorCameraFPS animator = new AnimatorCameraFPS(cam, engine);
            cam.addAnimator(animator);
            animator.lookAt(new CL3D.Vect3d(0, 20, 0));

            s.getRootSceneNode().addChild(cam);
            s.setActiveCamera(cam);
        }
    }
}
