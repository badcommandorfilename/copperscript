using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptNamespace("CL3D")]
    public class Scene
    {
        [PreserveCase]
        public static readonly int REDRAW_EVERY_FRAME;
        [PreserveCase]
        public static readonly int RENDER_MODE_DEFAULT;
        [PreserveCase]
        public static readonly int REDRAW_WHEN_SCENE_CHANGED;


        [ScriptName("setRedrawMode")]
        public extern void setRedrawMode(int mode);
        [ScriptName("setBackgroundColor")]
        public extern void setBackgroundColor(double p);

        [ScriptName("getSceneNodeFromName")]
        public extern SceneNode getSceneNodeFromName(String name);
        [ScriptName("getRootSceneNode")]
        public extern SceneNode getRootSceneNode();

        [ScriptName("setActiveCamera")]
        public extern void setActiveCamera(CameraSceneNode cam);
        [ScriptName("registerNodeForRendering")]
        public extern void registerNodeForRendering(SceneNode n, int mode);

        public extern MetaTriangleSelector getCollisionGeometry();
    }
}
