using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShapesMVC.Generator
{
    public class RectangleGenerator : ShapeGenerator
    {
        private float _aspectRatio;

        public RectangleGenerator(float aspectRatio)
        {
            _aspectRatio = aspectRatio;
        }

        protected override string GetShapePixels(int line, ShapeParameters shapeParameters)
        {
            return GetShapeScanLine(shapeParameters);
        }

        private string GetShapeScanLine(ShapeParameters shapeParameters)
        {
            int runLength = (int)Math.Round(shapeParameters.Height * _aspectRatio);
            return PixelRun(runLength);
        }

        public float AspectRatio
        {
            get { return _aspectRatio; }
        }
    }
}