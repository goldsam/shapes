using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShapesMVC.Generator
{
    public class ShapeGeneratorFactory
    {

        public static readonly string TRIANGLE = "triangle";

        public static readonly string DIAMOND = "diamond";

        public static readonly string RECTANGLE = "rectangle";

        public static readonly string SQUARE = "square";


        private static Dictionary<string, ShapeGenerator> _shapeWriters = CreateShapeWriters();
    
        private static Dictionary<string, ShapeGenerator> CreateShapeWriters()
        {
            Dictionary<string, ShapeGenerator> shapeWriters = new Dictionary<string, ShapeGenerator>();
            shapeWriters.Add(TRIANGLE, new TriangleGenerator());
            shapeWriters.Add(DIAMOND, new DiamondGenerator());
            shapeWriters.Add(RECTANGLE, new RectangleGenerator(3f/2));
            shapeWriters.Add(SQUARE, new RectangleGenerator(1f));

            return shapeWriters;
        }
    
        public static ShapeGenerator GetShapeGenerator( string shapeName )
        {
            ShapeGenerator shapeWriter = null;
            if (!_shapeWriters.TryGetValue(shapeName, out shapeWriter))
            {
                throw new ArgumentException("Unsupported shape: " + shapeName);
            }

            return shapeWriter;
        }
    }
}