using System;
using System.Collections.Generic;
using System.Html;
using jQueryApi;
using System.Runtime.CompilerServices;
using CL3D;

namespace Tutorial6
{
    /// <summary>
    /// Adaptation of Copperlicht Tutorial #6
    /// http://www.ambiera.com/copperlicht/documentation/tutorials/tutorial-06.html
    /// </summary>
    [ScriptNamespace("GLEngine")]
    public class Tutorial6
    {
        public CopperLicht main()
        {
            CopperLicht engine = Global.startCopperLichtFromFile("3darea", "assets/copperlichtdata/room.ccbjs");

            engine.OnLoadingComplete = delegate
            {
                Scene scene = engine.getScene();
                if (scene == null)
                {
                    return;
                }

                // in the CopperCube 3d editor, we already created a camera which collides against the wall in this scene.
                // But to demonstrate how this would work manually, we create a new camera here which does this as well:

                // add a user controlled camera

                CameraSceneNode cam = new CL3D.CameraSceneNode();

                // ensure to place the camera inside the room, or it will fall out, into the endless void

                cam.Pos.X = -50;
                cam.Pos.Y = 180;
                cam.Pos.Z = -20;

                // add an animator which makes the camera move by keyboard and mouse input

                AnimatorCameraFPS animator = new CL3D.AnimatorCameraFPS(cam, engine);
                animator.MoveSpeed = 0.2;
                animator.RotateSpeed = 250;
                animator.setLookByMouseDown(false); //  look when the mouse is moved
                cam.addAnimator(animator);
                animator.lookAt(new CL3D.Vect3d(-200, 90, 200));

                scene.getRootSceneNode().addChild(cam);
                scene.setActiveCamera(cam);

                // add the collision response animator to collide against walls

                AnimatorCollisionResponse colanimator = new AnimatorCollisionResponse(
                    new CL3D.Vect3d(20, 40, 20), // size of the player ellipsoid
                    new CL3D.Vect3d(0, -10, 0), // gravity direction
                    new CL3D.Vect3d(0, 30, 0), // position of the eye in the ellipsoid
                    scene.getCollisionGeometry());

                cam.addAnimator(colanimator);	
            };

            return engine;
        }

    }
}
