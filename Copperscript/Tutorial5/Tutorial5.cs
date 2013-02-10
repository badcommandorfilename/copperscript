using System;
using System.Collections.Generic;
using System.Html;
using jQueryApi;
using CL3D;
using System.Runtime.CompilerServices;

namespace Tutorial5
{
    [ScriptNamespace("GLEngine")]
    public class Tutorial5
    {    
        public void main()
    {
    		// create the 3d engine
		CopperLicht engine = new CopperLicht("3darea");
		
		if (!engine.initRenderer())
        {
			return; // this browser doesn't support WebGL
        }
			
		// add a new 3d scene
		
		Scene scene = new Scene();
		engine.addScene(scene);
		
		scene.setBackgroundColor(Global.createColor(1, 0, 0, 0));
		scene.setRedrawMode(Scene.REDRAW_WHEN_SCENE_CHANGED);


        // add a sky box
       SceneNode skybox = new SkyBoxSceneNode();
        scene.getRootSceneNode().addChild(skybox);

        // set texture sides of the skybox
        for (int i = 0; i < 6; ++i)
        {
            skybox.getMaterial(i).Tex1 = engine.getTextureManager().getTexture("assets/stars.jpg", true);
        }

        // add a cube to test out
        SceneNode cubenode = new CubeSceneNode();
        scene.getRootSceneNode().addChild(cubenode);
        cubenode.getMaterial(0).Tex1 = engine.getTextureManager().getTexture("assets/crate_wood.jpg", true);

        // add a user controlled camera with a first person shooter style camera controller
        CameraSceneNode cam = new CameraSceneNode();
        cam.Pos.X = 20;
        cam.Pos.Y = 15;

        AnimatorCameraFPS animator = new AnimatorCameraFPS(cam, engine);
        cam.addAnimator(animator);
        animator.lookAt(new CL3D.Vect3d(0, 0, 0));

        scene.getRootSceneNode().addChild(cam);
        scene.setActiveCamera(cam);		
		
            		// now, we want to use a custom material for our cube, lets write
		// a vertex and a fragment shader:
		
		string vertex_shader_source = @"\
			#ifdef GL_ES								\n\
			precision highp float;						\n\
			#endif										\n\
			uniform mat4 worldviewproj;					\
			attribute vec4 vPosition;					\
			attribute vec4 vNormal;						\
			attribute vec2 vTexCoord1;					\
			attribute vec2 vTexCoord2;					\
			varying vec2 v_texCoord1;					\
			varying vec2 v_texCoord2;					\
			void main()									\
			{											\
				gl_Position = worldviewproj * vPosition;\
				v_texCoord1 = vTexCoord1.st;			\
				v_texCoord2 = vTexCoord2.st;			\
			}";
			
		string fragment_shader_source = @"\
			#ifdef GL_ES												\n\
			precision highp float;										\n\
			#endif														\n\
			uniform sampler2D texture1;									\
			uniform sampler2D texture2;									\
																		\
			varying vec2 v_texCoord1;									\
			varying vec2 v_texCoord2;									\
																		\
			void main()													\
			{															\
				vec2 texCoord = vec2(v_texCoord1.s, v_texCoord1.t);		\
				gl_FragColor = texture2D(texture1, texCoord) * 2.0;		\
			}";
		
		// create a solid material using the shaders. For transparent materials, take a look
		// at the other parameters of createMaterialType

        int newMaterialType = engine.getRenderer().createMaterialType(vertex_shader_source, fragment_shader_source);

        if (newMaterialType != -1)
        {
            cubenode.getMaterial(0).Type = newMaterialType;
        }
    }
    }


}
