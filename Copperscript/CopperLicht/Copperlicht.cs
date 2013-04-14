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
        public Action OnAnimate; //Called every frame
        [PreserveCase]
        public Action OnAfterDrawAll; //Called after every frame
        [PreserveCase]
        public Action OnBeforeDrawAll; //Called before every frame

        public extern CopperLicht(string canvassname);

        [ScriptName("getScene")] //Marks a function in the object's context
        public extern Scene getScene();

        [ScriptName("addScene")]
        public extern void addScene(Scene s);
        [ScriptName("getTextureManager")]
        public extern TextureManager getTextureManager();

        public extern bool initRenderer();
        public extern Renderer getRenderer();

        public extern Vect2d get2DPositionFrom3DPosition(Vect3d pos3d);
        public extern Vect3d get3DPositionFrom2DPosition(double x, double y);

        public extern void handleKeyUp(object e);

        public extern double getMouseX();
        public extern double getMouseY();
    }
}
