using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Common
{
    public class CProperties
    {
        private Brush backgroundColor = Brushes.Black;
        /// <summary>
        /// Get or set background color
        /// </summary>
        public Brush BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        private Brush borderColor = Brushes.SteelBlue;
        /// <summary>
        /// Get or set border color
        /// </summary>
        public Brush BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        private Brush strokeColor = Brushes.Black;
        /// <summary>
        /// Get or set Stroke color
        /// </summary>
        public Brush StrokeColor
        {
            get { return strokeColor; }
            set { strokeColor = value; }
        }

        private int diameter = 20;
        /// <summary>
        /// Get or set diameter
        /// </summary>
        public int Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }

        private int borderThickness = 1;
        /// <summary>
        /// Get or set border thickness
        /// </summary>
        public int BorderThickness
        {
            get { return borderThickness; }
            set { borderThickness = value; }
        }

        private CStyles style = CStyles.Fill;
        /// <summary>
        /// Get or set shape style
        /// </summary>
        public CStyles Style
        {
            get { return style; }
            set { style = value; }
        }

        private bool showBorder = true;
        /// <summary>
        /// Get or set show border
        /// </summary>
        public bool ShowBorder
        {
            get { return showBorder; }
            set { showBorder = value; }
        }

        private bool isFixSize = false;
        /// <summary>
        /// Get or set is fix size
        /// </summary>
        public bool IsFixSize
        {
            get { return isFixSize; }
            set { isFixSize = value; }
        }

        private string fontFamily = "Arial";
        /// <summary>
        /// Get or set font family
        /// </summary>
        public string FontFamily
        {
            get { return fontFamily; }
            set { fontFamily = value; }
        }

        private int fontSize = 9;
        /// <summary>
        /// Get or set font size
        /// </summary>
        public int FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }

        private EnvisionBreastControl.Lib.Cores.Enumulator.Units unit = EnvisionBreastControl.Lib.Cores.Enumulator.Units.Pixel;
        /// <summary>
        /// Get or set Unit format
        /// </summary>
        public EnvisionBreastControl.Lib.Cores.Enumulator.Units Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private Brush fontColor = Brushes.Black;
        /// <summary>
        /// Get or set Font Color
        /// </summary>
        public Brush FontColor
        {
            get { return fontColor; }
            set { fontColor = value; }
        }

        private EnvisionBreastControl.Lib.CShapeControl.Shapes shape = EnvisionBreastControl.Lib.CShapeControl.Shapes.Circumscribed;
        /// <summary>
        /// Get or set Shape Marker
        /// </summary>
        public EnvisionBreastControl.Lib.CShapeControl.Shapes Shape
        {
            get { return shape; }
            set { shape = value; }
        }
    }
}
