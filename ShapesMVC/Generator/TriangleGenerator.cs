using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShapesMVC.Generator
{
    public class TriangleGenerator : ShapeGenerator
    {
        protected override string GetShapePixels(int line, ShapeParameters shapeParameters)
        {
            return PixelRun(line + 1);
        }
    }
}