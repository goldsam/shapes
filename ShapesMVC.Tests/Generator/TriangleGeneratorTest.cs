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
    public class TriangleGeneratorTest
    {

        [TestMethod]
        public void WriteShape_TriangleLabelInside()
        {
            string expected = CreateExpectedLabelInside();

            TriangleGenerator shapeWriter = new TriangleGenerator();
            string value = shapeWriter.GetShapeString(TestHelpers.CreateShapeParametersLabelInside());

            Assert.AreEqual(expected, value);
        }

        /// <summary>
        /// Returns a string containing the ASCII-art shape expected by the WriteShape_TriangleLabelInside() test.
        /// </summary>
        /// <returns>ASCII art string expected by test.</returns>
        public static string CreateExpectedLabelInside()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("    X    ");
            sw.WriteLine("   X X   ");
            sw.WriteLine("  XHi X  ");
            sw.WriteLine(" X X X X ");
            sw.WriteLine("X X X X X");

            return sw.ToString();
        }

        [TestMethod]
        public void WriteShape_TriangleLabelOutside()
        {
            string expected = CreateExpectedLabelOutside();

            TriangleGenerator shapeWriter = new TriangleGenerator();
            string value = shapeWriter.GetShapeString(TestHelpers.CreateShapeParametersLabelOutside());

            Assert.AreEqual(expected, value);
        }

        /// <summary>
        /// Returns a string containing the ASCII-art shape expected by the WriteShape_TriangleLabelOutside() test.
        /// </summary>
        /// <returns>ASCII art string expected by test.</returns>
        public static string CreateExpectedLabelOutside()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("  X  ");
            sw.WriteLine(" X X ");
            sw.WriteLine("X X X");
            sw.WriteLine("     ");
            sw.WriteLine(" Hi  ");

            return sw.ToString();
        }
    }
}
