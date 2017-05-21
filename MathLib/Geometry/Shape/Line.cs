using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLib
{
    public class Line
    {
        public readonly Vector3 V0;
        public readonly Vector3 V1;

        public Line(Vector3 v0, Vector3 v1)
        {
            V0 = v0;
            V1 = v1;
        }
    }
}
