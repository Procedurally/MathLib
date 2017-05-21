using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLib
{
    public class Polygon
    {
        public readonly Vector3[] Vertices;

        public Polygon(params Vector3[] vertices)
        {
            Vertices = vertices;
        }
    }
}
