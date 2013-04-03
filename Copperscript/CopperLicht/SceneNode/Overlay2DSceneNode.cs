using System;
using System.Collections.Generic;
using System.Linq;

namespace CL3D
{
    public class Overlay2DSceneNode : SceneNode
    {
        public string FontName;
        public double TextColor;

        public extern void set2DPosition(double x, double y, double width, double height);
        public extern void setText(string text);
        public extern void setShowBackgroundColor(bool show, double color);
    }
}
