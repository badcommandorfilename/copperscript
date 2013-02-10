using System;
using System.Collections;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptNamespace("CL3D")]
    public class CopperLicht
    {
        [PreserveCase]
        public Action OnLoadingComplete;
        [PreserveCase]
        public Action OnAnimate;

        public extern CopperLicht(string canvassname);

        [ScriptName("getScene")] //Marks a function in the object's context
        public extern Scene getScene();

        [ScriptName("addScene")]
        public extern void addScene(Scene s);
        [ScriptName("getTextureManager")]
        public extern TextureManager getTextureManager();

        [ScriptName("initRenderer")]
        public extern bool initRenderer();

        [ScriptName("get2DPositionFrom3DPosition")]
        public extern Vect2d get2DPositionFrom3DPosition(Vect3d pos3d);

        [ScriptName("getRenderer")]
        public extern Renderer getRenderer();
    }
}
