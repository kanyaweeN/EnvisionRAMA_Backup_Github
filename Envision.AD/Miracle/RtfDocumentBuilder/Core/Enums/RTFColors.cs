using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.RtfDocumentBuilder.Core
{
    /// <summary>
    /// Definedation for Font color and back ground color
    /// </summary>
    public struct RTFColorsDef
    {
        public const string Black = @"\red0\green0\blue0";
        public const string Maroon = @"\red128\green0\blue0";
        public const string Green = @"\red0\green128\blue0";
        public const string Olive = @"\red128\green128\blue0";
        public const string Navy = @"\red0\green0\blue128";
        public const string Purple = @"\red128\green0\blue128";
        public const string Teal = @"\red0\green128\blue128";
        public const string Gray = @"\red128\green128\blue128";
        public const string Silver = @"\red192\green192\blue192";
        public const string Red = @"\red255\green0\blue0";
        public const string Lime = @"\red0\green255\blue0";
        public const string Yellow = @"\red255\green255\blue0";
        public const string Blue = @"\red0\green0\blue255";
        public const string Fuchsia = @"\red255\green0\blue255";
        public const string Aqua = @"\red0\green255\blue255";
        public const string White = @"\red255\green255\blue255";
    }

    /// <summary>
    /// Hightlight color is cover text on that paragraph. it like pen hightlight
    /// the color should be master color like yellow, red, blue and green in know color name
    /// default should be none.
    /// </summary>
    public enum RtfColor
    {
        None, Black, Maroon, Green, Olive, Navy, Purple, Teal, Gray, Silver,
        Red, Lime, Yellow, Blue, Fuchsia, Aqua, White
    }
}
