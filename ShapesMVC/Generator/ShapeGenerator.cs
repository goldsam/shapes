using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShapesMVC.Generator
{
    public abstract class ShapeGenerator
    {
        /// <summary>
        /// Generates a shape and returns it as a string.
        /// </summary>
        /// <param name="shapeParameters">Shape parameters</param>
        /// <returns>Generated shape as a string.</returns>
        public string GetShapeString(ShapeParameters shapeParameters)
        {
            return WriteShape(new StringWriter(), shapeParameters).ToString();
        }

        /// <summary>
        /// Generates a shape, writing it to given <see cref="TextWriter"/> instance.
        /// </summary>
        /// <param name="textWriter"><see cref="TextWriter"/> to write shape to/param>
        /// <param name="shapeParameters">Shape parameters</param>
        /// <returns>argument <see cref="TextWriter"/></returns>
        public TextWriter WriteShape(TextWriter textWriter, ShapeParameters shapeParameters)
        {
            // Collect all unformatted scanlines.
            List<String> scanLines = new List<string>();
            int scanLineCount = GetScanLineCount(shapeParameters);
            for (int i = 0; i < scanLineCount; i++)
            {
                scanLines.Add(GetScanLine(i, shapeParameters));
            }

            // Output each line, centered with respect to the longest line.
            int maxLineLength = 
                (scanLines.Count > 0) ? scanLines.Max(s => s.Length) : 0;
            foreach (string scanLine in scanLines)
            {
                textWriter.WriteLine(TextUtils.Center(scanLine, maxLineLength));
            }            

            return textWriter;
        }

        /// <summary>
        /// Computes the total number of scanlines in the ASCII-art output.
        /// </summary>
        /// <param name="shapeParameters">Shape parameters</param>
        /// <returns>total number of scanlines in ASCII-art output.</returns>
        private int GetScanLineCount(ShapeParameters shapeParameters)
        {
            // total height should respect the label position.
            int lineCount = Math.Max(shapeParameters.Height, shapeParameters.LabelRow);
            lineCount = Math.Max(0, lineCount);
            return lineCount;
        }

        /// <summary>
        /// Returns a raster scanline for a single row of 'pixels' in the output.
        /// This scanline should not contain the label, which is inserted by the calling process.
        /// </summary>
        /// <param name="line"></param>
        /// <returns>raster scanline for a single row of 'pixels' in the output</returns>
        protected virtual string GetScanLine(int line, ShapeParameters shapeParameters)
        {
            string scanLine = string.Empty;

            // collect pixels with boundaries of shape.
            if (line >= 0 && line < shapeParameters.Height) {
                scanLine = GetShapePixels(line, shapeParameters);
            }
   
            // Incorporate label into output.
            if (((shapeParameters.LabelRow - 1) == line) && !string.IsNullOrEmpty(shapeParameters.Label)) {
                scanLine = TextUtils.Overlay(scanLine, shapeParameters.Label);
            }
         
            return scanLine;
        }

        protected abstract string GetShapePixels(int line, ShapeParameters shapeParameters);
    
        protected string PixelRun(int runLength) {
            string value = "X";
            if( runLength > 1 ) {
                value = value + string.Concat(Enumerable.Repeat(" X", runLength - 1));
            }

            return value;
        }
    }
}