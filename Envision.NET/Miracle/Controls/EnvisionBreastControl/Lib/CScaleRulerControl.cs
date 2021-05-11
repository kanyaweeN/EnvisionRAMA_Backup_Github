///
/// PJ. Miracle (Ton) 4/12/2010
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EnvisionBreastControl.Lib.Cores.Enumulator;
using EnvisionBreastControl.Lib.Cores.Helper;

namespace EnvisionBreastControl.Lib
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFControlLib"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFControlLib;assembly=WPFControlLib"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CRuler/>
    ///
    /// </summary>
    /// 
    [TemplatePart(Name = CScaleRulerControl.ELE_RULER_AXIS, Type = typeof(Line))]
    [TemplatePart(Name = CScaleRulerControl.ELE_RULER_SCALE_START, Type = typeof(Line))]
    [TemplatePart(Name = CScaleRulerControl.ELE_RULER_SCALE_END, Type = typeof(Line))]
    [TemplatePart(Name = CScaleRulerControl.ELE_RULER_TEXT, Type = typeof(TextBlock))]
    public class CScaleRulerControl : Control
    {
        /// <summary>
        /// STRUCT LINE LOCATION VARIABLE
        /// </summary>
        public struct LineLocation
        {
            public double AXIS_X1 { get; set; }
            public double AXIS_Y1 { get; set; }
            public double AXIS_X2 { get; set; }
            public double AXIS_Y2 { get; set; }
            public double SCALE_X1 { get; set; }
            public double SCALE_Y1 { get; set; }
            public double SCALE_X2 { get; set; }
            public double SCALE_Y2 { get; set; }
            public double SCALE_W { get; set; }
            public double SCALE_H { get; set; }
            public double SCALE_OFFSET_Y { get; set; }
            public double SCALE_OFFSET_X { get; set; }
            public string TEXT { get; set; }
            public double TEXT_X { get; set; }
            public double TEXT_Y { get; set; }
            
        }
        private const string ELE_RULER_AXIS = "L_AXIS";
        private const string ELE_RULER_SCALE_START = "L_SCALE_START";
        private const string ELE_RULER_SCALE_END = "L_SCALE_END";
        private const string ELE_RULER_TEXT = "TXT_DIAMETER";
        private const TextAlignment DEFAULT_TEXT_ALIGNMENT = TextAlignment.Center;
        private const double DEFAULT_RULER_WIDTH = 20.0;
        private const double DEFAULT_LINE_THICKNESS = 3.0;
        private const double DEFAULT_LINE_SCALE_HIGHT = 8.0;
        private const double DEFAULT_LINE_TEXT_WIDTH = 15.0;
        private const double DEFAULT_OFFSET_TEXT_LOCATION = 2.0;
        private const TextOnFloatLocation DEFAULT_TEXT_ON_FLOAT_LOCATION = TextOnFloatLocation.Top;
        private const Visibility DEFAULT_SHOW_SCALE_TEXT = Visibility.Visible;
        private static readonly Thickness DEFAULT_LINE_ORIGIN = new Thickness() { Left = 0, Top = 0 };
        private static readonly LineLocation DEFAULT_LINE_LOCATION =
            new LineLocation()
            {
                AXIS_X1 = DEFAULT_LINE_ORIGIN.Left,
                AXIS_X2 = DEFAULT_RULER_WIDTH - DEFAULT_LINE_THICKNESS,
                AXIS_Y1 = DEFAULT_LINE_ORIGIN.Top,
                AXIS_Y2 = DEFAULT_LINE_ORIGIN.Top,
                SCALE_X1 = DEFAULT_LINE_ORIGIN.Left,
                SCALE_Y1 = DEFAULT_LINE_ORIGIN.Top,
                SCALE_X2 = DEFAULT_LINE_ORIGIN.Left,
                SCALE_Y2 = DEFAULT_LINE_ORIGIN.Top + (DEFAULT_LINE_SCALE_HIGHT),
                TEXT = DEFAULT_RULER_WIDTH.ToString(),
                TEXT_X = 0,
                TEXT_Y = DEFAULT_LINE_ORIGIN.Top + (DEFAULT_LINE_SCALE_HIGHT / 2),
                SCALE_H = DEFAULT_LINE_SCALE_HIGHT,
                SCALE_OFFSET_Y = -(DEFAULT_LINE_ORIGIN.Top - ((DEFAULT_LINE_SCALE_HIGHT - 1) / 2)),
                SCALE_W = DEFAULT_LINE_ORIGIN.Left + (DEFAULT_LINE_THICKNESS - 2),
                SCALE_OFFSET_X = DEFAULT_LINE_ORIGIN.Left + DEFAULT_RULER_WIDTH - DEFAULT_LINE_THICKNESS
            };

        TextBlock txtDiameter;

        private static readonly DependencyProperty DiameterTextProperty
            = DependencyProperty.Register("DiameterText", typeof(string), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(CScaleRulerControl.DEFAULT_RULER_WIDTH.ToString(), new PropertyChangedCallback(CScaleRulerControl.OnDiameterTextChanged)
            , new CoerceValueCallback(CoerceDiameterText)));

        private static void OnDiameterTextChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args) { }
        private static object CoerceDiameterText(DependencyObject dependencyObj, object obj)
        {
            CScaleRulerControl cs = (CScaleRulerControl)dependencyObj;
            string dm = cs.LineWidth.ToString();
            if (cs.Unit == Units.Cm)
                dm = DipHelper.DipToCm(cs.LineWidth).ToString("0.00");
            else if (cs.Unit == Units.Inch)
                dm = DipHelper.DipToInch(cs.LineWidth).ToString("0.00");
            else if (cs.Unit == Units.Mm)
                dm = DipHelper.DipToMm(cs.LineWidth).ToString("0.0");
            return dm;
        }

        private string DiameterText
        {
            get { return (string)this.GetValue(DiameterTextProperty); }
            set { this.SetValue(DiameterTextProperty, value); }
        }

        public static readonly DependencyProperty LineWidthProperty
            = DependencyProperty.Register("LineWidth", typeof(double), typeof(CScaleRulerControl)
            , new FrameworkPropertyMetadata(CScaleRulerControl.DEFAULT_RULER_WIDTH,
               new PropertyChangedCallback(CScaleRulerControl.OnLineWidthChanged), 
               new CoerceValueCallback(CScaleRulerControl.CoerceLineWidth)));

        public double LineWidth
        {
            get { return (double)this.GetValue(LineWidthProperty); }
            set { this.SetValue(LineWidthProperty, value); }
        }

        public static void OnLineWidthChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            CScaleRulerControl cr = (CScaleRulerControl)dependencyObject;
            cr.CoerceValue(DiameterTextProperty);
            cr.CoerceValue(LineLocationProperty);
            cr.CoerceValue(ShowScaleTextProperty);
        }

        private void CalculateDiameterText(Units uOld, Units uNew)
        {
            if (uOld == Units.Cm && uNew == Units.Pixel)
                this.DiameterText = ((int)(DipHelper.CmToDip(Convert.ToDouble(this.DiameterText)))).ToString();
            else if (uOld == Units.Pixel && uNew == Units.Cm)
                this.DiameterText = DipHelper.CmToDip(Convert.ToDouble(this.DiameterText)).ToString("0.00");
        }

        public static object CoerceLineWidth(DependencyObject dependencyObject, object obj)
        {
            return obj;
        }


        private object CalculateLocation()
        {
            double offset = (this.FontSize / 2);
            double diameter = this.LineWidth;
            if (this.LineWidth <= this.LineTextWidth)
            {
                if(this.LineTextOnFloatAlignment == TextOnFloatLocation.Top)
                    offset = CScaleRulerControl.DEFAULT_OFFSET_TEXT_LOCATION + this.FontSize;
                else
                    offset = -(CScaleRulerControl.DEFAULT_OFFSET_TEXT_LOCATION) + 1;
            }
            return new LineLocation()
            {
                AXIS_X1 = this.LineOrigin.Left,
                AXIS_X2 = this.LineWidth - this.LineThickness,
                AXIS_Y1 = this.LineOrigin.Top,
                AXIS_Y2 = this.LineOrigin.Top,
                SCALE_X1 = this.LineOrigin.Left,
                SCALE_Y1 = this.LineOrigin.Top,
                SCALE_X2 = this.LineOrigin.Left,
                SCALE_Y2 = this.LineOrigin.Top + (this.LineScaleHight),
                TEXT = DiameterText,
                TEXT_X = this.LineOrigin.Left + ((this.LineWidth - this.LineTextWidth - this.LineThickness) / 2),
                TEXT_Y = this.LineOrigin.Top - offset,
                SCALE_H = this.LineOrigin.Top + this.LineScaleHight,
                SCALE_W = this.LineOrigin.Left + (this.LineThickness - 2),
                SCALE_OFFSET_Y = -(this.LineOrigin.Top + (this.LineScaleHight /2)),
                SCALE_OFFSET_X = this.LineOrigin.Left + this.LineWidth - this.LineThickness
            };
        }

        public static readonly DependencyProperty LineThicknessProperty
            = DependencyProperty.Register("LineThickness", typeof(double), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(CScaleRulerControl.DEFAULT_LINE_THICKNESS, FrameworkPropertyMetadataOptions.AffectsMeasure));
        
        public double LineThickness
        {
            get { return (double)this.GetValue(LineThicknessProperty); }
            set { this.SetValue(LineThicknessProperty, value); }
        }

        public static readonly DependencyProperty LineLocationProperty
            = DependencyProperty.Register("LineLocation", typeof(LineLocation), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(CScaleRulerControl.DEFAULT_LINE_LOCATION
                , new PropertyChangedCallback(CScaleRulerControl.OnLineWidthChanged)
                , new CoerceValueCallback(CScaleRulerControl.CoerceLineLocation)));

        public static object CoerceLineLocation(DependencyObject dependencyObj, object obj)
        {
            CScaleRulerControl cr = (CScaleRulerControl)dependencyObj;
            return cr.CalculateLocation();
        }

        public static readonly DependencyProperty LineColorProperty
            = DependencyProperty.Register("LineColor", typeof(Brush), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        public Brush LineColor
        {
            get { return (Brush)this.GetValue(LineColorProperty); }
            set { this.SetValue(LineColorProperty, value); }
        }

        public static readonly DependencyProperty LineScaleHightProperty
            = DependencyProperty.Register("LineScaleHight", typeof(double), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(CScaleRulerControl.DEFAULT_LINE_SCALE_HIGHT,new PropertyChangedCallback(CScaleRulerControl.OnLineWidthChanged)
                , new CoerceValueCallback(CScaleRulerControl.CoerceLineScaleHight)));

        public static object CoerceLineScaleHight(DependencyObject dependencyObj, object obj)
        {
            return obj;
        }

        public double LineScaleHight
        {
            get { return (double)this.GetValue(LineScaleHightProperty); }
            set { this.SetValue(LineScaleHightProperty, value); }
        }

        public static readonly DependencyProperty LineOriginProperty
            = DependencyProperty.Register("LineOrigin", typeof(Thickness), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(CScaleRulerControl.DEFAULT_LINE_ORIGIN, 
                new PropertyChangedCallback(CScaleRulerControl.OnLineWidthChanged),
                new CoerceValueCallback(CScaleRulerControl.CoerceLineOrigin)));

        public static object CoerceLineOrigin(DependencyObject dependencyObj, object obj)
        {
            return obj;
        }

        public Thickness LineOrigin
        {
            get { return (Thickness)this.GetValue(LineOriginProperty); }
            set { this.SetValue(LineOriginProperty, value); }
        }

        public static readonly DependencyProperty LineTextWidthProperty
            = DependencyProperty.Register("LineTextWidth", typeof(double), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(CScaleRulerControl.DEFAULT_LINE_TEXT_WIDTH,
                new PropertyChangedCallback(CScaleRulerControl.OnLineWidthChanged), 
                new CoerceValueCallback(CScaleRulerControl.CoerceLineTextWidth)));

        public static object CoerceLineTextWidth(DependencyObject dependencyObj, object obj)
        {
            return obj;
        }

        public double LineTextWidth
        {
            get { return (double)this.GetValue(LineTextWidthProperty); }
            set { this.SetValue(LineTextWidthProperty, value); }
        }

        public static readonly DependencyProperty LineTextAlignmentProperty
            = DependencyProperty.Register("LineTextAlignment", typeof(TextAlignment), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(CScaleRulerControl.DEFAULT_TEXT_ALIGNMENT, FrameworkPropertyMetadataOptions.AffectsRender));

        public TextAlignment LineTextAlignment
        {
            get { return (TextAlignment)this.GetValue(LineTextAlignmentProperty); }
            set { this.SetValue(LineTextAlignmentProperty, value); }
        }

        public static readonly DependencyProperty ShowScaleTextProperty
            = DependencyProperty.Register("ShowScaleText", typeof(Visibility), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(CScaleRulerControl.DEFAULT_SHOW_SCALE_TEXT
                , new PropertyChangedCallback(CScaleRulerControl.OnShowScaleTextChanged)
                , new CoerceValueCallback(CScaleRulerControl.CoerceShowScaleText)));

        public static void OnShowScaleTextChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            
        }

        public static object CoerceShowScaleText(DependencyObject dependencyObj, object obj)
        {
            return obj;
        }

        public static readonly DependencyProperty LineTextBackgroundProperty
            = DependencyProperty.Register("LineTextBackground", typeof(Brush), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(Brushes.White, FrameworkPropertyMetadataOptions.AffectsRender));

        public Brush LineTextBackground
        {
            get { return (Brush)this.GetValue(LineTextBackgroundProperty); }
            set { this.SetValue(LineTextBackgroundProperty, value); }
        }

        public static readonly DependencyProperty LineTextOnFloatAlignmentProperty
            = DependencyProperty.Register("LineTextOnFloatAlignment", typeof(TextOnFloatLocation), typeof(CScaleRulerControl),
            new FrameworkPropertyMetadata(CScaleRulerControl.DEFAULT_TEXT_ON_FLOAT_LOCATION, new PropertyChangedCallback(CScaleRulerControl.OnTextOnFloatChanged)));

        public TextOnFloatLocation LineTextOnFloatAlignment
        {
            get { return (TextOnFloatLocation)this.GetValue(LineTextOnFloatAlignmentProperty); }
            set { this.SetValue(LineTextOnFloatAlignmentProperty, value); }
        }

        public static void OnTextOnFloatChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            CScaleRulerControl cs = (CScaleRulerControl)dependencyObj;
            cs.CoerceValue(LineLocationProperty);
        }

        public static readonly DependencyProperty UnitProperty
            = DependencyProperty.Register("Unit", typeof(Units), typeof(CScaleRulerControl)
            , new FrameworkPropertyMetadata(Units.Cm, new PropertyChangedCallback(CScaleRulerControl.OnLineWidthChanged)));

        public Units Unit
        {
            get { return (Units)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }
        
        static CScaleRulerControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CScaleRulerControl), new FrameworkPropertyMetadata(typeof(CScaleRulerControl)));
        }

        public override void OnApplyTemplate()
        {
            txtDiameter = this.GetTemplateChild(CScaleRulerControl.ELE_RULER_TEXT) as TextBlock;
            
            base.OnApplyTemplate();
        }
    }
}
