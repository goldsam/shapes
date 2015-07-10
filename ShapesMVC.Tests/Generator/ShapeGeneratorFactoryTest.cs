using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapesMVC;
using ShapesMVC.Generator;
using System.IO;

namespace ShapesMVC.Tests.Generator
{
    [TestClass]
    public class ShapeGeneratorFactoryTest
    {

        [TestMethod]
        public void GetShapeGenerator_Diamond()
        {
            ShapeGenerator shapeGenerator = 
                ShapeGeneratorFactory.GetShapeGenerator(ShapeGeneratorFactory.DIAMOND);
            Assert.IsInstanceOfType(shapeGenerator, typeof(DiamondGenerator));
        }


        [TestMethod]
        public void GetShapeGenerator_Triangle()
        {
            ShapeGenerator shapeGenerator =
                ShapeGeneratorFactory.GetShapeGenerator(ShapeGeneratorFactory.TRIANGLE);
            Assert.IsInstanceOfType(shapeGenerator, typeof(TriangleGenerator));
        }

        [TestMethod]
        public void GetShapeGenerator_Square()
        {
            ShapeGenerator shapeGenerator =
                ShapeGeneratorFactory.GetShapeGenerator(ShapeGeneratorFactory.SQUARE);
            Assert.IsInstanceOfType(shapeGenerator, typeof(RectangleGenerator));
        }

        [TestMethod]
        public void GetShapeGenerator_Rectangle()
        {
            ShapeGenerator shapeGenerator =
                ShapeGeneratorFactory.GetShapeGenerator(ShapeGeneratorFactory.RECTANGLE);
            Assert.IsInstanceOfType(shapeGenerator, typeof(RectangleGenerator));
        }
    }
}
