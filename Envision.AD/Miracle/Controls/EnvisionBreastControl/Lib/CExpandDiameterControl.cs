///
/// PJ. Miracle (Ton) 4/12/2010

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
using System.Diagnostics;
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
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    /// 
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_BOUNDER, Type = typeof(Rectangle))]
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_BTN1, Type = typeof(Rectangle))]
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_BTN3, Type = typeof(Rectangle))]
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_BTN2, Type = typeof(Rectangle))]
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_BTN4, Type = typeof(Rectangle))]
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_SCALE_RULER_TOP, Type = typeof(CScaleRulerControl))]
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_SCALE_RULER_BOTTOM, Type = typeof(CScaleRulerControl))]
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_SCALE_RULER_LEFT, Type = typeof(CScaleRulerControl))]
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_SCALE_RULER_RIGHT, Type = typeof(CScaleRulerControl))]
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_CONTENT, Type = typeof(ContentControl))]
    [TemplatePart(Name = CExpandDiameterControl.ELEMENT_BOUNDER_MOUSE_OVER, Type = typeof(Rectangle))]
    public class CExpandDiameterControl : Control
    {
        public struct SnappOffSet
        {
            public double X1 { get; set; }
            public double Y1 { get; set; }
            public double X2 { get; set; }
            public double Y2 { get; set; }
            public double X3 { get; set; }
            public double Y3 { get; set; }
            public double X4 { get; set; }
            public double Y4 { get; set; }
            public double SR_TOP_X { get; set; }
            public double SR_TOP_Y { get; set; }
            public double SR_BOTTOM_X { get; set; }
            public double SR_BOTTOM_Y { get; set; }
            public double SR_LEFT_X { get; set; }
            public double SR_LEFT_Y { get; set; }
            public double SR_RIGHT_X { get; set; }
            public double SR_RIGHT_Y { get; set; }

            public override string ToString()
            {
                return  "B1:(" + X1 + "," + Y1 + ") B2:(" + X2 + "," + Y2 + ") B3:(" + X3 + "," + Y3 + ") B4:(" + X4 + "," + Y4 + ")";
            }
        }
        private const string ELEMENT_BOUNDER = "bounder";
        private const string ELEMENT_BOUNDER_MOUSE_OVER = "MouseOverBounder";
        private const string ELEMENT_CONTENT = "Content";
        private const string ELEMENT_BTN1 = "btn1"; //Top left
        private const string ELEMENT_BTN3 = "btn3"; //Bottom left
        private const string ELEMENT_BTN2 = "btn2"; //Top right
        private const string ELEMENT_BTN4 = "btn4"; //Button right
        private const string ELEMENT_SCALE_RULER_TOP = "CS_TOP"; //scale ruler top
        private const string ELEMENT_SCALE_RULER_LEFT = "CS_LEFT"; //scale ruler left
        private const string ELEMENT_SCALE_RULER_RIGHT = "CS_RIGHT"; //scale ruler right
        private const string ELEMENT_SCALE_RULER_BOTTOM = "CS_BOTTOM"; //scale ruler bottom
        private const Visibility DEFAULT_VISIBLE_SCALE_RULER_TOP = Visibility.Collapsed;
        private const Visibility DEFAULT_VISIBLE_SCALE_RULER_LEFT = Visibility.Collapsed;
        private const Visibility DEFAULT_VISIBLE_SCALE_RULER_RIGHT = Visibility.Collapsed;
        private const Visibility DEFAULT_VISIBLE_SCALE_RULER_BOTTOM = Visibility.Collapsed;
        private const Visibility DEFAULT_CAN_EXPAND = Visibility.Visible;
        private const Visibility DEFAULT_SHOW_BOUNDER = Visibility.Visible;
        private const double DEFAULT_RULER_OFFSET = 12.0; //default ruler offset
        private const double DEFAULT_CONTENT_OFFSET = 1.0; //default content offset
        private const double DEFAULT_BOUNDER_DIAMETER = 52;
        private static readonly double MIN_DIAMETER = 1.0; //Miniminm diameter
        private static readonly double MAX_DIAMETER = 200.0; //Maximinm diameter
        private static readonly double DEFAULT_DIAMITER = 50.0; //Default diameter
        private static readonly double DEFAULT_THICKNESS = 1.0; //Default Thickness
        private bool isclick = false;
        private Point _lastPoint = new Point();

        // 1-----2
        // |     |
        // |     |
        // 3-----4
        private string[][] snapper_relation = { 
                                                    new string[]{"3", "2"},
                                                    new string[]{"4", "1"},
                                                    new string[]{"1", "4"},
                                                    new string[]{"2", "3"},
                                              };
        Rectangle s1;
        Rectangle s2;
        Rectangle s3;
        Rectangle s4;
        Rectangle selectedRectangle;
        ContentPresenter content;
        CScaleRulerControl srTop;
        CScaleRulerControl srLeft;
        CScaleRulerControl srBottom;
        CScaleRulerControl srRight;
        bool isIncreased;
        bool isMaxminChanged;

        #region Ctrc
        static CExpandDiameterControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CExpandDiameterControl), new FrameworkPropertyMetadata(typeof(CExpandDiameterControl)));
        }
        #endregion

        #region Dependency Properties

        #region Diameter

        public static readonly RoutedEvent DiameterChangedEvent
            = EventManager.RegisterRoutedEvent("DiameterChanged", 
            RoutingStrategy.Bubble, 
            typeof(RoutedPropertyChangedEventHandler<double>), 
            typeof(CExpandDiameterControl));

        public event RoutedPropertyChangedEventHandler<double> DiameterChanged
        {
            add { base.AddHandler(DiameterChangedEvent, value); }
            remove { base.RemoveHandler(DiameterChangedEvent, value); }
        }

        public static readonly DependencyProperty DiameterProperty
            = DependencyProperty.Register(
            "Diameter", typeof(double), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(CExpandDiameterControl.DEFAULT_DIAMITER, 
                new PropertyChangedCallback(CExpandDiameterControl.OnDiameterChanged), 
                new CoerceValueCallback(CExpandDiameterControl.CoerceDiameterChanged)));

        public virtual void OnDiameterChanged(double oldValue, double newValue)
        {
            RoutedPropertyChangedEventArgs<double> e = new RoutedPropertyChangedEventArgs<double>(oldValue, newValue);
            e.RoutedEvent = DiameterChangedEvent;
            base.RaiseEvent(e);
        }

        public static void OnDiameterChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            CExpandDiameterControl cr = (CExpandDiameterControl)dependencyObject as CExpandDiameterControl;
            cr.OnDiameterChanged((double)args.OldValue, (double)args.NewValue);
            cr.CoerceValue(BounderDiameterProperty);
            cr.CoerceValue(OffsetProperty);
            cr.CoerceValue(CenterProperty);
        }

        public static object CoerceDiameterChanged(DependencyObject dependencyObject, object obj)
        {
            CExpandDiameterControl cexp = (CExpandDiameterControl)dependencyObject;
            if ((double)obj <= cexp.Minimun)
            {
                return CalculateRawDiameter(cexp, Convert.ToDouble(cexp.Minimun));
            }
            else if ((double)obj >= cexp.Maximun)
            {
                return CalculateRawDiameter(cexp, Convert.ToDouble(cexp.Maximun));
            }
            return CalculateRawDiameter(cexp, Convert.ToDouble(obj));
        }

        private static double CalculateRawDiameter(CExpandDiameterControl cexp, double diameter)
        {
            if (cexp.Unit == Units.Pixel)
                return diameter;
            else if (cexp.Unit == Units.Mm)
                return DipHelper.MmToDip(diameter);
            else if (cexp.Unit == Units.Cm)
                return DipHelper.CmToDip(diameter);
            else
                return DipHelper.InchToDip(diameter);
        }

        public double Diameter
        {
            get { return (double)this.GetValue(DiameterProperty); }
            set 
            { 
                this.SetValue(DiameterProperty, value);
            }
        }

        #endregion

        #region OffSet
        public static readonly DependencyProperty OffsetProperty
            = DependencyProperty.Register(
            "Offset", typeof(SnappOffSet), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(
                new SnappOffSet() {
                    X1 = 0 - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                    Y1 = 0 - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                    X2 = CExpandDiameterControl.DEFAULT_DIAMITER + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2) + CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                    Y2 = 0 - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                    X3 = 0 - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                    Y3 = CExpandDiameterControl.DEFAULT_DIAMITER + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2) + CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                    X4 = CExpandDiameterControl.DEFAULT_DIAMITER + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2) + CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                    Y4 = CExpandDiameterControl.DEFAULT_DIAMITER + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2) + CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                    SR_TOP_X = 5,
                    SR_TOP_Y = - CExpandDiameterControl.DEFAULT_RULER_OFFSET,
                    SR_BOTTOM_X = 5,
                    SR_BOTTOM_Y = CExpandDiameterControl.DEFAULT_DIAMITER + 8 + CExpandDiameterControl.DEFAULT_RULER_OFFSET,
                    SR_LEFT_X = - CExpandDiameterControl.DEFAULT_RULER_OFFSET,
                    SR_LEFT_Y = CExpandDiameterControl.DEFAULT_DIAMITER + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2),
                    SR_RIGHT_X = CExpandDiameterControl.DEFAULT_DIAMITER + 10 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2) + CExpandDiameterControl.DEFAULT_RULER_OFFSET,
                    SR_RIGHT_Y = 5
                }, new PropertyChangedCallback(CExpandDiameterControl.OnOffsetChanged), new CoerceValueCallback(CExpandDiameterControl.CoerceOffsetChanged)));

        public static void OnOffsetChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            CExpandDiameterControl rec = (CExpandDiameterControl)dependencyObject;
            rec.DumpOffSet((SnappOffSet)args.NewValue, rec.Diameter);
        }

        public static object CoerceOffsetChanged(DependencyObject dependencyObject, Object obj)
        {
            CExpandDiameterControl cr = (CExpandDiameterControl)dependencyObject;
            return cr.CalculateOffset(cr.selectedRectangle);
        }

        public SnappOffSet Offset
        {
            get { return (SnappOffSet)this.GetValue(OffsetProperty); }
            set { this.SetValue(OffsetProperty, value); }
        }
        #endregion

        #region stroke Thickness
        public static readonly DependencyProperty StrokeThicknessProperty
            = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(CExpandDiameterControl.DEFAULT_THICKNESS, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double StrokeThickness
        {
            get { return (double)this.GetValue(StrokeThicknessProperty); }
            set { this.SetValue(StrokeThicknessProperty, value); }
        }
        #endregion

        #region Origin
        public static readonly DependencyProperty OriginProperty
            = DependencyProperty.Register(
            "Origin", typeof(Point), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(new Point(0,0), 
                FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Point Origin
        {
            get { return (Point)this.GetValue(OriginProperty); }
            set { this.SetValue(OriginProperty, value); }
        }
        #endregion

        #region ContentItem
        public static readonly DependencyProperty ContentItemProperty
            = DependencyProperty.Register(
            "ContentItem", typeof(object), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(CExpandDiameterControl.OnContentItemChanged), new CoerceValueCallback(CoerceContentItem)));

        public static void OnContentItemChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {

        }

        public static object CoerceContentItem(DependencyObject dependencyObj, object obj)
        {
            return obj;
        }

        public object ContentItem
        {
            get { return this.GetValue(ContentItemProperty); }
            set { this.SetValue(ContentItemProperty, value); }
        }
        #endregion

        #region ContentOffset
        public static DependencyProperty ContentOffsetProperty
            = DependencyProperty.Register("ContentOffset", typeof(double), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(CExpandDiameterControl.DEFAULT_CONTENT_OFFSET, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double ContentOffset
        {
            get { return (double)this.GetValue(ContentOffsetProperty); }
            set { this.SetValue(ContentOffsetProperty, value); }
        }
        #endregion

        #region BounderDiameter
        internal static DependencyProperty BounderDiameterProperty
            = DependencyProperty.Register("BounderDiameter", typeof(double), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(CExpandDiameterControl.DEFAULT_BOUNDER_DIAMETER,
                new PropertyChangedCallback(CExpandDiameterControl.OnBounderDiameterChanged), new CoerceValueCallback(CExpandDiameterControl.CoerceBounderDiameter)));

        internal static void OnBounderDiameterChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            //No use
        }

        internal static object CoerceBounderDiameter(DependencyObject dependencyObj, object obj)
        {
            CExpandDiameterControl cr = (CExpandDiameterControl)dependencyObj;
            return (double) cr.Diameter + (DEFAULT_CONTENT_OFFSET * 2);
        }

        internal double BounderDiameter
        {
            get { return (double)this.GetValue(BounderDiameterProperty); }
            set { this.SetValue(BounderDiameterProperty, value); }
        }
        #endregion

        #region Can Expand
        public static DependencyProperty CanExpandProperty
            = DependencyProperty.Register("CanExpand", typeof(Visibility), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(CExpandDiameterControl.DEFAULT_CAN_EXPAND, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Visibility CanExpand
        {
            get { return (Visibility)this.GetValue(CanExpandProperty); }
            set { this.SetValue(CanExpandProperty, value); }
        }
        #endregion

        #region Show Bounder
        public static DependencyProperty ShowBounderProperty
            = DependencyProperty.Register("ShowBounder", typeof(Visibility), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(CExpandDiameterControl.DEFAULT_SHOW_BOUNDER, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Visibility ShowBounder
        {
            get { return (Visibility)this.GetValue(ShowBounderProperty); }
            set { this.SetValue(ShowBounderProperty, value); }
        }
        #endregion

        #region Scale Diameter
        internal static DependencyProperty ScaleDiamaterProperty
            = DependencyProperty.RegisterAttached("ScaleDiamater", typeof(CScaleRulerControl), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        internal CScaleRulerControl ScaleDiamater
        {
            get { return (CScaleRulerControl)this.GetValue(ScaleDiamaterProperty); }
            set { this.SetValue(ScaleDiamaterProperty, value); }
        }
        #endregion

        #region SHOW SCALE RULER
        internal static readonly DependencyProperty ShowTopScaleRulerProperty
            = DependencyProperty.Register("ShowTopScaleRuler", typeof(Visibility), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(CExpandDiameterControl.DEFAULT_VISIBLE_SCALE_RULER_TOP));

        internal Visibility ShowTopScaleRuler
        {
            get { return (Visibility)this.GetValue(ShowTopScaleRulerProperty); }
            set { this.SetValue(ShowTopScaleRulerProperty, value); }
        }

        internal static readonly DependencyProperty ShowLeftScaleRulerProperty
            = DependencyProperty.Register("ShowLeftScaleRuler", typeof(Visibility), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(CExpandDiameterControl.DEFAULT_VISIBLE_SCALE_RULER_LEFT));

        internal Visibility ShowLeftScaleRuler
        {
            get { return (Visibility)this.GetValue(ShowLeftScaleRulerProperty); }
            set { this.SetValue(ShowLeftScaleRulerProperty, value); }
        }

        internal static readonly DependencyProperty ShowRightScaleRulerProperty
            = DependencyProperty.Register("ShowRightScaleRuler", typeof(Visibility), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(CExpandDiameterControl.DEFAULT_VISIBLE_SCALE_RULER_RIGHT));

        internal Visibility ShowRightScaleRuler
        {
            get { return (Visibility)this.GetValue(ShowRightScaleRulerProperty); }
            set { this.SetValue(ShowRightScaleRulerProperty, value); }
        }

        internal static readonly DependencyProperty ShowBottomScaleRulerProperty
            = DependencyProperty.Register("ShowBottomScaleRuler", typeof(Visibility), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(CExpandDiameterControl.DEFAULT_VISIBLE_SCALE_RULER_BOTTOM));

        internal Visibility ShowBottomScaleRuler
        {
            get { return (Visibility)this.GetValue(ShowBottomScaleRulerProperty); }
            set { this.SetValue(ShowBottomScaleRulerProperty, value); }
        }
        #endregion

        #region SCALE DIAMETER RULER PROPERIES
        public static readonly DependencyProperty LineScaleColorProperty
            = DependencyProperty.Register("LineScaleColor", typeof(Brush), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(Brushes.SteelBlue, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush LineScaleColor
        {
            get { return (Brush)this.GetValue(LineScaleColorProperty); }
            set { this.SetValue(LineScaleColorProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextForegroundProperty
            = DependencyProperty.Register("LineScaleTextForeground", typeof(Brush), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(Brushes.SteelBlue, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush LineScaleTextForeground
        {
            get { return (Brush)this.GetValue(LineScaleTextForegroundProperty); }
            set { this.SetValue(LineScaleTextForegroundProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextBackgroundProperty
            = DependencyProperty.Register("LineScaleTextBackground", typeof(Brush), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(Brushes.White, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush LineScaleTextBackground
        {
            get { return (Brush)this.GetValue(LineScaleTextBackgroundProperty); }
            set { this.SetValue(LineScaleTextBackgroundProperty, value); }
        }

        public static readonly DependencyProperty LineThicknessProperty
            = DependencyProperty.Register("LineThickness", typeof(double), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(3.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public double LineThickness
        {
            get { return (double)this.GetValue(LineThicknessProperty); }
            set { this.SetValue(LineThicknessProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextFontSizeProperty
            = DependencyProperty.Register("LineScaleTextFontSize", typeof(double), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(9.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public double LineScaleTextFontSize
        {
            get { return (double)this.GetValue(LineScaleTextFontSizeProperty); }
            set { this.SetValue(LineScaleTextFontSizeProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextFontFamilyProperty
            = DependencyProperty.Register("LineScaleTextFontFamily", typeof(FontFamily), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(new FontFamily("Arial"), FrameworkPropertyMetadataOptions.AffectsRender));
        public FontFamily LineScaleTextFontFamily
        {
            get { return (FontFamily)this.GetValue(LineScaleTextFontFamilyProperty); }
            set { this.SetValue(LineScaleTextFontFamilyProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextWidthProperty
            = DependencyProperty.Register("LineScaleTextWidth", typeof(double), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(26.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public double LineScaleTextWidth
        {
            get { return (double)this.GetValue(LineScaleTextWidthProperty); }
            set { this.SetValue(LineScaleTextWidthProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextAlginmentProperty
            = DependencyProperty.Register("LineScaleTextAlginment", typeof(TextAlignment), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(TextAlignment.Center, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public TextAlignment LineScaleTextAlginment
        {
            get { return (TextAlignment)this.GetValue(LineScaleTextAlginmentProperty); }
            set { this.SetValue(LineScaleTextAlginmentProperty, value); }
        }
        #endregion

        #region Unit
        public static DependencyProperty UnitProperty
            = DependencyProperty.Register("Unit", typeof(Units), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(Units.Pixel, new PropertyChangedCallback(CExpandDiameterControl.OnUnitChanged), new CoerceValueCallback(CExpandDiameterControl.CoerceUnitChanged)));

        public static void OnUnitChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            CExpandDiameterControl cexp = (CExpandDiameterControl)obj;
            cexp.CoerceValue(DiameterProperty);
            cexp.CoerceValue(BounderDiameterProperty);
            cexp.CoerceValue(OffsetProperty);
            cexp.CoerceValue(CenterProperty);
        }

        public static object CoerceUnitChanged(DependencyObject depObj, object obj)
        {
            return obj;
        }

        public Units Unit
        {
            get { return (Units)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }
        #endregion

        #region Maximun
        public static DependencyProperty MaximunProperty
            = DependencyProperty.RegisterAttached("Maximun", typeof(double), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(CExpandDiameterControl.MAX_DIAMETER, new PropertyChangedCallback(CExpandDiameterControl.OnMaximunChanged)));

        public static void SetMaximun(DependencyObject obj, double value)
        {
            obj.SetValue(MaximunProperty, value);
        }
        public static double GetMaximun(DependencyObject obj)
        {
            return (double)obj.GetValue(MaximunProperty);
        }

        public static void OnMaximunChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            UIElement elm = dependencyObj as UIElement;
            if (elm is CExpandDiameterControl)
            {
                CExpandDiameterControl ce = (CExpandDiameterControl)dependencyObj;
                ce.OnMaximunChanged((double)args.OldValue, (double)args.NewValue);
                if ((double)args.OldValue > (double)args.NewValue)
                {
                    ce.isMaxminChanged = true;
                    ce.CoerceValue(DiameterProperty);
                    ce.CoerceValue(BounderDiameterProperty);
                    ce.CoerceValue(OffsetProperty);
                    ce.isMaxminChanged = false;
                }
            }
        }
        public virtual void OnMaximunChanged(double oldValue, double newValue)
        {
            RoutedPropertyChangedEventArgs<double> e = new RoutedPropertyChangedEventArgs<double>(oldValue, newValue);
            e.RoutedEvent = MaximunChangedEvent;
            base.RaiseEvent(e);
        }

        public double Maximun
        {
            get { return (double)this.GetValue(MaximunProperty); }
            set { this.SetValue(MaximunProperty, value); }
        }

        public static RoutedEvent MaximunChangedEvent
            = EventManager.RegisterRoutedEvent("MaximunChanged", RoutingStrategy.Bubble
            , typeof(RoutedPropertyChangedEventArgs<double>), typeof(CExpandDiameterControl));

        public event RoutedPropertyChangedEventHandler<double> MaximunChanged
        {
            add { base.AddHandler(MaximunChangedEvent, value); }
            remove { base.RemoveHandler(MaximunChangedEvent, value); }
        }
        
        #endregion

        #region Minimun
        public static DependencyProperty MinimunProperty
            = DependencyProperty.Register("Minimun", typeof(double), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(CExpandDiameterControl.MIN_DIAMETER, new PropertyChangedCallback(CExpandDiameterControl.OnMinimunChanged)));

        public static void OnMinimunChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            CExpandDiameterControl ce = (CExpandDiameterControl)dependencyObj;
            ce.OnMinimunChanged((double)args.OldValue, (double)args.NewValue);
            if ((double)args.OldValue < (double)args.NewValue)
            {
                ce.isMaxminChanged = true;
                ce.CoerceValue(DiameterProperty);
                ce.CoerceValue(BounderDiameterProperty);
                ce.CoerceValue(OffsetProperty);
                ce.isMaxminChanged = false;
            }
        }
        public virtual void OnMinimunChanged(double oldValue, double newValue)
        {
            RoutedPropertyChangedEventArgs<double> e = new RoutedPropertyChangedEventArgs<double>(oldValue, newValue);
            e.RoutedEvent = MinimunChangedEvent;
            base.RaiseEvent(e);
        }

        public double Minimun
        {
            get { return (double)this.GetValue(MinimunProperty); }
            set { this.SetValue(MinimunProperty, value); }
        }

        public static RoutedEvent MinimunChangedEvent
            = EventManager.RegisterRoutedEvent("MinimunChanged", RoutingStrategy.Bubble
            , typeof(RoutedPropertyChangedEventArgs<double>), typeof(CExpandDiameterControl));

        public event RoutedPropertyChangedEventHandler<double> MinimunChanged
        {
            add { base.AddHandler(MinimunChangedEvent, value); }
            remove { base.RemoveHandler(MinimunChangedEvent, value); }
        }
        #endregion

        #region Show Mouse Over Bounder
        public static DependencyProperty ShowMouseOverBounderProperty
            = DependencyProperty.Register("ShowMouseOverBounder", typeof(Visibility), typeof(CExpandDiameterControl),
            new FrameworkPropertyMetadata(Visibility.Collapsed, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Visibility ShowMouseOverBounder
        {
            get { return (Visibility)this.GetValue(ShowMouseOverBounderProperty); }
            set { this.SetValue(ShowMouseOverBounderProperty, value); }
        }
        #endregion

        #region Bounder Mouse Over Color
        public static readonly DependencyProperty BounderMouseOverColorProperty
            = DependencyProperty.Register("BounderMouseOverColor", typeof(Brush), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(Brushes.DarkSlateBlue, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush BounderMouseOverColor
        {
            get { return (Brush)this.GetValue(BounderMouseOverColorProperty); }
            set { this.SetValue(BounderMouseOverColorProperty, value); }
        }
        #endregion

        #region BeginExpand
        public static RoutedEvent ExpandingEvent
            = EventManager.RegisterRoutedEvent("Expanding", RoutingStrategy.Bubble
            , typeof(RoutedEventArgs), typeof(CExpandDiameterControl));

        public event RoutedEventHandler Expanding
        {
            add { base.AddHandler(ExpandingEvent, value); }
            remove { base.RemoveHandler(ExpandingEvent, value); }
        }
        #endregion

        #region EndExpand
        public static RoutedEvent ExpandedEvent
            = EventManager.RegisterRoutedEvent("Expanded", RoutingStrategy.Bubble
            , typeof(RoutedEventArgs), typeof(CExpandDiameterControl));

        public event RoutedEventHandler Expanded
        {
            add { base.AddHandler(ExpandedEvent, value); }
            remove { base.RemoveHandler(ExpandedEvent, value); }
        }
        #endregion

        #region Center
        public static DependencyProperty CenterProperty
            = DependencyProperty.Register("Center", typeof(Point), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(new Point(CExpandDiameterControl.DEFAULT_DIAMITER / 2 - 4, CExpandDiameterControl.DEFAULT_DIAMITER / 2 - 4)
                , new PropertyChangedCallback(CExpandDiameterControl.OnCenterChanged), new CoerceValueCallback(CExpandDiameterControl.CoerceCenterChanged)));

        public static void OnCenterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) 
        {
            CExpandDiameterControl ce = (CExpandDiameterControl)sender;
            ce.OnCenterChanged((Point)args.OldValue, (Point)args.NewValue);
 
        }
        public virtual void OnCenterChanged(Point oldValue, Point newValue)
        {
            RoutedPropertyChangedEventArgs<Point> e = new RoutedPropertyChangedEventArgs<Point>(oldValue, newValue);
            e.RoutedEvent = CenterChangedEvent;
            base.RaiseEvent(e);
        }
        public static object CoerceCenterChanged(DependencyObject dependencyObj, object obj)
        {
            CExpandDiameterControl ce = (CExpandDiameterControl)dependencyObj;
            Point p = new Point();
            p.X = ce.Offset.X1 + ((ce.Diameter + 8) / 2);
            p.Y = ce.Offset.Y1 + ((ce.Diameter + 8) / 2);
            return p;
        }
        public Point Center
        {
            get { return (Point)this.GetValue(CenterProperty); }
            set { this.SetValue(CenterProperty, value); }
        }

        public static RoutedEvent CenterChangedEvent
            = EventManager.RegisterRoutedEvent("CenterChanged", RoutingStrategy.Bubble
            , typeof(RoutedPropertyChangedEventHandler<Point>)
            , typeof(CExpandDiameterControl));

        public event RoutedPropertyChangedEventHandler<Point> CenterChanged
        {
            add { base.AddHandler(CenterChangedEvent, value); }
            remove { base.RemoveHandler(CenterChangedEvent, value); }
        }
        #endregion

        public static DependencyProperty ReadOnlyProperty
            = DependencyProperty.Register("ReadOnly", typeof(bool), typeof(CExpandDiameterControl)
            , new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(CExpandDiameterControl.OnReadOnlyChanged)));

        public static void OnReadOnlyChanged(DependencyObject denpendencyObj, DependencyPropertyChangedEventArgs args)
        {
           
        }

        public bool ReadOnly
        {
            get { return (bool)GetValue(ReadOnlyProperty); }
            set
            {
                SetValue(ReadOnlyProperty, value);
            }
        }

        #endregion

        #region OVERRIDE METHOD
        /// <summary>
        /// APPLY TEMPLATE OVERRIDING
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            s1 = this.GetTemplateChild(CExpandDiameterControl.ELEMENT_BTN1) as Rectangle;
            if (s1 != null)
            {
                s1.MouseDown += BeginSnapEvent;
                s1.MouseUp += EndSnapEvent;
                s1.MouseMove += SnapMoveEvent;
            }
            s2 = this.GetTemplateChild(CExpandDiameterControl.ELEMENT_BTN2) as Rectangle;
            if (s2 != null)
            {
                s2.MouseDown += BeginSnapEvent;
                s2.MouseUp += EndSnapEvent;
                s2.MouseMove += SnapMoveEvent;
            }
            s3 = this.GetTemplateChild(CExpandDiameterControl.ELEMENT_BTN3) as Rectangle;
            if (s3 != null)
            {
                s3.MouseDown += BeginSnapEvent;
                s3.MouseUp += EndSnapEvent;
                s3.MouseMove += SnapMoveEvent;
            }
            s4 = this.GetTemplateChild(CExpandDiameterControl.ELEMENT_BTN4) as Rectangle;
            if (s3 != null)
            {
                s4.MouseDown += BeginSnapEvent;
                s4.MouseUp += EndSnapEvent;
                s4.MouseMove += SnapMoveEvent;
            }
            this.srTop = this.GetTemplateChild(CExpandDiameterControl.ELEMENT_SCALE_RULER_TOP) as CScaleRulerControl;
            this.srRight = this.GetTemplateChild(CExpandDiameterControl.ELEMENT_SCALE_RULER_RIGHT) as CScaleRulerControl;
            this.srLeft = this.GetTemplateChild(CExpandDiameterControl.ELEMENT_SCALE_RULER_LEFT) as CScaleRulerControl;
            this.srBottom = this.GetTemplateChild(CExpandDiameterControl.ELEMENT_SCALE_RULER_BOTTOM) as CScaleRulerControl;
            this.content = this.GetTemplateChild(CExpandDiameterControl.ELEMENT_CONTENT) as ContentPresenter;
            if (this.content != null)
            {
                this.content.MouseEnter += OnMouseOver;
                this.content.MouseLeave += OnMouseLeave;
            }
        }
        #endregion

        #region MOUSE EVENTS
        public void BeginSnapEvent(object sender, RoutedEventArgs args)
        {
            
                Rectangle rect = sender as Rectangle;
                Mouse.Capture(rect);
                this.selectedRectangle = sender as Rectangle;
                if (this.selectedRectangle != null)
                {
                    RoutedEventArgs e = new RoutedEventArgs(ExpandingEvent, sender);
                    base.RaiseEvent(e);
                }
                this.ShowScaleRuler();
                this.HightlightSnapper(this.selectedRectangle);
                if (!this.ReadOnly)
                {
                    isclick = true;
                }
        }

        public void EndSnapEvent(object sender, RoutedEventArgs args)
        {
            Mouse.Capture(null);
            this.HideScaleRuler();
            this.DeHightSnapper(this.selectedRectangle);
            if (this.selectedRectangle != null)
            {
                RoutedEventArgs e = new RoutedEventArgs(ExpandedEvent, sender);
                base.RaiseEvent(e);
                this.selectedRectangle = null; // unfocus
            }
            isclick = false;
        }

        public void SnapMoveEvent(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            if (isclick)
            {
                Point p = e.GetPosition(this);
                this.CalculateNewPosition(p, rect);
            }
        }
        public void OnMouseOver(object sender, MouseEventArgs args)
        {
            if(this.ShowBounder == Visibility.Collapsed)
                this.ShowMouseOverBounder = Visibility.Visible;
        }
        public void OnMouseLeave(object sender, MouseEventArgs args)
        {
            this.ShowMouseOverBounder = Visibility.Collapsed;
        }
        #endregion

        #region UTILITY METHOD
        /// <summary>
        /// THIS METHOD USE TO SET HIGHT COLOR FOR SELECTED BUTTON
        /// </summary>
        /// <param name="rect"></param>
        private void HightlightSnapper(Rectangle rect)
        {
            if(rect != null)
                rect.Fill = Brushes.LightBlue;
        }
        /// <summary>
        /// THIS METHOD USE TO UNSET HIGHT COLOR FOR SELECTED BUTTON
        /// </summary>
        /// <param name="rectangle"></param>
        private void DeHightSnapper(Rectangle rect)
        {
            if(rect != null)
                rect.Fill = Brushes.Transparent;
        }
        /// <summary>
        /// THIS METHOD USE TO CALCULATE SNAPPER POSITION
        /// </summary>
        /// <param name="p">BEGIN POSITION</param>
        /// <param name="sender">SNAP SENDER</param>
        private void CalculateNewPosition(Point p, Rectangle sender)
        {
            
            #region TOP LEFT
            if (sender.Name == CExpandDiameterControl.ELEMENT_BTN1)
            {
                //Update Owner 
                if (p.X < _lastPoint.X || p.Y < _lastPoint.Y)
                {
                    //Check max
                    if (this.Diameter != CExpandDiameterControl.MAX_DIAMETER)
                    {
                        this.isIncreased = true;
                        this.Diameter+=2; //Increasing
                    }
                }
                else if (p.Y > _lastPoint.Y || p.X > _lastPoint.X)
                {
                    //Check min
                    if (this.Diameter != CExpandDiameterControl.MIN_DIAMETER)
                    {
                        this.isIncreased = false;
                        this.Diameter-=2; //decreasing
                    }
                }
            }
            #endregion

            #region TOP RIGHT
            else if (sender.Name == CExpandDiameterControl.ELEMENT_BTN2)
            {
                //Update Owner 
                if (p.X > _lastPoint.X || p.Y < _lastPoint.Y)
                {
                    //Check Max
                    if (this.Diameter != CExpandDiameterControl.MAX_DIAMETER)
                    {
                        this.isIncreased = true;
                        this.Diameter+=2; //Increasing 
                    }
                }
                else if (p.Y > _lastPoint.Y || p.X < _lastPoint.X)
                {
                    //Check Min
                    if (this.Diameter != CExpandDiameterControl.MIN_DIAMETER)
                    {
                        this.isIncreased = false;
                        this.Diameter-=2; //decreasing
                    }
                }
            }
            #endregion

            #region BOTTOM LEFT
            else if (sender.Name == CExpandDiameterControl.ELEMENT_BTN3)
            {
                string[] snapper = this.snapper_relation[2];
                //Update Owner 
                if (p.X < _lastPoint.X || p.Y > _lastPoint.Y)
                {
                    //Check max
                    if (this.Diameter != CExpandDiameterControl.MAX_DIAMETER)
                    {
                        this.isIncreased = true;
                        this.Diameter+=2; //Increasing 
                    }
                }
                else if (p.Y < _lastPoint.Y || p.X > _lastPoint.X)
                {
                    //Check min
                    if (this.Diameter != CExpandDiameterControl.MIN_DIAMETER)
                    {
                        this.isIncreased = false;
                        this.Diameter-=2; //decreasing
                    }
                }
            }
            #endregion

            #region BOTTOM RIGHT
            else if (sender.Name == CExpandDiameterControl.ELEMENT_BTN4)
            {
                //Update Owner 
                if (p.X > _lastPoint.X || p.Y > _lastPoint.Y)
                {
                    //Check Max
                    if (this.Diameter != CExpandDiameterControl.MAX_DIAMETER)
                    {
                        this.isIncreased = true;
                        this.Diameter+=2; //Increasing 
                    }
                }
                else if (p.Y < _lastPoint.Y || p.X < _lastPoint.X)
                {
                    //Check min
                    if (this.Diameter != CExpandDiameterControl.MIN_DIAMETER)
                    {
                        this.isIncreased = false;
                        this.Diameter-=2; //decreasing
                    }
                }
            }
            #endregion

            this._lastPoint = p;
            //this.DumpPosition(0, 0, p, Diameter);
        }
        /// <summary>
        /// THIS METHOD USE TO CALCULATE OFFSET
        /// </summary>
        /// <param name="sender">BTN SENDER</param>
        /// <returns>OFFSET</returns>
        private object CalculateOffset(Rectangle sender)
        {
            if (sender != null)
            {
                if (sender.Name == CExpandDiameterControl.ELEMENT_BTN1)
                {
                    SnappOffSet _oldSnappOffset = this.Offset;
                    this.Origin = new Point() { X = _oldSnappOffset.X1 - this.GetDelta(), Y = _oldSnappOffset.Y1 - this.GetDelta() };
                    return new SnappOffSet()
                    {
                        X1 = _oldSnappOffset.X1 - this.GetDelta(),
                        Y1 = _oldSnappOffset.Y1 - this.GetDelta(),
                        X2 = _oldSnappOffset.X2,
                        Y2 = _oldSnappOffset.Y2 - this.GetDelta(),
                        X3 = _oldSnappOffset.X3 - this.GetDelta(),
                        Y3 = _oldSnappOffset.Y3,
                        X4 = _oldSnappOffset.X4,
                        Y4 = _oldSnappOffset.Y4,
                        SR_TOP_X = _oldSnappOffset.SR_TOP_X - this.GetDelta(),
                        SR_TOP_Y = _oldSnappOffset.SR_TOP_Y - this.GetDelta(),
                        SR_BOTTOM_X = _oldSnappOffset.SR_BOTTOM_X - this.GetDelta(),
                        SR_BOTTOM_Y = _oldSnappOffset.SR_BOTTOM_Y,
                        SR_LEFT_X = _oldSnappOffset.SR_LEFT_X - this.GetDelta(),
                        SR_LEFT_Y = _oldSnappOffset.SR_LEFT_Y,
                        SR_RIGHT_X = _oldSnappOffset.SR_RIGHT_X ,
                        SR_RIGHT_Y = _oldSnappOffset.SR_RIGHT_Y - this.GetDelta()
                    };
                }
                else if (sender.Name == CExpandDiameterControl.ELEMENT_BTN2)
                {
                    SnappOffSet _oldSnappOffset = this.Offset;
                    this.Origin = new Point() { X = _oldSnappOffset.X1, Y = _oldSnappOffset.Y1 - this.GetDelta() };
                    return new SnappOffSet()
                    {
                        X1 = _oldSnappOffset.X1,
                        Y1 = _oldSnappOffset.Y1 - this.GetDelta(),
                        X2 = _oldSnappOffset.X2 + this.GetDelta(),
                        Y2 = _oldSnappOffset.Y2 - this.GetDelta(),
                        X3 = _oldSnappOffset.X3,
                        Y3 = _oldSnappOffset.Y3,
                        X4 = _oldSnappOffset.X4 + this.GetDelta(),
                        Y4 = _oldSnappOffset.Y4,
                        SR_TOP_X = _oldSnappOffset.SR_TOP_X,
                        SR_TOP_Y = _oldSnappOffset.SR_TOP_Y - this.GetDelta(),
                        SR_BOTTOM_X = _oldSnappOffset.SR_BOTTOM_X,
                        SR_BOTTOM_Y = _oldSnappOffset.SR_BOTTOM_Y,
                        SR_LEFT_X = _oldSnappOffset.SR_LEFT_X,
                        SR_LEFT_Y = _oldSnappOffset.SR_LEFT_Y,
                        SR_RIGHT_X = _oldSnappOffset.SR_RIGHT_X + this.GetDelta(),
                        SR_RIGHT_Y = _oldSnappOffset.SR_RIGHT_Y - this.GetDelta()
                    };
                }
                else if (sender.Name == CExpandDiameterControl.ELEMENT_BTN3)
                {
                    SnappOffSet _oldSnappOffset = this.Offset;
                    this.Origin = new Point() { X = _oldSnappOffset.X1 - this.GetDelta(), Y = _oldSnappOffset.Y1 };
                    return new SnappOffSet()
                    {
                        X1 = _oldSnappOffset.X1 - this.GetDelta(),
                        Y1 = _oldSnappOffset.Y1,
                        X2 = _oldSnappOffset.X2,
                        Y2 = _oldSnappOffset.Y2,
                        X3 = _oldSnappOffset.X3 - this.GetDelta(),
                        Y3 = _oldSnappOffset.Y3 + this.GetDelta(),
                        X4 = _oldSnappOffset.X4,
                        Y4 = _oldSnappOffset.Y4 + this.GetDelta(),
                        SR_TOP_X = _oldSnappOffset.SR_TOP_X - this.GetDelta(),
                        SR_TOP_Y = _oldSnappOffset.SR_TOP_Y,
                        SR_BOTTOM_X = _oldSnappOffset.SR_BOTTOM_X - this.GetDelta(),
                        SR_BOTTOM_Y = _oldSnappOffset.SR_BOTTOM_Y + this.GetDelta(),
                        SR_LEFT_X = _oldSnappOffset.SR_LEFT_X - this.GetDelta(),
                        SR_LEFT_Y = _oldSnappOffset.SR_LEFT_Y + this.GetDelta(),
                        SR_RIGHT_X = _oldSnappOffset.SR_RIGHT_X,
                        SR_RIGHT_Y = _oldSnappOffset.SR_RIGHT_Y
                    };
                }
                else
                {
                    SnappOffSet _oldSnappOffset = this.Offset;
                    this.Origin = new Point() { X = _oldSnappOffset.X1, Y = _oldSnappOffset.Y1 };
                    return new SnappOffSet()
                    {
                        X1 = _oldSnappOffset.X1,
                        Y1 = _oldSnappOffset.Y1,
                        X2 = _oldSnappOffset.X2 + this.GetDelta(),
                        Y2 = _oldSnappOffset.Y2,
                        X3 = _oldSnappOffset.X3,
                        Y3 = _oldSnappOffset.Y3 + this.GetDelta(),
                        X4 = _oldSnappOffset.X4 + this.GetDelta(),
                        Y4 = _oldSnappOffset.Y4 + this.GetDelta(),
                        SR_TOP_X = _oldSnappOffset.SR_TOP_X,
                        SR_TOP_Y = _oldSnappOffset.SR_TOP_Y,
                        SR_BOTTOM_X = _oldSnappOffset.SR_BOTTOM_X,
                        SR_BOTTOM_Y = _oldSnappOffset.SR_BOTTOM_Y + this.GetDelta(),
                        SR_LEFT_X = _oldSnappOffset.SR_LEFT_X,
                        SR_LEFT_Y = _oldSnappOffset.SR_LEFT_Y  + this.GetDelta(),
                        SR_RIGHT_X = _oldSnappOffset.SR_RIGHT_X + this.GetDelta(),
                        SR_RIGHT_Y = _oldSnappOffset.SR_RIGHT_Y
                    };
                }
            }
            else
            {
                SnappOffSet _oldSnappOffset = this.Offset;
                this.Origin = new Point() { X = _oldSnappOffset.X1, Y = _oldSnappOffset.Y1 };
                if (isMaxminChanged)
                {
                    return new SnappOffSet()
                    {
                        X1 = _oldSnappOffset.X1,
                        Y1 = _oldSnappOffset.Y1,
                        X2 = (BounderDiameter + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2)) - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET + _oldSnappOffset.X1 + (CExpandDiameterControl.DEFAULT_THICKNESS),
                        Y2 = _oldSnappOffset.Y2,
                        X3 = _oldSnappOffset.X3,
                        Y3 = (BounderDiameter + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2)) - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET + _oldSnappOffset.Y1 + (CExpandDiameterControl.DEFAULT_THICKNESS),
                        X4 = (BounderDiameter + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2)) - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET + _oldSnappOffset.X1 + (CExpandDiameterControl.DEFAULT_THICKNESS),
                        Y4 = (BounderDiameter + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2)) - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET + _oldSnappOffset.Y1 + (CExpandDiameterControl.DEFAULT_THICKNESS),
                        SR_TOP_X = _oldSnappOffset.SR_TOP_X,
                        SR_TOP_Y = _oldSnappOffset.SR_TOP_Y,
                        SR_BOTTOM_X = _oldSnappOffset.SR_BOTTOM_X,
                        SR_BOTTOM_Y = (BounderDiameter + 8) + CExpandDiameterControl.DEFAULT_RULER_OFFSET + _oldSnappOffset.Y1,
                        SR_LEFT_X = _oldSnappOffset.SR_LEFT_X,
                        SR_LEFT_Y = (BounderDiameter + 5) - (CExpandDiameterControl.DEFAULT_THICKNESS * 2) + _oldSnappOffset.Y1,
                        SR_RIGHT_X = (BounderDiameter + 10) - (CExpandDiameterControl.DEFAULT_THICKNESS * 2) + CExpandDiameterControl.DEFAULT_RULER_OFFSET - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET + _oldSnappOffset.X1,
                        SR_RIGHT_Y = _oldSnappOffset.SR_RIGHT_Y
                    };
                }
                else
                {
                    return new SnappOffSet()
                    {
                        X1 = _oldSnappOffset.X1,
                        Y1 = _oldSnappOffset.Y1,
                        X2 = (BounderDiameter + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2)) - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                        Y2 = _oldSnappOffset.Y2,
                        X3 = _oldSnappOffset.X3,
                        Y3 = (BounderDiameter + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2)) - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                        X4 = (BounderDiameter + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2)) - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                        Y4 = (BounderDiameter + 5 - (CExpandDiameterControl.DEFAULT_THICKNESS * 2)) - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                        SR_TOP_X = _oldSnappOffset.SR_TOP_X,
                        SR_TOP_Y = _oldSnappOffset.SR_TOP_Y,
                        SR_BOTTOM_X = _oldSnappOffset.SR_BOTTOM_X,
                        SR_BOTTOM_Y = (BounderDiameter + 8) + CExpandDiameterControl.DEFAULT_RULER_OFFSET,
                        SR_LEFT_X = _oldSnappOffset.SR_LEFT_X,
                        SR_LEFT_Y = (BounderDiameter + 5) - (CExpandDiameterControl.DEFAULT_THICKNESS * 2),
                        SR_RIGHT_X = (BounderDiameter + 10) - (CExpandDiameterControl.DEFAULT_THICKNESS * 2) + CExpandDiameterControl.DEFAULT_RULER_OFFSET - CExpandDiameterControl.DEFAULT_CONTENT_OFFSET,
                        SR_RIGHT_Y = _oldSnappOffset.SR_RIGHT_Y
                    };
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private double GetDelta()
        {
            if (this.isIncreased)
                return 2;
            else
                return -2;
        }
        /// <summary>
        /// THIS METHOD USE TO SET VISIBLE SCALE RULER
        /// </summary>
        /// <param name="sender"></param>
        private void ShowScaleRuler()
        {
            if (this.selectedRectangle != null)
            {
                if (this.selectedRectangle.Name == CExpandDiameterControl.ELEMENT_BTN1)
                {
                    this.ShowTopScaleRuler = Visibility.Visible;
                    this.ShowLeftScaleRuler = Visibility.Visible;
                }
                else if (this.selectedRectangle.Name == CExpandDiameterControl.ELEMENT_BTN2)
                {
                    this.ShowTopScaleRuler = Visibility.Visible;
                    this.ShowRightScaleRuler = Visibility.Visible;
                }
                else if (this.selectedRectangle.Name == CExpandDiameterControl.ELEMENT_BTN3)
                {
                    this.ShowLeftScaleRuler = Visibility.Visible;
                    this.ShowBottomScaleRuler = Visibility.Visible;
                }
                else
                {
                    this.ShowRightScaleRuler = Visibility.Visible;
                    this.ShowBottomScaleRuler = Visibility.Visible;
                }
            }
        }
        /// <summary>
        /// THIS METHOD USE TO HIDE SCALE RULER
        /// </summary>
        private void HideScaleRuler()
        {
            this.ShowLeftScaleRuler = Visibility.Collapsed;
            this.ShowRightScaleRuler = Visibility.Collapsed;
            this.ShowTopScaleRuler = Visibility.Collapsed;
            this.ShowBottomScaleRuler = Visibility.Collapsed;
        }
        /// <summary>
        /// DUMP POSITION ONLY DEBUG
        /// </summary>
        /// <param name="ox">OLD X POSITION</param>
        /// <param name="oy">OLD Y POSITION</param>
        /// <param name="p">NEW POINT</param>
        [Conditional("DEBUG")]
        private void DumpPosition(double ox, double oy, Point p, double diameter)
        {
            Console.WriteLine(ox + "," + oy + " n: " + p.ToString() + " D: " + diameter);
        }
        [Conditional("DEBUG")]
        private void DumpOffSet(SnappOffSet offset, double diameter)
        {
            Console.WriteLine(offset.ToString() + " D:" + diameter);
        }
        /// <summary>
        /// THIS METHOD USE TO GET SNAPPER NAME
        /// </summary>
        /// <param name="p">NUMBER OF INDEXER</param>
        /// <returns>CONSTANT NAME</returns>
        private string GetBtnSnapperName(string p)
        {
            switch (p)
            {
                case "1": return CExpandDiameterControl.ELEMENT_BTN1;
                case "2": return CExpandDiameterControl.ELEMENT_BTN2;
                case "3": return CExpandDiameterControl.ELEMENT_BTN3;
                case "4": return CExpandDiameterControl.ELEMENT_BTN4;
                default: return string.Empty;
            }
        }
        #endregion

    }
}
