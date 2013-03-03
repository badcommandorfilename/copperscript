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
        private CopperLicht engine = null;

        public CopperLicht main()
        {
            engine = Global.startCopperLichtFromFile("3darea", "assets/copperlichtdata/room.ccbjs");

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

                cam.setFov(Math.PI / 4.0);

                // add an animator which makes the camera move by keyboard and mouse input

                AnimatorCameraFPS animator = new CL3D.AnimatorCameraFPS(cam, engine);
                animator.MoveSpeed = 0.2;
                animator.RotateSpeed = 250;
                animator.setLookByMouseDown(false); //  look when the mouse is moved
                animator.MayZoom = false;

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

        public void setEventHandlers()
        {
            jQuery.Document.Keyup(new jQueryEventHandler(delegate(jQueryEvent e)
                {
                    int key = e.Which;

                    // every time the user presses e, we want to do a collision test with the wall
                    // and create a cube where we hit the wall
                    if (key == 69)
                    {
                        shootCube();
                    }

                    if (key == 32)
                    {
                        jump();
                    }

                    // we need to call the key handler of the 3d engine as well, so that the user is
                    // able to move the camera using the keys
                    engine.handleKeyUp(e);
                }
                ));
        }

        private void jump()
        {

        }

        public SceneNode shootCube()
        {
            Scene scene = engine.getScene();
            if (scene == null)
            {
                return null;
            }

            CameraSceneNode cam = scene.getActiveCamera();
			
			// calculate the start and end 3d point of the line, the beinning being
			// the camera position and the end about 2000 units away in the direction of the
			// camera target
			
			Vect3d startLine = cam.getAbsolutePosition();
            Vect3d endLine = startLine.add(cam.getTarget().substract(startLine).multiplyWithScal(2000.0));
			
			// test our line for a collision with the world
			
			Vect3d collisionPoint = scene.getCollisionGeometry().getCollisionPointWithLine(startLine, endLine, true, null);
						
			if (collisionPoint != null)
			{
				// a collision has been found.
                CubeSceneNode cubeCollision = new CubeSceneNode();
				scene.getRootSceneNode().addChild(cubeCollision);
				cubeCollision.getMaterial(0).Tex1 = engine.getTextureManager().getTexture("assets/ground_stone.jpg", true);
				
				cubeCollision.Pos = collisionPoint; //Move the new cube

                MetaTriangleSelector geometry = scene.getCollisionGeometry() as MetaTriangleSelector;

                if (geometry != null)
                {
                    geometry.addSelector(new MeshTriangleSelector(cubeCollision.getMesh(), cubeCollision)); 
                    //Add the new cube to the collision geometry
                }

                return cubeCollision;
			}

            return null;
        }
    }
}
