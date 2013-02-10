using CL3D;
using jQueryApi;
using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using System.Net;

namespace Tutorial4
{
    [ScriptNamespace("GLEngine")]
    public class Tutorial4
    {
        public void main()
        {
            // create the 3d engine
            CopperLicht engine = new CopperLicht("3darea");

            engine.initRenderer(); //Needs to be done BEFORE loading textures

            // add a new 3d scene

            Scene scene = new Scene();
            engine.addScene(scene);

            scene.setBackgroundColor(Global.createColor(1, 0, 0, 0));
            scene.setRedrawMode(Scene.REDRAW_WHEN_SCENE_CHANGED);

            // add a transparent billboard scene node with a text sign
            for (int i = 0; i < 50; ++i)
            {
                BillboardSceneNode billboard = new BillboardSceneNode();
                billboard.setSize(30, 30);
                billboard.Pos.X = Math.Random() * 80 - 40;
                billboard.Pos.Y = Math.Random() * 80 - 40;
                billboard.Pos.Z = Math.Random() * 80 - 40;
                billboard.getMaterial(0).Tex1 = engine.getTextureManager().getTexture("assets/particle.png", true);
                billboard.getMaterial(0).Type = Material.EMT_TRANSPARENT_ADD_COLOR;
                scene.getRootSceneNode().addChild(billboard);
            }

            // add a user controlled camera with a first person shooter style camera controller
            CameraSceneNode cam = new CameraSceneNode();
            cam.Pos.X = 50;
            cam.Pos.Y = 20;

            AnimatorCameraFPS animator = new AnimatorCameraFPS(cam, engine);
            cam.addAnimator(animator);
            animator.lookAt(new Vect3d(0, 20, 0));

            scene.getRootSceneNode().addChild(cam);
            scene.setActiveCamera(cam);

            // draw handler
            Vect3d pos3d = new Vect3d(0, 0, 0);

            engine.OnAnimate = new Action(delegate
            {
                Element element = jQuery.Select("#originlabel").GetElement(0);
                if (element != null)
                {
                    // set the position of the label to the 2d position of the 3d point

                    Vect2d pos2d = engine.get2DPositionFrom3DPosition(pos3d);
                    bool hide = false;

                    if (pos2d != null)
                    {
                        Element style = element.GetAttribute("style") as Element;
                        if (style != null)
                        {
                            //TODO: style is a JSON object, so making modifications to it requires parsing and modifying style.NodeValue

                            //style.SetAttribute("left", pos2d.X.ToFixed());
                            //element.style.left = pos2d.X;
                            //style.SetAttribute("top", pos2d.Y.ToFixed());
                            //element.style.top = pos2d.Y;
                        }
					
                        // hide if outside of the border
                        hide = pos2d.X < 0 
                            || pos2d.Y < 0 
                            || pos2d.X > engine.getRenderer().getWidth()-60 
                            || pos2d.Y > engine.getRenderer().getHeight()-20;
                         
                    }
                    else
                    {
                        hide = true;
                    }

                    //element.style.display = hide ? 'none' : 'block';
                }
            });
        }
    }
}
