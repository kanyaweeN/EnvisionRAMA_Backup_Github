using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace EnvisionBreastControl
{
    public class ShapeProperties
    {
        //private double _shapeDimension = 20.0;
        ///// <summary>
        ///// Get or set shape dimension
        ///// </summary>
        //public double ShapeDimension
        //{
        //    get { return _shapeDimension; }
        //    set { _shapeDimension = value; }
        //}
        ///// <summary>
        ///// Get or set shape thickness
        ///// </summary>
        //private double _shapeThickness = 1.0;
        //public double ShapeThickness
        //{
        //    get { return _shapeThickness; }
        //    set { _shapeThickness = value; }
        //}
        //private Brush _shapeFillColor = Brushes.PaleGreen;
        ///// <summary>
        ///// Get or set Shape fill color
        ///// </summary>
        //public Brush ShapeFillColor
        //{
        //    get { return _shapeFillColor; }
        //    set { _shapeFillColor = value; }
        //}
        //private Brush _shapeStrockColor = Brushes.Gray;
        ///// <summary>
        ///// Get or set shape stroke color
        ///// </summary>
        //public Brush ShapeStrokeColor
        //{
        //    get { return _shapeStrockColor; }
        //    set { _shapeStrockColor = value; }
        //}
        private Brush _shapeSelectedBoundingColor = Brushes.Gray;

        /// <summary>
        /// Get or Set Shape Selected Bounding Color
        /// </summary>
        public Brush ShapeSelectedBoundingColor
        {
            get { return _shapeSelectedBoundingColor; }
            set { _shapeSelectedBoundingColor = value; }
        }

        //private ShapeStyles _style = ShapeStyles.Fill;
        ///// <summary>
        ///// Get or Set Shape Style
        ///// </summary>
        //public ShapeStyles Style
        //{
        //    get { return _style; }
        //    set { _style = value; }
        //}

        private double _ovalWidth = 20 * 0.6;
        /// <summary>
        /// Get or Set Oval Width
        /// </summary>
        public double OvalWidth
        {
            get { return _ovalWidth; }
            set { _ovalWidth = value; }
        }
        private Brush _backgroundColor = Brushes.Black;
        /// <summary>
        /// Get or set background color
        /// </summary>
        public Brush BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        private Brush _borderColor = Brushes.SteelBlue;
        /// <summary>
        /// Get or set border color
        /// </summary>
        public Brush BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        private Brush _strokeColor = Brushes.Black;
        /// <summary>
        /// Get or set Stroke color
        /// </summary>
        public Brush StrokeColor
        {
            get { return _strokeColor; }
            set { _strokeColor = value; }
        }

        private int _diameter = 20;
        /// <summary>
        /// Get or set diameter
        /// </summary>
        public int Diameter
        {
            get { return _diameter; }
            set { _diameter = value; }
        }

        private int _borderThickness = 1;
        /// <summary>
        /// Get or set border thickness
        /// </summary>
        public int BorderThickness
        {
            get { return _borderThickness; }
            set { _borderThickness = value; }
        }

        private ShapeStyles _Style = ShapeStyles.Fill;
        /// <summary>
        /// Get or set shape style
        /// </summary>
        public ShapeStyles Style
        {
            get { return _Style; }
            set { _Style = value; }
        }

        private bool _showBorder = true;
        /// <summary>
        /// Get or set show border
        /// </summary>
        public bool ShowBorder
        {
            get { return _showBorder; }
            set { _showBorder = value; }
        }

        private bool _isFixSize = false;
        /// <summary>
        /// Get or set is fix size
        /// </summary>
        public bool IsFixSize
        {
            get { return _isFixSize; }
            set { _isFixSize = value; }
        }

        private string _fontFamily = "Arial";
        /// <summary>
        /// Get or set font family
        /// </summary>
        public string FontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }

        private int _fontSize = 9;
        /// <summary>
        /// Get or set font size
        /// </summary>
        public int FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        private EnvisionBreastControl.Lib.Cores.Enumulator.Units _unit = EnvisionBreastControl.Lib.Cores.Enumulator.Units.Pixel;
        /// <summary>
        /// Get or set Unit format
        /// </summary>
        public EnvisionBreastControl.Lib.Cores.Enumulator.Units Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private Brush _fontColor = Brushes.Black;
        /// <summary>
        /// Get or set Font Color
        /// </summary>
        public Brush FontColor
        {
            get { return _fontColor; }
            set { _fontColor = value; }
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
        public ShapeProperties() { }
    }
}
