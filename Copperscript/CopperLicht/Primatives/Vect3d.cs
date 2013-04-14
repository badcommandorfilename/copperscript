using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptNamespace("CL3D")]
    public class Vect3d : Vect2d
    {
        [PreserveCase]
        public double Z;

        public extern Vect3d(double x, double y, double z);

        public extern Vect3d add(Vect3d other);
        public extern Vect3d substract(Vect3d other); //Copperlicht function is labelled "substract" instead of "subtract"
        public extern Vect3d multiplyWithScal(double scalar);
        public extern Vect3d multiplyThisWithScal(double scalar);
        public extern Vect3d multiplyWithVect(Vect3d scale);
        public extern Vect3d multiplyThisWithVect(Vect3d scale);
        public extern void normalize();
    }
}
