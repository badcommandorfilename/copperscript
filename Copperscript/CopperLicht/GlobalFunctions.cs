using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CL3D
{
    [Imported]
    [ScriptName("CL3D")]
    public static class Global
    {
        [ScriptAlias("startCopperLichtFromFile")] //Marks a function in the global context
        public static extern CopperLicht startCopperLichtFromFile(string name, string path);

        [ScriptAlias("CL3D.createColor")]
        public static extern double createColor(double a, double r, double g, double b);
    }
}
