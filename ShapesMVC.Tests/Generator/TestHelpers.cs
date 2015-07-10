using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesMVC.Generator;

namespace ShapesMVC.Tests.Generator
{
    /// <summary>
    /// Defines static methods for creating data used in unit tests.
    /// </summary>
    class TestHelpers
    {
        /// <summary>
        /// Returns a string containing the following ASCII-art diamond pattern:
        /// <pre>
        ///  X 
        /// X X
        ///  X 
        /// </pre>
        /// </summary>
        /// <returns>Simple ASCII art diamond pattern used for testing.</returns>
        public static string CreateSimpleDiamond()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("  X  ");
            sw.WriteLine(" X X ");
            sw.WriteLine("X X X");
            sw.WriteLine(" X X ");
            sw.WriteLine("  X  ");

            return sw.ToString();
        }


        public static ShapeParameters CreateShapeParametersLabelInside()
        {
            return new ShapeParameters
            {
                Height = 5,
                Label = "Hi",
                LabelRow = 3
            };  
        }

        public static ShapeParameters CreateShapeParametersLabelOutside()
        {
            return new ShapeParameters
            {
                Height = 3,
                Label = "Hi",
                LabelRow = 5
            };
        }
    }
}
