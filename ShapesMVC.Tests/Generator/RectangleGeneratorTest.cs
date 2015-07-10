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
    public class RectangleGeneratorTest
    {
        /// <summary>
        /// Rectangle aspect ratio used for testing.
        /// </summary>
        private static readonly float ASPECT_RATIO = 7f / 5;

        [TestMethod]
        public void AspectRatio()
        {
            RectangleGenerator shapeWriter = new RectangleGenerator(ASPECT_RATIO);
            Assert.AreEqual(ASPECT_RATIO, shapeWriter.AspectRatio);
        }

        [TestMethod]
        public void WriteShape_RectangleLabelInside()
        {
            string expected = CreateExpectedLabelInside();

            RectangleGenerator shapeWriter = new RectangleGenerator(ASPECT_RATIO);
            string value = shapeWriter.GetShapeString(TestHelpers.CreateShapeParametersLabelInside());

            Assert.AreEqual(expected, value);
        }

        /// <summary>
        /// Returns a string containing the ASCII-art shape expected by the WriteShape_RectangleLabelInside() test.
        /// </summary>
        /// <returns>ASCII art string expected by test.</returns>
        public static string CreateExpectedLabelInside()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("X X X X X X X");
            sw.WriteLine("X X X X X X X");
            sw.WriteLine("X X XHi X X X");
            sw.WriteLine("X X X X X X X");
            sw.WriteLine("X X X X X X X");

            return sw.ToString();
        }

        [TestMethod]
        public void WriteShape_RectangleLabelOutside()
        {
            string expected = CreateExpectedLabelOutside();

            RectangleGenerator shapeWriter = new RectangleGenerator(ASPECT_RATIO);
            string value = shapeWriter.GetShapeString(TestHelpers.CreateShapeParametersLabelOutside());

            Assert.AreEqual(expected, value);
        }

        /// <summary>
        /// Returns a string containing the ASCII-art shape expected by the WriteShape_RectangleLabelOutside() test.
        /// </summary>
        /// <returns>ASCII art string expected by test.</returns>
        public static string CreateExpectedLabelOutside()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("X X X X");
            sw.WriteLine("X X X X");
            sw.WriteLine("X X X X");
            sw.WriteLine("       ");
            sw.WriteLine("  Hi   ");
            
            return sw.ToString();
        }
    }
}
