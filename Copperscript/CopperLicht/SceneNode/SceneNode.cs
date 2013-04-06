using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    public class SceneNode
    {
        [PreserveCase]
        public Action<Scene> OnRegisterSceneNode;
        [PreserveCase]
        public Action<Renderer> render;

        [PreserveCase]
        public Vect3d Pos;
        [PreserveCase]
        public Vect3d Rot;
        [PreserveCase]
        public Mesh Mesh;
        [PreserveCase]
        public Mesh OwnedMesh;
        [PreserveCase]
        public Vect3d Scale;


        [PreserveCase]
        public extern void addAnimator(Animator animiator);
        [PreserveCase]
        public extern void removeAnimator(AnimatorCameraFPS animator);

        public extern void addChild(SceneNode n);
        public extern void removeChild(SceneNode n);

        [ScriptName("getMaterial")]
        public extern Material getMaterial(int layer);

        public extern Vect3d getAbsolutePosition();
        public extern Matrix4 getAbsoluteTransformation();
        public extern void updateAbsolutePosition();

        [ScriptName("init")]
        protected extern void init();
    }
}
