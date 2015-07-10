using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShapesMVC.Generator
{
    public class DiamondGenerator : ShapeGenerator
    {
        protected override string GetShapePixels(int line, ShapeParameters shapeParameters)
        {
            int runLength = Math.Min(shapeParameters.Height - line, line + 1);
            return PixelRun(runLength);
        }
    }
}