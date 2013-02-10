using CL3D;
using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;

namespace Tutorial2
{
    [ScriptNamespace("GLEngine")]
    public class Tutorial2
    {
        public SceneNode cube;
        public SceneNode sphere;
        public CopperLicht engine;

        public Tutorial2()
        {
        }

        public void main()
        {
            engine = Global.startCopperLichtFromFile("3darea", @"assets/index.ccbjs");

            engine.OnLoadingComplete = delegate
            {
                Scene scene = engine.getScene();

                if (scene != null)
                {
                    cube = scene.getSceneNodeFromName("cubeMesh1");

                    scene.setRedrawMode(Scene.REDRAW_EVERY_FRAME);

                    sphere = scene.getSceneNodeFromName("sphereMesh1");

                    sphere.addAnimator(new AnimatorRotation(new Vect3d(1, 1, 1)));
                }
            };
        }
    }
}
