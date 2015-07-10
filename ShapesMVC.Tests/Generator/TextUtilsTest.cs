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
    public class TextUtilsTest
    {
        [TestMethod]
        public void Overlay_OverlayShorterThanBackground()
        {
            string background = "XYXYXYXYXYXY";
            string overlay = "-{}-";

            string expected= "XYXY-{}-XYXY";

            Assert.AreEqual(expected, TextUtils.Overlay(background, overlay));
        }

        [TestMethod]
        public void Overlay_OverlayLongerThanBackground()
        {
            string background = "-{}-";
            string overlay = "XYXYXYXYXYXY";

            string expected = "XYXYXYXYXYXY";

            Assert.AreEqual(expected, TextUtils.Overlay(background, overlay));
        }

        [TestMethod]
        public void Center_TextShorterThanWidth()
        {
            string value = "-{}-";
            string expected =  "  -{}-  ";
            
            Assert.AreEqual(expected, TextUtils.Center(value, 8));
        }

        [TestMethod]
        public void Center_TextWiderThanWidth()
        {
            string value = "-{}-{}-";
            string expected = "{}-{}";

            Assert.AreEqual(expected, TextUtils.Center(value, 5));
        }

        [TestMethod]
        public void Spaces()
        {
            string expected = "     ";

            Assert.AreEqual(expected, TextUtils.Spaces(5));
        }
    }
}
