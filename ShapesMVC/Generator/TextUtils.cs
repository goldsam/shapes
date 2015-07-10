using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShapesMVC.Generator
{
    /// <summary>
    /// Utiliity class defining static methods for manpulating text.
    /// </summary>
    public class TextUtils
    {
        public static string Overlay(string background, string overlay)
        {
            int visibleBackgroundCharCount = background.Length - overlay.Length;
            if (visibleBackgroundCharCount >= 0)
            {
                // The overlay text is shorter (or the same length) as the background.
                // Center the overlay text on top of the background text.
                int offset = (visibleBackgroundCharCount) / 2;
                return background.Substring(0, offset)
                    + overlay + background.Substring(offset + overlay.Length);
            }
            else
            {
                // The overlay text is longer than the background text and thus 
                // comletely obscures it - just use the overlay text.
                return overlay;
            }
        }

        /// <summary>
        /// Creates a string of a given width with its content centered.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static string Center( string text, int width ) 
        {
            int whiteSpace = width - text.Length;
            if (whiteSpace > 0)
            {
                int leadingSpace = whiteSpace / 2;
                int trailingSpace = whiteSpace - leadingSpace;
                return Spaces(leadingSpace) + text + Spaces(trailingSpace);
            }
            else
            {
                int offset = whiteSpace / -2;
                return text.Substring(offset, width);
            }
        }

        /// <summary>
        /// Helper method to create a string of N space characters.
        /// </summary>
        /// <param name="n">Number of space characters</param>
        /// <returns>string of N space characters</returns>
        public static string Spaces(int n)
        {
            return new String(' ', n);
        }
    }
}